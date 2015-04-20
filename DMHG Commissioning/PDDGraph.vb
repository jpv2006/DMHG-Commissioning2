Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Windows.Forms.DataVisualization.Charting

Public Class PDDGraph
    '=========================================================================================
    '
    ' Provides graphing for the PDD values.
    ' Graph1 - Square Fields only
    '
    ' Uploaded: 4/16/2015
    '
    ' 4/16/2015: Original code (copied from ScpGraph).
    '
    '=========================================================================================

    Dim MaxAxisPosition = 45
    Dim MinAxisPosition = 0
    Public DBPDDData As New DataTable
    Dim dt As DataTable
    Dim factorsDBConn As MySqlConnection

    Private Sub PDDGraph_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        ' Set up Chart parameters
        '
        Label_GraphHeader.Text = activeSiteName & " - "
        ' Square field PDD Chart
        ChartTitles(Chart_PDD, "Square Fields PDD")
        ChartSetup(Chart_PDD)

    End Sub

    Private Sub ChartTitles(c As Chart, cTitle As String)
        '
        ' WORKING WITH TITLE 
        '
        ' Adding a Title
        Dim T As Title = c.Titles.Add(cTitle)
        ' Formatting the Title
        With T
            .ForeColor = Color.Black              ' Changing the Fore Color of the Title 
            .BackColor = Color.LightBlue          ' Changing the Back Color of the Title 

            ' Setting Font, Font Size and Bold/Italicizing
            .Font = New System.Drawing.Font("Times New Roman", 11.0F, System.Drawing.FontStyle.Bold)
            .BorderColor = Color.Black              ' Changing the Border Color of the Title 
            .BorderDashStyle = ChartDashStyle.Solid ' Changing the Border Dash Style of the Title 
        End With
    End Sub

    Private Sub ChartSetup(c As Chart)
        c.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
        c.ChartAreas(0).AxisX.Minimum = MinAxisPosition
        c.ChartAreas(0).AxisX.Maximum = MaxAxisPosition
        c.ChartAreas(0).AxisX.Interval = 5
        c.ChartAreas(0).AxisX.MinorGrid.Interval = 1
        c.ChartAreas(0).AxisX.MinorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dash
        c.ChartAreas(0).AxisX.MinorGrid.Enabled = True
        c.ChartAreas(0).AxisX.MinorGrid.LineColor = Color.LightGray

        c.ChartAreas(0).AxisY.Minimum = 0.8
        c.ChartAreas(0).AxisY.Maximum = 1.3
        c.ChartAreas(0).AxisY.Interval = 0.2
        c.ChartAreas(0).AxisY.MinorGrid.Interval = 0.1
        c.ChartAreas(0).AxisY.MinorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dash
        c.ChartAreas(0).AxisY.MinorGrid.Enabled = True
        c.ChartAreas(0).AxisY.MinorGrid.LineColor = Color.LightGray

        c.ChartAreas(0).AxisX.Title = "Field Size"
        c.ChartAreas(0).AxisY.Title = "PDD"

        c.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
        c.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
        c.ChartAreas(0).AxisX.ScaleView.Zoomable = True
        c.ChartAreas(0).AxisY.ScaleView.Zoomable = True

        c.ChartAreas(0).AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.ResetZoom
        c.ChartAreas(0).AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.ResetZoom

    End Sub

    Private Sub GetPDDData(SCPdt As DataTable, wdg As Integer, SSD As Integer)
        '
        ' Retrieves the PDD data from the database for wedge angle 'wdg' (0 for Open Field)
        ' sorts in ascending field order and
        ' stores in DataTable DBScpData
        '
        Dim stm As String = "SELECT * FROM photon_pdd WHERE Energy = '" & activePhotonEnergy & "' AND wedgeangle = " & ToString(wdg) & " AND SSD = " & SSD

        factorsDBConn = New MySqlConnection(ConfigurationManager.ConnectionStrings("noDB").ConnectionString & "database=" & activeSite.factors)

        Try
            factorsDBConn.Open()

            Dim da As New MySqlDataAdapter(stm, factorsDBConn)
            Dim ds As New DataSet

            da.Fill(ds, "photon_scp")
            '
            ' Now sort the table in increasing field size
            '
            Dim dt As New DataTable
            dt = ds.Tables("photon_scp")
            Dim view As New DataView(dt)
            view.Sort = "X ASC, Y ASC"
            DBPDDData = view.ToTable()
            SCPdt = view.ToTable()

        Catch ex As MySqlException
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            factorsDBConn.Close()
        End Try

    End Sub

    Private Sub Chart_Update(dt As DataTable, wdg As Integer, SSD As Integer)

        '==================================================================
        '  Data is held im DataTable DBScpData from database
        '  need to separate it out into
        '   - square field data
        '==================================================================
        '
        ' Read in PDD database to DataTable
        '
        GetPDDData(dt, wdg, SSD)
        '
        '=================================================================

        Dim NDepths = DBPDDData.Rows.Count
        Dim iSeries As Integer
        '
        ' Dim (x,y) matrices for points
        '
        Dim SqPDDX(NDepths)     ' Depths
        Dim SqPDDY(NDepths)     ' PDD Values

        '=================================================================
        '
        ' Fill the Multi-Scp Array
        '
        Chart_PDD.Series.Clear()
        '
        ' Count the number of field sizes in the PDD Table
        ' and parse out Field Sizes
        '
        Dim name(DBPDDData.Columns.Count) As String     ' Holds Column Names
        Dim FS(DBPDDData.Columns.Count) As Single       ' Holds Field Sizes

        Dim kount As Integer = 0
        For Each column As DataColumn In DBPDDData.Columns
            name(kount) = column.ColumnName
            FS(kount) = Val(name(kount).Substring(0, name(kount).IndexOf("x") - 1))
            kount += 1
        Next
        kount = kount - 6       ' first 6 column of PDD Table is information, not data
        '
        ' Main loop - run through each column at a time
        '
        For pddcol = 1 To kount                  ' Assume FS data starts in column 7

            Dim MultPDDX(kount)                 ' All PDD FS Data for series
            Dim MultPDDY(kount)                 ' All PDD Data for series

            For Each drow As DataRow In DBPDDData.Rows

                MultPDDX(pddcol) = drow.Item("Depth")
                MultPDDY(pddcol) = drow.Item(name(pddcol + 6))

            Next drow

            iSeries = pddcol ' Chart Series number
            Chart_PDD.Series(pddcol).Name = name(pddcol + 6)

            SetUpPDDChart(Chart_PDD, pddcol, iSeries, MultPDDX, MultPDDY)
        Next

    End Sub

    Private Function CountPDDFields()
        '
        ' Count the number of field sizes in the PDD Table
        '
        Dim kcount As Integer
        Dim name(DBPDDData.Columns.Count) As String     ' Holds Column Names
        Dim FS(DBPDDData.Columns.Count) As Single       ' Holds Field Sizes

        Dim i As Integer = 0
        For Each column As DataColumn In DBPDDData.Columns
            name(i) = column.ColumnName
            FS(i) = Val(name(i).Substring(0, name(i).IndexOf("x") - 1))
            i += 1
        Next

        kcount = i

        Return kcount

    End Function

    Private Sub SetUpPDDChart(c As Chart, k As Integer, iSeries As Integer, PointX As Array, PointY As Array)

        c.Series.Add(iSeries)
        c.Series(iSeries).ChartType = DataVisualization.Charting.SeriesChartType.Line
        c.Series(iSeries).Points.DataBindXY(PointX, PointY)
        c.Update()

        For Each dp As DataPoint In c.Series(iSeries).Points
            dp.MarkerStyle = MarkerStyle.Diamond
            dp.MarkerSize = 8
            dp.BorderWidth = 2
            dp.ToolTip = "#SERIESNAME X #VALX{N1}, Scp: #VALY{N3}"
        Next dp
        Chart_PDD.ChartAreas(0).RecalculateAxesScale()
    End Sub

End Class