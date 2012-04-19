Public Class frmMain
    Dim res As ScanResults = Nothing
    Dim tankList As List(Of Tank) = Nothing
    Dim playerList As List(Of PlayerInfo) = Nothing, playersUseList As New List(Of PlayerInfo),
        hidePlayers As New List(Of PlayerInfo)
    Dim displayedPlayers As New List(Of PlayerInfo)
    Dim teamPlayers As New List(Of TeamPlayer)

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not JarHandler.findJava() Then
            MessageBox.Show("Java was not found on your machine" & vbCrLf & _
                            "Java is required to run ClanStats", "Java not Found!")
            Me.Close()
        End If
        JarHandler.extractJar()
        cmbTimeSpan.SelectedIndex = 1
    End Sub

    Private Sub radTournament_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTournament.CheckedChanged
        lblURL.Visible = radTournament.Checked
        txtURL.Visible = radTournament.Checked
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If txtSearch.Text.Trim().Length = 0 Then
            MessageBox.Show("Input something to search for")
        ElseIf radTournament.Checked And txtURL.Text.Trim().Length = 0 Then
            MessageBox.Show("URL missing")
        ElseIf radTournament.Checked _
            And Not txtURL.Text.Trim().ToLower().StartsWith("http://") _
            And Not txtURL.Text.Trim().ToLower().Contains("/uc/tournaments/") Then
            MessageBox.Show("invalid URL")
        Else
            pnlStart.Enabled = False
            ' check if there is a saved search
            JarHandler.dataSaveFile = JarHandler.dataFolder & "saves\" & txtSearch.Text.Trim().ToUpper() & ".dat"
            If IO.File.Exists(JarHandler.dataSaveFile) Then
                Dim f As String() = IO.File.ReadAllLines(JarHandler.dataSaveFile)
                Dim g As Long = 0
                For Each l As String In f
                    If l.Trim().ToLower().StartsWith("generated:") Then
                        g = TextParser.getLong(l.Substring(l.IndexOf(":") + 1).Trim(), 0)
                        Exit For
                    End If
                Next
                Dim ts As TimeSpan = DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)
                Dim secOld As Long = ts.TotalSeconds - (g / 1000)
                If secOld < 60 * 60 * 12 Then
                    ' less than 12 h old
                    Dim h As Int16 = secOld / (60 * 60)
                    secOld -= h * (60 * 60)
                    Dim m As Int16 = secOld / 60
                    secOld -= m * 60
                    Dim tim As String = ""
                    If h > 0 Then
                        tim = (h + Math.Round(m / 60.0, 1)) & " hours old"
                    ElseIf m > 0 Then
                        tim = (m + Math.Round(secOld / 60.0, 1)) & " minutes old"
                    Else
                        tim = secOld & " seconds old"
                    End If
                    Select Case MessageBox.Show("Earlier Scan Found: " & tim & vbCrLf & "re-use?", "Reuse Earlier Scan?", _
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        Case DialogResult.Cancel
                            Exit Sub
                        Case DialogResult.Yes
                            scanDone()
                            Exit Sub
                    End Select
                End If
            End If
            If Not radTournament.Checked Then
                JarHandler.startScan(txtSearch.Text)
            Else
                JarHandler.startScan(txtSearch.Text, txtURL.Text)
            End If
        End If
    End Sub

    Sub scanDone()
        If Not IO.File.Exists(JarHandler.dataSaveFile) Then
            MessageBox.Show("no match found for the entered query")
            pnlStart.Enabled = True
            Return
        Else
            pnlStart.Visible = False
            res = New ScanResults(JarHandler.dataFolder, JarHandler.dataSaveFile)
            pnlResults.Visible = True
            txtClan.Text = res.tag & " - " & res.name
            txtMembers.Text = res.numMembers
            refeshDisplay()

            If (res.tag.Trim().Length > 0) Then
                ' now save for future reference
                Dim newFileName As String = JarHandler.dataFolder & "saves\" & res.tag & ".dat"
                If newFileName <> JarHandler.dataSaveFile Then
                    If IO.File.Exists(newFileName) Then
                        IO.File.Delete(newFileName)
                    End If
                    IO.File.Move(JarHandler.dataSaveFile, newFileName)
                    JarHandler.dataSaveFile = newFileName
                End If
            End If
        End If
    End Sub

    Sub refeshDisplay()
        If Not res Is Nothing Then
            Dim tank As Tank = Nothing
            If Not tankList Is Nothing AndAlso _
                lstTanks.SelectedIndex >= 0 AndAlso lstTanks.SelectedIndex < tankList.Count Then
                tank = tankList(lstTanks.SelectedIndex)
            End If
            lstTanks.Items.Clear()
            lstPlayers.Items.Clear()
            chklstRemTeam.Items.Clear()
            btnAdd.Enabled = False
            txtPlayerTanks.Text = ""
            Dim min As Integer = Integer.MaxValue
            If chkHideInactive.Checked Then
                min = numTime.Value
                Select Case cmbTimeSpan.SelectedIndex
                    Case 1 ' Hours
                        min *= 60
                    Case 2 ' Days
                        min *= 60 * 24
                    Case 3 ' Weeks
                        min *= 60 * 24 * 7
                End Select
            End If
            playerList = res.getUndistributedPlayers(min, res.gen)
            playersUseList.Clear()
            playersUseList.AddRange(playerList)
            For Each rp As PlayerInfo In hidePlayers
                playersUseList.Remove(rp)
            Next
            tankList = res.getUndistributedTanks(playersUseList, min, res.gen)

            If chkEffective.Checked Then
                res.sortTanksByEffectiveTier(tankList)
            Else
                res.sortTanksByTier(tankList)
            End If

            playerList.Sort(Function(p1, p2)
                                Return p1.name.CompareTo(p2.name)
                            End Function)

            txtMembers.Text = res.numMembers & " (" & playersUseList.Count & " listed)"

            Dim nTanks(tankList.Count) As Integer
            Dim i As Integer = 0
            For Each p As PlayerInfo In playersUseList
                For Each t As TankBattleStat In p.playerTanks
                    i = tankList.IndexOf(t.tank)
                    If i <> -1 Then
                        nTanks(i) += 1
                    End If
                Next
            Next
            Dim maxNum As Integer = 0
            For Each m As Integer In nTanks
                If m > maxNum Then
                    maxNum = m
                End If
            Next
            maxNum = maxNum.ToString().Length
            Dim maxT As Integer = 0
            For Each t As Tank In tankList
                If t.getTier > maxT Then
                    maxT = t.getTier
                End If
            Next
            maxT = maxT.ToString().Length
            i = 0
            For Each t As Tank In tankList
                lstTanks.Items.Add(("(" & nTanks(i) & ")").PadRight(maxNum + 2, " ") & " " & _
                                   t.getTier.ToString.PadLeft(maxT, " ") & " " & t.getTankTypeCode().PadLeft(3, " ") & ": " & t.getName)
                i += 1
            Next
            ' now re-select tank, if is still there
            If Not tank Is Nothing Then
                i = tankList.IndexOf(tank)
                If i <> -1 Then
                    lstTanks.SelectedIndex = i
                End If
            End If
            ' now show list for team
            Dim tier As Int16 = 0, effTier As Int16 = 0, maxTier As Int16 = 0, nameLen As Int16 = 0
            Dim nH As Int16 = 0, nM As Int16 = 0, nL As Int16 = 0, nT As Int16 = 0, nA As Int16 = 0
            Dim tnL As Integer = 0
            For Each p As TeamPlayer In teamPlayers
                tier += p.tank.getTier()
                effTier += p.tank.effectiveTier()
                Select Case p.tank.getTankType
                    Case Tanks.Type.HEAVY
                        nH += 1
                    Case Tanks.Type.MEDIUM
                        nM += 1
                    Case Tanks.Type.LIGHT
                        nL += 1
                    Case Tanks.Type.TD
                        nT += 1
                    Case Tanks.Type.SPG
                        nA += 1
                End Select
                If p.tank.getName().Length > tnL Then
                    tnL = p.tank.getName().Length
                End If
                If p.tank.getTier() > maxTier Then
                    maxTier = p.tank.getTier()
                End If
                If p.player.name.Length > nameLen Then
                    nameLen = p.player.name.Length
                End If
            Next
            maxTier = maxTier.ToString().Length
            ' & " (" & effTier & ")"
            txtTeam.Text = "Total Tier Points: " & tier
            If res.max > 0 Then
                txtTeam.Text += " of " & res.max & " (" & (res.max - tier) & " left)"
            End If
            txtTeam.Text += vbCrLf & _
                "Heavy: " & nH & " Medium: " & nM & " Light: " & nL & " TD: " & nT & " SPG: " & nA & vbCrLf & _
                "Team: (" & teamPlayers.Count & ")" & vbCrLf
            For Each p As TeamPlayer In teamPlayers
                Dim line As String = p.tank.getName().PadLeft(tnL, " ") & _
                    " (" & p.tank.getTier().ToString().PadLeft(maxTier, " ") & " " & p.tank.getTankTypeCode() & ")  "
                If p.tank.getTankType() <> Tanks.Type.SPG Then
                    line += " "
                End If
                txtTeam.Text += line & p.player.name & vbCrLf

                Dim st As TankBattleStat = p.player.getTankStat(p.tank)
                chklstRemTeam.Items.Add(line & p.player.name.PadRight(nameLen, " ") & _
                                        " (" & st.battles & " (" & (Math.Round((st.wins / st.battles) * 100)) & "%))")
            Next
            refreshPlayerList()
        End If
    End Sub

    Sub refreshPlayerList()
        chklstShowPlayers.Items.Clear()
        For Each pl As PlayerInfo In playerList
            Dim hAgo As Integer = pl.getMinutesSinceActive(res.gen) / 60
            chklstShowPlayers.Items.Add(hAgo.ToString().PadRight(3) & " " & pl.name)
            chklstShowPlayers.SetItemChecked(chklstShowPlayers.Items.Count - 1, Not hidePlayers.Contains(pl))
        Next
    End Sub

    Private Sub chkEffective_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEffective.CheckedChanged
        refeshDisplay()
    End Sub

    Private Sub chkHideInactive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHideInactive.CheckedChanged
        refeshDisplay()
    End Sub

    Private Sub numTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numTime.ValueChanged
        If chkHideInactive.Checked Then
            refeshDisplay()
        End If
    End Sub

    Private Sub cmbTimeSpan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTimeSpan.SelectedIndexChanged
        If chkHideInactive.Checked Then
            refeshDisplay()
        End If
    End Sub

    Private Sub lstTanks_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstTanks.SelectedIndexChanged
        If Not tankList Is Nothing AndAlso lstTanks.SelectedIndex <> -1 Then
            Dim tank As Tank = tankList(lstTanks.SelectedIndex)
            lstPlayers.Items.Clear()
            displayedPlayers.Clear()
            btnAdd.Enabled = False
            For Each p As PlayerInfo In playersUseList
                For Each t As TankBattleStat In p.playerTanks
                    If t.tank.getName() = tank.getName() Then
                        displayedPlayers.Add(p)
                        Exit For
                    End If
                Next
            Next
            txtPlayerTanks.Text = displayedPlayers.Count & " Players with " & tank.getName() & ": "

            If True Then
                ' sort by total tank battles
                displayedPlayers.Sort(Function(p1, p2)
                                          Dim t1 As Integer = p1.getTankStat(tank).battles
                                          Dim t2 As Integer = p2.getTankStat(tank).battles
                                          Dim t = t2.CompareTo(t1)
                                          If t = 0 Then
                                              Return p1.playerRating.CompareTo(p2.playerRating)
                                          End If
                                          Return t
                                      End Function)
            Else
                ' sort by player rank
                displayedPlayers.Sort(Function(p1, p2)
                                          Dim t = p1.playerRating.CompareTo(p2.playerRating)
                                          If t = 0 Then
                                              Dim t1 As Integer = p1.getTankStat(tank).battles
                                              Dim t2 As Integer = p2.getTankStat(tank).battles
                                              Return t2.CompareTo(t1)
                                          End If
                                          Return t
                                      End Function)
            End If
            Dim maxBattles = 0
            For Each p As PlayerInfo In displayedPlayers
                Dim b As Integer = p.getTankStat(tank).battles
                If b > maxBattles Then
                    maxBattles = b
                End If
            Next
            maxBattles = maxBattles.ToString().Length
            For Each p As PlayerInfo In displayedPlayers
                Dim st As TankBattleStat = p.getTankStat(tank)
                lstPlayers.Items.Add((st.battles.ToString().PadLeft(maxBattles, " ") & _
                                      " (" & (Math.Round((st.wins / st.battles) * 100)) & "%)").PadRight(11, " ") & " " & p.name)
            Next
        End If
    End Sub

    Private Sub lstPlayers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstPlayers.SelectedIndexChanged
        If lstPlayers.SelectedIndex <> -1 Then
            btnAdd.Enabled = True
        Else
            btnAdd.Enabled = False
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim pl As PlayerInfo = displayedPlayers.Item(lstPlayers.SelectedIndex)
        teamPlayers.Add(New TeamPlayer(pl, tankList(lstTanks.SelectedIndex)))
        res.displayedPlayers.Add(pl)
        refeshDisplay()
    End Sub

    Private Sub btnRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRem.Click
        If Not chklstRemTeam.Visible Then
            chklstRemTeam.Visible = True
            btnCancelRem.Visible = True
        Else
            chklstRemTeam.Visible = False
            btnCancelRem.Visible = False
            ' now remove checked players
            Dim checked As CheckedListBox.CheckedIndexCollection = chklstRemTeam.CheckedIndices
            If checked.Count <> 0 Then
                For i As Integer = checked.Count - 1 To 0 Step -1
                    Dim remPl As PlayerInfo = res.displayedPlayers.Item(checked.Item(i))
                    For j As Integer = 0 To teamPlayers.Count
                        If teamPlayers.Item(j).player.name = remPl.name Then
                            teamPlayers.RemoveAt(j)
                            Exit For
                        End If
                    Next
                    res.displayedPlayers.RemoveAt(checked.Item(i))
                Next
                refeshDisplay()
            End If
        End If
    End Sub

    Private Sub btnCancelRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelRem.Click
        chklstRemTeam.Visible = False
        btnCancelRem.Visible = False
        For Each i As Integer In chklstRemTeam.CheckedIndices
            chklstRemTeam.SetItemChecked(i, False)
        Next
        chklstRemTeam.ClearSelected()
    End Sub

    Private Sub btnPickPlayers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPickPlayers.Click
        chklstShowPlayers.Visible = True
        btnPickPlayers.Enabled = False
        lstTanks.Visible = False
        btnSelectPlayersCancel.Visible = True
        btnSelectPlayersOK.Visible = True
        btnSelectPlayersAll.Visible = True
        btnSelectPlayersNone.Visible = True
    End Sub

    Private Sub btnSelectPlayers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPlayersCancel.Click, btnSelectPlayersOK.Click
        chklstShowPlayers.Visible = False
        btnPickPlayers.Enabled = True
        lstTanks.Visible = True
        btnSelectPlayersCancel.Visible = False
        btnSelectPlayersOK.Visible = False
        btnSelectPlayersAll.Visible = False
        btnSelectPlayersNone.Visible = False
        If sender Is btnSelectPlayersOK Then
            hidePlayers.Clear()
            For i As Integer = 0 To chklstShowPlayers.Items.Count - 1
                If Not chklstShowPlayers.GetItemChecked(i) Then
                    hidePlayers.Add(playerList(i))
                    If res.displayedPlayers.Contains(playerList(i)) Then
                        res.displayedPlayers.Remove(playerList(i))
                    End If
                End If
            Next
            refeshDisplay()
        Else
            refreshPlayerList()
        End If
    End Sub

    Private Sub btnSelectPlayersAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPlayersAll.Click
        For i As Integer = 0 To chklstShowPlayers.Items.Count - 1
            chklstShowPlayers.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub btnSelectPlayersNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPlayersNone.Click
        For i As Integer = 0 To chklstShowPlayers.Items.Count - 1
            chklstShowPlayers.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        If e.KeyCode = Keys.Enter Then
            If radTournament.Checked Then
                txtURL.Focus()
                txtURL.SelectAll()
                e.Handled = True
            Else
                btnStart_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtURL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtURL.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnStart_Click(sender, e)
        End If
    End Sub
End Class
