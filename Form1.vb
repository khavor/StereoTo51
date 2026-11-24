Option Strict On
Option Explicit On

Imports System.Diagnostics
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports Microsoft.Win32

Public Class Form1

    Private Const RegSubKeyPath As String = "Software\2to51CL_GUI"

    Private Shared ReadOnly ProgressRegex As New Regex(
        "Processing:\s*\((\d+)%\)\s*completed(?:\s*-\s*Output Max.*?:\s*(.+))?",
        RegexOptions.Compiled Or RegexOptions.IgnoreCase)

    Private Shared ReadOnly SupportedFolderExtensions As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
        ".wav", ".flac", ".aif", ".aiff", ".mp3", ".m4a", ".mp4", ".aac", ".ogg",
        ".opus", ".wma", ".wv", ".ape", ".alac", ".ac3", ".eac3", ".dts", ".mka", ".caf"
    }

    Private _cts As CancellationTokenSource
    Private _isRunning As Boolean = False
    Dim defaultExe As String

    ' ========================================================================
    ' Form Load & Registry Restore / Save
    ' ========================================================================
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettingsFromRegistry()
        UpdateAllDspReadouts()
        UpdateOutDirControls()
        UpdateLimiterControls()
        RefreshOutputPreviewPaths()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If _isRunning Then
            Dim res = MessageBox.Show(
                "A batch conversion is currently running. Cancel conversion and exit?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)
            If res = DialogResult.No Then
                e.Cancel = True
                Return
            End If
            If _cts IsNot Nothing Then
                _cts.Cancel()
            End If
        End If

        SaveSettingsToRegistry()
    End Sub

    Private Sub LoadSettingsFromRegistry()
        defaultExe = Path.Combine(Application.StartupPath, "2to51CL-FF.exe")

        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(RegSubKeyPath, False)
            'If key Is Nothing Then
            '    txtExePath.Text = defaultExe
            '    Return
            'End If

            ' Paths & Output Mode
            'txtExePath.Text = Convert.ToString(key.GetValue("ExePath", defaultExe))
            If Not File.Exists(defaultExe) Then
                MsgBox("Warning: Default executable not found at " & defaultExe, MsgBoxStyle.Exclamation, "Executable Missing")
                Exit Sub
            End If
            Dim outMode As String = Convert.ToString(key.GetValue("OutFolderMode", "Same"))
            rbOutCustomDir.Checked = String.Equals(outMode, "Custom", StringComparison.OrdinalIgnoreCase)
            rbOutSameDir.Checked = Not rbOutCustomDir.Checked
            txtOutDir.Text = Convert.ToString(key.GetValue("CustomOutFolder", String.Empty))
            txtSuffix.Text = Convert.ToString(key.GetValue("OutSuffix", "_5.1"))
            chkOverwrite.Checked = (Convert.ToInt32(key.GetValue("Overwrite", 1)) <> 0)

            ' DSP Options (stored as real-world numbers, scaled to TrackBar integers)
            'SetTrackBarFromReg(key, "cwidth", tbCWidth, 100D, 0.25D)
            StereoTo51VisualizerControl1.CenterWidth = Convert.ToDouble(key.GetValue("cwidth", 0.25))
            'SetTrackBarFromReg(key, "cslope", tbCSlope, 100D, 2.00D)
            StereoTo51VisualizerControl1.CenterSlope = Convert.ToDouble(key.GetValue("cslope", 2.0))
            SetTrackBarFromReg(key, "lfeclp", tbLfeClp, 1D, 120D)
            'SetTrackBarFromReg(key, "swidth", tbSWidth, 100D, 0.33D)
            'SetTrackBarFromReg(key, "sslope", tbSSlope, 100D, 2.00D)
            StereoTo51VisualizerControl1.SurroundWidth = Convert.ToDouble(key.GetValue("swidth", 0.33))
            StereoTo51VisualizerControl1.SurroundSlope = Convert.ToDouble(key.GetValue("sslope", 2.0))
            SetTrackBarFromReg(key, "sdelay", tbSDelay, 2D, 0.0D)
            SetTrackBarFromReg(key, "gainlr", tbGainLR, 2D, 0.0D)
            SetTrackBarFromReg(key, "gainc", tbGainC, 2D, 0.0D)
            SetTrackBarFromReg(key, "gainlfe", tbGainLFE, 2D, 0.0D)
            SetTrackBarFromReg(key, "gainslsr", tbGainLsRs, 2D, 0.0D)
            SetTrackBarFromReg(key, "cthresh", tbCThresh, 1D, -100D)
            SetTrackBarFromReg(key, "sthresh", tbSThresh, 1D, -100D)

            ' Audio Output & Encoder Options
            SetComboFromReg(key, "format", cmbFormat, "auto")
            SetComboFromReg(key, "codec", cmbCodec, "auto")
            SetComboFromReg(key, "samplerate", cmbSampleRate, "auto")
            SetComboFromReg(key, "samplefmt", cmbSampleFmt, "auto")
            SetComboFromReg(key, "bits", cmbBits, "auto")
            SetComboFromReg(key, "bitrate", cmbBitrate, "auto")
            SetNudFromReg(key, "compression", nudCompression, -1D)
            SetComboFromReg(key, "chlayout", cmbChLayout, "auto")

            SetComboFromReg(key, "limiter_mode", cmbLimiterMode, "auto")
            SetNudFromReg(key, "limiter_thresh", nudLimiterThresh, 0.94D)
            txtEncOpt.Text = Convert.ToString(key.GetValue("encopt", String.Empty))

            ' Window Dimensions
            Dim w As Integer = Convert.ToInt32(key.GetValue("WindowWidth", Me.Width))
            Dim h As Integer = Convert.ToInt32(key.GetValue("WindowHeight", Me.Height))
            If w >= Me.MinimumSize.Width AndAlso h >= Me.MinimumSize.Height Then
                Me.Size = New Size(w, h)
            End If
        End Using
    End Sub

    Private Sub SaveSettingsToRegistry()
        Using key As RegistryKey = Registry.CurrentUser.CreateSubKey(RegSubKeyPath)
            If key Is Nothing Then Return

            ' Paths & Output Mode
            'key.SetValue("ExePath", txtExePath.Text.Trim(), RegistryValueKind.String)
            key.SetValue("OutFolderMode", If(rbOutCustomDir.Checked, "Custom", "Same"), RegistryValueKind.String)
            key.SetValue("CustomOutFolder", txtOutDir.Text.Trim(), RegistryValueKind.String)
            key.SetValue("OutSuffix", txtSuffix.Text, RegistryValueKind.String)
            key.SetValue("Overwrite", If(chkOverwrite.Checked, 1, 0), RegistryValueKind.DWord)

            ' DSP Options (stored as InvariantCulture real-world values)
            'key.SetValue("cwidth", (tbCWidth.Value / 100D).ToString("0.00", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("cwidth", StereoTo51VisualizerControl1.CenterWidth.ToString("0.00", CultureInfo.InvariantCulture), RegistryValueKind.String)
            'key.SetValue("cslope", (tbCSlope.Value / 100D).ToString("0.00", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("cslope", StereoTo51VisualizerControl1.CenterSlope.ToString("0.00", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("lfeclp", tbLfeClp.Value.ToString(CultureInfo.InvariantCulture), RegistryValueKind.String)
            'key.SetValue("swidth", (tbSWidth.Value / 100D).ToString("0.00", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("swidth", StereoTo51VisualizerControl1.SurroundWidth.ToString("0.00", CultureInfo.InvariantCulture), RegistryValueKind.String)
            'key.SetValue("sslope", (tbSSlope.Value / 100D).ToString("0.00", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("sslope", StereoTo51VisualizerControl1.SurroundSlope.ToString("0.00", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("sdelay", (tbSDelay.Value / 2D).ToString("0.0", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("gainlr", (tbGainLR.Value / 2D).ToString("0.0", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("gainc", (tbGainC.Value / 2D).ToString("0.0", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("gainlfe", (tbGainLFE.Value / 2D).ToString("0.0", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("gainslsr", (tbGainLsRs.Value / 2D).ToString("0.0", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("cthresh", tbCThresh.Value.ToString(CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("sthresh", tbSThresh.Value.ToString(CultureInfo.InvariantCulture), RegistryValueKind.String)

            ' Audio Output & Encoder Options
            key.SetValue("format", cmbFormat.Text.Trim(), RegistryValueKind.String)
            key.SetValue("codec", cmbCodec.Text.Trim(), RegistryValueKind.String)
            key.SetValue("samplerate", cmbSampleRate.Text.Trim(), RegistryValueKind.String)
            key.SetValue("samplefmt", cmbSampleFmt.Text.Trim(), RegistryValueKind.String)
            key.SetValue("bits", cmbBits.Text.Trim(), RegistryValueKind.String)
            key.SetValue("bitrate", cmbBitrate.Text.Trim(), RegistryValueKind.String)
            key.SetValue("compression", nudCompression.Value.ToString(CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("chlayout", cmbChLayout.Text.Trim(), RegistryValueKind.String)

            key.SetValue("limiter_mode", cmbLimiterMode.Text.Trim(), RegistryValueKind.String)
            key.SetValue("limiter_thresh", nudLimiterThresh.Value.ToString(CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("encopt", txtEncOpt.Text, RegistryValueKind.String)

            ' Window Dimensions (only save when Normal)
            If Me.WindowState = FormWindowState.Normal Then
                key.SetValue("WindowWidth", Me.Width, RegistryValueKind.DWord)
                key.SetValue("WindowHeight", Me.Height, RegistryValueKind.DWord)
            End If
        End Using
    End Sub

    Private Shared Sub SetTrackBarFromReg(key As RegistryKey, name As String, tb As TrackBar, scale As Decimal, fallbackReal As Decimal)
        Dim raw As Object = key.GetValue(name, Nothing)
        Dim realVal As Decimal = fallbackReal
        If raw IsNot Nothing Then
            Decimal.TryParse(Convert.ToString(raw), NumberStyles.Any, CultureInfo.InvariantCulture, realVal)
        End If
        Dim tbVal As Integer = Convert.ToInt32(Math.Round(realVal * scale))
        If tbVal < tb.Minimum Then tbVal = tb.Minimum
        If tbVal > tb.Maximum Then tbVal = tb.Maximum
        tb.Value = tbVal
    End Sub

    Private Shared Sub SetNudFromReg(key As RegistryKey, name As String, nud As NumericUpDown, fallback As Decimal)
        Dim raw As Object = key.GetValue(name, Nothing)
        Dim parsed As Decimal = fallback
        If raw IsNot Nothing Then
            Decimal.TryParse(Convert.ToString(raw), NumberStyles.Any, CultureInfo.InvariantCulture, parsed)
        End If
        If parsed < nud.Minimum Then parsed = nud.Minimum
        If parsed > nud.Maximum Then parsed = nud.Maximum
        nud.Value = parsed
    End Sub

    Private Shared Sub SetComboFromReg(key As RegistryKey, name As String, cmb As ComboBox, fallback As String)
        Dim val As String = Convert.ToString(key.GetValue(name, fallback))
        If String.IsNullOrWhiteSpace(val) Then val = fallback

        If cmb.DropDownStyle = ComboBoxStyle.DropDownList Then
            Dim idx As Integer = cmb.FindStringExact(val)
            If idx >= 0 Then
                cmb.SelectedIndex = idx
            Else
                cmb.SelectedItem = fallback
            End If
        Else
            cmb.Text = val
        End If
    End Sub

    ' ========================================================================
    ' TrackBar Numerical Readout Updates
    ' ========================================================================
    Private Sub DspTrackBar_ValueChanged(sender As Object, e As EventArgs) Handles _
        tbCWidth.ValueChanged, tbCSlope.ValueChanged, tbSWidth.ValueChanged, tbSSlope.ValueChanged,
        tbLfeClp.ValueChanged, tbSDelay.ValueChanged, tbGainLR.ValueChanged, tbGainC.ValueChanged,
        tbGainLFE.ValueChanged, tbGainLsRs.ValueChanged, tbCThresh.ValueChanged, tbSThresh.ValueChanged

        UpdateAllDspReadouts()
    End Sub

    Private Sub UpdateAllDspReadouts()
        lblCWidthVal.Text = (tbCWidth.Value / 100D).ToString("0.00", CultureInfo.InvariantCulture)
        lblCSlopeVal.Text = (tbCSlope.Value / 100D).ToString("0.00", CultureInfo.InvariantCulture)
        lblSWidthVal.Text = (tbSWidth.Value / 100D).ToString("0.00", CultureInfo.InvariantCulture)
        lblSSlopeVal.Text = (tbSSlope.Value / 100D).ToString("0.00", CultureInfo.InvariantCulture)

        lblLfeClpVal.Text = tbLfeClp.Value.ToString(CultureInfo.InvariantCulture) & " Hz"
        lblSDelayVal.Text = (tbSDelay.Value / 2D).ToString("0.0", CultureInfo.InvariantCulture) & " ms"

        lblGainLRVal.Text = FormatDbReadout(tbGainLR.Value / 2D)
        lblGainCVal.Text = FormatDbReadout(tbGainC.Value / 2D)
        lblGainLFEVal.Text = FormatDbReadout(tbGainLFE.Value / 2D)
        lblGainLsRsVal.Text = FormatDbReadout(tbGainLsRs.Value / 2D)

        lblCThreshVal.Text = FormatThreshReadout(tbCThresh.Value)
        lblSThreshVal.Text = FormatThreshReadout(tbSThresh.Value)
    End Sub

    Private Shared Function FormatDbReadout(dbVal As Decimal) As String
        Dim prefix As String = If(dbVal > 0D, "+", String.Empty)
        Return prefix & dbVal.ToString("0.0", CultureInfo.InvariantCulture) & " dB"
    End Function

    Private Shared Function FormatThreshReadout(threshDb As Integer) As String
        Dim baseStr As String = threshDb.ToString(CultureInfo.InvariantCulture) & " dB"
        Return If(threshDb <= -95, baseStr & " (off)", baseStr)
    End Function

    ' ========================================================================
    ' Drag & Drop Handling
    ' ========================================================================
    Private Sub Any_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter, lvFiles.DragEnter
        If Not _isRunning AndAlso e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Any_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop, lvFiles.DragDrop
        If _isRunning OrElse Not e.Data.GetDataPresent(DataFormats.FileDrop) Then Return

        Dim droppedPaths = TryCast(e.Data.GetData(DataFormats.FileDrop), String())
        If droppedPaths Is Nothing OrElse droppedPaths.Length = 0 Then Return

        Dim filesToAdd As New List(Of String)()
        For Each p As String In droppedPaths
            If File.Exists(p) Then
                filesToAdd.Add(p)
            ElseIf Directory.Exists(p) Then
                Try
                    For Each f As String In Directory.EnumerateFiles(p, "*.*", SearchOption.AllDirectories)
                        If SupportedFolderExtensions.Contains(Path.GetExtension(f)) Then
                            filesToAdd.Add(f)
                        End If
                    Next
                Catch ex As Exception
                    AppendLog("Warning scanning folder '" & p & "': " & ex.Message)
                End Try
            End If
        Next

        AddFilesToQueue(filesToAdd)
    End Sub

    Private Sub AddFilesToQueue(paths As IEnumerable(Of String))
        Dim existing As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each item As ListViewItem In lvFiles.Items
            existing.Add(item.SubItems(3).Text)
        Next

        lvFiles.BeginUpdate()
        Try
            For Each p As String In paths
                If String.IsNullOrWhiteSpace(p) OrElse Not File.Exists(p) Then Continue For
                If existing.Contains(p) Then Continue For
                existing.Add(p)

                Dim lvi As New ListViewItem(Path.GetFileName(p))
                lvi.SubItems.Add("Pending")
                lvi.SubItems.Add(ComputeOutputPath(p))
                lvi.SubItems.Add(p)
                lvFiles.Items.Add(lvi)
            Next
        Finally
            lvFiles.EndUpdate()
        End Try

        UpdateBatchStatusLabel(0, lvFiles.Items.Count)
    End Sub

    ' ========================================================================
    ' UI Event Handlers
    ' ========================================================================
    'Private Sub btnBrowseExe_Click(sender As Object, e As EventArgs) Handles btnBrowseExe.Click
    '    Using ofd As New OpenFileDialog()
    '        ofd.Title = "Locate 2to51CL-FF.exe"
    '        ofd.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*"
    '        If File.Exists(txtExePath.Text) Then
    '            ofd.InitialDirectory = Path.GetDirectoryName(txtExePath.Text)
    '            ofd.FileName = Path.GetFileName(txtExePath.Text)
    '        End If
    '        If ofd.ShowDialog() = DialogResult.OK Then
    '            txtExePath.Text = ofd.FileName
    '        End If
    '    End Using
    'End Sub

    Private Sub btnBrowseOutDir_Click(sender As Object, e As EventArgs) Handles btnBrowseOutDir.Click
        Using fbd As New FolderBrowserDialog()
            fbd.Description = "Select Output Folder for Converted 5.1 Audio Files"
            If Directory.Exists(txtOutDir.Text) Then
                fbd.SelectedPath = txtOutDir.Text
            End If
            If fbd.ShowDialog() = DialogResult.OK Then
                txtOutDir.Text = fbd.SelectedPath
                RefreshOutputPreviewPaths()
            End If
        End Using
    End Sub

    Private Sub OutputPathSetting_Changed(sender As Object, e As EventArgs) Handles rbOutSameDir.CheckedChanged, rbOutCustomDir.CheckedChanged, txtSuffix.TextChanged, txtOutDir.TextChanged, cmbFormat.TextChanged, cmbCodec.TextChanged
        UpdateOutDirControls()
        RefreshOutputPreviewPaths()
    End Sub

    Private Sub UpdateOutDirControls()
        Dim custom As Boolean = rbOutCustomDir.Checked
        txtOutDir.Enabled = custom AndAlso Not _isRunning
        btnBrowseOutDir.Enabled = custom AndAlso Not _isRunning
    End Sub

    Private Sub cmbLimiterMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLimiterMode.SelectedIndexChanged
        UpdateLimiterControls()
    End Sub

    Private Sub UpdateLimiterControls()
        nudLimiterThresh.Enabled = String.Equals(cmbLimiterMode.Text, "custom", StringComparison.OrdinalIgnoreCase) AndAlso Not _isRunning
    End Sub

    Private Sub btnAddFiles_Click(sender As Object, e As EventArgs) Handles btnAddFiles.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select Stereo Audio Files"
            ofd.Multiselect = True
            ofd.Filter = "Audio Files|*.wav;*.flac;*.mp3;*.m4a;*.aac;*.ogg;*.opus;*.aif;*.aiff;*.wma;*.wv;*.mka;*.caf|All Files (*.*)|*.*"
            If ofd.ShowDialog() = DialogResult.OK Then
                AddFilesToQueue(ofd.FileNames)
            End If
        End Using
    End Sub

    Private Sub btnRemoveSelected_Click(sender As Object, e As EventArgs) Handles btnRemoveSelected.Click
        For i As Integer = lvFiles.SelectedItems.Count - 1 To 0 Step -1
            lvFiles.Items.Remove(lvFiles.SelectedItems(i))
        Next
        UpdateBatchStatusLabel(0, lvFiles.Items.Count)
    End Sub

    Private Sub btnClearList_Click(sender As Object, e As EventArgs) Handles btnClearList.Click
        lvFiles.Items.Clear()
        pbFile.Value = 0
        pbBatch.Value = 0
        lblFileStatus.Text = "Current File: Idle"
        UpdateBatchStatusLabel(0, 0)
    End Sub

    Private Sub btnResetDefaults_Click(sender As Object, e As EventArgs) Handles btnResetDefaults.Click
        tbCWidth.Value = 25
        StereoTo51VisualizerControl1.CenterWidth = 0.25
        tbCSlope.Value = 200
        StereoTo51VisualizerControl1.CenterSlope = 2.0
        tbLfeClp.Value = 120
        tbSWidth.Value = 33
        StereoTo51VisualizerControl1.SurroundWidth = 0.33
        tbSSlope.Value = 200
        StereoTo51VisualizerControl1.SurroundSlope = 2.0
        tbSDelay.Value = 0
        tbGainLR.Value = 0
        tbGainC.Value = 0
        tbGainLFE.Value = 0
        tbGainLsRs.Value = 0
        tbCThresh.Value = -100
        tbSThresh.Value = -100
        UpdateAllDspReadouts()

        cmbFormat.Text = "auto"
        cmbCodec.Text = "auto"
        cmbSampleRate.Text = "auto"
        cmbSampleFmt.Text = "auto"
        cmbBits.SelectedItem = "auto"
        cmbBitrate.Text = "auto"
        nudCompression.Value = -1D
        cmbChLayout.SelectedItem = "auto"
        cmbLimiterMode.SelectedItem = "auto"
        nudLimiterThresh.Value = 0.94D
        txtEncOpt.Clear()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If _cts IsNot Nothing AndAlso Not _cts.IsCancellationRequested Then
            AppendLog("Cancelling batch conversion...")
            btnCancel.Enabled = False
            _cts.Cancel()
        End If
    End Sub

    ' ========================================================================
    ' Output Path & CLI Argument Building
    ' ========================================================================
    Private Function ComputeOutputPath(inputPath As String) As String
        Dim dir As String
        If rbOutCustomDir.Checked AndAlso Not String.IsNullOrWhiteSpace(txtOutDir.Text) Then
            dir = txtOutDir.Text.Trim()
        Else
            dir = Path.GetDirectoryName(inputPath)
        End If

        Dim baseName As String = Path.GetFileNameWithoutExtension(inputPath)
        Dim suffix As String = txtSuffix.Text
        Dim ext As String = ResolveOutputExtension(inputPath)

        Dim outPath As String = Path.Combine(dir, baseName & suffix & ext)
        If String.Equals(outPath, inputPath, StringComparison.OrdinalIgnoreCase) Then
            outPath = Path.Combine(dir, baseName & "_5.1" & ext)
        End If
        Return outPath
    End Function

    Private Function ResolveOutputExtension(inputPath As String) As String
        Dim fmt As String = cmbFormat.Text.Trim().ToLowerInvariant()
        If Not String.IsNullOrEmpty(fmt) AndAlso fmt <> "auto" Then
            Select Case fmt
                Case "wav" : Return ".wav"
                Case "flac" : Return ".flac"
                Case "wv", "wavpack" : Return ".wv"
                Case "mp4" : Return ".m4a"
                Case "matroska" : Return ".mka"
                Case "ac3" : Return ".ac3"
                Case "eac3" : Return ".eac3"
                Case "ogg" : Return ".ogg"
                Case "opus" : Return ".opus"
                Case "caf" : Return ".caf"
                Case "aiff" : Return ".aiff"
                Case "adts" : Return ".aac"
                Case "dts" : Return ".dts"
                Case Else : Return "." & fmt
            End Select
        End If

        Dim codec As String = cmbCodec.Text.Trim().ToLowerInvariant()
        If Not String.IsNullOrEmpty(codec) AndAlso codec <> "auto" Then
            Select Case codec
                Case "flac" : Return ".flac"
                Case "wavpack" : Return ".wv"
                Case "ac3" : Return ".ac3"
                Case "eac3" : Return ".eac3"
                Case "aac" : Return ".m4a"
                Case "alac" : Return ".m4a"
                Case "libopus" : Return ".opus"
                Case "libvorbis" : Return ".ogg"
                Case "dca" : Return ".dts"
                Case "pcm_s16le", "pcm_s24le", "pcm_s32le", "pcm_f32le", "pcm_f64le" : Return ".wav"
            End Select
        End If

        Dim origExt As String = Path.GetExtension(inputPath)
        Return If(String.IsNullOrEmpty(origExt), ".wav", origExt)
    End Function

    Private Sub RefreshOutputPreviewPaths()
        For Each item As ListViewItem In lvFiles.Items
            Dim inPath As String = item.SubItems(3).Text
            item.SubItems(2).Text = ComputeOutputPath(inPath)
        Next
    End Sub

    Private Function BuildArguments(inputPath As String, outputPath As String) As String
        Dim args As New List(Of String)()

        ' Input & Output
        args.Add("--input " & QuoteArg(inputPath))
        args.Add("--output " & QuoteArg(outputPath))

        ' DSP Switches
        'args.Add("--cwidth " & (tbCWidth.Value / 100D).ToString("0.00", CultureInfo.InvariantCulture))
        args.Add("--cwidth " & StereoTo51VisualizerControl1.CenterWidth.ToString("0.00", CultureInfo.InvariantCulture))
        'args.Add("--cslope " & (tbCSlope.Value / 100D).ToString("0.00", CultureInfo.InvariantCulture))
        args.Add("--cslope " & StereoTo51VisualizerControl1.CenterSlope.ToString("0.00", CultureInfo.InvariantCulture))
        args.Add("--lfeclp " & tbLfeClp.Value.ToString(CultureInfo.InvariantCulture))
        'args.Add("--swidth " & (tbSWidth.Value / 100D).ToString("0.00", CultureInfo.InvariantCulture))
        args.Add("--swidth " & StereoTo51VisualizerControl1.SurroundWidth.ToString("0.00", CultureInfo.InvariantCulture))
        'args.Add("--sslope " & (tbSSlope.Value / 100D).ToString("0.00", CultureInfo.InvariantCulture))
        args.Add("--sslope " & StereoTo51VisualizerControl1.SurroundSlope.ToString("0.00", CultureInfo.InvariantCulture))
        args.Add("--sdelay " & (tbSDelay.Value / 2D).ToString("0.0", CultureInfo.InvariantCulture))
        args.Add("--gainlr " & (tbGainLR.Value / 2D).ToString("0.0", CultureInfo.InvariantCulture))
        args.Add("--gainc " & (tbGainC.Value / 2D).ToString("0.0", CultureInfo.InvariantCulture))
        args.Add("--gainlfe " & (tbGainLFE.Value / 2D).ToString("0.0", CultureInfo.InvariantCulture))
        args.Add("--gainslsr " & (tbGainLsRs.Value / 2D).ToString("0.0", CultureInfo.InvariantCulture))
        args.Add("--cthresh " & tbCThresh.Value.ToString(CultureInfo.InvariantCulture))
        args.Add("--sthresh " & tbSThresh.Value.ToString(CultureInfo.InvariantCulture))

        ' Output Format & Encoder Switches
        Dim fmt As String = cmbFormat.Text.Trim()
        If Not String.IsNullOrEmpty(fmt) AndAlso Not fmt.Equals("auto", StringComparison.OrdinalIgnoreCase) Then
            args.Add("--format " & QuoteArg(fmt))
        End If

        Dim codec As String = cmbCodec.Text.Trim()
        If Not String.IsNullOrEmpty(codec) AndAlso Not codec.Equals("auto", StringComparison.OrdinalIgnoreCase) Then
            args.Add("--codec " & QuoteArg(codec))
        End If

        Dim srText As String = cmbSampleRate.Text.Trim()
        Dim srVal As Integer
        If Integer.TryParse(srText, NumberStyles.Integer, CultureInfo.InvariantCulture, srVal) AndAlso srVal > 0 Then
            args.Add("--samplerate " & srVal.ToString(CultureInfo.InvariantCulture))
        End If

        Dim sfmt As String = cmbSampleFmt.Text.Trim()
        If Not String.IsNullOrEmpty(sfmt) AndAlso Not sfmt.Equals("auto", StringComparison.OrdinalIgnoreCase) Then
            args.Add("--samplefmt " & QuoteArg(sfmt))
        End If

        Dim bits As String = cmbBits.Text.Trim()
        If bits = "16" OrElse bits = "24" OrElse bits = "32" Then
            args.Add("--bits " & bits)
        End If

        Dim br As String = cmbBitrate.Text.Trim()
        If Not String.IsNullOrEmpty(br) AndAlso Not br.Equals("auto", StringComparison.OrdinalIgnoreCase) Then
            args.Add("--bitrate " & QuoteArg(br))
        End If

        If nudCompression.Value >= 0D Then
            args.Add("--compression " & Convert.ToInt32(nudCompression.Value).ToString(CultureInfo.InvariantCulture))
        End If

        Dim chLayout As String = cmbChLayout.Text.Trim()
        If Not String.IsNullOrEmpty(chLayout) AndAlso Not chLayout.Equals("auto", StringComparison.OrdinalIgnoreCase) Then
            args.Add("--chlayout " & QuoteArg(chLayout))
        End If

        Dim limMode As String = cmbLimiterMode.Text.Trim().ToLowerInvariant()
        If limMode = "off" Then
            args.Add("--limiter off")
        ElseIf limMode = "custom" Then
            args.Add("--limiter " & nudLimiterThresh.Value.ToString(CultureInfo.InvariantCulture))
        End If

        ' Repeatable --encopt k=v
        If Not String.IsNullOrWhiteSpace(txtEncOpt.Text) Then
            Dim lines = txtEncOpt.Text.Split(New String() {vbCrLf, vbLf, vbCr}, StringSplitOptions.RemoveEmptyEntries)
            For Each rawLine As String In lines
                Dim kv As String = rawLine.Trim()
                If kv.Length > 0 AndAlso kv.Contains("=") Then
                    args.Add("--encopt " & QuoteArg(kv))
                End If
            Next
        End If

        Return String.Join(" ", args)
    End Function

    Private Shared Function QuoteArg(value As String) As String
        If value Is Nothing Then Return """"""
        Return """" & value.Replace("""", "\""") & """"
    End Function

    ' ========================================================================
    ' Batch Conversion Execution & Real-time Progress Parsing
    ' ========================================================================
    Private Async Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If _isRunning Then Return

        Dim exePath As String = defaultExe.Trim()
        If Not File.Exists(exePath) Then
            MessageBox.Show("Could not find 2to51CL-FF executable at:" & Environment.NewLine & exePath,
                            "Executable Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If lvFiles.Items.Count = 0 Then
            MessageBox.Show("Please drag and drop or add at least one stereo audio file.",
                            "Queue Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If rbOutCustomDir.Checked Then
            Dim customDir As String = txtOutDir.Text.Trim()
            If String.IsNullOrWhiteSpace(customDir) Then
                MessageBox.Show("Please specify a custom output folder.",
                                "Output Folder Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Directory.CreateDirectory(customDir)
        End If

        RefreshOutputPreviewPaths()
        SetRunningState(True)
        txtLog.Clear()

        _cts = New CancellationTokenSource()
        Dim totalCount As Integer = lvFiles.Items.Count
        pbBatch.Minimum = 0
        pbBatch.Maximum = totalCount * 100
        pbBatch.Value = 0

        Dim succeeded As Integer = 0
        Dim failed As Integer = 0
        Dim skipped As Integer = 0

        Try
            For idx As Integer = 0 To totalCount - 1
                If _cts.Token.IsCancellationRequested Then Exit For

                Dim item As ListViewItem = lvFiles.Items(idx)
                Dim inPath As String = item.SubItems(3).Text
                Dim outPath As String = ComputeOutputPath(inPath)
                item.SubItems(2).Text = outPath
                item.EnsureVisible()

                If Not chkOverwrite.Checked AndAlso File.Exists(outPath) Then
                    item.SubItems(1).Text = "Skipped"
                    skipped += 1
                    pbFile.Value = 100
                    pbBatch.Value = Math.Min(pbBatch.Maximum, (idx + 1) * 100)
                    UpdateBatchStatusLabel(idx + 1, totalCount)
                    AppendLog($"[{idx + 1}/{totalCount}] Skipped (exists): {outPath}")
                    Continue For
                End If

                Dim outDir As String = Path.GetDirectoryName(outPath)
                If Not String.IsNullOrEmpty(outDir) AndAlso Not Directory.Exists(outDir) Then
                    Directory.CreateDirectory(outDir)
                End If

                item.SubItems(1).Text = "Converting..."
                pbFile.Value = 0
                lblFileStatus.Text = $"File {idx + 1} of {totalCount}: {Path.GetFileName(inPath)} (0%)"
                UpdateBatchStatusLabel(idx, totalCount)

                Dim cliArgs As String = BuildArguments(inPath, outPath)
                AppendLog($"[{idx + 1}/{totalCount}] ""{exePath}"" {cliArgs}")

                Dim exitCode As Integer = Await RunSingleFileAsync(exePath, cliArgs, idx, totalCount, Path.GetFileName(inPath), _cts.Token)

                If _cts.Token.IsCancellationRequested Then
                    item.SubItems(1).Text = "Cancelled"
                    Exit For
                ElseIf exitCode = 0 Then
                    item.SubItems(1).Text = "Done"
                    pbFile.Value = 100
                    pbBatch.Value = Math.Min(pbBatch.Maximum, (idx + 1) * 100)
                    succeeded += 1
                    AppendLog($"[{idx + 1}/{totalCount}] Completed successfully.")
                Else
                    item.SubItems(1).Text = $"Error ({exitCode})"
                    pbBatch.Value = Math.Min(pbBatch.Maximum, (idx + 1) * 100)
                    failed += 1
                    AppendLog($"[{idx + 1}/{totalCount}] Failed with exit code {exitCode}.")
                End If

                UpdateBatchStatusLabel(idx + 1, totalCount)
            Next
        Catch ex As OperationCanceledException
            AppendLog("Batch cancelled.")
        Catch ex As Exception
            AppendLog("Unexpected error: " & ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If _cts IsNot Nothing Then
                _cts.Dispose()
                _cts = Nothing
            End If
            SetRunningState(False)
            AppendLog($"--- Batch finished: {succeeded} succeeded, {failed} failed, {skipped} skipped ---")
        End Try
    End Sub

    Private Async Function RunSingleFileAsync(
        exePath As String,
        arguments As String,
        fileIndex As Integer,
        totalFiles As Integer,
        fileName As String,
        ct As CancellationToken) As Task(Of Integer)

        Dim psi As New ProcessStartInfo() With {
            .FileName = exePath,
            .Arguments = arguments,
            .UseShellExecute = False,
            .CreateNoWindow = True,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .StandardOutputEncoding = Encoding.UTF8,
            .StandardErrorEncoding = Encoding.UTF8
        }

        Using proc As New Process() With {.StartInfo = psi}
            proc.Start()

            Using reg = ct.Register(
                Sub()
                    Try
                        If Not proc.HasExited Then
                            proc.Kill()
                        End If
                    Catch
                        ' Ignore race if process already exited
                    End Try
                End Sub)

                Dim outTask = ReadStreamSegmentsAsync(
                    proc.StandardOutput.BaseStream,
                    Encoding.UTF8,
                    Sub(line As String)
                        HandleStdoutLine(line, fileIndex, totalFiles, fileName)
                    End Sub)

                Dim errTask = ReadStreamSegmentsAsync(
                    proc.StandardError.BaseStream,
                    Encoding.UTF8,
                    Sub(line As String)
                        AppendLogThreadSafe("[ERR] " & line)
                    End Sub)

                Await Task.WhenAll(outTask, errTask)
                Await Task.Run(Sub() proc.WaitForExit())

                Return proc.ExitCode
            End Using
        End Using
    End Function

    Private Shared Async Function ReadStreamSegmentsAsync(
        stream As Stream,
        encoding As Encoding,
        onSegment As Action(Of String)) As Task

        Dim buffer(4095) As Byte
        Dim charBuf(4095) As Char
        Dim decoder As Decoder = encoding.GetDecoder()
        Dim sb As New StringBuilder()

        While True
            Dim bytesRead As Integer = Await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(False)
            If bytesRead <= 0 Then Exit While

            Dim charsDecoded As Integer = decoder.GetChars(buffer, 0, bytesRead, charBuf, 0, False)
            For i As Integer = 0 To charsDecoded - 1
                Dim ch As Char = charBuf(i)
                If ch = ControlChars.Cr OrElse ch = ControlChars.Lf Then
                    If sb.Length > 0 Then
                        onSegment(sb.ToString())
                        sb.Clear()
                    End If
                Else
                    sb.Append(ch)
                End If
            Next
        End While

        If sb.Length > 0 Then
            onSegment(sb.ToString())
        End If
    End Function

    Private Sub HandleStdoutLine(line As String, fileIndex As Integer, totalFiles As Integer, fileName As String)
        Dim m As Match = ProgressRegex.Match(line)
        If m.Success Then
            Dim pct As Integer
            If Integer.TryParse(m.Groups(1).Value, pct) Then
                pct = Math.Max(0, Math.Min(100, pct))
                Dim peaks As String = If(m.Groups.Count > 2 AndAlso m.Groups(2).Success, m.Groups(2).Value.Trim(), String.Empty)

                If Not Me.IsDisposed Then
                    Me.BeginInvoke(
                        Sub()
                            pbFile.Value = pct
                            pbBatch.Value = Math.Min(pbBatch.Maximum, (fileIndex * 100) + pct)
                            If String.IsNullOrEmpty(peaks) Then
                                lblFileStatus.Text = $"File {fileIndex + 1} of {totalFiles}: {fileName} ({pct}%)"
                            Else
                                lblFileStatus.Text = $"File {fileIndex + 1} of {totalFiles}: {fileName} ({pct}%) | Peaks [Max L/R C LFE Ls/Rs]: {peaks}"
                            End If
                        End Sub)
                End If
            End If
        Else
            AppendLogThreadSafe(line)
        End If
    End Sub

    Private Sub AppendLogThreadSafe(text As String)
        If String.IsNullOrWhiteSpace(text) OrElse Me.IsDisposed Then Return
        If Me.InvokeRequired Then
            Me.BeginInvoke(Sub() AppendLog(text))
        Else
            AppendLog(text)
        End If
    End Sub

    Private Sub AppendLog(text As String)
        txtLog.AppendText(text & Environment.NewLine)
    End Sub

    Private Sub UpdateBatchStatusLabel(completed As Integer, total As Integer)
        lblBatchStatus.Text = $"Batch Progress: {completed} / {total} files"
    End Sub

    Private Sub SetRunningState(running As Boolean)
        _isRunning = running

        btnStart.Enabled = Not running
        btnCancel.Enabled = running
        btnAddFiles.Enabled = Not running
        btnRemoveSelected.Enabled = Not running
        btnClearList.Enabled = Not running
        btnResetDefaults.Enabled = Not running

        grpPaths.Enabled = Not running
        grpDsp.Enabled = Not running
        grpOutput.Enabled = Not running

        If Not running Then
            UpdateOutDirControls()
            UpdateLimiterControls()
        End If
    End Sub

End Class
