Imports Microsoft.VisualBasic
Imports clsSmart
Imports clssessoes

Public Class clscontasemails

    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _padrao As Boolean
    Dim _porta As Integer = 587
    Dim _mensagemerro As String
    Dim _nrseq As Integer = 0
    Dim _servidor As String
    Dim _usuario As String
    Dim _senha As String
    Dim _ssl As Boolean
    Dim _dtcad As Date
    Dim _usercad As String
    Dim _email As String

    Public Sub New()
        _usercad = buscarsessoes("usuario")
        _dtcad = data()
    End Sub

    Public Property Mensagemerro As String
        Get
            Return _mensagemerro
        End Get
        Set(value As String)
            _mensagemerro = value
        End Set
    End Property

    Public Property Nrseq As Integer
        Get
            Return _nrseq
        End Get
        Set(value As Integer)
            _nrseq = value
        End Set
    End Property

    Public Property Servidor As String
        Get
            Return _servidor
        End Get
        Set(value As String)
            _servidor = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _usuario
        End Get
        Set(value As String)
            _usuario = value
        End Set
    End Property

    Public Property Senha As String
        Get
            Return _senha
        End Get
        Set(value As String)
            _senha = value
        End Set
    End Property

    Public Property Ssl As Boolean
        Get
            Return _ssl
        End Get
        Set(value As Boolean)
            _ssl = value
        End Set
    End Property

    Public Property Dtcad As Date
        Get
            Return _dtcad
        End Get
        Set(value As Date)
            _dtcad = value
        End Set
    End Property

    Public Property Usercad As String
        Get
            Return _usercad
        End Get
        Set(value As String)
            _usercad = value
        End Set
    End Property

    Public Property Padrao As Boolean
        Get
            Return _padrao
        End Get
        Set(value As Boolean)
            _padrao = value
        End Set
    End Property

    Public Property Porta As Integer
        Get
            Return _porta
        End Get
        Set(value As Integer)
            _porta = value
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
End Class
Partial Public Class clscontasemails

    Public Function salvar() As Boolean

        Try



            If _usuario = "" Then
                _mensagemerro = "Entre com um usuário válido !"

                Return False
            End If
            If _servidor = "" Then
                _mensagemerro = "Entre com um servidor válido !"

                Return False
            End If

            tb1 = tab1.conectar("select * from tbcontasemails where usuario = '" & _usuario & "' and servidor = '" & _servidor & "' and ativo = true")

            If tb1.Rows.Count = 0 Then
                If _senha = "" Then
                    _mensagemerro = "Entre com uma senha válida !"

                    Return False
                End If
                tb1 = tab1.IncluirAlterarDados("insert into tbcontasemails (usuario, senha, servidor, ativo, ssl, dtcad, usercad, padrao) values ('" & _usuario & "','" & _senha & "', '" & _servidor & "', true, " & logico(_ssl) & ", '" & hoje() & "', '" & _usercad & "', " & logico(Padrao) & "')")
            Else

                Dim sql As String = "Update tbcontasemails set  ssl = " & logico(_ssl) & ", padrao = " & logico(_padrao)

                If _senha <> "" Then
                    sql &= ", senha = '" & _senha & "'"
                End If

                sql &= " where usuario = '" & _usuario & "' and servidor = '" & _servidor & "' and ativo = true"

                tb1 = tab1.IncluirAlterarDados(sql)
            End If




            Return True
        Catch exsalvar As Exception
            _mensagemerro = exsalvar.Message
            Return False
        End Try

    End Function
    Public Function carregar() As Boolean

        Try



            If _usuario = "" Then
                _mensagemerro = "Entre com um usuário válido !"

                Return False
            End If


            tb1 = tab1.conectar("select * from tbcontasemails where usuario = '" & _usuario & "'  and ativo = true")

            If tb1.Rows.Count = 0 Then
                _mensagemerro = "Nenhuma configuração de emails para esse usuário !"
                Return False
            End If

            _senha = tb1.Rows(0)("senha").ToString
            _servidor = tb1.Rows(0)("servidor").ToString
            _nrseq = tb1.Rows(0)("nrseq").ToString
            _porta = tb1.Rows(0)("porta").ToString
            _padrao = tb1.Rows(0)("padrao").ToString
            _ssl = tb1.Rows(0)("ssl").ToString
            _usercad = tb1.Rows(0)("usercad").ToString
            Return True
        Catch excarr As Exception

            _mensagemerro = excarr.Message
            Return False
        End Try

    End Function
End Class