Public Class DataToCollect

    Private Sub Form_DataToCollect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim myLabel As Label = New Label()
        Dim myLinkLabel As LinkLabel = New LinkLabel
        Me.Label_Linac.Text = activeSiteName
        Me.Label_Linac.Show()
        Me.Label_Linac.Visible = True
        For i = 1 To pEnergyNum
            myLabel = Me.GroupBox_PhotonFactors.Controls("Label_P" & i)
            myLabel.Text = activeSite.pEnergyNames(i - 1)
            myLabel.Enabled = True
            myLabel.BackColor = Color.LightBlue
            myLabel = Me.GroupBox_PhotonScans.Controls("Label_P" & i & "S")
            myLabel.Text = activeSite.pEnergyNames(i - 1)
            myLabel.Enabled = True
            myLabel.BackColor = Color.LightBlue
            myLinkLabel = Me.GroupBox_PhotonFactors.Controls("LinkLabel_P" & i & "Scp")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
            myLinkLabel = Me.GroupBox_PhotonFactors.Controls("LinkLabel_P" & i & "Scp2")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
            myLinkLabel = Me.GroupBox_PhotonFactors.Controls("LinkLabel_P" & i & "Sc")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
            myLinkLabel = Me.GroupBox_PhotonFactors.Controls("LinkLabel_P" & i & "WF")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
            myLinkLabel = Me.GroupBox_PhotonFactors.Controls("LinkLabel_P" & i & "EDWF")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
            myLinkLabel = Me.GroupBox_PhotonFactors.Controls("LinkLabel_P" & i & "MLCTF")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
            myLinkLabel = Me.GroupBox_PhotonFactors.Controls("LinkLabel_P" & i & "MLCDLG")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
            myLinkLabel = Me.GroupBox_PhotonFactors.Controls("LinkLabel_P" & i & "AccF")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
            myLinkLabel = Me.GroupBox_PhotonScans.Controls("LinkLabel_P" & i & "Scans")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
            myLinkLabel = Me.GroupBox_PhotonScans.Controls("LinkLabel_P" & i & "TMR")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
        Next
        For i = 1 To eEnergyNum
            myLabel = Me.GroupBox_ElectronFactorsScans.Controls("Label_E" & i)
            myLabel.Text = activeSite.eEnergyNames(i - 1)
            myLabel.Enabled = True
            myLabel.BackColor = Color.LightBlue
            myLabel = Me.GroupBox_ElectronFactorsScans.Controls("Label_E" & i & "S")
            myLabel.Text = activeSite.eEnergyNames(i - 1)
            myLabel.Enabled = True
            myLabel.BackColor = Color.LightBlue
            myLinkLabel = Me.GroupBox_ElectronFactorsScans.Controls("LinkLabel_E" & i & "OF")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
            myLinkLabel = Me.GroupBox_ElectronFactorsScans.Controls("LinkLabel_E" & i & "Cutout")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
            myLinkLabel = Me.GroupBox_ElectronFactorsScans.Controls("LinkLabel_E" & i & "Scans")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
            myLinkLabel = Me.GroupBox_ElectronFactorsScans.Controls("LinkLabel_E" & i & "AirScans")
            myLinkLabel.Enabled = True
            myLinkLabel.BackColor = Color.Crimson
        Next
    End Sub

    Private Sub Button_Back_Click(sender As System.Object, e As System.EventArgs) Handles Button_Back.Click
        Form_SiteInfo.Show()
        Me.Close()
    End Sub

    Private Sub LinkLabel_P1Scp_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P1Scp.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(0)
        activeMeasurement = "Scp at d10, Total Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_scp"
        activeMeasurementType = "Scp"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P1Scp2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P1Scp2.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(0)
        activeMeasurement = "Scp at dmax, Total Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_scp2"
        activeMeasurementType = "Scp"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P1Sc_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P1Sc.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(0)
        activeMeasurement = "Sc, Collimator Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_sc"
        activeMeasurementType = "Sc"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P1WF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P1WF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(0)
        activeMeasurement = "WF, Wedge Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_wedgefactors"
        activeMeasurementType = "WF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P1EDWF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P1EDWF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(0)
        activeMeasurement = "EWF, Electronic Wedge Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_edw_factors"
        activeMeasurementType = "EDW_WF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P1MLCTF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P1MLCTF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(0)
        activeMeasurement = "MLC-TF, MLC Transmisison Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_mlc_tf"
        activeMeasurementType = "MLC_TF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P1MLCDLG_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P1MLCDLG.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(0)
        activeMeasurement = "MLC-DLG, MLC Dynamic Leaf Gap  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_mlc_dlg"
        activeMeasurementType = "MLC_LG"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P1AccF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P1AccF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(0)
        activeMeasurement = "AccF, Accessory Factors  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_accessory_tf"
        activeMeasurementType = "TF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P1Scans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P1Scans.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(0)
        activeMeasurement = "Photon Scans  -  " & activePhotonEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P1TMR_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P1TMR.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(0)
        activeMeasurement = "Photon TMR Scans  -  " & activePhotonEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P2Scp_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P2Scp.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(1)
        activeMeasurement = "Scp at d10, Total Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_scp"
        activeMeasurementType = "Scp"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P2Scp2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P2Scp2.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(1)
        activeMeasurement = "Scp at dmax, Total Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_scp2"
        activeMeasurementType = "Scp"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P2Sc_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P2Sc.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(1)
        activeMeasurement = "Sc, Collimator Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_sc"
        activeMeasurementType = "Sc"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P2WF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P2WF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(1)
        activeMeasurement = "WF, Wedge Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_wedgefactors"
        activeMeasurementType = "WF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P2EDWF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P2EDWF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(1)
        activeMeasurement = "EWF, Electronic Wedge Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_edw_factors"
        activeMeasurementType = "EDW_WF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P2MLCTF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P2MLCTF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(1)
        activeMeasurement = "MLC-TF, MLC Transmisison Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_mlc_tf"
        activeMeasurementType = "MLC_TF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P2MLCDLG_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P2MLCDLG.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(1)
        activeMeasurement = "MLC-DLG, MLC Dynamic Leaf Gap  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_mlc_dlg"
        activeMeasurementType = "MLC_LG"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P2AccF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P2AccF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(1)
        activeMeasurement = "AccF, Accessory Factors  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_accessory_tf"
        activeMeasurementType = "TF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P2Scans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P2Scans.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(1)
        activeMeasurement = "Photon Scans  -  " & activePhotonEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P2TMR_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P2TMR.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(1)
        activeMeasurement = "Photon TMR Scans  -  " & activePhotonEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P3Scp_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P3Scp.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(2)
        activeMeasurement = "Scp at d10, Total Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_scp"
        activeMeasurementType = "Scp"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P3Scp2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P3Scp2.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(2)
        activeMeasurement = "Scp at dmax, Total Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_scp2"
        activeMeasurementType = "Scp"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P3Sc_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P3Sc.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(2)
        activeMeasurement = "Sc, Collimator Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_sc"
        activeMeasurementType = "Sc"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P3WF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P3WF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(2)
        activeMeasurement = "WF, Wedge Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_wedgefactors"
        activeMeasurementType = "WF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P3EDWF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P3EDWF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(2)
        activeMeasurement = "EWF, Electronic Wedge Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_edw_factors"
        activeMeasurementType = "EDW_WF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P3MLCTF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P3MLCTF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(2)
        activeMeasurement = "MLC-TF, MLC Transmisison Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_mlc_tf"
        activeMeasurementType = "MLC_TF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P3MLCDLG_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P3MLCDLG.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(2)
        activeMeasurement = "MLC-DLG, MLC Dynamic Leaf Gap  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_mlc_dlg"
        activeMeasurementType = "MLC_LG"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P3AccF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P3AccF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(2)
        activeMeasurement = "AccF, Accessory Factors  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_accessory_tf"
        activeMeasurementType = "TF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P3Scans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P3Scans.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(2)
        activeMeasurement = "Photon Scans  -  " & activePhotonEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P3TMR_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P3TMR.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(2)
        activeMeasurement = "Photon TMR Scans  -  " & activePhotonEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P4Scp_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P4Scp.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(3)
        activeMeasurement = "Scp at d10, Total Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_scp"
        activeMeasurementType = "Scp"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P4Scp2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P4Scp2.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(3)
        activeMeasurement = "Scp at dmax, Total Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_scp2"
        activeMeasurementType = "Scp"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P4Sc_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P4Sc.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(3)
        activeMeasurement = "Sc, Collimator Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_sc"
        activeMeasurementType = "Sc"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P4WF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P4WF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(3)
        activeMeasurement = "WF, Wedge Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_wedgefactors"
        activeMeasurementType = "WF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P4EDWF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P4EDWF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(3)
        activeMeasurement = "EWF, Electronic Wedge Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_edw_factors"
        activeMeasurementType = "EDW_WF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P4MLCTF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P4MLCTF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(3)
        activeMeasurement = "MLC-TF, MLC Transmisison Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_mlc_tf"
        activeMeasurementType = "MLC_TF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P4MLCDLG_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P4MLCDLG.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(3)
        activeMeasurement = "MLC-DLG, MLC Dynamic Leaf Gap  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_mlc_dlg"
        activeMeasurementType = "MLC_LG"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P4AccF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P4AccF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(3)
        activeMeasurement = "AccF, Accessory Factors  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_accessory_tf"
        activeMeasurementType = "TF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P4Scans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P4Scans.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(3)
        activeMeasurement = "Photon Scans  -  " & activePhotonEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P4TMR_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P4TMR.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(3)
        activeMeasurement = "Photon TMR Scans  -  " & activePhotonEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P5Scp_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P5Scp.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(4)
        activeMeasurement = "Scp at d10, Total Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_scp"
        activeMeasurementType = "Scp"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P5Scp2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P5Scp2.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(4)
        activeMeasurement = "Scp at dmax, Total Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_scp2"
        activeMeasurementType = "Scp"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P5Sc_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P5Sc.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(4)
        activeMeasurement = "Sc, Collimator Scatter Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_sc"
        activeMeasurementType = "Sc"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P5WF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P5WF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(4)
        activeMeasurement = "WF, Wedge Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_wedgefactors"
        activeMeasurementType = "WF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P5EDWF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P5EDWF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(4)
        activeMeasurement = "EWF, Electronic Wedge Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_edw_factors"
        activeMeasurementType = "EDW_WF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P5MLCTF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P5MLCTF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(4)
        activeMeasurement = "MLC-TF, MLC Transmisison Factor  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_mlc_tf"
        activeMeasurementType = "MLC_TF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P5MLCDLG_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P5MLCDLG.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(4)
        activeMeasurement = "MLC-DLG, MLC Dynamic Leaf Gap  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_mlc_dlg"
        activeMeasurementType = "MLC_LG"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P5AccF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P5AccF.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(4)
        activeMeasurement = "AccF, Accessory Factors  -  " & activePhotonEnergy
        activeMeasurementTableName = "photon_accessory_tf"
        activeMeasurementType = "TF"
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P5Scans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P5Scans.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(4)
        activeMeasurement = "Photon Scans  -  " & activePhotonEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_P5TMR_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_P5TMR.LinkClicked
        activePhotonEnergy = activeSite.pEnergyNames(4)
        activeMeasurement = "Photon TMR Scans  -  " & activePhotonEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E1OF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E1OF.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(0)
        activeMeasurement = "Electron Applicator Factors  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E1Cutout_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E1Cutout.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(0)
        activeMeasurement = "Electron Cutout Factors  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E1Scans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E1Scans.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(0)
        activeMeasurement = "Electron Scans  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E1AirScans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E1AirScans.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(0)
        activeMeasurement = "Electron Air Scans  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E2OF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E2OF.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(1)
        activeMeasurement = "Electron Applicator Factors  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E2Cutout_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E2Cutout.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(1)
        activeMeasurement = "Electron Cutout Factors  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E2Scans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E2Scans.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(1)
        activeMeasurement = "Electron Scans  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E2AirScans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E2AirScans.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(1)
        activeMeasurement = "Electron Air Scans  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E3OF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E3OF.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(2)
        activeMeasurement = "Electron Applicator Factors  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E3Cutout_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E3Cutout.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(2)
        activeMeasurement = "Electron Cutout Factors  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E3Scans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E3Scans.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(2)
        activeMeasurement = "Electron Scans  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E3AirScans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E3AirScans.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(2)
        activeMeasurement = "Electron Air Scans  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E4OF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E4OF.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(3)
        activeMeasurement = "Electron Applicator Factors  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E4Cutout_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E4Cutout.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(3)
        activeMeasurement = "Electron Cutout Factors  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E4Scans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E4Scans.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(3)
        activeMeasurement = "Electron Scans  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E4AirScans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E4AirScans.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(3)
        activeMeasurement = "Electron Air Scans  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E5OF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E5OF.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(4)
        activeMeasurement = "Electron Applicator Factors  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E5Cutout_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E5Cutout.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(4)
        activeMeasurement = "Electron Cutout Factors  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E5Scans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E5Scans.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(4)
        activeMeasurement = "Electron Scans  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E5AirScans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E5AirScans.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(4)
        activeMeasurement = "Electron Air Scans  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E6OF_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E6OF.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(5)
        activeMeasurement = "Electron Applicator Factors  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E6Cutout_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E6Cutout.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(5)
        activeMeasurement = "Electron Cutout Factors  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E6Scans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E6Scans.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(5)
        activeMeasurement = "Electron Scans  -  " & activeElectronEnergy
        Form_ScpData.Show()
        Me.Close()
    End Sub
    Private Sub LinkLabel_E6AirScans_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_E6AirScans.LinkClicked
        activeElectronEnergy = activeSite.eEnergyNames(5)
        activeMeasurement = "Electron Air Scans  -  " & activeElectronEnergy
        Form_ScpData.Show()
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