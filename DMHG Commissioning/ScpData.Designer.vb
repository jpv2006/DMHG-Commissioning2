<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ScpData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_ScpData))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel_Title = New System.Windows.Forms.Panel()
        Me.Label_Title = New System.Windows.Forms.Label()
        Me.PictureBox_Logo = New System.Windows.Forms.PictureBox()
        Me.Label_Scanner = New System.Windows.Forms.Label()
        Me.Label_Electrometer = New System.Windows.Forms.Label()
        Me.ComboBox_Electrometer = New System.Windows.Forms.ComboBox()
        Me.Label_Chamber = New System.Windows.Forms.Label()
        Me.ComboBox_SmallFieldDetector = New System.Windows.Forms.ComboBox()
        Me.Panel_BottomSelections = New System.Windows.Forms.Panel()
        Me.Button_Exit = New System.Windows.Forms.Button()
        Me.Button_Back = New System.Windows.Forms.Button()
        Me.Panel_HeaderInfo = New System.Windows.Forms.Panel()
        Me.ComboBox_Thermometer = New System.Windows.Forms.ComboBox()
        Me.Label_Thermometer = New System.Windows.Forms.Label()
        Me.ComboBox_Barometer = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ComboBox_Scanner = New System.Windows.Forms.ComboBox()
        Me.Label_Detector = New System.Windows.Forms.Label()
        Me.Label_SCD = New System.Windows.Forms.Label()
        Me.Label_DetectorSCD = New System.Windows.Forms.Label()
        Me.TextBox_ScpTolerance = New System.Windows.Forms.TextBox()
        Me.TextBox_ReadingsTolerance = New System.Windows.Forms.TextBox()
        Me.Label_ScpTolerance = New System.Windows.Forms.Label()
        Me.Label_ReadingsTolerance = New System.Windows.Forms.Label()
        Me.Label_Tolerance = New System.Windows.Forms.Label()
        Me.ComboBox_Energy = New System.Windows.Forms.ComboBox()
        Me.Label_SSD = New System.Windows.Forms.Label()
        Me.Label_SetupSSD = New System.Windows.Forms.Label()
        Me.Label_FieldSize = New System.Windows.Forms.Label()
        Me.Label_Reading1 = New System.Windows.Forms.Label()
        Me.Label_Reading2 = New System.Windows.Forms.Label()
        Me.TextBox_X = New System.Windows.Forms.TextBox()
        Me.TextBox_Reading2 = New System.Windows.Forms.TextBox()
        Me.TextBox_Average = New System.Windows.Forms.TextBox()
        Me.TextBox_Y = New System.Windows.Forms.TextBox()
        Me.Label_X = New System.Windows.Forms.Label()
        Me.Label_Y = New System.Windows.Forms.Label()
        Me.Label_Average = New System.Windows.Forms.Label()
        Me.Button_Select = New System.Windows.Forms.Button()
        Me.DataGridView_Factors = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox_Reading1 = New System.Windows.Forms.TextBox()
        Me.Label_SelectRowToEdit = New System.Windows.Forms.Label()
        Me.Button_Edit = New System.Windows.Forms.Button()
        Me.Button_Enter = New System.Windows.Forms.Button()
        Me.Panel_Data = New System.Windows.Forms.Panel()
        Me.Button_Pressure = New System.Windows.Forms.Button()
        Me.TextBox_Pressure = New System.Windows.Forms.TextBox()
        Me.Button_Temperature = New System.Windows.Forms.Button()
        Me.TextBox_Temperature = New System.Windows.Forms.TextBox()
        Me.Panel_Stability = New System.Windows.Forms.Panel()
        Me.GroupBox_Stability = New System.Windows.Forms.GroupBox()
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
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button_StabEnter = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_Skip = New System.Windows.Forms.Button()
        Me.Label_StabInstructions = New System.Windows.Forms.Label()
        Me.TextBox_StabReading = New System.Windows.Forms.TextBox()
        Me.Label_StabHeader = New System.Windows.Forms.Label()
        Me.Panel_Title.SuspendLayout()
        CType(Me.PictureBox_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_BottomSelections.SuspendLayout()
        Me.Panel_HeaderInfo.SuspendLayout()
        CType(Me.DataGridView_Factors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Data.SuspendLayout()
        Me.Panel_Stability.SuspendLayout()
        Me.GroupBox_Stability.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel_Title
        '
        Me.Panel_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Title.Controls.Add(Me.Label_Title)
        Me.Panel_Title.Controls.Add(Me.PictureBox_Logo)
        Me.Panel_Title.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Title.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Title.Name = "Panel_Title"
        Me.Panel_Title.Size = New System.Drawing.Size(1314, 90)
        Me.Panel_Title.TabIndex = 1
        '
        'Label_Title
        '
        Me.Label_Title.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label_Title.AutoSize = True
        Me.Label_Title.Font = New System.Drawing.Font("Book Antiqua", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Title.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label_Title.Location = New System.Drawing.Point(368, 17)
        Me.Label_Title.Name = "Label_Title"
        Me.Label_Title.Size = New System.Drawing.Size(314, 51)
        Me.Label_Title.TabIndex = 2
        Me.Label_Title.Text = "Output Factors"
        '
        'PictureBox_Logo
        '
        Me.PictureBox_Logo.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox_Logo.Image = CType(resources.GetObject("PictureBox_Logo.Image"), System.Drawing.Image)
        Me.PictureBox_Logo.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox_Logo.Name = "PictureBox_Logo"
        Me.PictureBox_Logo.Size = New System.Drawing.Size(226, 88)
        Me.PictureBox_Logo.TabIndex = 0
        Me.PictureBox_Logo.TabStop = False
        '
        'Label_Scanner
        '
        Me.Label_Scanner.AutoSize = True
        Me.Label_Scanner.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scanner.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label_Scanner.Location = New System.Drawing.Point(252, 13)
        Me.Label_Scanner.Name = "Label_Scanner"
        Me.Label_Scanner.Size = New System.Drawing.Size(216, 24)
        Me.Label_Scanner.TabIndex = 4
        Me.Label_Scanner.Text = "Measurement System:"
        '
        'Label_Electrometer
        '
        Me.Label_Electrometer.AutoSize = True
        Me.Label_Electrometer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Electrometer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label_Electrometer.Location = New System.Drawing.Point(765, 97)
        Me.Label_Electrometer.Name = "Label_Electrometer"
        Me.Label_Electrometer.Size = New System.Drawing.Size(135, 24)
        Me.Label_Electrometer.TabIndex = 5
        Me.Label_Electrometer.Text = "Electrometer:"
        '
        'ComboBox_Electrometer
        '
        Me.ComboBox_Electrometer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_Electrometer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComboBox_Electrometer.FormattingEnabled = True
        Me.ComboBox_Electrometer.Items.AddRange(New Object() {"", "SuperMax", "3DS"})
        Me.ComboBox_Electrometer.Location = New System.Drawing.Point(906, 94)
        Me.ComboBox_Electrometer.Name = "ComboBox_Electrometer"
        Me.ComboBox_Electrometer.Size = New System.Drawing.Size(226, 32)
        Me.ComboBox_Electrometer.TabIndex = 6
        '
        'Label_Chamber
        '
        Me.Label_Chamber.AutoSize = True
        Me.Label_Chamber.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Chamber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label_Chamber.Location = New System.Drawing.Point(702, 55)
        Me.Label_Chamber.Name = "Label_Chamber"
        Me.Label_Chamber.Size = New System.Drawing.Size(198, 24)
        Me.Label_Chamber.TabIndex = 7
        Me.Label_Chamber.Text = "SmallField Detector:"
        '
        'ComboBox_SmallFieldDetector
        '
        Me.ComboBox_SmallFieldDetector.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_SmallFieldDetector.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComboBox_SmallFieldDetector.FormattingEnabled = True
        Me.ComboBox_SmallFieldDetector.Items.AddRange(New Object() {"", "SNC1", "SNC2", "Edge1", "Edge2"})
        Me.ComboBox_SmallFieldDetector.Location = New System.Drawing.Point(906, 52)
        Me.ComboBox_SmallFieldDetector.Name = "ComboBox_SmallFieldDetector"
        Me.ComboBox_SmallFieldDetector.Size = New System.Drawing.Size(226, 32)
        Me.ComboBox_SmallFieldDetector.TabIndex = 8
        '
        'Panel_BottomSelections
        '
        Me.Panel_BottomSelections.Controls.Add(Me.Button_Exit)
        Me.Panel_BottomSelections.Controls.Add(Me.Button_Back)
        Me.Panel_BottomSelections.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel_BottomSelections.Location = New System.Drawing.Point(0, 652)
        Me.Panel_BottomSelections.Name = "Panel_BottomSelections"
        Me.Panel_BottomSelections.Size = New System.Drawing.Size(1314, 45)
        Me.Panel_BottomSelections.TabIndex = 2
        '
        'Button_Exit
        '
        Me.Button_Exit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button_Exit.AutoEllipsis = True
        Me.Button_Exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Exit.Location = New System.Drawing.Point(1153, 2)
        Me.Button_Exit.Name = "Button_Exit"
        Me.Button_Exit.Size = New System.Drawing.Size(99, 40)
        Me.Button_Exit.TabIndex = 38
        Me.Button_Exit.Text = "Exit"
        Me.Button_Exit.UseVisualStyleBackColor = True
        '
        'Button_Back
        '
        Me.Button_Back.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button_Back.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Back.Location = New System.Drawing.Point(35, 3)
        Me.Button_Back.Name = "Button_Back"
        Me.Button_Back.Size = New System.Drawing.Size(100, 39)
        Me.Button_Back.TabIndex = 0
        Me.Button_Back.Text = "Back"
        Me.Button_Back.UseVisualStyleBackColor = True
        '
        'Panel_HeaderInfo
        '
        Me.Panel_HeaderInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_HeaderInfo.Controls.Add(Me.ComboBox_Thermometer)
        Me.Panel_HeaderInfo.Controls.Add(Me.Label_Thermometer)
        Me.Panel_HeaderInfo.Controls.Add(Me.ComboBox_Barometer)
        Me.Panel_HeaderInfo.Controls.Add(Me.Label22)
        Me.Panel_HeaderInfo.Controls.Add(Me.ComboBox_Scanner)
        Me.Panel_HeaderInfo.Controls.Add(Me.Label_Detector)
        Me.Panel_HeaderInfo.Controls.Add(Me.Label_SCD)
        Me.Panel_HeaderInfo.Controls.Add(Me.Label_DetectorSCD)
        Me.Panel_HeaderInfo.Controls.Add(Me.TextBox_ScpTolerance)
        Me.Panel_HeaderInfo.Controls.Add(Me.TextBox_ReadingsTolerance)
        Me.Panel_HeaderInfo.Controls.Add(Me.Label_ScpTolerance)
        Me.Panel_HeaderInfo.Controls.Add(Me.Label_ReadingsTolerance)
        Me.Panel_HeaderInfo.Controls.Add(Me.Label_Tolerance)
        Me.Panel_HeaderInfo.Controls.Add(Me.ComboBox_Energy)
        Me.Panel_HeaderInfo.Controls.Add(Me.Label_SSD)
        Me.Panel_HeaderInfo.Controls.Add(Me.Label_SetupSSD)
        Me.Panel_HeaderInfo.Controls.Add(Me.ComboBox_SmallFieldDetector)
        Me.Panel_HeaderInfo.Controls.Add(Me.Label_Scanner)
        Me.Panel_HeaderInfo.Controls.Add(Me.Label_Chamber)
        Me.Panel_HeaderInfo.Controls.Add(Me.ComboBox_Electrometer)
        Me.Panel_HeaderInfo.Controls.Add(Me.Label_Electrometer)
        Me.Panel_HeaderInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_HeaderInfo.Location = New System.Drawing.Point(0, 90)
        Me.Panel_HeaderInfo.Name = "Panel_HeaderInfo"
        Me.Panel_HeaderInfo.Size = New System.Drawing.Size(1314, 138)
        Me.Panel_HeaderInfo.TabIndex = 3
        '
        'ComboBox_Thermometer
        '
        Me.ComboBox_Thermometer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_Thermometer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComboBox_Thermometer.FormattingEnabled = True
        Me.ComboBox_Thermometer.Location = New System.Drawing.Point(478, 91)
        Me.ComboBox_Thermometer.Name = "ComboBox_Thermometer"
        Me.ComboBox_Thermometer.Size = New System.Drawing.Size(193, 32)
        Me.ComboBox_Thermometer.TabIndex = 28
        '
        'Label_Thermometer
        '
        Me.Label_Thermometer.AutoSize = True
        Me.Label_Thermometer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Thermometer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label_Thermometer.Location = New System.Drawing.Point(326, 94)
        Me.Label_Thermometer.Name = "Label_Thermometer"
        Me.Label_Thermometer.Size = New System.Drawing.Size(142, 24)
        Me.Label_Thermometer.TabIndex = 27
        Me.Label_Thermometer.Text = "Thermometer:"
        '
        'ComboBox_Barometer
        '
        Me.ComboBox_Barometer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_Barometer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComboBox_Barometer.FormattingEnabled = True
        Me.ComboBox_Barometer.Location = New System.Drawing.Point(478, 50)
        Me.ComboBox_Barometer.Name = "ComboBox_Barometer"
        Me.ComboBox_Barometer.Size = New System.Drawing.Size(193, 32)
        Me.ComboBox_Barometer.TabIndex = 26
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(356, 55)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 24)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "Barometer:"
        '
        'ComboBox_Scanner
        '
        Me.ComboBox_Scanner.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_Scanner.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComboBox_Scanner.FormattingEnabled = True
        Me.ComboBox_Scanner.Location = New System.Drawing.Point(478, 10)
        Me.ComboBox_Scanner.Name = "ComboBox_Scanner"
        Me.ComboBox_Scanner.Size = New System.Drawing.Size(222, 32)
        Me.ComboBox_Scanner.TabIndex = 24
        '
        'Label_Detector
        '
        Me.Label_Detector.AutoSize = True
        Me.Label_Detector.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Detector.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label_Detector.Location = New System.Drawing.Point(806, 13)
        Me.Label_Detector.Name = "Label_Detector"
        Me.Label_Detector.Size = New System.Drawing.Size(94, 24)
        Me.Label_Detector.TabIndex = 21
        Me.Label_Detector.Text = "Detector:"
        '
        'Label_SCD
        '
        Me.Label_SCD.AutoSize = True
        Me.Label_SCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_SCD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label_SCD.Location = New System.Drawing.Point(160, 60)
        Me.Label_SCD.Name = "Label_SCD"
        Me.Label_SCD.Size = New System.Drawing.Size(48, 24)
        Me.Label_SCD.TabIndex = 20
        Me.Label_SCD.Text = "SCD"
        '
        'Label_DetectorSCD
        '
        Me.Label_DetectorSCD.AutoSize = True
        Me.Label_DetectorSCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_DetectorSCD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label_DetectorSCD.Location = New System.Drawing.Point(13, 60)
        Me.Label_DetectorSCD.Name = "Label_DetectorSCD"
        Me.Label_DetectorSCD.Size = New System.Drawing.Size(141, 24)
        Me.Label_DetectorSCD.TabIndex = 19
        Me.Label_DetectorSCD.Text = "Detector SCD:"
        '
        'TextBox_ScpTolerance
        '
        Me.TextBox_ScpTolerance.Location = New System.Drawing.Point(1246, 60)
        Me.TextBox_ScpTolerance.Name = "TextBox_ScpTolerance"
        Me.TextBox_ScpTolerance.Size = New System.Drawing.Size(29, 20)
        Me.TextBox_ScpTolerance.TabIndex = 18
        Me.TextBox_ScpTolerance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_ReadingsTolerance
        '
        Me.TextBox_ReadingsTolerance.Location = New System.Drawing.Point(1188, 60)
        Me.TextBox_ReadingsTolerance.Name = "TextBox_ReadingsTolerance"
        Me.TextBox_ReadingsTolerance.Size = New System.Drawing.Size(29, 20)
        Me.TextBox_ReadingsTolerance.TabIndex = 17
        Me.TextBox_ReadingsTolerance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_ScpTolerance
        '
        Me.Label_ScpTolerance.AutoSize = True
        Me.Label_ScpTolerance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ScpTolerance.Location = New System.Drawing.Point(1246, 38)
        Me.Label_ScpTolerance.Name = "Label_ScpTolerance"
        Me.Label_ScpTolerance.Size = New System.Drawing.Size(29, 13)
        Me.Label_ScpTolerance.TabIndex = 16
        Me.Label_ScpTolerance.Text = "Scp"
        '
        'Label_ReadingsTolerance
        '
        Me.Label_ReadingsTolerance.AutoSize = True
        Me.Label_ReadingsTolerance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ReadingsTolerance.Location = New System.Drawing.Point(1171, 38)
        Me.Label_ReadingsTolerance.Name = "Label_ReadingsTolerance"
        Me.Label_ReadingsTolerance.Size = New System.Drawing.Size(60, 13)
        Me.Label_ReadingsTolerance.TabIndex = 15
        Me.Label_ReadingsTolerance.Text = "Readings"
        '
        'Label_Tolerance
        '
        Me.Label_Tolerance.AutoSize = True
        Me.Label_Tolerance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Tolerance.Location = New System.Drawing.Point(1185, 13)
        Me.Label_Tolerance.Name = "Label_Tolerance"
        Me.Label_Tolerance.Size = New System.Drawing.Size(77, 13)
        Me.Label_Tolerance.TabIndex = 14
        Me.Label_Tolerance.Text = "% Tolerance"
        '
        'ComboBox_Energy
        '
        Me.ComboBox_Energy.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_Energy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComboBox_Energy.FormattingEnabled = True
        Me.ComboBox_Energy.Location = New System.Drawing.Point(906, 10)
        Me.ComboBox_Energy.Name = "ComboBox_Energy"
        Me.ComboBox_Energy.Size = New System.Drawing.Size(226, 32)
        Me.ComboBox_Energy.TabIndex = 12
        '
        'Label_SSD
        '
        Me.Label_SSD.AutoSize = True
        Me.Label_SSD.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_SSD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label_SSD.Location = New System.Drawing.Point(134, 13)
        Me.Label_SSD.Name = "Label_SSD"
        Me.Label_SSD.Size = New System.Drawing.Size(47, 24)
        Me.Label_SSD.TabIndex = 10
        Me.Label_SSD.Text = "SSD"
        '
        'Label_SetupSSD
        '
        Me.Label_SetupSSD.AutoSize = True
        Me.Label_SetupSSD.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_SetupSSD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label_SetupSSD.Location = New System.Drawing.Point(12, 13)
        Me.Label_SetupSSD.Name = "Label_SetupSSD"
        Me.Label_SetupSSD.Size = New System.Drawing.Size(116, 24)
        Me.Label_SetupSSD.TabIndex = 9
        Me.Label_SetupSSD.Text = "Setup SSD:"
        '
        'Label_FieldSize
        '
        Me.Label_FieldSize.AutoSize = True
        Me.Label_FieldSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Label_FieldSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_FieldSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_FieldSize.Location = New System.Drawing.Point(274, 40)
        Me.Label_FieldSize.Name = "Label_FieldSize"
        Me.Label_FieldSize.Size = New System.Drawing.Size(90, 22)
        Me.Label_FieldSize.TabIndex = 0
        Me.Label_FieldSize.Text = "Field Size"
        '
        'Label_Reading1
        '
        Me.Label_Reading1.AutoSize = True
        Me.Label_Reading1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Label_Reading1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_Reading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Reading1.Location = New System.Drawing.Point(379, 40)
        Me.Label_Reading1.Name = "Label_Reading1"
        Me.Label_Reading1.Size = New System.Drawing.Size(93, 22)
        Me.Label_Reading1.TabIndex = 1
        Me.Label_Reading1.Text = "Reading 1"
        '
        'Label_Reading2
        '
        Me.Label_Reading2.AutoSize = True
        Me.Label_Reading2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Label_Reading2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_Reading2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Reading2.Location = New System.Drawing.Point(487, 40)
        Me.Label_Reading2.Name = "Label_Reading2"
        Me.Label_Reading2.Size = New System.Drawing.Size(93, 22)
        Me.Label_Reading2.TabIndex = 2
        Me.Label_Reading2.Text = "Reading 2"
        '
        'TextBox_X
        '
        Me.TextBox_X.Enabled = False
        Me.TextBox_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_X.Location = New System.Drawing.Point(271, 86)
        Me.TextBox_X.Name = "TextBox_X"
        Me.TextBox_X.ReadOnly = True
        Me.TextBox_X.Size = New System.Drawing.Size(41, 26)
        Me.TextBox_X.TabIndex = 6
        Me.TextBox_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_Reading2
        '
        Me.TextBox_Reading2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Reading2.Location = New System.Drawing.Point(490, 86)
        Me.TextBox_Reading2.Name = "TextBox_Reading2"
        Me.TextBox_Reading2.Size = New System.Drawing.Size(90, 26)
        Me.TextBox_Reading2.TabIndex = 8
        Me.TextBox_Reading2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_Average
        '
        Me.TextBox_Average.Enabled = False
        Me.TextBox_Average.Location = New System.Drawing.Point(596, 90)
        Me.TextBox_Average.Name = "TextBox_Average"
        Me.TextBox_Average.Size = New System.Drawing.Size(90, 20)
        Me.TextBox_Average.TabIndex = 12
        Me.TextBox_Average.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_Y
        '
        Me.TextBox_Y.Enabled = False
        Me.TextBox_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Y.Location = New System.Drawing.Point(323, 86)
        Me.TextBox_Y.Name = "TextBox_Y"
        Me.TextBox_Y.ReadOnly = True
        Me.TextBox_Y.Size = New System.Drawing.Size(41, 26)
        Me.TextBox_Y.TabIndex = 14
        Me.TextBox_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_X
        '
        Me.Label_X.AutoSize = True
        Me.Label_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_X.Location = New System.Drawing.Point(284, 66)
        Me.Label_X.Name = "Label_X"
        Me.Label_X.Size = New System.Drawing.Size(15, 13)
        Me.Label_X.TabIndex = 15
        Me.Label_X.Text = "X"
        '
        'Label_Y
        '
        Me.Label_Y.AutoSize = True
        Me.Label_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Y.Location = New System.Drawing.Point(330, 66)
        Me.Label_Y.Name = "Label_Y"
        Me.Label_Y.Size = New System.Drawing.Size(15, 13)
        Me.Label_Y.TabIndex = 16
        Me.Label_Y.Text = "Y"
        '
        'Label_Average
        '
        Me.Label_Average.AutoSize = True
        Me.Label_Average.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Label_Average.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_Average.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Average.Location = New System.Drawing.Point(601, 40)
        Me.Label_Average.Name = "Label_Average"
        Me.Label_Average.Size = New System.Drawing.Size(77, 22)
        Me.Label_Average.TabIndex = 17
        Me.Label_Average.Text = "Average"
        '
        'Button_Select
        '
        Me.Button_Select.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Select.Location = New System.Drawing.Point(1039, 29)
        Me.Button_Select.Name = "Button_Select"
        Me.Button_Select.Size = New System.Drawing.Size(176, 33)
        Me.Button_Select.TabIndex = 19
        Me.Button_Select.Text = "Select Row to edit"
        Me.Button_Select.UseVisualStyleBackColor = True
        Me.Button_Select.Visible = False
        '
        'DataGridView_Factors
        '
        Me.DataGridView_Factors.AllowUserToAddRows = False
        Me.DataGridView_Factors.AllowUserToDeleteRows = False
        Me.DataGridView_Factors.AllowUserToResizeColumns = False
        Me.DataGridView_Factors.AllowUserToResizeRows = False
        Me.DataGridView_Factors.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.DataGridView_Factors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView_Factors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView_Factors.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView_Factors.ColumnHeadersHeight = 30
        Me.DataGridView_Factors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.DataGridView_Factors.DataMember = "11"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView_Factors.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView_Factors.Location = New System.Drawing.Point(4, 118)
        Me.DataGridView_Factors.Name = "DataGridView_Factors"
        Me.DataGridView_Factors.ReadOnly = True
        Me.DataGridView_Factors.RowHeadersVisible = False
        Me.DataGridView_Factors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView_Factors.Size = New System.Drawing.Size(1306, 289)
        Me.DataGridView_Factors.TabIndex = 9
        Me.DataGridView_Factors.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "RowKey"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'TextBox_Reading1
        '
        Me.TextBox_Reading1.BackColor = System.Drawing.Color.White
        Me.TextBox_Reading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Reading1.Location = New System.Drawing.Point(379, 86)
        Me.TextBox_Reading1.Name = "TextBox_Reading1"
        Me.TextBox_Reading1.Size = New System.Drawing.Size(90, 26)
        Me.TextBox_Reading1.TabIndex = 7
        Me.TextBox_Reading1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_SelectRowToEdit
        '
        Me.Label_SelectRowToEdit.AutoSize = True
        Me.Label_SelectRowToEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label_SelectRowToEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_SelectRowToEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_SelectRowToEdit.Location = New System.Drawing.Point(937, 88)
        Me.Label_SelectRowToEdit.Name = "Label_SelectRowToEdit"
        Me.Label_SelectRowToEdit.Size = New System.Drawing.Size(142, 22)
        Me.Label_SelectRowToEdit.TabIndex = 20
        Me.Label_SelectRowToEdit.Text = "Select Row to Edit"
        Me.Label_SelectRowToEdit.Visible = False
        '
        'Button_Edit
        '
        Me.Button_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Edit.Location = New System.Drawing.Point(843, 82)
        Me.Button_Edit.Name = "Button_Edit"
        Me.Button_Edit.Size = New System.Drawing.Size(88, 33)
        Me.Button_Edit.TabIndex = 4
        Me.Button_Edit.Text = "Edit"
        Me.Button_Edit.UseVisualStyleBackColor = True
        '
        'Button_Enter
        '
        Me.Button_Enter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Enter.Location = New System.Drawing.Point(707, 82)
        Me.Button_Enter.Name = "Button_Enter"
        Me.Button_Enter.Size = New System.Drawing.Size(120, 31)
        Me.Button_Enter.TabIndex = 3
        Me.Button_Enter.Text = "Enter"
        Me.Button_Enter.UseVisualStyleBackColor = True
        '
        'Panel_Data
        '
        Me.Panel_Data.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel_Data.Controls.Add(Me.Button_Pressure)
        Me.Panel_Data.Controls.Add(Me.Label_SelectRowToEdit)
        Me.Panel_Data.Controls.Add(Me.DataGridView_Factors)
        Me.Panel_Data.Controls.Add(Me.TextBox_Pressure)
        Me.Panel_Data.Controls.Add(Me.Button_Temperature)
        Me.Panel_Data.Controls.Add(Me.Button_Edit)
        Me.Panel_Data.Controls.Add(Me.Button_Select)
        Me.Panel_Data.Controls.Add(Me.Button_Enter)
        Me.Panel_Data.Controls.Add(Me.Label_Average)
        Me.Panel_Data.Controls.Add(Me.Label_Y)
        Me.Panel_Data.Controls.Add(Me.Label_X)
        Me.Panel_Data.Controls.Add(Me.TextBox_Y)
        Me.Panel_Data.Controls.Add(Me.TextBox_Reading1)
        Me.Panel_Data.Controls.Add(Me.TextBox_Average)
        Me.Panel_Data.Controls.Add(Me.TextBox_Reading2)
        Me.Panel_Data.Controls.Add(Me.TextBox_X)
        Me.Panel_Data.Controls.Add(Me.Label_Reading2)
        Me.Panel_Data.Controls.Add(Me.Label_Reading1)
        Me.Panel_Data.Controls.Add(Me.Label_FieldSize)
        Me.Panel_Data.Controls.Add(Me.TextBox_Temperature)
        Me.Panel_Data.Location = New System.Drawing.Point(0, 228)
        Me.Panel_Data.Name = "Panel_Data"
        Me.Panel_Data.Size = New System.Drawing.Size(1313, 420)
        Me.Panel_Data.TabIndex = 4
        Me.Panel_Data.Visible = False
        '
        'Button_Pressure
        '
        Me.Button_Pressure.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Button_Pressure.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button_Pressure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button_Pressure.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Pressure.Location = New System.Drawing.Point(161, 37)
        Me.Button_Pressure.Name = "Button_Pressure"
        Me.Button_Pressure.Size = New System.Drawing.Size(89, 28)
        Me.Button_Pressure.TabIndex = 19
        Me.Button_Pressure.Text = "P (mmHg)"
        Me.Button_Pressure.UseVisualStyleBackColor = False
        '
        'TextBox_Pressure
        '
        Me.TextBox_Pressure.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Pressure.Location = New System.Drawing.Point(175, 84)
        Me.TextBox_Pressure.Name = "TextBox_Pressure"
        Me.TextBox_Pressure.ReadOnly = True
        Me.TextBox_Pressure.Size = New System.Drawing.Size(53, 26)
        Me.TextBox_Pressure.TabIndex = 13
        Me.TextBox_Pressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button_Temperature
        '
        Me.Button_Temperature.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Button_Temperature.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button_Temperature.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button_Temperature.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button_Temperature.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Temperature.Location = New System.Drawing.Point(89, 37)
        Me.Button_Temperature.Name = "Button_Temperature"
        Me.Button_Temperature.Size = New System.Drawing.Size(66, 28)
        Me.Button_Temperature.TabIndex = 20
        Me.Button_Temperature.Text = "T ( °C)"
        Me.Button_Temperature.UseVisualStyleBackColor = False
        '
        'TextBox_Temperature
        '
        Me.TextBox_Temperature.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Temperature.Location = New System.Drawing.Point(98, 84)
        Me.TextBox_Temperature.Name = "TextBox_Temperature"
        Me.TextBox_Temperature.ReadOnly = True
        Me.TextBox_Temperature.Size = New System.Drawing.Size(53, 26)
        Me.TextBox_Temperature.TabIndex = 24
        Me.TextBox_Temperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel_Stability
        '
        Me.Panel_Stability.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel_Stability.Controls.Add(Me.GroupBox_Stability)
        Me.Panel_Stability.Location = New System.Drawing.Point(1, 225)
        Me.Panel_Stability.Name = "Panel_Stability"
        Me.Panel_Stability.Size = New System.Drawing.Size(1313, 420)
        Me.Panel_Stability.TabIndex = 25
        Me.Panel_Stability.Visible = False
        '
        'GroupBox_Stability
        '
        Me.GroupBox_Stability.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox_Stability.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.GroupBox_Stability.Controls.Add(Me.Label11)
        Me.GroupBox_Stability.Controls.Add(Me.Label12)
        Me.GroupBox_Stability.Controls.Add(Me.Label13)
        Me.GroupBox_Stability.Controls.Add(Me.Label14)
        Me.GroupBox_Stability.Controls.Add(Me.Label15)
        Me.GroupBox_Stability.Controls.Add(Me.Label16)
        Me.GroupBox_Stability.Controls.Add(Me.Label17)
        Me.GroupBox_Stability.Controls.Add(Me.Label18)
        Me.GroupBox_Stability.Controls.Add(Me.Label19)
        Me.GroupBox_Stability.Controls.Add(Me.Label20)
        Me.GroupBox_Stability.Controls.Add(Me.Label10)
        Me.GroupBox_Stability.Controls.Add(Me.Label9)
        Me.GroupBox_Stability.Controls.Add(Me.Label8)
        Me.GroupBox_Stability.Controls.Add(Me.Label7)
        Me.GroupBox_Stability.Controls.Add(Me.Label6)
        Me.GroupBox_Stability.Controls.Add(Me.Label5)
        Me.GroupBox_Stability.Controls.Add(Me.Label4)
        Me.GroupBox_Stability.Controls.Add(Me.Label3)
        Me.GroupBox_Stability.Controls.Add(Me.Label2)
        Me.GroupBox_Stability.Controls.Add(Me.Button_StabEnter)
        Me.GroupBox_Stability.Controls.Add(Me.Label1)
        Me.GroupBox_Stability.Controls.Add(Me.Button_Skip)
        Me.GroupBox_Stability.Controls.Add(Me.Label_StabInstructions)
        Me.GroupBox_Stability.Controls.Add(Me.TextBox_StabReading)
        Me.GroupBox_Stability.Controls.Add(Me.Label_StabHeader)
        Me.GroupBox_Stability.Location = New System.Drawing.Point(16, 34)
        Me.GroupBox_Stability.Name = "GroupBox_Stability"
        Me.GroupBox_Stability.Size = New System.Drawing.Size(1275, 278)
        Me.GroupBox_Stability.TabIndex = 15
        Me.GroupBox_Stability.TabStop = False
        Me.GroupBox_Stability.Visible = False
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(378, 185)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 26)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "11"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(453, 185)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 26)
        Me.Label12.TabIndex = 59
        Me.Label12.Text = "12"
        Me.Label12.Visible = False
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(537, 185)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 26)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "13"
        Me.Label13.Visible = False
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(619, 185)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 26)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "14"
        Me.Label14.Visible = False
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(705, 185)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 26)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "15"
        Me.Label15.Visible = False
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(789, 185)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 26)
        Me.Label16.TabIndex = 55
        Me.Label16.Text = "16"
        Me.Label16.Visible = False
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(879, 185)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 26)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "17"
        Me.Label17.Visible = False
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(959, 185)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(36, 26)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "18"
        Me.Label18.Visible = False
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(1039, 185)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(36, 26)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "19"
        Me.Label19.Visible = False
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(1122, 185)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(36, 26)
        Me.Label20.TabIndex = 51
        Me.Label20.Text = "20"
        Me.Label20.Visible = False
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1122, 138)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 26)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "10"
        Me.Label10.Visible = False
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1039, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 26)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "9"
        Me.Label9.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(959, 138)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 26)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "8"
        Me.Label8.Visible = False
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(879, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 26)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "7"
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(789, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 26)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "6"
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(705, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 26)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "5"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(619, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 26)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "4"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(537, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 26)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "3"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(453, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 26)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "2"
        Me.Label2.Visible = False
        '
        'Button_StabEnter
        '
        Me.Button_StabEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_StabEnter.Location = New System.Drawing.Point(181, 148)
        Me.Button_StabEnter.Name = "Button_StabEnter"
        Me.Button_StabEnter.Size = New System.Drawing.Size(95, 35)
        Me.Button_StabEnter.TabIndex = 41
        Me.Button_StabEnter.Text = "Enter"
        Me.Button_StabEnter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(378, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 26)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "1"
        Me.Label1.Visible = False
        '
        'Button_Skip
        '
        Me.Button_Skip.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button_Skip.AutoEllipsis = True
        Me.Button_Skip.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Skip.Location = New System.Drawing.Point(1152, 219)
        Me.Button_Skip.Name = "Button_Skip"
        Me.Button_Skip.Size = New System.Drawing.Size(99, 40)
        Me.Button_Skip.TabIndex = 39
        Me.Button_Skip.Text = "Skip"
        Me.Button_Skip.UseVisualStyleBackColor = True
        '
        'Label_StabInstructions
        '
        Me.Label_StabInstructions.AutoSize = True
        Me.Label_StabInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_StabInstructions.Location = New System.Drawing.Point(153, 67)
        Me.Label_StabInstructions.Name = "Label_StabInstructions"
        Me.Label_StabInstructions.Size = New System.Drawing.Size(870, 40)
        Me.Label_StabInstructions.TabIndex = 12
        Me.Label_StabInstructions.Text = resources.GetString("Label_StabInstructions.Text")
        '
        'TextBox_StabReading
        '
        Me.TextBox_StabReading.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_StabReading.Location = New System.Drawing.Point(66, 153)
        Me.TextBox_StabReading.Name = "TextBox_StabReading"
        Me.TextBox_StabReading.Size = New System.Drawing.Size(100, 26)
        Me.TextBox_StabReading.TabIndex = 2
        '
        'Label_StabHeader
        '
        Me.Label_StabHeader.AutoSize = True
        Me.Label_StabHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label_StabHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_StabHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_StabHeader.Location = New System.Drawing.Point(478, 17)
        Me.Label_StabHeader.Name = "Label_StabHeader"
        Me.Label_StabHeader.Size = New System.Drawing.Size(238, 27)
        Me.Label_StabHeader.TabIndex = 1
        Me.Label_StabHeader.Text = "Stability Measurements"
        '
        'Form_ScpData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1314, 697)
        Me.Controls.Add(Me.Panel_BottomSelections)
        Me.Controls.Add(Me.Panel_HeaderInfo)
        Me.Controls.Add(Me.Panel_Title)
        Me.Controls.Add(Me.Panel_Data)
        Me.Controls.Add(Me.Panel_Stability)
        Me.Name = "Form_ScpData"
        Me.Text = "Scp"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel_Title.ResumeLayout(False)
        Me.Panel_Title.PerformLayout()
        CType(Me.PictureBox_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_BottomSelections.ResumeLayout(False)
        Me.Panel_HeaderInfo.ResumeLayout(False)
        Me.Panel_HeaderInfo.PerformLayout()
        CType(Me.DataGridView_Factors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Data.ResumeLayout(False)
        Me.Panel_Data.PerformLayout()
        Me.Panel_Stability.ResumeLayout(False)
        Me.GroupBox_Stability.ResumeLayout(False)
        Me.GroupBox_Stability.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel_Title As System.Windows.Forms.Panel
    Friend WithEvents Label_Title As System.Windows.Forms.Label
    Friend WithEvents PictureBox_Logo As System.Windows.Forms.PictureBox
    Friend WithEvents Label_Electrometer As System.Windows.Forms.Label
    Friend WithEvents Label_Scanner As System.Windows.Forms.Label
    Friend WithEvents ComboBox_SmallFieldDetector As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Chamber As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Electrometer As System.Windows.Forms.ComboBox
    Friend WithEvents Panel_BottomSelections As System.Windows.Forms.Panel
    Friend WithEvents Button_Back As System.Windows.Forms.Button
    Friend WithEvents Panel_HeaderInfo As System.Windows.Forms.Panel
    Friend WithEvents ComboBox_Energy As System.Windows.Forms.ComboBox
    Friend WithEvents Label_SSD As System.Windows.Forms.Label
    Friend WithEvents Label_SetupSSD As System.Windows.Forms.Label
    Friend WithEvents Button_Exit As System.Windows.Forms.Button
    Friend WithEvents TextBox_ScpTolerance As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_ReadingsTolerance As System.Windows.Forms.TextBox
    Friend WithEvents Label_ScpTolerance As System.Windows.Forms.Label
    Friend WithEvents Label_ReadingsTolerance As System.Windows.Forms.Label
    Friend WithEvents Label_Tolerance As System.Windows.Forms.Label
    Friend WithEvents Label_FieldSize As System.Windows.Forms.Label
    Friend WithEvents Label_Reading1 As System.Windows.Forms.Label
    Friend WithEvents Label_Reading2 As System.Windows.Forms.Label
    Friend WithEvents TextBox_X As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Reading2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Average As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Y As System.Windows.Forms.TextBox
    Public WithEvents Label_X As System.Windows.Forms.Label
    Friend WithEvents Label_Y As System.Windows.Forms.Label
    Friend WithEvents Label_Average As System.Windows.Forms.Label
    Friend WithEvents Button_Select As System.Windows.Forms.Button
    Friend WithEvents DataGridView_Factors As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox_Reading1 As System.Windows.Forms.TextBox
    Friend WithEvents Label_SelectRowToEdit As System.Windows.Forms.Label
    Friend WithEvents Button_Edit As System.Windows.Forms.Button
    Friend WithEvents Button_Enter As System.Windows.Forms.Button
    Friend WithEvents Panel_Data As System.Windows.Forms.Panel
    Friend WithEvents TextBox_Pressure As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Temperature As System.Windows.Forms.TextBox
    Friend WithEvents Panel_Stability As System.Windows.Forms.Panel
    Friend WithEvents GroupBox_Stability As System.Windows.Forms.GroupBox
    Friend WithEvents Button_Skip As System.Windows.Forms.Button
    Friend WithEvents Label_StabInstructions As System.Windows.Forms.Label
    Friend WithEvents TextBox_StabReading As System.Windows.Forms.TextBox
    Friend WithEvents Label_StabHeader As System.Windows.Forms.Label
    Friend WithEvents Button_Pressure As System.Windows.Forms.Button
    Friend WithEvents Button_Temperature As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button_StabEnter As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label_DetectorSCD As System.Windows.Forms.Label
    Friend WithEvents Label_Detector As System.Windows.Forms.Label
    Friend WithEvents Label_SCD As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Scanner As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_Thermometer As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Thermometer As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Barometer As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
