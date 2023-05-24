Imports System.IO

Public Class Diccionario
    Private _palabras As New List(Of String)
    Private _rutaFichero As String = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\..\..\PalabrasLeer"), "Palabras.txt")
    Private _usuario As Usuario
    Private _estaArchivoCorrupto As Boolean = True
    Public Property estaArchivoCorrupto() As Boolean
        Get
            Return _estaArchivoCorrupto
        End Get
        Set(ByVal value As Boolean)
            _estaArchivoCorrupto = value
        End Set
    End Property

    Private _palabraGenerada As String
    Public ReadOnly Property PalabraGenerada
        Get
            Return _palabraGenerada
        End Get
    End Property

    Public Enum TipoAcierto
        Acertado
        Regular
        Erroneo
    End Enum

    Public Sub New(user As Usuario)
        Me._usuario = user
        If File.Exists(_rutaFichero) Then
            Dim lineas() As String = File.ReadAllLines(_rutaFichero)
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
                    _palabras = partes.ToList
                Next
            End If
        Else
            MsgBox("The file does not exist.")
            EstaArchivoCorrupto = False
        End If
    End Sub

    Public Sub AddWord(palabra As String)
        Me._palabras.Add(palabra)
    End Sub

    Public Function palbraEsValida(palabraValidar As String) As Boolean
        For Each p In _palabras
            If p.ToUpper = palabraValidar.ToUpper Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub GetRandomWord()

        Dim numeroPalabras = _palabras.Count()
        Dim randomIndex = New Random().Next(0, numeroPalabras)
        _palabraGenerada = _palabras(randomIndex)


    End Sub

    Public Function GreenYellowGray(pal As String) As TipoAcierto()
        Dim palab As String = _palabraGenerada.ToUpper
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
        If palabraformada.ToUpper = _palabraGenerada.ToUpper Then
            Globales.listaUsuarios.AgregarPuntuacion(_usuario.Username, True)
            Return True
        ElseIf indexLabelActual = Globales.numeroFilas * 5 Then
            Globales.listaUsuarios.AgregarPuntuacion(_usuario.Username, False)
            Return True
        End If
        Return False
    End Function
End Class
