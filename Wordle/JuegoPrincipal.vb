Imports System.Drawing.Text
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Imports WordleClases
Imports WorldleUtilidades
Public Class JuegoPrincipal
    ReadOnly appender As New AppendMessageOnScreen
    Private WithEvents escuchadorDeTeclado As KeyboardListener
    Const numeroColumnas As Integer = 5
    Const tamañoLabel As Integer = 50
    Const margenEntreLabels As Integer = 10
    Const caracteresPermitidos As String = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"

    Dim celdaActual As Integer
    Dim celdaMaximaDeFila As Integer
    Dim celdaMinimaDeFila As Integer
    Dim palabraDeFilaActual As String

    Dim pnlJuegoPrincipal As Panel
    Dim pnlInteriorClasificacion As Panel
    Dim pnlConfiguracion As New Panel With {
            .Dock = DockStyle.Fill,
            .BorderStyle = BorderStyle.FixedSingle,
            .Visible = True,
            .BackColor = Color.Black
        }

    Dim haCargadoElJuego As Boolean = False

    Dim haAccionadoClasificacion As Boolean = False



    ReadOnly cboSelectorDificultad As New ComboBox With {
            .Width = 100,
            .Height = tamañoLabel,
            .Left = 160, '((tamanoLabel + tamanoLabel) + tamanoMargen) + tamanoMargen,
            .Top = 102, '((tamanoLabel + tamanoLabel) + tamanoMargen) + tamanoMargen,
            .Text = "Normal",
            .Font = New Font("Arial", 10, FontStyle.Bold)
        }
    ReadOnly lblDificultad As New Label With {
            .Width = 500,
            .Height = 50,
            .Left = 130%,
            .Top = 60,
            .Text = "Dificultad",
            .Font = New Font("Arial", 18, FontStyle.Bold)
    }

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Globales.listOfArrays = New List(Of Diccionario.TipoAcierto())()
        Me.WindowState = FormWindowState.Maximized
        Me.Controls.Remove(pnlConfiguracion)
        Me.Controls.Remove(cboSelectorDificultad)

        cboSelectorDificultad.Items.AddRange({"Normal", "Avanzado", "Experto"})
        btnCerrarConfiguracion.Hide()
        btnAplicarConfiguracion.Hide()
        pnlConfiguracion.Controls.Add(lblDificultad)
        pnlClasificacion.Hide()

        cargarJuego()

        haCargadoElJuego = True
    End Sub

    Private Sub cargarJuego()
        Globales.Instanciadicionario.GetRandomWord()
        MsgBox(Instanciadicionario.PalabraGenerada)

        Dim coordenadasEjeYCentroForm = Me.Height / 2
        Dim coordenadasEjeXCentroForm = Me.Width / 2

        grpTeclado.Location = New Point(coordenadasEjeXCentroForm - (grpTeclado.Size.Width / 2), Me.Height - grpTeclado.Size.Height - 30)
        grpMenu.Location = New Point(coordenadasEjeXCentroForm - (grpMenu.Size.Width / 2), 0)

        Dim grpContenedorTest As New Panel With {
            .Size = New Size(numeroColumnas * (tamañoLabel + margenEntreLabels) + margenEntreLabels, Globales.numeroFilas * (tamañoLabel + margenEntreLabels) + margenEntreLabels),
            .BorderStyle = BorderStyle.None
        }
        pnlJuegoPrincipal = grpContenedorTest

        pnlJuegoPrincipal.Location = New Point((Me.Width - pnlJuegoPrincipal.Width) / 2, (Me.Height - pnlJuegoPrincipal.Height) / 2)

        Me.Controls.Add(pnlJuegoPrincipal)

        Dim font As New Font("Arial", 24, FontStyle.Bold)

        For row As Integer = 0 To Globales.numeroFilas - 1
            For col As Integer = 0 To numeroColumnas - 1
                Dim nuevoLabel As New Label With {
            .Width = tamañoLabel,
            .Height = tamañoLabel,
            .BorderStyle = BorderStyle.FixedSingle,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Location = New Point(col * (tamañoLabel + margenEntreLabels) + margenEntreLabels, row * (tamañoLabel + margenEntreLabels) + margenEntreLabels),
            .Font = font
        }
                pnlJuegoPrincipal.Controls.Add(nuevoLabel)
            Next
        Next

        Dim lbl As New Label With {.Visible = False}
        pnlJuegoPrincipal.Controls.Add(lbl)

        celdaMaximaDeFila = numeroColumnas + celdaActual
        celdaMinimaDeFila = celdaActual
        haCargadoElJuego = True
        escuchadorDeTeclado = New KeyboardListener()
    End Sub
    Private Sub EnterPresionado()
        If celdaActual <> celdaMaximaDeFila Then
            appender.CreateAnimatedLabel(Me, "No hay suficientes letras", pnlJuegoPrincipal.Location.X + (pnlJuegoPrincipal.Width / 2), pnlJuegoPrincipal.Location.Y)
            Exit Sub
        End If

        palabraDeFilaActual = palabraDeFilaActual.Substring(0, numeroColumnas)

        If Not Globales.Instanciadicionario.palbraEsValida(palabraDeFilaActual) Then
            appender.CreateAnimatedLabel(Me, "La palabra introducida no existe en nuestro diccionario", pnlJuegoPrincipal.Location.X + (pnlJuegoPrincipal.Width / 2), pnlJuegoPrincipal.Location.Y)
            Exit Sub
        End If

        Dim estadoAciertosPalabraActua() As Diccionario.TipoAcierto = Globales.Instanciadicionario.GreenYellowGray(palabraDeFilaActual)
        Globales.listOfArrays.Add(estadoAciertosPalabraActua)

        For i = 0 To palabraDeFilaActual.Length - 1
            Dim leterLabel As Label = CType(pnlJuegoPrincipal.Controls(i + celdaMinimaDeFila), Label)
            For Each control As Control In grpTeclado.Controls
                If TypeOf control Is Button Then
                    Dim button As Button = CType(control, Button)
                    If palabraDeFilaActual(i) = button.Text Then
                        If estadoAciertosPalabraActua(i) = Diccionario.TipoAcierto.Acertado Then
                            leterLabel.BackColor = ColorTranslator.FromHtml("#538d4e")
                            button.BackColor = ColorTranslator.FromHtml("#538d4e")
                        ElseIf estadoAciertosPalabraActua(i) = Diccionario.TipoAcierto.Regular Then
                            leterLabel.BackColor = ColorTranslator.FromHtml("#b59f3b")
                            button.BackColor = ColorTranslator.FromHtml("#b59f3b")
                        Else
                            leterLabel.BackColor = ColorTranslator.FromHtml("#3a3a3c")
                            button.BackColor = ColorTranslator.FromHtml("#3a3a3c")
                        End If
                    End If
                End If
            Next
        Next

        If Globales.Instanciadicionario.HaGanado(palabraDeFilaActual, celdaActual) Then
            Dim frm2 As New PartidaFinalizada
            frm2.Show()
            escuchadorDeTeclado.Dispose()
            Globales.listaUsuarios.GuardarUsuarios()
            Me.Dispose()
        End If

        celdaMaximaDeFila += numeroColumnas
        celdaMinimaDeFila += numeroColumnas
        palabraDeFilaActual = ""
    End Sub

    Private Sub ReturnPresionado(currentLabel As Label)
        If celdaActual > celdaMinimaDeFila Then
            palabraDeFilaActual = palabraDeFilaActual.Substring(0, palabraDeFilaActual.Length - 1)
            currentLabel = CType(pnlJuegoPrincipal.Controls(celdaActual - 1), Label)
            currentLabel.Text = ""
            celdaActual -= 1
            Debug.WriteLine(palabraDeFilaActual)
        End If
    End Sub

    Private Sub LetraPresionada(currentLabel As Label, letra As String)
        If celdaActual <> celdaMaximaDeFila Then
            celdaActual += 1
            currentLabel.Text = letra
            palabraDeFilaActual += currentLabel.Text
        End If
    End Sub
    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btnQ.Click, btnW.Click, btnR.Click, btnT.Click, btnY.Click, btnU.Click, btnI.Click, btnE.Click, btnO.Click, btnP.Click, btnA.Click, btnS.Click, btnD.Click, btnF.Click, btnG.Click, btnH.Click, btnJ.Click, btnK.Click, btnL.Click, btnÑ.Click, btnZ.Click, btnX.Click, btnC.Click, btnV.Click, btnB.Click, btnN.Click, btnM.Click
        If celdaActual <= Globales.numeroFilas * numeroColumnas Then
            Dim button As Button = CType(sender, Button)
            Dim currentLabel As Label = CType(pnlJuegoPrincipal.Controls(celdaActual), Label)
            LetraPresionada(currentLabel, button.Text)
        End If
    End Sub

    Private Sub btnENVIAR_Click(sender As Object, e As EventArgs) Handles btnENVIAR.Click
        If celdaActual <= Globales.numeroFilas * numeroColumnas Then
            EnterPresionado()
        End If
    End Sub

    Private Sub btnELIMINAR_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If celdaActual <= Globales.numeroFilas * numeroColumnas Then
            Dim currentLabel As Label = CType(pnlJuegoPrincipal.Controls(celdaActual), Label)
            ReturnPresionado(currentLabel)
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim posY = Me.Height / 2
        Dim posX = Me.Width / 2

        grpTeclado.Location = New Point(posX - (grpTeclado.Size.Width / 2), Me.Height - grpTeclado.Size.Height - 30)
        grpMenu.Location = New Point(posX - (grpMenu.Size.Width / 2), 0)
        If haCargadoElJuego Then
            pnlJuegoPrincipal.Location = New Point((Me.Width - pnlJuegoPrincipal.Width) / 2, (Me.Height - pnlJuegoPrincipal.Height) / 2)
        End If
    End Sub
    Private Sub _keyboardListener_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles escuchadorDeTeclado.KeyDown

        Dim caracteresPermitidos As String = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"

        If celdaActual <= Globales.numeroFilas * numeroColumnas Then
            Dim currentLabel As Label = CType(pnlJuegoPrincipal.Controls(celdaActual), Label)
            Debug.WriteLine($"Current Label: {celdaActual}")

            If caracteresPermitidos.Contains(e.KeyCode.ToString().ToUpper()) Then ''si no se ha pulsado eneter, se busca si la tecla esta en abecedario, si es asi haz ....
                LetraPresionada(currentLabel, e.KeyCode.ToString())
            End If

            If e.KeyCode = Keys.Back Then
                ReturnPresionado(currentLabel)
            End If

            If e.KeyCode = Keys.Return Then
                EnterPresionado()
            End If

            e.Handled = True
            Debug.WriteLine($"End Label: {celdaActual}")
            Debug.WriteLine(palabraDeFilaActual)
        End If
    End Sub
    Private Sub btnconfig_Click(sender As Object, e As EventArgs) Handles btnconfig.Click
        Me.Controls.Add(cboSelectorDificultad)
        Me.Controls.Add(pnlConfiguracion)

        pnlConfiguracion.Controls.Add(btnCerrarConfiguracion)
        pnlConfiguracion.Controls.Add(btnAplicarConfiguracion)
        pnlConfiguracion.Show()
        cboSelectorDificultad.Show()
        btnCerrarConfiguracion.Show()
        btnAplicarConfiguracion.Show()

        pnlConfiguracion.BringToFront()
        btnCerrarConfiguracion.BringToFront()
        btnAplicarConfiguracion.BringToFront()
        cboSelectorDificultad.BringToFront()
    End Sub
    Private Sub cerrar_Click(sender As Object, e As EventArgs) Handles btnCerrarConfiguracion.Click
        pnlConfiguracion.Controls.Remove(btnCerrarConfiguracion)
        Me.Controls.Remove(btnCerrarConfiguracion)
        Me.Controls.Remove(pnlConfiguracion)
        Me.Controls.Remove(cboSelectorDificultad)

        btnCerrarConfiguracion.Hide()
        btnAplicarConfiguracion.Hide()
        pnlConfiguracion.Hide()
        cboSelectorDificultad.Hide()

    End Sub

    Private Sub btnApliConf_Click(sender As Object, e As EventArgs) Handles btnAplicarConfiguracion.Click
        MsgBox("Configuración Aplicada")
        If cboSelectorDificultad.SelectedItem <> "Normal" Then
            Dim a As New JuegoPrincipal
            If cboSelectorDificultad.SelectedItem = "Avanzado" Then
                Globales.numeroFilas = 6 - 1
            ElseIf cboSelectorDificultad.SelectedItem = "Experto" Then
                Globales.numeroFilas = 6 - 2
            Else
                Globales.numeroFilas = 6
            End If
            a.Show()
            Me.Dispose()
        End If
    End Sub

    Private Sub btnbarras_Click(sender As Object, e As EventArgs) Handles btnbarras.Click
        If Not haAccionadoClasificacion Then
            If pnlInteriorClasificacion Is Nothing Then
                pnlInteriorClasificacion = New Panel()
                Dim headers As String() = {"Usuario", "Partidas Jugadas", "Partidas Ganadas", "Racha Actual", "Mejor Racha"}
                Dim left As Integer = 0
                Dim maxWidth As Integer = 0
                For Each header As String In headers
                    Dim headerLabel As New Label()
                    headerLabel.Text = header
                    headerLabel.Top = 0
                    headerLabel.Left = left
                    headerLabel.Font = New Font(headerLabel.Font, FontStyle.Bold)
                    pnlInteriorClasificacion.Controls.Add(headerLabel)
                    left += headerLabel.Width + 5
                    maxWidth = Math.Max(maxWidth, headerLabel.Width)
                Next

                Dim top As Integer = 30
                Dim ranking As List(Of Usuario) = Globales.listaUsuarios.GetRanking()
                Dim count As Integer = 0

                For Each usuario As Usuario In ranking
                    If count >= 8 Then
                        Exit For
                    End If

                    Dim labels() As Label = {New Label(), New Label(), New Label(), New Label(), New Label()}
                    Dim properties() As String = {usuario.Username, usuario.PartidasJugadas.ToString(), usuario.PartidasGanadas.ToString(), usuario.RachaActual.ToString(), usuario.MejorRacha.ToString()}
                    left = 0
                    For i As Integer = 0 To labels.Length - 1
                        labels(i).Text = properties(i)
                        labels(i).Top = top
                        labels(i).Left = left
                        labels(i).Width = maxWidth
                        labels(i).BorderStyle = BorderStyle.Fixed3D
                        pnlInteriorClasificacion.Controls.Add(labels(i))
                        left += labels(i).Width + 5
                    Next
                    top += 60
                    count += 1
                Next

                btnbarras.Location = New Point((pnlInteriorClasificacion.Width - btnbarras.Width) / 2, top + 10)
                pnlInteriorClasificacion.Controls.Add(btnbarras)

                pnlInteriorClasificacion.Width = left
                pnlInteriorClasificacion.Height = top + btnbarras.Height + 20
                pnlInteriorClasificacion.Location = New Point((pnlClasificacion.Width - pnlInteriorClasificacion.Width) / 2, (pnlClasificacion.Height - pnlInteriorClasificacion.Height) / 2)

                pnlClasificacion.Controls.Add(pnlInteriorClasificacion)
            Else
                pnlInteriorClasificacion.Show()
            End If

            pnlInteriorClasificacion.Controls.Add(btnbarras)
            btnbarras.Location = New Point((pnlInteriorClasificacion.Width - btnbarras.Width) / 2, pnlInteriorClasificacion.Height - btnbarras.Height - 10)

            pnlClasificacion.Show()
        Else
            grpMenu.Controls.Add(btnbarras)
            btnbarras.Location = New Point(1, 46)

            pnlInteriorClasificacion.Hide()
            pnlClasificacion.Hide()
        End If
        haAccionadoClasificacion = Not haAccionadoClasificacion
    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If haCargadoElJuego Then
            EscuchadorDeTeclado.Dispose()
        End If
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If haCargadoElJuego Then
            EscuchadorDeTeclado = New KeyboardListener()
        End If
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Environment.Exit(0)
    End Sub
End Class