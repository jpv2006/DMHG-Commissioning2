Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class SNCSysImport
    Public tables As New Collection

    Private Sub Init_Tables()
        tables.Add(New Collection, "pdd")
        tables.Add(New Collection, "profile")
        tables.Add(New Collection, "tmr")

        TreeView_PDD.Nodes.Add("pdd", "PDD").Expand()
        TreeView_Profiles.Nodes.Add("profile", "Profiles").Expand()
        TreeView_TMR.Nodes.Add("tmr", "TMR").Expand()
    End Sub

    Private Sub Button_Back_Click(sender As Object, e As EventArgs) Handles Button_Back.Click
        Form_SiteInfo.Show()
        Me.Close()
    End Sub

    Private Sub Button_BrowseLoc_Click(sender As Object, e As EventArgs) Handles Button_BrowseLoc.Click
        Dim folderDialog As FolderBrowserDialog = New FolderBrowserDialog()
        folderDialog.RootFolder = Environment.SpecialFolder.Personal

        If folderDialog.ShowDialog() = DialogResult.OK Then
            TextBox_SNCTableLoc.Text = folderDialog.SelectedPath
        End If
    End Sub

    Private Sub Button_OpenDB_Click(sender As Object, e As EventArgs) Handles Button_LoadTables.Click
        If (TextBox_SNCTableLoc.Text Is Nothing) Then
            MessageBox.Show("Please specify the folder containing the SNC System data tables.")
        ElseIf (FileIO.FileSystem.DirectoryExists(TextBox_SNCTableLoc.Text)) Then
            LoadTables(TextBox_SNCTableLoc.Text)
        Else
            MessageBox.Show("The specified folder does not exist.")
        End If
    End Sub

    Private Sub LoadTables(tableFolder As String)
        Dim fileInfo As String()
        Dim fieldType As String = "", scanType As String = "", scanAngle As Double, wedgeAngle As Double, ssd As Double, energy As String = ""
        Dim numTables As Integer = 0
        Dim fileInfoIndex As Integer = 0
        Dim dir As New System.IO.DirectoryInfo(tableFolder)

        ProgressBar_TableLoad.Visible = True
        ProgressBar_TableLoad.Value = 0
        ProgressBar_TableLoad.Maximum = dir.GetFiles.Length
        Me.Cursor = Cursors.WaitCursor

        tables.Clear()
        TreeView_PDD.Nodes.Clear()
        TreeView_Profiles.Nodes.Clear()
        TreeView_TMR.Nodes.Clear()
        Init_Tables()

        'Parse filename
        For Each file As System.IO.FileInfo In dir.GetFiles()
            fileInfoIndex = 0

            'Initialize wedgeAngle and scanAngle to -1 so we know if they've been set
            scanAngle = -1
            wedgeAngle = -1

            fileInfo = file.Name.Substring(0, file.Name.LastIndexOf(".")).Split("_")
            If (fileInfo.Length >= 4 And fileInfo.Length <= 6) Then
                scanType = fileInfo(fileInfoIndex).ToLower
                fileInfoIndex += 1

                If (scanType.Equals("profile")) Then
                    scanAngle = fileInfo(fileInfoIndex)
                    fileInfoIndex += 1
                End If

                fieldType = fileInfo(fileInfoIndex).ToLower
                fileInfoIndex += 1

                If (scanType.Equals("profile") And fileInfo.Length = 6) Or (Not scanType.Equals("profile") And fileInfo.Length = 5) Then
                    wedgeAngle = fileInfo(fileInfoIndex)
                    fileInfoIndex += 1
                End If

                ssd = fileInfo(fileInfoIndex)
                fileInfoIndex += 1
                energy = fileInfo(fileInfoIndex)
                If energy.ToLower.Contains("e") Then
                    energy = energy.ToLower
                Else
                    energy = energy.ToUpper
                End If

                'Populates the treeview - note that the tables stored in the tree's leaves have an identifying key which can be used to retrieve their table data from tables
                If (scanType.Equals("pdd") Or scanType.Equals("profile") Or scanType.Equals("tmr")) Then

                    'Store the wedgeangle as 0 for open fields
                    If (fieldType.Equals("open")) Then
                        wedgeAngle = 0
                    End If

                    numTables += 1
                    Select Case scanType
                        Case "pdd"
                            'Create subtree for the field type if it doesn't exist
                            If (Not TreeView_PDD.Nodes(scanType).Nodes.ContainsKey(fieldType)) Then
                                TreeView_PDD.Nodes(scanType).Nodes.Add(fieldType, fieldType.First.ToString.ToUpper & fieldType.Substring(1))
                            End If

                            'Add scan to tree
                            If (wedgeAngle <> -1) Then
                                If (wedgeAngle > 0 And Not TreeView_PDD.Nodes(scanType).Nodes(fieldType).Nodes.ContainsKey(wedgeAngle.ToString)) Then
                                    TreeView_PDD.Nodes(scanType).Nodes(fieldType).Nodes.Add(wedgeAngle.ToString, "Wedge Angle: " & wedgeAngle.ToString)
                                    TreeView_PDD.Nodes(scanType).Nodes(fieldType).Nodes(wedgeAngle.ToString).Nodes().Add( _
                                        wedgeAngle.ToString & "," & ssd.ToString & "," & energy, "SSD: " & ssd.ToString & ", Energy: " & energy)
                                Else
                                    TreeView_PDD.Nodes(scanType).Nodes(fieldType).Nodes().Add( _
                                        wedgeAngle.ToString & "," & ssd.ToString & "," & energy, "SSD: " & ssd.ToString & ", Energy: " & energy)
                                End If

                            Else
                                TreeView_PDD.Nodes(scanType).Nodes(fieldType).Nodes().Add( _
                                   ssd.ToString & "," & energy, "SSD: " & ssd.ToString & ", Energy: " & energy)
                            End If
                        Case "profile"
                            'Create subtree for the field type if it doesn't exist
                            If (Not TreeView_Profiles.Nodes(0).Nodes.ContainsKey(fieldType)) Then
                                TreeView_Profiles.Nodes(scanType).Nodes.Add(fieldType, fieldType.First.ToString.ToUpper & fieldType.Substring(1))
                            End If

                            'Add scan to tree
                            If (wedgeAngle <> -1) Then
                                If (wedgeAngle > 0 And Not TreeView_Profiles.Nodes(scanType).Nodes(fieldType).Nodes.ContainsKey(wedgeAngle.ToString)) Then
                                    TreeView_Profiles.Nodes(scanType).Nodes(fieldType).Nodes.Add(wedgeAngle.ToString, "Wedge Angle: " & wedgeAngle.ToString)
                                    TreeView_Profiles.Nodes(scanType).Nodes(fieldType).Nodes(wedgeAngle.ToString).Nodes().Add( _
                                        scanAngle & "," & wedgeAngle.ToString & "," & ssd.ToString & "," & energy, "Scan Angle: " & scanAngle.ToString & ", SSD: " & ssd.ToString & ", Energy: " & energy)
                                Else
                                    TreeView_Profiles.Nodes(scanType).Nodes(fieldType).Nodes().Add( _
                                        wedgeAngle.ToString & "," & ssd.ToString & "," & energy, "SSD: " & ssd.ToString & ", Energy: " & energy)
                                End If
                                
                            Else
                                TreeView_Profiles.Nodes(scanType).Nodes(fieldType).Nodes().Add( _
                                    scanAngle & "," & ssd.ToString & ", " & energy, "Scan Angle: " & scanAngle.ToString & ", SSD: " & ssd.ToString & ", Energy: " & energy)
                            End If
                        Case "tmr"
                            'Create subtree for the field type if it doesn't exist
                            If (Not TreeView_TMR.Nodes(scanType).Nodes.ContainsKey(fieldType)) Then
                                TreeView_TMR.Nodes(scanType).Nodes.Add(fieldType, fieldType.First.ToString.ToUpper & fieldType.Substring(1))
                            End If

                            'Add scan to tree
                            If (wedgeAngle <> -1) Then
                                If (wedgeAngle > 0 And Not TreeView_TMR.Nodes(scanType).Nodes(fieldType).Nodes.ContainsKey(wedgeAngle.ToString)) Then
                                    TreeView_TMR.Nodes(scanType).Nodes(fieldType).Nodes.Add(wedgeAngle.ToString, "Wedge Angle: " & wedgeAngle.ToString)
                                    'NOTE! The ssd variable is used here, HOWEVER the actual measurement for the tmr scan is the scd. The scd will in this case be stored in the ssd variable for convenience.
                                    TreeView_TMR.Nodes(scanType).Nodes(fieldType).Nodes(wedgeAngle.ToString).Nodes().Add( _
                                        wedgeAngle.ToString & "," & ssd.ToString & "," & energy, "SCD: " & ssd.ToString & ", Energy: " & energy)
                                Else
                                    TreeView_TMR.Nodes(scanType).Nodes(fieldType).Nodes().Add( _
                                        wedgeAngle.ToString & "," & ssd.ToString & "," & energy, "SCD: " & ssd.ToString & ", Energy: " & energy)
                                End If
                                
                            Else
                                TreeView_TMR.Nodes(scanType).Nodes(fieldType).Nodes().Add( _
                                    ssd.ToString & "," & energy, "SCD: " & ssd.ToString & ", Energy: " & energy)
                            End If
                    End Select
                    
                    'Create the datatable for the scan table
                    If (Not tables.Item(scanType).contains(fieldType)) Then
                        tables.Item(scanType).add(New Collection, fieldType)
                    End If

                    If (scanType.Equals("profile")) Then
                        If (wedgeAngle <> -1) Then
                            tables.Item(scanType).item(fieldType).add(New DataTable, scanAngle.ToString & "," & wedgeAngle.ToString & "," & ssd.ToString & "," & energy)
                            ReadTable(file.FullName, tables.Item(scanType).item(fieldType).item(scanAngle.ToString & "," & wedgeAngle.ToString & "," & ssd.ToString & "," & energy), fieldType)
                        Else
                            tables.Item(scanType).item(fieldType).add(New DataTable, scanAngle.ToString & "," & ssd.ToString & "," & energy)
                            ReadTable(file.FullName, tables.Item(scanType).item(fieldType).item(scanAngle.ToString & "," & ssd.ToString & "," & energy), fieldType)
                        End If
                    Else
                        If (wedgeAngle <> -1) Then
                            tables.Item(scanType).item(fieldType).add(New DataTable, wedgeAngle.ToString & "," & ssd.ToString & "," & energy)
                            ReadTable(file.FullName, tables.Item(scanType).item(fieldType).item(wedgeAngle.ToString & "," & ssd.ToString & "," & energy), fieldType)
                        Else
                            tables.Item(scanType).item(fieldType).add(New DataTable, ssd.ToString & "," & energy)
                            ReadTable(file.FullName, tables.Item(scanType).item(fieldType).item(ssd.ToString & "," & energy), fieldType)
                        End If
                    End If
                    ProgressBar_TableLoad.Increment(1)
                End If
            End If
        Next

        Label_TablesLoaded.Text = numTables & " Tables Loaded"

        ProgressBar_TableLoad.Value = ProgressBar_TableLoad.Maximum
        Me.Cursor = Cursors.Default
        ProgressBar_TableLoad.Visible = False

        If (numTables > 0) Then
            Button_Import.Enabled = True
        End If
    End Sub

    Private Sub TreeView_PDD_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView_PDD.AfterSelect
        If (e.Node.Level = 2 And e.Node.Nodes.Count = 0) Then
            OpenTable(tables.Item(e.Node.Parent.Parent.Text).item(e.Node.Parent.Text).item(e.Node.Name), e.Node.Text)
        ElseIf e.Node.Level = 3 Then
            OpenTable(tables.Item(e.Node.Parent.Parent.Text).item(e.Node.Parent.Text).item(e.Node.Name), e.Node.Text)
        End If
    End Sub

    Private Sub TreeView_Profiles_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView_Profiles.AfterSelect
        If (e.Node.Level = 2 And e.Node.Nodes.Count = 0) Then
            OpenTable(tables.Item(e.Node.Parent.Parent.Text).item(e.Node.Parent.Text).item(e.Node.Name), e.Node.Text)
        ElseIf e.Node.Level = 3 Then
            OpenTable(tables.Item(e.Node.Parent.Parent.Text).item(e.Node.Parent.Text).item(e.Node.Name), e.Node.Text)
        End If
    End Sub

    Private Sub TreeView_TMR_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView_TMR.AfterSelect
        If (e.Node.Level = 2 And e.Node.Nodes.Count = 0) Then
            OpenTable(tables.Item(e.Node.Parent.Parent.Text).item(e.Node.Parent.Text).item(e.Node.Name), e.Node.Text)
        ElseIf e.Node.Level = 3 Then
            OpenTable(tables.Item(e.Node.Parent.Parent.Text).item(e.Node.Parent.Text).item(e.Node.Name), e.Node.Text)
        End If
    End Sub

    Private Sub ReadTable(file As String, table As DataTable, fieldType As String)
        Dim columnNames As String()
        Dim data As String()
        Dim fileReader As New FileIO.TextFieldParser(file)

        fileReader.SetDelimiters(vbTab)

        table.Columns.Add("Depth")

        columnNames = fileReader.ReadFields
        For Each column As String In columnNames
            If (column IsNot "") Then
                column = column.Replace(" ", "")

                'Cone fields are of the form 10mm, non cone fields are of the form 5x5
                If (fieldType.Equals("cone")) Then
                    If (column.Contains("x")) Then
                        column = column.Substring(column.IndexOf("x") + 1)
                    End If

                Else
                    If (column.Contains("c")) Then
                        column = column.Substring(0, column.LastIndexOf("c"))
                    End If
                End If

                table.Columns.Add(column)
            End If
        Next

        While fileReader.LineNumber <> -1
            table.Rows().Add(table.NewRow)
            data = fileReader.ReadFields
            For i As Integer = 0 To (data.Length - 1)
                If (Not data(i).Equals("")) Then
                    table.Rows(table.Rows().Count - 1).Item(i) = data(i)
                End If
            Next
        End While


    End Sub

    Private Sub OpenTable(table As DataTable, title As String)
        Dim tableDialog As New Form
        Dim dataGrid As New DataGridView

        dataGrid.DataSource = table
        dataGrid.AllowUserToAddRows = False
        dataGrid.AllowUserToDeleteRows = False
        dataGrid.EditMode = DataGridViewEditMode.EditProgrammatically
        dataGrid.Dock = DockStyle.Fill

        tableDialog.Controls().Add(dataGrid)
        tableDialog.Width = 720
        tableDialog.Height = 480
        tableDialog.StartPosition = FormStartPosition.CenterParent
        tableDialog.Text = title
        tableDialog.ShowDialog()
    End Sub

    Private Sub Button_Import_Click(sender As Object, e As EventArgs) Handles Button_Import.Click
        Dim MySqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("noDB").ConnectionString & "database=" & activeSite.factors)
        Dim command As New MySqlCommand
        Dim commandString As String
        Dim table As DataTable
        Dim numRows As Integer = 0
        Dim numSucceeded As Integer = 0, numFailed As Integer = 0
        Dim successText As String = " (Failed)"
        Dim failed As Boolean

        'Count the number of rows to set the progress bar
        For Each scanType In Panel_TreeViews.Controls
            If (scanType.GetType.Equals(GetType(TreeView))) Then
                scanType = TryCast(scanType, TreeView)
                'Note that scanType.nodes(0).name is used to get the scan type string since each tree view has its root node as the scan type
                For Each fieldType As TreeNode In scanType.nodes(0).nodes
                    If (fieldType.Nodes(0).Nodes.Count > 0) Then
                        For Each wedgeAngle As TreeNode In fieldType.Nodes
                            For Each scan As TreeNode In wedgeAngle.Nodes
                                numRows += tables.Item(scanType.nodes(0).name).item(fieldType.Name).item(scan.Name).rows.count
                            Next

                        Next
                    Else
                        For Each scan As TreeNode In fieldType.Nodes
                            numRows += tables.Item(scanType.nodes(0).name).item(fieldType.Name).item(scan.Name).rows.count
                        Next
                    End If
                Next
            End If
        Next

        ProgressBar_TableLoad.Maximum = numRows
        ProgressBar_TableLoad.Visible = True
        ProgressBar_TableLoad.Value = 0
        Me.Cursor = Cursors.WaitCursor

        For Each scanType In Panel_TreeViews.Controls
            If (scanType.GetType.Equals(GetType(TreeView))) Then
                scanType = TryCast(scanType, TreeView)
                'Note that scanType.nodes(0).name is used to get the scan type string since each tree view has its root node as the scan type
                For Each fieldType As TreeNode In scanType.nodes(0).nodes

                    'If there are wedge angle subtrees for this field type
                    If (fieldType.Nodes(0).Nodes.Count > 0) Then
                        For Each wedgeAngle As TreeNode In fieldType.Nodes
                            For Each scan As TreeNode In wedgeAngle.Nodes
                                Try
                                    table = tables.Item(scanType.Nodes(0).name).item(fieldType.Text).item(scan.Name)
                                    commandString = ConstructCommandString(scanType.nodes(0), fieldType, scan, table)

                                    'Filling in command parameters
                                    command.CommandText = commandString
                                    command.Connection = MySqlConn
                                    MySqlConn.Open()
                                    command.Prepare()

                                    failed = False
                                    successText = " (Failed)"

                                    For Each row As DataRow In table.Rows
                                        command = Add_Command_Parameters(command, scanType.nodes(0), scan, table, row)

                                        If (command.ExecuteScalar = 1) Then
                                            'Cannot find a table/row to fit table, user likely made a typo
                                            MessageBox.Show("Error when importing data table '" & scan.Text & "' with " & wedgeAngle.Text & "', Field Type: " & fieldType.Text & _
                                                            ", Scan Type: " & scanType.nodes(0).text & ". Check filename for validity. Details: Cannot find matching location for the table in the database.")
                                            numFailed += 1
                                            ProgressBar_TableLoad.Increment(table.Rows.Count)
                                            command.Parameters.Clear()
                                            failed = True
                                            Exit For
                                        End If
                                        command.Parameters.Clear()
                                        ProgressBar_TableLoad.Increment(1)
                                    Next


                                    If (Not failed) Then
                                        numSucceeded += 1
                                        successText = " (Imported)"

                                    End If
                                    MySqlConn.Close()

                                Catch ex As MySqlException
                                    MySqlConn.Close()
                                    MessageBox.Show("Error when importing data table '" & scan.Text & "' with " & wedgeAngle.Text & ", Field Type: " & fieldType.Text & _
                                                    ", Scan Type: " & scanType.nodes(0).text & ". Check file contents for validity. Details: " & ex.Message)
                                    numFailed += 1
                                    command.Parameters.Clear()
                                End Try

                                scan.Text = scan.Text & successText
                            Next
                        Next
                    Else
                        For Each scan As TreeNode In fieldType.Nodes
                            Try
                                table = tables.Item(scanType.Nodes(0).name).item(fieldType.Text).item(scan.Name)
                                commandString = ConstructCommandString(scanType.nodes(0), fieldType, scan, table)

                                'Filling in command parameters
                                command.CommandText = commandString
                                command.Connection = MySqlConn
                                MySqlConn.Open()
                                command.Prepare()

                                failed = False
                                successText = " (Failed)"

                                For Each row As DataRow In table.Rows
                                    command = Add_Command_Parameters(command, scanType.nodes(0), scan, table, row)

                                    If (command.ExecuteScalar = 1) Then
                                        'Cannot find a table/row to fit table, user likely made a typo
                                        MessageBox.Show("Error when importing data table '" & scan.Text & "', Field Type: " & fieldType.Text & _
                                                        ", Scan Type: " & scanType.nodes(0).text & ". Check filename for validity. Details: Cannot find matching location for the table in the database.")
                                        numFailed += 1
                                        ProgressBar_TableLoad.Increment(table.Rows.Count)
                                        command.Parameters.Clear()
                                        failed = True
                                        Exit For
                                    End If
                                    command.Parameters.Clear()
                                    ProgressBar_TableLoad.Increment(1)
                                Next

                                If (Not failed) Then
                                    numSucceeded += 1
                                    successText = " (Imported)"
                                End If
                                MySqlConn.Close()

                            Catch ex As MySqlException
                                MySqlConn.Close()
                                MessageBox.Show("Error when importing data table '" & scan.Text & "', Field Type: " & fieldType.Text & _
                                                ", Scan Type: " & scanType.nodes(0).text & ". Check file contents for validity. Details: " & ex.Message)
                                numFailed += 1
                                command.Parameters.Clear()
                            End Try

                            scan.Text = scan.Text & successText
                        Next
                    End If
                Next
            End If
        Next

        ProgressBar_TableLoad.Visible = False
        Me.Cursor = Cursors.Default
        Label_TableImportsFailed.Visible = True
        Label_TableImportsSucceeded.Visible = True
        Label_TableImportsFailed.Text = numFailed & " Table Imports Failed"
        Label_TableImportsSucceeded.Text = numSucceeded & " Table Imports Succeeded"
    End Sub

    Private Function ConstructCommandString(scanType As TreeNode, fieldType As TreeNode, scan As TreeNode, table As DataTable) As String
        Dim commandString As String = ""
        Dim dbTableName As String = ""

        If (scan.Name.ToUpper.Contains("X")) Then
            'Photon energy
            dbTableName = "photon_" & scanType.Name
            If (fieldType.Text.Equals("cone")) Then
                dbTableName = dbTableName & "_cones"
            End If
        ElseIf (scan.Name.ToLower.Contains("e")) Then
            'Electron energy
            dbTableName = "electron_" & scanType.Name
            If (fieldType.Text.Equals("cone")) Then
                dbTableName = dbTableName & "_cones"
            End If
        End If

        If (Not dbTableName.Equals("")) Then
            commandString = "UPDATE " & dbTableName & " SET "

            'SET Portion

            If (scanType.Name.Equals("profile")) Then
                commandString = commandString & "ScanAngle=@scanAngle, "
                commandString = commandString & "SSD=@ssd, "
            ElseIf (scanType.Name.Equals("tmr")) Then
                commandString = commandString & "SCD=@ssd, "
            ElseIf (scanType.Name.Equals("pdd")) Then
                commandString = commandString & "SSD=@ssd"
            End If

            For Each column As Data.DataColumn In table.Columns
                If (Not column.ColumnName.Equals("Depth")) Then
                    commandString = commandString & column.ColumnName & "=@" & column.ColumnName & ", "
                End If
            Next

            commandString = commandString.Substring(0, commandString.LastIndexOf(","))

            'WHERE Portion
            commandString = commandString & " WHERE Energy=@energy AND Depth=@depth"

            'If there are wedge angle subtrees or the scan type is open (so there is a wedge angle of 0)
            If (fieldType.Nodes(0).Nodes.Count > 0 Or fieldType.Name.Equals("open")) Then
                commandString = commandString & " AND WedgeAngle=@wedgeAngle"
            End If


            'Checks if the rows exist, this will determine if the user made any typos while writing the filenames because corresponding tables/rows won't exist
            commandString = commandString & ";SELECT IF(EXISTS(SELECT * FROM " & dbTableName & " WHERE Energy=@energy AND Depth=@depth"
            If (fieldType.Nodes(0).Nodes.Count > 0 Or fieldType.Name.Equals("open")) Then
                commandString = commandString & " AND WedgeAngle=@wedgeAngle"
            End If
            commandString = commandString & "), 0, 1);"
        Else
            commandString = "SELECT 1;"
        End If

        Return commandString
    End Function

    Private Function Add_Command_Parameters(command As MySqlCommand, scanType As TreeNode, scan As TreeNode, table As DataTable, row As DataRow) As MySqlCommand
        Dim scanNameSegments As String()
        Dim scanNameIndex As Integer
        Dim energy As String

        scanNameIndex = 0
        scanNameSegments = scan.Name.Split(",")

        If (scanType.Name.Equals("profile")) Then
            command.Parameters.AddWithValue("scanAngle", scanNameSegments(scanNameIndex))
            scanNameIndex += 1
        End If

        'If there are wedge angle subtrees or the scan type is open (so there is a wedge angle of 0)
        If (scanType.Nodes(0).Nodes(0).Nodes.Count > 0 Or scan.Parent.Name.Equals("open")) Then
            command.Parameters.AddWithValue("wedgeAngle", scanNameSegments(scanNameIndex))
            scanNameIndex += 1
        End If

        command.Parameters.AddWithValue("ssd", scanNameSegments(scanNameIndex))
        scanNameIndex += 1

        energy = scanNameSegments(scanNameIndex)
        If (energy.Contains("FFF")) Then
            energy = energy.Insert(energy.IndexOf("F"), " ")
        End If
        command.Parameters.AddWithValue("energy", energy)
        scanNameIndex += 1

        command.Parameters.AddWithValue("depth", row.Item("Depth") * 10)

        For Each column As DataColumn In table.Columns
            If (Not column.ColumnName.Equals("Depth")) Then
                command.Parameters.AddWithValue(column.ColumnName, row.Item(column.ColumnName))
            End If
        Next

        Return command
    End Function
End Class