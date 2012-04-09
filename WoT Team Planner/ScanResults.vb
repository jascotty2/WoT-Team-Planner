Public Class ScanResults
    Public tag As String = "", name, emblemURL As String
    Public gen, cr As Long
    Public numMembers, ownerNum, clanNum, income As Integer
    Public players As New List(Of PlayerInfo)
    Public displayedPlayers As New List(Of PlayerInfo)
    Public max, maxHT, maxMT, maxLT, maxTD, maxSPG As Integer

    Public Sub New(ByVal dir As String, ByVal file As String)
        max = -1
        maxLT = 7
        maxMT = 10
        maxHT = 10
        maxTD = 9
        maxSPG = 8

        load(file)

    End Sub

    Public Sub load(ByVal file As String)
        Dim lines As String() = IO.File.ReadAllLines(file)

        Dim lastkey As String = ""
        For i As Integer = 0 To lines.Length - 1
            Dim line As String = lines(i)
            If Not line.Trim().StartsWith("#") And line.Contains(":") Then
                Dim key As String = line.Trim().ToLower()
                key = key.Substring(0, key.IndexOf(":"))
                If line.Trim().EndsWith(":") Then
                    lastkey = key
                    If key = "players" Then
                        i += 1
                        loadPlayers(i, lines)
                    End If
                Else
                    Dim val As String = line.Substring(line.IndexOf(":") + 1).Trim()
                    If line.StartsWith("	") Then
                        Select Case lastkey.ToLower()
                            Case "maxtier"
                                Select Case key
                                    Case "total"
                                        max = TextParser.getInt(val, max)
                                    Case "lt"
                                        maxLT = TextParser.getInt(val, maxLT)
                                    Case "mt"
                                        maxMT = TextParser.getInt(val, maxMT)
                                    Case "ht"
                                        maxHT = TextParser.getInt(val, maxHT)
                                    Case "td"
                                        maxTD = TextParser.getInt(val, maxTD)
                                    Case "spg"
                                        maxSPG = TextParser.getInt(val, maxSPG)
                                End Select
                        End Select
                    Else
                        Select Case key
                            Case "tag"
                                tag = val
                            Case "name"
                                name = val
                            Case "emblem"
                                emblemURL = val
                            Case "generated"
                                gen = TextParser.getLong(val, 0) / 1000
                            Case "created"
                                cr = TextParser.getLong(val, 0) / 1000
                            Case "owner"
                                ownerNum = TextParser.getInt(val, 0)
                            Case "clannum"
                                clanNum = TextParser.getInt(val, 0)
                            Case "members"
                                numMembers = TextParser.getInt(val, 0)
                            Case "total income"
                                income = TextParser.getInt(val, 0)
                        End Select
                    End If
                End If
            End If
        Next
    End Sub

    Public Sub loadPlayers(ByRef startIndex As Integer, ByVal file As String())
        Dim i As Integer = startIndex ' i prefer 'i' for index ;)
        While i < file.Length AndAlso file(i).StartsWith("	")
            Dim player As New PlayerInfo()
            player.name = file(i).Trim
            player.name = player.name.Substring(0, player.name.IndexOf(":"))
            i += 1
            Dim lastKey As String = ""
            While i < file.Length AndAlso file(i).StartsWith("		")
                Dim line As String = file(i).Substring(2)
                If line.Trim().StartsWith("#") Then
                    i += 1
                    Continue While
                End If
                Dim k As String = line.Trim().ToLower()
                Dim val As String = ""

                k = k.Substring(0, k.IndexOf(":"))
                If Not line.Trim().EndsWith(":") Then
                    val = line.Substring(line.IndexOf(":") + 1).Trim()
                End If

                If Not line.StartsWith("	") Then
                    lastKey = k
                End If
                If val.Length = 0 Then
                    i += 1
                    Continue While
                End If

                Select Case lastKey
                    Case "id"
                        player.id = TextParser.getInt(val, 0)
                    Case "position"
                        player.setPosition(val)
                    Case "joined"
                        player.joined = TextParser.getLong(val, 0) / 1000
                    Case "last battle"
                        player.lastBattle = TextParser.getLong(val, 0) / 1000
                    Case "battle results"
                        Dim v As Integer = TextParser.getInt(val, 0)
                        Select Case k
                            Case "battles"
                                player.playerStats.battles = v
                            Case "victories"
                                player.playerStats.victories = v
                            Case "defeats"
                                player.playerStats.losses = v
                            Case "survived"
                                player.playerStats.survived = v
                            Case "destroyed"
                                player.playerStats.destroyed = v
                            Case "detected"
                                player.playerStats.spotted = v
                            Case "hit ratio"
                                player.playerStats.hitRatio = v
                            Case "damage"
                                player.playerStats.damage = v
                            Case "captured"
                                player.playerStats.captured = v
                            Case "defense"
                                player.playerStats.defense = v
                            Case "total exp"
                                player.playerStats.totalExp = v
                            Case "avg exp"
                                player.playerStats.avgExp = v
                            Case "max exp"
                                player.playerStats.maxExp = v
                        End Select
                    Case "rating"
                        Dim v As Integer = TextParser.getInt(val, 0)

                        Select Case k
                            Case "gr" ' global rating
                                player.playerRating = v
                            Case "w/b" ' wins / battles
                                player.ratingStats.hitRatio = v
                            Case "e/b" ' experience / battles
                                player.ratingStats.avgExp = v
                            Case "win" ' victories
                                player.ratingStats.victories = v
                            Case "gpl" ' battles participated
                                player.ratingStats.battles = v
                            Case "cpt" ' capture points
                                player.ratingStats.captured = v
                            Case "dmg" ' damage points
                                player.ratingStats.damage = v
                            Case "dpt" ' defense points
                                player.ratingStats.defense = v
                            Case "frg" ' targets destroyed
                                player.ratingStats.destroyed = v
                            Case "spt" ' targets detected
                                player.ratingStats.spotted = v
                            Case "exp" ' total experience
                                player.ratingStats.totalExp = v
                        End Select
                    Case "vehicles"
                        Dim t As Tank = Tanks.getTank(k)
                        If Not t Is Nothing Then
                            player.playerTanks.Add(New TankBattleStat(t, val))
                        End If
                End Select
                i += 1
            End While
            players.Add(player)
        End While
        startIndex = i
    End Sub

    Public Function getUndistributedPlayers(Optional ByVal maxMinutes As Integer = Integer.MaxValue, Optional ByVal time As Long = 0) As List(Of PlayerInfo)
        Dim ret As New List(Of PlayerInfo)
        For Each p As PlayerInfo In players
            If Not displayedPlayers.Contains(p) AndAlso p.getMinutesSinceActive(time) <= maxMinutes Then
                ret.Add(p)
            End If
        Next
        Return ret
    End Function

    Public Function getUndistributedTanks(Optional ByVal maxMinutes As Integer = Integer.MaxValue, Optional ByVal time As Long = 0) As List(Of Tank)
        Return getTanks(getUndistributedPlayers(maxMinutes, time))
    End Function

    Public Function getUndistributedTanks(ByVal players As List(Of PlayerInfo), Optional ByVal maxMinutes As Integer = Integer.MaxValue, Optional ByVal time As Long = 0) As List(Of Tank)
        Dim ret As New List(Of Tank)
        For Each p As PlayerInfo In players
            If p.getMinutesSinceActive(time) <= maxMinutes Then
                For Each t As TankBattleStat In p.playerTanks
                    If Not ret.Contains(t.tank) Then
                        ret.Add(t.tank)
                    End If
                Next
            End If
        Next
        Return ret
    End Function

    Public Function getTanks(ByVal players As List(Of PlayerInfo)) As List(Of Tank)
        Dim ret As New List(Of Tank)
        For Each p As PlayerInfo In players
            For Each t As TankBattleStat In p.playerTanks
                If Not ret.Contains(t.tank) Then
                    ret.Add(t.tank)
                End If
            Next
        Next
        Return ret
    End Function

    Public Sub sortTanksByTier(ByRef tankList As List(Of Tank))
        tankList.Sort(Function(p1, p2)
                          Dim t = p2.getTier().CompareTo(p1.getTier())
                          If t = 0 Then
                              Return Tanks.getTypeNum(p1.getTankType()).CompareTo(Tanks.getTypeNum(p2.getTankType))
                          End If
                          Return t
                      End Function)
    End Sub

    Public Sub sortTanksByEffectiveTier(ByRef tankList As List(Of Tank))
        tankList.Sort(Function(p1, p2)
                          Dim t = p2.effectiveTier().CompareTo(p1.effectiveTier())
                          If t = 0 Then
                              Return Tanks.getTypeNum(p1.getTankType()).CompareTo(Tanks.getTypeNum(p2.getTankType))
                          End If
                          Return t
                      End Function)
    End Sub

    Public Sub sortTanksByLowTier(ByRef tankList As List(Of Tank))
        tankList.Sort(Function(p1, p2)
                          Dim t = p1.getTier().CompareTo(p2.getTier())
                          If t = 0 Then
                              Return Tanks.getTypeNum(p1.getTankType()).CompareTo(Tanks.getTypeNum(p2.getTankType))
                          End If
                          Return t
                      End Function)
    End Sub

    Public Sub sortTanksByEffectiveLowTier(ByRef tankList As List(Of Tank))
        tankList.Sort(Function(p1, p2)
                          Dim t = p1.effectiveTier().CompareTo(p2.effectiveTier())
                          If t = 0 Then
                              Return Tanks.getTypeNum(p1.getTankType()).CompareTo(Tanks.getTypeNum(p2.getTankType))
                          End If
                          Return t
                      End Function)
    End Sub

End Class
