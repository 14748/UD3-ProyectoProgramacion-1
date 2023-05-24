Imports System.Drawing.Printing
Imports WordleClases

Public Class PartidaFinalizada

    ''' <summary>
    ''' Se ejecuta cuando se carga el formulario "PartidaFinalizada". Configura las etiquetas y crea una matriz de aciertos visual.
    ''' </summary>
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configurar las etiquetas con las estadísticas del jugador y la palabra generada
        lblestadisticas.Text = Globales.User.RachaActual
        lblmejorracha.Text = Globales.User.MejorRacha
        lblpartidasganadas.Text = Globales.User.PartidasGanadas
        lblpartidasjugadas.Text = Globales.User.PartidasJugadas
        lblpalabraadecuada.Text = Globales.Instanciadicionario.PalabraGenerada

        ' Crear un panel para mostrar la matriz de aciertos visual
        Dim pnlEstadisticaPartidaVisual As New Panel() With {.BorderStyle = BorderStyle.None}
        pnlEstadisticaPartidaVisual.Location = New Point((Me.Width / 2) - (pnlEstadisticaPartidaVisual.Width / 2), (Me.Height / 2) - (pnlEstadisticaPartidaVisual.Height * 2.5))

        ' Configurar las dimensiones y el espaciado de las etiquetas
        Dim rows As Integer = 6
        Dim cols As Integer = 5
        Dim labelSize As Integer = 50
        Dim labelSpacing As Integer = 1

        ' Configurar el tamaño del panel según las dimensiones de las etiquetas
        pnlEstadisticaPartidaVisual.Size = New Size(5 * (labelSize + labelSpacing) + labelSpacing, 6 * (labelSize + labelSpacing) + labelSpacing)

        ' Crear y agregar las etiquetas de la matriz de aciertos visual
        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To cols - 1
                If i < listaDeAciertosWordle.Count AndAlso j < listaDeAciertosWordle(i).Length Then
                    Dim array As Diccionario.TipoAcierto() = listaDeAciertosWordle(i)
                    Dim number As Diccionario.TipoAcierto = array(j)

                    ' Crear etiqueta
                    Dim label As New Label()
                    label.Width = labelSize
                    label.Height = labelSize
                    label.Location = New Point(j * (labelSize + labelSpacing), i * (labelSize + labelSpacing))

                    ' Establecer el color de fondo de la etiqueta según el tipo de acierto
                    Select Case number
                        Case Diccionario.TipoAcierto.Regular
                            label.BackColor = Color.Yellow
                        Case Diccionario.TipoAcierto.Acertado
                            label.BackColor = Color.Green
                        Case Else
                            label.BackColor = Color.White
                    End Select

                    ' Agregar la etiqueta al panel
                    pnlEstadisticaPartidaVisual.Controls.Add(label)
                End If
            Next
        Next

        ' Agregar el panel al formulario
        Me.Controls.Add(pnlEstadisticaPartidaVisual)
    End Sub

    ''' <summary>
    ''' Se ejecuta cuando se hace clic en el botón "Reintentar". Abre una nueva partida y cierra el formulario actual.
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnreintentar.Click
        Dim frm1 As New JuegoPrincipal
        frm1.Show()
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' Se ejecuta cuando se hace clic en el botón "Finalizar". Cierra el formulario actual.
    ''' </summary>
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnfinalizar.Click
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' Se ejecuta cuando se hace clic en la etiqueta "lblpalabradia". Actualiza el texto de la etiqueta con el número de partidas ganadas del jugador.
    ''' </summary>
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles lblpalabradia.Click
        lblpalabradia.Text = Globales.User.PartidasGanadas
    End Sub

    ''' <summary>
    ''' Se ejecuta cuando se cierra el formulario "PartidaFinalizada". Cierra la aplicación.
    ''' </summary>
    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Environment.Exit(0)
    End Sub
End Class
