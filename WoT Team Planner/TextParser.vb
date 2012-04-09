Module TextParser
    Public Function getInt(ByVal str As String, ByVal def As Integer) As Integer
        Integer.TryParse(str, def)
        Return def
    End Function
    Public Function getLong(ByVal str As String, ByVal def As Long) As Long
        Long.TryParse(str, def)
        Return def
    End Function
End Module
