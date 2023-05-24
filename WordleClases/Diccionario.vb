Imports System.IO
''' <summary>
''' Clase que representa el diccionario de palabras para el juego.
''' Contiene métodos para cargar el diccionario desde un archivo, generar palabras aleatorias y verificar aciertos.
''' </summary>
Public Class Diccionario
    Private _palabras As New List(Of String)
    Private _rutaFichero As String = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\..\..\PalabrasLeer"), "Palabras.txt")
    Private _usuario As Usuario
    Private _estaArchivoCorrupto As Boolean = True

    ''' <summary>
    ''' Indica si el archivo del diccionario está corrupto.
    ''' </summary>
    ''' <value>True si el archivo está corrupto, False en caso contrario.</value>
    Public Property EstaArchivoCorrupto() As Boolean
        Get
            Return _estaArchivoCorrupto
        End Get
        Set(ByVal value As Boolean)
            _estaArchivoCorrupto = value
        End Set
    End Property

    Private _palabraGenerada As String

    ''' <summary>
    ''' Obtiene la palabra generada aleatoriamente del diccionario.
    ''' </summary>
    ''' <value>La palabra generada.</value>
    Public ReadOnly Property PalabraGenerada As String
        Get
            Return _palabraGenerada
        End Get
    End Property

    ''' <summary>
    ''' Enumeración para los tipos de aciertos posibles.
    ''' </summary>
    Public Enum TipoAcierto
        Acertado
        Regular
        Erroneo
    End Enum

    ''' <summary>
    ''' Constructor de la clase Diccionario.
    ''' Inicializa el diccionario y verifica la validez del archivo del diccionario.
    ''' </summary>
    ''' <param name="user">El usuario asociado al diccionario.</param>
    Public Sub New(user As Usuario)
        Me._usuario = user

        If File.Exists(_rutaFichero) Then
            Dim lineas() As String = File.ReadAllLines(_rutaFichero)

            If lineas.Length <> 1 Then
                EstaArchivoCorrupto = False
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
                        EstaArchivoCorrupto = False
                    End If
                Next

                For Each linea In lineas
                    Dim partes() As String = linea.Split(",")
                    _palabras = partes.ToList
                Next
            End If
        Else
            EstaArchivoCorrupto = False
        End If

        If Not EstaArchivoCorrupto Then
            Throw New InvalidOperationException("Archivo 'Palabras.txt' corrupto o inexistente")
        End If
    End Sub

    ''' <summary>
    ''' Agrega una palabra al diccionario.
    ''' </summary>
    ''' <param name="palabra">La palabra a agregar.</param>
    Public Sub AddWord(palabra As String)
        Me._palabras.Add(palabra)
    End Sub

    ''' <summary>
    ''' Verifica si una palabra está en el diccionario.
    ''' </summary>
    ''' <param name="palabraValidar">La palabra a verificar.</param>
    ''' <returns>True si la palabra está en el diccionario, False en caso contrario.</returns>
    Public Function PalabraEsValida(palabraValidar As String) As Boolean
        For Each p In _palabras
            If p.ToUpper = palabraValidar.ToUpper Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Genera una palabra aleatoria del diccionario.
    ''' </summary>
    Public Sub GetRandomWord()
        Dim numeroPalabras = _palabras.Count()
        Dim randomIndex = New Random().Next(0, numeroPalabras)
        _palabraGenerada = _palabras(randomIndex)
    End Sub

    ''' <summary>
    ''' Verifica los aciertos en una palabra ingresada y genera un arreglo de TipoAcierto.
    ''' </summary>
    ''' <param name="pal">La palabra ingresada.</param>
    ''' <returns>El arreglo de TipoAcierto que indica los aciertos en cada posición.</returns>
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

    ''' <summary>
    ''' Verifica si el usuario ha ganado el juego.
    ''' </summary>
    ''' <param name="palabraFormada">La palabra ingresada por el usuario.</param>
    ''' <param name="indexLabelActual">El índice del label actual en el juego.</param>
    ''' <returns>True si el usuario ha ganado, False en caso contrario.</returns>
    Public Function HaGanado(palabraFormada As String, indexLabelActual As Integer) As Boolean
        If palabraFormada.ToUpper = _palabraGenerada.ToUpper Then
            Globales.listaUsuarios.AgregarPuntuacion(_usuario.Username, True)
            Return True
        ElseIf indexLabelActual = Globales.numeroFilas * 5 Then
            Globales.listaUsuarios.AgregarPuntuacion(_usuario.Username, False)
            Return True
        End If
        Return False
    End Function
End Class