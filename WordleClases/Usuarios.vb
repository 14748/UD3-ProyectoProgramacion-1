Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ApplicationServices
Public Enum TipoError
    UsuarioVacio
    ContrasenaVacia
    RepetirContrasenaVacia
    AmbosVacios
    UsuarioLongitudIncorrecta
    ContrasenaLongitudIncorrecta
    AmbasLongitudesIncorrectas
    UsuarioYaExiste
    ContrasenaNoCoincide

    UsuarioNoExiste
    ContrasenaIncorrecta
End Enum
Public Class Usuarios
    Private _users As List(Of Usuario)
    Private ReadOnly RutaFichero As String = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\..\..\PalabrasLeer"), "Usuarios.txt")
    Public Property EstaArchivoCorrupto As Boolean = True


    Public Sub New()
        Me._users = New List(Of Usuario)
        If File.Exists(RutaFichero) Then
            Dim lines() As String = File.ReadAllLines(RutaFichero)

            ' Check if the file has more than one line
            If lines.Length < 1 Then
                EstaArchivoCorrupto = False
                Return
            End If

            For Each line As String In lines
                Dim values() As String = line.Split(":")

                ' Check if the line has exactly 6 parts
                If values.Length <> 6 Then
                    EstaArchivoCorrupto = False
                    Return
                End If

                ' Assuming the third, fourth, fifth, and sixth parts are integers
                If Not IsNumeric(values(2)) Or Not IsNumeric(values(3)) Or Not IsNumeric(values(4)) Or Not IsNumeric(values(5)) Then
                    EstaArchivoCorrupto = False
                    Return
                End If

                Me._users.Add(New Usuario(values(0), values(1), Integer.Parse(values(2)), Integer.Parse(values(3)), Integer.Parse(values(4)), Integer.Parse(values(5))))
            Next
        Else
            EstaArchivoCorrupto = False
        End If
    End Sub


    Public Function AnadirUsuario(username As String, password As String, repeatPassword As String) As TipoError
        Dim us As New Usuario(username, password)
        If username = "" AndAlso password = "" Then
            Return TipoError.AmbosVacios
        ElseIf username = "" Then
            Return TipoError.UsuarioVacio
        ElseIf password = "" Then
            Return TipoError.ContrasenaVacia
        End If

        If username.Length < 4 AndAlso password.Length < 4 Then
            Return TipoError.AmbasLongitudesIncorrectas
        ElseIf username.Length < 4 Then
            Return TipoError.UsuarioLongitudIncorrecta
        ElseIf password.Length < 6 Then
            Return TipoError.ContrasenaLongitudIncorrecta
        End If

        If Not EsUsuarioValido(us) Then
            Return TipoError.UsuarioYaExiste
        End If

        If password <> repeatPassword Then
            Return TipoError.ContrasenaNoCoincide
        End If

        Me._users.Add(New Usuario(username, password))

        Return Nothing
    End Function

    Public Function ValidarUsuario(usernanme As String, password As String) As TipoError
        If String.IsNullOrEmpty(usernanme) AndAlso String.IsNullOrEmpty(password) Then
            Return TipoError.AmbosVacios
        ElseIf String.IsNullOrEmpty(usernanme) Then
            Return TipoError.UsuarioVacio
        ElseIf String.IsNullOrEmpty(password) Then
            Return TipoError.ContrasenaVacia
        End If

        Dim user As Usuario
        user = BuscarUsuario(usernanme)


        If user Is Nothing Then
            Return TipoError.UsuarioNoExiste
        End If

        If user.Password <> password Then
            Return TipoError.ContrasenaIncorrecta
        End If

        Dim userReal As New Usuario(usernanme, password)
        Globales.Instanciadicionario = New Diccionario(userReal)
        Globales.User = userReal
        Return Nothing
    End Function

    Public Sub GuardarUsuarios()
        Using writer As New System.IO.StreamWriter(RutaFichero)
            For Each user As Usuario In Me._users
                writer.WriteLine(user.Username & ":" & user.Password & ":" & user.RachaActual & ":" & user.MejorRacha & ":" & user.PartidasGanadas & ":" & user.PartidasJugadas)
            Next
        End Using
    End Sub

    Public Function EsUsuarioValido(usuario As Usuario)
        For Each user In Me._users
            If user.Equals(usuario) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function BuscarUsuario(usuario As String) As Usuario
        For Each User In Me._users
            If User.Username.ToUpper = usuario.ToUpper Then
                Return User
            End If
        Next
        Return Nothing
    End Function

    Public Function GetRanking() As List(Of Usuario)
        Dim ranking As New List(Of Usuario)
        Dim zeroPartidasGanadasUsers As New List(Of Usuario)
        Dim maxPartidasGanadas As Integer
        Dim maxUser As Usuario

        For i As Integer = 1 To Me._users.Count
            maxPartidasGanadas = 0
            maxUser = Nothing
            For Each innerUser In Me._users

                If Not ranking.Contains(innerUser) And innerUser.PartidasGanadas > maxPartidasGanadas Then
                    maxPartidasGanadas = innerUser.PartidasGanadas
                    maxUser = innerUser
                End If
            Next
            If maxUser IsNot Nothing Then
                ranking.Add(maxUser)
            End If
        Next

        For Each innerUser In Me._users
            If innerUser.PartidasGanadas = 0 Then
                zeroPartidasGanadasUsers.Add(innerUser)
            End If
        Next
        ' Add users with 0 PartidasGanadas at the end of the ranking list
        ranking.AddRange(zeroPartidasGanadasUsers)
        Return ranking
    End Function







    Public Sub AgregarPuntuacion(userName As String, b As Boolean)
        Dim user As Usuario = BuscarUsuario(userName)
        user.PartidaFinalizada(b)
    End Sub
End Class
