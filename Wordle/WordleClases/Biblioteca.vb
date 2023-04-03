Public Class Biblioteca
    Private ArrayPalabras As Palabra()

    Private Property PalabraRnd As Palabra

    'Constructor
    Public Sub New()

    End Sub
    Public Sub New(pal As Palabra)
        ArrayPalabras(ArrayPalabras.Length - 1) = pal
    End Sub
    Public Sub New(term As String, sig As String)
        ArrayPalabras(ArrayPalabras.Length - 1).Termino = term
        ArrayPalabras(ArrayPalabras.Length - 1).Significado(ArrayPalabras(ArrayPalabras.Length - 1).Significado.Length - 1) = sig
    End Sub


    'Metodo Random
    Public Function RtrPalRnd() As String()
        Dim rnd As New Random
        Dim numRnd As Integer

        numRnd = Rnd.Next(ArrayPalabras.Length - 1)
        PalabraRnd = ArrayPalabras(numRnd)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim biblioteca = TryCast(obj, Biblioteca)
        Return biblioteca IsNot Nothing AndAlso
               EqualityComparer(Of Palabra).Default.Equals(PalabraRnd, biblioteca.PalabraRnd)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return HashCode.Combine(PalabraRnd)
    End Function
End Class
