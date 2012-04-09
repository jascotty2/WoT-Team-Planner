Public Class TeamPlayer
    Public player As PlayerInfo
    Public tank As Tank

    Public Sub New(ByVal player As PlayerInfo, ByVal tank As Tank)
        Me.player = player
        Me.tank = tank
    End Sub
End Class
