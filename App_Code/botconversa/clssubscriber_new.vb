Imports Microsoft.VisualBasic

Public Class clssubscriber_new
    Inherits clssubscriber
    Dim _ddd As String

    Public Property ddd As String
        Get
            Return _ddd
        End Get
        Set(value As String)
            _ddd = value
        End Set
    End Property
End Class
