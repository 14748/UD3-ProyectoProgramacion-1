Public Class Palabra
    Public Property Texto As String
    Public Property Dificultad As Integer
    Public Property NumeroLetras As Integer

    Public Sub New(textoPasado As String, dificultadPasada As Integer, numeroLetras As Integer)
        Me.Texto = textoPasado
        Me.Dificultad = dificultadPasada
        Me.NumeroLetras = numeroLetras
    End Sub

End Class
