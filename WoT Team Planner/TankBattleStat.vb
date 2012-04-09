Public Class TankBattleStat
    Public battles, wins As Integer
    Public tank As Tank
    Public Sub New(ByVal tank As Tank, ByVal battleWins As String)
        Me.tank = tank
        If battleWins.Contains("/") Then
            battles = TextParser.getInt(battleWins.Substring(battleWins.IndexOf("/") + 1), 0)
            wins = TextParser.getInt(battleWins.Substring(0, battleWins.IndexOf("/")), 0)
        End If
    End Sub
End Class
