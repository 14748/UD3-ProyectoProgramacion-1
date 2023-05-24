Public Class Usuario
    Implements IEquatable(Of Usuario)

    Private _username As String
    Private _password As String
    Private _partidasJugadas As Integer
    Private _partidasGanadas As Integer
    Private _rachaActual As Integer
    Private _mejorRacha As Integer

    Public Property Username() As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    Public Property PartidasJugadas() As Integer
        Get
            Return _partidasJugadas
        End Get
        Set(value As Integer)
            _partidasJugadas = value
        End Set
    End Property

    Public Property PartidasGanadas() As Integer
        Get
            Return _partidasGanadas
        End Get
        Set(value As Integer)
            _partidasGanadas = value
        End Set
    End Property

    Public Property RachaActual() As Integer
        Get
            Return _rachaActual
        End Get
        Set(value As Integer)
            _rachaActual = value
        End Set
    End Property

    Public Property MejorRacha() As Integer
        Get
            Return _mejorRacha
        End Get
        Set(value As Integer)
            _mejorRacha = value
        End Set
    End Property

    Public Sub New(username As String, password As String, rachaActual As Integer, mejorRacha As Integer, partidasGanadas As Integer, partidasJugadas As Integer)
        Me.Username = username
        Me.Password = password
        Me.PartidasGanadas = partidasGanadas
        Me.PartidasJugadas = partidasJugadas
        Me.RachaActual = rachaActual
        Me.MejorRacha = mejorRacha
    End Sub

    Public Sub New(username As String, password As String)
        Me.Username = username
        Me.Password = password
    End Sub

    Public Overloads Function Equals(other As Usuario) As Boolean Implements IEquatable(Of Usuario).Equals
        Return other IsNot Nothing AndAlso
               _username.ToUpper() = other._username.ToUpper()
    End Function
End Class
