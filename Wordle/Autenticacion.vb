Imports WordleClases

Public Class Autenticacion
    ' ...

    ''' <summary>
    ''' Muestra un mensaje de error en el formulario de login.
    ''' </summary>
    ''' <param name="labelActuar">El label donde se mostrará el mensaje de error.</param>
    ''' <param name="mensajeUsuario">El mensaje de error a mostrar.</param>
    Private Sub MensajeDeErrorLogin(labelActuar As Label, mensajeUsuario As String)
        If Not String.IsNullOrEmpty(mensajeUsuario) Then
            labelActuar.Text = mensajeUsuario
            labelActuar.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' Limpia los mensajes de error en el formulario de login.
    ''' </summary>
    ''' <param name="labelActuar">El label donde se muestra el mensaje de error.</param>
    Private Sub LimpiarErrores(labelActuar As Label)
        labelActuar.Visible = False
    End Sub

    ''' <summary>
    ''' Evento que se dispara al hacer clic en el botón de login.
    ''' Realiza la validación de usuario y muestra el juego principal si es exitoso.
    ''' </summary>
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim resultado As Usuarios.TipoError = Globales.listaUsuarios.ValidarUsuario(txtNombreUsuario.Text, txtContraseña.Text)

        If resultado <> Nothing Then
            Select Case resultado
                Case Usuarios.TipoError.UsuarioVacio
                    MensajeDeErrorLogin(lblLoginNombreUsuario, "Por favor introduzca un nombre de usuario")
                Case Usuarios.TipoError.ContrasenaVacia
                    MensajeDeErrorLogin(lblLoginContraseña, "Por favor introduzca una contraseña")
                Case Usuarios.TipoError.AmbosVacios
                    MensajeDeErrorLogin(lblLoginNombreUsuario, "Por favor introduzca un nombre de usuario")
                    MensajeDeErrorLogin(lblLoginContraseña, "Por favor introduzca una contraseña")
                Case Usuarios.TipoError.UsuarioNoExiste
                    MensajeDeErrorLogin(lblLoginNombreUsuario, "El usuario no existe")
                Case Usuarios.TipoError.ContrasenaIncorrecta
                    MensajeDeErrorLogin(lblLoginContraseña, "La contraseña es incorrecta")
            End Select
        Else
            Dim palabrita As New Wordle.JuegoPrincipal
            Globales.numeroFilas = 6
            palabrita.Show()
            Me.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' Evento que se dispara al entrar al campo de texto del nombre de usuario en el formulario de login.
    ''' Limpia los mensajes de error relacionados.
    ''' </summary>
    Private Sub txtNombreUsuario_Enter(sender As Object, e As EventArgs) Handles txtNombreUsuario.Enter
        LimpiarErrores(lblLoginNombreUsuario)
    End Sub

    ''' <summary>
    ''' Evento que se dispara al entrar al campo de texto de la contraseña en el formulario de login.
    ''' Limpia los mensajes de error relacionados.
    ''' </summary>
    Private Sub txtContraseña_Enter(sender As Object, e As EventArgs) Handles txtContraseña.Enter
        LimpiarErrores(lblLoginContraseña)
    End Sub

    ''' <summary>
    ''' Evento que se dispara al entrar al campo de texto del nombre de usuario en el formulario de registro.
    ''' Limpia los mensajes de error relacionados.
    ''' </summary>
    Private Sub txtRegistrarNombre_Enter(sender As Object, e As EventArgs) Handles txtRegistrarNombre.Enter
        LimpiarErrores(lblRegistrarNombre)
    End Sub

    ''' <summary>
    ''' Evento que se dispara al entrar al campo de texto de la contraseña en el formulario de registro.
    ''' Limpia los mensajes de error relacionados.
    ''' </summary>
    Private Sub txtRegistrarContraseña_Enter(sender As Object, e As EventArgs) Handles txtRegistrarContraseña.Enter
        LimpiarErrores(lblRegistrarContraseña)
    End Sub

    ''' <summary>
    ''' Evento que se dispara al entrar al campo de texto de la confirmación de contraseña en el formulario de registro.
    ''' Limpia los mensajes de error relacionados.
    ''' </summary>
    Private Sub txtRegistrarReContraseña_Enter(sender As Object, e As EventArgs) Handles txtRegistrarReContraseña.Enter
        LimpiarErrores(lblRegistrarReContraseña)
    End Sub

    ''' <summary>
    ''' Evento que se dispara al hacer clic en el botón de registro.
    ''' Realiza la validación de los campos de registro y guarda el usuario si es exitoso.
    ''' </summary>
    Private Sub Registro_Click(sender As Object, e As EventArgs) Handles Register.Click
        Dim resultado As Usuarios.TipoError = Globales.listaUsuarios.AnadirUsuario(txtRegistrarNombre.Text, txtRegistrarContraseña.Text, txtRegistrarReContraseña.Text)

        If resultado <> Nothing Then
            Select Case resultado
                Case Usuarios.TipoError.UsuarioVacio
                    MensajeDeErrorLogin(lblRegistrarNombre, "Por favor introduzca un nombre de usuario")
                Case Usuarios.TipoError.ContrasenaVacia
                    MensajeDeErrorLogin(lblRegistrarContraseña, "Por favor introduzca una contraseña")
                Case Usuarios.TipoError.RepetirContrasenaVacia
                    MensajeDeErrorLogin(lblRegistrarReContraseña, "Por favor introduzca una contraseña")
                Case Usuarios.TipoError.AmbosVacios
                    MensajeDeErrorLogin(lblRegistrarNombre, "Por favor introduzca un nombre de usuario")
                    MensajeDeErrorLogin(lblRegistrarContraseña, "Por favor introduzca una contraseña")
                    MensajeDeErrorLogin(lblRegistrarReContraseña, "Por favor introduzca una contraseña")
                Case Usuarios.TipoError.UsuarioLongitudIncorrecta
                    MensajeDeErrorLogin(lblRegistrarNombre, "La longitud debe ser mayor a 4 caracteres")
                Case Usuarios.TipoError.ContrasenaLongitudIncorrecta
                    MensajeDeErrorLogin(lblRegistrarContraseña, "La longitud debe ser mayor a 6 caracteres")
                Case Usuarios.TipoError.AmbasLongitudesIncorrectas
                    MensajeDeErrorLogin(lblRegistrarNombre, "La longitud debe ser mayor a 4 caracteres")
                    MensajeDeErrorLogin(lblRegistrarContraseña, "La longitud debe ser mayor a 6 caracteres")
                Case Usuarios.TipoError.UsuarioYaExiste
                    MensajeDeErrorLogin(lblRegistrarNombre, "El usuario ya existe")
                Case Usuarios.TipoError.ContrasenaNoCoincide
                    MensajeDeErrorLogin(lblRegistrarReContraseña, "La contraseña no coincide")
            End Select
        Else
            Globales.listaUsuarios.GuardarUsuarios()
            pnlRegister.Hide()
        End If
    End Sub

    ''' <summary>
    ''' Evento que se dispara al hacer clic en el enlace de cancelar registro.
    ''' Oculta el formulario de registro.
    ''' </summary>
    Private Sub linkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel2.LinkClicked
        pnlRegister.Hide()
    End Sub

    ''' <summary>
    ''' Evento que se dispara al hacer clic en el enlace de mostrar formulario de registro.
    ''' Muestra el formulario de registro.
    ''' </summary>
    Private Sub linkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked
        pnlRegister.Show()
    End Sub

    ''' <summary>
    ''' Evento que se dispara al cargar el formulario.
    ''' Inicializa la lista de usuarios y establece valores predeterminados en los campos de texto.
    ''' </summary>
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
