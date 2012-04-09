Public Class PlayerInfo
    Public name As String
    Public id, joined, created, lastBattle As Long
    Public position As ClanPosition = Nothing
    Public ratingStats As New BattleStats()
    Public playerStats As New BattleStats()
    Public playerRating As Integer
    Public playerTanks As New List(Of TankBattleStat)

    Public Sub setPosition(ByVal pos As String)
        position = getPosition(pos)
    End Sub

    Shared Function getPosition(ByVal str As String) As ClanPosition
        Select Case str.Trim().ToLower()
            Case "commander"
                Return ClanPosition.Commander
            Case "deputy commander"
                Return ClanPosition.Deputy_Commander
            Case "recruiter"
                Return ClanPosition.Recruiter
            Case "treasurer"
                Return ClanPosition.Treasurer
            Case "diplomat"
                Return ClanPosition.Diplomat
            Case "field commander"
                Return ClanPosition.Field_Commander
            Case "soldier"
                Return ClanPosition.Soldier
            Case "recruit"
                Return ClanPosition.Recruit
        End Select
        Return Nothing
    End Function

    Public Function getMinutesSinceActive(Optional ByVal timeSince As Long = 0) As Integer
        If timeSince = 0 Then
            ' maybe correct? timeSince = System.DateTime.Now.ToFileTimeUtc()
            Dim ts As TimeSpan = DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)
            timeSince = ts.TotalSeconds()
        End If
        Return (timeSince - lastBattle) / 60
    End Function

    Public Function getTank(ByVal tank As String) As Tank
        tank = tank.ToLower()
        For Each t As TankBattleStat In playerTanks
            If t.tank.getName().ToLower() = tank Then
                Return t.tank
            End If
        Next
        Return Nothing
    End Function

    Public Function getTank(ByVal tank As Tank) As Tank
        Dim tn As String = tank.getName().ToLower()
        For Each t As TankBattleStat In playerTanks
            If t.tank.getName().ToLower() = tn Then
                Return t.tank
            End If
        Next
        Return Nothing
    End Function

    Public Function getTankStat(ByVal tank As String) As TankBattleStat
        tank = tank.ToLower()
        For Each t As TankBattleStat In playerTanks
            If t.tank.getName().ToLower() = tank Then
                Return t
            End If
        Next
        Return Nothing
    End Function

    Public Function getTankStat(ByVal tank As Tank) As TankBattleStat
        Dim tn As String = tank.getName().ToLower()
        For Each t As TankBattleStat In playerTanks
            If t.tank.getName().ToLower() = tn Then
                Return t
            End If
        Next
        Return Nothing
    End Function
End Class
