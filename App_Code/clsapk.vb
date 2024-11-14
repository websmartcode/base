Imports Microsoft.VisualBasic

Public Class clsapk
    Dim _arquivo As String = ""
    Dim _data As String = ""
    Dim _concluido As Boolean
    Dim _mensagem As String
    Dim _listaclasse As New List(Of clsapk)

    Public Property Arquivo As String
        Get
            Return _arquivo
        End Get
        Set(value As String)
            _arquivo = value
        End Set
    End Property

    Public Property Data As String
        Get
            Return _data
        End Get
        Set(value As String)
            _data = value
        End Set
    End Property

    Public Property Concluido As Boolean
        Get
            Return _concluido
        End Get
        Set(value As Boolean)
            _concluido = value
        End Set
    End Property

    Public Property Mensagem As String
        Get
            Return _mensagem
        End Get
        Set(value As String)
            _mensagem = value
        End Set
    End Property

    Public Property Listaclasse As List(Of clsapk)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clsapk))
            _listaclasse = value
        End Set
    End Property
End Class
