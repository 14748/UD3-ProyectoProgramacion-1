Imports System.Drawing.Text
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Imports WordleClases
Imports WorldleUtilidades
Public Class Form1
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
    Dim grpContenedor As Panel

    Dim haCargadoElJuego As Boolean = False
    Dim leaderboardToggled As Boolean = False
    Dim pnlRanking As New Panel With {.Dock = DockStyle.Fill}


    Dim pnlConfiguracion As New Panel With {
            .Dock = DockStyle.Fill,
            .BorderStyle = BorderStyle.FixedSingle,
            .Visible = True,
            .BackColor = Color.Black
        }
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

        cboSelectorDificultad.Items.AddRange({"Normal", "Avanzado", "Experto"})
        Me.Controls.Remove(pnlConfiguracion)
        Me.Controls.Remove(cboSelectorDificultad)
        cerrar.Hide()
        btnApliConf.Hide()
        pnlConfiguracion.Controls.Add(lblDificultad)
        Panel1.Hide()

        cargarJuego()

        haCargadoElJuego = True
    End Sub

    Private Sub cargarJuego()
        pnlRanking.Hide()
        'Generate random word
        Globales.Instanciadicionario.GetRandomWord()
        MsgBox(Instanciadicionario._palabraGenerada)



        'Set position variables
        Dim coordenadasEjeYCentroForm = Me.Height / 2
        Dim coordenadasEjeXCentroForm = Me.Width / 2

        'Position the group boxes
        grpTeclado.Location = New Point(coordenadasEjeXCentroForm - (grpTeclado.Size.Width / 2), Me.Height - grpTeclado.Size.Height - 30)
        grpMenu.Location = New Point(coordenadasEjeXCentroForm - (grpMenu.Size.Width / 2), 0)

        ' Create and configure the group box
        Dim grpContenedorTest As New Panel With {
            .Size = New Size(numeroColumnas * (tamañoLabel + margenEntreLabels) + margenEntreLabels, Globales.numeroFilas * (tamañoLabel + margenEntreLabels) + margenEntreLabels),
            .BorderStyle = BorderStyle.None
        }
        grpContenedor = grpContenedorTest

        ' Position the group box at the center of the form
        grpContenedor.Location = New Point((Me.Width - grpContenedor.Width) / 2, (Me.Height - grpContenedor.Height) / 2)

        ' Add the group box to the form controls
        Me.Controls.Add(grpContenedor)

        ' Create font for labels
        Dim font As New Font("Arial", 24, FontStyle.Bold)

        ' Add labels to the group box
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
                grpContenedor.Controls.Add(nuevoLabel)
            Next
        Next

        'Add an invisible label to the group box
        Dim lbl As New Label With {.Visible = False}
        grpContenedor.Controls.Add(lbl)


        'Set values for other variables
        celdaMaximaDeFila = numeroColumnas + celdaActual
        celdaMinimaDeFila = celdaActual
        haCargadoElJuego = True
        escuchadorDeTeclado = New KeyboardListener()
    End Sub
    Private Sub EnterPresionado()
        If celdaActual <> celdaMaximaDeFila Then
            Appender.CreateAnimatedLabel(Me, "No hay suficientes letras", grpContenedor.Location.X + (grpContenedor.Width / 2), grpContenedor.Location.Y)
            Exit Sub
        End If

        palabraDeFilaActual = palabraDeFilaActual.Substring(0, NumeroColumnas)

        If Not Globales.Instanciadicionario.palbraEsValida(palabraDeFilaActual) Then
            Appender.CreateAnimatedLabel(Me, "La palabra introducida no existe en nuestro diccionario", grpContenedor.Location.X + (grpContenedor.Width / 2), grpContenedor.Location.Y)
            Exit Sub
        End If
        Dim estadoAciertosPalabraActua() As Diccionario.TipoAcierto = Globales.Instanciadicionario.GreenYellowGray(palabraDeFilaActual)
        Globales.listOfArrays.Add(estadoAciertosPalabraActua)
        For i = 0 To palabraDeFilaActual.Length - 1
            Dim leterLabel As Label = CType(grpContenedor.Controls(i + celdaMinimaDeFila), Label)
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
            Dim frm2 As New Form2
            frm2.Show()
            EscuchadorDeTeclado.Dispose()
            Globales.listaUsuarios.GuardarUsuarios()
            Me.Dispose()
        End If
        celdaMaximaDeFila += NumeroColumnas
        celdaMinimaDeFila += NumeroColumnas
        palabraDeFilaActual = ""
    End Sub

    Private Sub ReturnPresionado(currentLabel As Label)
        If celdaActual > celdaMinimaDeFila Then
            palabraDeFilaActual = palabraDeFilaActual.Substring(0, palabraDeFilaActual.Length - 1)
            currentLabel = CType(grpContenedor.Controls(celdaActual - 1), Label)
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
        If celdaActual <= Globales.numeroFilas * NumeroColumnas Then
            Dim button As Button = CType(sender, Button)
            Dim currentLabel As Label = CType(grpContenedor.Controls(celdaActual), Label)
            LetraPresionada(currentLabel, button.Text)
        End If
    End Sub

    Private Sub btnENVIAR_Click(sender As Object, e As EventArgs) Handles btnENVIAR.Click
        If celdaActual <= Globales.numeroFilas * NumeroColumnas Then
            EnterPresionado()
        End If
    End Sub

    Private Sub btnELIMINAR_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If celdaActual <= Globales.numeroFilas * NumeroColumnas Then
            Dim currentLabel As Label = CType(grpContenedor.Controls(celdaActual), Label)
            ReturnPresionado(currentLabel)
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim posY = Me.Height / 2
        Dim posX = Me.Width / 2

        grpTeclado.Location = New Point(posX - (grpTeclado.Size.Width / 2), Me.Height - grpTeclado.Size.Height - 30)
        grpMenu.Location = New Point(posX - (grpMenu.Size.Width / 2), 0)
        If haCargadoElJuego Then
            grpContenedor.Location = New Point((Me.Width - grpContenedor.Width) / 2, (Me.Height - grpContenedor.Height) / 2)
        End If


    End Sub
    Private Sub _keyboardListener_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles escuchadorDeTeclado.KeyDown
        Dim caracteresPermitidos As String = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"
        If celdaActual <= Globales.numeroFilas * numeroColumnas Then
            Dim currentLabel As Label = CType(grpContenedor.Controls(celdaActual), Label)
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

        pnlConfiguracion.Controls.Add(cerrar)
        pnlConfiguracion.Controls.Add(btnApliConf)
        pnlConfiguracion.Show()
        cboSelectorDificultad.Show()
        cerrar.Show()
        btnApliConf.Show()

        pnlConfiguracion.BringToFront()
        cerrar.BringToFront()
        btnApliConf.BringToFront()
        cboSelectorDificultad.BringToFront()
    End Sub
    Private Sub cerrar_Click(sender As Object, e As EventArgs) Handles cerrar.Click
        pnlConfiguracion.Controls.Remove(cerrar)
        Me.Controls.Remove(cerrar)
        Me.Controls.Remove(pnlConfiguracion)
        Me.Controls.Remove(cboSelectorDificultad)

        cerrar.Hide()
        btnApliConf.Hide()
        pnlConfiguracion.Hide()
        cboSelectorDificultad.Hide()

    End Sub

    Private Sub btnApliConf_Click(sender As Object, e As EventArgs) Handles btnApliConf.Click
        MsgBox("Configuración Aplicada")

        'Prueba1
        If cboSelectorDificultad.SelectedItem <> "Normal" Then
            Dim a As New Form1
            If cboSelectorDificultad.SelectedItem = "Avanzado" Then
                Globales.numeroFilas = 6 - (2 - 1)
            ElseIf cboSelectorDificultad.SelectedItem = "Experto" Then
                Globales.numeroFilas = 6 - (3 - 1)
            Else
                Globales.numeroFilas = 6
            End If
            a.Show()
            Me.Dispose()
        End If

        'If cbo.Text = 2 Then
        '    Globales.Globales.numeroFilas = 5
        'ElseIf cbo.Text = 3 Then
        '    Globales.Globales.numeroFilas = 4
        'Else

        '    Globales.numeroFilas = 6
        'End If

        'CargarJuego()
    End Sub

    Private Sub btnbarras_Click(sender As Object, e As EventArgs) Handles btnbarras.Click
        If Not leaderboardToggled Then
            Panel1.Show()
            Panel1.Controls.Add(btnbarras)
            btnbarras.Location = New Point(Me.Size.Width / 2, Me.Size.Height / 2)
        Else
            Panel1.Hide()
            grpMenu.Controls.Add(btnbarras)
            btnbarras.Location = New Point(1, 46)
        End If

        btnbarras.BringToFront()
        leaderboardToggled = Not leaderboardToggled
        Dim ranking As List(Of Usuario) = Globales.listaUsuarios.GetRanking()

        ' Create inner panel
        Dim innerPanel As New Panel()

        ' Create header labels
        Dim headers As String() = {"Username", "Games Played", "Games Won", "Current Streak", "Best Streak"}
        Dim left As Integer = 0
        Dim maxWidth As Integer = 0
        For Each header As String In headers
            Dim headerLabel As New Label()
            headerLabel.Text = header
            headerLabel.Top = 0
            headerLabel.Left = left
            headerLabel.Font = New Font(headerLabel.Font, FontStyle.Bold) ' Make it bold
            innerPanel.Controls.Add(headerLabel)
            left += headerLabel.Width + 5
            maxWidth = Math.Max(maxWidth, headerLabel.Width)
        Next

        Dim top As Integer = 30 ' Adjust top for data labels
        For Each usuario As Usuario In ranking
            ' Create labels for each property
            Dim labels() As Label = {New Label(), New Label(), New Label(), New Label(), New Label()}
            Dim properties() As String = {usuario.Username, usuario.PartidasJugadas.ToString(), usuario.PartidasGanadas.ToString(), usuario.RachaActual.ToString(), usuario.MejorRacha.ToString()}

            left = 0
            For i As Integer = 0 To labels.Length - 1
                labels(i).Text = properties(i)
                labels(i).Top = top
                labels(i).Left = left
                labels(i).Width = maxWidth
                labels(i).BorderStyle = BorderStyle.Fixed3D
                innerPanel.Controls.Add(labels(i))
                left += labels(i).Width + 5
            Next

            top += 60
        Next

        ' Adjust size and position of the inner panel
        innerPanel.Width = left
        innerPanel.Height = top
        innerPanel.Location = New Point((Panel1.Width - innerPanel.Width) / 2, (Panel1.Height - innerPanel.Height) / 2)

        ' Add inner panel to Panel1
        Panel1.Controls.Add(innerPanel)
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