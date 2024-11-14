Imports Microsoft.VisualBasic

Public Class clsconfig_padroes_tags
    Dim _tag As String = ""

    Public Property Tag As String
        Get
            Return _tag
        End Get
        Set(value As String)
            _tag = value
        End Set
    End Property
End Class
