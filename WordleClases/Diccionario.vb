﻿Imports System.IO

Public Class Diccionario
    Private ReadOnly Palabras As New List(Of Palabra)

    Private palabraGenerada As Palabra
    Public Enum TipoAcierto
        Acertado
        Regular
        Erroneo
    End Enum

    Public Sub New(rutaArchivoLeer As String)

        Dim lineas() As String = File.ReadAllLines(rutaArchivoLeer)
        For Each linea In lineas
            Dim partes() As String = linea.Split(",")
            Dim texto As String = partes(0)
            Dim dificultad As Integer = Integer.Parse(partes(1))
            Dim numeroLetras As Integer = texto.Length
            Dim palabra As New Palabra(texto, dificultad, numeroLetras)
            Palabras.Add(palabra)
        Next
    End Sub

    Public Sub AddWord(palabra As Palabra)
        Me.Palabras.Add(palabra)
    End Sub

    Public Function palbraEsValida(palabraValidar As String) As Boolean
        For Each p In Palabras
            If p.Texto.ToUpper = palabraValidar.ToUpper Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub GetRandomWord(numeroChars As Integer)
        Dim palabrasPosibles = From w In Palabras Where w.NumeroLetras = numeroChars
        Dim numeroPalabras = palabrasPosibles.Count()
        Dim randomIndex = New Random().Next(0, numeroPalabras)
        palabraGenerada = palabrasPosibles(randomIndex)
    End Sub

    Public Function GreenYellowGray(pal As String) As TipoAcierto()
        ''TODO no se repita la misma palbra dos veces en una misma sesion
        ''TODO obtener la palbra valida actual

        'Dim palab As Palabra = GetRandomWord(dificultad)
        Dim palab As String = palabraGenerada.Texto.ToUpper
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
End Class
