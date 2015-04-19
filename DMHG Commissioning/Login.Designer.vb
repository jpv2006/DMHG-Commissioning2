<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Login))
        Me.Label_IncorrectUserPass = New System.Windows.Forms.Label()
        Me.Label_Login = New System.Windows.Forms.Label()
        Me.Label_Username = New System.Windows.Forms.Label()
        Me.TextBox_Username = New System.Windows.Forms.TextBox()
        Me.Label_Password = New System.Windows.Forms.Label()
        Me.TextBox_Password = New System.Windows.Forms.TextBox()
        Me.Button_Login = New System.Windows.Forms.Button()
        Me.Button_ExitLogin = New System.Windows.Forms.Button()
        Me.Button_Next = New System.Windows.Forms.Button()
        Me.Panel_Top = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel_Middle = New System.Windows.Forms.Panel()
        Me.Label_Server = New System.Windows.Forms.Label()
        Me.CheckBox_LocalServer = New System.Windows.Forms.CheckBox()
        Me.ComboBox_Linac = New System.Windows.Forms.ComboBox()
        Me.Label_Linac = New System.Windows.Forms.Label()
        Me.RadioButton_AnnualQA = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Commissioning = New System.Windows.Forms.RadioButton()
        Me.Label_DatabaseConnection = New System.Windows.Forms.Label()
        Me.Panel_Bottom = New System.Windows.Forms.Panel()
        Me.Label_Existing = New System.Windows.Forms.Label()
        Me.ComboBox_Existing = New System.Windows.Forms.ComboBox()
        Me.Label_LoginName = New System.Windows.Forms.Label()
        Me.Label_LoggedInAs = New System.Windows.Forms.Label()
        Me.Button_NewSite = New System.Windows.Forms.Button()
        Me.Button_Logout = New System.Windows.Forms.Button()
        Me.Panel_Top.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Middle.SuspendLayout()
        Me.Panel_Bottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label_IncorrectUserPass
        '
        Me.Label_IncorrectUserPass.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label_IncorrectUserPass.AutoSize = True
        Me.Label_IncorrectUserPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_IncorrectUserPass.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label_IncorrectUserPass.Location = New System.Drawing.Point(255, 57)
        Me.Label_IncorrectUserPass.Name = "Label_IncorrectUserPass"
        Me.Label_IncorrectUserPass.Size = New System.Drawing.Size(822, 55)
        Me.Label_IncorrectUserPass.TabIndex = 16
        Me.Label_IncorrectUserPass.Text = "Incorrect Username and/or Password"
        Me.Label_IncorrectUserPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label_IncorrectUserPass.Visible = False
        '
        'Label_Login
        '
        Me.Label_Login.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label_Login.AutoSize = True
        Me.Label_Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Login.ForeColor = System.Drawing.Color.DimGray
        Me.Label_Login.Location = New System.Drawing.Point(506, 57)
        Me.Label_Login.Name = "Label_Login"
        Me.Label_Login.Size = New System.Drawing.Size(302, 55)
        Me.Label_Login.TabIndex = 17
        Me.Label_Login.Text = "Please Login"
        Me.Label_Login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Username
        '
        Me.Label_Username.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label_Username.AutoSize = True
        Me.Label_Username.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Username.Location = New System.Drawing.Point(84, 213)
        Me.Label_Username.Name = "Label_Username"
        Me.Label_Username.Size = New System.Drawing.Size(116, 25)
        Me.Label_Username.TabIndex = 23
        Me.Label_Username.Text = "Username:"
        '
        'TextBox_Username
        '
        Me.TextBox_Username.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TextBox_Username.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Username.Location = New System.Drawing.Point(228, 207)
        Me.TextBox_Username.MaxLength = 16
        Me.TextBox_Username.Name = "TextBox_Username"
        Me.TextBox_Username.Size = New System.Drawing.Size(284, 31)
        Me.TextBox_Username.TabIndex = 24
        '
        'Label_Password
        '
        Me.Label_Password.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label_Password.AutoSize = True
        Me.Label_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Password.Location = New System.Drawing.Point(602, 213)
        Me.Label_Password.Name = "Label_Password"
        Me.Label_Password.Size = New System.Drawing.Size(112, 25)
        Me.Label_Password.TabIndex = 25
        Me.Label_Password.Text = "Password:"
        '
        'TextBox_Password
        '
        Me.TextBox_Password.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TextBox_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Password.Location = New System.Drawing.Point(734, 207)
        Me.TextBox_Password.MaxLength = 16
        Me.TextBox_Password.Name = "TextBox_Password"
        Me.TextBox_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Password.Size = New System.Drawing.Size(272, 31)
        Me.TextBox_Password.TabIndex = 26
        '
        'Button_Login
        '
        Me.Button_Login.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button_Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Login.Location = New System.Drawing.Point(1097, 191)
        Me.Button_Login.MaximumSize = New System.Drawing.Size(126, 47)
        Me.Button_Login.Name = "Button_Login"
        Me.Button_Login.Size = New System.Drawing.Size(126, 47)
        Me.Button_Login.TabIndex = 28
        Me.Button_Login.Text = "Login"
        Me.Button_Login.UseVisualStyleBackColor = True
        '
        'Button_ExitLogin
        '
        Me.Button_ExitLogin.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button_ExitLogin.AutoSize = True
        Me.Button_ExitLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_ExitLogin.Location = New System.Drawing.Point(37, 3)
        Me.Button_ExitLogin.Name = "Button_ExitLogin"
        Me.Button_ExitLogin.Size = New System.Drawing.Size(100, 46)
        Me.Button_ExitLogin.TabIndex = 30
        Me.Button_ExitLogin.Text = "Exit"
        Me.Button_ExitLogin.UseVisualStyleBackColor = True
        '
        'Button_Next
        '
        Me.Button_Next.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button_Next.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Next.Location = New System.Drawing.Point(1161, 5)
        Me.Button_Next.Margin = New System.Windows.Forms.Padding(899, 3, 3, 3)
        Me.Button_Next.Name = "Button_Next"
        Me.Button_Next.Size = New System.Drawing.Size(100, 36)
        Me.Button_Next.TabIndex = 31
        Me.Button_Next.Text = "Next"
        Me.Button_Next.UseVisualStyleBackColor = True
        Me.Button_Next.Visible = False
        '
        'Panel_Top
        '
        Me.Panel_Top.Controls.Add(Me.PictureBox1)
        Me.Panel_Top.Controls.Add(Me.Label1)
        Me.Panel_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Top.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Top.Name = "Panel_Top"
        Me.Panel_Top.Size = New System.Drawing.Size(1314, 95)
        Me.Panel_Top.TabIndex = 32
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(213, 95)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(252, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(807, 55)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Welcome to DMHG Commissioning"
        '
        'Panel_Middle
        '
        Me.Panel_Middle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel_Middle.Controls.Add(Me.Label_Server)
        Me.Panel_Middle.Controls.Add(Me.CheckBox_LocalServer)
        Me.Panel_Middle.Controls.Add(Me.ComboBox_Linac)
        Me.Panel_Middle.Controls.Add(Me.Label_Linac)
        Me.Panel_Middle.Controls.Add(Me.RadioButton_AnnualQA)
        Me.Panel_Middle.Controls.Add(Me.RadioButton_Commissioning)
        Me.Panel_Middle.Controls.Add(Me.Label_DatabaseConnection)
        Me.Panel_Middle.Controls.Add(Me.Panel_Bottom)
        Me.Panel_Middle.Controls.Add(Me.Label_Existing)
        Me.Panel_Middle.Controls.Add(Me.ComboBox_Existing)
        Me.Panel_Middle.Controls.Add(Me.Label_LoginName)
        Me.Panel_Middle.Controls.Add(Me.Label_LoggedInAs)
        Me.Panel_Middle.Controls.Add(Me.Button_NewSite)
        Me.Panel_Middle.Controls.Add(Me.TextBox_Password)
        Me.Panel_Middle.Controls.Add(Me.Label_Login)
        Me.Panel_Middle.Controls.Add(Me.Label_Password)
        Me.Panel_Middle.Controls.Add(Me.Label_IncorrectUserPass)
        Me.Panel_Middle.Controls.Add(Me.TextBox_Username)
        Me.Panel_Middle.Controls.Add(Me.Label_Username)
        Me.Panel_Middle.Controls.Add(Me.Button_Login)
        Me.Panel_Middle.Controls.Add(Me.Button_Logout)
        Me.Panel_Middle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Middle.Location = New System.Drawing.Point(0, 95)
        Me.Panel_Middle.Name = "Panel_Middle"
        Me.Panel_Middle.Size = New System.Drawing.Size(1314, 656)
        Me.Panel_Middle.TabIndex = 33
        '
        'Label_Server
        '
        Me.Label_Server.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label_Server.AutoSize = True
        Me.Label_Server.Location = New System.Drawing.Point(88, 155)
        Me.Label_Server.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label_Server.Name = "Label_Server"
        Me.Label_Server.Size = New System.Drawing.Size(39, 13)
        Me.Label_Server.TabIndex = 49
        Me.Label_Server.Text = "Label2"
        '
        'CheckBox_LocalServer
        '
        Me.CheckBox_LocalServer.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.CheckBox_LocalServer.AutoSize = True
        Me.CheckBox_LocalServer.Location = New System.Drawing.Point(88, 133)
        Me.CheckBox_LocalServer.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox_LocalServer.Name = "CheckBox_LocalServer"
        Me.CheckBox_LocalServer.Size = New System.Drawing.Size(108, 17)
        Me.CheckBox_LocalServer.TabIndex = 48
        Me.CheckBox_LocalServer.Text = "Use Local Server"
        Me.CheckBox_LocalServer.UseVisualStyleBackColor = True
        '
        'ComboBox_Linac
        '
        Me.ComboBox_Linac.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ComboBox_Linac.Enabled = False
        Me.ComboBox_Linac.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_Linac.FormattingEnabled = True
        Me.ComboBox_Linac.Location = New System.Drawing.Point(1055, 476)
        Me.ComboBox_Linac.Name = "ComboBox_Linac"
        Me.ComboBox_Linac.Size = New System.Drawing.Size(234, 33)
        Me.ComboBox_Linac.TabIndex = 47
        Me.ComboBox_Linac.Visible = False
        '
        'Label_Linac
        '
        Me.Label_Linac.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label_Linac.AutoSize = True
        Me.Label_Linac.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Linac.Location = New System.Drawing.Point(979, 479)
        Me.Label_Linac.Name = "Label_Linac"
        Me.Label_Linac.Size = New System.Drawing.Size(70, 25)
        Me.Label_Linac.TabIndex = 44
        Me.Label_Linac.Text = "Linac:"
        Me.Label_Linac.Visible = False
        '
        'RadioButton_AnnualQA
        '
        Me.RadioButton_AnnualQA.AutoSize = True
        Me.RadioButton_AnnualQA.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_AnnualQA.Location = New System.Drawing.Point(1097, 335)
        Me.RadioButton_AnnualQA.Name = "RadioButton_AnnualQA"
        Me.RadioButton_AnnualQA.Size = New System.Drawing.Size(133, 29)
        Me.RadioButton_AnnualQA.TabIndex = 43
        Me.RadioButton_AnnualQA.TabStop = True
        Me.RadioButton_AnnualQA.Text = "Annual QA"
        Me.RadioButton_AnnualQA.UseVisualStyleBackColor = True
        Me.RadioButton_AnnualQA.Visible = False
        '
        'RadioButton_Commissioning
        '
        Me.RadioButton_Commissioning.AutoSize = True
        Me.RadioButton_Commissioning.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_Commissioning.Location = New System.Drawing.Point(887, 335)
        Me.RadioButton_Commissioning.Name = "RadioButton_Commissioning"
        Me.RadioButton_Commissioning.Size = New System.Drawing.Size(176, 29)
        Me.RadioButton_Commissioning.TabIndex = 42
        Me.RadioButton_Commissioning.TabStop = True
        Me.RadioButton_Commissioning.Text = "Commissioning"
        Me.RadioButton_Commissioning.UseVisualStyleBackColor = True
        Me.RadioButton_Commissioning.Visible = False
        '
        'Label_DatabaseConnection
        '
        Me.Label_DatabaseConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_DatabaseConnection.AutoSize = True
        Me.Label_DatabaseConnection.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Label_DatabaseConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_DatabaseConnection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_DatabaseConnection.ForeColor = System.Drawing.Color.Black
        Me.Label_DatabaseConnection.Location = New System.Drawing.Point(1123, 569)
        Me.Label_DatabaseConnection.Name = "Label_DatabaseConnection"
        Me.Label_DatabaseConnection.Size = New System.Drawing.Size(166, 22)
        Me.Label_DatabaseConnection.TabIndex = 37
        Me.Label_DatabaseConnection.Text = "Database Connection"
        Me.Label_DatabaseConnection.Visible = False
        '
        'Panel_Bottom
        '
        Me.Panel_Bottom.Controls.Add(Me.Button_ExitLogin)
        Me.Panel_Bottom.Controls.Add(Me.Button_Next)
        Me.Panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel_Bottom.Location = New System.Drawing.Point(0, 610)
        Me.Panel_Bottom.Name = "Panel_Bottom"
        Me.Panel_Bottom.Size = New System.Drawing.Size(1314, 46)
        Me.Panel_Bottom.TabIndex = 36
        '
        'Label_Existing
        '
        Me.Label_Existing.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label_Existing.AutoSize = True
        Me.Label_Existing.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Existing.Location = New System.Drawing.Point(375, 479)
        Me.Label_Existing.Name = "Label_Existing"
        Me.Label_Existing.Size = New System.Drawing.Size(137, 25)
        Me.Label_Existing.TabIndex = 35
        Me.Label_Existing.Text = "Existing Site:"
        Me.Label_Existing.Visible = False
        '
        'ComboBox_Existing
        '
        Me.ComboBox_Existing.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ComboBox_Existing.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_Existing.FormattingEnabled = True
        Me.ComboBox_Existing.Location = New System.Drawing.Point(515, 476)
        Me.ComboBox_Existing.Name = "ComboBox_Existing"
        Me.ComboBox_Existing.Size = New System.Drawing.Size(443, 33)
        Me.ComboBox_Existing.TabIndex = 34
        Me.ComboBox_Existing.Visible = False
        '
        'Label_LoginName
        '
        Me.Label_LoginName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label_LoginName.AutoSize = True
        Me.Label_LoginName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LoginName.Location = New System.Drawing.Point(260, 337)
        Me.Label_LoginName.Name = "Label_LoginName"
        Me.Label_LoginName.Size = New System.Drawing.Size(127, 25)
        Me.Label_LoginName.TabIndex = 33
        Me.Label_LoginName.Text = "Login Name"
        Me.Label_LoginName.Visible = False
        '
        'Label_LoggedInAs
        '
        Me.Label_LoggedInAs.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label_LoggedInAs.AutoSize = True
        Me.Label_LoggedInAs.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LoggedInAs.Location = New System.Drawing.Point(84, 337)
        Me.Label_LoggedInAs.Name = "Label_LoggedInAs"
        Me.Label_LoggedInAs.Size = New System.Drawing.Size(142, 25)
        Me.Label_LoggedInAs.TabIndex = 32
        Me.Label_LoggedInAs.Text = "Logged in as:"
        Me.Label_LoggedInAs.Visible = False
        '
        'Button_NewSite
        '
        Me.Button_NewSite.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button_NewSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_NewSite.Location = New System.Drawing.Point(89, 473)
        Me.Button_NewSite.MaximumSize = New System.Drawing.Size(136, 37)
        Me.Button_NewSite.Name = "Button_NewSite"
        Me.Button_NewSite.Size = New System.Drawing.Size(136, 37)
        Me.Button_NewSite.TabIndex = 30
        Me.Button_NewSite.Text = "New Site"
        Me.Button_NewSite.UseVisualStyleBackColor = True
        Me.Button_NewSite.Visible = False
        '
        'Button_Logout
        '
        Me.Button_Logout.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button_Logout.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Logout.Location = New System.Drawing.Point(1097, 191)
        Me.Button_Logout.MaximumSize = New System.Drawing.Size(126, 47)
        Me.Button_Logout.Name = "Button_Logout"
        Me.Button_Logout.Size = New System.Drawing.Size(126, 47)
        Me.Button_Logout.TabIndex = 39
        Me.Button_Logout.Text = "Log Out"
        Me.Button_Logout.UseVisualStyleBackColor = True
        Me.Button_Logout.Visible = False
        '
        'Form_Login
        '
        Me.AcceptButton = Me.Button_Login
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1314, 751)
        Me.Controls.Add(Me.Panel_Middle)
        Me.Controls.Add(Me.Panel_Top)
        Me.IsMdiContainer = True
        Me.Name = "Form_Login"
        Me.Text = "Login"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel_Top.ResumeLayout(False)
        Me.Panel_Top.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Middle.ResumeLayout(False)
        Me.Panel_Middle.PerformLayout()
        Me.Panel_Bottom.ResumeLayout(False)
        Me.Panel_Bottom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label_IncorrectUserPass As System.Windows.Forms.Label
    Friend WithEvents Label_Username As System.Windows.Forms.Label
    Friend WithEvents TextBox_Username As System.Windows.Forms.TextBox
    Friend WithEvents Label_Password As System.Windows.Forms.Label
    Friend WithEvents TextBox_Password As System.Windows.Forms.TextBox
    Friend WithEvents Button_Login As System.Windows.Forms.Button
    Friend WithEvents Button_ExitLogin As System.Windows.Forms.Button
    Friend WithEvents Panel_Top As System.Windows.Forms.Panel
    Friend WithEvents Panel_Middle As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label_LoginName As System.Windows.Forms.Label
    Friend WithEvents Label_LoggedInAs As System.Windows.Forms.Label
    Friend WithEvents Button_NewSite As System.Windows.Forms.Button
    Friend WithEvents Button_Next As System.Windows.Forms.Button
    Friend WithEvents ComboBox_Existing As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Existing As System.Windows.Forms.Label
    Friend WithEvents Label_Login As System.Windows.Forms.Label
    Friend WithEvents Panel_Bottom As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label_DatabaseConnection As System.Windows.Forms.Label
    Friend WithEvents Button_Logout As System.Windows.Forms.Button
    Friend WithEvents RadioButton_AnnualQA As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton_Commissioning As System.Windows.Forms.RadioButton
    Friend WithEvents Label_Linac As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Linac As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox_LocalServer As System.Windows.Forms.CheckBox
    Friend WithEvents Label_Server As System.Windows.Forms.Label
End Class
