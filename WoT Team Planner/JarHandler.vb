Module JarHandler

    Public Const JarCommitVersion As String = "6afec1ab550053072ec620c9b931ca6b19c54e72"

    Dim WithEvents tmrCheck As New Timer()
    Public javaFile As String = Nothing
    Public dataFolder As String = ""
    Public statsJarFile As String = ""
    Public dataSaveFile As String = ""
    Dim scanProc As Process = Nothing

    Function findJava() As Boolean
        Dim progFiles As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Dim x64 As Boolean = progFiles.Contains(" (x86)")
        If x64 Then
            progFiles = progFiles.Substring(0, progFiles.IndexOf(" (x86)")) & "\"
        End If
        Dim b As Boolean = _findJava(progFiles)
        If Not b And x64 Then
            b = _findJava(progFiles.Substring(0, progFiles.Length - 1) & " (x86)\")
        End If
        Return b
    End Function

    Function _findJava(ByVal progFiles As String) As Boolean
        progFiles = progFiles & "Java\"
        If IO.Directory.Exists(progFiles) Then
            If IO.Directory.Exists(progFiles & "jre7") Then
                progFiles = progFiles & "jre7\"
            ElseIf IO.Directory.Exists(progFiles & "jre6") Then
                progFiles = progFiles & "jre6\"
            Else
                Return False
            End If
            If IO.File.Exists(progFiles & "bin\javaw.exe") Then
                javaFile = progFiles & "bin\javaw.exe"
                Return True
            End If
        End If
        Return False
    End Function

    Sub extractJar()
        dataFolder = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
        Dim ns As String = frmMain.GetType().Namespace
        If (dataFolder.Contains(ns)) Then
            dataFolder = dataFolder.Substring(0, dataFolder.IndexOf(ns) + ns.Length + 1)
        End If
        statsJarFile = dataFolder + "ClanStats.jar"
        Dim good As Boolean = IO.File.Exists(statsJarFile)
        If good AndAlso IO.File.Exists(statsJarFile) Then
            ' check if is the correct version
            If IO.File.Exists(dataFolder + "VERSION") Then
                Dim v As String = IO.File.ReadAllLines(dataFolder + "VERSION")(0)
                If v <> JarCommitVersion Then
                    good = False
                End If
            Else
                good = False
            End If
        End If
        'if file not already exist, then extract it
        If Not good Then
            Try
                If IO.File.Exists(statsJarFile) Then
                    IO.File.SetAttributes(statsJarFile, IO.FileAttributes.Normal)
                    IO.File.Delete(statsJarFile)
                End If
                Dim fs As New System.IO.FileStream(statsJarFile, IO.FileMode.Create)
                Dim bw As New IO.BinaryWriter(fs)
                Try
                    bw.Write(My.Resources.ClanStats)
                    IO.File.SetAttributes(statsJarFile, IO.FileAttributes.ReadOnly)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    bw.Close()
                    fs.Close()
                End Try
                IO.File.WriteAllText(dataFolder + "VERSION", JarCommitVersion)
            Catch ex As Exception
                MessageBox.Show("Problem extracting file: " & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Public Sub startScan(ByVal clan As String, Optional ByVal url As String = "")
        dataSaveFile = dataFolder & "saves\save.dat"
        If IO.File.Exists(dataSaveFile) Then
            IO.File.Delete(dataSaveFile)
        End If
        Dim args As String = " -jar """ & statsJarFile & """ " & clan & " """ & dataFolder & "saves"" true save.dat"
        If Not url Is Nothing And url.Trim().Length > 0 Then
            args += " """ & url & """"
        End If
        scanProc = System.Diagnostics.Process.Start(javaFile, args)
        tmrCheck.Start()
    End Sub

    Private Sub tmrScanCheck_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCheck.Tick
        If Not scanProc Is Nothing Then
            If scanProc.HasExited Then
                scanProc = Nothing
                tmrCheck.Stop()
                frmMain.scanDone()
            End If
        Else
            tmrCheck.Stop()
            frmMain.scanDone()
        End If
    End Sub

End Module
