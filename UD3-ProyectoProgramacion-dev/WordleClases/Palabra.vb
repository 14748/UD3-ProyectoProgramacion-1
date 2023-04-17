Public Class Palabra
    Public Property Texto As String
    Public Property Dificultad As Integer
    Public Property NumeroLetras As Integer

    Public Sub New(textoPasado As String, dificultadPasada As Integer, numeroLetras As Integer)
        Me.Texto = textoPasado
        Me.Dificultad = dificultadPasada
        Me.NumeroLetras = numeroLetras
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim palabra = TryCast(obj, Palabra)
        Return palabra IsNot Nothing AndAlso
               Texto = palabra.Texto
    End Function

    Public Overrides Function GetHashCode() As Integer
        Dim hashCode As Long = -356309981
        hashCode = (hashCode * -1521134295 + EqualityComparer(Of String).Default.GetHashCode(Texto)).GetHashCode()
        Return hashCode
    End Function
End Class
