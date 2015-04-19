Imports MySql.Data.MySqlClient

''' <summary>
''' An object to hold all relevant site information.
''' </summary>
''' <remarks></remarks>
Public Class Site
    Public siteName As String
    Public streetAddress As String, city As String, state As String, zip As String, country As String
    Public physicist As String, phone As String
    Public linacManufacturer As String, linacModel As String, linacSerial As String
    Public nPEnergies As Integer
    Public pEnergyNames(4) As String
    Public nEEnergies As Integer
    Public eEnergyNames(5) As String
    Public nRTP As Integer
    Public RTPNames(4) As String
    Public dbID As Integer
    Public factors As String

    ' Constructor for all site information except id and factors

    Sub New(_siteName As String, _streetAddress As String, _city As String, _zip As String, _state As String, _country As String, _
            _physicist As String, _phone As String, _
            _linacManufacturer As String, _linacModel As String, _linacSerial As String, _
            _nPEnergies As Integer, _pEnergyNames() As String, _
            _nEEnergies As Integer, _eEnergyNames() As String, _
            _nRTP As Integer, _RTPNames() As String)
        siteName = _siteName
        streetAddress = _streetAddress
        city = _city
        state = _state
        zip = _zip
        country = _country
        physicist = _physicist
        phone = _phone
        linacManufacturer = _linacManufacturer
        linacModel = _linacModel
        linacSerial = _linacSerial
        nPEnergies = _nPEnergies
        pEnergyNames = _pEnergyNames
        nEEnergies = _nEEnergies
        eEnergyNames = _eEnergyNames
        nRTP = _nRTP
        RTPNames = _RTPNames

        dbID = -1
    End Sub

    ' Constructor for database to be accessed with code to read all items in database table

    Sub New(sitesDBConn As MySqlConnection, ID As String)
        Dim query As String
        Dim command As MySqlCommand
        Dim reader As MySqlDataReader

        Try
            sitesDBConn.Open()
            query = "SELECT * FROM siteinfo WHERE idsiteinfo=" & ID.Substring(0, ID.IndexOf("_")) & " AND SiteName = '" & ID.Substring(ID.IndexOf("_") + 1) & "'"
            command = New MySqlCommand(query, sitesDBConn)
            reader = command.ExecuteReader()
            reader.Read()

            dbID = reader.Item("idsiteinfo")
            siteName = reader.Item("SiteName")
            streetAddress = reader.Item("StreetAddress")
            city = reader.Item("City")
            state = reader.Item("State")
            zip = reader.Item("Zip")
            country = reader.Item("Country")
            physicist = reader.Item("PhysicistContact")
            phone = reader.Item("Phone")
            linacManufacturer = reader.Item("LinacManufacturer")
            linacModel = reader.Item("LinacModel")
            linacSerial = reader.Item("LinacSerial")
            nPEnergies = reader.Item("PhotonNumber")
            pEnergyNum = nPEnergies
            For i As Integer = 0 To nPEnergies - 1
                pEnergyNames(i) = reader.Item("PhotonEnergy" & i + 1)
            Next

            nEEnergies = reader.Item("ElectronNumber")
            eEnergyNum = nEEnergies
            For i As Integer = 0 To nEEnergies - 1
                eEnergyNames(i) = reader.Item("ElectronEnergy" & i + 1)
            Next

            nRTP = reader.Item("RTPNumber")

            For i As Integer = 0 To nRTP - 1
                RTPNames(i) = reader.Item("RTP" & i + 1)
            Next

            factors = reader.Item("Factors")

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            sitesDBConn.Close()
            sitesDBConn.Dispose()
        End Try
    End Sub

    ' Constructor to initialize all database values


    Sub New()
        dbID = -1
        siteName = ""
        streetAddress = ""
        city = ""
        state = ""
        zip = ""
        country = ""
        physicist = ""
        phone = ""
        linacManufacturer = ""
        linacModel = ""
        linacSerial = ""
        nPEnergies = 0
        pEnergyNames.Initialize()
        nEEnergies = 0
        eEnergyNames.Initialize()
        nRTP = 0
        RTPNames.Initialize()
        factors = ""

    End Sub

    Public Overloads Overrides Function Equals(o As Object) As Boolean
        Dim res As Boolean = True
        Dim oSite As Site

        If (o Is Nothing) Then
            Return False
        End If

        If (o.GetType().Equals(Me.GetType)) Then
            oSite = TryCast(o, Site)

            ' checks each entry in site sequentially. Returns False if any entry has changed, True if not

            res = res And siteName.Equals(oSite.siteName)
            res = res And streetAddress.Equals(oSite.streetAddress)
            res = res And city.Equals(oSite.city)
            res = res And state.Equals(oSite.state)
            res = res And zip.Equals(oSite.zip)
            res = res And country.Equals(oSite.country)
            res = res And physicist.Equals(oSite.physicist)
            res = res And phone.Equals(oSite.phone)
            res = res And linacManufacturer.Equals(oSite.linacManufacturer)
            res = res And linacModel.Equals(oSite.linacModel)
            res = res And linacSerial.Equals(oSite.linacSerial)
            res = res And nPEnergies.Equals(oSite.nPEnergies)
            res = res And pEnergyNames.Equals(oSite.pEnergyNames)
            res = res And nEEnergies.Equals(oSite.nEEnergies)
            res = res And eEnergyNames.Equals(oSite.eEnergyNames)
            res = res And nRTP.Equals(oSite.nRTP)
            res = res And RTPNames.Equals(oSite.RTPNames)

            Return res
        Else
            Return False
        End If
    End Function

    Public Sub Fill(_siteName As String, _streetAddress As String, _city As String, _zip As String, _state As String, _country As String, _
            _physicist As String, _phone As String, _
            _linacManufacturer As String, _linacModel As String, _linacSerial As String, _
            _nPEnergies As Integer, _pEnergyNames() As String, _
            _nEEnergies As Integer, _eEnergyNames() As String, _
            _nRTP As Integer, _RTPNames() As String)

        siteName = _siteName
        streetAddress = _streetAddress
        city = _city
        state = _state
        zip = _zip
        country = _country
        physicist = _physicist
        phone = _phone
        linacManufacturer = _linacManufacturer
        linacModel = _linacModel
        linacSerial = _linacSerial
        nPEnergies = _nPEnergies
        pEnergyNames = _pEnergyNames
        nEEnergies = _nEEnergies
        eEnergyNames = _eEnergyNames
        nRTP = _nRTP
        RTPNames = _RTPNames
    End Sub

End Class
