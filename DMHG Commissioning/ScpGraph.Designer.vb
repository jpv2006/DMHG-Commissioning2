<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScpGraph
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart_SCP = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart_AllScp = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label_GraphHeader = New System.Windows.Forms.Label()
        CType(Me.Chart_SCP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart_AllScp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart_SCP
        '
        Me.Chart_SCP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart_SCP.BorderlineColor = System.Drawing.Color.Black
        Me.Chart_SCP.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Chart_SCP.BorderlineWidth = 2
        ChartArea1.Name = "ChartArea1"
        Me.Chart_SCP.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart_SCP.Legends.Add(Legend1)
        Me.Chart_SCP.Location = New System.Drawing.Point(42, 33)
        Me.Chart_SCP.Name = "Chart_SCP"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart_SCP.Series.Add(Series1)
        Me.Chart_SCP.Size = New System.Drawing.Size(1274, 472)
        Me.Chart_SCP.TabIndex = 1
        Me.Chart_SCP.Text = "Chart2"
        '
        'Chart_AllScp
        '
        Me.Chart_AllScp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart_AllScp.BorderlineColor = System.Drawing.Color.Black
        Me.Chart_AllScp.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Chart_AllScp.BorderlineWidth = 2
        ChartArea2.Name = "ChartArea1"
        Me.Chart_AllScp.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart_AllScp.Legends.Add(Legend2)
        Me.Chart_AllScp.Location = New System.Drawing.Point(42, 492)
        Me.Chart_AllScp.Name = "Chart_AllScp"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart_AllScp.Series.Add(Series2)
        Me.Chart_AllScp.Size = New System.Drawing.Size(1274, 488)
        Me.Chart_AllScp.TabIndex = 2
        Me.Chart_AllScp.Text = "Chart3"
        '
        'Label_GraphHeader
        '
        Me.Label_GraphHeader.AutoSize = True
        Me.Label_GraphHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_GraphHeader.Location = New System.Drawing.Point(28, 9)
        Me.Label_GraphHeader.Name = "Label_GraphHeader"
        Me.Label_GraphHeader.Size = New System.Drawing.Size(63, 20)
        Me.Label_GraphHeader.TabIndex = 3
        Me.Label_GraphHeader.Text = "Label1"
        '
        'ScpGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1373, 980)
        Me.Controls.Add(Me.Label_GraphHeader)
        Me.Controls.Add(Me.Chart_AllScp)
        Me.Controls.Add(Me.Chart_SCP)
        Me.Name = "ScpGraph"
        Me.Text = "Scp Graph"
        CType(Me.Chart_SCP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart_AllScp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart_SCP As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart_AllScp As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label_GraphHeader As System.Windows.Forms.Label
End Class

