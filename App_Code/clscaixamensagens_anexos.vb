Imports Microsoft.VisualBasic

Public Class clscaixamensagens_anexos
    Dim _arquivo As String
    Dim _caminho As String
    Dim _nrseqmensagem As Integer

    Public Property Arquivo As String
        Get
            Return _arquivo
        End Get
        Set(value As String)
            _arquivo = value
        End Set
    End Property

    Public Property Caminho As String
        Get
            Return _caminho
        End Get
        Set(value As String)
            _caminho = value
        End Set
    End Property

    Public Property Nrseqmensagem As Integer
        Get
            Return _nrseqmensagem
        End Get
        Set(value As Integer)
            _nrseqmensagem = value
        End Set
    End Property
End Class
