Imports System.IO

Public Class Diccionario
    Private ReadOnly Palabras As New List(Of Palabra)

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

    Public Function GetRandomWord(dificultad As Integer) As Palabra
        Dim palabrasPosibles = From w In Palabras Where w.Dificultad = dificultad
        Dim numeroPalabras = palabrasPosibles.Count()

        ''TODO si es 0 return nothing o lanzar excepcion

        Dim randomIndex = New Random().Next(0, numeroPalabras)
        Return palabrasPosibles(randomIndex)
    End Function
End Class
