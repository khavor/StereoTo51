<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tlpRoot = New System.Windows.Forms.TableLayoutPanel()
        Me.grpPaths = New System.Windows.Forms.GroupBox()
        Me.lblOutMode = New System.Windows.Forms.Label()
        Me.rbOutSameDir = New System.Windows.Forms.RadioButton()
        Me.rbOutCustomDir = New System.Windows.Forms.RadioButton()
        Me.lblSuffix = New System.Windows.Forms.Label()
        Me.txtSuffix = New System.Windows.Forms.TextBox()
        Me.chkOverwrite = New System.Windows.Forms.CheckBox()
        Me.lblOutDir = New System.Windows.Forms.Label()
        Me.txtOutDir = New System.Windows.Forms.TextBox()
        Me.btnBrowseOutDir = New System.Windows.Forms.Button()
        Me.tlpSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.grpDsp = New System.Windows.Forms.GroupBox()
        Me.lblCWidth = New System.Windows.Forms.Label()
        Me.tbCWidth = New System.Windows.Forms.TrackBar()
        Me.lblCWidthVal = New System.Windows.Forms.Label()
        Me.lblCSlope = New System.Windows.Forms.Label()
        Me.tbCSlope = New System.Windows.Forms.TrackBar()
        Me.lblCSlopeVal = New System.Windows.Forms.Label()
        Me.lblSWidth = New System.Windows.Forms.Label()
        Me.tbSWidth = New System.Windows.Forms.TrackBar()
        Me.lblSWidthVal = New System.Windows.Forms.Label()
        Me.lblSSlope = New System.Windows.Forms.Label()
        Me.tbSSlope = New System.Windows.Forms.TrackBar()
        Me.lblSSlopeVal = New System.Windows.Forms.Label()
        Me.tbLfeClp = New System.Windows.Forms.TrackBar()
        Me.lblLfeClpVal = New System.Windows.Forms.Label()
        Me.tbSDelay = New System.Windows.Forms.TrackBar()
        Me.lblSDelayVal = New System.Windows.Forms.Label()
        Me.tbGainLR = New System.Windows.Forms.TrackBar()
        Me.lblGainLRVal = New System.Windows.Forms.Label()
        Me.tbGainC = New System.Windows.Forms.TrackBar()
        Me.lblGainCVal = New System.Windows.Forms.Label()
        Me.tbGainLFE = New System.Windows.Forms.TrackBar()
        Me.lblGainLFEVal = New System.Windows.Forms.Label()
        Me.tbGainLsRs = New System.Windows.Forms.TrackBar()
        Me.lblGainLsRsVal = New System.Windows.Forms.Label()
        Me.lblCThresh = New System.Windows.Forms.Label()
        Me.tbCThresh = New System.Windows.Forms.TrackBar()
        Me.lblCThreshVal = New System.Windows.Forms.Label()
        Me.tbSThresh = New System.Windows.Forms.TrackBar()
        Me.lblSThreshVal = New System.Windows.Forms.Label()
        Me.grpOutput = New System.Windows.Forms.GroupBox()
        Me.tlpOutput = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFormat = New System.Windows.Forms.Label()
        Me.cmbFormat = New System.Windows.Forms.ComboBox()
        Me.lblCodec = New System.Windows.Forms.Label()
        Me.cmbCodec = New System.Windows.Forms.ComboBox()
        Me.lblSampleRate = New System.Windows.Forms.Label()
        Me.cmbSampleRate = New System.Windows.Forms.ComboBox()
        Me.lblSampleFmt = New System.Windows.Forms.Label()
        Me.cmbSampleFmt = New System.Windows.Forms.ComboBox()
        Me.lblBits = New System.Windows.Forms.Label()
        Me.cmbBits = New System.Windows.Forms.ComboBox()
        Me.lblBitrate = New System.Windows.Forms.Label()
        Me.cmbBitrate = New System.Windows.Forms.ComboBox()
        Me.lblCompression = New System.Windows.Forms.Label()
        Me.nudCompression = New System.Windows.Forms.NumericUpDown()
        Me.lblChLayout = New System.Windows.Forms.Label()
        Me.cmbChLayout = New System.Windows.Forms.ComboBox()
        Me.lblLimiter = New System.Windows.Forms.Label()
        Me.pnlLimiter = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmbLimiterMode = New System.Windows.Forms.ComboBox()
        Me.nudLimiterThresh = New System.Windows.Forms.NumericUpDown()
        Me.lblEncOpt = New System.Windows.Forms.Label()
        Me.txtEncOpt = New System.Windows.Forms.TextBox()
        Me.grpQueue = New System.Windows.Forms.GroupBox()
        Me.tlpQueue = New System.Windows.Forms.TableLayoutPanel()
        Me.lvFiles = New System.Windows.Forms.ListView()
        Me.colFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colOutput = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colInput = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlQueueButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAddFiles = New System.Windows.Forms.Button()
        Me.btnRemoveSelected = New System.Windows.Forms.Button()
        Me.btnClearList = New System.Windows.Forms.Button()
        Me.btnResetDefaults = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tlpProgress = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFileStatus = New System.Windows.Forms.Label()
        Me.lblBatchStatus = New System.Windows.Forms.Label()
        Me.pbFile = New System.Windows.Forms.ProgressBar()
        Me.pbBatch = New System.Windows.Forms.ProgressBar()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.StereoTo51VisualizerControl1 = New StereoTo51.StereoTo51VisualizerControl()
        Me.tlpRoot.SuspendLayout()
        Me.grpPaths.SuspendLayout()
        Me.tlpSettings.SuspendLayout()
        Me.grpDsp.SuspendLayout()
        CType(Me.tbCWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCSlope, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSSlope, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLfeClp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbGainLR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbGainC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbGainLFE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbGainLsRs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCThresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSThresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOutput.SuspendLayout()
        Me.tlpOutput.SuspendLayout()
        CType(Me.nudCompression, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLimiter.SuspendLayout()
        CType(Me.nudLimiterThresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpQueue.SuspendLayout()
        Me.tlpQueue.SuspendLayout()
        Me.pnlQueueButtons.SuspendLayout()
        Me.tlpProgress.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpRoot
        '
        Me.tlpRoot.ColumnCount = 1
        Me.tlpRoot.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRoot.Controls.Add(Me.grpPaths, 0, 0)
        Me.tlpRoot.Controls.Add(Me.tlpSettings, 0, 1)
        Me.tlpRoot.Controls.Add(Me.grpQueue, 0, 2)
        Me.tlpRoot.Controls.Add(Me.tlpProgress, 0, 3)
        Me.tlpRoot.Controls.Add(Me.txtLog, 0, 4)
        Me.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpRoot.Location = New System.Drawing.Point(0, 0)
        Me.tlpRoot.Name = "tlpRoot"
        Me.tlpRoot.Padding = New System.Windows.Forms.Padding(8)
        Me.tlpRoot.RowCount = 5
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.tlpRoot.Size = New System.Drawing.Size(1160, 877)
        Me.tlpRoot.TabIndex = 0
        '
        'grpPaths
        '
        Me.grpPaths.Controls.Add(Me.btnBrowseOutDir)
        Me.grpPaths.Controls.Add(Me.txtOutDir)
        Me.grpPaths.Controls.Add(Me.lblOutMode)
        Me.grpPaths.Controls.Add(Me.lblSuffix)
        Me.grpPaths.Controls.Add(Me.lblOutDir)
        Me.grpPaths.Controls.Add(Me.chkOverwrite)
        Me.grpPaths.Controls.Add(Me.rbOutSameDir)
        Me.grpPaths.Controls.Add(Me.txtSuffix)
        Me.grpPaths.Controls.Add(Me.rbOutCustomDir)
        Me.grpPaths.Location = New System.Drawing.Point(11, 11)
        Me.grpPaths.Name = "grpPaths"
        Me.grpPaths.Size = New System.Drawing.Size(681, 66)
        Me.grpPaths.TabIndex = 0
        Me.grpPaths.TabStop = False
        Me.grpPaths.Text = "Executable && Output Location"
        '
        'lblOutMode
        '
        Me.lblOutMode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOutMode.Location = New System.Drawing.Point(7, 17)
        Me.lblOutMode.Name = "lblOutMode"
        Me.lblOutMode.Size = New System.Drawing.Size(81, 13)
        Me.lblOutMode.TabIndex = 3
        Me.lblOutMode.Text = "Output Options:"
        '
        'rbOutSameDir
        '
        Me.rbOutSameDir.AutoSize = True
        Me.rbOutSameDir.Checked = True
        Me.rbOutSameDir.Location = New System.Drawing.Point(90, 16)
        Me.rbOutSameDir.Name = "rbOutSameDir"
        Me.rbOutSameDir.Size = New System.Drawing.Size(121, 17)
        Me.rbOutSameDir.TabIndex = 0
        Me.rbOutSameDir.TabStop = True
        Me.rbOutSameDir.Text = "Same folder as input"
        '
        'rbOutCustomDir
        '
        Me.rbOutCustomDir.AutoSize = True
        Me.rbOutCustomDir.Location = New System.Drawing.Point(212, 16)
        Me.rbOutCustomDir.Name = "rbOutCustomDir"
        Me.rbOutCustomDir.Size = New System.Drawing.Size(89, 17)
        Me.rbOutCustomDir.TabIndex = 1
        Me.rbOutCustomDir.Text = "Custom folder"
        '
        'lblSuffix
        '
        Me.lblSuffix.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSuffix.AutoSize = True
        Me.lblSuffix.Location = New System.Drawing.Point(393, 18)
        Me.lblSuffix.Margin = New System.Windows.Forms.Padding(12, 3, 3, 3)
        Me.lblSuffix.Name = "lblSuffix"
        Me.lblSuffix.Size = New System.Drawing.Size(81, 13)
        Me.lblSuffix.TabIndex = 2
        Me.lblSuffix.Text = "Filename Suffix:"
        '
        'txtSuffix
        '
        Me.txtSuffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuffix.Location = New System.Drawing.Point(476, 15)
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.Size = New System.Drawing.Size(90, 20)
        Me.txtSuffix.TabIndex = 3
        Me.txtSuffix.Text = "_5.1"
        '
        'chkOverwrite
        '
        Me.chkOverwrite.AutoSize = True
        Me.chkOverwrite.Checked = True
        Me.chkOverwrite.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOverwrite.Location = New System.Drawing.Point(574, 17)
        Me.chkOverwrite.Margin = New System.Windows.Forms.Padding(12, 3, 3, 3)
        Me.chkOverwrite.Name = "chkOverwrite"
        Me.chkOverwrite.Size = New System.Drawing.Size(104, 17)
        Me.chkOverwrite.TabIndex = 4
        Me.chkOverwrite.Text = "Overwrite output"
        '
        'lblOutDir
        '
        Me.lblOutDir.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOutDir.AutoSize = True
        Me.lblOutDir.Location = New System.Drawing.Point(11, 40)
        Me.lblOutDir.Name = "lblOutDir"
        Me.lblOutDir.Size = New System.Drawing.Size(77, 13)
        Me.lblOutDir.TabIndex = 5
        Me.lblOutDir.Text = "Custom Folder:"
        '
        'txtOutDir
        '
        Me.txtOutDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutDir.Enabled = False
        Me.txtOutDir.Location = New System.Drawing.Point(87, 37)
        Me.txtOutDir.Name = "txtOutDir"
        Me.txtOutDir.Size = New System.Drawing.Size(479, 20)
        Me.txtOutDir.TabIndex = 6
        '
        'btnBrowseOutDir
        '
        Me.btnBrowseOutDir.AutoSize = True
        Me.btnBrowseOutDir.Enabled = False
        Me.btnBrowseOutDir.Location = New System.Drawing.Point(572, 36)
        Me.btnBrowseOutDir.Name = "btnBrowseOutDir"
        Me.btnBrowseOutDir.Size = New System.Drawing.Size(97, 23)
        Me.btnBrowseOutDir.TabIndex = 7
        Me.btnBrowseOutDir.Text = "Browse..."
        '
        'tlpSettings
        '
        Me.tlpSettings.ColumnCount = 2
        Me.tlpSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 685.0!))
        Me.tlpSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSettings.Controls.Add(Me.grpDsp, 0, 0)
        Me.tlpSettings.Controls.Add(Me.grpOutput, 1, 0)
        Me.tlpSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpSettings.Location = New System.Drawing.Point(11, 83)
        Me.tlpSettings.Name = "tlpSettings"
        Me.tlpSettings.RowCount = 1
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSettings.Size = New System.Drawing.Size(1138, 400)
        Me.tlpSettings.TabIndex = 1
        '
        'grpDsp
        '
        Me.grpDsp.Controls.Add(Me.Panel1)
        Me.grpDsp.Controls.Add(Me.Label21)
        Me.grpDsp.Controls.Add(Me.Label22)
        Me.grpDsp.Controls.Add(Me.Label23)
        Me.grpDsp.Controls.Add(Me.lblGainCVal)
        Me.grpDsp.Controls.Add(Me.Label18)
        Me.grpDsp.Controls.Add(Me.Label19)
        Me.grpDsp.Controls.Add(Me.Label20)
        Me.grpDsp.Controls.Add(Me.lblGainLsRsVal)
        Me.grpDsp.Controls.Add(Me.Label15)
        Me.grpDsp.Controls.Add(Me.tbGainC)
        Me.grpDsp.Controls.Add(Me.Label16)
        Me.grpDsp.Controls.Add(Me.Label17)
        Me.grpDsp.Controls.Add(Me.Label12)
        Me.grpDsp.Controls.Add(Me.Label13)
        Me.grpDsp.Controls.Add(Me.Label14)
        Me.grpDsp.Controls.Add(Me.lblCThreshVal)
        Me.grpDsp.Controls.Add(Me.tbGainLsRs)
        Me.grpDsp.Controls.Add(Me.lblGainLRVal)
        Me.grpDsp.Controls.Add(Me.Label9)
        Me.grpDsp.Controls.Add(Me.Label10)
        Me.grpDsp.Controls.Add(Me.tbGainLR)
        Me.grpDsp.Controls.Add(Me.Label11)
        Me.grpDsp.Controls.Add(Me.Label8)
        Me.grpDsp.Controls.Add(Me.Label7)
        Me.grpDsp.Controls.Add(Me.lblSDelayVal)
        Me.grpDsp.Controls.Add(Me.Label6)
        Me.grpDsp.Controls.Add(Me.lblSThreshVal)
        Me.grpDsp.Controls.Add(Me.Label5)
        Me.grpDsp.Controls.Add(Me.Label4)
        Me.grpDsp.Controls.Add(Me.Label3)
        Me.grpDsp.Controls.Add(Me.Label2)
        Me.grpDsp.Controls.Add(Me.Label1)
        Me.grpDsp.Controls.Add(Me.StereoTo51VisualizerControl1)
        Me.grpDsp.Controls.Add(Me.tbSDelay)
        Me.grpDsp.Controls.Add(Me.lblCThresh)
        Me.grpDsp.Controls.Add(Me.tbCThresh)
        Me.grpDsp.Controls.Add(Me.tbSThresh)
        Me.grpDsp.Controls.Add(Me.tbLfeClp)
        Me.grpDsp.Controls.Add(Me.lblLfeClpVal)
        Me.grpDsp.Controls.Add(Me.lblGainLFEVal)
        Me.grpDsp.Controls.Add(Me.tbGainLFE)
        Me.grpDsp.Location = New System.Drawing.Point(3, 3)
        Me.grpDsp.Name = "grpDsp"
        Me.grpDsp.Size = New System.Drawing.Size(677, 385)
        Me.grpDsp.TabIndex = 0
        Me.grpDsp.TabStop = False
        Me.grpDsp.Text = "Upmix DSP Options"
        '
        'lblCWidth
        '
        Me.lblCWidth.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCWidth.Location = New System.Drawing.Point(28, 47)
        Me.lblCWidth.Name = "lblCWidth"
        Me.lblCWidth.Size = New System.Drawing.Size(98, 13)
        Me.lblCWidth.TabIndex = 0
        Me.lblCWidth.Text = "Center Width (-cw):"
        Me.lblCWidth.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'tbCWidth
        '
        Me.tbCWidth.AutoSize = False
        Me.tbCWidth.LargeChange = 10
        Me.tbCWidth.Location = New System.Drawing.Point(129, 42)
        Me.tbCWidth.Maximum = 100
        Me.tbCWidth.Name = "tbCWidth"
        Me.tbCWidth.Size = New System.Drawing.Size(118, 28)
        Me.tbCWidth.TabIndex = 1
        Me.tbCWidth.TickFrequency = 10
        Me.toolTip1.SetToolTip(Me.tbCWidth, "Center spectral width fraction (0.0 to 1.0)")
        Me.tbCWidth.Value = 25
        '
        'lblCWidthVal
        '
        Me.lblCWidthVal.Location = New System.Drawing.Point(252, 36)
        Me.lblCWidthVal.Margin = New System.Windows.Forms.Padding(2, 0, 8, 0)
        Me.lblCWidthVal.Name = "lblCWidthVal"
        Me.lblCWidthVal.Size = New System.Drawing.Size(72, 34)
        Me.lblCWidthVal.TabIndex = 2
        Me.lblCWidthVal.Text = "0.25"
        Me.lblCWidthVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCSlope
        '
        Me.lblCSlope.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCSlope.Location = New System.Drawing.Point(22, 122)
        Me.lblCSlope.Name = "lblCSlope"
        Me.lblCSlope.Size = New System.Drawing.Size(94, 13)
        Me.lblCSlope.TabIndex = 3
        Me.lblCSlope.Text = "Center Slope (-cs):"
        Me.lblCSlope.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'tbCSlope
        '
        Me.tbCSlope.AutoSize = False
        Me.tbCSlope.LargeChange = 25
        Me.tbCSlope.Location = New System.Drawing.Point(125, 117)
        Me.tbCSlope.Maximum = 400
        Me.tbCSlope.Minimum = 50
        Me.tbCSlope.Name = "tbCSlope"
        Me.tbCSlope.Size = New System.Drawing.Size(118, 28)
        Me.tbCSlope.SmallChange = 5
        Me.tbCSlope.TabIndex = 4
        Me.tbCSlope.TickFrequency = 50
        Me.toolTip1.SetToolTip(Me.tbCSlope, "Center spectral falloff slope (0.5 to +4.0)")
        Me.tbCSlope.Value = 200
        '
        'lblCSlopeVal
        '
        Me.lblCSlopeVal.Location = New System.Drawing.Point(262, 121)
        Me.lblCSlopeVal.Margin = New System.Windows.Forms.Padding(2, 0, 4, 0)
        Me.lblCSlopeVal.Name = "lblCSlopeVal"
        Me.lblCSlopeVal.Size = New System.Drawing.Size(77, 34)
        Me.lblCSlopeVal.TabIndex = 5
        Me.lblCSlopeVal.Text = "2.00"
        Me.lblCSlopeVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSWidth
        '
        Me.lblSWidth.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSWidth.Location = New System.Drawing.Point(17, 77)
        Me.lblSWidth.Name = "lblSWidth"
        Me.lblSWidth.Size = New System.Drawing.Size(109, 13)
        Me.lblSWidth.TabIndex = 6
        Me.lblSWidth.Text = "Surround Width (-sw):"
        Me.lblSWidth.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'tbSWidth
        '
        Me.tbSWidth.AutoSize = False
        Me.tbSWidth.LargeChange = 10
        Me.tbSWidth.Location = New System.Drawing.Point(129, 76)
        Me.tbSWidth.Maximum = 100
        Me.tbSWidth.Name = "tbSWidth"
        Me.tbSWidth.Size = New System.Drawing.Size(118, 28)
        Me.tbSWidth.TabIndex = 7
        Me.tbSWidth.TickFrequency = 10
        Me.toolTip1.SetToolTip(Me.tbSWidth, "Surround width fraction (0.0=extreme panned, 1.0=entire L/R)")
        Me.tbSWidth.Value = 33
        '
        'lblSWidthVal
        '
        Me.lblSWidthVal.Location = New System.Drawing.Point(252, 66)
        Me.lblSWidthVal.Margin = New System.Windows.Forms.Padding(2, 0, 8, 0)
        Me.lblSWidthVal.Name = "lblSWidthVal"
        Me.lblSWidthVal.Size = New System.Drawing.Size(72, 34)
        Me.lblSWidthVal.TabIndex = 8
        Me.lblSWidthVal.Text = "0.33"
        Me.lblSWidthVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSSlope
        '
        Me.lblSSlope.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSSlope.Location = New System.Drawing.Point(11, 152)
        Me.lblSSlope.Name = "lblSSlope"
        Me.lblSSlope.Size = New System.Drawing.Size(105, 13)
        Me.lblSSlope.TabIndex = 9
        Me.lblSSlope.Text = "Surround Slope (-ss):"
        Me.lblSSlope.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'tbSSlope
        '
        Me.tbSSlope.AutoSize = False
        Me.tbSSlope.LargeChange = 25
        Me.tbSSlope.Location = New System.Drawing.Point(125, 151)
        Me.tbSSlope.Maximum = 400
        Me.tbSSlope.Minimum = 50
        Me.tbSSlope.Name = "tbSSlope"
        Me.tbSSlope.Size = New System.Drawing.Size(118, 28)
        Me.tbSSlope.SmallChange = 5
        Me.tbSSlope.TabIndex = 10
        Me.tbSSlope.TickFrequency = 50
        Me.toolTip1.SetToolTip(Me.tbSSlope, "Surround spectral falloff slope (0.5 to +4.0)")
        Me.tbSSlope.Value = 200
        '
        'lblSSlopeVal
        '
        Me.lblSSlopeVal.Location = New System.Drawing.Point(262, 145)
        Me.lblSSlopeVal.Margin = New System.Windows.Forms.Padding(2, 0, 4, 0)
        Me.lblSSlopeVal.Name = "lblSSlopeVal"
        Me.lblSSlopeVal.Size = New System.Drawing.Size(77, 34)
        Me.lblSSlopeVal.TabIndex = 11
        Me.lblSSlopeVal.Text = "2.00"
        Me.lblSSlopeVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbLfeClp
        '
        Me.tbLfeClp.AutoSize = False
        Me.tbLfeClp.LargeChange = 10
        Me.tbLfeClp.Location = New System.Drawing.Point(462, 279)
        Me.tbLfeClp.Maximum = 500
        Me.tbLfeClp.Minimum = 10
        Me.tbLfeClp.Name = "tbLfeClp"
        Me.tbLfeClp.Size = New System.Drawing.Size(203, 28)
        Me.tbLfeClp.TabIndex = 13
        Me.tbLfeClp.TickFrequency = 50
        Me.toolTip1.SetToolTip(Me.tbLfeClp, "LFE low-pass cutoff frequency in Hz")
        Me.tbLfeClp.Value = 120
        '
        'lblLfeClpVal
        '
        Me.lblLfeClpVal.BackColor = System.Drawing.SystemColors.Info
        Me.lblLfeClpVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLfeClpVal.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLfeClpVal.Location = New System.Drawing.Point(606, 261)
        Me.lblLfeClpVal.Margin = New System.Windows.Forms.Padding(2, 0, 8, 0)
        Me.lblLfeClpVal.Name = "lblLfeClpVal"
        Me.lblLfeClpVal.Size = New System.Drawing.Size(59, 17)
        Me.lblLfeClpVal.TabIndex = 14
        Me.lblLfeClpVal.Text = "120 Hz"
        Me.lblLfeClpVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbSDelay
        '
        Me.tbSDelay.AutoSize = False
        Me.tbSDelay.LargeChange = 10
        Me.tbSDelay.Location = New System.Drawing.Point(463, 339)
        Me.tbSDelay.Maximum = 400
        Me.tbSDelay.Name = "tbSDelay"
        Me.tbSDelay.Size = New System.Drawing.Size(203, 28)
        Me.tbSDelay.TabIndex = 16
        Me.tbSDelay.TickFrequency = 40
        Me.toolTip1.SetToolTip(Me.tbSDelay, "Delay in ms for Ls/Rs ambient channels (0.0 to 200.0 ms, typical 15-30ms)")
        '
        'lblSDelayVal
        '
        Me.lblSDelayVal.BackColor = System.Drawing.SystemColors.Info
        Me.lblSDelayVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSDelayVal.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSDelayVal.Location = New System.Drawing.Point(607, 321)
        Me.lblSDelayVal.Margin = New System.Windows.Forms.Padding(2, 0, 4, 0)
        Me.lblSDelayVal.Name = "lblSDelayVal"
        Me.lblSDelayVal.Size = New System.Drawing.Size(59, 17)
        Me.lblSDelayVal.TabIndex = 17
        Me.lblSDelayVal.Text = "0.0 ms"
        Me.lblSDelayVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbGainLR
        '
        Me.tbGainLR.AutoSize = False
        Me.tbGainLR.LargeChange = 6
        Me.tbGainLR.Location = New System.Drawing.Point(463, 34)
        Me.tbGainLR.Maximum = 48
        Me.tbGainLR.Minimum = -120
        Me.tbGainLR.Name = "tbGainLR"
        Me.tbGainLR.Size = New System.Drawing.Size(203, 28)
        Me.tbGainLR.TabIndex = 19
        Me.tbGainLR.TickFrequency = 12
        Me.toolTip1.SetToolTip(Me.tbGainLR, "Gain trim in dB for Front L and R (-60.0 to +24.0 dB)")
        '
        'lblGainLRVal
        '
        Me.lblGainLRVal.BackColor = System.Drawing.SystemColors.Info
        Me.lblGainLRVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGainLRVal.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGainLRVal.Location = New System.Drawing.Point(607, 16)
        Me.lblGainLRVal.Margin = New System.Windows.Forms.Padding(2, 0, 8, 0)
        Me.lblGainLRVal.Name = "lblGainLRVal"
        Me.lblGainLRVal.Size = New System.Drawing.Size(59, 17)
        Me.lblGainLRVal.TabIndex = 20
        Me.lblGainLRVal.Text = "0.0 dB"
        Me.lblGainLRVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbGainC
        '
        Me.tbGainC.AutoSize = False
        Me.tbGainC.LargeChange = 6
        Me.tbGainC.Location = New System.Drawing.Point(463, 95)
        Me.tbGainC.Maximum = 48
        Me.tbGainC.Minimum = -120
        Me.tbGainC.Name = "tbGainC"
        Me.tbGainC.Size = New System.Drawing.Size(203, 28)
        Me.tbGainC.TabIndex = 22
        Me.tbGainC.TickFrequency = 12
        Me.toolTip1.SetToolTip(Me.tbGainC, "Gain trim in dB for Center (-60.0 to +24.0 dB)")
        '
        'lblGainCVal
        '
        Me.lblGainCVal.BackColor = System.Drawing.SystemColors.Info
        Me.lblGainCVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGainCVal.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGainCVal.Location = New System.Drawing.Point(607, 77)
        Me.lblGainCVal.Margin = New System.Windows.Forms.Padding(2, 0, 4, 0)
        Me.lblGainCVal.Name = "lblGainCVal"
        Me.lblGainCVal.Size = New System.Drawing.Size(59, 17)
        Me.lblGainCVal.TabIndex = 23
        Me.lblGainCVal.Text = "0.0 dB"
        Me.lblGainCVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbGainLFE
        '
        Me.tbGainLFE.AutoSize = False
        Me.tbGainLFE.LargeChange = 6
        Me.tbGainLFE.Location = New System.Drawing.Point(463, 218)
        Me.tbGainLFE.Maximum = 48
        Me.tbGainLFE.Minimum = -120
        Me.tbGainLFE.Name = "tbGainLFE"
        Me.tbGainLFE.Size = New System.Drawing.Size(203, 28)
        Me.tbGainLFE.TabIndex = 25
        Me.tbGainLFE.TickFrequency = 12
        Me.toolTip1.SetToolTip(Me.tbGainLFE, "Gain trim in dB for LFE (-60.0 to +24.0 dB)")
        '
        'lblGainLFEVal
        '
        Me.lblGainLFEVal.BackColor = System.Drawing.SystemColors.Info
        Me.lblGainLFEVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGainLFEVal.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGainLFEVal.Location = New System.Drawing.Point(606, 200)
        Me.lblGainLFEVal.Margin = New System.Windows.Forms.Padding(2, 0, 8, 0)
        Me.lblGainLFEVal.Name = "lblGainLFEVal"
        Me.lblGainLFEVal.Size = New System.Drawing.Size(59, 17)
        Me.lblGainLFEVal.TabIndex = 26
        Me.lblGainLFEVal.Text = "0.0 dB"
        Me.lblGainLFEVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbGainLsRs
        '
        Me.tbGainLsRs.AutoSize = False
        Me.tbGainLsRs.LargeChange = 6
        Me.tbGainLsRs.Location = New System.Drawing.Point(462, 156)
        Me.tbGainLsRs.Maximum = 48
        Me.tbGainLsRs.Minimum = -120
        Me.tbGainLsRs.Name = "tbGainLsRs"
        Me.tbGainLsRs.Size = New System.Drawing.Size(203, 28)
        Me.tbGainLsRs.TabIndex = 28
        Me.tbGainLsRs.TickFrequency = 12
        Me.toolTip1.SetToolTip(Me.tbGainLsRs, "Gain trim in dB for Surround Ls and Rs (-60.0 to +24.0 dB)")
        '
        'lblGainLsRsVal
        '
        Me.lblGainLsRsVal.BackColor = System.Drawing.SystemColors.Info
        Me.lblGainLsRsVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGainLsRsVal.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGainLsRsVal.Location = New System.Drawing.Point(606, 138)
        Me.lblGainLsRsVal.Margin = New System.Windows.Forms.Padding(2, 0, 4, 0)
        Me.lblGainLsRsVal.Name = "lblGainLsRsVal"
        Me.lblGainLsRsVal.Size = New System.Drawing.Size(59, 17)
        Me.lblGainLsRsVal.TabIndex = 29
        Me.lblGainLsRsVal.Text = "0.0 dB"
        Me.lblGainLsRsVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCThresh
        '
        Me.lblCThresh.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCThresh.AutoSize = True
        Me.lblCThresh.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCThresh.Location = New System.Drawing.Point(19, 325)
        Me.lblCThresh.Name = "lblCThresh"
        Me.lblCThresh.Size = New System.Drawing.Size(103, 12)
        Me.lblCThresh.TabIndex = 30
        Me.lblCThresh.Text = "Center Gate Thresh (-ct):"
        '
        'tbCThresh
        '
        Me.tbCThresh.AutoSize = False
        Me.tbCThresh.BackColor = System.Drawing.SystemColors.Control
        Me.tbCThresh.Location = New System.Drawing.Point(21, 339)
        Me.tbCThresh.Maximum = 0
        Me.tbCThresh.Minimum = -100
        Me.tbCThresh.Name = "tbCThresh"
        Me.tbCThresh.Size = New System.Drawing.Size(203, 28)
        Me.tbCThresh.TabIndex = 31
        Me.tbCThresh.TickFrequency = 10
        Me.toolTip1.SetToolTip(Me.tbCThresh, "4:1 expander threshold in dB (<= -95 dB is OFF)")
        Me.tbCThresh.Value = -100
        '
        'lblCThreshVal
        '
        Me.lblCThreshVal.BackColor = System.Drawing.SystemColors.Info
        Me.lblCThreshVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCThreshVal.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCThreshVal.Location = New System.Drawing.Point(164, 321)
        Me.lblCThreshVal.Margin = New System.Windows.Forms.Padding(2, 0, 8, 0)
        Me.lblCThreshVal.Name = "lblCThreshVal"
        Me.lblCThreshVal.Size = New System.Drawing.Size(59, 17)
        Me.lblCThreshVal.TabIndex = 32
        Me.lblCThreshVal.Text = "-100 dB (off)"
        Me.lblCThreshVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbSThresh
        '
        Me.tbSThresh.AutoSize = False
        Me.tbSThresh.Location = New System.Drawing.Point(242, 339)
        Me.tbSThresh.Maximum = 0
        Me.tbSThresh.Minimum = -100
        Me.tbSThresh.Name = "tbSThresh"
        Me.tbSThresh.Size = New System.Drawing.Size(203, 28)
        Me.tbSThresh.TabIndex = 34
        Me.tbSThresh.TickFrequency = 10
        Me.toolTip1.SetToolTip(Me.tbSThresh, "4:1 expander threshold in dB for Ls/Rs (<= -95 dB is OFF)")
        Me.tbSThresh.Value = -100
        '
        'lblSThreshVal
        '
        Me.lblSThreshVal.BackColor = System.Drawing.SystemColors.Info
        Me.lblSThreshVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSThreshVal.Font = New System.Drawing.Font("Segoe UI Semibold", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSThreshVal.Location = New System.Drawing.Point(386, 321)
        Me.lblSThreshVal.Margin = New System.Windows.Forms.Padding(2, 0, 4, 0)
        Me.lblSThreshVal.Name = "lblSThreshVal"
        Me.lblSThreshVal.Size = New System.Drawing.Size(59, 17)
        Me.lblSThreshVal.TabIndex = 35
        Me.lblSThreshVal.Text = "-100 dB (off)"
        Me.lblSThreshVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpOutput
        '
        Me.grpOutput.AutoSize = True
        Me.grpOutput.Controls.Add(Me.tlpOutput)
        Me.grpOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpOutput.Location = New System.Drawing.Point(688, 3)
        Me.grpOutput.Name = "grpOutput"
        Me.grpOutput.Size = New System.Drawing.Size(447, 394)
        Me.grpOutput.TabIndex = 1
        Me.grpOutput.TabStop = False
        Me.grpOutput.Text = "Audio Output Format & Encoder Settings"
        '
        'tlpOutput
        '
        Me.tlpOutput.AutoSize = True
        Me.tlpOutput.ColumnCount = 4
        Me.tlpOutput.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpOutput.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpOutput.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpOutput.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpOutput.Controls.Add(Me.lblFormat, 0, 0)
        Me.tlpOutput.Controls.Add(Me.cmbFormat, 1, 0)
        Me.tlpOutput.Controls.Add(Me.lblCodec, 2, 0)
        Me.tlpOutput.Controls.Add(Me.cmbCodec, 3, 0)
        Me.tlpOutput.Controls.Add(Me.lblSampleRate, 0, 1)
        Me.tlpOutput.Controls.Add(Me.cmbSampleRate, 1, 1)
        Me.tlpOutput.Controls.Add(Me.lblSampleFmt, 2, 1)
        Me.tlpOutput.Controls.Add(Me.cmbSampleFmt, 3, 1)
        Me.tlpOutput.Controls.Add(Me.lblBits, 0, 2)
        Me.tlpOutput.Controls.Add(Me.cmbBits, 1, 2)
        Me.tlpOutput.Controls.Add(Me.lblBitrate, 2, 2)
        Me.tlpOutput.Controls.Add(Me.cmbBitrate, 3, 2)
        Me.tlpOutput.Controls.Add(Me.lblCompression, 0, 3)
        Me.tlpOutput.Controls.Add(Me.nudCompression, 1, 3)
        Me.tlpOutput.Controls.Add(Me.lblChLayout, 2, 3)
        Me.tlpOutput.Controls.Add(Me.cmbChLayout, 3, 3)
        Me.tlpOutput.Controls.Add(Me.lblLimiter, 0, 4)
        Me.tlpOutput.Controls.Add(Me.pnlLimiter, 1, 4)
        Me.tlpOutput.Controls.Add(Me.lblEncOpt, 0, 5)
        Me.tlpOutput.Controls.Add(Me.txtEncOpt, 1, 5)
        Me.tlpOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpOutput.Location = New System.Drawing.Point(3, 16)
        Me.tlpOutput.Name = "tlpOutput"
        Me.tlpOutput.Padding = New System.Windows.Forms.Padding(4)
        Me.tlpOutput.RowCount = 6
        Me.tlpOutput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpOutput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpOutput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpOutput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpOutput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpOutput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpOutput.Size = New System.Drawing.Size(441, 375)
        Me.tlpOutput.TabIndex = 0
        '
        'lblFormat
        '
        Me.lblFormat.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFormat.AutoSize = True
        Me.lblFormat.Location = New System.Drawing.Point(7, 11)
        Me.lblFormat.Name = "lblFormat"
        Me.lblFormat.Size = New System.Drawing.Size(57, 13)
        Me.lblFormat.TabIndex = 0
        Me.lblFormat.Text = "Format (-f):"
        '
        'cmbFormat
        '
        Me.cmbFormat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbFormat.Items.AddRange(New Object() {"auto", "wav", "flac", "wv", "mp4", "matroska", "ac3", "eac3", "ogg", "opus", "caf", "aiff", "adts"})
        Me.cmbFormat.Location = New System.Drawing.Point(104, 7)
        Me.cmbFormat.Name = "cmbFormat"
        Me.cmbFormat.Size = New System.Drawing.Size(116, 21)
        Me.cmbFormat.TabIndex = 1
        Me.cmbFormat.Text = "auto"
        Me.toolTip1.SetToolTip(Me.cmbFormat, "Output container format (auto = deduce from file extension)")
        '
        'lblCodec
        '
        Me.lblCodec.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCodec.AutoSize = True
        Me.lblCodec.Location = New System.Drawing.Point(226, 11)
        Me.lblCodec.Name = "lblCodec"
        Me.lblCodec.Size = New System.Drawing.Size(59, 13)
        Me.lblCodec.TabIndex = 2
        Me.lblCodec.Text = "Codec (-c):"
        '
        'cmbCodec
        '
        Me.cmbCodec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbCodec.Items.AddRange(New Object() {"auto", "pcm_s16le", "pcm_s24le", "pcm_s32le", "pcm_f32le", "pcm_f64le", "flac", "wavpack", "alac", "ac3", "eac3", "aac", "libopus", "libvorbis", "dca"})
        Me.cmbCodec.Location = New System.Drawing.Point(317, 7)
        Me.cmbCodec.Name = "cmbCodec"
        Me.cmbCodec.Size = New System.Drawing.Size(117, 21)
        Me.cmbCodec.TabIndex = 3
        Me.cmbCodec.Text = "auto"
        Me.toolTip1.SetToolTip(Me.cmbCodec, "Output audio codec")
        '
        'lblSampleRate
        '
        Me.lblSampleRate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSampleRate.AutoSize = True
        Me.lblSampleRate.Location = New System.Drawing.Point(7, 38)
        Me.lblSampleRate.Name = "lblSampleRate"
        Me.lblSampleRate.Size = New System.Drawing.Size(91, 13)
        Me.lblSampleRate.TabIndex = 4
        Me.lblSampleRate.Text = "Sample Rate (-sr):"
        '
        'cmbSampleRate
        '
        Me.cmbSampleRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbSampleRate.Items.AddRange(New Object() {"auto", "44100", "48000", "88200", "96000", "192000"})
        Me.cmbSampleRate.Location = New System.Drawing.Point(104, 34)
        Me.cmbSampleRate.Name = "cmbSampleRate"
        Me.cmbSampleRate.Size = New System.Drawing.Size(116, 21)
        Me.cmbSampleRate.TabIndex = 5
        Me.cmbSampleRate.Text = "auto"
        Me.toolTip1.SetToolTip(Me.cmbSampleRate, "Output sample rate in Hz (auto = match input)")
        '
        'lblSampleFmt
        '
        Me.lblSampleFmt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSampleFmt.AutoSize = True
        Me.lblSampleFmt.Location = New System.Drawing.Point(226, 38)
        Me.lblSampleFmt.Name = "lblSampleFmt"
        Me.lblSampleFmt.Size = New System.Drawing.Size(85, 13)
        Me.lblSampleFmt.TabIndex = 6
        Me.lblSampleFmt.Text = "Sample Fmt (-sf):"
        '
        'cmbSampleFmt
        '
        Me.cmbSampleFmt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbSampleFmt.Items.AddRange(New Object() {"auto", "s16", "s16p", "s32", "s32p", "flt", "fltp", "dbl", "dblp"})
        Me.cmbSampleFmt.Location = New System.Drawing.Point(317, 34)
        Me.cmbSampleFmt.Name = "cmbSampleFmt"
        Me.cmbSampleFmt.Size = New System.Drawing.Size(117, 21)
        Me.cmbSampleFmt.TabIndex = 7
        Me.cmbSampleFmt.Text = "auto"
        Me.toolTip1.SetToolTip(Me.cmbSampleFmt, "Output sample format")
        '
        'lblBits
        '
        Me.lblBits.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblBits.AutoSize = True
        Me.lblBits.Location = New System.Drawing.Point(7, 65)
        Me.lblBits.Name = "lblBits"
        Me.lblBits.Size = New System.Drawing.Size(85, 13)
        Me.lblBits.TabIndex = 8
        Me.lblBits.Text = "Bits/Sample (-b):"
        '
        'cmbBits
        '
        Me.cmbBits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBits.Items.AddRange(New Object() {"auto", "16", "24", "32"})
        Me.cmbBits.Location = New System.Drawing.Point(104, 61)
        Me.cmbBits.Name = "cmbBits"
        Me.cmbBits.Size = New System.Drawing.Size(116, 21)
        Me.cmbBits.TabIndex = 9
        Me.toolTip1.SetToolTip(Me.cmbBits, "Bits per sample for PCM/FLAC/ALAC")
        '
        'lblBitrate
        '
        Me.lblBitrate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblBitrate.AutoSize = True
        Me.lblBitrate.Location = New System.Drawing.Point(226, 65)
        Me.lblBitrate.Name = "lblBitrate"
        Me.lblBitrate.Size = New System.Drawing.Size(61, 13)
        Me.lblBitrate.TabIndex = 10
        Me.lblBitrate.Text = "Bitrate (-br):"
        '
        'cmbBitrate
        '
        Me.cmbBitrate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbBitrate.Items.AddRange(New Object() {"auto", "192k", "256k", "320k", "384k", "448k", "512k", "640k", "768k", "1.5M"})
        Me.cmbBitrate.Location = New System.Drawing.Point(317, 61)
        Me.cmbBitrate.Name = "cmbBitrate"
        Me.cmbBitrate.Size = New System.Drawing.Size(117, 21)
        Me.cmbBitrate.TabIndex = 11
        Me.cmbBitrate.Text = "auto"
        Me.toolTip1.SetToolTip(Me.cmbBitrate, "Output bitrate in bps, supports k/M suffix (e.g. 448k, 640k, 1.5M)")
        '
        'lblCompression
        '
        Me.lblCompression.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCompression.AutoSize = True
        Me.lblCompression.Location = New System.Drawing.Point(7, 92)
        Me.lblCompression.Name = "lblCompression"
        Me.lblCompression.Size = New System.Drawing.Size(90, 13)
        Me.lblCompression.TabIndex = 12
        Me.lblCompression.Text = "Compression (-cl):"
        '
        'nudCompression
        '
        Me.nudCompression.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nudCompression.Location = New System.Drawing.Point(104, 88)
        Me.nudCompression.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nudCompression.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.nudCompression.Name = "nudCompression"
        Me.nudCompression.Size = New System.Drawing.Size(116, 20)
        Me.nudCompression.TabIndex = 13
        Me.toolTip1.SetToolTip(Me.nudCompression, "Encoder compression level (-1 = codec default, >= 0 e.g. 0-12 for FLAC)")
        Me.nudCompression.Value = New Decimal(New Integer() {1, 0, 0, -2147483648})
        '
        'lblChLayout
        '
        Me.lblChLayout.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblChLayout.AutoSize = True
        Me.lblChLayout.Location = New System.Drawing.Point(226, 92)
        Me.lblChLayout.Name = "lblChLayout"
        Me.lblChLayout.Size = New System.Drawing.Size(82, 13)
        Me.lblChLayout.TabIndex = 14
        Me.lblChLayout.Text = "Ch Layout (-ch):"
        '
        'cmbChLayout
        '
        Me.cmbChLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbChLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChLayout.Items.AddRange(New Object() {"auto", "5.1", "5.1(side)", "5.1(back)"})
        Me.cmbChLayout.Location = New System.Drawing.Point(317, 88)
        Me.cmbChLayout.Name = "cmbChLayout"
        Me.cmbChLayout.Size = New System.Drawing.Size(117, 21)
        Me.cmbChLayout.TabIndex = 15
        Me.toolTip1.SetToolTip(Me.cmbChLayout, "5.1 channel layout")
        '
        'lblLimiter
        '
        Me.lblLimiter.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLimiter.AutoSize = True
        Me.lblLimiter.Location = New System.Drawing.Point(7, 119)
        Me.lblLimiter.Name = "lblLimiter"
        Me.lblLimiter.Size = New System.Drawing.Size(57, 13)
        Me.lblLimiter.TabIndex = 16
        Me.lblLimiter.Text = "Limiter (-lt):"
        '
        'pnlLimiter
        '
        Me.pnlLimiter.AutoSize = True
        Me.tlpOutput.SetColumnSpan(Me.pnlLimiter, 3)
        Me.pnlLimiter.Controls.Add(Me.cmbLimiterMode)
        Me.pnlLimiter.Controls.Add(Me.nudLimiterThresh)
        Me.pnlLimiter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLimiter.Location = New System.Drawing.Point(101, 112)
        Me.pnlLimiter.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlLimiter.Name = "pnlLimiter"
        Me.pnlLimiter.Size = New System.Drawing.Size(336, 27)
        Me.pnlLimiter.TabIndex = 17
        Me.pnlLimiter.WrapContents = False
        '
        'cmbLimiterMode
        '
        Me.cmbLimiterMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLimiterMode.Items.AddRange(New Object() {"auto", "off", "custom"})
        Me.cmbLimiterMode.Location = New System.Drawing.Point(3, 3)
        Me.cmbLimiterMode.Name = "cmbLimiterMode"
        Me.cmbLimiterMode.Size = New System.Drawing.Size(75, 21)
        Me.cmbLimiterMode.TabIndex = 0
        Me.toolTip1.SetToolTip(Me.cmbLimiterMode, "auto = 0.94 int / off float; off = disabled; custom = threshold")
        '
        'nudLimiterThresh
        '
        Me.nudLimiterThresh.DecimalPlaces = 2
        Me.nudLimiterThresh.Enabled = False
        Me.nudLimiterThresh.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudLimiterThresh.Location = New System.Drawing.Point(84, 3)
        Me.nudLimiterThresh.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nudLimiterThresh.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudLimiterThresh.Name = "nudLimiterThresh"
        Me.nudLimiterThresh.Size = New System.Drawing.Size(65, 20)
        Me.nudLimiterThresh.TabIndex = 1
        Me.nudLimiterThresh.Value = New Decimal(New Integer() {94, 0, 0, 131072})
        '
        'lblEncOpt
        '
        Me.lblEncOpt.AutoSize = True
        Me.lblEncOpt.Location = New System.Drawing.Point(7, 139)
        Me.lblEncOpt.Name = "lblEncOpt"
        Me.lblEncOpt.Size = New System.Drawing.Size(78, 13)
        Me.lblEncOpt.TabIndex = 18
        Me.lblEncOpt.Text = "Enc Opts (-eo):"
        '
        'txtEncOpt
        '
        Me.txtEncOpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpOutput.SetColumnSpan(Me.txtEncOpt, 3)
        Me.txtEncOpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEncOpt.Location = New System.Drawing.Point(104, 142)
        Me.txtEncOpt.Multiline = True
        Me.txtEncOpt.Name = "txtEncOpt"
        Me.txtEncOpt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEncOpt.Size = New System.Drawing.Size(330, 226)
        Me.txtEncOpt.TabIndex = 19
        Me.toolTip1.SetToolTip(Me.txtEncOpt, "Codec-specific FFmpeg options, one key=value per line (e.g. dialnorm=-31)")
        '
        'grpQueue
        '
        Me.grpQueue.Controls.Add(Me.tlpQueue)
        Me.grpQueue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpQueue.Location = New System.Drawing.Point(11, 489)
        Me.grpQueue.Name = "grpQueue"
        Me.grpQueue.Size = New System.Drawing.Size(1138, 213)
        Me.grpQueue.TabIndex = 2
        Me.grpQueue.TabStop = False
        Me.grpQueue.Text = "Batch File Queue (Drag & Drop Stereo Audio Files or Folders Here)"
        '
        'tlpQueue
        '
        Me.tlpQueue.ColumnCount = 1
        Me.tlpQueue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpQueue.Controls.Add(Me.lvFiles, 0, 0)
        Me.tlpQueue.Controls.Add(Me.pnlQueueButtons, 0, 1)
        Me.tlpQueue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpQueue.Location = New System.Drawing.Point(3, 16)
        Me.tlpQueue.Name = "tlpQueue"
        Me.tlpQueue.Padding = New System.Windows.Forms.Padding(4)
        Me.tlpQueue.RowCount = 2
        Me.tlpQueue.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpQueue.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpQueue.Size = New System.Drawing.Size(1132, 194)
        Me.tlpQueue.TabIndex = 0
        '
        'lvFiles
        '
        Me.lvFiles.AllowDrop = True
        Me.lvFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colFileName, Me.colStatus, Me.colOutput, Me.colInput})
        Me.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvFiles.FullRowSelect = True
        Me.lvFiles.GridLines = True
        Me.lvFiles.HideSelection = False
        Me.lvFiles.Location = New System.Drawing.Point(7, 7)
        Me.lvFiles.Name = "lvFiles"
        Me.lvFiles.Size = New System.Drawing.Size(1118, 147)
        Me.lvFiles.TabIndex = 0
        Me.lvFiles.UseCompatibleStateImageBehavior = False
        Me.lvFiles.View = System.Windows.Forms.View.Details
        '
        'colFileName
        '
        Me.colFileName.Text = "File Name"
        Me.colFileName.Width = 240
        '
        'colStatus
        '
        Me.colStatus.Text = "Status"
        Me.colStatus.Width = 110
        '
        'colOutput
        '
        Me.colOutput.Text = "Output File"
        Me.colOutput.Width = 370
        '
        'colInput
        '
        Me.colInput.Text = "Input Path"
        Me.colInput.Width = 370
        '
        'pnlQueueButtons
        '
        Me.pnlQueueButtons.AutoSize = True
        Me.pnlQueueButtons.Controls.Add(Me.btnAddFiles)
        Me.pnlQueueButtons.Controls.Add(Me.btnRemoveSelected)
        Me.pnlQueueButtons.Controls.Add(Me.btnClearList)
        Me.pnlQueueButtons.Controls.Add(Me.btnResetDefaults)
        Me.pnlQueueButtons.Controls.Add(Me.btnStart)
        Me.pnlQueueButtons.Controls.Add(Me.btnCancel)
        Me.pnlQueueButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlQueueButtons.Location = New System.Drawing.Point(4, 161)
        Me.pnlQueueButtons.Margin = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.pnlQueueButtons.Name = "pnlQueueButtons"
        Me.pnlQueueButtons.Size = New System.Drawing.Size(1124, 29)
        Me.pnlQueueButtons.TabIndex = 1
        '
        'btnAddFiles
        '
        Me.btnAddFiles.AutoSize = True
        Me.btnAddFiles.Location = New System.Drawing.Point(3, 3)
        Me.btnAddFiles.Name = "btnAddFiles"
        Me.btnAddFiles.Size = New System.Drawing.Size(75, 23)
        Me.btnAddFiles.TabIndex = 0
        Me.btnAddFiles.Text = "Add Files..."
        '
        'btnRemoveSelected
        '
        Me.btnRemoveSelected.AutoSize = True
        Me.btnRemoveSelected.Location = New System.Drawing.Point(84, 3)
        Me.btnRemoveSelected.Name = "btnRemoveSelected"
        Me.btnRemoveSelected.Size = New System.Drawing.Size(102, 23)
        Me.btnRemoveSelected.TabIndex = 1
        Me.btnRemoveSelected.Text = "Remove Selected"
        '
        'btnClearList
        '
        Me.btnClearList.AutoSize = True
        Me.btnClearList.Location = New System.Drawing.Point(192, 3)
        Me.btnClearList.Name = "btnClearList"
        Me.btnClearList.Size = New System.Drawing.Size(75, 23)
        Me.btnClearList.TabIndex = 2
        Me.btnClearList.Text = "Clear List"
        '
        'btnResetDefaults
        '
        Me.btnResetDefaults.AutoSize = True
        Me.btnResetDefaults.Location = New System.Drawing.Point(273, 3)
        Me.btnResetDefaults.Name = "btnResetDefaults"
        Me.btnResetDefaults.Size = New System.Drawing.Size(149, 23)
        Me.btnResetDefaults.TabIndex = 3
        Me.btnResetDefaults.Text = "Reset DSP/Output Defaults"
        '
        'btnStart
        '
        Me.btnStart.AutoSize = True
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnStart.Location = New System.Drawing.Point(445, 3)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(148, 23)
        Me.btnStart.TabIndex = 4
        Me.btnStart.Text = "Start Batch Conversion"
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(599, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        '
        'tlpProgress
        '
        Me.tlpProgress.AutoSize = True
        Me.tlpProgress.ColumnCount = 2
        Me.tlpProgress.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpProgress.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpProgress.Controls.Add(Me.lblFileStatus, 0, 0)
        Me.tlpProgress.Controls.Add(Me.lblBatchStatus, 1, 0)
        Me.tlpProgress.Controls.Add(Me.pbFile, 0, 1)
        Me.tlpProgress.Controls.Add(Me.pbBatch, 1, 1)
        Me.tlpProgress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpProgress.Location = New System.Drawing.Point(11, 708)
        Me.tlpProgress.Name = "tlpProgress"
        Me.tlpProgress.RowCount = 2
        Me.tlpProgress.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpProgress.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpProgress.Size = New System.Drawing.Size(1138, 39)
        Me.tlpProgress.TabIndex = 3
        '
        'lblFileStatus
        '
        Me.lblFileStatus.AutoSize = True
        Me.lblFileStatus.Location = New System.Drawing.Point(3, 0)
        Me.lblFileStatus.Name = "lblFileStatus"
        Me.lblFileStatus.Size = New System.Drawing.Size(83, 13)
        Me.lblFileStatus.TabIndex = 0
        Me.lblFileStatus.Text = "Current File: Idle"
        '
        'lblBatchStatus
        '
        Me.lblBatchStatus.AutoSize = True
        Me.lblBatchStatus.Location = New System.Drawing.Point(572, 0)
        Me.lblBatchStatus.Name = "lblBatchStatus"
        Me.lblBatchStatus.Size = New System.Drawing.Size(108, 13)
        Me.lblBatchStatus.TabIndex = 1
        Me.lblBatchStatus.Text = "Batch Progress: 0 / 0"
        '
        'pbFile
        '
        Me.pbFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbFile.Location = New System.Drawing.Point(3, 16)
        Me.pbFile.Name = "pbFile"
        Me.pbFile.Size = New System.Drawing.Size(563, 20)
        Me.pbFile.TabIndex = 2
        '
        'pbBatch
        '
        Me.pbBatch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbBatch.Location = New System.Drawing.Point(572, 16)
        Me.pbBatch.Name = "pbBatch"
        Me.pbBatch.Size = New System.Drawing.Size(563, 20)
        Me.pbBatch.TabIndex = 3
        '
        'txtLog
        '
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Font = New System.Drawing.Font("Consolas", 8.5!)
        Me.txtLog.Location = New System.Drawing.Point(11, 753)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(1138, 113)
        Me.txtLog.TabIndex = 4
        '
        'toolTip1
        '
        Me.toolTip1.IsBalloon = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Panel1.Controls.Add(Me.lblSSlopeVal)
        Me.Panel1.Controls.Add(Me.lblCSlopeVal)
        Me.Panel1.Controls.Add(Me.tbCSlope)
        Me.Panel1.Controls.Add(Me.tbSSlope)
        Me.Panel1.Controls.Add(Me.lblSSlope)
        Me.Panel1.Controls.Add(Me.lblCSlope)
        Me.Panel1.Controls.Add(Me.lblCWidthVal)
        Me.Panel1.Controls.Add(Me.tbCWidth)
        Me.Panel1.Controls.Add(Me.lblCWidth)
        Me.Panel1.Controls.Add(Me.lblSWidthVal)
        Me.Panel1.Controls.Add(Me.lblSWidth)
        Me.Panel1.Controls.Add(Me.tbSWidth)
        Me.Panel1.Location = New System.Drawing.Point(552, 373)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(350, 471)
        Me.Panel1.TabIndex = 1
        Me.Panel1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(18, 367)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 12)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "-100 dB"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(201, 367)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 12)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "0 dB"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(240, 325)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 12)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Surround Gate Thresh (-st):"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(240, 367)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 12)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "-100 dB"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(423, 367)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 12)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "0 dB"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(461, 325)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 12)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Surround Delay (-sd):"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label7.Location = New System.Drawing.Point(464, 367)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 12)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "0 ms"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label8.Location = New System.Drawing.Point(633, 367)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 12)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "200 ms"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label9.Location = New System.Drawing.Point(633, 307)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 12)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "200 Hz"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label10.Location = New System.Drawing.Point(464, 307)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 12)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "0 Hz"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(461, 265)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 12)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "LFE Cutoff (-lp):"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label12.Location = New System.Drawing.Point(633, 246)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 12)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "+12 dB"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label13.Location = New System.Drawing.Point(464, 246)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 12)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "-60 dB"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(461, 204)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 12)
        Me.Label14.TabIndex = 44
        Me.Label14.Text = "Gain LFE (-gl):"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label15.Location = New System.Drawing.Point(633, 184)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 12)
        Me.Label15.TabIndex = 49
        Me.Label15.Text = "+12 dB"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label16.Location = New System.Drawing.Point(464, 184)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(31, 12)
        Me.Label16.TabIndex = 48
        Me.Label16.Text = "-60 dB"
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(461, 142)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 12)
        Me.Label17.TabIndex = 47
        Me.Label17.Text = "Gain Surround (-gs):"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label18.Location = New System.Drawing.Point(633, 123)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 12)
        Me.Label18.TabIndex = 52
        Me.Label18.Text = "+12 dB"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label19.Location = New System.Drawing.Point(464, 123)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 12)
        Me.Label19.TabIndex = 51
        Me.Label19.Text = "-60 dB"
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(461, 81)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(75, 12)
        Me.Label20.TabIndex = 50
        Me.Label20.Text = "Gain Center (-gc):"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label21.Location = New System.Drawing.Point(633, 62)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(33, 12)
        Me.Label21.TabIndex = 55
        Me.Label21.Text = "+12 dB"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label22.Location = New System.Drawing.Point(464, 62)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 12)
        Me.Label22.TabIndex = 54
        Me.Label22.Text = "-60 dB"
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(461, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(82, 12)
        Me.Label23.TabIndex = 53
        Me.Label23.Text = "Gain Front L/R (-gf):"
        '
        'StereoTo51VisualizerControl1
        '
        Me.StereoTo51VisualizerControl1.BackColor = System.Drawing.SystemColors.Control
        Me.StereoTo51VisualizerControl1.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.StereoTo51VisualizerControl1.Location = New System.Drawing.Point(10, 17)
        Me.StereoTo51VisualizerControl1.MinimumSize = New System.Drawing.Size(450, 300)
        Me.StereoTo51VisualizerControl1.Name = "StereoTo51VisualizerControl1"
        Me.StereoTo51VisualizerControl1.Size = New System.Drawing.Size(450, 300)
        Me.StereoTo51VisualizerControl1.TabIndex = 0
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1160, 877)
        Me.Controls.Add(Me.tlpRoot)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1176, 916)
        Me.MinimumSize = New System.Drawing.Size(1176, 916)
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stereo to 5.1 Batch Upmixer"
        Me.tlpRoot.ResumeLayout(False)
        Me.tlpRoot.PerformLayout()
        Me.grpPaths.ResumeLayout(False)
        Me.grpPaths.PerformLayout()
        Me.tlpSettings.ResumeLayout(False)
        Me.tlpSettings.PerformLayout()
        Me.grpDsp.ResumeLayout(False)
        Me.grpDsp.PerformLayout()
        CType(Me.tbCWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCSlope, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSSlope, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLfeClp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbGainLR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbGainC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbGainLFE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbGainLsRs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCThresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSThresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOutput.ResumeLayout(False)
        Me.grpOutput.PerformLayout()
        Me.tlpOutput.ResumeLayout(False)
        Me.tlpOutput.PerformLayout()
        CType(Me.nudCompression, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLimiter.ResumeLayout(False)
        CType(Me.nudLimiterThresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpQueue.ResumeLayout(False)
        Me.tlpQueue.ResumeLayout(False)
        Me.tlpQueue.PerformLayout()
        Me.pnlQueueButtons.ResumeLayout(False)
        Me.pnlQueueButtons.PerformLayout()
        Me.tlpProgress.ResumeLayout(False)
        Me.tlpProgress.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpRoot As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpPaths As System.Windows.Forms.GroupBox
    Friend WithEvents lblOutMode As System.Windows.Forms.Label
    Friend WithEvents rbOutSameDir As System.Windows.Forms.RadioButton
    Friend WithEvents rbOutCustomDir As System.Windows.Forms.RadioButton
    Friend WithEvents lblSuffix As System.Windows.Forms.Label
    Friend WithEvents txtSuffix As System.Windows.Forms.TextBox
    Friend WithEvents chkOverwrite As System.Windows.Forms.CheckBox
    Friend WithEvents lblOutDir As System.Windows.Forms.Label
    Friend WithEvents txtOutDir As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowseOutDir As System.Windows.Forms.Button
    Friend WithEvents tlpSettings As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpDsp As System.Windows.Forms.GroupBox
    Friend WithEvents lblCWidth As System.Windows.Forms.Label
    Friend WithEvents tbCWidth As System.Windows.Forms.TrackBar
    Friend WithEvents lblCWidthVal As System.Windows.Forms.Label
    Friend WithEvents lblCSlope As System.Windows.Forms.Label
    Friend WithEvents tbCSlope As System.Windows.Forms.TrackBar
    Friend WithEvents lblCSlopeVal As System.Windows.Forms.Label
    Friend WithEvents lblSWidth As System.Windows.Forms.Label
    Friend WithEvents tbSWidth As System.Windows.Forms.TrackBar
    Friend WithEvents lblSWidthVal As System.Windows.Forms.Label
    Friend WithEvents lblSSlope As System.Windows.Forms.Label
    Friend WithEvents tbSSlope As System.Windows.Forms.TrackBar
    Friend WithEvents lblSSlopeVal As System.Windows.Forms.Label
    Friend WithEvents tbLfeClp As System.Windows.Forms.TrackBar
    Friend WithEvents lblLfeClpVal As System.Windows.Forms.Label
    Friend WithEvents tbSDelay As System.Windows.Forms.TrackBar
    Friend WithEvents lblSDelayVal As System.Windows.Forms.Label
    Friend WithEvents tbGainLR As System.Windows.Forms.TrackBar
    Friend WithEvents lblGainLRVal As System.Windows.Forms.Label
    Friend WithEvents tbGainC As System.Windows.Forms.TrackBar
    Friend WithEvents lblGainCVal As System.Windows.Forms.Label
    Friend WithEvents tbGainLFE As System.Windows.Forms.TrackBar
    Friend WithEvents lblGainLFEVal As System.Windows.Forms.Label
    Friend WithEvents tbGainLsRs As System.Windows.Forms.TrackBar
    Friend WithEvents lblGainLsRsVal As System.Windows.Forms.Label
    Friend WithEvents lblCThresh As System.Windows.Forms.Label
    Friend WithEvents tbCThresh As System.Windows.Forms.TrackBar
    Friend WithEvents lblCThreshVal As System.Windows.Forms.Label
    Friend WithEvents tbSThresh As System.Windows.Forms.TrackBar
    Friend WithEvents lblSThreshVal As System.Windows.Forms.Label
    Friend WithEvents grpOutput As System.Windows.Forms.GroupBox
    Friend WithEvents tlpOutput As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFormat As System.Windows.Forms.Label
    Friend WithEvents cmbFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodec As System.Windows.Forms.Label
    Friend WithEvents cmbCodec As System.Windows.Forms.ComboBox
    Friend WithEvents lblSampleRate As System.Windows.Forms.Label
    Friend WithEvents cmbSampleRate As System.Windows.Forms.ComboBox
    Friend WithEvents lblSampleFmt As System.Windows.Forms.Label
    Friend WithEvents cmbSampleFmt As System.Windows.Forms.ComboBox
    Friend WithEvents lblBits As System.Windows.Forms.Label
    Friend WithEvents cmbBits As System.Windows.Forms.ComboBox
    Friend WithEvents lblBitrate As System.Windows.Forms.Label
    Friend WithEvents cmbBitrate As System.Windows.Forms.ComboBox
    Friend WithEvents lblCompression As System.Windows.Forms.Label
    Friend WithEvents nudCompression As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblChLayout As System.Windows.Forms.Label
    Friend WithEvents cmbChLayout As System.Windows.Forms.ComboBox
    Friend WithEvents lblLimiter As System.Windows.Forms.Label
    Friend WithEvents pnlLimiter As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmbLimiterMode As System.Windows.Forms.ComboBox
    Friend WithEvents nudLimiterThresh As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblEncOpt As System.Windows.Forms.Label
    Friend WithEvents txtEncOpt As System.Windows.Forms.TextBox
    Friend WithEvents grpQueue As System.Windows.Forms.GroupBox
    Friend WithEvents tlpQueue As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lvFiles As System.Windows.Forms.ListView
    Friend WithEvents colFileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents colOutput As System.Windows.Forms.ColumnHeader
    Friend WithEvents colInput As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnlQueueButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAddFiles As System.Windows.Forms.Button
    Friend WithEvents btnRemoveSelected As System.Windows.Forms.Button
    Friend WithEvents btnClearList As System.Windows.Forms.Button
    Friend WithEvents btnResetDefaults As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents tlpProgress As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblFileStatus As System.Windows.Forms.Label
    Friend WithEvents pbFile As System.Windows.Forms.ProgressBar
    Friend WithEvents lblBatchStatus As System.Windows.Forms.Label
    Friend WithEvents pbBatch As System.Windows.Forms.ProgressBar
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents toolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents StereoTo51VisualizerControl1 As StereoTo51VisualizerControl
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
End Class
