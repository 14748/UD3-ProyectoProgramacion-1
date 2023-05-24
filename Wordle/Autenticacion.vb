Imports WordleClases

Public Class Autenticacion

    Private Sub MensajeDeErrorLogin(labelActuar As Label, mensajeUsuario As String)
        If Not String.IsNullOrEmpty(mensajeUsuario) Then
            labelActuar.Text = mensajeUsuario
            labelActuar.Visible = True
        End If
    End Sub
    Private Sub LimpiarErrores(labelActuar As Label)
        labelActuar.Visible = False

    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim resultado As Usuarios.TipoError = Globales.listaUsuarios.ValidarUsuario(txtNombreUsuario.Text, txtContraseña.Text)
        If resultado <> Nothing Then
            Select Case resultado
                Case Usuarios.TipoError.UsuarioVacio
                    MensajeDeErrorLogin(lblLoginNombreUsuario, "Por favor introduzca un nombre de usuario")
                Case Usuarios.TipoError.ContrasenaVacia
                    MensajeDeErrorLogin(lblLoginContraseña, "Por favor introduzca una contrasena")
                Case Usuarios.TipoError.AmbosVacios
                    MensajeDeErrorLogin(lblLoginNombreUsuario, "Por favor introduzca un nombre de usuario")
                    MensajeDeErrorLogin(lblLoginContraseña, "Por favor introduzca una contrasena")
                Case Usuarios.TipoError.UsuarioNoExiste
                    MensajeDeErrorLogin(lblLoginNombreUsuario, "El usuario no existe")
                Case Usuarios.TipoError.ContrasenaIncorrecta
                    MensajeDeErrorLogin(lblLoginContraseña, "La contrasena es incorrecta")
            End Select
        Else
            MsgBox("Usuario Logeado")
            Dim palabrita As New Wordle.JuegoPrincipal
            Globales.numeroFilas = 6
            palabrita.Show()
            Me.Dispose()
        End If
    End Sub

    Private Sub txtNombreUsuario_Enter(sender As Object, e As EventArgs) Handles txtNombreUsuario.Enter
        LimpiarErrores(lblLoginNombreUsuario)
    End Sub

    Private Sub txtContraseña_Enter(sender As Object, e As EventArgs) Handles txtContraseña.Enter
        LimpiarErrores(lblLoginContraseña)
    End Sub
    Private Sub txtRegistrarNombre_Enter(sender As Object, e As EventArgs) Handles txtRegistrarNombre.Enter
        LimpiarErrores(lblRegistrarNombre)
    End Sub

    Private Sub txtRegistrarContraseña_Enter(sender As Object, e As EventArgs) Handles txtRegistrarContraseña.Enter
        LimpiarErrores(lblRegistrarContraseña)
    End Sub

    Private Sub txtRegistrarReContraseña_Enter(sender As Object, e As EventArgs) Handles txtRegistrarReContraseña.Enter
        LimpiarErrores(lblRegistrarReContraseña)
    End Sub

    Private Sub Registro_Click(sender As Object, e As EventArgs) Handles Register.Click
        Dim resultado As Usuarios.TipoError = Globales.listaUsuarios.AnadirUsuario(txtRegistrarNombre.Text, txtRegistrarContraseña.Text, txtRegistrarReContraseña.Text)
        If resultado <> Nothing Then
            Select Case resultado
                Case Usuarios.TipoError.UsuarioVacio
                    MensajeDeErrorLogin(lblRegistrarNombre, "Por favor introduzca un nombre de usuario")
                Case Usuarios.TipoError.ContrasenaVacia
                    MensajeDeErrorLogin(lblRegistrarContraseña, "Por favor introduzca una contrasena")
                Case Usuarios.TipoError.RepetirContrasenaVacia
                    MensajeDeErrorLogin(lblRegistrarReContraseña, "Por favor introduzca una contrasena")
                Case Usuarios.TipoError.AmbosVacios
                    MensajeDeErrorLogin(lblRegistrarNombre, "Por favor introduzca un nombre de usuario")
                    MensajeDeErrorLogin(lblRegistrarContraseña, "Por favor introduzca una contrasena")
                    MensajeDeErrorLogin(lblRegistrarReContraseña, "Por favor introduzca una contrasena")
                Case Usuarios.TipoError.UsuarioLongitudIncorrecta
                    MensajeDeErrorLogin(lblRegistrarNombre, "La longitud mayor a 4 caracteres")
                Case Usuarios.TipoError.ContrasenaLongitudIncorrecta
                    MensajeDeErrorLogin(lblRegistrarContraseña, "La longitud mayor a 6 caracteres")
                Case Usuarios.TipoError.AmbasLongitudesIncorrectas
                    MensajeDeErrorLogin(lblRegistrarNombre, "La longitud mayor a 4 caracteres")
                    MensajeDeErrorLogin(lblRegistrarContraseña, "La longitud mayor a 6 caracteres")
                Case Usuarios.TipoError.UsuarioYaExiste
                    MensajeDeErrorLogin(lblRegistrarNombre, "El usuario ya existe")
                Case Usuarios.TipoError.ContrasenaNoCoincide
                    MensajeDeErrorLogin(lblRegistrarReContraseña, "La contrasena no coincide")
            End Select
        Else
            MsgBox("Usuario Registrado")
            Globales.listaUsuarios.GuardarUsuarios()
            pnlRegister.Hide()
        End If
    End Sub

    Private Sub linkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel2.LinkClicked
        pnlRegister.Hide()
    End Sub

    Private Sub linkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked
        pnlRegister.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Globales.listaUsuarios = New Usuarios()
        txtNombreUsuario.Text = "Usuario"
        txtContraseña.Text = "contraseña"
        txtRegistrarNombre.Text = "Usuario"
        txtRegistrarContraseña.Text = "Contraseña"
        txtRegistrarReContraseña.Text = "reintroduce la contraseña"
    End Sub

    Private Sub txtRegistrarNombre_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtRegistrarNombre.GotFocus
        If txtRegistrarNombre.Text = "Usuario" Then
            txtRegistrarNombre.Text = ""

        End If
    End Sub
    Private Sub txtRegistrarNombre_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtRegistrarNombre.LostFocus
        If txtRegistrarNombre.Text = "" Then
            txtRegistrarNombre.Text = "Usuario"
            Console.WriteLine("perder foco")
        End If
    End Sub
    Private Sub txtRegisterPassword_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtRegistrarContraseña.GotFocus
        If txtRegistrarContraseña.Text = "Contraseña" Then
            txtRegistrarContraseña.Text = ""
        End If
    End Sub
    Private Sub txtRegistrarContraseña_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtRegistrarContraseña.LostFocus
        If txtRegistrarContraseña.Text = "" Then
            txtRegistrarContraseña.Text = "Contraseña"
        End If
    End Sub
    Private Sub txtRegistrarReContraseña_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtRegistrarReContraseña.GotFocus
        If txtRegistrarReContraseña.Text = "reintroduce la contraseña" Then
            txtRegistrarReContraseña.Text = ""
        End If
    End Sub
    Private Sub txtRegistrarReContraseña_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtRegistrarReContraseña.LostFocus
        If txtRegistrarReContraseña.Text = "" Then
            txtRegistrarReContraseña.Text = "reintroduce la contraseña"
        End If
    End Sub
    Private Sub txtNombreUsuario_GotFocus(sender As Object, e As EventArgs) Handles txtNombreUsuario.GotFocus
        If txtNombreUsuario.Text = "Usuario" Then
            txtNombreUsuario.Text = ""
        End If
    End Sub
    Private Sub txtNombreUsuario_LostFocus(sender As Object, e As EventArgs) Handles txtNombreUsuario.LostFocus
        If txtNombreUsuario.Text = "" Then
            txtNombreUsuario.Text = "Usuario"
        End If
    End Sub
    Private Sub txtContraseña_GotFocus(sender As Object, e As EventArgs) Handles txtContraseña.GotFocus
        If txtContraseña.Text = "contraseña" Then
            txtContraseña.Text = ""
        End If
    End Sub
    Private Sub txtContraseña_LostFocus(sender As Object, e As EventArgs) Handles txtContraseña.LostFocus
        If txtContraseña.Text = "" Then
            txtContraseña.Text = "contraseña"
        End If
    End Sub
End Class
