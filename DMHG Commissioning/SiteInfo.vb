Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class Form_SiteInfo
    Dim MySqlConn As MySqlConnection= New MySqlConnection(ConfigurationManager.ConnectionStrings("sites").ConnectionString)

    Private Sub Form_Site_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim command As New MySqlCommand
        Dim reader As MySqlDataReader
        Dim existingSiteAdapter As MySqlDataAdapter
        Dim setupinfoRowCheck As New DataTable()
        Dim factorsDBConn As MySqlConnection

        Set_Site(activeSite)
        Username.Text = activeUser

        'Open the database and make setupinfoRowData equal to setupinfo table.

        factorsDBConn = New MySqlConnection(ConfigurationManager.ConnectionStrings("noDB").ConnectionString & "database=" & activeSite.factors)
        Try
            factorsDBConn.Open()
            existingSiteAdapter = New MySqlDataAdapter("SELECT * FROM setupinfo", factorsDBConn)
            existingSiteAdapter.Fill(setupinfoRowCheck)
            existingSiteAdapter.Dispose()
            If setupinfoRowCheck.Rows.Count() = 0 Then
                ConfigSaved(activeSite, "False")
                sitesaved = "False"
            End If
        Catch ex As Exception
            MessageBox.Show("Error trying to set setupinfoRowCheck to setupinfo table " & ex.Message)
        Finally
            factorsDBConn.Close()
        End Try

        Try
            MySqlConn.Open()
            command.Connection = MySqlConn
            command.CommandText = "SELECT * FROM  `" & activeSite.factors & "`.setupinfo WHERE RowKey = 1;"
            command.Prepare()
            reader = command.ExecuteReader()
            reader.Read()
            sitesaved = reader.Item("SiteSaved")
            reader.Close()
        Catch ex As MySqlException
            Me.Cursor = Cursors.AppStarting
            MessageBox.Show("Error when checking configuration saved: " & ex.Message)
        Finally
            MySqlConn.Close()
        End Try

        If (sitesaved) Then
            Button_Configuration.Enabled = False
            Button_StartContinue.Enabled = True
        Else
            Button_Configuration.Enabled = True
            Button_StartContinue.Enabled = False
        End If

    End Sub

    Private Sub Button_Exit_Click(sender As System.Object, e As System.EventArgs) Handles Button_Exit.Click
        Dim ExitYN As System.Windows.Forms.DialogResult
        ExitYN = MsgBox("Do you really want to exit?", MsgBoxStyle.YesNo)
        If ExitYN = MsgBoxResult.Yes Then
            Application.Exit()
            End
        Else
        End If
    End Sub

    Private Sub Button_Back_Click(sender As System.Object, e As System.EventArgs) Handles Button_Back.Click
        Form_Login.Show()
        Me.Close()
    End Sub


    ''' <summary>
    ''' Loads the information of the site given into the form.
    ''' </summary>
    ''' <param name="site">The site whose information is to be displayed.</param>
    ''' <remarks></remarks>

    Public Sub Set_Site(site As Site)
        SiteName.Text = site.siteName
        LinacModel.Text = site.linacModel
        Serial.Text = site.linacSerial
        activeSiteName = "Linac: " & site.linacModel & "            Serial #: " & site.linacSerial
        PhotonEnergies.Text = ""
        For i As Integer = 0 To site.nPEnergies - 1
            If (i = 0) Then
                PhotonEnergies.Text = site.pEnergyNames(i)
            Else
                PhotonEnergies.Text = PhotonEnergies.Text & ", " & site.pEnergyNames(i)
            End If
        Next

        ElectronEnergies.Text = ""
        For i As Integer = 0 To site.nEEnergies - 1
            If (i = 0) Then
                ElectronEnergies.Text = site.eEnergyNames(i)
            Else
                ElectronEnergies.Text = ElectronEnergies.Text & ", " & site.eEnergyNames(i)
            End If
        Next

        RTPSystems.Text = ""
        For i As Integer = 0 To site.nRTP - 1
            If (i = 0) Then
                RTPSystems.Text = site.RTPNames(i)
            Else
                RTPSystems.Text = RTPSystems.Text & ", " & site.RTPNames(i)
            End If
        Next

    End Sub

    Private Sub Button_EditSiteData_Click(sender As Object, e As EventArgs) Handles Button_EditSiteData.Click
        Form_EditSite.Show()
        Me.Close()
    End Sub

    Private Sub Button_StartContinue_Click(sender As Object, e As EventArgs) Handles Button_StartContinue.Click
        DataToCollect.Show()
        Me.Close()
    End Sub


    ''' <summary>
    ''' Saves the Configuration data
    ''' </summary>
    ''' 
    Private Sub Button_Configuration_Click(sender As Object, e As EventArgs) Handles Button_Configuration.Click
        Dim result As DialogResult
        result = MessageBox.Show(" Once the Configuration Tables are created, it will not be possible to do any further edits for this site. Do you want to continue?", "Caution", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            Return
        Else
            Me.Cursor = Cursors.WaitCursor
            Try
                MySqlConn.Open()
                Form_EditSite.Fill_SelectedConfiguration_Tables(activeSite, MySqlConn)
                Button_StartContinue.Enabled = True
                Button_Configuration.Enabled = False
                ConfigUpdated(activeSite, "True")
                sitesaved = True
                MessageBox.Show("Configuration Tables created")
            Catch ex As Exception
                MessageBox.Show("Error creating Configuration Tables. " & ex.Message)
            Finally
                MySqlConn.Close()
            End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub



    ''' <summary>
    ''' Sets column SiteSaved entry to "result" value in siteinfo table
    ''' </summary>
    ''' <remarks></remarks>

    Private Function ConfigSaved(site As Site, result As Boolean) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        MySqlConn = New MySqlConnection(ConfigurationManager.ConnectionStrings("sites").ConnectionString)

        Try
            MySqlConn.Open()
            insertFactorsCommand.Connection = MySqlConn

            insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.setupinfo (RowKey, Row, SiteSaved, Measurement, Setup, " & _
                        "SSD, SCD, Electrometer, ElectSerial, Detector, DetectorSerial, RefDetector, RefDetectorSerial, SmallFieldDetector, SmallFieldDetectorSerial, " & _
                        " MeasurementSystem, MeasurementSystemSerial, Barometer, Barometerserial, Thermometer, ThermometerSerial)" & _
                        "VALUES (@RowKey, @Row, @SiteSaved, @Measurement, @Setup, @SSD, @SCD, @Electrometer, @ElectSerial, " & _
                        "@Detector, @DetectorSerial, @RefDetector, @RefDetectorSerial, @SmallFieldDetector, @SmallFieldDetectorSerial, @MeasurementSystem, @MeasurementSystemSerial, @Barometer, " & _
                        "@Barometerserial, @Thermometer, @ThermometerSerial)"

            insertFactorsCommand.Prepare()
            insertFactorsCommand.Parameters.AddWithValue("RowKey", 1)
            insertFactorsCommand.Parameters.AddWithValue("Row", 1)
            insertFactorsCommand.Parameters.AddWithValue("SiteSaved", result)
            insertFactorsCommand.Parameters.AddWithValue("Measurement", "")
            insertFactorsCommand.Parameters.AddWithValue("Setup", "")

            insertFactorsCommand.Parameters.AddWithValue("SSD", 100)
            insertFactorsCommand.Parameters.AddWithValue("SCD", 100)
            insertFactorsCommand.Parameters.AddWithValue("Electrometer", "")
            insertFactorsCommand.Parameters.AddWithValue("ElectSerial", "")
            insertFactorsCommand.Parameters.AddWithValue("Detector", "")

            insertFactorsCommand.Parameters.AddWithValue("DetectorSerial", "")
            insertFactorsCommand.Parameters.AddWithValue("RefDetector", "")
            insertFactorsCommand.Parameters.AddWithValue("RefDetectorSerial", "")
            insertFactorsCommand.Parameters.AddWithValue("SmallFieldDetector", "")
            insertFactorsCommand.Parameters.AddWithValue("SmallFieldDetectorSerial", "")

            insertFactorsCommand.Parameters.AddWithValue("MeasurementSystem", "")
            insertFactorsCommand.Parameters.AddWithValue("MeasurementSystemSerial", "")
            insertFactorsCommand.Parameters.AddWithValue("Barometer", "")
            insertFactorsCommand.Parameters.AddWithValue("BarometerSerial", "")
            insertFactorsCommand.Parameters.AddWithValue("Thermometer", "")

            insertFactorsCommand.Parameters.AddWithValue("ThermometerSerial", "")
            insertFactorsCommand.ExecuteNonQuery()
            insertFactorsCommand.Parameters.Clear()

        Catch ex As Exception
            MessageBox.Show("Error saving SiteSaved entry in setupinfo table " & ex.Message)
        Finally
            MySqlConn.Close()
        End Try
        Return True
    End Function



    ''' <summary>
    ''' Updates column SiteSaved entry to True in row 1 of siteinfo table
    ''' </summary>
    ''' <remarks></remarks>

    Private Function ConfigUpdated(site As Site, result As Boolean) As Boolean
        Dim updateCommand As New MySqlCommand
        MySqlConn = New MySqlConnection(ConfigurationManager.ConnectionStrings("sites").ConnectionString)

        Try
            MySqlConn.Open()
            updateCommand.Connection = MySqlConn
            updateCommand.CommandText = "UPDATE `" & site.factors & "`.setupinfo SET SiteSaved=@SiteSaved WHERE RowKey=1;"
            updateCommand.Prepare()
            updateCommand.Parameters.AddWithValue("SiteSaved", result)
            updateCommand.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Error saving SiteSaved entry in setupinfo table " & ex.Message)
        Finally
            MySqlConn.Close()
        End Try
        Return True
    End Function
   
    Private Sub Button_Import_Click(sender As Object, e As EventArgs) Handles Button_ImportExport.Click
        SNCSysImport.Show()
    End Sub

    Private Sub Button_ImportDatabase_Click(sender As Object, e As EventArgs) Handles Button_ImportDatabase.Click

    End Sub

End Class
