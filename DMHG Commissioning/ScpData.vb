Imports MySql.Data.MySqlClient
Imports System.Configuration


''' <summary>
''' Loads the ScpData form
''' </summary>

Public Class Form_ScpData

    Dim COMMAND As MySqlCommand
    Dim sitesDBConn As MySqlConnection
    Dim READER As MySqlDataReader
    Dim factorsDBConn As MySqlConnection
    Dim currentRowIndex As Integer
    Dim temporaryRowIndex As Integer
    Dim rowIndex As Integer
    Dim scpData As New DataTable()
    Dim turnlower As Boolean = False
    Dim turnhigher As Boolean = False
    Dim thisIsAnEdit As Boolean = False
    Dim reading(21) As Double

    Private Sub Scp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        factorsDBConn = New MySqlConnection(ConfigurationManager.ConnectionStrings("noDB").ConnectionString & "database=" & activeSite.factors)
        '================================================================
        ' 
        ScpGraph.Show()

        '===============================================================

        Populate_Data_Table(DataGridView_Factors, activeMeasurementTableName)

        Label_Title.Text = activeMeasurement

        Me.DataGridView_Factors.Columns(8).DefaultCellStyle.Format = "N1"
        Me.DataGridView_Factors.Columns(9).DefaultCellStyle.Format = "N1"
        Me.DataGridView_Factors.Columns(10).DefaultCellStyle.Format = "N1"
        Me.DataGridView_Factors.Columns(11).DefaultCellStyle.Format = "N3"
        Me.DataGridView_Factors.Columns(12).DefaultCellStyle.Format = "N1"
        Me.DataGridView_Factors.Columns(13).DefaultCellStyle.Format = "N1"

        ' If this is the start of data collection, make Temp and Press available for entry otherwise not.

        If currentRowIndex = 0 Then
            TextBox_Temperature.ReadOnly = False
            TextBox_Pressure.ReadOnly = False
            Panel_Stability.Visible = True
            GroupBox_Stability.Visible = True
            TextBox_StabReading.Select()
        Else
            TextBox_Temperature.ReadOnly = True
            TextBox_Pressure.ReadOnly = True
            Panel_Stability.Visible = True
            GroupBox_Stability.Visible = True
            TextBox_StabReading.Select()
        End If

    End Sub

    ''' <summary>
    ''' Populates the DGV data table with data from the factors database of the active site and the given table.
    ''' </summary>
    ''' <param name="tableControl">The data grid table control to edit.</param>
    ''' <param name="table">The factors table in the database to pull data from.</param>
    ''' <remarks></remarks>

    Private Sub Populate_Data_Table(tableControl As DataGridView, table As String)
        Dim existingSiteAdapter As MySqlDataAdapter
        Dim source As New BindingSource

        Try
            factorsDBConn.Open()

            existingSiteAdapter = New MySqlDataAdapter("SELECT * FROM " & table & " where Energy = '" & activePhotonEnergy & "'", factorsDBConn)
            existingSiteAdapter.Fill(scpData)
            existingSiteAdapter.Dispose()

            source.DataSource = scpData

            tableControl.DataSource = source
            '================================================================
            ' 
            ScpGraph.Chart_Update(scpData)

            '===============================================================

        Catch mysqlEx As MySqlException
            MessageBox.Show(mysqlEx.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            factorsDBConn.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Calculates Scp/Sc.
    ''' </summary>

    Private Function Scp_Calculate(rowIndex)
        Dim command As New MySqlCommand
        Dim NormValue, ctp, ctpnorm As Double
        If rowIndex = 0 Then
            Scp_Calculate = 1.0
        Else
            ctpnorm = ((273.2 + scpData.Rows(0).Item("Temp")) / 295.2) * ((101.33 * 7.50061682) / scpData.Rows(0).Item("Press"))
            NormValue = (scpData.Rows(0).Item("Average") * ctpnorm)
            ctp = ((273.2 + scpData.Rows(rowIndex).Item("Temp")) / 295.2) * ((101.33 * 7.50061682) / scpData.Rows(rowIndex).Item("Press"))
            Scp_Calculate = (scpData.Rows(rowIndex).Item("Average") * ctp) / NormValue
        End If
        
    End Function



    ''' <summary>
    ''' Calculates all Scp/Sc if there is an edit, writes the value into scpData and updates the database.
    ''' </summary>

    Private Function Scp_CalcEdit(rowIndex)
        Dim command As New MySqlCommand
        ' Dim reader As MySqlDataReader
        Dim NormValue, ctp, ctpnorm As Double
        Dim i As Integer
        Dim ScpRevised, readingsTolerance As Double

        ' Re-calculates all the Scp/Sc. Updates the database and scpData.
        Try
            factorsDBConn.Open()
            For i = 0 To currentRowIndex - 1
                If i = 0 Then
                    ctpnorm = ((273.2 + scpData.Rows(i).Item("Temp")) / 295.2) * ((101.33 * 7.50061682) / scpData.Rows(i).Item("Press"))
                    NormValue = (scpData.Rows(i).Item("Average") * ctpnorm)
                    ScpRevised = 1
                    scpData.Rows(i).Item(activeMeasurementType) = ScpRevised
                    command.CommandText = "UPDATE `" & activeSite.factors & "`.`" & activeMeasurementTableName & "` SET `" & activeMeasurementType & "`= '" & ScpRevised & "' WHERE Row= '" & i + 1 & "' and Energy = '" & activePhotonEnergy & "';"
                    command.Connection = factorsDBConn
                    command.Prepare()

                    'updates row in the database and the DGV
                    'Add_Row_Command_Parameters(scpData.Rows(i), command).ExecuteNonQuery()
                    command.ExecuteNonQuery()
                Else
                    ctp = ((273.2 + scpData.Rows(i).Item("Temp")) / 295.2) * ((101.33 * 7.50061682) / scpData.Rows(i).Item("Press"))
                    ScpRevised = (scpData.Rows(i).Item("Average") * ctp) / NormValue
                End If
                scpData.Rows(i).Item(activeMeasurementType) = ScpRevised
                command.CommandText = "UPDATE `" & activeSite.factors & "`.`" & activeMeasurementTableName & "` SET `" & activeMeasurementType & "`= '" & ScpRevised & "' WHERE Row= '" & i + 1 & "' and Energy = '" & activePhotonEnergy & "';"
                command.Connection = factorsDBConn
                command.Prepare()

                'updates row in the database and the DGV
                'Add_Row_Command_Parameters(scpData.Rows(i), command).ExecuteNonQuery()
                command.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MessageBox.Show("Could not open the database in order to calculate Scp/Sc" & ex.Message)
        Finally
            factorsDBConn.Close()
        End Try

        If Not ReadingTolerance(scpData.Rows(rowIndex).Item("Reading1"), scpData.Rows(rowIndex).Item("Reading2"), readingsTolerance) Then
            Me.DataGridView_Factors.Rows(rowIndex).Cells("Reading1").Style.BackColor = Color.IndianRed
            Me.DataGridView_Factors.Rows(rowIndex).Cells("Reading2").Style.BackColor = Color.IndianRed
        Else
            If scpData.Rows(currentRowIndex).Item("SmallField") <> "Yes" Then
                Me.DataGridView_Factors.Rows(rowIndex).Cells("Reading1").Style.BackColor = Color.White
                Me.DataGridView_Factors.Rows(rowIndex).Cells("Reading2").Style.BackColor = Color.White
            Else
                Me.DataGridView_Factors.Rows(rowIndex).Cells("Reading1").Style.BackColor = Color.Cornsilk
                Me.DataGridView_Factors.Rows(rowIndex).Cells("Reading2").Style.BackColor = Color.Cornsilk
            End If
        End If

        Scp_CalcEdit = 1.0

    End Function

    ''' <summary>
    ''' Pressing the Enter key selects the TextBox_Pressure, starting from TextBox_Temperature
    ''' </summary>

    Private Sub TextBox_Temperature_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_Temperature.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            TextBox_Pressure.Select()
        End If

    End Sub


    ''' <summary>
    ''' Pressing the Enter key selects the TextBox_Reading1, starting from TextBox_Pressure
    ''' </summary>

    Private Sub TextBox_Pressure_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_Pressure.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            TextBox_Reading1.Select()
            e.Handled = True
        End If

    End Sub


    ''' <summary>
    ''' Pressing the Enter key selects the TextBox_Reading2, starting from TextBox_Reading1 
    ''' </summary>

    Private Sub TextBox_Reading1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_Reading1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            TextBox_Reading2.Select()
            e.Handled = True
        End If

    End Sub


    ''' <summary>
    ''' Pressing the Enter key either selects the TextBox_Temperature or TextBox_Reading1, starting from TextBox_Reading2 
    ''' </summary>
    ''' 
    Private Sub TextBox_Reading2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_Reading2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Button_Enter_Click(sender, e)
            If currentRowIndex = 0 Then
                TextBox_Temperature.Select()
            Else
                TextBox_Reading1.Select()
            End If
            e.Handled = True
        End If

    End Sub


    ''' <summary>
    ''' Clears TextBox_Reading1, Reading2, and Average and sets the cursor to TextBox_Reading1 in order to take new measurements in
    ''' response to too large a difference between Reading 1 and Reading2 and user selects to repeat Measurement.
    ''' </summary>

    Private Sub RepeatMeasurement()
        TextBox_Reading1.Text = ""
        TextBox_Reading2.Text = ""
        TextBox_Average.Text = ""
        TextBox_Reading1.BackColor = Color.White
        TextBox_Reading2.BackColor = Color.White
        TextBox_Reading1.Select()
    End Sub


    ''' <summary>
    ''' Enters data into a prexisting row.
    ''' </summary>

    Private Sub Button_Enter_Click(sender As System.Object, e As System.EventArgs) Handles Button_Enter.Click
        Dim command As New MySqlCommand
        Dim TempPress As Boolean = False
        Dim fieldSize_X, fieldSize_Y As Integer, temp, press, reading1, reading2, average, readingsTolerance As Double

        ' Parses each textbox in the entry field and assigns value to corresponding variable
        ' Makes Temp and Press boxes read only.
        ' If any input fails, stop the save

        If (Not (Double.TryParse(TextBox_Temperature.Text, temp) And Double.TryParse(TextBox_Pressure.Text, press) And Integer.TryParse(TextBox_X.Text, fieldSize_X) And Integer.TryParse(TextBox_Y.Text, fieldSize_Y) And _
             Double.TryParse(TextBox_Reading1.Text, reading1) And Double.TryParse(TextBox_Reading2.Text, reading2) And _
             Double.TryParse(TextBox_Average.Text, average) And Double.TryParse(TextBox_ReadingsTolerance.Text, readingsTolerance))) Then
            MessageBox.Show("Only properly formatted numeric input is accepted.")
            Me.Cursor = Cursors.Default
            Return
        Else
            TextBox_Temperature.ReadOnly = True
            TextBox_Pressure.ReadOnly = True
        End If

        ' Checks to see if Reading1 and Reading2 are within tolearance, if not, give user option to repeat measurement

        If Not ReadingTolerance(reading1, reading2, readingsTolerance) Then
            TextBox_Reading1.BackColor = Color.IndianRed
            TextBox_Reading2.BackColor = Color.IndianRed
            Dim RepeatYN As System.Windows.Forms.DialogResult
            RepeatYN = MsgBox("The two readings differ by more than the allowed tolerance. Do you want to repeat the measurements??", MsgBoxStyle.YesNo)
            If RepeatYN = MsgBoxResult.Yes Then
                TextBox_Reading1.BackColor = Color.White
                TextBox_Reading2.BackColor = Color.White
                RepeatMeasurement()
                Return
            End If
            TextBox_Reading1.BackColor = Color.White
            TextBox_Reading2.BackColor = Color.White
        End If

        ' Checks to see if this is an edit

        If thisIsAnEdit Then
            rowIndex = temporaryRowIndex    ' temporaryRowIndex comes from the row clicked on using the mouse when edit is selected
            scpData.Rows(rowIndex).Item("Reading1") = reading1
            scpData.Rows(rowIndex).Item("Reading2") = reading2
            scpData.Rows(rowIndex).Item("Average") = average
            scpData.Rows(rowIndex).Item("Temp") = temp
            scpData.Rows(rowIndex).Item("Press") = press
            Scp_CalcEdit(rowIndex)
            Me.DataGridView_Factors.Enabled = True
        Else
            rowIndex = currentRowIndex      ' currentRowIndex calculates in method for Skip on Stability form
            scpData.Rows(rowIndex).Item("Reading1") = reading1
            scpData.Rows(rowIndex).Item("Reading2") = reading2
            scpData.Rows(rowIndex).Item("Average") = average
            scpData.Rows(rowIndex).Item("Temp") = temp
            scpData.Rows(rowIndex).Item("Press") = press
            scpData.Rows(rowIndex).Item(activeMeasurementType) = Scp_Calculate(rowIndex)


        End If

        ' Writes data into appropriate row of DataTable scpData
        ' Saves row in Scp database by calling routine Save_Row. Sends data in row as an argument.

        Try
            Save_Row(scpData.Rows(rowIndex))
            '================================================================
            ' 
            ScpGraph.Chart_Update(scpData)

            '===============================================================

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        ' Clears data entry textboxes in preparation for next set of entries

        TextBox_X.Text = ""
        TextBox_Y.Text = ""
        TextBox_Reading1.Text = ""
        TextBox_Reading2.Text = ""
        TextBox_Average.Text = ""

        ' Advances to the next row in the DGV as long as not at end of DataTable. Highlight the next row in blue and return 
        ' the previous row to white. Fill in the values of X and Y in the data entry text boxes.
        If Not thisIsAnEdit Then
            currentRowIndex = currentRowIndex + 1
        Else
            thisIsAnEdit = False
            Label_SelectRowToEdit.Visible = False
        End If

        'Sets the next data entry row blue. Colors rows that are for small field data.
        If currentRowIndex <= scpData.Rows.Count() - 1 And scpData.Rows(currentRowIndex).Item("SmallField") <> "Yes" Then
            If Not ReadingTolerance(scpData.Rows(currentRowIndex - 1).Item("Reading1"), scpData.Rows(currentRowIndex - 1).Item("Reading2"), readingsTolerance) Then
                Me.DataGridView_Factors.Rows(currentRowIndex - 1).Cells("Reading1").Style.BackColor = Color.IndianRed
                Me.DataGridView_Factors.Rows(currentRowIndex - 1).Cells("Reading2").Style.BackColor = Color.IndianRed
            Else
            Me.DataGridView_Factors.Rows(currentRowIndex - 1).DefaultCellStyle.BackColor = Color.White
        End If
        Me.DataGridView_Factors.Rows(currentRowIndex).DefaultCellStyle.BackColor = Color.AliceBlue
        Load_XYRow_Edit(scpData.Rows(currentRowIndex))
        Me.DataGridView_Factors.ClearSelection()
        TextBox_Reading1.Select()
        Else
            Me.DataGridView_Factors.Rows(currentRowIndex - 1).DefaultCellStyle.BackColor = Color.Cornsilk
            If Not ReadingTolerance(scpData.Rows(currentRowIndex - 1).Item("Reading1"), scpData.Rows(currentRowIndex - 1).Item("Reading2"), readingsTolerance) Then
                Me.DataGridView_Factors.Rows(currentRowIndex - 1).Cells("Reading1").Style.BackColor = Color.IndianRed
                Me.DataGridView_Factors.Rows(currentRowIndex - 1).Cells("Reading2").Style.BackColor = Color.IndianRed
            Else
                Me.DataGridView_Factors.Rows(currentRowIndex - 1).Cells("Reading1").Style.BackColor = Color.Cornsilk
                Me.DataGridView_Factors.Rows(currentRowIndex - 1).Cells("Reading2").Style.BackColor = Color.Cornsilk
            End If
            Me.DataGridView_Factors.Rows(currentRowIndex).DefaultCellStyle.BackColor = Color.AliceBlue
            Load_XYRow_Edit(scpData.Rows(currentRowIndex))
            Me.DataGridView_Factors.ClearSelection()
            TextBox_Reading1.Select()
        End If
        Me.Cursor = Cursors.Default
    End Sub


    ''' <summary>
    ''' Checks to see if Reading1 and Reading2 are within tolearance
    ''' </summary>

    Private Function ReadingTolerance(reading1, reading2, readingsTolerance)
        If (Math.Abs(reading1 - reading2) / reading1) * 100 > readingsTolerance Then
            ReadingTolerance = False
        Else
            ReadingTolerance = True
        End If
    End Function


    ''' <summary>
    ''' Saves a row to the database. Receives the data in row as an argument from the call.
    ''' </summary>

    Private Function Save_Row(row As System.Data.DataRow) As Boolean
        Dim command As New MySqlCommand
        Dim reader As MySqlDataReader

        ' Create the query to select all information from the .Scp/Sc database for a given row. @Row is an SQL variable. 

        Try
            factorsDBConn.Open()
            command.CommandText = "SELECT * FROM `" & activeSite.factors & "`.`" & activeMeasurementTableName & "` WHERE Row=@Row and Energy = '" & activePhotonEnergy & "';"
            command.Connection = factorsDBConn
            command.Prepare()

            ' Create an instance of the SqlDataReader reader. Fill with row from dataScp sent via argument.
            reader = Add_Row_Command_Parameters(row, command).ExecuteReader()

            ' Read the data in the row. If there was a row to read, do the If Then statement. If no row to read, do the If Else statement.

            If (reader.Read()) Then
                reader.Close()

                'Row already exists, so it must be updated. 
                command = New MySqlCommand()
                If activeMeasurementType = "Scp" Then
                    command.CommandText = "UPDATE `" & activeSite.factors & "`.`" & activeMeasurementTableName & "` SET " & _
                     "Reading1=@Reading1, Reading2=@Reading2, Average=@Average, Scp= @Scp, Temp=@Temp, Press=@Press " & _
                    "WHERE Row= @Row and Energy = '" & activePhotonEnergy & "';"
                End If
                If activeMeasurementType = "Scp2" Then
                    command.CommandText = "UPDATE `" & activeSite.factors & "`.`" & activeMeasurementTableName & "` SET " & _
                     "Reading1=@Reading1, Reading2=@Reading2, Average=@Average, Scp2= @Scp2, Temp=@Temp, Press=@Press " & _
                    "WHERE Row= @Row and Energy = '" & activePhotonEnergy & "';"
                End If
                If activeMeasurementType = "Sc" Then
                    command.CommandText = "UPDATE `" & activeSite.factors & "`.`" & activeMeasurementTableName & "` SET " & _
                     "Reading1=@Reading1, Reading2=@Reading2, Average=@Average, Sc= @Sc, Temp=@Temp, Press=@Press " & _
                    "WHERE Row= @Row and Energy = '" & activePhotonEnergy & "';"
                End If
                command.Connection = factorsDBConn
                command.Prepare()
                'updates row in the database
                Add_Row_Command_Parameters(row, command).ExecuteNonQuery()

                'command.ExecuteNonQuery()

            Else
                reader.Close()

                'Row doesn't exist so it must be created

                MessageBox.Show("You should not be seeing this message. Rows should only be updated, never inserted.")

                command = New MySqlCommand()
                If activeMeasurementType = "Scp" Then
                    command.CommandText = "INSERT INTO `" & activeSite.factors & "`.`" & activeMeasurementTableName & "` (Row, Energy, SSD, SmallField, X, Y, " & _
                        "Reading1, Reading2, Average, `" & activeMeasurementType & "`, Temp, Press) " & _
                        "VALUES (@Row, @Energy, @SSD, @SmallFiled, @X, @Y, @Reading1, @Reading2, @Average, @`" & activeMeasurementType & "`,@Temp, @Press ) where Energy = '" & activePhotonEnergy & "';"
                End If
                If activeMeasurementType = "Sc" Then
                    command.CommandText = "INSERT INTO `" & activeSite.factors & "`.`" & activeMeasurementTableName & "` (Row, Energy, SDD, SmallField, X, Y, " & _
                        "Reading1, Reading2, Average, `" & activeMeasurementType & "`, Temp, Press) " & _
                        "VALUES (@Row, @Energy, @SDD, @SmallFiled, @X, @Y, @Reading1, @Reading2, @Average, @`" & activeMeasurementType & "`,@Temp, @Press ) where Energy = '" & activePhotonEnergy & "';"
                End If
                command.Connection = factorsDBConn
                command.Prepare()

                Add_Row_Command_Parameters(row, command).ExecuteNonQuery()
                MessageBox.Show("Row Saved")
                End If
        Catch ex As Exception
            MessageBox.Show("Error in saving row to the database: " & ex.Message)
            Return False
        Finally
            factorsDBConn.Close()
        End Try

        Return True
    End Function


    ''' <summary>
    ''' Adds to the MySqlCommand command the entries for a row and fills the entries with the row data. Returns the filled command to Save_Row
    ''' </summary>

    Private Function Add_Row_Command_Parameters(row As System.Data.DataRow, command As MySqlCommand) As MySqlCommand
        command.Parameters.AddWithValue("Row", row.Item("Row"))
        command.Parameters.AddWithValue("Energy", row.Item("Energy"))
        If activeMeasurementType = "Scp" Then
            command.Parameters.AddWithValue("SSD", row.Item("SSD"))
        End If
        If activeMeasurementType = "Sc" Then
            command.Parameters.AddWithValue("SDD", row.Item("SDD"))
        End If
        command.Parameters.AddWithValue("SmallField", row.Item("SmallField"))
        command.Parameters.AddWithValue("X", row.Item("X"))
        command.Parameters.AddWithValue("Y", row.Item("Y"))
        command.Parameters.AddWithValue("Reading1", row.Item("Reading1"))
        command.Parameters.AddWithValue("Reading2", row.Item("Reading2"))
        command.Parameters.AddWithValue("Average", row.Item("Average"))
        command.Parameters.AddWithValue(activeMeasurementType, row.Item(activeMeasurementType))
        command.Parameters.AddWithValue("Temp", row.Item("Temp"))
        command.Parameters.AddWithValue("Press", row.Item("Press"))
        Return command
    End Function


    ''' <summary>
    ''' Responds to an Edit request by enabling the DGV so a row can be selected by the mouse.
    ''' </summary>

    Private Sub Button_Edit_Click(sender As System.Object, e As System.EventArgs) Handles Button_Edit.Click
        Me.DataGridView_Factors.Enabled = True
        Label_SelectRowToEdit.Visible = True
        thisIsAnEdit = True
    End Sub


    ''' <summary>
    ''' Selects a row using the mouse.
    ''' </summary>

    Private Sub DataGridView_Factors_CellMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView_Factors.CellMouseClick
        If Not thisIsAnEdit Then
            Return
        Else
            temporaryRowIndex = Me.DataGridView_Factors.SelectedRows.Item(0).Cells("Row").Value - 1
            TextBox_Temperature.ReadOnly = False
            TextBox_Pressure.ReadOnly = False
            Load_Row_Edit(scpData.Rows(temporaryRowIndex))
            Me.DataGridView_Factors.Enabled = False
        End If
    End Sub



    ''' <summary>
    ''' Loads the data entry row with the data in the row selected in DataViewGrid after an edit request.
    ''' </summary>

    Private Sub Load_Row_Edit(row As System.Data.DataRow)

        Try
            If IsDBNull(row.Item("X")) Then
                TextBox_X.Text = ""
            Else
                TextBox_X.Text = row.Item("X")
            End If

            If IsDBNull(row.Item("Y")) Then
                TextBox_Y.Text = ""
            Else
                TextBox_Y.Text = row.Item("Y")
            End If

            If IsDBNull(row.Item("Reading1")) Then
                TextBox_Reading1.Text = ""
            Else
                TextBox_Reading1.Text = row.Item("Reading1")
            End If

            If IsDBNull(row.Item("Reading2")) Then
                TextBox_Reading2.Text = ""
            Else
                TextBox_Reading2.Text = row.Item("Reading2")
            End If

            If IsDBNull(row.Item("Average")) Then
                TextBox_Average.Text = ""
            Else
                TextBox_Average.Text = row.Item("Average")
            End If

            If IsDBNull(row.Item("Temp")) Then
                TextBox_Temperature.Text = ""
            Else
                TextBox_Temperature.Text = row.Item("Temp")
            End If

            If IsDBNull(row.Item("Press")) Then
                TextBox_Pressure.Text = ""
            Else
                TextBox_Pressure.Text = row.Item("Press")
            End If

        Catch ex As Exception
            MessageBox.Show("You are editing a row with empty cells. " + ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' Loads the data entry row with the X, Y data in the DataViewGrid row where data entry is to begin.
    ''' </summary>

    Private Sub Load_XYRow_Edit(row As System.Data.DataRow)
        Try
            TextBox_X.Text = row.Item("X")
            TextBox_Y.Text = row.Item("Y")
            TextBox_X.BackColor = Color.AliceBlue
            TextBox_Y.BackColor = Color.AliceBlue
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    ''' <summary>
    ''' Loads the data entry row with the Temp and Press data in the DataViewGrid row using the values found in the previous row.
    ''' </summary>

    Private Sub Load_TP(row As System.Data.DataRow)
        Try
            TextBox_Temperature.Text = row.Item("Temp")
            TextBox_Pressure.Text = row.Item("Press")
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' The next two subroutines check to see if any of the readings entered have changed and changes the average as needed.
    ''' </summary>

    Private Sub TextBox_Reading1_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Reading1.TextChanged
        Dim read1 As Double, read2 As Double

        If (Double.TryParse(TextBox_Reading1.Text, read1) And Double.TryParse(TextBox_Reading2.Text, read2)) Then
            TextBox_Average.Text = (read1 + read2) / 2

        End If
    End Sub

    Private Sub TextBox_Reading2_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Reading2.TextChanged
        Dim read1 As Double, read2 As Double

        If (Double.TryParse(TextBox_Reading1.Text, read1) And Double.TryParse(TextBox_Reading2.Text, read2)) Then
            TextBox_Average.Text = (read1 + read2) / 2
        End If
    End Sub


    ''' <summary>
    ''' Code for going back to the Data To Collect page if use selects the Back Button
    ''' </summary>

    Private Sub Button_Back_Click(sender As Object, e As EventArgs) Handles Button_Back.Click
        DataToCollect.Show()
        Me.Close()
    End Sub


    ''' <summary>
    ''' Code for exiting the program based on user selection of Exit Button
    ''' </summary>

    Private Sub Button_Exit_Click(sender As Object, e As EventArgs) Handles Button_Exit.Click
        Dim ExitYN As System.Windows.Forms.DialogResult
        ExitYN = MsgBox("Do you really want to exit?", MsgBoxStyle.YesNo)
        If ExitYN = MsgBoxResult.Yes Then
            Application.Exit()
            End
        Else
        End If
    End Sub


    'Private Sub Button_Enter_Click_1(sender As Object, e As EventArgs) Handles Button_Select.Click
    '    If (DataGridView_Scp.SelectedCells().Count > 0) Then
    '       Load_Row_Enter(scpData.Rows(DataGridView_Scp.SelectedCells(0).RowIndex))
    '   End If
    ' End Sub


    ''' <summary>
    ''' Loads the X and Y entries of the currently selected DGV row into the data entry row.
    ''' </summary>

    Private Sub Load_Row_Enter(row As System.Data.DataRow)
        Try
            currentRowIndex = row.Item("Row") - 1
            TextBox_X.Text = row.Item("X")
            TextBox_Y.Text = row.Item("Y")
            '  TextBox_Reading1.Text = row.Item("Reading1")
            '  TextBox_Reading2.Text = row.Item("Reading2")
            '  TextBox_Average.Text = row.Item("Average")
            '  TextBox_Scp.Text = row.Item("Scp")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' Skips the Panel_Stability tests if the user chooses. Also called after stability is reached.
    ''' </summary>

    Private Sub Button_Skip_Click(sender As Object, e As EventArgs) Handles Button_Skip.Click
        Dim testRowItem As String
        Dim i As Integer
        Dim readingsTolerance As Double
        Panel_Stability.Visible = False
        GroupBox_Stability.Visible = False

        Panel_Data.Visible = True
        DataGridView_Factors.Visible = True
        DataGridView_Factors.Columns("RowKey").Visible = False
        DataGridView_Factors.ReadOnly = True
        DataGridView_Factors.Enabled = True
        DataGridView_Factors.ClearSelection()

        'This loop highlights the DGV rows when a SmallField is the measurement

        For i = 0 To scpData.Rows.Count() - 1
            testRowItem = scpData.Rows(i)("SmallField").ToString()
            If testRowItem = "Yes" Then
                Me.DataGridView_Factors.Rows(i).DefaultCellStyle.BackColor = Color.Cornsilk
            End If
        Next

        'This loop stops when a blank entry is found for Reading1 and that row is selected as the point where the user 
        'starts entering data. Establishes the currentRowIndex.

        For i = 0 To scpData.Rows.Count() - 1
            testRowItem = scpData.Rows(i)("Reading1").ToString()
            If testRowItem = "" Then
                currentRowIndex = i
                Me.DataGridView_Factors.Rows(currentRowIndex).DefaultCellStyle.BackColor = Color.AliceBlue
                Load_XYRow_Edit(scpData.Rows(currentRowIndex))
                If currentRowIndex > 0 Then
                    Load_TP(scpData.Rows(currentRowIndex - 1))
                End If
                Me.DataGridView_Factors.ClearSelection()
                Exit For
            End If
        Next

        If currentRowIndex = 0 Then
            TextBox_Temperature.Select()
        Else
            TextBox_Reading1.Select()
        End If

        ' If DataGridView_Scp is full allow nothing to happen

        If i = scpData.Rows.Count() Then
            DataToCollect.LinkLabel_P1Scp.BackColor = Color.LimeGreen
            Panel_Stability.Visible = False
            GroupBox_Stability.Visible = False
            Panel_Data.Visible = True
            DataGridView_Factors.Visible = True
            DataGridView_Factors.Columns(0).Visible = False
            Me.DataGridView_Factors.ReadOnly = True
            Me.DataGridView_Factors.Enabled = True
            Me.DataGridView_Factors.ClearSelection()
            Button_Enter.Enabled = False
            Button_Edit.Enabled = True
            TextBox_Reading1.ReadOnly = True
            TextBox_Reading2.ReadOnly = True
            TextBox_Temperature.ReadOnly = True
            TextBox_Pressure.ReadOnly = True
        End If

        ' Sets the tolerances

        TextBox_ReadingsTolerance.Text = 0.3
        TextBox_ScpTolerance.Text = 2
        readingsTolerance = TextBox_ReadingsTolerance.Text

        ' checks all Readings to see if they are within tolerance. This check is done each time in the event the tolerance is changed.
        For i = 0 To currentRowIndex - 1
            If Not ReadingTolerance(scpData.Rows(i).Item("Reading1"), scpData.Rows(i).Item("Reading2"), readingsTolerance) Then
                Me.DataGridView_Factors.Rows(i).Cells("Reading1").Style.BackColor = Color.IndianRed
                Me.DataGridView_Factors.Rows(i).Cells("Reading2").Style.BackColor = Color.IndianRed
            Else
                Me.DataGridView_Factors.Rows(i).Cells("Reading1").Style.BackColor = Color.White
                Me.DataGridView_Factors.Rows(i).Cells("Reading2").Style.BackColor = Color.White
            End If
        Next


    End Sub



    ''' <summary>
    ''' The following is to evaluate the entries on Panel_Stability and determine when stability is reached
    ''' </summary>

    Private Sub Button_StabEnter_Click(sender As Object, e As EventArgs) Handles Button_StabEnter.Click
        Dim myLabel As Label = New Label()
        Dim i As Integer
        If reading(1) = 0 Then
            If Not (Double.TryParse(TextBox_StabReading.Text, reading(1))) Then
                MessageBox.Show("Only properly formatted numeric input is accepted.")
                Return
            End If
            myLabel = Me.GroupBox_Stability.Controls("Label" & 1)
            myLabel.Text = reading(1)
            myLabel.Visible = True
            TextBox_StabReading.Clear()
            TextBox_StabReading.Select()
            Return
        End If

        If reading(2) = 0 Then
            If Not (Double.TryParse(TextBox_StabReading.Text, reading(2))) Then
                MessageBox.Show("Only properly formatted numeric input is accepted.")
                Return
            End If
            If reading(2) < reading(1) Then
                turnlower = True
            End If
            myLabel = Me.GroupBox_Stability.Controls("Label" & 2)
            myLabel.Text = reading(2)
            myLabel.Visible = True
            TextBox_StabReading.Clear()
            TextBox_StabReading.Select()
            Return
        End If

        If reading(3) = 0 Then
            If Not (Double.TryParse(TextBox_StabReading.Text, reading(3))) Then
                MessageBox.Show("Only properly formatted numeric input is accepted.")
                Return
            End If
            If reading(3) < reading(2) And Not turnlower Then
                turnlower = True
            End If
            If reading(3) > reading(2) And turnlower Then
                turnhigher = True
            End If
            myLabel = Me.GroupBox_Stability.Controls("Label" & 3)
            myLabel.Text = reading(3)
            myLabel.Visible = True
            TextBox_StabReading.Clear()
            TextBox_StabReading.Select()
            Return
        End If

        i = 4
        For i = 4 To 20
                myLabel = Me.GroupBox_Stability.Controls("Label" & i)
                If reading(i) = 0 Then
                    If Not (Double.TryParse(TextBox_StabReading.Text, reading(i))) Then
                        MessageBox.Show("Only properly formatted numeric input is accepted.")
                        Return
                    End If
                    If reading(i) < reading(i - 1) And Not turnlower Then
                        turnlower = True
                    End If
                    If reading(i) > reading(i - 1) And turnlower And Not turnhigher Then
                        turnhigher = True
                    End If
                    If reading(i) < reading(i - 1) And turnlower And turnhigher Then
                        Panel_Stability.Visible = False
                        GroupBox_Stability.Visible = False
                        If currentRowIndex = 0 Then
                            Button_Skip_Click(sender, e)
                        Else
                            Button_Skip_Click(sender, e)
                        End If
                    Else
                    If i = 20 Then
                        MessageBox.Show("Linac not stable")
                    End If
                    End If
                    myLabel.Text = reading(i)
                    myLabel.Visible = True
                    TextBox_StabReading.Clear()
                    TextBox_StabReading.Select()
                    Return
                End If
        Next
    End Sub

    Private Sub Button_Temperature_Click(sender As Object, e As EventArgs) Handles Button_Temperature.Click
        TextBox_Temperature.ReadOnly = False
        TextBox_Pressure.ReadOnly = False
        TextBox_Temperature.Select()
    End Sub

    Private Sub Button_Pressure_Click(sender As Object, e As EventArgs) Handles Button_Pressure.Click
        TextBox_Temperature.ReadOnly = False
        TextBox_Pressure.ReadOnly = False
        TextBox_Temperature.Select()
    End Sub

    Private Sub TextBox_ReadingsTolerance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_ReadingsTolerance.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Dim i As Integer
            Dim tolerance As Double
            i = 0
            tolerance = TextBox_ReadingsTolerance.Text
            For i = 0 To currentRowIndex - 1
                If Not ReadingTolerance(scpData.Rows(i).Item("Reading1"), scpData.Rows(i).Item("Reading2"), tolerance) Then
                    Me.DataGridView_Factors.Rows(i).Cells("Reading1").Style.BackColor = Color.IndianRed
                    Me.DataGridView_Factors.Rows(i).Cells("Reading2").Style.BackColor = Color.IndianRed
                Else
                    If scpData.Rows(i).Item("SmallField") <> "Yes" Then
                        Me.DataGridView_Factors.Rows(i).Cells("Reading1").Style.BackColor = Color.White
                        Me.DataGridView_Factors.Rows(i).Cells("Reading2").Style.BackColor = Color.White
                    Else
                        Me.DataGridView_Factors.Rows(i).Cells("Reading1").Style.BackColor = Color.Cornsilk
                        Me.DataGridView_Factors.Rows(i).Cells("Reading2").Style.BackColor = Color.Cornsilk
                    End If
                End If
            Next
            TextBox_Reading1.Select()
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_StabReading_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_StabReading.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Button_StabEnter_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub Panel_Title_Paint(sender As Object, e As PaintEventArgs) Handles Panel_Title.Paint

    End Sub
End Class