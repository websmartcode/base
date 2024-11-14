Imports Microsoft.VisualBasic

Public Class clscaixamensagens_destinatarios
    Dim tbusuarios_map As New Data.DataTable
    Dim tabusuarios As New clabancopsql
    Public Sub New(Optional ocultos As Boolean = False)
        _oculto = ocultos
        tbusuarios_map = tabusuarios.conectar("select * from tbusuarios where ativo = true order by usuario")
    End Sub
    Private _usuario As String
    Private _email As String
    Private _nrsequsuario As Integer = 0
    Private _oculto As Boolean = False

    Public Property Usuario As String
        Get
            Return _usuario
        End Get
        Set(value As String)
            _usuario = value
            Dim tblinha As Data.DataRow()

            tblinha = tbusuarios_map.Select(" usuario = '" & _usuario & "' or email = '" & _usuario & "'")
            If tblinha.Count = 0 Then
                If _usuario.Contains("@") Then
                    _email = _usuario
                End If
                _nrsequsuario = 0
            Else
                _email = tblinha(0)("email").ToString
                _nrsequsuario = tblinha(0)("nrseq").ToString
                _usuario = tblinha(0)("usuario").ToString
            End If

        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property Nrsequsuario As Integer
        Get
            Return _nrsequsuario
        End Get
        Set(value As Integer)
            _nrsequsuario = value
        End Set
    End Property



    Public Property Oculto As Boolean
        Get
            Return _oculto
        End Get
        Set(value As Boolean)
            _oculto = value
        End Set
    End Property
End Class
