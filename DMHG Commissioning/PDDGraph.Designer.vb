<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDDGraph
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
        Me.Chart_PDD = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label_GraphHeader = New System.Windows.Forms.Label()
        CType(Me.Chart_PDD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart_PDD
        '
        Me.Chart_PDD.BorderlineColor = System.Drawing.Color.Black
        Me.Chart_PDD.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Chart_PDD.BorderlineWidth = 2
        ChartArea1.Name = "ChartArea1"
        Me.Chart_PDD.ChartAreas.Add(ChartArea1)
        Me.Chart_PDD.ImeMode = System.Windows.Forms.ImeMode.Off
        Legend1.Name = "Legend1"
        Me.Chart_PDD.Legends.Add(Legend1)
        Me.Chart_PDD.Location = New System.Drawing.Point(12, 38)
        Me.Chart_PDD.Name = "Chart_PDD"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart_PDD.Series.Add(Series1)
        Me.Chart_PDD.Size = New System.Drawing.Size(861, 491)
        Me.Chart_PDD.TabIndex = 2
        Me.Chart_PDD.Text = "ChartPDD"
        '
        'Label_GraphHeader
        '
        Me.Label_GraphHeader.AutoSize = True
        Me.Label_GraphHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_GraphHeader.Location = New System.Drawing.Point(12, 9)
        Me.Label_GraphHeader.Name = "Label_GraphHeader"
        Me.Label_GraphHeader.Size = New System.Drawing.Size(63, 20)
        Me.Label_GraphHeader.TabIndex = 4
        Me.Label_GraphHeader.Text = "Label1"
        '
        'PDDGraph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 582)
        Me.Controls.Add(Me.Label_GraphHeader)
        Me.Controls.Add(Me.Chart_PDD)
        Me.Name = "PDDGraph"
        Me.Text = "PDDGraph"
        CType(Me.Chart_PDD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart_PDD As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label_GraphHeader As System.Windows.Forms.Label
End Class
