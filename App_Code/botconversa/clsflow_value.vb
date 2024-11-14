Imports Microsoft.VisualBasic

Public Class clsflow_value
    Dim _flow As String = ""

    Public Property flow As String
        Get
            Return _flow
        End Get
        Set(value As String)
            _flow = value
        End Set
    End Property
End Class
