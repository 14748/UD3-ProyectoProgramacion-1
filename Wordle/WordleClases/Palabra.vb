Public Class Palabra
    Implements IEquatable(Of Palabra)
    Public Property Termino As String
    Public Property Significado As String() = {}
    Public Sub New()

    End Sub

    Public Sub New(termino As String)
        Me.Termino = termino
    End Sub

    Public Sub New(termino As String, significado() As String)
        Me.New(termino)
        Me.Significado = significado
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals(TryCast(obj, Palabra))
    End Function

    Public Overloads Function Equals(other As Palabra) As Boolean Implements IEquatable(Of Palabra).Equals
        Return other IsNot Nothing AndAlso
               Termino.ToLower = other.Termino.ToLower
    End Function

    Public Overrides Function GetHashCode() As Integer
        Dim hashCode As Long = 1495157033
        hashCode = (hashCode * -1521134295 + EqualityComparer(Of String).Default.GetHashCode(Termino)).GetHashCode()
        Return hashCode
    End Function
End Class
