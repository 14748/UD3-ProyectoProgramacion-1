Imports System.IO
Imports System.Linq.Expressions
Imports WordleClases
Public Class Form1
    Dim numeroFilas As Integer = 6
    Dim numeroColumnas As Integer = 5
    Dim tamanoLabel As Integer = 50
    Dim tamanoMargen As Integer = 5
    Dim indiceLabelActual As Integer = 0
    Dim indiceMaxCeldasRellenadasPorFila As Integer = numeroColumnas

    Dim palabraFormando As String

    Dim sumLabel As Integer = 0

    Dim wordle As Diccionario
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim directorioSolucion As String = Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)) ''busca donde esta el .sln
        Dim rutaCompletaDirectorioPadreSln As String = Directory.GetParent(directorioSolucion).FullName ''te busca la ruta absoluta de cada ordenador hasta la carpeta que contiene el .sln
        Dim rutaPalabrasLeer As String = Path.Combine(rutaCompletaDirectorioPadreSln, "PalabrasLeer") ''de la ruta abs ya obtenida se mueve a la carpeta PalabrasLeer
        Dim accesoFicherPalabras As String = Path.Combine(rutaPalabrasLeer, "Palabras.txt") ''de dicha ruta + carpeta accede al fichero Palabras.txt


        wordle = New Diccionario(accesoFicherPalabras)

        For i As Integer = 0 To numeroFilas - 1
            For j As Integer = 0 To numeroColumnas - 1
                Dim nuevoLabel As New Label()
                nuevoLabel.Width = tamanoLabel
                nuevoLabel.Height = tamanoLabel
                nuevoLabel.BorderStyle = BorderStyle.FixedSingle
                nuevoLabel.TextAlign = ContentAlignment.MiddleCenter

                nuevoLabel.Left = j * (tamanoLabel + tamanoMargen) + tamanoMargen
                nuevoLabel.Top = i * (tamanoLabel + tamanoMargen) + tamanoMargen

                Me.Controls.Add(nuevoLabel)
            Next
        Next






    End Sub

    Dim palabrasPermitidas As String = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ" ''TODO const arriba del todo x orden y convencion

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If indiceLabelActual < numeroFilas * numeroColumnas Then
            Dim currentLabel As Label = CType(Me.Controls(indiceLabelActual), Label)
            Debug.WriteLine($"Current Label: {indiceLabelActual}")
            If e.KeyChar = ChrW(Keys.Back) AndAlso indiceLabelActual >= indiceMaxCeldasRellenadasPorFila - 5 Then
                If palabraFormando.Length > 0 Then
                    palabraFormando = palabraFormando.Substring(0, palabraFormando.Length - 1)
                End If

                If indiceLabelActual = indiceMaxCeldasRellenadasPorFila Then
                    currentLabel = CType(Me.Controls(indiceLabelActual - 1), Label)
                    currentLabel.Text = ""
                    indiceLabelActual -= 2

                Else

                    If indiceLabelActual <> indiceMaxCeldasRellenadasPorFila - 5 Then
                        indiceLabelActual -= 1

                    End If
                    currentLabel.Text = ""
                End If



                Debug.WriteLine(palabraFormando)

            End If

            If e.KeyChar = ChrW(Keys.Enter) Then 'Si enter es pulsado mira si se ha completado la palabra o no
                If indiceLabelActual <> indiceMaxCeldasRellenadasPorFila Then
                    MsgBox("Lenght != col")
                Else
                    palabraFormando = palabraFormando.Substring(0, 5)

                    If wordle.palbraEsValida(palabraFormando) Then

                        'Realiza la operación de poner los labels al color correspondiente
                        'Green: Correcto, en la misma posición
                        'Yellow: Correcto, pero en otra posición
                        'Gray: La letra no existe en la palabra
                        For i = 0 To wordle.GreenYellowGray(palabraFormando, 1).Length - 1
                            Dim leterLabel As Label = CType(Me.Controls(i + sumLabel), Label)

                            If wordle.GreenYellowGray(palabraFormando, 1)(i) = 2 Then
                                leterLabel.BackColor = Color.Green
                            ElseIf wordle.GreenYellowGray(palabraFormando, 1)(i) = 1 Then
                                leterLabel.BackColor = Color.Yellow
                            ElseIf wordle.GreenYellowGray(palabraFormando, 1)(i) = 0 Then
                                leterLabel.BackColor = Color.Gray
                            End If
                        Next
                        sumLabel += 5

                        indiceMaxCeldasRellenadasPorFila += 5
                        palabraFormando = ""
                    Else
                        MsgBox("La palabra no existe")
                    End If

                End If
                Return
            End If

            If palabrasPermitidas.Contains(e.KeyChar.ToString.ToUpper) Then ''si no se ha pulsado eneter, se busca si la tecla esta en abecedario, si es asi haz ....
                If indiceLabelActual <> indiceMaxCeldasRellenadasPorFila Then
                    indiceLabelActual += 1
                    currentLabel.Text = e.KeyChar.ToString()
                    palabraFormando += currentLabel.Text
                End If
            End If

            ''TODO al pressionar return eliminar palabras
            Debug.WriteLine($"End Label: {indiceLabelActual}")

        End If
    End Sub
End Class