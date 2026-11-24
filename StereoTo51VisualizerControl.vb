Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.Win32

<ToolboxItem(True)>
Public Class StereoTo51VisualizerControl
    Inherits UserControl

    Private Class GraphCanvas
        Inherits Panel
        Public Sub New()
            Me.DoubleBuffered = True
            Me.ResizeRedraw = True
        End Sub
    End Class

    Private Structure LegendEntry
        Public Text As String
        Public Col As Color
        Public IsDashed As Boolean
        Public Sub New(t As String, c As Color, d As Boolean)
            Text = t
            Col = c
            IsDashed = d
        End Sub
    End Structure

    <DllImport("kernel32.dll", CharSet:=CharSet.Unicode, SetLastError:=True)>
    Private Shared Function GetPrivateProfileString(lpAppName As String,
                                                    lpKeyName As String,
                                                    lpDefault As String,
                                                    lpReturnedString As StringBuilder,
                                                    nSize As Integer,
                                                    lpFileName As String) As Integer
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Unicode, SetLastError:=True)>
    Private Shared Function WritePrivateProfileString(lpAppName As String,
                                                      lpKeyName As String,
                                                      lpString As String,
                                                      lpFileName As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Private ReadOnly _graphCanvas As GraphCanvas
    Private ReadOnly _grpCenter As GroupBox
    Private ReadOnly _grpSurround As GroupBox

    Private ReadOnly _tbCenterWidth As TrackBar
    Private ReadOnly _tbCenterSlope As TrackBar
    Private ReadOnly _tbSurroundWidth As TrackBar
    Private ReadOnly _tbSurroundSlope As TrackBar

    Private ReadOnly _lblCenterWidthVal As Label
    Private ReadOnly _lblCenterSlopeVal As Label
    Private ReadOnly _lblSurroundWidthVal As Label
    Private ReadOnly _lblSurroundSlopeVal As Label
    Private ReadOnly _toolTip As ToolTip

    Private _suppressEvents As Boolean = False

    Public Event ParametersChanged As EventHandler

    Public Sub New()
        Me.SuspendLayout()

        Me.Size = New Size(450, 300)
        Me.MinimumSize = New Size(450, 300)
        Me.BackColor = SystemColors.Control
        Me.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular)

        _toolTip = New ToolTip()

        ' 1. Graph Canvas (Top)
        _graphCanvas = New GraphCanvas() With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.FromArgb(20, 24, 31)
        }
        AddHandler _graphCanvas.Paint, AddressOf GraphCanvas_Paint

        Dim graphHost As New Panel() With {
            .Dock = DockStyle.Fill,
            .Padding = New Padding(6, 6, 6, 2)
        }
        graphHost.Controls.Add(_graphCanvas)

        ' 2. TrackBar Controls Panel (Bottom)
        Dim controlsContainer As New TableLayoutPanel() With {
            .Dock = DockStyle.Bottom,
            .Height = 144,
            .ColumnCount = 2,
            .RowCount = 1,
            .Padding = New Padding(6, 2, 6, 6)
        }
        controlsContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        controlsContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        controlsContainer.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))

        ' --- Center GroupBox ---
        _grpCenter = New GroupBox() With {
            .Text = "Center Extraction Settings",
            .Dock = DockStyle.Fill,
            .Margin = New Padding(0, 0, 3, 0)
        }

        _tbCenterWidth = CreateTrackBar(0, 100, 25, 10, 1, 5)
        ' Slope TrackBar: 0 (left) = 4.00 Steep, 350 (right) = 0.50 Gentle; default 200 = 2.00 (0.57 norm)
        '_tbCenterSlope = CreateTrackBar(0, 350, 200, 35, 4, 35)
        _tbCenterSlope = CreateTrackBar(0, 1000, 200, 35, 4, 35)

        _lblCenterWidthVal = CreateValueLabel("0.25", Color.FromArgb(0, 153, 0))
        _lblCenterSlopeVal = CreateValueLabel(CenterSlopeNormalized.ToString("0.00"), Color.FromArgb(0, 153, 0)) 'Color.FromArgb(0, 90, 158))

        _toolTip.SetToolTip(_tbCenterSlope, "0.00 (Steep = -cs 4.00) to 1.00 (Gentle = -cs 0.50)")

        BuildSliderGroup(_grpCenter,
                         "Center Width", _tbCenterWidth, _lblCenterWidthVal, "0.00 (Exact)", "1.00 (Full)",
                         "Center Slope", _tbCenterSlope, _lblCenterSlopeVal, "0.00 (Steep)", "1.00 (Gentle)")

        ' --- Surround GroupBox ---
        _grpSurround = New GroupBox() With {
            .Text = "Surround Extraction Settings",
            .Dock = DockStyle.Fill,
            .Margin = New Padding(3, 0, 0, 0)
        }

        _tbSurroundWidth = CreateTrackBar(0, 100, 33, 10, 1, 5)
        '_tbSurroundSlope = CreateTrackBar(0, 350, 200, 35, 4, 35)
        _tbSurroundSlope = CreateTrackBar(0, 1000, 200, 35, 4, 35)

        _lblSurroundWidthVal = CreateValueLabel("0.33", Color.FromArgb(0, 76, 153))
        _lblSurroundSlopeVal = CreateValueLabel(SurroundSlopeNormalized.ToString("0.00"), Color.FromArgb(0, 76, 153))   'Color.FromArgb(194, 65, 12))

        _toolTip.SetToolTip(_tbSurroundSlope, "0.00 (Steep = -ss 4.00) to 1.00 (Gentle = -ss 0.50)")

        BuildSliderGroup(_grpSurround,
                         "Surround Width", _tbSurroundWidth, _lblSurroundWidthVal, "0.00 (Extreme Pan)", "1.00 (Full L/R)",
                         "Surround Slope", _tbSurroundSlope, _lblSurroundSlopeVal, "0.00 (Steep)", "1.00 (Gentle)")

        controlsContainer.Controls.Add(_grpCenter, 0, 0)
        controlsContainer.Controls.Add(_grpSurround, 1, 0)

        Me.Controls.Add(graphHost)
        Me.Controls.Add(controlsContainer)

        AddHandler _tbCenterWidth.ValueChanged, AddressOf OnTrackBarChanged
        AddHandler _tbCenterSlope.ValueChanged, AddressOf OnTrackBarChanged
        AddHandler _tbSurroundWidth.ValueChanged, AddressOf OnTrackBarChanged
        AddHandler _tbSurroundSlope.ValueChanged, AddressOf OnTrackBarChanged

        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            _toolTip.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' =========================================================================
    ' Public Properties (CLI / DSP Range: Width 0.0..1.0, Slope 0.5..4.0)
    ' =========================================================================
    <Category("DSP Parameters"), DefaultValue(0.25)>
    Public Property CenterWidth As Double
        Get
            Return _tbCenterWidth.Value / 100.0
        End Get
        Set(value As Double)
            Dim clamped As Double = Math.Max(0.0, Math.Min(1.0, value))
            _suppressEvents = True
            _tbCenterWidth.Value = CInt(Math.Round(clamped * 100.0))
            _lblCenterWidthVal.Text = CenterWidth.ToString("0.00")
            _suppressEvents = False
            _graphCanvas.Invalidate()
        End Set
    End Property

    <Category("DSP Parameters"), DefaultValue(2.0)>
    Public Property CenterSlope As Double
        Get
            ' Left (0) = 4.0 (Steep), Right (350) = 0.5 (Gentle)
            Return 10.0 - (_tbCenterSlope.Value / 100.0)
        End Get
        Set(value As Double)
            Dim clamped As Double = Math.Max(0.5, Math.Min(10.0, value)) '3.5
            _suppressEvents = True
            _tbCenterSlope.Value = CInt(Math.Round((10.0 - clamped) * 100.0)) '4.0
            _lblCenterSlopeVal.Text = CenterSlopeNormalized.ToString("0.00")
            _suppressEvents = False
            _graphCanvas.Invalidate()
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property CenterSlopeNormalized As Double
        Get
            Return _tbCenterSlope.Value / 1000.0 '350
        End Get
        Set(value As Double)
            Dim clamped As Double = Math.Max(0.0, Math.Min(1.0, value))
            _suppressEvents = True
            _tbCenterSlope.Value = CInt(Math.Round(clamped * 1000.0)) '350
            _lblCenterSlopeVal.Text = CenterSlopeNormalized.ToString("0.00")
            _suppressEvents = False
            _graphCanvas.Invalidate()
        End Set
    End Property

    <Category("DSP Parameters"), DefaultValue(0.33)>
    Public Property SurroundWidth As Double
        Get
            Return _tbSurroundWidth.Value / 100.0
        End Get
        Set(value As Double)
            Dim clamped As Double = Math.Max(0.0, Math.Min(1.0, value))
            _suppressEvents = True
            _tbSurroundWidth.Value = CInt(Math.Round(clamped * 100.0))
            _lblSurroundWidthVal.Text = SurroundWidth.ToString("0.00")
            _suppressEvents = False
            _graphCanvas.Invalidate()
        End Set
    End Property

    <Category("DSP Parameters"), DefaultValue(2.0)>
    Public Property SurroundSlope As Double
        Get
            ' Left (0) = 4.0 (Steep), Right (350) = 0.5 (Gentle)
            Return 10.0 - (_tbSurroundSlope.Value / 100.0)
        End Get
        Set(value As Double)
            Dim clamped As Double = Math.Max(0.5, Math.Min(10.0, value)) '4.0
            _suppressEvents = True
            _tbSurroundSlope.Value = CInt(Math.Round((10.0 - clamped) * 100.0))
            _lblSurroundSlopeVal.Text = SurroundSlopeNormalized.ToString("0.00")
            _suppressEvents = False
            _graphCanvas.Invalidate()
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property SurroundSlopeNormalized As Double
        Get
            Return _tbSurroundSlope.Value / 1000.0 '350
        End Get
        Set(value As Double)
            Dim clamped As Double = Math.Max(0.0, Math.Min(1.0, value))
            _suppressEvents = True
            _tbSurroundSlope.Value = CInt(Math.Round(clamped * 1000.0)) '350
            _lblSurroundSlopeVal.Text = SurroundSlopeNormalized.ToString("0.00")
            _suppressEvents = False
            _graphCanvas.Invalidate()
        End Set
    End Property

    ' =========================================================================
    ' Batch Update + INI / Registry Persistence (Stores 0.5..4.0 DSP Values)
    ' =========================================================================
    Public Sub SetParameters(cWidth As Double, cSlope As Double, sWidth As Double, sSlope As Double,
                             Optional raiseChangedEvent As Boolean = False)
        Dim cw As Double = Math.Max(0.0, Math.Min(1.0, cWidth))
        Dim cs As Double = Math.Max(0.5, Math.Min(10.0, cSlope)) '4.0
        Dim sw As Double = Math.Max(0.0, Math.Min(1.0, sWidth))
        Dim ss As Double = Math.Max(0.5, Math.Min(10.0, sSlope)) '4.0

        _suppressEvents = True
        _tbCenterWidth.Value = CInt(Math.Round(cw * 100.0))
        _tbCenterSlope.Value = CInt(Math.Round((10.0 - cs) * 100.0)) '4.0
        _tbSurroundWidth.Value = CInt(Math.Round(sw * 100.0))
        _tbSurroundSlope.Value = CInt(Math.Round((10.0 - ss) * 100.0)) '4.0

        _lblCenterWidthVal.Text = CenterWidth.ToString("0.00")
        _lblCenterSlopeVal.Text = CenterSlopeNormalized.ToString("0.00")
        _lblSurroundWidthVal.Text = SurroundWidth.ToString("0.00")
        _lblSurroundSlopeVal.Text = SurroundSlopeNormalized.ToString("0.00")
        _suppressEvents = False

        _graphCanvas.Invalidate()
        If raiseChangedEvent Then
            RaiseEvent ParametersChanged(Me, EventArgs.Empty)
        End If
    End Sub

    Public Sub SaveToIni(iniFilePath As String, Optional sectionName As String = "2to51CL")
        Dim fullPath As String = Path.GetFullPath(iniFilePath)
        Dim dir As String = Path.GetDirectoryName(fullPath)
        If Not String.IsNullOrEmpty(dir) AndAlso Not Directory.Exists(dir) Then
            Directory.CreateDirectory(dir)
        End If

        WritePrivateProfileString(sectionName, "CenterWidth", CenterWidth.ToString("0.00", CultureInfo.InvariantCulture), fullPath)
        WritePrivateProfileString(sectionName, "CenterSlope", CenterSlope.ToString("0.00", CultureInfo.InvariantCulture), fullPath)
        WritePrivateProfileString(sectionName, "SurroundWidth", SurroundWidth.ToString("0.00", CultureInfo.InvariantCulture), fullPath)
        WritePrivateProfileString(sectionName, "SurroundSlope", SurroundSlope.ToString("0.00", CultureInfo.InvariantCulture), fullPath)
    End Sub

    Public Function LoadFromIni(iniFilePath As String,
                                Optional sectionName As String = "2to51CL",
                                Optional raiseChangedEvent As Boolean = False) As Boolean
        Dim fullPath As String = Path.GetFullPath(iniFilePath)
        If Not File.Exists(fullPath) Then Return False

        Dim cw As Double = ReadIniDouble(fullPath, sectionName, "CenterWidth", CenterWidth)
        Dim cs As Double = ReadIniDouble(fullPath, sectionName, "CenterSlope", CenterSlope)
        Dim sw As Double = ReadIniDouble(fullPath, sectionName, "SurroundWidth", SurroundWidth)
        Dim ss As Double = ReadIniDouble(fullPath, sectionName, "SurroundSlope", SurroundSlope)

        SetParameters(cw, cs, sw, ss, raiseChangedEvent)
        Return True
    End Function

    Public Sub SaveToRegistry(Optional subKeyPath As String = "Software\2to51CL\Settings")
        Using key As RegistryKey = Registry.CurrentUser.CreateSubKey(subKeyPath)
            If key Is Nothing Then Return
            key.SetValue("CenterWidth", CenterWidth.ToString("0.00", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("CenterSlope", CenterSlope.ToString("0.00", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("SurroundWidth", SurroundWidth.ToString("0.00", CultureInfo.InvariantCulture), RegistryValueKind.String)
            key.SetValue("SurroundSlope", SurroundSlope.ToString("0.00", CultureInfo.InvariantCulture), RegistryValueKind.String)
        End Using
    End Sub

    Public Function LoadFromRegistry(Optional subKeyPath As String = "Software\2to51CL\Settings",
                                     Optional raiseChangedEvent As Boolean = False) As Boolean
        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(subKeyPath, writable:=False)
            If key Is Nothing Then Return False

            Dim cw As Double = ReadRegDouble(key, "CenterWidth", CenterWidth)
            Dim cs As Double = ReadRegDouble(key, "CenterSlope", CenterSlope)
            Dim sw As Double = ReadRegDouble(key, "SurroundWidth", SurroundWidth)
            Dim ss As Double = ReadRegDouble(key, "SurroundSlope", SurroundSlope)

            SetParameters(cw, cs, sw, ss, raiseChangedEvent)
            Return True
        End Using
    End Function

    Private Shared Function ReadIniDouble(fullPath As String, section As String, key As String, fallback As Double) As Double
        Dim sb As New StringBuilder(64)
        GetPrivateProfileString(section, key, String.Empty, sb, sb.Capacity, fullPath)
        Dim parsed As Double
        If Double.TryParse(sb.ToString().Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, parsed) Then
            Return parsed
        End If
        Return fallback
    End Function

    Private Shared Function ReadRegDouble(key As RegistryKey, valueName As String, fallback As Double) As Double
        Dim raw As Object = key.GetValue(valueName, Nothing)
        If raw Is Nothing Then Return fallback
        Dim parsed As Double
        If Double.TryParse(Convert.ToString(raw, CultureInfo.InvariantCulture), NumberStyles.Float, CultureInfo.InvariantCulture, parsed) Then
            Return parsed
        End If
        Return fallback
    End Function

    ' =========================================================================
    ' Layout Helpers
    ' =========================================================================
    Private Shared Function CreateTrackBar(minVal As Integer, maxVal As Integer, initVal As Integer,
                                           tickFreq As Integer, smallChg As Integer, largeChg As Integer) As TrackBar
        Return New TrackBar() With {
            .Minimum = minVal,
            .Maximum = maxVal,
            .Value = initVal,
            .TickFrequency = tickFreq,
            .SmallChange = smallChg,
            .LargeChange = largeChg,
            .TickStyle = TickStyle.BottomRight,
            .AutoSize = False,
            .Height = 26,
            .Dock = DockStyle.Fill,
            .Margin = New Padding(0)
        }
    End Function

    Private Shared Function CreateValueLabel(text As String, foreColor As Color) As Label
        Return New Label() With {
            .Text = text,
            .ForeColor = foreColor,
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold),
            .Size = New Size(38, 15),
            .Anchor = AnchorStyles.Right Or AnchorStyles.Top,
            .Margin = New Padding(0)
        }
    End Function

    Private Shared Sub BuildSliderGroup(grp As GroupBox,
                                        title1 As String, tb1 As TrackBar, val1 As Label, minLbl1 As String, maxLbl1 As String,
                                        title2 As String, tb2 As TrackBar, val2 As Label, minLbl2 As String, maxLbl2 As String)
        Dim tlp As New TableLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 2,
            .RowCount = 6,
            .Padding = New Padding(4, 1, 4, 1),
            .Margin = New Padding(0)
        }
        tlp.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 75.0F))
        tlp.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))

        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 16.0F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 26.0F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 13.0F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 16.0F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 26.0F))
        tlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 13.0F))

        Dim lbl1 As New Label() With {.Text = title1, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleLeft, .Margin = New Padding(0)}
        tlp.Controls.Add(lbl1, 0, 0)
        tlp.Controls.Add(val1, 1, 0)
        tlp.Controls.Add(tb1, 0, 1)
        tlp.SetColumnSpan(tb1, 2)

        Dim rowMinMax1 As Panel = CreateMinMaxRow(minLbl1, maxLbl1)
        tlp.Controls.Add(rowMinMax1, 0, 2)
        tlp.SetColumnSpan(rowMinMax1, 2)

        Dim lbl2 As New Label() With {.Text = title2, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleLeft, .Margin = New Padding(0)}
        tlp.Controls.Add(lbl2, 0, 3)
        tlp.Controls.Add(val2, 1, 3)
        tlp.Controls.Add(tb2, 0, 4)
        tlp.SetColumnSpan(tb2, 2)

        Dim rowMinMax2 As Panel = CreateMinMaxRow(minLbl2, maxLbl2)
        tlp.Controls.Add(rowMinMax2, 0, 5)
        tlp.SetColumnSpan(rowMinMax2, 2)

        grp.Controls.Add(tlp)
    End Sub

    Private Shared Function CreateMinMaxRow(minText As String, maxText As String) As Panel
        Dim pnl As New Panel() With {.Dock = DockStyle.Fill, .Margin = New Padding(0)}
        Dim hintFont As New Font("Segoe UI", 6.5F)

        Dim lblMin As New Label() With {
            .Text = minText,
            .Font = hintFont,
            .ForeColor = Color.DimGray,
            .AutoSize = True,
            .Dock = DockStyle.Left,
            .Margin = New Padding(0)
        }
        Dim lblMax As New Label() With {
            .Text = maxText,
            .Font = hintFont,
            .ForeColor = Color.DimGray,
            .AutoSize = True,
            .Dock = DockStyle.Right,
            .Margin = New Padding(0)
        }
        pnl.Controls.Add(lblMax)
        pnl.Controls.Add(lblMin)
        Return pnl
    End Function

    Private Sub OnTrackBarChanged(sender As Object, e As EventArgs)
        If _suppressEvents Then Return

        _lblCenterWidthVal.Text = CenterWidth.ToString("0.00")
        _lblCenterSlopeVal.Text = CenterSlopeNormalized.ToString("0.00")
        _lblSurroundWidthVal.Text = SurroundWidth.ToString("0.00")
        _lblSurroundSlopeVal.Text = SurroundSlopeNormalized.ToString("0.00")

        _graphCanvas.Invalidate()
        RaiseEvent ParametersChanged(Me, EventArgs.Empty)
    End Sub

    ' =========================================================================
    ' DSP Math Mirrors the C++ Code Exactly
    ' =========================================================================
    Private Shared Function ComputeCenterMask(pan As Double, cWidth As Double, cSlope As Double) As Double
        If cWidth >= 0.999 Then Return 1.0
        Dim effectiveWidth As Double = Math.Max(0.005, cWidth)
        Dim cSlopePower As Double = 2.0 * Math.Max(0.1, cSlope)
        Dim safePan As Double = Math.Max(0.0, pan)
        Return 1.0 / (1.0 + Math.Pow(safePan / effectiveWidth, cSlopePower))
    End Function

    Private Shared Function ComputeSurroundPanMask(pan As Double, sWidth As Double, sSlope As Double) As Double
        If sWidth >= 0.999 Then Return 1.0
        Dim effectiveSWidth As Double = Math.Max(0.005, sWidth)
        Dim sSlopePower As Double = 2.0 * Math.Max(0.1, sSlope)
        Dim dist As Double = Math.Max(0.0, 1.0 - pan) / effectiveSWidth
        If dist > 10.0 Then Return 0.0
        Return 1.0 / (1.0 + Math.Pow(dist, sSlopePower))
    End Function

    ' =========================================================================
    ' GDI+ Graph Rendering
    ' =========================================================================
    Private Sub GraphCanvas_Paint(sender As Object, e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim w As Integer = _graphCanvas.ClientSize.Width
        Dim h As Integer = _graphCanvas.ClientSize.Height
        If w < 100 OrElse h < 70 Then Return

        Const padLeft As Single = 34.0F
        Const padRight As Single = 32.0F
        Const padTop As Single = 24.0F
        Const padBottom As Single = 20.0F

        Dim plotRect As New RectangleF(padLeft, padTop, w - padLeft - padRight, h - padTop - padBottom)
        If plotRect.Width <= 10 OrElse plotRect.Height <= 10 Then Return

        Dim cw As Double = CenterWidth
        Dim cs As Double = CenterSlope
        Dim sw As Double = SurroundWidth
        Dim ss As Double = SurroundSlope

        Using borderPen As New Pen(Color.FromArgb(80, 90, 108), 1.0F)
            g.DrawRectangle(borderPen, 0, 0, w - 1, h - 1)
        End Using

        Using gridPen As New Pen(Color.FromArgb(38, 46, 61), 1.0F),
              halfPen As New Pen(Color.FromArgb(59, 71, 94), 1.0F) With {.DashStyle = DashStyle.Dash},
              axisPen As New Pen(Color.FromArgb(75, 85, 99), 1.0F),
              lblBrush As New SolidBrush(Color.FromArgb(148, 163, 184)),
              xLblBrush As New SolidBrush(Color.FromArgb(203, 213, 225)),
              axisFont As New Font("Segoe UI", 6.8F)

            For i As Integer = 0 To 4
                Dim normY As Single = i / 4.0F
                Dim y As Single = plotRect.Bottom - normY * plotRect.Height
                Dim p As Pen = If(i = 0, axisPen, If(i = 2, halfPen, gridPen))
                g.DrawLine(p, plotRect.Left, y, plotRect.Right, y)

                Using sfRight As New StringFormat() With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center}
                    g.DrawString(normY.ToString("0.00"), axisFont, lblBrush, plotRect.Left - 4.0F, y, sfRight)
                End Using
            Next

            Dim xLabels() As String = {"-1.0 (Hard L)", "-0.5", "0.0 (Center)", "+0.5", "+1.0 (Hard R)"}
            For i As Integer = 0 To 4
                Dim normX As Single = i / 4.0F
                Dim x As Single = plotRect.Left + normX * plotRect.Width
                Dim p As Pen = If(i = 0 OrElse i = 4, axisPen, gridPen)
                g.DrawLine(p, x, plotRect.Top, x, plotRect.Bottom)

                Using sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near}
                    g.DrawString(xLabels(i), axisFont, xLblBrush, x, plotRect.Bottom + 3.0F, sfCenter)
                End Using
            Next
        End Using

        If cw < 0.999 Then
            Using cGuidePen As New Pen(Color.FromArgb(120, 56, 189, 248), 1.0F) With {.DashStyle = DashStyle.Dot}
                Dim xL As Single = MapPanToX(CSng(-cw), plotRect)
                Dim xR As Single = MapPanToX(CSng(cw), plotRect)
                g.DrawLine(cGuidePen, xL, plotRect.Top, xL, plotRect.Bottom)
                g.DrawLine(cGuidePen, xR, plotRect.Top, xR, plotRect.Bottom)
            End Using
        End If
        If sw < 0.999 Then
            Using sGuidePen As New Pen(Color.FromArgb(120, 251, 146, 60), 1.0F) With {.DashStyle = DashStyle.Dot}
                Dim xL As Single = MapPanToX(CSng(-(1.0 - sw)), plotRect)
                Dim xR As Single = MapPanToX(CSng(1.0 - sw), plotRect)
                g.DrawLine(sGuidePen, xL, plotRect.Top, xL, plotRect.Bottom)
                g.DrawLine(sGuidePen, xR, plotRect.Top, xR, plotRect.Bottom)
            End Using
        End If

        Const steps As Integer = 180
        Dim ptsCenter(steps) As PointF
        Dim ptsFrontLR(steps) As PointF
        Dim ptsSurrLeft(steps \ 2) As PointF
        Dim ptsSurrRight(steps \ 2) As PointF
        Dim ptsInPhaseLeft(steps \ 2) As PointF
        Dim ptsInPhaseRight(steps \ 2) As PointF

        For i As Integer = 0 To steps
            Dim xPan As Double = -1.0 + (2.0 * i / steps)
            Dim absPan As Double = Math.Abs(xPan)

            Dim cVal As Double = ComputeCenterMask(absPan, cw, cs)
            Dim sVal As Double = ComputeSurroundPanMask(absPan, sw, ss)
            Dim lrResidual As Double = Math.Max(0.0, (1.0 - cVal) * (1.0 - sVal))
            Dim diffIccInPhase As Double = (2.0 * absPan * absPan) / (1.0 + absPan * absPan)
            Dim sInPhase As Double = sVal * diffIccInPhase

            Dim px As Single = MapPanToX(CSng(xPan), plotRect)
            ptsCenter(i) = New PointF(px, MapGainToY(CSng(cVal), plotRect))
            ptsFrontLR(i) = New PointF(px, MapGainToY(CSng(lrResidual), plotRect))

            If i <= steps \ 2 Then
                ptsSurrLeft(i) = New PointF(px, MapGainToY(CSng(sVal), plotRect))
                ptsInPhaseLeft(i) = New PointF(px, MapGainToY(CSng(sInPhase), plotRect))
            End If
            If i >= steps \ 2 Then
                Dim idxR As Integer = i - (steps \ 2)
                ptsSurrRight(idxR) = New PointF(px, MapGainToY(CSng(sVal), plotRect))
                ptsInPhaseRight(idxR) = New PointF(px, MapGainToY(CSng(sInPhase), plotRect))
            End If
        Next

        'DrawFilledCurve(g, ptsFrontLR, plotRect, Color.FromArgb(74, 222, 128), 40, 1.4F)
        'DrawFilledCurve(g, ptsSurrLeft, plotRect, Color.FromArgb(251, 146, 60), 55, 1.6F)
        'DrawFilledCurve(g, ptsSurrRight, plotRect, Color.FromArgb(251, 146, 60), 55, 1.6F)

        DrawFilledCurve(g, ptsFrontLR, plotRect, Color.FromArgb(222, 74, 74), 40, 1.4F)
        DrawFilledCurve(g, ptsSurrLeft, plotRect, Color.FromArgb(74, 120, 222), 55, 1.6F)
        DrawFilledCurve(g, ptsSurrRight, plotRect, Color.FromArgb(74, 120, 222), 55, 1.6F)

        'Using dashPen As New Pen(Color.FromArgb(253, 186, 116), 1.2F) With {.DashStyle = DashStyle.Dash}
        'g.DrawLines(dashPen, ptsInPhaseLeft)
        'g.DrawLines(dashPen, ptsInPhaseRight)
        'End Using

        DrawFilledCurve(g, ptsCenter, plotRect, Color.FromArgb(74, 222, 109), 64, 1.7F)
        DrawLegend(g, w)
    End Sub

    Private Shared Sub DrawFilledCurve(g As Graphics, pts() As PointF, plotRect As RectangleF,
                                       lineColor As Color, fillAlpha As Integer, strokeWidth As Single)
        If pts.Length < 2 Then Return
        Using gp As New GraphicsPath()
            gp.AddLine(pts(0).X, plotRect.Bottom, pts(0).X, pts(0).Y)
            gp.AddLines(pts)
            gp.AddLine(pts(pts.Length - 1).X, pts(pts.Length - 1).Y, pts(pts.Length - 1).X, plotRect.Bottom)
            gp.CloseFigure()

            Using fillBrush As New SolidBrush(Color.FromArgb(fillAlpha, lineColor))
                g.FillPath(fillBrush, gp)
            End Using
        End Using

        Using linePen As New Pen(lineColor, strokeWidth)
            g.DrawLines(linePen, pts)
        End Using
    End Sub

    Private Shared Sub DrawLegend(g As Graphics, canvasWidth As Integer)
        Using titleFont As New Font("Segoe UI", 7.5F, FontStyle.Bold),
              legendFont As New Font("Segoe UI", 6.8F),
              textBrush As New SolidBrush(Color.FromArgb(217, 225, 236))

            g.DrawString("Mask Gain vs. Pan", titleFont, textBrush, 7.0F, 5.0F)

            Dim items() As LegendEntry = {
                New LegendEntry("Center (C)", Color.FromArgb(74, 222, 109), False),
                New LegendEntry("Front L/R", Color.FromArgb(222, 74, 74), False),
                New LegendEntry("Ls/Rs (Surround)", Color.FromArgb(74, 120, 222), False)}
            'New LegendEntry("In-Phase Pan", Color.FromArgb(253, 186, 116), True)
            '}

            Dim curX As Single = canvasWidth - 8.0F
            For i As Integer = items.Length - 1 To 0 Step -1
                Dim item As LegendEntry = items(i)
                Dim sz As SizeF = g.MeasureString(item.Text, legendFont)
                curX -= sz.Width
                g.DrawString(item.Text, legendFont, textBrush, curX, 6.0F)
                curX -= 11.0F

                If item.IsDashed Then
                    Using p As New Pen(item.Col, 1.3F) With {.DashStyle = DashStyle.Dash}
                        g.DrawLine(p, curX, 11.5F, curX + 9.0F, 11.5F)
                    End Using
                Else
                    Using b As New SolidBrush(item.Col)
                        g.FillRectangle(b, curX, 8.0F, 7.5F, 6.5F)
                    End Using
                End If
                curX -= 7.0F
            Next
        End Using
    End Sub

    Private Shared Function MapPanToX(pan As Single, plotRect As RectangleF) As Single
        Return plotRect.Left + ((pan + 1.0F) * 0.5F) * plotRect.Width
    End Function

    Private Shared Function MapGainToY(gain As Single, plotRect As RectangleF) As Single
        Dim clamped As Single = Math.Max(0.0F, Math.Min(1.0F, gain))
        Return plotRect.Bottom - clamped * plotRect.Height
    End Function
End Class