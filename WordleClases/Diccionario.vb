Imports System.IO
Imports System.Windows.Forms
Imports System.Windows.Forms.LinkLabel

Public Class Diccionario
    Private ReadOnly Palabras As New List(Of String)
    Private ReadOnly RutaFichero As String = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\..\..\PalabrasLeer"), "Palabras.txt")
    Private palabraGenerada As String
    Private user As Usuario
    Public EstaArchivoCorrupto As Boolean = True

    Public ReadOnly Property _palabraGenerada
        Get
            Return palabraGenerada
        End Get
    End Property
    Public Enum TipoAcierto
        Acertado
        Regular
        Erroneo
    End Enum

    Public Sub New(user As Usuario)
        Me.user = user
        If File.Exists(RutaFichero) Then
            Dim lineas() As String = File.ReadAllLines(RutaFichero)
            If lineas.Length <> 1 Then
                EstaArchivoCorrupto = False
                MsgBox("The file contains only one line.")
            Else
                For Each line As String In lineas
                    Dim parts As String() = line.Split(","c)
                    If parts.Length > 0 Then
                        For Each part As String In parts
                            If Not System.Text.RegularExpressions.Regex.IsMatch(part, "^[a-zA-ZñÑ]+$") OrElse part.Length <> 5 Then
                                EstaArchivoCorrupto = False
                                Exit For
                            End If
                        Next
                    Else
                        MsgBox("A line in the file does not contain any comma-separated parts.")
                        EstaArchivoCorrupto = False
                    End If
                Next

                For Each linea In lineas
                    Dim partes() As String = linea.Split(",")
                    Palabras = partes.ToList
                Next
            End If
        Else
            MsgBox("The file does not exist.")
            EstaArchivoCorrupto = False
        End If
    End Sub



    Public Sub AddWord(palabra As String)
        Me.Palabras.Add(palabra)
    End Sub

    Public Function palbraEsValida(palabraValidar As String) As Boolean
        For Each p In Palabras
            If p.ToUpper = palabraValidar.ToUpper Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub GetRandomWord()

        Dim numeroPalabras = Palabras.Count()
        Dim randomIndex = New Random().Next(0, numeroPalabras)
        palabraGenerada = Palabras(randomIndex)


    End Sub

    Public Function GreenYellowGray(pal As String) As TipoAcierto()
        ''TODO no se repita la misma palbra dos veces en una misma sesion
        ''TODO obtener la palbra valida actual

        'Dim palab As Palabra = GetRandomWord(dificultad)
        Dim palab As String = palabraGenerada.ToUpper
        Dim pAr(pal.Length) As TipoAcierto

        For i = 0 To palab.Length - 1
            If palab.Chars(i) = pal.Chars(i) Then
                pAr(i) = TipoAcierto.Acertado
            Else
                For j = 0 To pal.Length - 1
                    If palab.Chars(j) = pal.Chars(i) Then
                        pAr(i) = TipoAcierto.Regular
                        Exit For
                    Else
                        pAr(i) = TipoAcierto.Erroneo
                    End If

                Next

            End If


        Next
        Return pAr
    End Function

    Public Function HaGanado(palabraformada As String, indexLabelActual As Integer) As Boolean


        If palabraformada.ToUpper = palabraGenerada.ToUpper Then
            Globales.listaUsuarios.AgregarPuntuacion(user.Username, True)
            'user.PartidaFinalizada(True)
            Return True
        ElseIf indexLabelActual = Globales.numeroFilas * 5 Then
            Globales.listaUsuarios.AgregarPuntuacion(user.Username, False)
            Return True
        End If
        Return False
    End Function
End Class
