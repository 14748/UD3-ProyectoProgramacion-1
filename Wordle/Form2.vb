Imports System.Drawing.Printing
Imports WordleClases

Public Class Form2


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblestadisticas.Text = Globales.User.RachaActual
        lblmejorracha.Text = Globales.User.MejorRacha
        lblpartidasganadas.Text = Globales.User.PartidasGanadas
        lblpartidasjugadas.Text = Globales.User.PartidasJugadas
        lblpalabraadecuada.Text = Globales.Instanciadicionario._palabraGenerada

        Dim groupBox As New GroupBox()
        groupBox.Location = New Point((Me.Width / 2) - (groupBox.Width / 2), (Me.Height / 2) - (groupBox.Height * 2.5)) ' Change this as per your requirements

        Dim rows As Integer = 6
        Dim cols As Integer = 5
        Dim labelSize As Integer = 50
        Dim labelSpacing As Integer = 1

        groupBox.Size = New Size(5 * (labelSize + labelSpacing) + labelSpacing, 6 * (labelSize + labelSpacing) + labelSpacing)

        For i As Integer = 0 To rows - 1
            Debug.WriteLine(i)
            Debug.WriteLine("-----------------------------------------------")
            For j As Integer = 0 To cols - 1
                If i < listOfArrays.Count AndAlso j < listOfArrays(i).Length Then
                    Dim array As Diccionario.TipoAcierto() = listOfArrays(i)
                    Dim number As Diccionario.TipoAcierto = array(j)
                    Debug.WriteLine(number)
                    ' Create label
                    Dim label As New Label()
                    label.Width = labelSize
                    label.Height = labelSize
                    label.Location = New Point(j * (labelSize + labelSpacing), i * (labelSize + labelSpacing))
                    Select Case number
                        Case Diccionario.TipoAcierto.Regular
                            label.BackColor = Color.Yellow
                        Case Diccionario.TipoAcierto.Acertado
                            label.BackColor = Color.Green
                        Case Else
                            label.BackColor = Color.White
                    End Select
                    groupBox.Controls.Add(label)
                End If
            Next
        Next

        ' Add groupBox to your form
        Me.Controls.Add(groupBox)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnreintentar.Click
        Dim frm1 As New Form1
        frm1.Show()
        Me.Dispose()

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnfinalizar.Click
        Me.Dispose()
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles lblpalabradia.Click
        lblpalabradia.Text = Globales.User.PartidasGanadas
    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Environment.Exit(0)
    End Sub
End Class