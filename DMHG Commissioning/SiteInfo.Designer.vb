<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_SiteInfo
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
        Me.Button_Back = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button_StartContinue = New System.Windows.Forms.Button()
        Me.Button_Exit = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label_Username = New System.Windows.Forms.Label()
        Me.Username = New System.Windows.Forms.Label()
        Me.Label_LinacModel = New System.Windows.Forms.Label()
        Me.Label_Serial = New System.Windows.Forms.Label()
        Me.Label_PhotonEnergies = New System.Windows.Forms.Label()
        Me.Label_ElectronEnergies = New System.Windows.Forms.Label()
        Me.Label_RTPSystems = New System.Windows.Forms.Label()
        Me.Label_SiteName = New System.Windows.Forms.Label()
        Me.SiteName = New System.Windows.Forms.Label()
        Me.LinacModel = New System.Windows.Forms.Label()
        Me.Serial = New System.Windows.Forms.Label()
        Me.PhotonEnergies = New System.Windows.Forms.Label()
        Me.ElectronEnergies = New System.Windows.Forms.Label()
        Me.RTPSystems = New System.Windows.Forms.Label()
        Me.Button_EditSiteData = New System.Windows.Forms.Button()
        Me.Button_Configuration = New System.Windows.Forms.Button()
        Me.Button_ImportExport = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button_ImportDatabase = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Back
        '
        Me.Button_Back.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button_Back.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Back.Location = New System.Drawing.Point(35, 2)
        Me.Button_Back.Name = "Button_Back"
        Me.Button_Back.Size = New System.Drawing.Size(100, 39)
        Me.Button_Back.TabIndex = 0
        Me.Button_Back.Text = "Back"
        Me.Button_Back.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button_StartContinue)
        Me.Panel1.Controls.Add(Me.Button_Exit)
        Me.Panel1.Controls.Add(Me.Button_Back)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 798)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1443, 45)
        Me.Panel1.TabIndex = 1
        '
        'Button_StartContinue
        '
        Me.Button_StartContinue.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button_StartContinue.Enabled = False
        Me.Button_StartContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_StartContinue.Location = New System.Drawing.Point(569, 3)
        Me.Button_StartContinue.Name = "Button_StartContinue"
        Me.Button_StartContinue.Size = New System.Drawing.Size(348, 39)
        Me.Button_StartContinue.TabIndex = 1
        Me.Button_StartContinue.Text = "Start/Continue Data Collection"
        Me.Button_StartContinue.UseVisualStyleBackColor = True
        '
        'Button_Exit
        '
        Me.Button_Exit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button_Exit.AutoEllipsis = True
        Me.Button_Exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Exit.Location = New System.Drawing.Point(1299, 2)
        Me.Button_Exit.Name = "Button_Exit"
        Me.Button_Exit.Size = New System.Drawing.Size(99, 40)
        Me.Button_Exit.TabIndex = 11
        Me.Button_Exit.Text = "Exit"
        Me.Button_Exit.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label_Username)
        Me.Panel2.Controls.Add(Me.Username)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1443, 91)
        Me.Panel2.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Book Antiqua", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(531, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(495, 51)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "DMHG Commissioning"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.DMHG_Commissioning.My.Resources.Resources.DMHG_Logo_small
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(231, 89)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label_Username
        '
        Me.Label_Username.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_Username.AutoSize = True
        Me.Label_Username.Font = New System.Drawing.Font("Times New Roman", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Username.Location = New System.Drawing.Point(1115, 36)
        Me.Label_Username.Name = "Label_Username"
        Me.Label_Username.Size = New System.Drawing.Size(139, 25)
        Me.Label_Username.TabIndex = 27
        Me.Label_Username.Text = "Logged in as:"
        Me.Label_Username.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Username
        '
        Me.Username.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Username.AutoSize = True
        Me.Username.Font = New System.Drawing.Font("Times New Roman", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Username.Location = New System.Drawing.Point(1253, 37)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(64, 25)
        Me.Username.TabIndex = 28
        Me.Username.Text = "Name"
        Me.Username.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label_LinacModel
        '
        Me.Label_LinacModel.AutoSize = True
        Me.Label_LinacModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LinacModel.Location = New System.Drawing.Point(44, 171)
        Me.Label_LinacModel.Name = "Label_LinacModel"
        Me.Label_LinacModel.Size = New System.Drawing.Size(174, 25)
        Me.Label_LinacModel.TabIndex = 3
        Me.Label_LinacModel.Text = "Model of Linac:"
        '
        'Label_Serial
        '
        Me.Label_Serial.AutoSize = True
        Me.Label_Serial.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Serial.Location = New System.Drawing.Point(422, 171)
        Me.Label_Serial.Name = "Label_Serial"
        Me.Label_Serial.Size = New System.Drawing.Size(168, 25)
        Me.Label_Serial.TabIndex = 5
        Me.Label_Serial.Text = "Serial Number:"
        '
        'Label_PhotonEnergies
        '
        Me.Label_PhotonEnergies.AutoSize = True
        Me.Label_PhotonEnergies.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PhotonEnergies.Location = New System.Drawing.Point(44, 240)
        Me.Label_PhotonEnergies.Name = "Label_PhotonEnergies"
        Me.Label_PhotonEnergies.Size = New System.Drawing.Size(193, 25)
        Me.Label_PhotonEnergies.TabIndex = 7
        Me.Label_PhotonEnergies.Text = "Photon Energies:"
        '
        'Label_ElectronEnergies
        '
        Me.Label_ElectronEnergies.AutoSize = True
        Me.Label_ElectronEnergies.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ElectronEnergies.Location = New System.Drawing.Point(44, 306)
        Me.Label_ElectronEnergies.Name = "Label_ElectronEnergies"
        Me.Label_ElectronEnergies.Size = New System.Drawing.Size(206, 25)
        Me.Label_ElectronEnergies.TabIndex = 15
        Me.Label_ElectronEnergies.Text = "Electron Energies:"
        '
        'Label_RTPSystems
        '
        Me.Label_RTPSystems.AutoSize = True
        Me.Label_RTPSystems.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_RTPSystems.Location = New System.Drawing.Point(44, 370)
        Me.Label_RTPSystems.Name = "Label_RTPSystems"
        Me.Label_RTPSystems.Size = New System.Drawing.Size(160, 25)
        Me.Label_RTPSystems.TabIndex = 25
        Me.Label_RTPSystems.Text = "RTP Systems:"
        '
        'Label_SiteName
        '
        Me.Label_SiteName.AutoSize = True
        Me.Label_SiteName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_SiteName.Location = New System.Drawing.Point(44, 107)
        Me.Label_SiteName.Name = "Label_SiteName"
        Me.Label_SiteName.Size = New System.Drawing.Size(127, 25)
        Me.Label_SiteName.TabIndex = 1
        Me.Label_SiteName.Text = "Site Name:"
        '
        'SiteName
        '
        Me.SiteName.AutoSize = True
        Me.SiteName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SiteName.Location = New System.Drawing.Point(256, 107)
        Me.SiteName.Name = "SiteName"
        Me.SiteName.Size = New System.Drawing.Size(111, 25)
        Me.SiteName.TabIndex = 29
        Me.SiteName.Text = "Site Name"
        '
        'LinacModel
        '
        Me.LinacModel.AutoSize = True
        Me.LinacModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinacModel.Location = New System.Drawing.Point(256, 171)
        Me.LinacModel.Name = "LinacModel"
        Me.LinacModel.Size = New System.Drawing.Size(129, 25)
        Me.LinacModel.TabIndex = 30
        Me.LinacModel.Text = "Linac Model"
        '
        'Serial
        '
        Me.Serial.AutoSize = True
        Me.Serial.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial.Location = New System.Drawing.Point(592, 171)
        Me.Serial.Name = "Serial"
        Me.Serial.Size = New System.Drawing.Size(85, 25)
        Me.Serial.TabIndex = 31
        Me.Serial.Text = "Serial #"
        '
        'PhotonEnergies
        '
        Me.PhotonEnergies.AutoSize = True
        Me.PhotonEnergies.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PhotonEnergies.Location = New System.Drawing.Point(256, 240)
        Me.PhotonEnergies.Name = "PhotonEnergies"
        Me.PhotonEnergies.Size = New System.Drawing.Size(171, 25)
        Me.PhotonEnergies.TabIndex = 32
        Me.PhotonEnergies.Text = "Photon Energies"
        '
        'ElectronEnergies
        '
        Me.ElectronEnergies.AutoSize = True
        Me.ElectronEnergies.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElectronEnergies.Location = New System.Drawing.Point(256, 306)
        Me.ElectronEnergies.Name = "ElectronEnergies"
        Me.ElectronEnergies.Size = New System.Drawing.Size(182, 25)
        Me.ElectronEnergies.TabIndex = 33
        Me.ElectronEnergies.Text = "Electron Energies"
        '
        'RTPSystems
        '
        Me.RTPSystems.AutoSize = True
        Me.RTPSystems.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTPSystems.Location = New System.Drawing.Point(256, 370)
        Me.RTPSystems.Name = "RTPSystems"
        Me.RTPSystems.Size = New System.Drawing.Size(131, 25)
        Me.RTPSystems.TabIndex = 34
        Me.RTPSystems.Text = "RTP System"
        '
        'Button_EditSiteData
        '
        Me.Button_EditSiteData.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_EditSiteData.Location = New System.Drawing.Point(49, 439)
        Me.Button_EditSiteData.Name = "Button_EditSiteData"
        Me.Button_EditSiteData.Size = New System.Drawing.Size(171, 37)
        Me.Button_EditSiteData.TabIndex = 35
        Me.Button_EditSiteData.Text = "Edit Site Data"
        Me.Button_EditSiteData.UseVisualStyleBackColor = True
        '
        'Button_Configuration
        '
        Me.Button_Configuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Configuration.Location = New System.Drawing.Point(49, 518)
        Me.Button_Configuration.Name = "Button_Configuration"
        Me.Button_Configuration.Size = New System.Drawing.Size(444, 37)
        Me.Button_Configuration.TabIndex = 36
        Me.Button_Configuration.Text = "Create Tables for Configuration Selected"
        Me.Button_Configuration.UseVisualStyleBackColor = True
        '
        'Button_ImportExport
        '
        Me.Button_ImportExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_ImportExport.ForeColor = System.Drawing.Color.Maroon
        Me.Button_ImportExport.Location = New System.Drawing.Point(64, 124)
        Me.Button_ImportExport.Name = "Button_ImportExport"
        Me.Button_ImportExport.Size = New System.Drawing.Size(259, 79)
        Me.Button_ImportExport.TabIndex = 37
        Me.Button_ImportExport.Text = "Import 3DS Export Files"
        Me.Button_ImportExport.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Button_ImportDatabase)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Button_ImportExport)
        Me.Panel3.Location = New System.Drawing.Point(1000, 159)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(384, 471)
        Me.Panel3.TabIndex = 38
        '
        'Button_ImportDatabase
        '
        Me.Button_ImportDatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_ImportDatabase.ForeColor = System.Drawing.Color.Maroon
        Me.Button_ImportDatabase.Location = New System.Drawing.Point(64, 297)
        Me.Button_ImportDatabase.Name = "Button_ImportDatabase"
        Me.Button_ImportDatabase.Size = New System.Drawing.Size(259, 79)
        Me.Button_ImportDatabase.TabIndex = 40
        Me.Button_ImportDatabase.Text = "Import 3DS Database Files"
        Me.Button_ImportDatabase.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Book Antiqua", 24.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(72, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 38)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "3DS Data Import"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label_SiteName)
        Me.Panel4.Controls.Add(Me.Label_LinacModel)
        Me.Panel4.Controls.Add(Me.Button_Configuration)
        Me.Panel4.Controls.Add(Me.Label_Serial)
        Me.Panel4.Controls.Add(Me.Button_EditSiteData)
        Me.Panel4.Controls.Add(Me.Label_PhotonEnergies)
        Me.Panel4.Controls.Add(Me.RTPSystems)
        Me.Panel4.Controls.Add(Me.Label_ElectronEnergies)
        Me.Panel4.Controls.Add(Me.ElectronEnergies)
        Me.Panel4.Controls.Add(Me.Label_RTPSystems)
        Me.Panel4.Controls.Add(Me.PhotonEnergies)
        Me.Panel4.Controls.Add(Me.Serial)
        Me.Panel4.Controls.Add(Me.LinacModel)
        Me.Panel4.Controls.Add(Me.SiteName)
        Me.Panel4.Location = New System.Drawing.Point(57, 117)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(735, 609)
        Me.Panel4.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Book Antiqua", 24.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(274, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 38)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Linac Data"
        '
        'Form_SiteInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1443, 843)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Form_SiteInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Site Information"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button_Back As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button_StartContinue As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label_LinacModel As System.Windows.Forms.Label
    Friend WithEvents Label_Serial As System.Windows.Forms.Label
    Friend WithEvents Label_PhotonEnergies As System.Windows.Forms.Label
    Friend WithEvents Label_ElectronEnergies As System.Windows.Forms.Label
    Friend WithEvents Label_RTPSystems As System.Windows.Forms.Label
    Friend WithEvents Label_SiteName As System.Windows.Forms.Label
    Friend WithEvents Button_Exit As System.Windows.Forms.Button
    Friend WithEvents Label_Username As System.Windows.Forms.Label
    Friend WithEvents Username As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SiteName As System.Windows.Forms.Label
    Friend WithEvents LinacModel As System.Windows.Forms.Label
    Friend WithEvents Serial As System.Windows.Forms.Label
    Friend WithEvents PhotonEnergies As System.Windows.Forms.Label
    Friend WithEvents ElectronEnergies As System.Windows.Forms.Label
    Friend WithEvents RTPSystems As System.Windows.Forms.Label
    Friend WithEvents Button_EditSiteData As System.Windows.Forms.Button
    Friend WithEvents Button_Configuration As System.Windows.Forms.Button
    Friend WithEvents Button_ImportExport As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button_ImportDatabase As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
