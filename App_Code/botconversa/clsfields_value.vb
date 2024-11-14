Imports Microsoft.VisualBasic

Public Class clsfields_value
    Dim _value As String = ""

    Public Property value As String
        Get
            Return _value
        End Get
        Set(value As String)
            _value = value
        End Set
    End Property
End Class
