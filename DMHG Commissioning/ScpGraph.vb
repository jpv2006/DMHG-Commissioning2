Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Windows.Forms.DataVisualization.Charting




Public Class ScpGraph
    '=========================================================================================
    '
    ' Provides graphing for the Scp values.
    ' Graph1 - Square Fields only
    ' Graph2 - Rectangular Fields (Multi Series)
    '
    ' Uploaded: 2/9/2015
    '
    ' 2/9/2015: Added Hover tooltips to data points.
    ' 4/2/2015: Integrated into DMHG Commissioning latest version.
    '
    '=========================================================================================

    Dim MaxAxisPosition = 45
    Dim MinAxisPosition = 0
    Public DBscpData As New DataTable
    Dim dt As DataTable
    Dim factorsDBConn As MySqlConnection

    Public Sub Form_SCPGraph_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        ' Set up Chart parameters
        '
        Label_GraphHeader.Text = activeSiteName & " - " & activeMeasurement
        ' Square field Chart
        ChartTitles(Chart_SCP, "Square Fields Scp")
        ChartSetup(Chart_SCP)
        '
        ' Multi plot Chart
        ChartTitles(Chart_AllScp, "Scp vs. Field Size")
        ChartSetup(Chart_AllScp)
        '
        ' Parse the data and assign to Series
        '
        'Chart_Update()

    End Sub

    Public Sub Chart_Update(dt As DataTable)

        '  Data is held im DataTable DBScpData from database
        '  need to separate it out into
        '   - square field data
        '   - multiple series data
        '  for the two separate graphs.

        ' Array data is: Row, X, Y, Reading1, Reading2, Average, Scp
        '
        '==================================================================
        '
        ' Read in SCP database to DataTable
        '
        GetScpData(dt)
        Label_GraphHeader.Text = activeSiteName & " - " & activeMeasurement

        '
        '=================================================================

        Dim NPoints = DBscpData.Rows.Count
        Dim i, j, k, kSq, l, iSeries As Integer
        '
        ' Determine number of square fields sizes for plot
        '
        kSq = CountSquareFields() - 1
        '
        ' Dim (x,y) matrices for points
        '
        Dim SqScpX(kSq)   ' Square Field data
        Dim SqScpY(kSq)
        '================================================================
        '
        'Parse the Square Field data
        '
        j = 0
        For i = 0 To NPoints - 1
            If DBscpData.Rows(i).Item("X") = DBscpData.Rows(i).Item("Y") Then
                If DBscpData.Rows(i).Item("Scp").ToString <> "" Then
                    SqScpX(j) = DBscpData.Rows(i).Item("Y")
                    SqScpY(j) = DBscpData.Rows(i).Item("Scp")
                    j = j + 1
                End If
            End If
        Next i
        '
        '=================================================================
        ' Plot Square Field Sizes
        '
        Chart_SCP.Series(0).Points.DataBindXY(SqScpX, SqScpY)
        Chart_SCP.ChartAreas(0).RecalculateAxesScale()
        '
        ' Define point marker, style, etc
        '
        Chart_SCP.Series(0).Name = "Sq Scp"
        For Each dp As DataPoint In Chart_SCP.Series(0).Points
            dp.MarkerStyle = MarkerStyle.Diamond
            dp.MarkerColor = Color.Crimson
            dp.MarkerSize = 8
            '  dp.Color = Color.DarkRed
            dp.BorderColor = Color.DarkRed
            dp.BorderWidth = 2
            dp.ToolTip = "Field: #VALX{N1}, Scp: #VALY{N3}"

        Next dp

        '=================================================================
        '
        ' Fill the Multi-Scp Array
        '
        Chart_AllScp.Series.Clear()



        k = DBscpData.Rows(0).Item("X")     ' initial field size
        l = CountMultiFields(k)             ' How many fields in this series
        Dim MultSCPX(l)                     ' All Scp X Data for multiple series
        Dim MultSCPY(l)                     ' All Scp Y Data for multiple series

        i = 0       ' initialize matrix index
        iSeries = 0 ' Chart Series number

        For Each drow As DataRow In DBscpData.Rows

            If drow.Item("X") = k Then
                '
                ' If a match - store data
                '
                MultSCPX(i) = drow.Item("Y") ' Y Jaw, Varies
                MultSCPY(i) = drow.Item("Scp") ' Scp Value
                i = i + 1
            Else
                ' No match - must be next field size
                ' Set up series for Chart and plot
                '
                SetUpMultiChart(Chart_AllScp, k, iSeries, MultSCPX, MultSCPY)

                'Reset Matrices for next series
                k = drow.Item("X")   ' reset Field Size
                l = CountMultiFields(k)
                ReDim MultSCPX(l) ' All Scp X Data for multiple series
                ReDim MultSCPY(l) ' All Scp Y Data for multiple series
                i = 0
                '
                ' Following needed to pick up current field data
                ' before continuing loop
                '
                MultSCPX(i) = drow.Item("Y")    ' Y Jaw, Varies
                MultSCPY(i) = drow.Item("Scp")  ' Scp Value
                iSeries = iSeries + 1
                i = i + 1
            End If
        Next drow
        '
        ' plot last series
        '
        SetUpMultiChart(Chart_AllScp, k, iSeries, MultSCPX, MultSCPY)

    End Sub
    Private Sub SetUpMultiChart(c As Chart, k As Integer, iSeries As Integer, PointX As Array, PointY As Array)

        c.Series.Add(iSeries)
        c.Series(iSeries).ChartType = DataVisualization.Charting.SeriesChartType.Line
        c.Series(iSeries).Name = "FS " & k.ToString("00.0")
        c.Series(iSeries).Points.DataBindXY(PointX, PointY)
        c.Update()

        For Each dp As DataPoint In c.Series(iSeries).Points
            dp.MarkerStyle = MarkerStyle.Diamond
            dp.MarkerSize = 8
            dp.BorderWidth = 2
            dp.ToolTip = "#SERIESNAME X #VALX{N1}, Scp: #VALY{N3}"
        Next dp
        Chart_SCP.ChartAreas(0).RecalculateAxesScale()

    End Sub
    Private Sub Button_Exit_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Public Sub GetScpData(SCPdt As DataTable)
        '
        ' Retrieves the Scp data from the database,
        ' sorts in ascending field order and
        ' stores in DataTable DBScpData
        'activeMeasurement = "Scp at dmax, Total Scatter Factor  -  " & activePhotonEnergy
        'activeMeasurementTableName = "photon_scp2"
        'activeMeasurementType = "Scp"
        '
        Dim stm As String = "SELECT * FROM " & activeMeasurementTableName & " WHERE Energy = '" & activePhotonEnergy & "' AND " & activeMeasurementType & " IS NOT NULL"

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
            DBscpData = view.ToTable()
            SCPdt = view.ToTable()

        Catch ex As MySqlException
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            factorsDBConn.Close()
        End Try

    End Sub
    Function CountSquareFields()
        '
        ' Count the number of Square fields in the dataset
        '
        Dim i, kcount As Integer

        kcount = 0
        For i = 0 To DBscpData.Rows.Count - 1
            If DBscpData.Rows(i).Item("X") = DBscpData.Rows(i).Item("Y") Then
                '
                ' Filter out blank data
                If DBscpData.Rows(i).Item("Scp").ToString <> "" Then
                    ' Debug.WriteLine("i=" & i & " kcoount=" & kcount & " Scp=" & DBscpData.Rows(i).Item("Scp"))
                    kcount = kcount + 1
                End If
            End If
        Next i
        Return kcount

    End Function

    Function CountMultiFields(k As Integer)
        '
        ' For a field size 'k'
        ' Count the number of associated field sizes in the Table
        '
        Dim i, kcount As Integer

        kcount = 0
        For i = 0 To DBscpData.Rows.Count - 1
            If DBscpData.Rows(i).Item("X") = k Then
                '  If DBscpData.Rows(i).Item("Scp").ToString <> "" Then
                kcount = kcount + 1
                'End If
            End If
        Next i
        Return kcount

    End Function

    Private Sub Chart_SCP_Click(sender As Object, e As EventArgs) Handles Chart_SCP.Click
        Chart_SCP.ChartAreas(0).AxisX.ScaleView.ZoomReset(0)

    End Sub
    Sub ChartTitles(c As Chart, cTitle As String)
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
    Sub ChartSetup(c As Chart)
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
        c.ChartAreas(0).AxisY.Title = "Scp"

        c.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
        c.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
        c.ChartAreas(0).AxisX.ScaleView.Zoomable = True
        c.ChartAreas(0).AxisY.ScaleView.Zoomable = True

        c.ChartAreas(0).AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.ResetZoom
        c.ChartAreas(0).AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.ResetZoom

    End Sub


    'Private Sub Chart_AllScp_AxisViewChanged(sender As Object, e As ViewEventArgs) Handles Chart_AllScp.AxisViewChanged
    '    '
    '    ' rescale Y-axis when x-axis is zoomed
    '    '
    '    Dim axisY = Chart_AllScp.ChartAreas(0).AxisY
    '    Dim totalXRange = e.Axis.Maximum - e.Axis.Minimum
    '    Dim totalYRange = axisY.Maximum - axisY.Minimum
    '    Dim ySelectionStart = (e.Axis.ScaleView.ViewMinimum - e.Axis.Minimum) * totalYRange / totalXRange
    '    Dim ySelectionEnd = (e.Axis.ScaleView.ViewMaximum - e.Axis.Minimum) * totalYRange / totalXRange

    '    axisY.ScaleView.Zoom(ySelectionStart, ySelectionEnd)

    'End Sub
End Class