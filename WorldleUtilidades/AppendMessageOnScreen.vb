Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Clase que se utiliza para crear y animar etiquetas de texto en un formulario.
''' Permite agregar etiquetas animadas al formulario con un límite máximo de 4 etiquetas.
''' Las etiquetas se muestran con un color de fondo, fuente y ubicación específicos.
''' La animación hace que las etiquetas se desvanezcan gradualmente hasta desaparecer.
''' </summary>
Public Class AppendMessageOnScreen
    Private animationTimer As Timer
    Private labelsToAnimate As New List(Of Label)

    ''' <summary>
    ''' Constructor de la clase AppendMessageOnScreen.
    ''' Inicializa el temporizador de animación y suscripción al evento Tick.
    ''' </summary>
    Public Sub New()
        animationTimer = New Timer With {.Interval = 10}
        AddHandler animationTimer.Tick, AddressOf AnimateLabel
    End Sub

    ''' <summary>
    ''' Crea una etiqueta de texto animada y la agrega al formulario especificado.
    ''' La etiqueta se muestra con un color de fondo, fuente y ubicación específicos.
    ''' Solo se permite un máximo de 4 etiquetas animadas al mismo tiempo.
    ''' </summary>
    ''' <param name="targetForm">El formulario al que se agregará la etiqueta animada.</param>
    ''' <param name="text">El texto que se mostrará en la etiqueta animada.</param>
    ''' <param name="x">La coordenada X de la ubicación de la etiqueta animada.</param>
    ''' <param name="y">La coordenada Y de la ubicación de la etiqueta animada.</param>
    Public Sub CreateAnimatedLabel(targetForm As Form, ByVal text As String, x As Integer, y As Integer)
        If labelsToAnimate.Count < 4 Then
            Dim newLabel As New Label With {
            .Text = text,
            .BackColor = ColorTranslator.FromHtml("#d7dadc"),
            .ForeColor = Color.Black,
            .Location = New Point(x, y),
            .Font = New Font("Arial", 24, FontStyle.Bold),
            .AutoSize = True
        }

            targetForm.Controls.Add(newLabel)
            newLabel.Location = New Point(x - newLabel.Width / 2, y - newLabel.Height + (60 * labelsToAnimate.Count))
            newLabel.BringToFront()
            labelsToAnimate.Add(newLabel)

            animationTimer.Start()
        End If
    End Sub

    ''' <summary>
    ''' Método de animación de las etiquetas.
    ''' Controla el desvanecimiento gradual de las etiquetas animadas hasta que desaparecen.
    ''' </summary>
    ''' <param name="sender">El objeto que desencadenó el evento.</param>
    ''' <param name="e">Los argumentos del evento.</param>
    Private Sub AnimateLabel(ByVal sender As Object, ByVal e As EventArgs)
        If labelsToAnimate.Count > 0 Then
            ' Obtener la última etiqueta en la lista
            Dim label = labelsToAnimate(labelsToAnimate.Count - 1)

            Dim targetForm = TryCast(label.Parent, Form)

            label.ForeColor = Color.FromArgb(Math.Max(label.ForeColor.A - 5, 0), label.ForeColor.R, label.ForeColor.G, label.ForeColor.B)
            Debug.WriteLine(label.ForeColor.A)
            If label.ForeColor.A = 0 Then
                targetForm.Controls.Remove(label)
                label.Dispose()
                labelsToAnimate.RemoveAt(labelsToAnimate.Count - 1)
            End If

            If labelsToAnimate.Count = 0 Then
                animationTimer.Stop()
            End If
        End If
    End Sub

End Class
