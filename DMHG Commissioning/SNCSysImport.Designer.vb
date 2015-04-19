<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SNCSysImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SNCSysImport))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button_Back = New System.Windows.Forms.Button()
        Me.TextBox_SNCTableLoc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_BrowseLoc = New System.Windows.Forms.Button()
        Me.Button_LoadTables = New System.Windows.Forms.Button()
        Me.NamingExampleText = New System.Windows.Forms.RichTextBox()
        Me.Label_TablesLoaded = New System.Windows.Forms.Label()
        Me.TreeView_PDD = New System.Windows.Forms.TreeView()
        Me.TreeView_Profiles = New System.Windows.Forms.TreeView()
        Me.TreeView_TMR = New System.Windows.Forms.TreeView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel_TreeViews = New System.Windows.Forms.Panel()
        Me.Button_Import = New System.Windows.Forms.Button()
        Me.ProgressBar_TableLoad = New System.Windows.Forms.ProgressBar()
        Me.Label_TableImportsSucceeded = New System.Windows.Forms.Label()
        Me.Label_TableImportsFailed = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel_TreeViews.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1752, 111)
        Me.Panel2.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(631, 23)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(596, 63)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "DMHG Commissioning"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.DMHG_Commissioning.My.Resources.Resources.DMHG_Logo_small
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(308, 111)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button_Back)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 728)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1752, 55)
        Me.Panel1.TabIndex = 4
        '
        'Button_Back
        '
        Me.Button_Back.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button_Back.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Back.Location = New System.Drawing.Point(47, 4)
        Me.Button_Back.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_Back.Name = "Button_Back"
        Me.Button_Back.Size = New System.Drawing.Size(133, 48)
        Me.Button_Back.TabIndex = 0
        Me.Button_Back.Text = "Back"
        Me.Button_Back.UseVisualStyleBackColor = True
        '
        'TextBox_SNCTableLoc
        '
        Me.TextBox_SNCTableLoc.Location = New System.Drawing.Point(115, 153)
        Me.TextBox_SNCTableLoc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_SNCTableLoc.Name = "TextBox_SNCTableLoc"
        Me.TextBox_SNCTableLoc.Size = New System.Drawing.Size(307, 22)
        Me.TextBox_SNCTableLoc.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(111, 133)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 18)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Folder Containing SNC System Data Tables"
        '
        'Button_BrowseLoc
        '
        Me.Button_BrowseLoc.Location = New System.Drawing.Point(440, 153)
        Me.Button_BrowseLoc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_BrowseLoc.Name = "Button_BrowseLoc"
        Me.Button_BrowseLoc.Size = New System.Drawing.Size(116, 23)
        Me.Button_BrowseLoc.TabIndex = 6
        Me.Button_BrowseLoc.Text = "Browse"
        Me.Button_BrowseLoc.UseVisualStyleBackColor = True
        '
        'Button_LoadTables
        '
        Me.Button_LoadTables.Location = New System.Drawing.Point(115, 185)
        Me.Button_LoadTables.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_LoadTables.Name = "Button_LoadTables"
        Me.Button_LoadTables.Size = New System.Drawing.Size(163, 23)
        Me.Button_LoadTables.TabIndex = 7
        Me.Button_LoadTables.Text = "Load Tables"
        Me.Button_LoadTables.UseVisualStyleBackColor = True
        '
        'NamingExampleText
        '
        Me.NamingExampleText.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.NamingExampleText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NamingExampleText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.15!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NamingExampleText.Location = New System.Drawing.Point(668, 118)
        Me.NamingExampleText.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NamingExampleText.Name = "NamingExampleText"
        Me.NamingExampleText.Size = New System.Drawing.Size(536, 196)
        Me.NamingExampleText.TabIndex = 8
        Me.NamingExampleText.Text = resources.GetString("NamingExampleText.Text")
        '
        'Label_TablesLoaded
        '
        Me.Label_TablesLoaded.AutoSize = True
        Me.Label_TablesLoaded.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_TablesLoaded.Location = New System.Drawing.Point(111, 22)
        Me.Label_TablesLoaded.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_TablesLoaded.Name = "Label_TablesLoaded"
        Me.Label_TablesLoaded.Size = New System.Drawing.Size(132, 20)
        Me.Label_TablesLoaded.TabIndex = 9
        Me.Label_TablesLoaded.Text = "Tables Loaded"
        '
        'TreeView_PDD
        '
        Me.TreeView_PDD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeView_PDD.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TreeView_PDD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView_PDD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView_PDD.Location = New System.Drawing.Point(68, 46)
        Me.TreeView_PDD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TreeView_PDD.Name = "TreeView_PDD"
        Me.TreeView_PDD.Size = New System.Drawing.Size(466, 301)
        Me.TreeView_PDD.TabIndex = 10
        '
        'TreeView_Profiles
        '
        Me.TreeView_Profiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TreeView_Profiles.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TreeView_Profiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView_Profiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView_Profiles.Location = New System.Drawing.Point(637, 46)
        Me.TreeView_Profiles.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TreeView_Profiles.Name = "TreeView_Profiles"
        Me.TreeView_Profiles.Size = New System.Drawing.Size(466, 301)
        Me.TreeView_Profiles.TabIndex = 11
        '
        'TreeView_TMR
        '
        Me.TreeView_TMR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView_TMR.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TreeView_TMR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView_TMR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView_TMR.Location = New System.Drawing.Point(1205, 46)
        Me.TreeView_TMR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TreeView_TMR.Name = "TreeView_TMR"
        Me.TreeView_TMR.Size = New System.Drawing.Size(466, 301)
        Me.TreeView_TMR.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(117, 370)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(285, 18)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Select A Table By Its Details To View"
        '
        'Panel_TreeViews
        '
        Me.Panel_TreeViews.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_TreeViews.Controls.Add(Me.TreeView_PDD)
        Me.Panel_TreeViews.Controls.Add(Me.Label_TablesLoaded)
        Me.Panel_TreeViews.Controls.Add(Me.Label2)
        Me.Panel_TreeViews.Controls.Add(Me.TreeView_Profiles)
        Me.Panel_TreeViews.Controls.Add(Me.TreeView_TMR)
        Me.Panel_TreeViews.Location = New System.Drawing.Point(0, 321)
        Me.Panel_TreeViews.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel_TreeViews.Name = "Panel_TreeViews"
        Me.Panel_TreeViews.Size = New System.Drawing.Size(1752, 402)
        Me.Panel_TreeViews.TabIndex = 14
        '
        'Button_Import
        '
        Me.Button_Import.Enabled = False
        Me.Button_Import.Location = New System.Drawing.Point(115, 215)
        Me.Button_Import.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_Import.Name = "Button_Import"
        Me.Button_Import.Size = New System.Drawing.Size(175, 33)
        Me.Button_Import.TabIndex = 15
        Me.Button_Import.Text = "Import"
        Me.Button_Import.UseVisualStyleBackColor = True
        '
        'ProgressBar_TableLoad
        '
        Me.ProgressBar_TableLoad.Location = New System.Drawing.Point(115, 256)
        Me.ProgressBar_TableLoad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ProgressBar_TableLoad.Name = "ProgressBar_TableLoad"
        Me.ProgressBar_TableLoad.Size = New System.Drawing.Size(332, 23)
        Me.ProgressBar_TableLoad.TabIndex = 16
        Me.ProgressBar_TableLoad.Visible = False
        '
        'Label_TableImportsSucceeded
        '
        Me.Label_TableImportsSucceeded.AutoSize = True
        Me.Label_TableImportsSucceeded.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_TableImportsSucceeded.Location = New System.Drawing.Point(111, 283)
        Me.Label_TableImportsSucceeded.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_TableImportsSucceeded.Name = "Label_TableImportsSucceeded"
        Me.Label_TableImportsSucceeded.Size = New System.Drawing.Size(222, 20)
        Me.Label_TableImportsSucceeded.TabIndex = 14
        Me.Label_TableImportsSucceeded.Text = "Table Imports Succeeded"
        Me.Label_TableImportsSucceeded.Visible = False
        '
        'Label_TableImportsFailed
        '
        Me.Label_TableImportsFailed.AutoSize = True
        Me.Label_TableImportsFailed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_TableImportsFailed.Location = New System.Drawing.Point(411, 283)
        Me.Label_TableImportsFailed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_TableImportsFailed.Name = "Label_TableImportsFailed"
        Me.Label_TableImportsFailed.Size = New System.Drawing.Size(181, 20)
        Me.Label_TableImportsFailed.TabIndex = 17
        Me.Label_TableImportsFailed.Text = "Table Imports Failed"
        Me.Label_TableImportsFailed.Visible = False
        '
        'SNCSysImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1752, 783)
        Me.Controls.Add(Me.Label_TableImportsFailed)
        Me.Controls.Add(Me.Label_TableImportsSucceeded)
        Me.Controls.Add(Me.ProgressBar_TableLoad)
        Me.Controls.Add(Me.Button_Import)
        Me.Controls.Add(Me.Panel_TreeViews)
        Me.Controls.Add(Me.NamingExampleText)
        Me.Controls.Add(Me.Button_LoadTables)
        Me.Controls.Add(Me.Button_BrowseLoc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox_SNCTableLoc)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SNCSysImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SNC System Data Import"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel_TreeViews.ResumeLayout(False)
        Me.Panel_TreeViews.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button_Back As System.Windows.Forms.Button
    Friend WithEvents TextBox_SNCTableLoc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button_BrowseLoc As System.Windows.Forms.Button
    Friend WithEvents Button_LoadTables As System.Windows.Forms.Button
    Friend WithEvents NamingExampleText As System.Windows.Forms.RichTextBox
    Friend WithEvents Label_TablesLoaded As System.Windows.Forms.Label
    Friend WithEvents TreeView_PDD As System.Windows.Forms.TreeView
    Friend WithEvents TreeView_Profiles As System.Windows.Forms.TreeView
    Friend WithEvents TreeView_TMR As System.Windows.Forms.TreeView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel_TreeViews As System.Windows.Forms.Panel
    Friend WithEvents Button_Import As System.Windows.Forms.Button
    Friend WithEvents ProgressBar_TableLoad As System.Windows.Forms.ProgressBar
    Friend WithEvents Label_TableImportsSucceeded As System.Windows.Forms.Label
    Friend WithEvents Label_TableImportsFailed As System.Windows.Forms.Label
End Class
