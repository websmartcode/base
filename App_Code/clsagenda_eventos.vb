Imports Microsoft.VisualBasic

Public Class clsagenda_eventos
    Dim _evento As String = ""

    Public Property Evento As String
        Get
            Return _evento
        End Get
        Set(value As String)
            _evento = value
        End Set
    End Property
End Class
