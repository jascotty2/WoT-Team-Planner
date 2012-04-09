Public Class Tank
    Private name As String
    Private tier As Integer
    Private type As Tanks.Type

    Public Sub New(ByVal name As String, ByVal tier As Integer, ByVal type As Tanks.Type)
        Me.name = name
        Me.tier = tier
        Me.type = type
    End Sub

    Public Function getName() As String
        Return name
    End Function

    Public Function getTankType() As Tanks.Type
        Return type
    End Function

    Public Function getTankTypeChar() As Char
        Select Case type
            Case Tanks.Type.HEAVY
                Return "H"
            Case Tanks.Type.MEDIUM
                Return "M"
            Case Tanks.Type.LIGHT
                Return "L"
            Case Tanks.Type.TD
                Return "T"
            Case Tanks.Type.SPG
                Return "A"
            Case Else
                Return "?"
        End Select
    End Function

    Public Function getTankTypeCode() As String
        Select Case type
            Case Tanks.Type.HEAVY
                Return "HT"
            Case Tanks.Type.MEDIUM
                Return "MT"
            Case Tanks.Type.LIGHT
                Return "LT"
            Case Tanks.Type.TD
                Return "TD"
            Case Tanks.Type.SPG
                Return "SPG"
            Case Else
                Return "?"
        End Select
    End Function

    Public Function getTier() As Integer
        Return tier
    End Function

    Public Function effectiveTier() As Integer
        ' just in general.. nothing specific (yet..)
        If type = Tanks.Type.HEAVY Or type = Tanks.Type.MEDIUM Then
            Return tier
        ElseIf type = Tanks.Type.TD Then
            Return tier + 1
        ElseIf type = Tanks.Type.SPG Or type = Tanks.Type.LIGHT Then
            If (tier + 2) > 10 Then
                Return 10
            ElseIf tier > 4 Then
                Return tier + 2
            Else
                Return tier + 1
            End If
        End If
        Return tier
    End Function
End Class
