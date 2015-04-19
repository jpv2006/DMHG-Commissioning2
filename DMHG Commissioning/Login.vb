Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class Form_Login
    Dim COMMAND As MySqlCommand
    Dim sitesDBConn As MySqlConnection
    Dim READER As MySqlDataReader
    Dim userpassDBConn As MySqlConnection
    Dim username As String
    Dim totalSiteNumber As Integer

    Private Sub Login_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Connect_To_Database()

        ' Shows active user if non-blank entry

        If (Not activeUser = "") Then
            Show_Logged_In()
        End If
        
    End Sub



    Private Sub Connect_To_Database()
        Label_DatabaseConnection.Text = "Database not connected"
        Label_DatabaseConnection.BackColor = Color.Red
        Label_DatabaseConnection.Visible = True

        If (activeUser = "") Then
            Dim cString As String
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Dim connectionStringsSection As ConfigurationSection = config.GetSection("connectionStrings")

            cString = ConfigurationManager.ConnectionStrings("sites").ConnectionString
            cString = cString.Substring(cString.IndexOf(";"))
            cString = cString.Insert(0, "server=" & ConfigurationManager.AppSettings("ActiveServer"))
            connectionStringsSection.CurrentConfiguration.ConnectionStrings.ConnectionStrings("sites").ConnectionString = cString

            cString = ConfigurationManager.ConnectionStrings("userPass").ConnectionString
            cString = cString.Substring(cString.IndexOf(";"))
            cString = cString.Insert(0, "server=" & ConfigurationManager.AppSettings("ActiveServer"))
            connectionStringsSection.CurrentConfiguration.ConnectionStrings.ConnectionStrings("userPass").ConnectionString = cString

            cString = ConfigurationManager.ConnectionStrings("noDB").ConnectionString
            cString = cString.Substring(cString.IndexOf(";"))
            cString = cString.Insert(0, "server=" & ConfigurationManager.AppSettings("ActiveServer"))
            connectionStringsSection.CurrentConfiguration.ConnectionStrings.ConnectionStrings("noDB").ConnectionString = cString

            config.Save()
            ConfigurationManager.RefreshSection("connectionStrings")

            Label_Server.Text = "(" & ConfigurationManager.AppSettings("ActiveServer") & ")"
        End If


        sitesDBConn = New MySqlConnection(ConfigurationManager.ConnectionStrings("sites").ConnectionString)
        userpassDBConn = New MySqlConnection(ConfigurationManager.ConnectionStrings("userpass").ConnectionString)

        ' connects to the userpass database which contains the usernames and passwords of all authorized users
        Try
            userpassDBConn.Open()
            If userpassDBConn.State = ConnectionState.Open Then
                Label_DatabaseConnection.Text = "Connected to Database"
                Label_DatabaseConnection.BackColor = Color.PaleGreen
                Label_DatabaseConnection.Visible = True
            Else
                Label_DatabaseConnection.Text = "Database not connected"
                Label_DatabaseConnection.BackColor = Color.Red
                Label_DatabaseConnection.Visible = True
            End If
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            userpassDBConn.Close()
            userpassDBConn.Dispose()
        End Try
        TextBox_Username.Select()
    End Sub

    Private Sub Button_ExitLogin_Click(sender As System.Object, e As System.EventArgs) Handles Button_ExitLogin.Click
        Dim ExitYN As System.Windows.Forms.DialogResult
        ExitYN = MsgBox("Do you really want to exit?", MsgBoxStyle.YesNo)
        If ExitYN = MsgBoxResult.Yes Then
            Application.Exit()
            End
        Else
        End If
    End Sub

    Private Sub Button_Login_Click(sender As System.Object, e As System.EventArgs) Handles Button_Login.Click
        Me.Cursor = Cursors.WaitCursor

        If (Process_Login()) Then
            Show_Logged_In()
        Else
            Label_Login.Visible = False
            Label_IncorrectUserPass.Visible = True
        End If

    End Sub

    ''' <summary>
    ''' Attempts to log the user in.
    ''' </summary>
    ''' <returns>The success of the login.</returns>
    ''' <remarks></remarks>
    Private Function Process_Login() As Boolean
        Try
            userpassDBConn.Open()
            Dim Query As String
            Query = "select * from userpass.userpass where Username = '" & TextBox_Username.Text & "' and Password = '" & TextBox_Password.Text & "'"
            COMMAND = New MySqlCommand(Query, userpassDBConn)
            READER = COMMAND.ExecuteReader()
            Dim count As Integer
            count = 0

            While READER.Read
                count = count + 1
            End While

            If count = 1 Then
                username = READER.GetString("FirstName") & " " & READER.GetString("LastName")
            Else
                If count > 1 Then
                    MessageBox.Show("There is more than one entry for this username and password, contact database administrator.")
                End If

                Return False

            End If
        Catch ex As MySqlException
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        Finally
            userpassDBConn.Close()
            userpassDBConn.Dispose()
            Me.Cursor = Cursors.Default
        End Try

        activeUser = username

        Return True
    End Function

    ''' <summary>
    ''' Changes the form to the logged in appearance.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Show_Logged_In()
        CheckBox_LocalServer.Enabled = False
        Label_LoginName.Text = activeUser
        Label_LoginName.Visible = True
        Label_LoggedInAs.Visible = True
        Label_Login.Visible = False
        Button_Login.Visible = False
        Label_IncorrectUserPass.Visible = False
        Button_Logout.Visible = True
        RadioButton_Commissioning.Visible = True
        RadioButton_AnnualQA.Visible = True
        RadioButton_Commissioning.Checked = True
        Label_Server.Text = "(" & ConfigurationManager.AppSettings("ActiveServer") & ")"
        If Label_Server.Text = "(localhost)" Then
            CheckBox_LocalServer.Checked = True
        End If
        If Commissioning Then
            RadioButton_Commissioning.Checked = True
            Button_NewSite.Visible = True
            Label_Existing.Visible = True
            Label_Linac.Visible = True
            ComboBox_Existing.Visible = True
            ComboBox_Linac.Visible = True
            Button_Next.Visible = True
            Commissioning = True           
        Else
            RadioButton_AnnualQA.Checked = True
            Button_NewSite.Visible = False
            Label_Existing.Visible = False
            Label_Linac.Visible = False
            ComboBox_Existing.Visible = False
            ComboBox_Linac.Visible = False
            Button_Next.Visible = False
            Commissioning = False
        End If
        Populate_Existing_Sites()
    End Sub

    ''' <summary>
    ''' Changes the form to the logged out appearance.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Show_Logged_Out()
        CheckBox_LocalServer.Enabled = True
        Label_LoginName.Visible = False
        Label_LoggedInAs.Visible = False
        Button_NewSite.Visible = False
        Label_Existing.Visible = False
        Label_Linac.Visible = False
        ComboBox_Existing.Visible = False
        ComboBox_Linac.Visible = False
        Label_Login.Visible = False
        Button_Next.Visible = False
        Button_Login.Visible = True
        Button_Logout.Visible = False
    End Sub

    ''' <summary>
    ''' Populates the existing site ComboBox Linac TextBox with the existing sites from the database.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Populate_Existing_Sites()
        Dim existingSiteAdapter As MySqlDataAdapter
        Dim existingSites As New DataSet()
        Dim dt As New DataTable()

        Try
            sitesDBConn.Open()
            existingSiteAdapter = New MySqlDataAdapter("SELECT idsiteinfo, SiteName, City, State, LinacModel, LinacSerial FROM siteinfo", sitesDBConn)
            existingSiteAdapter.Fill(existingSites)
            existingSiteAdapter.Dispose()

            dt.Columns.Add("ExistingSite")
            dt.Columns.Add("SiteID")
            dt.Columns.Add("Linac")

            ' Format ComboBox_ExistingSite displaymember entry as "SiteName - City, State" and valuemember entry values as ID_SiteName
            ' TextBox_Linac as LinacModel, #LinacSerial

            For i As Integer = 0 To existingSites.Tables(0).Rows.Count - 1
                dt.Rows.Add()
                dt.Rows(i).Item(0) = existingSites.Tables(0).Rows(i).Field(Of String)(1) & " - " & _
                            existingSites.Tables(0).Rows(i).Field(Of String)(2) & ", " & _
                            existingSites.Tables(0).Rows(i).Field(Of String)(3)
                dt.Rows(i).Item(1) = existingSites.Tables(0).Rows(i).Field(Of Integer)(0).ToString() & "_" & _
                            existingSites.Tables(0).Rows(i).Field(Of String)(1)
                dt.Rows(i).Item(2) = existingSites.Tables(0).Rows(i).Field(Of String)(4) & ", #" & _
                            existingSites.Tables(0).Rows(i).Field(Of String)(5)
                totalSiteNumber = i + 1
            Next
            ComboBox_Existing.DataSource = dt
            ComboBox_Linac.DataSource = dt
            ComboBox_Existing.DisplayMember = "ExistingSite"
            ComboBox_Existing.ValueMember = "SiteID"
            ComboBox_Linac.DisplayMember = "Linac"
            ComboBox_Linac.ValueMember = "SiteID"

            sitesDBConn.Close()
            sitesDBConn.Dispose()
        Catch mysqlEx As MySqlException
            MessageBox.Show(mysqlEx.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Button_New_Click(sender As System.Object, e As System.EventArgs) Handles Button_NewSite.Click
        activeSite = Nothing
        activeSiteName = ""
        Form_EditSite.Show()
        Me.Close()
    End Sub

    Private Sub Button_Next_Click(sender As System.Object, e As System.EventArgs) Handles Button_Next.Click
        If (ComboBox_Existing.SelectedValue Is Nothing) Then
            MessageBox.Show("A site must be chosen to continue. If no sites exist, press new site to create one.")
            Return
        End If
        Dim site As New Site(sitesDBConn, ComboBox_Existing.SelectedValue)
        activeSite = site
        Form_SiteInfo.Show()
        Me.Close()
    End Sub

    Public Sub Button_Logout_Click(sender As Object, e As EventArgs) Handles Button_Logout.Click
        activeUser = ""
        username = ""

        TextBox_Username.Text = ""
        TextBox_Password.Text = ""

        Show_Logged_Out()
    End Sub

    Private Sub RadioButton_Commissioning_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_Commissioning.CheckedChanged
        Button_NewSite.Visible = True
        Label_Existing.Visible = True
        Label_Linac.Visible = True
        ComboBox_Existing.Visible = True
        ComboBox_Linac.Visible = True
        Button_Next.Visible = True
        Commissioning = True
    End Sub

    Private Sub RadioButton_AnnualQA_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_AnnualQA.CheckedChanged
        Button_NewSite.Visible = False
        Label_Existing.Visible = False
        Label_Linac.Visible = False
        ComboBox_Existing.Visible = False
        ComboBox_Linac.Visible = False
        Button_Next.Visible = False
        Commissioning = False
    End Sub


    Private Sub ComboBox_Existing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Existing.SelectedIndexChanged
        Dim index As Integer
        index = ComboBox_Existing.SelectedIndex
        ComboBox_Linac.SelectedIndex = ComboBox_Linac.Items.IndexOf(index)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_LocalServer.CheckedChanged
        Dim activeServerLocal As Boolean = False
        If CType(sender, CheckBox).Checked Then
            ConfigurationManager.AppSettings("ActiveServer") = ConfigurationManager.AppSettings("LocalServer")
        Else
            ConfigurationManager.AppSettings("ActiveServer") = ConfigurationManager.AppSettings("RemoteServer")
        End If

        Connect_To_Database()
    End Sub

    Private Sub Panel_Top_Paint(sender As Object, e As PaintEventArgs) Handles Panel_Top.Paint

    End Sub
End Class