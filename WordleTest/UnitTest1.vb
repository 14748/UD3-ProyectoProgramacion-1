Imports System.IO
Imports System.Net.Mime.MediaTypeNames
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports WordleClases
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ApplicationServices
Imports WordleClases.Diccionario

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestUserRegistration()
        Dim users As New Usuarios()
        Dim testUser As New Usuario("testUsername", "testPassword", 0, 0, 0, 0)

        Assert.AreEqual(users.AnadirUsuario(testUser.Username, testUser.Password, testUser.Password), Nothing)
    End Sub

    Public Sub TestUserLogin()
        Dim users As New Usuarios()
        Dim testUser As New Usuario("testUsername", "testPassword", 0, 0, 0, 0)
        users.AnadirUsuario(testUser.Username, testUser.Password, testUser.Password)

        Assert.AreEqual(users.ValidarUsuario(testUser.Username, testUser.Password), Nothing)
    End Sub

    ''Comprueba si la palabra generada, al pasarla por la funcion retorna que es valida
    <TestMethod()> Public Sub TestPalabraValidar()
        Dim u As New Usuario("test", "test")
        Dim word As New Diccionario(u)
        word.GetRandomWord()
        Dim pal As String = word._palabraGenerada
        Debug.WriteLine(pal)
        Dim real() As TipoAcierto = word.GreenYellowGray(pal)
        Dim expected() As TipoAcierto = {TipoAcierto.Acertado, TipoAcierto.Acertado, TipoAcierto.Acertado, TipoAcierto.Acertado, TipoAcierto.Acertado, TipoAcierto.Acertado}
        Dim realEsValido = True

        For Each item In real
            If item <> TipoAcierto.Acertado Then
                realEsValido = False
            End If
        Next

        Assert.IsTrue(realEsValido)
    End Sub

    'Comprobacion achivos de diccionario
    <TestMethod()> Public Sub TestArchivoDiccionario()
        Dim v As New Usuarios()
        Assert.IsTrue(v.EstaArchivoCorrupto)
    End Sub

    'Comprobacion archivos del usuario
    <TestMethod()> Public Sub TestArchivoUsuario()
        Dim u As New Usuario("test", "test")
        Dim d As New Diccionario(u)
        Assert.IsTrue(d.EstaArchivoCorrupto)
    End Sub

End Class