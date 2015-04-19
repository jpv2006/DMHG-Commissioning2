Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class Form_EditSite
    ' Dim MySqlConn As MySqlConnection
    Dim RTPSystems(2) As String
    Dim phoneNumber As String
    Dim currentSite As Site
    Dim factorsDBConn As MySqlConnection
    Dim currentRowIndex As Integer
    Dim scpData As New DataTable()
    Dim MySqlConn As MySqlConnection

    Private Sub Form_EditSite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MySqlConn = New MySqlConnection(ConfigurationManager.ConnectionStrings("sites").ConnectionString)

        pEnergyNames.Initialize()
        eEnergyNames.Initialize()
        RTPSystems.Initialize()

        If (activeSite IsNot Nothing) Then
            currentSite = activeSite
            Fill_Form(activeSite)
            If (sitesaved) Then
                Button_Save.Enabled = False
                Button_SaveAndExit.Enabled = False
            End If
        End If

    End Sub

    ''' <summary>
    ''' Fills the form with a site's information.
    ''' </summary>
    ''' <param name="site">The site whose information is to populate the form.</param>
    ''' <remarks></remarks>
    Private Sub Fill_Form(site As Site)
        TextBox_SiteName.Text = site.siteName
        TextBox_StreetAddress.Text = site.streetAddress
        TextBox_City.Text = site.city
        ComboBox_State.Text = site.state
        TextBox_Zip.Text = site.zip
        ComboBox_Country.Text = site.country
        TextBox_PhysicistContact.Text = site.physicist

        Try
            TextBox_Phone_A.Text = site.phone.Substring(0, site.phone.IndexOf("-"))
            TextBox_Phone_F.Text = site.phone.Substring(site.phone.IndexOf("-") + 1, 3)
            TextBox_Phone_L.Text = site.phone.Substring(site.phone.LastIndexOf("-") + 1)
        Catch ex As Exception
            MessageBox.Show("Error in loading phone number.")
        End Try

        ComboBox_LinacManufacturer.Text = site.linacManufacturer
        ComboBox_LinacModel.Text = site.linacModel
        TextBox_LinacSerial.Text = site.linacSerial

        Try
            For Each pE As String In site.pEnergyNames
                Select Case pE
                    Case CheckBox_P_6X.Text
                        CheckBox_P_6X.Checked = True
                    Case CheckBox_P_10X.Text
                        CheckBox_P_10X.Checked = True
                    Case CheckBox_P_15X.Text
                        CheckBox_P_15X.Checked = True
                    Case CheckBox_P_16X.Text
                        CheckBox_P_16X.Checked = True
                    Case CheckBox_P_18X.Text
                        CheckBox_P_18X.Checked = True
                    Case CheckBox_P_23X.Text
                        CheckBox_P_23X.Checked = True
                    Case CheckBox_P_6XFFF.Text
                        CheckBox_P_6XFFF.Checked = True
                    Case CheckBox_P_10XFFF.Text
                        CheckBox_P_10XFFF.Checked = True
                    Case CheckBox_P_6XSRS.Text
                        CheckBox_P_6XSRS.Checked = True
                End Select
            Next
        Catch ex As Exception
            MessageBox.Show("Error in loading photon energies.")
        End Try

        Try
            For Each eE As String In site.eEnergyNames
                Select Case eE
                    Case CheckBox_E_4e.Text
                        CheckBox_E_4e.Checked = True
                    Case CheckBox_E_6e.Text
                        CheckBox_E_6e.Checked = True
                    Case CheckBox_E_8e.Text
                        CheckBox_E_8e.Checked = True
                    Case CheckBox_E_9e.Text
                        CheckBox_E_9e.Checked = True
                    Case CheckBox_E_10e.Text
                        CheckBox_E_10e.Checked = True
                    Case CheckBox_E_12e.Text
                        CheckBox_E_12e.Checked = True
                    Case CheckBox_E_15e.Text
                        CheckBox_E_15e.Checked = True
                    Case CheckBox_E_16e.Text
                        CheckBox_E_16e.Checked = True
                    Case CheckBox_E_18e.Text
                        CheckBox_E_18e.Checked = True
                    Case CheckBox_E_21e.Text
                        CheckBox_E_21e.Checked = True
                End Select
            Next
        Catch ex As Exception
            MessageBox.Show("Error in loading electron energies.")
        End Try

        ComboBox_nRTP.Text = site.nRTP

        Try
            For i As Integer = 0 To site.nRTP - 1
                Select Case i + 1
                    Case 1
                        ComboBox_RTP1.Text = site.RTPNames(i)
                    Case 2
                        ComboBox_RTP2.Text = site.RTPNames(i)
                    Case 3
                        ComboBox_RTP3.Text = site.RTPNames(i)
                End Select
            Next

        Catch ex As Exception
            MessageBox.Show("Error in loading RTP systems")
        End Try
    End Sub


    ''' <summary>
    ''' Save the site's information.
    ''' </summary>

    Private Sub Button_Save_Click(sender As System.Object, e As System.EventArgs) Handles Button_Save.Click
        Me.Cursor = Cursors.WaitCursor
        Dim command As New MySqlCommand
        Dim site As New Site
        'Dim dialogRes As Integer

        If (Not Fill_Site(site)) Then

            Me.Cursor = Cursors.Default
            Return

            ' ElseIf (currentSite IsNot Nothing) Then

            ' If (currentSite.Equals(site)) Then

            'MessageBox.Show("This site has already been saved, edit a value to save again.")
            'Me.Cursor = Cursors.Default
            'Return
            'End If

        End If

        Edit_Site(site)
        Me.Cursor = Cursors.Default
    End Sub


    ''' <summary>
    ''' Attempts to edit the site.
    ''' </summary>
    ''' <param name="site">Site to edit.</param>
    ''' <remarks></remarks>

    Private Sub Edit_Site(site As Site)
        If (Site_Exists(site)) Then
            If (Update_Site(site)) Then
                MessageBox.Show("Site Updated")
                currentSite = site
                activeSite = site
            Else
                MessageBox.Show("Site Not Updated")
            End If
        Else
            If (Save_Site(site)) Then
                MessageBox.Show("Site Saved")
                currentSite = site
                activeSite = site
            Else
                MessageBox.Show("Site Not Saved")
            End If
        End If
    End Sub


    ''' <summary>
    ''' Fills the given site with the information in the form.
    ''' </summary>
    ''' <param name="site">The site to fill.</param>
    ''' <returns>The success of filling the site.</returns>
    ''' <remarks></remarks>

    Private Function Fill_Site(site As Site) As Boolean
        pEnergyNum = 0
        eEnergyNum = 0
        phoneNumber = "--"
        Array.Clear(pEnergyNames, 0, pEnergyNames.Length)
        Array.Clear(eEnergyNames, 0, eEnergyNames.Length)
        Array.Clear(RTPSystems, 0, RTPSystems.Length)

        For Each c As Control In Me.Controls

            If (Not Parse_Control(c)) Then

                Me.Cursor = Cursors.Default
                Return False
            End If
        Next
        If (pEnergyNum = 0) Then
            MessageBox.Show("A least one photon energy must be chosen.")
            Return False
        End If
        site.Fill(TextBox_SiteName.Text, TextBox_StreetAddress.Text, TextBox_City.Text, TextBox_Zip.Text, ComboBox_State.Text, ComboBox_Country.Text, _
                                         TextBox_PhysicistContact.Text, phoneNumber, _
                                         ComboBox_LinacManufacturer.Text, ComboBox_LinacModel.Text, TextBox_LinacSerial.Text, _
                                         pEnergyNum, pEnergyNames, _
                                         eEnergyNum, eEnergyNames, _
                                         ComboBox_nRTP.Text, RTPSystems)
        If (currentSite IsNot Nothing) Then
            site.factors = currentSite.factors
            site.dbID = currentSite.dbID
        End If

        Return True
    End Function


    ''' <summary>
    ''' Parses a form control to data that can easily be stored in a site.
    ''' </summary>
    ''' <param name="c">The control to parse.</param>
    ''' <returns>The success of the parsing.</returns>
    ''' <remarks></remarks>

    Private Function Parse_Control(c As Control) As Boolean
        If (c.Enabled = True) Then
            Select Case c.GetType()
                Case GetType(CheckBox)
                    Return Parse_Control(TryCast(c, CheckBox))
                Case GetType(TextBox)
                    Return Parse_Control(TryCast(c, TextBox))
                Case GetType(ComboBox)
                    Return Parse_Control(TryCast(c, ComboBox))
            End Select
        End If

        Return True
    End Function


    ''' <summary>
    ''' Parse a CheckBox control to data that can easily be stored in a site.
    ''' </summary>
    ''' <param name="cb">The checkbox to parse.</param>
    ''' <returns>The success of the parsing.</returns>
    ''' <remarks></remarks>

    Private Function Parse_Control(cb As CheckBox)
        If (cb.Checked) Then
            If (cb.Name.Contains("P")) Then
                pEnergyNum += 1
                If (pEnergyNum > pEnergyNames.Length) Then
                    MessageBox.Show("Too many photon energies chosen.")
                    Return False
                End If
                pEnergyNames(pEnergyNum - 1) = cb.Text
            ElseIf (cb.Name.Contains("E")) Then
                eEnergyNum += 1
                If (eEnergyNum > eEnergyNames.Length) Then
                    MessageBox.Show("Too many electron energies chosen.")
                    Return False
                End If
                eEnergyNames(eEnergyNum - 1) = cb.Text
            End If
        End If
        Return True
    End Function


    ''' <summary>
    ''' Parses a TextBox control to data that can easily be stored in a site.
    ''' </summary>
    ''' <param name="tb">The TextBox to parse.</param>
    ''' <returns>The success of the parsing.</returns>
    ''' <remarks></remarks>

    Private Function Parse_Control(tb As TextBox) As Boolean

        ' Checks that textbox items filled in

        If tb.Name.Contains("SiteName") Or tb.Name.Contains("StreetAddress") Or tb.Name.Contains("City") Or tb.Name.Contains("Zip") Or
            tb.Name.Contains("PhysicistContact") Or tb.Name.Contains("Phone") Or tb.Name.Contains("LinacSerial") Then
            If tb.Text.Length = 0 Then
                MessageBox.Show("All items are required.")
                Return False
            End If
        End If

        ' Checks for complete phone number

        If (tb.Name.Contains("Phone")) Then
            If (tb.Text.Length < 3) Then
                MessageBox.Show("A complete phone number is required.")
                Return False
            ElseIf (Not IsNumeric(tb.Text)) Then
                MessageBox.Show("A Phone number may only contain numbers.")
                Return False
            End If

            If (tb.Name.EndsWith("A")) Then
                phoneNumber = phoneNumber.Remove(0, phoneNumber.IndexOf("-"))
                phoneNumber = phoneNumber.Insert(0, tb.Text)
            ElseIf (tb.Name.EndsWith("F")) Then
                phoneNumber = phoneNumber.Remove(phoneNumber.IndexOf("-") + 1, phoneNumber.LastIndexOf("-") - (phoneNumber.IndexOf("-") + 1))
                phoneNumber = phoneNumber.Insert(phoneNumber.IndexOf("-") + 1, tb.Text)
            ElseIf (tb.Name.EndsWith("L")) Then
                If (tb.Text.Length < 4) Then
                    MessageBox.Show("A complete phone number is required.")
                    Return False
                End If

                If (Not phoneNumber.LastIndexOf("-") + 1 = phoneNumber.Length) Then
                    phoneNumber = phoneNumber.Remove(phoneNumber.LastIndexOf("-") + 1)
                End If

                phoneNumber = phoneNumber.Insert(phoneNumber.LastIndexOf("-") + 1, tb.Text)

            End If

            ' Checks for complete zip code

        ElseIf (tb.Name.Contains("Zip")) Then
            If (tb.Text.Length < 5) Then
                MessageBox.Show("A complete five digit zip code is required.")
                Return False
            ElseIf (Not IsNumeric(tb.Text)) Then
                MessageBox.Show("A zip code may only contain numbers.")
                Return False
            End If

        End If

        tb.Text = tb.Text.Trim

        Return True
    End Function


    ''' <summary>
    ''' Parses a ComboBox Control to data that can easily be stored in a site.
    ''' </summary>
    ''' <param name="cob">The ComboBox to parse.</param>
    ''' <returns>The success of the parsing.</returns>
    ''' <remarks></remarks>

    Private Function Parse_Control(cob As ComboBox)
        Dim RTPSysNumber As Integer

        ' Checks that combobox items filled in

        If cob.Name.Contains("State") Or cob.Name.Contains("Country") Or cob.Name.Contains("LinacManufacturer") Or cob.Name.Contains("LinacModel") Then
            If cob.Text.Length = 0 Then
                MessageBox.Show("All items are required.")
                Return False
            End If
        End If

        If ComboBox_nRTP.Text = "" Then
            MessageBox.Show("Please select number of RTP systems")
            Return False
        End If

        If (cob.Name.Contains("_RTP")) Then
            RTPSysNumber = Microsoft.VisualBasic.Val(cob.Name(cob.Name.Length - 1))

            If (RTPSysNumber <= ComboBox_nRTP.Text) Then
                If (cob.Text.Length = 0) Then
                    MessageBox.Show("Please specify all RTP machines.")
                    Return False
                End If
            End If

            RTPSystems(RTPSysNumber - 1) = cob.Text

        End If

        Return True
    End Function


    ''' <summary>
    ''' Formats a database name for the site's data database
    ''' </summary>
    ''' <param name="site">The site to use.</param>
    ''' <returns>The appropriate name for the site's data database.</returns>
    ''' <remarks>This does not create the data database.</remarks>

    Private Function Create_Site_Database_Name(site As Site) As String
        Dim databaseName As String = ""

        databaseName = site.dbID & "_Data"

        Return databaseName
    End Function

    '-----------------------------------------------currently not used ------------------------------------------------------
    ''' <summary>
    ''' Checks if the site already exists in the database.
    ''' </summary>
    ''' <param name="site">Site to check for.</param>
    ''' <returns>Whether the site exists.</returns>
    ''' <remarks></remarks>

    Private Function Site_Exists(site As Site) As Boolean
        Dim command As New MySqlCommand
        Dim reader As MySqlDataReader
        Dim exists As Boolean

        Try
            MySqlConn.Open()

            command.Connection = MySqlConn
            command.CommandText = "SELECT * FROM sites.siteinfo WHERE idsiteinfo=@idsiteinfo;"

            command.Prepare()

            Add_Command_Parameters(command, site)

            reader = command.ExecuteReader()

            exists = reader.Read()

            reader.Close()
        Catch ex As MySqlException
            Me.Cursor = Cursors.AppStarting
            MessageBox.Show("Error when checking if the site already exists in the database: " & ex.Message)
        Finally
            MySqlConn.Close()
        End Try

        Return exists
    End Function


    ''' <summary>
    ''' Attempts to update the site's entry in the database.
    ''' </summary>
    ''' <param name="site">Site to update.</param>
    ''' <returns>Success of update.</returns>
    ''' <remarks></remarks>

    Private Function Update_Site(site As Site) As Boolean

        If (MessageBox.Show("This site already exists in the database, would you like to overwrite it?" _
                        , "Site Already Exists", MessageBoxButtons.YesNo) = DialogResult.Yes) Then

            Drop_Table_PhotonFactors(site)
            Try
                MySqlConn.Open()
                Generate_Update_Site_Command(site, MySqlConn).ExecuteNonQuery()
            Catch ex As MySqlException
                Me.Cursor = Cursors.AppStarting
                MessageBox.Show("Error in udpating site: " & ex.Message)
                Return False
            Finally
                MySqlConn.Close()
            End Try
            Create_Table_PhotonFactors(site)
        Else
            Me.Cursor = Cursors.Default
            Return False
        End If

        

        Return True
    End Function

      ''' <summary>
    ''' Attempts to save the site in the database and create the data tables.
    ''' </summary>
    ''' <param name="site">Site to save.</param>
    ''' <returns>Success of save.</returns>
    ''' <remarks></remarks>

    Private Function Save_Site(site As Site) As Boolean
        Dim command As New MySqlCommand
        Dim reader As MySqlDataReader

        Try
            MySqlConn.Open()
            Generate_Insert_Site_Command(site, MySqlConn).ExecuteNonQuery()
            Me.Cursor = Cursors.Default
        Catch ex As MySqlException
            Me.Cursor = Cursors.AppStarting
            MessageBox.Show("Error in saving site: " & ex.Message)
            Return False
        Finally
            MySqlConn.Close()
        End Try

        'Gets the database-generated id for the site
        Try
            MySqlConn.Open()
            command.Connection = MySqlConn
            command.CommandText = "SELECT * FROM sites.siteinfo WHERE SiteName=@SiteName AND StreetAddress=@StreetAddress AND City=@City AND State=@State AND Zip=@Zip AND Country=@Country;"
            command.Prepare()
            Add_Command_Parameters(command, site)
            reader = command.ExecuteReader()
            reader.Read()
            site.dbID = reader.Item("idsiteinfo")
            reader.Close()
        Catch ex As MySqlException
            MessageBox.Show("Error in retrieving the site's new ID from database: " & ex.Message)
        Finally
            MySqlConn.Close()
        End Try

        ' Create the #_data (the name in site.factors) database for the site
        Try
            MySqlConn.Open()
            command = New MySqlCommand()
            command.Connection = MySqlConn
            site.factors = Create_Site_Database_Name(site)
            command.CommandText = "CREATE DATABASE `" & MySqlHelper.EscapeString(site.factors) & "`; UPDATE sites.siteinfo SET Factors=@Factors WHERE idsiteinfo=@idsiteinfo"
            command.Prepare()
            Add_Command_Parameters(command, site)
            command.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error creating site data database: " & ex.Message)
        Finally
            MySqlConn.Close()
        End Try


        ' Creates the tables for scp, scp2, sc, wf, edwf (Varian Enhanced Dynamic WF), mwf (Elekta Motorized WF), mlcdlg (Dosimetric Leaf Gap), 
        ' mlctf (mlc Transmission Factor), accessoryTF

        Create_Table_PhotonFactors(site)

        ' Creates the tables for pdd_photons, pdd_photons_cones, pdd_photons_mlc, 
        ' tmr_photons, tmr_photons_cones, tmr_photons_mlc,
        ' cp_photons, ip_photons, dp_photons, 
        ' pdd_wedge, cp_wedge, ip_wedge, pdd_mwedge (Elekta motorized wedge), cp_mwedge, ip_mwedge,

        Create_Table_PhotonScans(site)


        ' Creates the tables for of_electrons_100, of_electrons_105, of_electrons_110, cutoutTF

        Create_Table_ElectronFactors(site)


        ' Creates the tables for ' pdd_electrons, cp_electrons, ip_electrons, cp_electron_air

        Create_Table_ElectronScans(site)


        ' Creates the tables which holds the setup information on all factors and scans

        Create_Table_SetupInfo(site)

        Return True
    End Function

    ' ----------------------------------------------------currently not used--------------------------------------------

    ''' <summary>
    ''' Sets column SiteSaved entry to False in siteinfo table
    ''' </summary>
    ''' <remarks></remarks>

    Private Function ConfigSaved(site As Site) As Boolean
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
            insertFactorsCommand.Parameters.AddWithValue("SiteSaved", "False")
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
    ''' Checks to see if a table exists in Database or not.
    ''' </summary>
    ''' <param name="tblName">Table name to check</param>
    ''' <remarks></remarks>

    Private Function DoesTableExist(ByVal tblName As String, site As Site) As Boolean
        Dim command As New MySqlCommand
        Dim restrictions(3) As String
        factorsDBConn = New MySqlConnection(ConfigurationManager.ConnectionStrings("noDB").ConnectionString & "database=" & site.factors)
        factorsDBConn.Open()

        ' Specify restriction to get table definition schema

        restrictions(2) = tblName
        Dim dbTbl As DataTable = factorsDBConn.GetSchema("Tables", restrictions)

        If dbTbl.Rows.Count = 0 Then
            'Table does not exist
            DoesTableExist = False
        Else
            'Table exists
            DoesTableExist = True
        End If

        dbTbl.Dispose()
        factorsDBConn.Close()
        factorsDBConn.Dispose()
    End Function


    ''' <summary>
    ''' Creates the tables for scp, scp2, sc, wf, edwf (Varian Enhanced Dynamic WF), mwf (Elekta Motorized WF), mlcdlg (Dosimetric Leaf Gap), 
    ''' mlctf (mlc Transmission Factor), accessoryTF
    ''' </summary>
    ''' 
    Private Function Create_Table_PhotonFactors(site As Site) As Boolean
        Dim command As New MySqlCommand
        Dim exists As Boolean = False

        Try
            MySqlConn.Open()
            command = New MySqlCommand()
            command.Connection = MySqlConn
            command.CommandText = "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_scp (RowKey INT NOT NULL , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(7) null , " & _
                "SSD INT NULL , " & _
                "SmallField Varchar(3) null , " & _
                "X INT NULL , " & _
                "Y INT NULL , " & _
                "Reading1 DOUBLE NULL , " & _
                "Reading2 DOUBLE NULL , " & _
                "Average DOUBLE NULL , " & _
                "Scp DOUBLE NULL , " & _
                "Temp DOUBLE NULL , " & _
                "Press DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_scp2 (RowKey INT NOT NULL , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(7) null , " & _
                "SSD INT NULL , " & _
                "SmallField Varchar(3) null , " & _
                "X INT NULL , " & _
                "Y INT NULL , " & _
                "Reading1 DOUBLE NULL , " & _
                "Reading2 DOUBLE NULL , " & _
                "Average DOUBLE NULL , " & _
                "Scp DOUBLE NULL , " & _
                "Temp DOUBLE NULL , " & _
                "Press DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_sc (RowKey INT NOT NULL , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(7) null , " & _
                "SDD INT NULL , " & _
                "SmallField Varchar(3) null , " & _
                "X INT NULL , " & _
                "Y INT NULL , " & _
                "Reading1 DOUBLE NULL , " & _
                "Reading2 DOUBLE NULL , " & _
                "Average DOUBLE NULL , " & _
                "Sc DOUBLE NULL , " & _
                "Temp DOUBLE NULL , " & _
                "Press DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_wedgefactors (RowKey INT NOT NULL , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(7) null , " & _
                "SSD INT NULL , " & _
                "WedgeAngle INT NULL , " & _
                "Direction varchar(8) NULL , " & _
                "X INT NULL , " & _
                "Y INT NULL , " & _
                "Reading1 DOUBLE NULL , " & _
                "Reading2 DOUBLE NULL , " & _
                "Average DOUBLE NULL , " & _
                "WF DOUBLE NULL , " & _
                "WOF DOUBLE NULL , " & _
                "Temp DOUBLE NULL , " & _
                "Press DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_edw_factors (RowKey INT NOT NULL , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(7) null , " & _
                "SSD INT NULL , " & _
                "X INT NULL , " & _
                "Y INT NULL , " & _
                "Reading1 DOUBLE NULL , " & _
                "Reading2 DOUBLE NULL , " & _
                "Average DOUBLE NULL , " & _
                "EDW_WF DOUBLE NULL , " & _
                "Temp DOUBLE NULL , " & _
                "Press DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_mwedge_factors (RowKey INT NOT NULL , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(7) null , " & _
                "SSD INT NULL , " & _
                "X INT NULL , " & _
                "Y INT NULL , " & _
                "Reading1 DOUBLE NULL , " & _
                "Reading2 DOUBLE NULL , " & _
                "Average DOUBLE NULL , " & _
                "MW_WF DOUBLE NULL , " & _
                "Temp DOUBLE NULL , " & _
                "Press DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_mlc_dlg (RowKey INT NOT NULL , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(7) null , " & _
                "SSD INT NULL , " & _
                "X INT NULL , " & _
                "Y INT NULL , " & _
                "Reading1 DOUBLE NULL , " & _
                "Reading2 DOUBLE NULL , " & _
                "Average DOUBLE NULL , " & _
                "MLC_LG DOUBLE NULL , " & _
                "Temp DOUBLE NULL , " & _
                "Press DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_mlc_tf (RowKey INT NOT NULL , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(7) null , " & _
                "SSD INT NULL , " & _
                "X INT NULL , " & _
                "Y INT NULL , " & _
                "Reading1 DOUBLE NULL , " & _
                "Reading2 DOUBLE NULL , " & _
                "Average DOUBLE NULL , " & _
                "MLC_TF DOUBLE NULL , " & _
                "Temp DOUBLE NULL , " & _
                "Press DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_accessory_tf (RowKey INT NOT NULL , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(7) null , " & _
                "SSD INT NULL , " & _
                "Depth INT NULL , " & _
                "Accessory DOUBLE NULL , " & _
                "X INT NULL , " & _
                "Y INT NULL , " & _
                "Reading1 DOUBLE NULL , " & _
                "Reading2 DOUBLE NULL , " & _
                "Average DOUBLE NULL , " & _
                "TF DOUBLE NULL , " & _
                "Temp DOUBLE NULL , " & _
                "Press DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC))"
            command.Prepare()
            command.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show("Error creating Factors tables " & ex.Message)
        Finally
            MySqlConn.Close()
        End Try

        ' Fill_PhotonFactors_Tables(site, MySqlConn, 1)

        Return True
    End Function


    ''' <summary>
    ''' Drops the tables for scp, scp2, sc, wf, edwf (Varian Enhanced Dynamic WF), mwf (Elekta Motorized WF), mlcdlg (Dosimetric Leaf Gap), 
    ''' mlctf (mlc Transmission Factor), accessoryTF if site is updated with less tables
    ''' </summary>
    ''' 
    Private Function Drop_Table_PhotonFactors(site As Site) As Boolean
        Dim command As New MySqlCommand

        Try
            MySqlConn.Open()
            command = New MySqlCommand()
            command.Connection = MySqlConn
            command.CommandText = "Drop Table " & site.factors & ".photon_scp;"
            command.Prepare()
            command.ExecuteNonQuery()
            command.CommandText = "Drop Table " & site.factors & ".photon_scp2;"
            command.Prepare()
            command.ExecuteNonQuery()
            command.CommandText = "Drop Table " & site.factors & ".photon_sc;"
            command.Prepare()
            command.ExecuteNonQuery()
            command.CommandText = "Drop Table " & site.factors & ".photon_wedgefactors;"
            command.Prepare()
            command.ExecuteNonQuery()
            command.CommandText = "Drop Table " & site.factors & ".photon_mwedge_factors;"
            command.Prepare()
            command.ExecuteNonQuery()
            command.CommandText = "Drop Table " & site.factors & ".photon_mlc_tf;"
            command.Prepare()
            command.ExecuteNonQuery()
            command.CommandText = "Drop Table " & site.factors & ".photon_mlc_dlg;"
            command.Prepare()
            command.ExecuteNonQuery()
            command.CommandText = "Drop Table " & site.factors & ".photon_edw_factors;"
            command.Prepare()
            command.ExecuteNonQuery()
            command.CommandText = "Drop Table " & site.factors & ".photon_accessory_tf;"
            command.Prepare()
            command.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show("Error dropping Factors tables " & ex.Message)
        Finally
            MySqlConn.Close()
        End Try

        Return True
    End Function


    ''' <summary>
    ''' Creates the tables for pdd_photons, pdd_photons_cones, pdd_photons_mlc, 
    ''' tmr_photons, tmr_photons_cones, tmr_photons_mlc,
    ''' cp_photons, ip_photons, dp_photons, 
    ''' pdd_wedge, cp_wedge, ip_wedge, pdd_mwedge (Elekta motorized wedge), cp_mwedge, ip_mwedge,
    ''' </summary>
    ''' 
    Private Function Create_Table_PhotonScans(site As Site) As Boolean
        Dim command As New MySqlCommand

            Try
                MySqlConn.Open()
                command = New MySqlCommand()
                command.Connection = MySqlConn
            command.CommandText = "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_pdd (RowKey int NOT NULL AUTO_INCREMENT, " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(8) NULL , " & _
                "WedgeAngle INT NULL , " & _
                "SSD INT NULL , " & _
                "Depth INT NULL , " & _
                "1x1 DOUBLE NULL , " & _
                "2x2 DOUBLE NULL , " & _
                "3x3 DOUBLE NULL , " & _
                "4x4 DOUBLE NULL , " & _
                "5x5 DOUBLE NULL , " & _
                "6x6 DOUBLE NULL , " & _
                "7x7 DOUBLE NULL , " & _
                "8x8 DOUBLE NULL , " & _
                "9x9 DOUBLE NULL , " & _
                "10x10 DOUBLE NULL , " & _
                "11x11 DOUBLE NULL , " & _
                "12x12 DOUBLE NULL , " & _
                "13x13 DOUBLE NULL , " & _
                "14x14 DOUBLE NULL , " & _
                "15x15 DOUBLE NULL , " & _
                "16x16 DOUBLE NULL , " & _
                "17x17 DOUBLE NULL , " & _
                "18x18 DOUBLE NULL , " & _
                "19x19 DOUBLE NULL , " & _
                "20x20 DOUBLE NULL , " & _
                "21x21 DOUBLE NULL , " & _
                "22x22 DOUBLE NULL , " & _
                "23x23 DOUBLE NULL , " & _
                "24x24 DOUBLE NULL , " & _
                "25x25 DOUBLE NULL , " & _
                "26x26 DOUBLE NULL , " & _
                "27x27 DOUBLE NULL , " & _
                "28x28 DOUBLE NULL , " & _
                "29x29 DOUBLE NULL , " & _
                "30x30 DOUBLE NULL , " & _
                "31X31 DOUBLE NULL , " & _
                "32X32 DOUBLE NULL , " & _
                "33X33 DOUBLE NULL , " & _
                "34x34 DOUBLE NULL , " & _
                "35x35 DOUBLE NULL , " & _
                "36x36 DOUBLE NULL , " & _
                "37x37 DOUBLE NULL , " & _
                "38x38 DOUBLE NULL , " & _
                "39x39 DOUBLE NULL , " & _
                "40x40 DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_pdd_cones (RowKey int NOT NULL AUTO_INCREMENT , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(8) NULL , " & _
                "SSD INT NULL , " & _
                "Depth INT NULL , " & _
                "4mm DOUBLE NULL , " & _
                "5mm DOUBLE NULL , " & _
                "6mm DOUBLE NULL , " & _
                "75mm DOUBLE NULL , " & _
                "10mm DOUBLE NULL , " & _
                "125mm DOUBLE NULL , " & _
                "15mm DOUBLE NULL , " & _
                "175mm DOUBLE NULL , " & _
                "20mm DOUBLE NULL , " & _
                "25mm DOUBLE NULL , " & _
                "30mm DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_pdd_mlc (RowKey int NOT NULL AUTO_INCREMENT , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(8) NULL , " & _
                "SSD INT NULL , " & _
                "Depth INT NULL , " & _
                "1x1 DOUBLE NULL , " & _
                "2x2 DOUBLE NULL , " & _
                "3x3 DOUBLE NULL , " & _
                "4x4 DOUBLE NULL , " & _
                "5x5 DOUBLE NULL , " & _
                "6x6 DOUBLE NULL , " & _
                "7x7 DOUBLE NULL , " & _
                "8x8 DOUBLE NULL , " & _
                "9x9 DOUBLE NULL , " & _
                "10x10 DOUBLE NULL , " & _
                "11x11 DOUBLE NULL , " & _
                "12x12 DOUBLE NULL , " & _
                "13x13 DOUBLE NULL , " & _
                "14x14 DOUBLE NULL , " & _
                "15x15 DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_tmr (RowKey int NOT NULL AUTO_INCREMENT , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(8) NULL , " & _
                "SSD INT NULL , " & _
                "Depth INT NULL , " & _
                "1x1 DOUBLE NULL , " & _
                "2x2 DOUBLE NULL , " & _
                "3x3 DOUBLE NULL , " & _
                "4x4 DOUBLE NULL , " & _
                "5x5 DOUBLE NULL , " & _
                "6x6 DOUBLE NULL , " & _
                "7x7 DOUBLE NULL , " & _
                "8x8 DOUBLE NULL , " & _
                "9x9 DOUBLE NULL , " & _
                "10x10 DOUBLE NULL , " & _
                "11x11 DOUBLE NULL , " & _
                "12x12 DOUBLE NULL , " & _
                "13x13 DOUBLE NULL , " & _
                "14x14 DOUBLE NULL , " & _
                "15x15 DOUBLE NULL , " & _
                "16x16 DOUBLE NULL , " & _
                "17x17 DOUBLE NULL , " & _
                "18x18 DOUBLE NULL , " & _
                "19x19 DOUBLE NULL , " & _
                "20x20 DOUBLE NULL , " & _
                "21x21 DOUBLE NULL , " & _
                "22x22 DOUBLE NULL , " & _
                "23x23 DOUBLE NULL , " & _
                "24x24 DOUBLE NULL , " & _
                "25x25 DOUBLE NULL , " & _
                "26x26 DOUBLE NULL , " & _
                "27x27 DOUBLE NULL , " & _
                "28x28 DOUBLE NULL , " & _
                "29x29 DOUBLE NULL , " & _
                "30x30 DOUBLE NULL , " & _
                "31X31 DOUBLE NULL , " & _
                "32X32 DOUBLE NULL , " & _
                "33X33 DOUBLE NULL , " & _
                "34x34 DOUBLE NULL , " & _
                "35x35 DOUBLE NULL , " & _
                "36x36 DOUBLE NULL , " & _
                "37x37 DOUBLE NULL , " & _
                "38x38 DOUBLE NULL , " & _
                "39x39 DOUBLE NULL , " & _
                "40x40 DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_tmr_cones (RowKey int NOT NULL AUTO_INCREMENT , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(8) NULL , " & _
                "SSD INT NULL , " & _
                "Depth INT NULL , " & _
                "4mm DOUBLE NULL , " & _
                "5mm DOUBLE NULL , " & _
                "6mm DOUBLE NULL , " & _
                "75mm DOUBLE NULL , " & _
                "10mm DOUBLE NULL , " & _
                "125mm DOUBLE NULL , " & _
                "15mm DOUBLE NULL , " & _
                "175mm DOUBLE NULL , " & _
                "20mm DOUBLE NULL , " & _
                "25mm DOUBLE NULL , " & _
                "30mm DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_tmr_mlc (RowKey int NOT NULL AUTO_INCREMENT , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(8) NULL , " & _
                "SSD INT NULL , " & _
                "Depth INT NULL , " & _
                "1x1 DOUBLE NULL , " & _
                "2x2 DOUBLE NULL , " & _
                "3x3 DOUBLE NULL , " & _
                "4x4 DOUBLE NULL , " & _
                "5x5 DOUBLE NULL , " & _
                "6x6 DOUBLE NULL , " & _
                "7x7 DOUBLE NULL , " & _
                "8x8 DOUBLE NULL , " & _
                "9x9 DOUBLE NULL , " & _
                "10x10 DOUBLE NULL , " & _
                "11x11 DOUBLE NULL , " & _
                "12x12 DOUBLE NULL , " & _
                "13x13 DOUBLE NULL , " & _
                "14x14 DOUBLE NULL , " & _
                "15x15 DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.photon_profiles (RowKey int NOT NULL AUTO_INCREMENT , " & _
                "Row INT NOT NULL , " & _
                "Energy Varchar(8) NULL , " & _
                "WedgeAngle INT NULL , " & _
                "ScanAngle INT NULL , " & _
                "SSD INT NULL , " & _
                "FieldSize Varchar(5) NULL , " & _
                "Depth INT NULL , " & _
                "R1 DOUBLE NULL , " & _
                "R2 DOUBLE NULL , " & _
                "R3 DOUBLE NULL , " & _
                "R4 DOUBLE NULL , " & _
                "R5 DOUBLE NULL , " & _
                "R6 DOUBLE NULL , " & _
                "R7 DOUBLE NULL , " & _
                "R8 DOUBLE NULL , " & _
                "R9 DOUBLE NULL , " & _
                "R10 DOUBLE NULL , " & _
                "R11 DOUBLE NULL , " & _
                "R12 DOUBLE NULL , " & _
                "R13 DOUBLE NULL , " & _
                "R14 DOUBLE NULL , " & _
                "R15 DOUBLE NULL , " & _
                "R16 DOUBLE NULL , " & _
                "R17 DOUBLE NULL , " & _
                "R18 DOUBLE NULL , " & _
                "R19 DOUBLE NULL , " & _
                "R20 DOUBLE NULL , " & _
                "R21 DOUBLE NULL , " & _
                "R22 DOUBLE NULL , " & _
                "R23 DOUBLE NULL , " & _
                "R24 DOUBLE NULL , " & _
                "R25 DOUBLE NULL , " & _
                "R26 DOUBLE NULL , " & _
                "R27 DOUBLE NULL , " & _
                "R28 DOUBLE NULL , " & _
                "R29 DOUBLE NULL , " & _
                "R30 DOUBLE NULL , " & _
                "R31 DOUBLE NULL , " & _
                "R32 DOUBLE NULL , " & _
                "R33 DOUBLE NULL , " & _
                "R34 DOUBLE NULL , " & _
                "R35 DOUBLE NULL , " & _
                "R36 DOUBLE NULL , " & _
                "R37 DOUBLE NULL , " & _
                "R38 DOUBLE NULL , " & _
                "R39 DOUBLE NULL , " & _
                "R40 DOUBLE NULL , " & _
                "R41 DOUBLE NULL , " & _
                "R42 DOUBLE NULL , " & _
                "R43 DOUBLE NULL , " & _
                "R44 DOUBLE NULL , " & _
                "R45 DOUBLE NULL , " & _
                "R46 DOUBLE NULL , " & _
                "R47 DOUBLE NULL , " & _
                "R48 DOUBLE NULL , " & _
                "R49 DOUBLE NULL , " & _
                "R50 DOUBLE NULL , " & _
                "R51 DOUBLE NULL , " & _
                "R52 DOUBLE NULL , " & _
                "R53 DOUBLE NULL , " & _
                "R54 DOUBLE NULL , " & _
                "R55 DOUBLE NULL , " & _
                "R56 DOUBLE NULL , " & _
                "R57 DOUBLE NULL , " & _
                "R58 DOUBLE NULL , " & _
                "R59 DOUBLE NULL , " & _
                "R60 DOUBLE NULL , " & _
                "R61 DOUBLE NULL , " & _
                "R62 DOUBLE NULL , " & _
                "R63 DOUBLE NULL , " & _
                "R64 DOUBLE NULL , " & _
                "R65 DOUBLE NULL , " & _
                "R66 DOUBLE NULL , " & _
                "R67 DOUBLE NULL , " & _
                "R68 DOUBLE NULL , " & _
                "R69 DOUBLE NULL , " & _
                "R70 DOUBLE NULL , " & _
                "R71 DOUBLE NULL , " & _
                "R72 DOUBLE NULL , " & _
                "R73 DOUBLE NULL , " & _
                "R74 DOUBLE NULL , " & _
                "R75 DOUBLE NULL , " & _
                "R76 DOUBLE NULL , " & _
                "R77 DOUBLE NULL , " & _
                "R78 DOUBLE NULL , " & _
                "R79 DOUBLE NULL , " & _
                "R80 DOUBLE NULL , " & _
                "R81 DOUBLE NULL , " & _
                "R82 DOUBLE NULL , " & _
                "R83 DOUBLE NULL , " & _
                "R84 DOUBLE NULL , " & _
                "R85 DOUBLE NULL , " & _
                "R86 DOUBLE NULL , " & _
                "R87 DOUBLE NULL , " & _
                "R88 DOUBLE NULL , " & _
                "R89 DOUBLE NULL , " & _
                "R90 DOUBLE NULL , " & _
                "R91 DOUBLE NULL , " & _
                "R92 DOUBLE NULL , " & _
                "R93 DOUBLE NULL , " & _
                "R94 DOUBLE NULL , " & _
                "R95 DOUBLE NULL , " & _
                "R96 DOUBLE NULL , " & _
                "R97 DOUBLE NULL , " & _
                "R98 DOUBLE NULL , " & _
                "R99 DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));"
            command.Prepare()
            command.ExecuteNonQuery()

            '  Fill_SelectedConfiguration_Tables(site, MySqlConn)

            Catch ex As MySqlException
                MessageBox.Show("Error creating PhotonsScans tables " & ex.Message)
            Finally
                MySqlConn.Close()
            End Try
        Return True
    End Function


    ''' <summary>
    ''' Creates the tables for of_electrons_100, of_electrons_105, of_electrons_110, cutoutTF
    ''' </summary>
    ''' 
    Private Function Create_Table_ElectronFactors(site As Site) As Boolean
        Dim command As New MySqlCommand

            Try
                MySqlConn.Open()
                command = New MySqlCommand()
                command.Connection = MySqlConn
                command.CommandText = "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                    "`.electron_applicator_factors (RowKey INT NOT NULL , " & _
                    "Row INT NOT NULL , " & _
                    "SSD INT NULL , " & _
                    "X INT NULL , " & _
                    "Y INT NULL , " & _
                    "Cutout_X INT NULL , " & _
                    "Cutout_Y INT NULL , " & _
                    "Reading1 DOUBLE NULL , " & _
                    "Reading2 DOUBLE NULL , " & _
                    "Average DOUBLE NULL , " & _
                    "OF DOUBLE NULL , " & _
                    "Temp DOUBLE NULL , " & _
                    "Press DOUBLE NULL , " & _
                    "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                    "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                    "`.electron_cutout_tf (RowKey INT NOT NULL , " & _
                    "Row INT NOT NULL , " & _
                    "Depth INT NULL , " & _
                    "OpenBlocked DOUBLE NULL , " & _
                    "X INT NULL , " & _
                    "Y INT NULL , " & _
                    "Reading1 DOUBLE NULL , " & _
                    "Reading2 DOUBLE NULL , " & _
                    "Average DOUBLE NULL , " & _
                    "TF DOUBLE NULL , " & _
                    "Temp DOUBLE NULL , " & _
                    "Press DOUBLE NULL , " & _
                    "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC))"
                command.Prepare()
                command.ExecuteNonQuery()

                '   Fill_Electron_Tables(site, MySqlConn, i)

            Catch ex As MySqlException
                MessageBox.Show("Error creating ElectronFactors tables " & ex.Message)
            Finally
                MySqlConn.Close()
            End Try
        Return True
    End Function



    ''' <summary>
    ''' Creates the tables for pdd_electrons, cp_electrons, ip_electrons, cp_electron_air
    ''' </summary>
    ''' 
    Private Function Create_Table_ElectronScans(site As Site) As Boolean
        Dim command As New MySqlCommand

            Try
                MySqlConn.Open()
                command = New MySqlCommand()
                command.Connection = MySqlConn
            command.CommandText = "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.electron_pdd (RowKey int NOT NULL AUTO_INCREMENT , " & _
                "Row INT NOT NULL , " & _
                "Energy VARCHAR(4) NULL , " & _
                "SSD INT NULL , " & _
                "Cutout VARCHAR(5) NULL , " & _
                "Depth INT NULL , " & _
                "4x4 DOUBLE NULL , " & _
                "5cm DOUBLE NULL , " & _
                "6x6 DOUBLE NULL , " & _
                "6x10 DOUBLE NULL , " & _
                "10x10 DOUBLE NULL , " & _
                "10x20 DOUBLE NULL , " & _
                "14x14 DOUBLE NULL , " & _
                "15x15 DOUBLE NULL , " & _
                "20x20 DOUBLE NULL , " & _
                "25x25 DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));" & _
                "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.electron_profiles (RowKey int NOT NULL AUTO_INCREMENT , " & _
                "Row INT NOT NULL , " & _
                "AirScan VARCHAR(3) NULL , " & _
                "Energy VARCHAR(4) NULL , " & _
                "ScanAngle INT NULL , " & _
                "SSD INT NULL , " & _
                "Applicator Varchar(5) NULL , " & _
                "Cutout Varchar(5) NULL , " & _
                "Depth VARCHAR(5) NULL , " & _
                "R1 DOUBLE NULL , " & _
                "R2 DOUBLE NULL , " & _
                "R3 DOUBLE NULL , " & _
                "R4 DOUBLE NULL , " & _
                "R5 DOUBLE NULL , " & _
                "R6 DOUBLE NULL , " & _
                "R7 DOUBLE NULL , " & _
                "R8 DOUBLE NULL , " & _
                "R9 DOUBLE NULL , " & _
                "R10 DOUBLE NULL , " & _
                "R11 DOUBLE NULL , " & _
                "R12 DOUBLE NULL , " & _
                "R13 DOUBLE NULL , " & _
                "R14 DOUBLE NULL , " & _
                "R15 DOUBLE NULL , " & _
                "R16 DOUBLE NULL , " & _
                "R17 DOUBLE NULL , " & _
                "R18 DOUBLE NULL , " & _
                "R19 DOUBLE NULL , " & _
                "R20 DOUBLE NULL , " & _
                "R21 DOUBLE NULL , " & _
                "R22 DOUBLE NULL , " & _
                "R23 DOUBLE NULL , " & _
                "R24 DOUBLE NULL , " & _
                "R25 DOUBLE NULL , " & _
                "R26 DOUBLE NULL , " & _
                "R27 DOUBLE NULL , " & _
                "R28 DOUBLE NULL , " & _
                "R29 DOUBLE NULL , " & _
                "R30 DOUBLE NULL , " & _
                "R31 DOUBLE NULL , " & _
                "R32 DOUBLE NULL , " & _
                "R33 DOUBLE NULL , " & _
                "R34 DOUBLE NULL , " & _
                "R35 DOUBLE NULL , " & _
                "R36 DOUBLE NULL , " & _
                "R37 DOUBLE NULL , " & _
                "R38 DOUBLE NULL , " & _
                "R39 DOUBLE NULL , " & _
                "R40 DOUBLE NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC));"
            command.Prepare()
                command.ExecuteNonQuery()

                '      Fill_Electron_Tables(site, MySqlConn, i)

            Catch ex As MySqlException
                MessageBox.Show("Error creating ElectronScan tables: " & ex.Message)
            Finally
                MySqlConn.Close()
            End Try
        Return True
    End Function


    ''' <summary>
    ''' Creates the tables which holds the measurement setup information on all factors and scans
    ''' </summary>
    ''' 
    Private Function Create_Table_SetupInfo(site As Site) As Boolean
        Dim command As New MySqlCommand
        Try
            MySqlConn.Open()
            command = New MySqlCommand()
            command.Connection = MySqlConn
            command.CommandText = "CREATE TABLE  `" & MySqlHelper.EscapeString(site.factors) & _
                "`.setupinfo (RowKey int NOT NULL , " & _
                "Row INT NOT NULL , " & _
                "SiteSaved VARCHAR(5) NULL ," & _
                "Measurement VARCHAR(16) NULL , " & _
                "Setup VARCHAR(12) NULL , " & _
                "SSD INT NULL , " & _
                "SCD INT NULL , " & _
                "Electrometer VARCHAR(16) NULL , " & _
                "ElectSerial VARCHAR(16) NULL , " & _
                "Detector VARCHAR(16) NULL , " & _
                "DetectorSerial VARCHAR(16) NULL , " & _
                "RefDetector VARCHAR(16) NULL , " & _
                "RefDetectorSerial VARCHAR(16) NULL , " & _
                "SmallFieldDetector VARCHAR(16) NULL , " & _
                "SmallFieldDetectorSerial VARCHAR(16) NULL , " & _
                "SmallFieldRefDetector VARCHAR(16) NULL , " & _
                "SmallFieldRefDetectorSerial VARCHAR(16) NULL , " & _
                "MeasurementSystem VARCHAR(16) NULL , " & _
                "MeasurementSystemSerial VARCHAR(16) NULL , " & _
                "Barometer VARCHAR(16) NULL , " & _
                "BarometerSerial VARCHAR(16) NULL , " & _
                "Thermometer VARCHAR(16) NULL , " & _
                "ThermometerSerial VARCHAR(16) NULL , " & _
                "PRIMARY KEY (RowKey) , UNIQUE INDEX RowKey_UNIQUE (RowKey ASC))"
            command.Prepare()
            command.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show("Error creating SetupInfo tables " & ex.Message)
        Finally
            MySqlConn.Close()
        End Try

        Return True
    End Function

   
    ''' <summary>
    ''' Creates the field sizes needed for Photon Factor table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_PhotonFactors_Tables(site As Site, connection As MySqlConnection) As Boolean

        Dim insertFactorsCommand As New MySqlCommand
        Dim fieldSize_X, fieldSize_Y, i, j, l, n, irow, irowkey, istop As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim yEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim wedgeAngle = New Integer() {15, 30, 45, 60}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection

        ' Enter the data that needs to be collected based on site Linac and RTP configuration. The two comment lines 
        ' with stars are just to highlight the Varian code from the Elekta code.

        ' ********************************************************************************************************************************************************


        Try

            insertFactorsCommand.Connection = connection

            If site.linacManufacturer = "Varian" Then
                If site.RTPNames(0) = "Eclipse" Then

                    ' Create Scp tables for all photon energies

                    insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_scp (RowKey, Row, Energy, SSD, SmallField, X, Y) " & _
                            "VALUES (@RowKey, @Row, @Energy, @SSD, @SmallField, @X, @Y)"
                    insertFactorsCommand.Prepare()
                    irow = 0
                    irowkey = 0
                    For n = 0 To pEnergyNum - 1
                        irow += 1
                        irowkey += 1
                        fieldSize_X = 10
                        fieldSize_Y = 10
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                        insertFactorsCommand.Parameters.AddWithValue("SmallField", "No")
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        For i = 2 To 10
                            fieldSize_X = xEclipse(i)
                            For j = 2 To 10

                                irow += 1
                                irowkey += 1
                                fieldSize_Y = yEclipse(j)
                                insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                                insertFactorsCommand.Parameters.AddWithValue("SmallField", "No")
                                insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                                insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            Next
                            j = 2
                        Next

                        ' Create rows for Scp for small fields

                        irow += 1
                        irowkey += 1
                        fieldSize_X = 10
                        fieldSize_Y = 10
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                        insertFactorsCommand.Parameters.AddWithValue("SmallField", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()

                        irow += 1
                        irowkey += 1
                        fieldSize_X = 4
                        fieldSize_Y = 4
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                        insertFactorsCommand.Parameters.AddWithValue("SmallField", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()

                        irow += 1
                        irowkey += 1
                        fieldSize_X = 3
                        fieldSize_Y = 3
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                        insertFactorsCommand.Parameters.AddWithValue("SmallField", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()

                        For i = 0 To 1
                            fieldSize_X = xEclipse(i)
                            For j = 0 To 10

                                irow += 1
                                irowkey += 1
                                fieldSize_Y = yEclipse(j)
                                insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                                insertFactorsCommand.Parameters.AddWithValue("SmallField", "Yes")
                                insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                                insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            Next
                            j = 0
                        Next
                        For i = 0 To 1
                            fieldSize_X = yEclipse(i)
                            For j = 3 To 10

                                irow += 1
                                irowkey += 1
                                fieldSize_Y = xEclipse(j)
                                insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                                insertFactorsCommand.Parameters.AddWithValue("SmallField", "Yes")
                                insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                                insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            Next
                            j = 3
                        Next
                        irow = 0
                    Next

                    ' Create Sc tables for all photon energies

                    'insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.p" & site.pEnergyNames(k) & "_sc (Row, SSD, X, Y) " & _
                    insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_sc (Rowkey, Row, Energy, SDD, SmallField, X, Y) " & _
                            "VALUES (@RowKey, @Row, @Energy, @SDD, @SmallField, @X, @Y)"
                    insertFactorsCommand.Prepare()
                    irow = 0
                    irowkey = 0

                    For n = 0 To pEnergyNum - 1
                        irow += 1
                        irowkey += 1
                        fieldSize_X = 10
                        fieldSize_Y = 10
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SDD", 100)
                        insertFactorsCommand.Parameters.AddWithValue("SmallField", "No")
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        For i = 2 To 10

                            fieldSize_X = xEclipse(i)
                            fieldSize_Y = yEclipse(i)
                            irow += 1
                            irowkey += 1
                            insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("SDD", 100)
                            insertFactorsCommand.Parameters.AddWithValue("SmallField", "No")
                            insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                            insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        Next

                        ' Create rows for Sc for small fields

                        irow += 1
                        irowkey += 1
                        fieldSize_X = 10
                        fieldSize_Y = 10
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SDD", 300)
                        insertFactorsCommand.Parameters.AddWithValue("SmallField", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        For i = 0 To 3

    
                            fieldSize_X = xEclipse(i)
                            fieldSize_Y = yEclipse(i)
                            irow += 1
                            irowkey += 1
                            insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("SDD", 300)
                            insertFactorsCommand.Parameters.AddWithValue("SmallField", "Yes")
                            insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                            insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        Next
                        irow = 0
                    Next

                    ' Create second Scp tables for all photon energies

                    insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_scp2 (Rowkey, Row, Energy, SSD, SmallField, X, Y) " & _
                             "VALUES (@RowKey, @Row, @Energy, @SSD, @SmallField, @X, @Y)"
                    insertFactorsCommand.Prepare()
                    irow = 0
                    irowkey = 0

                    For n = 0 To pEnergyNum - 1
                        irow += 1
                        irowkey += 1
                        fieldSize_X = 10
                        fieldSize_Y = 10
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                        insertFactorsCommand.Parameters.AddWithValue("SmallField", "No")
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        For i = 2 To 10

                            fieldSize_X = xEclipse(i)
                            fieldSize_Y = yEclipse(i)
                            irow += 1
                            irowkey += 1
                            insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                            insertFactorsCommand.Parameters.AddWithValue("SmallField", "No")
                            insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                            insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        Next

                        ' Create rows for second Scp for small fields

                        irow += 1
                        irowkey += 1
                        fieldSize_X = 10
                        fieldSize_Y = 10
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                        insertFactorsCommand.Parameters.AddWithValue("SmallField", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        For i = 0 To 3

     
                            fieldSize_X = xEclipse(i)
                            fieldSize_Y = yEclipse(i)
                            irow += 1
                            irowkey += 1
                            insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                            insertFactorsCommand.Parameters.AddWithValue("SmallField", "Yes")
                            insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                            insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        Next
                        irow = 0
                    Next

                    ' Create WF tables for all photon energies

                    insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_wedgefactors (Rowkey, Row, Energy, SSD, WedgeAngle, Direction, X, Y) " & _
                                "VALUES (@RowKey, @Row, @Energy, @SSD, @WedgeAngle, @Direction, @X, @Y)"
                    insertFactorsCommand.Prepare()
                    irow = 0
                    irowkey = 0

                    For n = 0 To pEnergyNum - 1
                        irow += 1
                        irowkey += 1
                        For l = 0 To 5

                            fieldSize_X = xEclipseWedge(l)
                            fieldSize_Y = yEclipseWedge(l)
                            insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("Direction", "Open")
                            insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                            insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                            irow += 1
                            irowkey += 1
                        Next

                        fieldSize_X = 15
                        fieldSize_Y = 40
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Direction", "Open")
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()

                        irow += 1
                        irowkey += 1
                        fieldSize_X = 20
                        fieldSize_Y = 40
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Direction", "Open")
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()

                        irow += 1
                        irowkey += 1
                        fieldSize_X = 30
                        fieldSize_Y = 40
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Direction", "Open")
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        For j = 0 To 3
                            For i = 0 To 3

      
                                irow += 1
                                irowkey += 1
                                fieldSize_X = 10
                                fieldSize_Y = 10
                                insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                Select Case i
                                    Case "0"
                                        insertFactorsCommand.Parameters.AddWithValue("Direction", "ToeOut")
                                    Case "1"
                                        insertFactorsCommand.Parameters.AddWithValue("Direction", "ToeIn")
                                    Case "2"
                                        insertFactorsCommand.Parameters.AddWithValue("Direction", "ToeRight")
                                    Case "3"
                                        insertFactorsCommand.Parameters.AddWithValue("Direction", "ToeLeft")
                                End Select
                                insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                                insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            Next
                            istop = 5
                            If wedgeAngle(j) = "45" Then
                                istop = 4
                            End If
                            If wedgeAngle(j) = "60" Then
                                istop = 3
                            End If
                            For i = 0 To istop

                                irow += 1
                                irowkey += 1
                                If i <> 2 Then  ' do not repeat 10x10 field size
                                    fieldSize_X = xEclipseWedge(i)
                                    fieldSize_Y = yEclipseWedge(i)
                                    irow += 1
                                    irowkey += 1
                                    insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                                    insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                                    insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                                    insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                                    insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                    insertFactorsCommand.Parameters.AddWithValue("Direction", "ToeLeft")
                                    insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                                    insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                                    insertFactorsCommand.ExecuteNonQuery()
                                    insertFactorsCommand.Parameters.Clear()
                                End If
                            Next
                            If wedgeAngle(j) = "60" Then

                                irow += 1
                                irowkey += 1
                                fieldSize_X = 15
                                fieldSize_Y = 40
                                insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("Direction", "ToeLeft")
                                insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                                insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            ElseIf wedgeAngle(j) = "45" Then

                                irow += 1
                                irowkey += 1
                                fieldSize_X = 15
                                fieldSize_Y = 40
                                insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("Direction", "ToeLeft")
                                insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                                insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                                irow += 1
                                irowkey += 1
                                fieldSize_X = 20
                                fieldSize_Y = 40
                                insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("Direction", "ToeLeft")
                                insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                                insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            Else

                                irow += 1
                                irowkey += 1
                                fieldSize_X = 20
                                fieldSize_Y = 20
                                insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("Direction", "ToeLeft")
                                insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                                insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()

                                irow += 1
                                irowkey += 1
                                fieldSize_X = 30
                                fieldSize_Y = 30
                                insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("Direction", "ToeLeft")
                                insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                                insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()

                                irow += 1
                                irowkey += 1
                                fieldSize_X = 15
                                fieldSize_Y = 40
                                insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("Direction", "ToeLeft")
                                insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                                insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()

     
                                irow += 1
                                irowkey += 1
                                fieldSize_X = 20
                                fieldSize_Y = 40
                                insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("Direction", "ToeLeft")
                                insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                                insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()

                                irow += 1
                                irowkey += 1
                                fieldSize_X = 30
                                fieldSize_Y = 40
                                insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("SSD", 90)                         'temporary, needs to be settable
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("Direction", "ToeLeft")
                                insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                                insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                        Next
                        irow = 0
                    Next

                    ' Create edw_factors tables for all photon energies

                    'insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.p" & site.pEnergyNames(k) & "_sc (Row, SSD, X, Y) " & _
                    insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_edw_factors (Rowkey, Row, Energy, SSD, X, Y) " & _
                                    "VALUES (@RowKey, @Row, @Energy, @SSD, @X, @Y)"
                    insertFactorsCommand.Prepare()
                    irow = 0
                    irowkey = 0

                    For n = 0 To pEnergyNum - 1
                        irow += 1
                        irowkey += 1
                        fieldSize_X = 10
                        fieldSize_Y = 10
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", 100)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        For i = 2 To 10

                            fieldSize_X = xEclipse(i)
                            fieldSize_Y = yEclipse(i)
                            irow += 1
                            irowkey += 1
                            insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("SSD", 100)
                            insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                            insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        Next
                        irow = 0
                    Next


                    ' Create mlc_dlg tables for all photon energies

                    'insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.p" & site.pEnergyNames(k) & "_sc (Row, SSD, X, Y) " & _
                    insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_mlc_dlg (Rowkey, Row, Energy, SSD, X, Y) " & _
                                    "VALUES (@RowKey, @Row, @Energy, @SSD, @X, @Y)"
                    insertFactorsCommand.Prepare()
                    irow = 0
                    irowkey = 0

                    For n = 0 To pEnergyNum - 1
                        irow += 1
                        irowkey += 1
                        fieldSize_X = 10
                        fieldSize_Y = 10
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", 100)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        For i = 2 To 10

                            fieldSize_X = xEclipse(i)
                            fieldSize_Y = yEclipse(i)
                            irow += 1
                            irowkey += 1
                            insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("SSD", 100)
                            insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                            insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        Next
                        irow = 0
                    Next


                    ' Create mlc_tf tables for all photon energies

                    'insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.p" & site.pEnergyNames(k) & "_sc (Row, SSD, X, Y) " & _
                    insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_mlc_tf (Rowkey, Row, Energy, SSD, X, Y) " & _
                                    "VALUES (@RowKey, @Row, @Energy, @SSD, @X, @Y)"
                    insertFactorsCommand.Prepare()
                    irow = 0
                    irowkey = 0

                    For n = 0 To pEnergyNum - 1
                        irow += 1
                        irowkey += 1
                        fieldSize_X = 10
                        fieldSize_Y = 10
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", 100)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        For i = 2 To 10

                            fieldSize_X = xEclipse(i)
                            fieldSize_Y = yEclipse(i)
                            irow += 1
                            irowkey += 1
                            insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("SSD", 100)
                            insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                            insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        Next
                        irow = 0
                    Next

                    ' Create mwedge_factors tables for all photon energies

                    ' insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.p" & site.pEnergyNames(k) & "_sc (Row, SSD, X, Y) " & _
                    insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_mwedge_factors (Rowkey, Row, Energy, SSD, X, Y) " & _
                                    "VALUES (@RowKey, @Row, @Energy, @SSD, @X, @Y)"
                    insertFactorsCommand.Prepare()
                    irow = 0
                    irowkey = 0

                    For n = 0 To pEnergyNum - 1
                        irow += 1
                        irowkey += 1
                        fieldSize_X = 10
                        fieldSize_Y = 10
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", 100)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        For i = 2 To 10

                            fieldSize_X = xEclipse(i)
                            fieldSize_Y = yEclipse(i)
                            irow += 1
                            irowkey += 1
                            insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("SSD", 100)
                            insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                            insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        Next
                        irow = 0
                    Next

                End If

                If site.RTPNames(0) = "Monaco" Then
                    For i = 0 To 9
                        fieldSize_X = xyMonaco(i)
                        irow += 1
                        irowkey += 1
                        fieldSize_Y = xyMonaco(i)
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                    Next
                End If

                If site.RTPNames(0) = "Xio" Then
                    For i = 0 To 9
                        fieldSize_X = xyMonaco(i)
                        irow += 1
                        irowkey += 1
                        fieldSize_Y = xyMonaco(i)
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                    Next
                End If

                If site.RTPNames(0) = "Pinnacle" Then
                    For i = 0 To 9
                        fieldSize_X = xyMonaco(i)
                        irow += 1
                        irowkey += 1
                        fieldSize_Y = xyMonaco(i)
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                    Next
                End If

                If site.RTPNames(0) = "BrainLab" Then
                    For i = 0 To 9
                        fieldSize_X = xyMonaco(i)
                        irow += 1
                        irowkey += 1
                        fieldSize_Y = xyMonaco(i)
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                    Next
                End If

                If site.RTPNames(0) = "Raystation" Then
                    For i = 0 To 9
                        fieldSize_X = xyMonaco(i)
                        irow += 1
                        irowkey += 1
                        fieldSize_Y = xyMonaco(i)
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                    Next
                End If
            End If


            ' *********************************************************************************************************************************************************

            If site.linacManufacturer = "Elekta" Then

                insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.p1_scp (Rowkey, Row, X, Y) " & _
                        "VALUES (@RowKey, @Row, @X, @Y)"

                insertFactorsCommand.Prepare()

                irow = 1
                irowkey = 0
                fieldSize_X = 10
                fieldSize_Y = 10
                insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                insertFactorsCommand.ExecuteNonQuery()
                insertFactorsCommand.Parameters.Clear()

                If site.RTPNames(0) = "Eclipse" Then
                    For i = 0 To 8
                        fieldSize_X = xEclipse(i)
                        For j = 0 To 8
                            irow += 1
                            irowkey += 1
                            fieldSize_Y = yEclipse(j)
                            insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                            insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        Next
                        j = 0
                    Next
                End If

                If site.RTPNames(0) = "Monaco" Then
                    For i = 0 To 9
                        fieldSize_X = xyMonaco(i)
                        irow += 1
                        irowkey += 1
                        fieldSize_Y = xyMonaco(i)
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                    Next
                End If

                If site.RTPNames(0) = "Xio" Then
                    For i = 0 To 9
                        fieldSize_X = xyMonaco(i)
                        irow += 1
                        irowkey += 1
                        fieldSize_Y = xyMonaco(i)
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                    Next
                End If

                If site.RTPNames(0) = "Pinnacle" Then
                    For i = 0 To 9
                        fieldSize_X = xyMonaco(i)
                        irow += 1
                        irowkey += 1
                        fieldSize_Y = xyMonaco(i)
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                    Next
                End If

                If site.RTPNames(0) = "BrainLab" Then
                    For i = 0 To 9
                        fieldSize_X = xyMonaco(i)
                        irow += 1
                        irowkey += 1
                        fieldSize_Y = xyMonaco(i)
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                    Next
                End If

                If site.RTPNames(0) = "Raystation" Then
                    For i = 0 To 9
                        fieldSize_X = xyMonaco(i)
                        irow += 1
                        irowkey += 1
                        fieldSize_Y = xyMonaco(i)
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error filling photon factors table " & ex.Message)
        End Try

        Return True
    End Function



    ''' <summary>
    ''' Creates the field sizes needed for the Photon PDD table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_PhotonPddOpen_Tables(site As Site, connection As MySqlConnection) As Boolean

        Dim insertFactorsCommand As New MySqlCommand
        Dim i, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim yEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim wedgeAngle = New Integer() {15, 30, 45, 60}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection

        ' Create open field PDD tables for all photon energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_pdd (Row, Energy, WedgeAngle, SSD, Depth) " & _
                            "VALUES (@Row, @Energy, @WedgeAngle, @SSD, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To pEnergyNum - 1
            For i = 0 To 350

                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                insertFactorsCommand.ExecuteNonQuery()
                insertFactorsCommand.Parameters.Clear()
                irow += 1

            Next
            irow = 1
        Next

        Return True
    End Function


    ''' <summary>
    ''' Creates the field sizes needed for the Photon Wedge PDD table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_PhotonPddWedge_Tables(site As Site, connection As MySqlConnection) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        Dim i, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim yEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim wedgeAngle = New Integer() {15, 30, 45, 60}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection

        ' Create pdd_wedge tables for all photon energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_pdd (Row, Energy, WedgeAngle, SSD, Depth) " & _
                     "VALUES (@Row, @Energy, @WedgeAngle, @SSD, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To pEnergyNum - 1
            For i = 0 To 350

                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "15")
                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                insertFactorsCommand.ExecuteNonQuery()
                insertFactorsCommand.Parameters.Clear()
                irow += 1

            Next
            irow = 1
        Next
        For n = 0 To pEnergyNum - 1
            For i = 0 To 350

                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "30")
                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                insertFactorsCommand.ExecuteNonQuery()
                insertFactorsCommand.Parameters.Clear()
                irow += 1

            Next
            irow = 1
        Next
        For n = 0 To pEnergyNum - 1
            For i = 0 To 350

                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "45")
                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                insertFactorsCommand.ExecuteNonQuery()
                insertFactorsCommand.Parameters.Clear()
                irow += 1

            Next
            irow = 1
        Next
        For n = 0 To pEnergyNum - 1
            For i = 0 To 350

                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                insertFactorsCommand.ExecuteNonQuery()
                insertFactorsCommand.Parameters.Clear()
                irow += 1

            Next
            irow = 1
        Next


        Return True
    End Function



    ''' <summary>
    ''' Creates the field sizes needed for the Photon Motorized Wedge PDD table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_PhotonPddMWedge_Tables(site As Site, connection As MySqlConnection) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        Dim i, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim yEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim wedgeAngle = New Integer() {15, 30, 45, 60}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection

        ' Create pdd_mwedge tables for all photon energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_pdd (Row, Energy, WedgeAngle, SSD, Depth) " & _
                     "VALUES (@Row, @Energy, @WedgeAngle, @SSD, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To pEnergyNum - 1
            For i = 0 To 350


                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                insertFactorsCommand.ExecuteNonQuery()
                insertFactorsCommand.Parameters.Clear()
                irow += 1
                '   irowkey += 1
            Next
            irow = 1
        Next

        Return True
    End Function



    ''' <summary>
    ''' Creates the field sizes needed for the Photon MLC PDD table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_PhotonPddMLC_Tables(site As Site, connection As MySqlConnection) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        Dim i, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim yEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim wedgeAngle = New Integer() {15, 30, 45, 60}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection


        ' Create pdd_mlc tables for all photon energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_pdd_mlc (Row, Energy, SSD, Depth) " & _
                     "VALUES (@Row, @Energy, @SSD, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To pEnergyNum - 1
            For i = 0 To 350

                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                insertFactorsCommand.ExecuteNonQuery()
                insertFactorsCommand.Parameters.Clear()
                irow += 1

            Next
            irow = 1
        Next


        Return True
    End Function



    ''' <summary>
    ''' Creates the field sizes needed for the Photon Cones PDD table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_PhotonPddCones_Tables(site As Site, connection As MySqlConnection) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        Dim i, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim yEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim wedgeAngle = New Integer() {15, 30, 45, 60}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection

        ' Create pdd_cones tables for all photon energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_pdd_cones (Row, Energy, SSD, Depth) " & _
                     "VALUES (@Row, @Energy, @SSD, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To pEnergyNum - 1
            For i = 0 To 350

                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                insertFactorsCommand.ExecuteNonQuery()
                insertFactorsCommand.Parameters.Clear()
                irow += 1

            Next
            irow = 1
        Next

        Return True
    End Function



    ''' <summary>
    ''' Creates the field sizes needed for the Photon TMR table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_PhotonTMROpen_Tables(site As Site, connection As MySqlConnection) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        Dim i, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim yEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim wedgeAngle = New Integer() {15, 30, 45, 60}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection

        ' Create tmr tables for all photon energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_tmr (Row, Energy, SSD, Depth) " & _
                     "VALUES (@Row, @Energy, @SSD, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To pEnergyNum - 1
            For i = 0 To 350

                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                insertFactorsCommand.ExecuteNonQuery()
                insertFactorsCommand.Parameters.Clear()
                irow += 1

            Next
            irow = 1
        Next

        Return True
    End Function



    ''' <summary>
    ''' Creates the field sizes needed for the Photon MLC TMR table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_PhotonTMRMLC_Tables(site As Site, connection As MySqlConnection) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        Dim i, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim yEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim wedgeAngle = New Integer() {15, 30, 45, 60}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection

        ' Create tmr_mlc tables for all photon energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_tmr_mlc (Row, Energy, SSD, Depth) " & _
                     "VALUES (@Row, @Energy, @SSD, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To pEnergyNum - 1
            For i = 0 To 350

                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                insertFactorsCommand.ExecuteNonQuery()
                insertFactorsCommand.Parameters.Clear()
                irow += 1
                '   irowkey += 1
            Next
            irow = 1
        Next

        Return True
    End Function



    ''' <summary>
    ''' Creates the field sizes needed for the Photon Cones TMR table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_PhotonTMRCones_Tables(site As Site, connection As MySqlConnection) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        Dim i, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim yEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim wedgeAngle = New Integer() {15, 30, 45, 60}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection


        ' Create tmr_cones tables for all photon energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_tmr_cones (Row, Energy, SSD, Depth) " & _
                     "VALUES (@Row, @Energy, @SSD, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To pEnergyNum - 1
            For i = 0 To 350

                insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                insertFactorsCommand.Parameters.AddWithValue("Energy", site.pEnergyNames(n))
                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                insertFactorsCommand.ExecuteNonQuery()
                insertFactorsCommand.Parameters.Clear()
                irow += 1

            Next
            irow = 1
        Next


        Return True
    End Function



    ''' <summary>
    ''' Creates the field sizes needed for the Photon Profiles table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_PhotonProfilesOpen_Tables(site As Site, connection As MySqlConnection) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        Dim i, j, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim yEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim wedgeAngle = New Integer() {15, 30, 45, 60}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection

        ' Create profiles tables for all photon energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_profiles (Row, Energy, WedgeAngle, ScanAngle, SSD, FieldSize, Depth) " & _
                     "VALUES (@Row, @Energy, @WedgeAngle, @ScanAngle, @SSD, @FieldSize, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To pEnergyNum - 1
            For j = 0 To 10
                For i = 0 To 4
                    Select Case pEnergyNames(n)
                        Case "6X"

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "6X")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 1 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 15)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 3 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 5 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 7 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 9 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If

                            irow += 1

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "6X")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 2 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 15)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 4 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 6 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 8 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 10 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                        Case "10X"

                 
                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "10X")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 1 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 25)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 3 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 5 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 7 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 9 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If

                            irow += 1

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "10X")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 2 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 15)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 4 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 6 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 8 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 10 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                        Case "15X"

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "15X")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 1 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 30)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 3 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 5 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 7 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 9 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If

                            irow += 1

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "15X")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 2 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 15)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 4 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 6 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 8 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 10 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                        Case "16X"

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "16X")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 1 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 30)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 3 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 5 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 7 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 9 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If

                            irow += 1

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "16X")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 2 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 15)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 4 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 6 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 8 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 10 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                        Case "18X"

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "18X")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 1 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 33)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 3 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 5 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 7 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 9 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If

                            irow += 1

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "18X")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 2 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 15)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 4 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 6 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 8 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 10 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                        Case "23X"

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "23X")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 1 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 33)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 3 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 5 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 7 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 9 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If

                            irow += 1

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "23X")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 2 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 15)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 4 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 5)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 6 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 8 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 10 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                        Case "6X FFF"

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "6X FFF")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 1 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 15)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 3 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 5 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 7 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 9 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If

                            irow += 1

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "6X FFF")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 2 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 15)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 4 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 6 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 8 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 10 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                        Case "10X FFF"

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "10X FFF")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 1 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 25)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 3 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 5 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 7 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 9 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If

                            irow += 1

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "10X FFF")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 2 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 15)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 4 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 6 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 8 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 10 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                        Case "6X SRS"

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "6X SRS")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 1 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 33)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 3 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 5 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 7 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 9 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If

                            irow += 1

                            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", "6X SRS")
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            If irow = 2 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 15)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 4 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 50)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 6 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 100)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 8 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 200)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                            If irow = 10 Then
                                insertFactorsCommand.Parameters.AddWithValue("Depth", 300)
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                            End If
                    End Select
                    irow += 1

                Next
                irow = 1
            Next
            irow = 1
        Next

        Return True
    End Function



    ''' <summary>
    ''' Creates the field sizes needed for the Photon Wedge Profiles table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_PhotonProfilesWedges_Tables(site As Site, connection As MySqlConnection) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        Dim i, idepth As Integer
        Dim xEclipse = New Integer() {4, 6, 8, 10, 12, 15, 20, 30}
        Dim yEclipse = New Integer() {4, 6, 8, 10, 12, 15, 20, 30}
        Dim xEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim yEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim wedgeAngle = New Integer() {15, 30, 45, 60}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim profileDepth = New Integer() {50, 100, 200, 300}

        insertFactorsCommand.Connection = connection

        ' Create profiles_wedge tables for all photon energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_profiles (Row, Energy, WedgeAngle, ScanAngle, SSD, FieldSize, Depth) " & _
                     "VALUES (@Row, @Energy, @WedgeAngle, @ScanAngle, @SSD, @FieldSize, @Depth)"
        insertFactorsCommand.Prepare()

        For n = 0 To pEnergyNum - 1
            For k = 0 To 7
                For j = 0 To 3
                    i = 1

                    Select Case pEnergyNames(n)
                        Case "6X"

                            insertFactorsCommand.Parameters.AddWithValue("Row", i)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 15)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()

                            insertFactorsCommand.Parameters.AddWithValue("Row", i + 1)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 15)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()

                            idepth = 0
                            For i = 3 To 9 Step 2

                                insertFactorsCommand.Parameters.AddWithValue("Row", i)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                                insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                                insertFactorsCommand.Parameters.AddWithValue("Depth", profileDepth(idepth))
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()

                                insertFactorsCommand.Parameters.AddWithValue("Row", i + 1)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                                insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                                insertFactorsCommand.Parameters.AddWithValue("Depth", profileDepth(idepth))
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                                idepth += 1
                            Next
                            i = 1
                        Case "10X"

                            insertFactorsCommand.Parameters.AddWithValue("Row", i)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 23)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()

                            insertFactorsCommand.Parameters.AddWithValue("Row", i + 1)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 23)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()

                            idepth = 0
                            For i = 3 To 9 Step 2

                                insertFactorsCommand.Parameters.AddWithValue("Row", i)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                                insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                                insertFactorsCommand.Parameters.AddWithValue("Depth", profileDepth(idepth))
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()

                                insertFactorsCommand.Parameters.AddWithValue("Row", i + 1)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                                insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                                insertFactorsCommand.Parameters.AddWithValue("Depth", profileDepth(idepth))
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                                idepth += 1
                            Next
                            i = 1
                        Case "15X"

                            insertFactorsCommand.Parameters.AddWithValue("Row", i)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 30)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()

                            insertFactorsCommand.Parameters.AddWithValue("Row", i + 1)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 30)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()

                            idepth = 0
                            For i = 3 To 9 Step 2

                                insertFactorsCommand.Parameters.AddWithValue("Row", i)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                                insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                                insertFactorsCommand.Parameters.AddWithValue("Depth", profileDepth(idepth))
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()

                                insertFactorsCommand.Parameters.AddWithValue("Row", i + 1)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                                insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                                insertFactorsCommand.Parameters.AddWithValue("Depth", profileDepth(idepth))
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                                idepth += 1
                            Next
                            i = 1
                        Case "16X"

                            insertFactorsCommand.Parameters.AddWithValue("Row", i)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 30)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()

                            insertFactorsCommand.Parameters.AddWithValue("Row", i + 1)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 30)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()

                            idepth = 0
                            For i = 3 To 9 Step 2

                                insertFactorsCommand.Parameters.AddWithValue("Row", i)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                                insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                                insertFactorsCommand.Parameters.AddWithValue("Depth", profileDepth(idepth))
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()

                                insertFactorsCommand.Parameters.AddWithValue("Row", i + 1)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                                insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                                insertFactorsCommand.Parameters.AddWithValue("Depth", profileDepth(idepth))
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                                idepth += 1
                            Next
                            i = 1
                        Case "18X"

                            insertFactorsCommand.Parameters.AddWithValue("Row", i)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 33)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()

                            insertFactorsCommand.Parameters.AddWithValue("Row", i + 1)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 33)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()

                            idepth = 0
                            For i = 3 To 9 Step 2

                                insertFactorsCommand.Parameters.AddWithValue("Row", i)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                                insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                                insertFactorsCommand.Parameters.AddWithValue("Depth", profileDepth(idepth))
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()

                                insertFactorsCommand.Parameters.AddWithValue("Row", i + 1)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                                insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                                insertFactorsCommand.Parameters.AddWithValue("Depth", profileDepth(idepth))
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                                idepth += 1
                            Next
                            i = 1
                        Case "23X"

                            insertFactorsCommand.Parameters.AddWithValue("Row", i)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 33)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()

                            insertFactorsCommand.Parameters.AddWithValue("Row", i + 1)
                            insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                            insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                            insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                            insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                            insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 33)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()

                            idepth = 0
                            For i = 3 To 9 Step 2

                                insertFactorsCommand.Parameters.AddWithValue("Row", i)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                                insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                                insertFactorsCommand.Parameters.AddWithValue("Depth", profileDepth(idepth))
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()

                                insertFactorsCommand.Parameters.AddWithValue("Row", i + 1)
                                insertFactorsCommand.Parameters.AddWithValue("Energy", pEnergyNames(n))
                                insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", wedgeAngle(j))
                                insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                                insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                                insertFactorsCommand.Parameters.AddWithValue("FieldSize", xEclipse(j) & "x" & yEclipse(j))
                                insertFactorsCommand.Parameters.AddWithValue("Depth", profileDepth(idepth))
                                insertFactorsCommand.ExecuteNonQuery()
                                insertFactorsCommand.Parameters.Clear()
                                idepth += 1
                            Next
                    End Select
                Next
            Next
        Next

        Return True
    End Function



    ''' <summary>
    ''' Creates the field sizes needed for the Photon Motorized Wedge Profiles table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_PhotonProfilesMWedge_Tables(site As Site, connection As MySqlConnection) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        Dim i, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim yEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim wedgeAngle = New Integer() {15, 30, 45, 60}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection


        ' Create profiles_mwedge tables for all photon energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.photon_profiles_mwedge (Row, Energy, WedgeAngle, ScanAngle, SSD, Depth) " & _
                     "VALUES (@Row, @Energy, @WedgeAngle, @ScanAngle, @SSD, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To pEnergyNum - 1
            For i = 0 To 4
                Select Case pEnergyNames(n)
                    Case "6X"

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6X")
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 1.5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 10)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 20)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 30)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If

                        irow += 1

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6X")
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 1.5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 10)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "10X"

                        irow += 1

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "10X")
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 2.5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 10)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 20)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 30)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If

                        irow += 1

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "10X")
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 1.5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 10)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "15X"

                        irow += 1

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "15X")
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 3.0)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 10)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 20)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 30)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If

                        irow += 1

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "15X")
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 1.5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 10)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "16X"

                        irow += 1

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "16X")
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 3.0)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 10)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 20)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 30)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If

                        irow += 1

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "16X")
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 1.5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 10)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "18X"

                        irow += 1

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "18X")
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 3.3)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 10)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 20)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 30)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If

                        irow += 1

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "18X")
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 1.5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 10)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "23X"

                        irow += 1

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "23X")
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 3.3)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 10)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 20)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 30)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If

                        irow += 1

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "23X")
                        insertFactorsCommand.Parameters.AddWithValue("WedgeAngle", "60")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 1.5)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", 10)
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                End Select
                irow += 1

            Next
            irow = 1
        Next

        Return True
    End Function



    ''' <summary>
    ''' Creates the field sizes needed for the Photon PDD table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_ElectronPddOpen_Tables(site As Site, connection As MySqlConnection) As Boolean

        Dim insertFactorsCommand As New MySqlCommand
        Dim i, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection

        ' Create open field PDD tables for all electron energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.electron_pdd (Row, Energy, SSD, Cutout, Depth) " & _
                            "VALUES (@Row, @Energy, @SSD, @Cutout, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To eEnergyNum - 1
            Select Case eEnergyNames(n)
                Case "4e"
                    For i = 0 To 40

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "None")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "6e"
                    For i = 0 To 60
       
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "None")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "8e"
                    For i = 0 To 90

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "None")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "9e"
                    For i = 0 To 90

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "None")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "10e"
                    For i = 0 To 90

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "None")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "12e"
                    For i = 0 To 120

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "None")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "15e"
                    For i = 0 To 150

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "None")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "16e"
                    For i = 0 To 160

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "None")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "18e"
                    For i = 0 To 180

      
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "None")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "21e"
                    For i = 0 To 210

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "None")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                    irow = 1
            End Select
        Next
        Return True
    End Function



    ''' <summary>
    ''' Creates the field sizes needed for the Photon PDD with Cutouts table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_ElectronPddCutout_Tables(site As Site, connection As MySqlConnection) As Boolean

        Dim insertFactorsCommand As New MySqlCommand
        Dim i, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection

        ' Create open field PDD tables for all electron energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.electron_pdd (Row, Energy, SSD, Cutout, Depth) " & _
                            "VALUES (@Row, @Energy, @SSD, @Cutout, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To eEnergyNum - 1
            Select Case eEnergyNames(n)
                Case "4e"
                    For i = 0 To 40

         
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "6e"
                    For i = 0 To 60

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "8e"
                    For i = 0 To 60

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "9e"
                    For i = 0 To 90

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "10e"
                    For i = 0 To 60

         
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "12e"
                    For i = 0 To 120

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "15e"
                    For i = 0 To 150

        
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "16e"
                    For i = 0 To 160

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "18e"
                    For i = 0 To 180

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                Case "21e"
                    For i = 0 To 210

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("Energy", site.eEnergyNames(n))
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Depth", i)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                        irow += 1
                    Next
                    irow = 1
            End Select
        Next
        Return True
    End Function




    ''' <summary>
    ''' Creates the field sizes needed for the Electron Profiles table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_ElectronProfilesOpen_Tables(site As Site, connection As MySqlConnection) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        Dim i, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection

        ' Create profiles tables for all electron energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.electron_profiles (Row, AirScan, Energy, ScanAngle, SSD, Applicator, Cutout, Depth) " & _
                     "VALUES (@Row, @AirScan, @Energy, @ScanAngle, @SSD, @Applicator, @Cutout, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To eEnergyNum - 1
            For i = 0 To 4
                Select Case eEnergyNames(n)
                    Case "4e"

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "4e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "Dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "4e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "6e"

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "Dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "8e"

      
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "Dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "9e"

     
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "9e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "Dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "9e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "10e"

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "Dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "12e"

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "12e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "Dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "12e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "15e"

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "15e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "Dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "15e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "16e"

    
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "16e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "Dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "16e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "18e"

       
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "18e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "Dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "No")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "18e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "dmax")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d90")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d80")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d50")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "d20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                End Select
                irow += 1
            Next
            irow = 1
        Next

        Return True
    End Function




    ''' <summary>
    ''' Creates the field sizes needed for the Electron Profiles in Air table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Fill_ElectronProfilesAir_Tables(site As Site, connection As MySqlConnection) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        Dim i, irow As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        insertFactorsCommand.Connection = connection

        ' Create profiles tables for all electron energies

        insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.electron_profiles (Row, AirScan, Energy, ScanAngle, SSD, Applicator, Cutout, Depth) " & _
                     "VALUES (@Row, @AirScan, @Energy, @ScanAngle, @SSD, @Applicator, @Cutout, @Depth)"
        insertFactorsCommand.Prepare()
        irow = 1

        For n = 0 To eEnergyNum - 1
            For i = 0 To 4
                Select Case eEnergyNames(n)
                    Case "4e"

                
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "4e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "4e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "6e"

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "8e"

         
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "9e"

        
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "9e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "9e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "10e"

        
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "6e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "12e"

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "12e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "12e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "15e"

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "15e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "15e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "16e"

                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "16e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "16e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                    Case "18e"

         
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "18e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "0")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 1 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 3 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 5 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 7 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 9 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        irow += 1
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("AirScan", "Yes")
                        insertFactorsCommand.Parameters.AddWithValue("Energy", "18e")
                        insertFactorsCommand.Parameters.AddWithValue("ScanAngle", "90")
                        insertFactorsCommand.Parameters.AddWithValue("SSD", "100")
                        insertFactorsCommand.Parameters.AddWithValue("Applicator", "0")
                        insertFactorsCommand.Parameters.AddWithValue("Cutout", "0")
                        If irow = 2 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "0")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 4 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "5")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 6 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "10")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 8 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "15")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                        If irow = 10 Then
                            insertFactorsCommand.Parameters.AddWithValue("Depth", "20")
                            insertFactorsCommand.ExecuteNonQuery()
                            insertFactorsCommand.Parameters.Clear()
                        End If
                End Select
                irow += 1
            Next
            irow = 1
        Next

        Return True
    End Function



    ''' <summary>
    ''' Creates the field sizes needed for each table of data to be measured based on the Linac and RTP System(s).
    ''' </summary>
    ''' <remarks></remarks>

    Public Function Fill_SelectedConfiguration_Tables(site As Site, connection As MySqlConnection) As Boolean
        Dim insertFactorsCommand As New MySqlCommand
        Dim fieldSize_X, fieldSize_Y, i, j, irow, irowkey As Integer
        Dim xEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim yEclipse = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim yEclipseWedge = New Integer() {3, 5, 10, 15, 20, 30, 40}
        Dim wedgeAngle = New Integer() {15, 30, 45, 60}
        Dim xyMonaco = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyXio = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyPinnacle = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyRayStation = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}
        Dim xyBrainLab = New Integer() {1, 2, 3, 4, 5, 7, 10, 15, 20, 30, 40}

        'Enter the data that needs to be collected based on site Linac and RTP configuration. The two comment lines 
        ' with stars are just to highlight the Varian code from the Elekta code.

        ' ********************************************************************************************************************************************************

        If site.linacManufacturer = "Varian" Then
            If site.RTPNames(0) = "Eclipse" Then

                Fill_PhotonFactors_Tables(site, connection)
                Fill_PhotonPddOpen_Tables(site, connection)
                Fill_PhotonPddWedge_Tables(site, connection)
                'Fill_PhotonPddMWedge_Tables(site, connection)
                Fill_PhotonProfilesOpen_Tables(site, connection)
                Fill_PhotonProfilesWedges_Tables(site, connection)
                'Fill_PhotonProfilesMWedge_Tables(site, connection)
                'Fill_PhotonProfileCones_Tables(site, connection)
                'Fill_PhotonProfilesMLC_Tables(site, connection)
                Fill_PhotonTMROpen_Tables(site, connection)
                Fill_PhotonTMRCones_Tables(site, connection)
                Fill_PhotonTMRMLC_Tables(site, connection)

                Fill_ElectronPddOpen_Tables(site, connection)
                Fill_ElectronPddCutout_Tables(site, connection)
                Fill_ElectronProfilesOpen_Tables(site, connection)
                Fill_ElectronProfilesAir_Tables(site, connection)

                Fill_PhotonPddMLC_Tables(site, connection)
                Fill_PhotonPddCones_Tables(site, connection)

     
            End If


            If site.RTPNames(0) = "Monaco" Then
                For i = 0 To 9
                    fieldSize_X = xyMonaco(i)
                    irow += 1
                    irowkey += 1
                    fieldSize_Y = xyMonaco(i)
                    insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                    insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                    insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                    insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                    insertFactorsCommand.ExecuteNonQuery()
                    insertFactorsCommand.Parameters.Clear()
                Next
            End If

            If site.RTPNames(0) = "Xio" Then
                For i = 0 To 9
                    fieldSize_X = xyMonaco(i)
                    irow += 1
                    irowkey += 1
                    fieldSize_Y = xyMonaco(i)
                    insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                    insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                    insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                    insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                    insertFactorsCommand.ExecuteNonQuery()
                    insertFactorsCommand.Parameters.Clear()
                Next
            End If

            If site.RTPNames(0) = "Pinnacle" Then
                For i = 0 To 9
                    fieldSize_X = xyMonaco(i)
                    irow += 1
                    irowkey += 1
                    fieldSize_Y = xyMonaco(i)
                    insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                    insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                    insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                    insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                    insertFactorsCommand.ExecuteNonQuery()
                    insertFactorsCommand.Parameters.Clear()
                Next
            End If

            If site.RTPNames(0) = "BrainLab" Then
                For i = 0 To 9
                    fieldSize_X = xyMonaco(i)
                    irow += 1
                    irowkey += 1
                    fieldSize_Y = xyMonaco(i)
                    insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                    insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                    insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                    insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                    insertFactorsCommand.ExecuteNonQuery()
                    insertFactorsCommand.Parameters.Clear()
                Next
            End If

            If site.RTPNames(0) = "Raystation" Then
                For i = 0 To 9
                    fieldSize_X = xyMonaco(i)
                    irow += 1
                    irowkey += 1
                    fieldSize_Y = xyMonaco(i)
                    insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                    insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                    insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                    insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                    insertFactorsCommand.ExecuteNonQuery()
                    insertFactorsCommand.Parameters.Clear()
                Next
            End If
        End If


        ' *********************************************************************************************************************************************************

        If site.linacManufacturer = "Elekta" Then

            insertFactorsCommand.CommandText = "INSERT INTO `" & site.factors & "`.p1_scp (Rowkey, Row, X, Y) " & _
                        "VALUES (@RowKey, @Row, @X, @Y)"

            insertFactorsCommand.Prepare()

            irow = 1
            irowkey = 1
            fieldSize_X = 10
            fieldSize_Y = 10
            insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
            insertFactorsCommand.Parameters.AddWithValue("Row", irow)
            insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
            insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
            insertFactorsCommand.ExecuteNonQuery()
            insertFactorsCommand.Parameters.Clear()

            If site.RTPNames(0) = "Eclipse" Then
                For i = 0 To 8
                    fieldSize_X = xEclipse(i)
                    For j = 0 To 8
                        irow += 1
                        irowkey += 1
                        fieldSize_Y = yEclipse(j)
                        insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                        insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                        insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                        insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                        insertFactorsCommand.ExecuteNonQuery()
                        insertFactorsCommand.Parameters.Clear()
                    Next
                    j = 0
                Next
            End If

            If site.RTPNames(0) = "Monaco" Then
                For i = 0 To 9
                    fieldSize_X = xyMonaco(i)
                    irow += 1
                    irowkey += 1
                    fieldSize_Y = xyMonaco(i)
                    insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                    insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                    insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                    insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                    insertFactorsCommand.ExecuteNonQuery()
                    insertFactorsCommand.Parameters.Clear()
                Next
            End If

            If site.RTPNames(0) = "Xio" Then
                For i = 0 To 9
                    fieldSize_X = xyMonaco(i)
                    irow += 1
                    irowkey += 1
                    fieldSize_Y = xyMonaco(i)
                    insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                    insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                    insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                    insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                    insertFactorsCommand.ExecuteNonQuery()
                    insertFactorsCommand.Parameters.Clear()
                Next
            End If

            If site.RTPNames(0) = "Pinnacle" Then
                For i = 0 To 9
                    fieldSize_X = xyMonaco(i)
                    irow += 1
                    irowkey += 1
                    fieldSize_Y = xyMonaco(i)
                    insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                    insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                    insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                    insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                    insertFactorsCommand.ExecuteNonQuery()
                    insertFactorsCommand.Parameters.Clear()
                Next
            End If

            If site.RTPNames(0) = "BrainLab" Then
                For i = 0 To 9
                    fieldSize_X = xyMonaco(i)
                    irow += 1
                    irowkey += 1
                    fieldSize_Y = xyMonaco(i)
                    insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                    insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                    insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                    insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                    insertFactorsCommand.ExecuteNonQuery()
                    insertFactorsCommand.Parameters.Clear()
                Next
            End If

            If site.RTPNames(0) = "Raystation" Then
                For i = 0 To 9
                    fieldSize_X = xyMonaco(i)
                    irow += 1
                    irowkey += 1
                    fieldSize_Y = xyMonaco(i)
                    insertFactorsCommand.Parameters.AddWithValue("Rowkey", irowkey)
                    insertFactorsCommand.Parameters.AddWithValue("Row", irow)
                    insertFactorsCommand.Parameters.AddWithValue("X", fieldSize_X)
                    insertFactorsCommand.Parameters.AddWithValue("Y", fieldSize_Y)
                    insertFactorsCommand.ExecuteNonQuery()
                    insertFactorsCommand.Parameters.Clear()
                Next
            End If

        End If
        Return True
    End Function


    ''' <summary>
    ''' Generates an MySql command to insert a new site into the database.
    ''' </summary>
    ''' <param name="site">New site to add to the database.</param>
    ''' <param name="connection">Database connection, must be opened beforehand.</param>
    ''' <returns>The sql command.</returns>
    ''' <remarks></remarks>

    Private Function Generate_Insert_Site_Command(site As Site, connection As MySqlConnection) As MySqlCommand
        Dim insertCommand As New MySqlCommand()

        insertCommand.Connection = connection

        insertCommand.CommandText = "INSERT INTO sites.siteinfo (SiteName, StreetAddress, City, State, Zip, Country, " & _
                        "PhysicistContact, Phone, LinacManufacturer, LinacModel, LinacSerial," & _
                        "PhotonNumber, PhotonEnergy1, Photonenergy2, PhotonEnergy3, PhotonEnergy4, PhotonEnergy5," & _
                        "ElectronNumber, ElectronEnergy1, ElectronEnergy2, ElectronEnergy3, ElectronEnergy4, ElectronEnergy5, ElectronEnergy6, " & _
                        "RTPNumber, RTP1, RTP2, RTP3)" & _
            "VALUES (@SiteName, @StreetAddress, @City, @State, @Zip, @Country, " & _
            "@PhysicistContact, @Phone, " & _
            "@LinacManufacturer, @LinacModel, @LinacSerial, " & _
            "@PhotonNumber, @PhotonEnergy1, @PhotonEnergy2, @PhotonEnergy3, @PhotonEnergy4, @PhotonEnergy5, " & _
            "@ElectronNumber, @ElectronEnergy1, @ElectronEnergy2, @ElectronEnergy3, @ElectronEnergy4, @ElectronEnergy5, @ElectronEnergy6, " & _
            "@RTPNumber, @RTP1, @RTP2, @RTP3)"

        insertCommand.Prepare()

        Return Add_Command_Parameters(insertCommand, site)
    End Function


    ''' <summary>
    ''' Generates an MySql command to update an existing site's information in the database.
    ''' </summary>
    ''' <param name="site">The site to update.</param>
    ''' <param name="connection">Database connection, must be opened beforehand.</param>
    ''' <returns>The sql command.</returns>
    ''' <remarks></remarks>

    Private Function Generate_Update_Site_Command(site As Site, connection As MySqlConnection) As MySqlCommand
        Dim updateCommand As New MySqlCommand

        updateCommand.Connection = connection

        updateCommand.CommandText = "UPDATE sites.siteinfo SET SiteName=@SiteName, StreetAddress=@StreetAddress, City=@City, State=@State, Zip=@Zip, Country=@Country, " & _
                            "PhysicistContact=@PhysicistContact, Phone=@Phone, LinacManufacturer=@LinacManufacturer, LinacModel=@LinacModel, LinacSerial=@LinacSerial, " & _
                            "PhotonNumber=@PhotonNumber, PhotonEnergy1=@PhotonEnergy1, PhotonEnergy2=@PhotonEnergy2, PhotonEnergy3=@PhotonEnergy3, PhotonEnergy4=@PhotonEnergy4, PhotonEnergy5=@PhotonEnergy5, " & _
                            "ElectronNumber=@ElectronNumber, ElectronEnergy1=@ElectronEnergy1, ElectronEnergy2=@ElectronEnergy2, ElectronEnergy3=@ElectronEnergy3, ElectronEnergy4=@ElectronEnergy4, ElectronEnergy5=@ElectronEnergy5, ElectronEnergy6=@ElectronEnergy6, " & _
                            "RTPNumber=@RTPNumber, RTP1=@RTP1, RTP2=@RTP2, RTP3=@RTP3 " & _
                "WHERE idsiteinfo=@idsiteinfo;"

        updateCommand.Prepare()

        Return Add_Command_Parameters(updateCommand, site)
    End Function


    ''' <summary>
    ''' Adds the site parameters to a prepared MySql command.
    ''' </summary>
    ''' <param name="command">The prepared MySql command.</param>
    ''' <param name="site">The site to add.</param>
    ''' <returns>The populated command.</returns>
    ''' <remarks>When writing the command text, ensure the parameters retain the database's capitalization.</remarks>

    Private Function Add_Command_Parameters(command As MySqlCommand, site As Site) As MySqlCommand
        Dim sortedPhotonEnergy(4), sortedElectronEnergy(5) As String
        Dim checkPhotonEnergy = New String() {"6X", "10X", "15X", "16X", "18X", "23X", "6X SRS", "6X FFF", "10X FFF"}
        Dim checkElectronEnergy = New String() {"4e", "6e", "8e", "9e", "10e", "12e", "15e", "16e", "18e", "21e"}
        Dim inext As Integer
        command.Parameters.AddWithValue("idsiteinfo", site.dbID)
        command.Parameters.AddWithValue("SiteName", site.siteName)
        command.Parameters.AddWithValue("StreetAddress", site.streetAddress)
        command.Parameters.AddWithValue("City", site.city)
        command.Parameters.AddWithValue("State", site.state)
        command.Parameters.AddWithValue("Zip", site.zip)
        command.Parameters.AddWithValue("Country", site.country)
        command.Parameters.AddWithValue("PhysicistContact", site.physicist)
        command.Parameters.AddWithValue("Phone", site.phone)
        command.Parameters.AddWithValue("LinacManufacturer", site.linacManufacturer)
        command.Parameters.AddWithValue("LinacModel", site.linacModel)
        command.Parameters.AddWithValue("LinacSerial", site.linacSerial)

        'For i As Integer = 0 To site.pEnergyNames.Length - 1

        inext = 0
        For i = 0 To 8
            For j = 0 To pEnergyNum - 1
                If site.pEnergyNames(j) = checkPhotonEnergy(i) Then
                    sortedPhotonEnergy(inext) = checkPhotonEnergy(i)
                    inext += 1
                End If
            Next
        Next

        For i = 0 To pEnergyNum - 1
            site.pEnergyNames(i) = sortedPhotonEnergy(i)
        Next

        inext = 0
        For i = 0 To 9
            For j = 0 To eEnergyNum - 1
                If site.eEnergyNames(j) = checkElectronEnergy(i) Then
                    sortedElectronEnergy(inext) = checkElectronEnergy(i)
                    inext += 1
                End If
            Next
        Next

        For i = 0 To eEnergyNum - 1
            site.eEnergyNames(i) = sortedElectronEnergy(i)
        Next

        command.Parameters.AddWithValue("PhotonNumber", site.nPEnergies)
        For i As Integer = 0 To 4
            If i < site.nPEnergies Then
                command.Parameters.AddWithValue("PhotonEnergy" & (i + 1), site.pEnergyNames(i))
            Else
                command.Parameters.AddWithValue("PhotonEnergy" & (i + 1), DBNull.Value)
            End If
        Next

        command.Parameters.AddWithValue("ElectronNumber", site.nEEnergies)
        For i As Integer = 0 To 5
            If i < site.nEEnergies Then
                command.Parameters.AddWithValue("ElectronEnergy" & (i + 1), site.eEnergyNames(i))
            Else
                command.Parameters.AddWithValue("ElectronEnergy" & (i + 1), DBNull.Value)
            End If
        Next

        command.Parameters.AddWithValue("RTPNumber", site.nRTP)

        For i As Integer = 0 To site.RTPNames.Length - 1
            command.Parameters.AddWithValue("RTP" & (i + 1), site.RTPNames(i))
        Next

        command.Parameters.AddWithValue("Factors", site.factors)

        Return command
    End Function



    Private Sub nRTP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_nRTP.SelectedIndexChanged
        Select Case ComboBox_nRTP.Text
            Case "1"
                ComboBox_RTP1.Enabled = True
                ComboBox_RTP2.Enabled = False
                ComboBox_RTP3.Enabled = False
            Case "2"
                ComboBox_RTP1.Enabled = True
                ComboBox_RTP2.Enabled = True
                ComboBox_RTP3.Enabled = False
            Case "3"
                ComboBox_RTP1.Enabled = True
                ComboBox_RTP2.Enabled = True
                ComboBox_RTP3.Enabled = True
            Case Else
                ComboBox_RTP1.Enabled = False
                ComboBox_RTP2.Enabled = False
                ComboBox_RTP3.Enabled = False
        End Select
    End Sub


    Private Sub Button_Next_Click(sender As Object, e As EventArgs) Handles Button_Next.Click
        If (activeSite Is Nothing) Then
            MessageBox.Show("The site must be saved before continuing.")
        Else
            activeSite = currentSite
            Form_SiteInfo.Show()
            Me.Close()
        End If
    End Sub


    Private Sub Button_SaveAndExit_Click(sender As Object, e As EventArgs) Handles Button_SaveAndExit.Click
        Button_Save_Click(sender, e)
        Me.Close()
    End Sub


    Private Sub Button_Back_Click(sender As Object, e As EventArgs) Handles Button_Back.Click
        Form_SiteInfo.Show()
        Me.Close()
    End Sub


    Private Sub Button_Exit_Click(sender As Object, e As EventArgs) Handles Button_Exit.Click
        Dim ExitYN As System.Windows.Forms.DialogResult
        ExitYN = MsgBox("Do you really want to exit?", MsgBoxStyle.YesNo)
        If ExitYN = MsgBoxResult.Yes Then
            Application.Exit()
            End
        Else
        End If
    End Sub

End Class