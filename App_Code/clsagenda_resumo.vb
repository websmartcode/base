Imports Microsoft.VisualBasic

Public Class clsagenda_resumo
    Dim _qtdeventos As Integer = 0
    Dim _qtdprogdia As Integer = 0
    Dim _qtdfim As Integer = 0
    Dim _qtdatrasos As Integer = 0

    Public Property Qtdeventos As Integer
        Get
            Return _qtdeventos
        End Get
        Set(value As Integer)
            _qtdeventos = value
        End Set
    End Property

    Public Property Qtdprogdia As Integer
        Get
            Return _qtdprogdia
        End Get
        Set(value As Integer)
            _qtdprogdia = value
        End Set
    End Property

    Public Property Qtdfim As Integer
        Get
            Return _qtdfim
        End Get
        Set(value As Integer)
            _qtdfim = value
        End Set
    End Property

    Public Property Qtdatrasos As Integer
        Get
            Return _qtdatrasos
        End Get
        Set(value As Integer)
            _qtdatrasos = value
        End Set
    End Property
End Class
