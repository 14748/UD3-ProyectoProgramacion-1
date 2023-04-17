Imports System.IO
Imports WordleClases
Public Class Form1
    Dim numeroFilas As Integer = 6
    Dim numeroColumnas As Integer = 5
    Dim tamanoLabel As Integer = 50
    Dim tamanoMargen As Integer = 5
    Dim indiceLabelActual As Integer = 0
    Dim indiceMaxCeldasRellenadasPorFila As Integer = numeroColumnas
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim directorioSolucion As String = Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)) ''busca donde esta el .sln
        Dim rutaCompletaDirectorioPadreSln As String = Directory.GetParent(directorioSolucion).FullName ''te busca la ruta absoluta de cada ordenador hasta la carpeta que contiene el .sln
        Dim rutaPalabrasLeer As String = Path.Combine(rutaCompletaDirectorioPadreSln, "PalabrasLeer") ''de la ruta abs ya obtenida se mueve a la carpeta PalabrasLeer
        Dim accesoFicherPalabras As String = Path.Combine(rutaPalabrasLeer, "Palabras.txt") ''de dicha ruta + carpeta accede al fichero Palabras.txt


        Dim wordle As New Diccionario(accesoFicherPalabras) ''esto probablemente tenga que ser variable global...

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


            If e.KeyChar = ChrW(Keys.Enter) Then 'Si enter es pulsado mira si se ha completado la palabra o no
                If indiceLabelActual <> indiceMaxCeldasRellenadasPorFila Then
                    MsgBox("Lenght != col")
                Else
                    'TODO mirar si esta en el diccionario                 
                    indiceMaxCeldasRellenadasPorFila += 5
                End If
                Return
            End If

            If palabrasPermitidas.Contains(e.KeyChar.ToString.ToUpper) Then ''si no se ha pulsado eneter, se busca si la tecla esta en abecedario, si es asi haz ....
                If indiceLabelActual <> indiceMaxCeldasRellenadasPorFila Then
                    currentLabel.Text = e.KeyChar.ToString()
                    indiceLabelActual += 1
                End If
            End If

            'Dim dic As Diccionario
            'If dic.Igual() Then
            '    MsgBox("Igual")
            'Else
            '    MsgBox("")
            'End If

            ''TODO al pressionar return eliminar palabras

            If e.KeyChar = ChrW(Keys.Back) Then

                If indiceLabelActual <= 0 Then
                    MsgBox("No se puede borrar mas")
                Else
                    indiceLabelActual -= 1
                    currentLabel.Text = Nothing

                End If

            End If

        End If
    End Sub
End Class