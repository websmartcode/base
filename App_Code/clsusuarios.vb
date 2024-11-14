Imports System.IO
Imports clsSmart
Public Class clsusuarios

    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim tbx As New Data.DataTable
    Dim tabx As New clabancopsql
    Dim _mensagemerro As String
    Dim _mensagemtitulo As String = "Ops !"
    Dim _mensagemicone As String = "error"
    Dim _listaclasse As New List(Of clsusuarios)
    Dim _listaempresas As New List(Of clsusuarios_empresas)
    Dim _emailantigo As String = ""
    Dim _nrseq As Integer
    Dim _usuario As String
    Dim _senha As String
    Dim _ativo As Boolean
    Dim _dtcad As Date
    Dim _usercad As String
    Dim _dtexclui As Date
    Dim _userexclui As String
    Dim _permissao As String
    Dim _email As String
    Dim _nrseqtransp As Integer
    Dim _master As Boolean
    Dim _imagemperfil As String
    Dim _smartcodesolucoes As Integer
    Dim _usuariosistema As Integer
    Dim _forcarlogin As Integer
    Dim _qtdtentativas As Integer
    Dim _suspenso As Integer
    Dim _dtsuspenso As Date
    Dim _usersuspenso As String
    Dim _alterado As Boolean
    Dim _dtalterado As Date
    Dim _useralterado As String
    Dim _nrseqctrl As String
    Dim _hralterado As String
    Dim _dtvalidadesenha As Date
    Dim _ip As String
    Dim _suspensoatualizacao As Integer
    Dim _nrseqconfigusuario As Integer
    Dim _nrseqempresa As Integer
    Dim _descricaopermissao As String = ""
    Dim _Nrseqpermissao As Integer = 0

    Dim _filtro_empresa As String = ""
    Dim _filtro_descricaopermissao As String = ""
    Dim _filtro_usuario As String = ""
    Dim _filtro_usuario_email As String = ""
    Dim _filtro_permissao As String = ""
    Dim _filtro_nrseq As Integer = 0
    Dim _filtro_nrseqcliente As Integer = 0
    Dim _filtro_nrseqempresa As Integer = 0
    Dim _filtro_nrseqfornecedor As Integer = 0
    Dim _filtro_master As Boolean = False
    Dim _filtro_excluidos As Boolean = False
    Dim _filtro_suspensos As Boolean = False
    Dim _Filtro_email As String = ""
    Dim _filtro_multiplo As New clsfiltro_usuario_email
    Dim _filtro_ativo As Boolean

    Dim _celular As String = ""
    Dim _whats_notificar As Boolean = False
    Dim _email_notificar As Boolean = False
    Dim _exibirnotificacao As Boolean = False
    Dim _dtultimologin As Date
    Dim _hrultimologin As String

    Public Sub New()
        Usuario = HttpContext.Current.Session("usuario")
    End Sub

    Public Property Mensagemerro As String
        Get
            Return _mensagemerro
        End Get
        Set(value As String)
            _mensagemerro = value
        End Set
    End Property

    Public Property Mensagemtitulo As String
        Get
            Return _mensagemtitulo
        End Get
        Set(value As String)
            _mensagemtitulo = value
        End Set
    End Property

    Public Property Mensagemicone As String
        Get
            Return _mensagemicone
        End Get
        Set(value As String)
            _mensagemicone = value
        End Set
    End Property

    Public Property Listaclasse As List(Of clsusuarios)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clsusuarios))
            _listaclasse = value
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

    Public Property Ativo As Boolean
        Get
            Return _ativo
        End Get
        Set(value As Boolean)
            _ativo = value
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

    Public Property Dtexclui As Date
        Get
            Return _dtexclui
        End Get
        Set(value As Date)
            _dtexclui = value
        End Set
    End Property

    Public Property Userexclui As String
        Get
            Return _userexclui
        End Get
        Set(value As String)
            _userexclui = value
        End Set
    End Property

    Public Property Permissao As String
        Get
            Return _permissao
        End Get
        Set(value As String)
            _permissao = value
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

    Public Property Nrseqtransp As Integer
        Get
            Return _nrseqtransp
        End Get
        Set(value As Integer)
            _nrseqtransp = value
        End Set
    End Property

    Public Property Master As Boolean
        Get
            Return _master
        End Get
        Set(value As Boolean)
            _master = value
        End Set
    End Property

    Public Property Imagemperfil As String
        Get
            Return _imagemperfil
        End Get
        Set(value As String)
            _imagemperfil = value
        End Set
    End Property

    Public Property Smartcodesolucoes As Integer
        Get
            Return _smartcodesolucoes
        End Get
        Set(value As Integer)
            _smartcodesolucoes = value
        End Set
    End Property

    Public Property Usuariosistema As Integer
        Get
            Return _usuariosistema
        End Get
        Set(value As Integer)
            _usuariosistema = value
        End Set
    End Property

    Public Property Forcarlogin As Integer
        Get
            Return _forcarlogin
        End Get
        Set(value As Integer)
            _forcarlogin = value
        End Set
    End Property

    Public Property Qtdtentativas As Integer
        Get
            Return _qtdtentativas
        End Get
        Set(value As Integer)
            _qtdtentativas = value
        End Set
    End Property

    Public Property Suspenso As Integer
        Get
            Return _suspenso
        End Get
        Set(value As Integer)
            _suspenso = value
        End Set
    End Property

    Public Property Dtsuspenso As Date
        Get
            Return _dtsuspenso
        End Get
        Set(value As Date)
            _dtsuspenso = value
        End Set
    End Property

    Public Property Usersuspenso As String
        Get
            Return _usersuspenso
        End Get
        Set(value As String)
            _usersuspenso = value
        End Set
    End Property

    Public Property Alterado As Boolean
        Get
            Return _alterado
        End Get
        Set(value As Boolean)
            _alterado = value
        End Set
    End Property

    Public Property Dtalterado As Date
        Get
            Return _dtalterado
        End Get
        Set(value As Date)
            _dtalterado = value
        End Set
    End Property

    Public Property Useralterado As String
        Get
            Return _useralterado
        End Get
        Set(value As String)
            _useralterado = value
        End Set
    End Property

    Public Property Nrseqctrl As String
        Get
            Return _nrseqctrl
        End Get
        Set(value As String)
            _nrseqctrl = value
        End Set
    End Property

    Public Property Hralterado As String
        Get
            Return _hralterado
        End Get
        Set(value As String)
            _hralterado = value
        End Set
    End Property

    Public Property Dtvalidadesenha As Date
        Get
            Return _dtvalidadesenha
        End Get
        Set(value As Date)
            _dtvalidadesenha = value
        End Set
    End Property

    Public Property Ip As String
        Get
            Return _ip
        End Get
        Set(value As String)
            _ip = value
        End Set
    End Property

    Public Property Suspensoatualizacao As Integer
        Get
            Return _suspensoatualizacao
        End Get
        Set(value As Integer)
            _suspensoatualizacao = value
        End Set
    End Property

    Public Property Nrseqconfigusuario As Integer
        Get
            Return _nrseqconfigusuario
        End Get
        Set(value As Integer)
            _nrseqconfigusuario = value
        End Set
    End Property

    Public Property Nrseqempresa As Integer
        Get
            Return _nrseqempresa
        End Get
        Set(value As Integer)
            _nrseqempresa = value
        End Set
    End Property

    Public Property Descricaopermissao As String
        Get
            Return _descricaopermissao
        End Get
        Set(value As String)
            _descricaopermissao = tratatexto(value)
            If Nrseqpermissao = 0 AndAlso Descricaopermissao <> "" Then
                tbx = tabx.conectar("select * from tbpermissoes where descricao = '" & Descricaopermissao & "' and ativo = true")
                If tbx.Rows.Count > 0 Then
                    Nrseqpermissao = tbx.Rows(0)("nrseq").ToString
                End If
            End If
        End Set
    End Property

    Public Property Filtro_descricaopermissao As String
        Get
            Return _filtro_descricaopermissao
        End Get
        Set(value As String)
            _filtro_descricaopermissao = value
        End Set
    End Property

    Public Property Filtro_usuario As String
        Get
            Return _filtro_usuario
        End Get
        Set(value As String)
            _filtro_usuario = value
        End Set
    End Property



    Public Property Filtro_permissao As String
        Get
            Return _filtro_permissao
        End Get
        Set(value As String)
            _filtro_permissao = value
        End Set
    End Property

    Public Property Filtro_nrseqcliente As Integer
        Get
            Return _filtro_nrseqcliente
        End Get
        Set(value As Integer)
            _filtro_nrseqcliente = value
        End Set
    End Property

    Public Property Filtro_nrseqempresa As Integer
        Get
            Return _filtro_nrseqempresa
        End Get
        Set(value As Integer)
            _filtro_nrseqempresa = value
        End Set
    End Property

    Public Property Filtro_nrseqfornecedor As Integer
        Get
            Return _filtro_nrseqfornecedor
        End Get
        Set(value As Integer)
            _filtro_nrseqfornecedor = value
        End Set
    End Property

    Public Property Filtro_master As Boolean
        Get
            Return _filtro_master
        End Get
        Set(value As Boolean)
            _filtro_master = value
        End Set
    End Property

    Public Property Celular As String
        Get
            Return _celular
        End Get
        Set(value As String)
            _celular = value
        End Set
    End Property

    Public Property Whats_notificar As Boolean
        Get
            Return _whats_notificar
        End Get
        Set(value As Boolean)
            _whats_notificar = value
        End Set
    End Property

    Public Property Email_notificar As Boolean
        Get
            Return _email_notificar
        End Get
        Set(value As Boolean)
            _email_notificar = value
        End Set
    End Property

    Public Property Exibirnotificacao As Boolean
        Get
            Return _exibirnotificacao
        End Get
        Set(value As Boolean)
            _exibirnotificacao = value
        End Set
    End Property

    Public Property Dtultimologin As Date
        Get
            Return _dtultimologin
        End Get
        Set(value As Date)
            _dtultimologin = value
        End Set
    End Property

    Public Property Hrultimologin As String
        Get
            Return _hrultimologin
        End Get
        Set(value As String)
            _hrultimologin = value
        End Set
    End Property

    Public Property Filtro_nrseq As Integer
        Get
            Return _filtro_nrseq
        End Get
        Set(value As Integer)
            _filtro_nrseq = value
        End Set
    End Property

    Public Property Filtro_usuario_email As String
        Get
            Return _filtro_usuario_email
        End Get
        Set(value As String)
            _filtro_usuario_email = value
        End Set
    End Property

    Public Property Filtro_email As String
        Get
            Return _Filtro_email
        End Get
        Set(value As String)
            _Filtro_email = value
        End Set
    End Property

    Public Property Filtro_multiplo As clsfiltro_usuario_email
        Get
            Return _filtro_multiplo
        End Get
        Set(value As clsfiltro_usuario_email)
            _filtro_multiplo = value
        End Set
    End Property

    Public Property Nrseqpermissao As Integer
        Get
            Return _Nrseqpermissao
        End Get
        Set(value As Integer)
            _Nrseqpermissao = value
        End Set
    End Property

    Public Property Filtro_excluidos As Boolean
        Get
            Return _filtro_excluidos
        End Get
        Set(value As Boolean)
            _filtro_excluidos = value
        End Set
    End Property

    Public Property Filtro_suspensos As Boolean
        Get
            Return _filtro_suspensos
        End Get
        Set(value As Boolean)
            _filtro_suspensos = value
        End Set
    End Property

    Public Property Emailantigo As String
        Get
            Return _emailantigo
        End Get
        Set(value As String)
            _emailantigo = value
        End Set
    End Property

    Public Property Filtro_empresa As String
        Get
            Return _filtro_empresa
        End Get
        Set(value As String)
            _filtro_empresa = value
        End Set
    End Property

    Public Property Listaempresas As List(Of clsusuarios_empresas)
        Get
            Return _listaempresas
        End Get
        Set(value As List(Of clsusuarios_empresas))
            _listaempresas = value
        End Set
    End Property

    Public Property Filtro_ativo As Boolean
        Get
            Return _filtro_ativo
        End Get
        Set(value As Boolean)
            _filtro_ativo = value
        End Set
    End Property
End Class

Partial Public Class clsusuarios
    Public Function Listarusuarios(xusuario As Integer) As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "select * from vwusuarios where 1=1"
            If Filtro_master Or Filtro_ativo Or Filtro_excluidos Or Filtro_excluidos Then
                Dim condicoes As List(Of String) = New List(Of String)
                If Filtro_master Then
                    condicoes.Add("(ativo = true and master = true)")
                End If
                If Filtro_ativo Then
                    condicoes.Add("(ativo = true and suspenso is not true and master is not true)")
                End If
                If Filtro_excluidos Then
                    condicoes.Add("ativo = false")
                End If
                If Filtro_suspensos Then
                    condicoes.Add("(ativo = true and suspenso = true)")
                End If
                xsql &= " and (" & String.Join(" or ", condicoes) & ")"
            End If
            If xusuario <> 0 Then
                xsql &= " and nrseq = " & xusuario
            End If
            'If Filtro_excluidos Then
            '    xsql &= " and ativo = false"
            'End If
            'If Filtro_suspensos Then
            '    xsql &= " and suspenso = true"
            'End If
            If Filtro_usuario <> "" Then
                xsql &= " and (usuario ilike '%" & Filtro_usuario & "%')"
            End If
            If Filtro_permissao <> "" Then
                xsql &= " and permissao like '%" & Filtro_permissao & "%'"
            End If
            If Filtro_empresa <> "" Then
                xsql &= " and nrseq in (select nrsequsuario from vwusuarios_empresas where (nomefantasiaempresa = '" & Filtro_empresa & "' or razaosocialempresa = '" & Filtro_empresa & "')"
            End If
            xsql &= " order by usuario"
            tb1 = tab1.conectar(xsql)

            Dim tbemp As New Data.DataTable
            Dim tabemp As New clsbanco
            tbemp = tabemp.conectar("select * from vwusuarios_empresas where ativo = true and empresaativa = true and nrsequsuario in (" & xsql.Replace("*", "nrseq") & ") order by nomefantasiaempresa")

            Dim tbusuarios_empresas_unidades As New Data.DataTable
            Dim tabusuarios_empresas_unidades As New clabancopsql
            tbusuarios_empresas_unidades = tabusuarios_empresas_unidades.conectar("Select * from vwusuarios_empresas_unidades where ativo = true And nrsequsuariosempresas In (select nrseq from vwusuarios_empresas where ativo = true and empresaativa = true and nrsequsuario in (" & xsql.Replace("*", "nrseq") & ") )")
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clsusuarios With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Usuario = tb1.Rows(x)("usuario").ToString, .Senha = tb1.Rows(x)("senha").ToString, .Ativo = logico(tb1.Rows(x)("ativo").ToString), .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Usercad = tb1.Rows(x)("usercad").ToString, .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Userexclui = tb1.Rows(x)("userexclui").ToString, .Permissao = tb1.Rows(x)("permissao").ToString, .Email = tb1.Rows(x)("email").ToString, .Nrseqtransp = numeros(tb1.Rows(x)("nrseqtransp").ToString), .Imagemperfil = tb1.Rows(x)("imagemperfil").ToString, .Smartcodesolucoes = numeros(tb1.Rows(x)("smartcodesolucoes").ToString), .Usuariosistema = numeros(tb1.Rows(x)("usuariosistema").ToString), .Forcarlogin = numeros(tb1.Rows(x)("forcarlogin").ToString), .Qtdtentativas = numeros(tb1.Rows(x)("qtdtentativas").ToString), .Suspenso = If(logico(tb1.Rows(x)("suspenso").ToString) = "True", 1, 0), .Dtsuspenso = valordata(tb1.Rows(x)("dtsuspenso").ToString), .Usersuspenso = tb1.Rows(x)("usersuspenso").ToString, .Alterado = numeros(tb1.Rows(x)("alterado").ToString), .Dtalterado = valordata(tb1.Rows(x)("dtalterado").ToString), .Useralterado = tb1.Rows(x)("useralterado").ToString, .Nrseqctrl = tb1.Rows(x)("nrseqctrl").ToString, .Hralterado = tb1.Rows(x)("hralterado").ToString, .Dtvalidadesenha = valordata(tb1.Rows(x)("dtvalidadesenha").ToString), .Ip = tb1.Rows(x)("ip").ToString, .Suspensoatualizacao = numeros(tb1.Rows(x)("suspensoatualizacao").ToString), .Nrseqconfigusuario = numeros(tb1.Rows(x)("nrseqconfigusuario").ToString), .Nrseqempresa = numeros(tb1.Rows(x)("nrseqempresa").ToString), .Nrseqpermissao = numeros(tb1.Rows(x)("Nrseqpermissao").ToString), .Descricaopermissao = tb1.Rows(x)("descricaopermissao").ToString, .Whats_notificar = logico(tb1.Rows(x)("Whats_notificar").ToString), .Email_notificar = logico(tb1.Rows(x)("Email_notificar").ToString), .Celular = tb1.Rows(x)("Celular").ToString, .Exibirnotificacao = logico(tb1.Rows(x)("Exibirnotificacao").ToString), .Dtultimologin = valordata(tb1.Rows(x)("Dtultimologin").ToString), .Hrultimologin = (tb1.Rows(x)("Hrultimologin").ToString), .Master = logico(tb1.Rows(x)("master").ToString)})

                Dim tbprocemp As Data.DataRow()
                tbprocemp = tbemp.Select(" nrsequsuario = " & tb1.Rows(x)("nrseq").ToString)


                For y As Integer = 0 To tbprocemp.Count - 1
                    Listaclasse(Listaclasse.Count - 1).Listaempresas.Add(New clsusuarios_empresas With {.Nrseq = numeros(tbprocemp(y)("nrseq").ToString), .Usercad = tbprocemp(y)("usercad").ToString, .Userexclui = tbprocemp(y)("userexclui").ToString, .Nrseqctrl = tbprocemp(y)("nrseqctrl").ToString, .Dtcad = valordata(tbprocemp(y)("dtcad").ToString), .Dtexclui = valordata(tbprocemp(y)("dtexclui").ToString), .Ativo = logico(tbprocemp(y)("ativo").ToString), .nrseqempresa = numeros(tbprocemp(y)("nrseqempresa").ToString), .nrsequsuario = numeros(tbprocemp(y)("nrsequsuario").ToString), .Logoempresa = tbprocemp(y)("Logoempresa").ToString, .Nomefantasiaempresa = tbprocemp(y)("Nomefantasiaempresa").ToString, .Razaosocialempresa = tbprocemp(y)("Razaosocialempresa").ToString, .Usuario = tbprocemp(y)("Usuario").ToString, .Imagemperfil = tbprocemp(y)("Imagemperfil").ToString})
                    Dim tbproc As Data.DataRow()
                    tbproc = tbusuarios_empresas_unidades.Select("nrsequsuariosempresas = " & numeros(tbprocemp(y)("nrseq").ToString))
                    For z As Integer = 0 To tbproc.Count - 1
                        Listaclasse(Listaclasse.Count - 1).Listaempresas(y).Listausuarios_empresas_unidades.Add(New clsusuarios_empresas_unidades With {.Nrseq = numeros(tbproc(z)("nrseq").ToString), .Usercad = tbproc(z)("usercad").ToString, .Userexclui = tbproc(z)("userexclui").ToString, .Nrseqctrl = tbproc(z)("nrseqctrl").ToString, .Dtcad = valordata(tbproc(z)("dtcad").ToString), .Dtexclui = valordata(tbproc(z)("dtexclui").ToString), .Ativo = logico(tbproc(z)("ativo").ToString), .Nrsequsuariosempresas = numeros(tbproc(z)("nrsequsuariosempresas").ToString), .Nrsequnidade = numeros(tbproc(z)("nrsequnidade").ToString), .Nomeunidade = tbproc(z)("Nomeunidade").ToString})
                    Next
                Next

            Next
            Return True
        Catch excons As Exception
            _mensagemerro = excons.Message
            Return False
        End Try
    End Function



    Public Function Listarusuarios() As Boolean
        Try

            tab1.Paramentrossql.Clear()

            Listaclasse.Clear()
            Dim xsql As String = "select * from vwusuarios where ativo = true"
            If Filtro_nrseq <> 0 Then
                xsql &= " and nrseq = " & Filtro_nrseq
            End If
            If Filtro_master Then
                xsql &= " and master = true"
            End If
            If _filtro_descricaopermissao <> "" Then
                xsql &= " and descricaopermissao like '%" & Filtro_descricaopermissao & "%'"
            End If
            If Filtro_usuario <> "" Then
                xsql &= " and usuario like '%" & Filtro_usuario & "%'"
                'tab1.Paramentrossql.Add("@usuario", "")
            End If
            If Filtro_email <> "" Then
                xsql &= " and email like '%" & Filtro_email & "%'"
                'tab1.Paramentrossql.Add("@email", "")
            End If
            If Filtro_nrseqcliente <> 0 Then
                xsql &= " and nrseqcliente = " & Filtro_nrseqcliente
            End If
            If Filtro_nrseqempresa <> 0 Then
                xsql &= " and nrseq in (select nrsequsuario from tbusuarios_empresas where nrseqempresa = " & Filtro_nrseqempresa & " and ativo = true) "
            End If
            If Filtro_nrseqfornecedor <> 0 Then
                xsql &= " and nrseqfornecedor = " & Filtro_nrseqfornecedor
            End If
            If Filtro_usuario_email <> "" Then
                xsql &= " and (usuario like '%" & Filtro_usuario_email & "%' or email like '%" & Filtro_usuario_email & "%')"

            End If
            If Filtro_multiplo.Usuario <> "" Or Filtro_multiplo.Email <> "" Then
                xsql &= " and (usuario like '%" & Filtro_multiplo.Usuario & "%' or email like '%" & Filtro_multiplo.Email & "%')"

            End If

            xsql &= " order by usuario"
            tb1 = tab1.conectar(xsql)

            Dim tbemp As New Data.DataTable
            Dim tabemp As New clsbanco
            tbemp = tabemp.conectar("select * from vwusuarios_empresas where ativo = true and empresaativa = true and nrsequsuario in (" & xsql.Replace("*", "nrseq") & ") order by nomefantasiaempresa")

            Dim tbusuarios_empresas_unidades As New Data.DataTable
            Dim tabusuarios_empresas_unidades As New clabancopsql
            tbusuarios_empresas_unidades = tabusuarios_empresas_unidades.conectar("Select * from vwusuarios_empresas_unidades where ativo = true And nrsequsuariosempresas In (select nrseq from vwusuarios_empresas where ativo = true and empresaativa = true and nrsequsuario in (" & xsql.Replace("*", "nrseq") & ") )")
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clsusuarios With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Usuario = tb1.Rows(x)("usuario").ToString, .Senha = tb1.Rows(x)("senha").ToString, .Ativo = logico(tb1.Rows(x)("ativo").ToString), .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Usercad = tb1.Rows(x)("usercad").ToString, .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Userexclui = tb1.Rows(x)("userexclui").ToString, .Permissao = tb1.Rows(x)("permissao").ToString, .Email = tb1.Rows(x)("email").ToString, .Nrseqtransp = numeros(tb1.Rows(x)("nrseqtransp").ToString), .Master = numeros(tb1.Rows(x)("master").ToString), .Imagemperfil = tb1.Rows(x)("imagemperfil").ToString, .Smartcodesolucoes = numeros(tb1.Rows(x)("smartcodesolucoes").ToString), .Usuariosistema = numeros(tb1.Rows(x)("usuariosistema").ToString), .Forcarlogin = numeros(tb1.Rows(x)("forcarlogin").ToString), .Qtdtentativas = numeros(tb1.Rows(x)("qtdtentativas").ToString), .Suspenso = numeros(tb1.Rows(x)("suspenso").ToString), .Dtsuspenso = valordata(tb1.Rows(x)("dtsuspenso").ToString), .Usersuspenso = tb1.Rows(x)("usersuspenso").ToString, .Alterado = numeros(tb1.Rows(x)("alterado").ToString), .Dtalterado = valordata(tb1.Rows(x)("dtalterado").ToString), .Useralterado = tb1.Rows(x)("useralterado").ToString, .Nrseqctrl = tb1.Rows(x)("nrseqctrl").ToString, .Hralterado = tb1.Rows(x)("hralterado").ToString, .Dtvalidadesenha = valordata(tb1.Rows(x)("dtvalidadesenha").ToString), .Ip = tb1.Rows(x)("ip").ToString, .Suspensoatualizacao = numeros(tb1.Rows(x)("suspensoatualizacao").ToString), .Nrseqconfigusuario = numeros(tb1.Rows(x)("nrseqconfigusuario").ToString), .Nrseqempresa = numeros(tb1.Rows(x)("nrseqempresa").ToString), .Descricaopermissao = tb1.Rows(x)("descricaopermissao").ToString, .Whats_notificar = logico(tb1.Rows(x)("whats_notificar").ToString), .Celular = tb1.Rows(x)("Celular").ToString, .Email_notificar = logico(tb1.Rows(x)("Email_notificar").ToString), .Dtultimologin = valordata(tb1.Rows(x)("Dtultimologin").ToString), .Hrultimologin = (tb1.Rows(x)("Hrultimologin").ToString)})

                Dim tbprocemp As Data.DataRow()
                tbprocemp = tbemp.Select(" nrsequsuario = " & tb1.Rows(x)("nrseq").ToString)


                For y As Integer = 0 To tbprocemp.Count - 1
                    Listaclasse(Listaclasse.Count - 1).Listaempresas.Add(New clsusuarios_empresas With {.Nrseq = numeros(tbprocemp(y)("nrseq").ToString), .Usercad = tbprocemp(y)("usercad").ToString, .Userexclui = tbprocemp(y)("userexclui").ToString, .Nrseqctrl = tbprocemp(y)("nrseqctrl").ToString, .Dtcad = valordata(tbprocemp(y)("dtcad").ToString), .Dtexclui = valordata(tbprocemp(y)("dtexclui").ToString), .Ativo = logico(tbprocemp(y)("ativo").ToString), .nrseqempresa = numeros(tbprocemp(y)("nrseqempresa").ToString), .nrsequsuario = numeros(tbprocemp(y)("nrsequsuario").ToString), .Logoempresa = tbprocemp(y)("Logoempresa").ToString, .Nomefantasiaempresa = tbprocemp(y)("Nomefantasiaempresa").ToString, .Razaosocialempresa = tbprocemp(y)("Razaosocialempresa").ToString, .Usuario = tbprocemp(y)("Usuario").ToString, .Imagemperfil = tbprocemp(y)("Imagemperfil").ToString})
                    Dim tbproc As Data.DataRow()
                    tbproc = tbusuarios_empresas_unidades.Select("nrsequsuariosempresas = " & numeros(tbprocemp(y)("nrseq").ToString))
                    For z As Integer = 0 To tbproc.Count - 1
                        Listaclasse(Listaclasse.Count - 1).Listaempresas(y).Listausuarios_empresas_unidades.Add(New clsusuarios_empresas_unidades With {.Nrseq = numeros(tbproc(z)("nrseq").ToString), .Usercad = tbproc(z)("usercad").ToString, .Userexclui = tbproc(z)("userexclui").ToString, .Nrseqctrl = tbproc(z)("nrseqctrl").ToString, .Dtcad = valordata(tbproc(z)("dtcad").ToString), .Dtexclui = valordata(tbproc(z)("dtexclui").ToString), .Ativo = logico(tbproc(z)("ativo").ToString), .Nrsequsuariosempresas = numeros(tbproc(z)("nrsequsuariosempresas").ToString), .Nrsequnidade = numeros(tbproc(z)("nrsequnidade").ToString), .Nomeunidade = tbproc(z)("Nomeunidade").ToString})
                    Next
                Next

            Next
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function


    Public Function procurar() As Boolean
        Try
            If Nrseq = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
            End If
            tb1 = tab1.conectar("select * from vwusuarios where nrseq = " & Nrseq)
            If tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(tb1.Rows(0)("nrseq").ToString)
            Usuario = tb1.Rows(0)("usuario").ToString
            Senha = tb1.Rows(0)("senha").ToString
            Ativo = logico(tb1.Rows(0)("ativo").ToString)
            Dtcad = FormatDateTime(valordata(tb1.Rows(0)("dtcad").ToString), DateFormat.ShortDate)
            Usercad = tb1.Rows(0)("usercad").ToString
            Dtexclui = FormatDateTime(valordata(tb1.Rows(0)("dtexclui").ToString), DateFormat.ShortDate)
            Userexclui = tb1.Rows(0)("userexclui").ToString
            Permissao = numeros(tb1.Rows(0)("permissao").ToString)
            Descricaopermissao = tb1.Rows(0)("Descricaopermissao").ToString
            Email = tb1.Rows(0)("email").ToString
            Nrseqtransp = numeros(tb1.Rows(0)("nrseqtransp").ToString)
            Master = numeros(tb1.Rows(0)("master").ToString)
            Imagemperfil = tb1.Rows(0)("imagemperfil").ToString
            Smartcodesolucoes = numeros(tb1.Rows(0)("smartcodesolucoes").ToString)
            Usuariosistema = numeros(tb1.Rows(0)("usuariosistema").ToString)
            Forcarlogin = numeros(tb1.Rows(0)("forcarlogin").ToString)
            Qtdtentativas = numeros(tb1.Rows(0)("qtdtentativas").ToString)
            Suspenso = numeros(tb1.Rows(0)("suspenso").ToString)
            Dtsuspenso = FormatDateTime(valordata(tb1.Rows(0)("dtsuspenso").ToString), DateFormat.ShortDate)
            Usersuspenso = tb1.Rows(0)("usersuspenso").ToString
            Alterado = numeros(tb1.Rows(0)("alterado").ToString)
            Dtalterado = FormatDateTime(valordata(tb1.Rows(0)("dtalterado").ToString), DateFormat.ShortDate)
            Useralterado = tb1.Rows(0)("useralterado").ToString
            Nrseqctrl = tb1.Rows(0)("nrseqctrl").ToString
            Hralterado = tb1.Rows(0)("hralterado").ToString
            Dtvalidadesenha = FormatDateTime(valordata(tb1.Rows(0)("dtvalidadesenha").ToString), DateFormat.ShortDate)
            Ip = tb1.Rows(0)("ip").ToString
            Suspensoatualizacao = numeros(tb1.Rows(0)("suspensoatualizacao").ToString)
            Nrseqconfigusuario = numeros(tb1.Rows(0)("nrseqconfigusuario").ToString)
            Nrseqempresa = numeros(tb1.Rows(0)("nrseqempresa").ToString)
            Whats_notificar = logico(tb1.Rows(0)("whats_notificar").ToString)
            Celular = tb1.Rows(0)("Celular").ToString
            Hrultimologin = tb1.Rows(0)("Hrultimologin").ToString
            Email_notificar = logico(tb1.Rows(0)("Email_notificar").ToString)
            Dtultimologin = valordata(tb1.Rows(0)("Dtultimologin").ToString)
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function
    Public Function SalvarMaster() As Boolean
        Try
            Dim xsql As String = "update tbusuarios set   master = " & logico(Master)
            xsql &= ", exibirnotificacao = true where nrseq = " & Nrseq

            tb1 = tab1.IncluirAlterarDados(xsql)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function SalvarNotificacoes() As Boolean
        Try
            Dim xsql As String = "update tbusuarios set whats_notificar = " & logico(Whats_notificar) & ", email_notificar = " & logico(Email_notificar) & ", exibirnotificacao = False"
            If Email <> "" Then
                xsql &= " , email = '" & Email & "'"
            End If
            If Celular <> "" Then
                xsql &= " , celular = '" & Celular & "'"
            End If
            xsql &= " where nrseq = " & Nrseq

            tb1 = tab1.IncluirAlterarDados(xsql)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function salvar() As Boolean
        Try
            Dim xsql As String
            xsql = " update tbusuarios Set ativo = True"
            If Celular <> "" Then
                xsql &= ", celular = '" & tratatexto(Celular) & "'"
            End If
            If Usuario <> "" Then
                xsql &= ",usuario = '" & tratatexto(Usuario) & "'"
            End If
            If Senha <> "" Then
                xsql &= ",senha = '" & tratatexto(Senha) & "'"
            End If

            xsql &= ",permissao = " & numeros(Permissao)

            If Email <> "" Then
                xsql &= ",email = '" & tratatexto(Email) & "'"
            End If
            If Useralterado <> "" Then
                xsql &= ",useralterado = '" & tratatexto(Useralterado) & "'"
            End If
            If Hralterado <> "" Then
                xsql &= ",hralterado = '" & tratatexto(Hralterado) & "'"
            End If
            If Nrseqempresa <> 0 Then
                xsql &= ",nrseqempresa = " & moeda(Nrseqempresa)
            End If

            xsql &= ",dtvalidadesenha = '" & formatadatamysql(Dtvalidadesenha) & "'"
            xsql &= ",alterado = " & logico(Alterado)
            xsql &= ",dtalterado = '" & formatadatamysql(Dtalterado) & "'"
            xsql &= " where nrseq = " & Nrseq
            tb1 = tab1.IncluirAlterarDados(xsql)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
    Public Function salvar(versaonovas As Boolean, Optional xnovo As Boolean = False) As Boolean
        Try
            If xnovo = True Then
                novo()
            End If
            Dim xsql As String
            Dim xprocura As New clsusuarios
            Dim xjaexiste As Boolean = True
            xprocura.Nrseq = _nrseq
            If Not xprocura.procurar() Then
                xjaexiste = False
            End If
            xsql = " update tbusuarios Set ativo = true"
            If xjaexiste Then
                If _usuario <> xprocura.Usuario Then
                    xsql &= ",usuario = '" & tratatexto(_usuario) & "'"
                End If
            Else
                If _usuario <> "" Then
                    xsql &= ",usuario = '" & tratatexto(_usuario) & "'"
                End If
            End If
            If xjaexiste Then
                If _senha <> xprocura.Senha Then
                    xsql &= ",senha = '" & tratatexto(_senha) & "'"
                End If
            Else
                If _senha <> "" Then
                    xsql &= ",senha = '" & tratatexto(_senha) & "'"
                End If
            End If
            If xjaexiste Then
                If _permissao <> numeros(xprocura.Permissao) Then
                    xsql &= ",permissao = " & numeros(_permissao)
                End If
            Else
                If _permissao <> 0 Then
                    xsql &= ",permissao = " & numeros(_permissao)
                End If
            End If
            If xjaexiste Then
                If _email <> xprocura.Email Then
                    xsql &= ",email = '" & tratatexto(_email) & "'"
                End If
            Else
                If _email <> "" Then
                    xsql &= ",email = '" & tratatexto(_email) & "'"
                End If
            End If
            If xjaexiste Then
                If _nrseqtransp <> numeros(xprocura.Nrseqtransp) Then
                    xsql &= ",nrseqtransp = " & numeros(_nrseqtransp)
                End If
            Else
                If _nrseqtransp <> 0 Then
                    xsql &= ",nrseqtransp = " & numeros(_nrseqtransp)
                End If
            End If
            If xjaexiste Then
                If logico(_master) <> logico(xprocura.Master) Then
                    xsql &= ",master = " & logico(_master) & ""
                End If
            Else
                If _master <> True Then
                    xsql &= ",master = " & logico(_master)
                End If
            End If
            If xjaexiste Then
                If _imagemperfil <> xprocura.Imagemperfil Then
                    xsql &= ",imagemperfil = '" & tratatexto(_imagemperfil) & "'"
                End If
            Else
                If _imagemperfil <> "" Then
                    xsql &= ",imagemperfil = '" & tratatexto(_imagemperfil) & "'"
                End If
            End If
            If xjaexiste Then
                If logico(_smartcodesolucoes) <> logico(xprocura.Smartcodesolucoes) Then
                    xsql &= ",smartcodesolucoes =  " & logico(_smartcodesolucoes)
                End If
            Else
                If _smartcodesolucoes <> True Then
                    xsql &= ",smartcodesolucoes = " & logico(_smartcodesolucoes)
                End If
            End If
            If xjaexiste Then
                If logico(_usuariosistema) <> logico(xprocura.Usuariosistema) Then
                    xsql &= ",usuariosistema =  (" & logico(_usuariosistema) & ")"
                End If
            Else
                If _usuariosistema <> True Then
                    xsql &= ",usuariosistema = " & logico(_usuariosistema)
                End If
            End If
            If xjaexiste Then
                If logico(_forcarlogin) <> logico(xprocura.Forcarlogin) Then
                    xsql &= ",forcarlogin =  (" & logico(_forcarlogin) & ")"
                End If
            Else
                If _forcarlogin <> True Then
                    xsql &= ",forcarlogin = " & logico(_forcarlogin)
                End If
            End If
            If xjaexiste Then
                If _qtdtentativas <> numeros(xprocura.Qtdtentativas) Then
                    xsql &= ",qtdtentativas = " & numeros(_qtdtentativas)
                End If
            Else
                If _qtdtentativas <> 0 Then
                    xsql &= ",qtdtentativas = " & numeros(_qtdtentativas)
                End If
            End If
            If xjaexiste Then
                If logico(_suspenso) <> logico(xprocura.Suspenso) Then
                    xsql &= ",suspenso =  (" & logico(_suspenso) & ")"
                End If
            Else
                If _suspenso <> True Then
                    xsql &= ",suspenso = " & logico(_suspenso)
                End If
            End If
            If xjaexiste Then
                If valordata(_dtsuspenso) <> valordata(xprocura.Dtsuspenso) Then
                    xsql &= ",dtsuspenso =  '" & formatadatamysql(valordata(_dtsuspenso)) & "'"
                End If
            Else
                If valordata(_dtsuspenso) <> valordata("01/01/1900") Then
                    xsql &= ",dtsuspenso =  '" & formatadatamysql(valordata(_dtsuspenso)) & "'"
                End If
            End If
            If xjaexiste Then
                If _usersuspenso <> xprocura.Usersuspenso Then
                    xsql &= ",usersuspenso = '" & tratatexto(_usersuspenso) & "'"
                End If
            Else
                If _usersuspenso <> "" Then
                    xsql &= ",usersuspenso = '" & tratatexto(_usersuspenso) & "'"
                End If
            End If
            If xjaexiste Then
                If logico(_alterado) <> logico(xprocura.Alterado) Then
                    xsql &= ",alterado =  (" & logico(_alterado) & ")"
                End If
            Else
                If _alterado <> True Then
                    xsql &= ",alterado = " & logico(_alterado)
                End If
            End If
            If xjaexiste Then
                If valordata(_dtalterado) <> valordata(xprocura.Dtalterado) Then
                    xsql &= ",dtalterado =  '" & formatadatamysql(valordata(_dtalterado)) & "'"
                End If
            Else
                If valordata(_dtalterado) <> valordata("01/01/1900") Then
                    xsql &= ",dtalterado =  '" & formatadatamysql(valordata(_dtalterado)) & "'"
                End If
            End If
            If xjaexiste Then
                If _useralterado <> xprocura.Useralterado Then
                    xsql &= ",useralterado = '" & tratatexto(_useralterado) & "'"
                End If
            Else
                If _useralterado <> "" Then
                    xsql &= ",useralterado = '" & tratatexto(_useralterado) & "'"
                End If
            End If
            If xjaexiste Then
                If _hralterado <> xprocura.Hralterado Then
                    xsql &= ",hralterado = '" & tratatexto(_hralterado) & "'"
                End If
            Else
                If _hralterado <> "" Then
                    xsql &= ",hralterado = '" & tratatexto(_hralterado) & "'"
                End If
            End If
            If xjaexiste Then
                If valordata(_dtvalidadesenha) <> valordata(xprocura.Dtvalidadesenha) Then
                    xsql &= ",dtvalidadesenha =  '" & formatadatamysql(valordata(_dtvalidadesenha)) & "'"
                End If
            Else
                If valordata(_dtvalidadesenha) <> valordata("01/01/1900") Then
                    xsql &= ",dtvalidadesenha =  '" & formatadatamysql(valordata(_dtvalidadesenha)) & "'"
                End If
            End If
            If xjaexiste Then
                If _ip <> xprocura.Ip Then
                    xsql &= ",ip = '" & tratatexto(_ip) & "'"
                End If
            Else
                If _ip <> "" Then
                    xsql &= ",ip = '" & tratatexto(_ip) & "'"
                End If
            End If
            If xjaexiste Then
                If logico(_suspensoatualizacao) <> logico(xprocura.Suspensoatualizacao) Then
                    xsql &= ",suspensoatualizacao =  (" & logico(_suspensoatualizacao) & ")"
                End If
            Else
                If _suspensoatualizacao <> True Then
                    xsql &= ",suspensoatualizacao = " & logico(_suspensoatualizacao)
                End If
            End If
            If xjaexiste Then
                If _nrseqconfigusuario <> numeros(xprocura.Nrseqconfigusuario) Then
                    xsql &= ",nrseqconfigusuario = " & numeros(_nrseqconfigusuario)
                End If
            Else
                If _nrseqconfigusuario <> 0 Then
                    xsql &= ",nrseqconfigusuario = " & numeros(_nrseqconfigusuario)
                End If
            End If
            If xjaexiste Then
                If _nrseqempresa <> numeros(xprocura.Nrseqempresa) Then
                    xsql &= ",nrseqempresa = " & numeros(_nrseqempresa)
                End If
            Else
                If _nrseqempresa <> 0 Then
                    xsql &= ",nrseqempresa = " & numeros(_nrseqempresa)
                End If
            End If
            If xjaexiste Then
                If _celular <> xprocura.Celular Then
                    xsql &= ",celular = '" & tratatexto(_celular) & "'"
                End If
            Else
                If _celular <> "" Then
                    xsql &= ",celular = '" & tratatexto(_celular) & "'"
                End If
            End If
            If xjaexiste Then
                If logico(_email_notificar) <> logico(xprocura.Email_notificar) Then
                    xsql &= ",email_notificar =  (" & logico(_email_notificar) & ")"
                End If
            Else
                If _email_notificar <> True Then
                    xsql &= ",email_notificar = " & logico(_email_notificar)
                End If
            End If
            If xjaexiste Then
                If logico(_whats_notificar) <> logico(xprocura.Whats_notificar) Then
                    xsql &= ",whats_notificar =  (" & logico(_whats_notificar) & ")"
                End If
            Else
                If _whats_notificar <> True Then
                    xsql &= ",whats_notificar = " & logico(_whats_notificar)
                End If
            End If
            xsql &= " where nrseq = " & _nrseq
            tb1 = tab1.IncluirAlterarDados(xsql)
            Return True
        Catch exsalvar As Exception
            _mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function

    Public Function novo() As Boolean
        Try
            Dim wcnrseqctrl As String = gerarnrseqcontrole()
            tb1 = tab1.IncluirAlterarDados("insert into tbusuarios (nrseqctrl, dtcad, usercad, ativo, dtultimologin) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false, '" & hoje() & "')")
            tb1 = tab1.conectar("Select * from  tbusuarios where nrseqctrl = '" & wcnrseqctrl & "'")
            Nrseq = tb1.Rows(0)("nrseq").ToString
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function

    Public Function excluir() As Boolean
        Try
            If Nrseq = 0 Then
                Mensagemerro = "Por favor, informe um item para excluir !"
                Return False
            End If
            If Not procurar() Then
                Return False
            End If
            tb1 = tab1.IncluirAlterarDados("update tbusuarios set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
    Public Function salvarUltimoLogin() As Boolean
        Try
            tb1 = tab1.IncluirAlterarDados("update tbusuarios set dtultimologin = '" & hoje() & "', hrultimologin = '" & hora() & "' where nrseq = " & Nrseq)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function RecuperarSenha(xnrsequsuario As Integer) As Boolean
        Try
            Dim xusuarios As New clsusuarios
            xusuarios.Filtro_nrseq = xnrsequsuario
            xusuarios.Listarusuarios()
            If xusuarios.Listaclasse.Count = 0 Then
                Return False
            End If

            Dim xnovasenha As String = ""
            Dim xsenha As New clsgeradorsenhas
            xsenha.Gerar()
            xnovasenha = tratatexto(AES_Encrypt(xsenha.Novasenha, "CodeSmart@9898"), True)
            tb1 = tab1.IncluirAlterarDados("update tbusuarios set ativo = true, senha = '" & xnovasenha & "', alterado = false, suspenso = false, qtdtentativas = 0, dtultimologin='" & hoje() & "' where nrseq = " & xnrsequsuario)

            If Not enviarsenhaemail(xnrsequsuario) Then
                Return False
            End If

            Mensagemerro = "Nova senha enviada !"
            Return True
        Catch ex As Exception
            Mensagemerro = ex.Message
            Return False
        End Try
    End Function
    Public Function enviarsenhaemail(xnrsequsuario As Integer) As Boolean
        Try

            Dim xusuarios As New clsusuarios
            xusuarios.Filtro_nrseq = xnrsequsuario
            xusuarios.Listarusuarios()
            If xusuarios.Listaclasse.Count = 0 Then
                Return False
            End If
            If Not validaemail(xusuarios.Listaclasse(0).Email) Then
                Mensagemerro = "Invalid e-mail!"
                Return False
            End If

            Dim xmapa As New clsconfig_padroes
            xmapa.Paramentrossql.Add("@nrseq", xusuarios.Listaclasse(0).Nrseq)
            xmapa.Filtro_nome = "New user or password"
            xmapa.Listarconfig_padroes()

            If xmapa.Listaclasse.Count = 0 Then
                Mensagemerro = "No default found !"
                Return False
            End If
            If Not xmapa.gerarHTMLdocumento("Reset de senha", "Novo usuario") Then
                Mensagemerro = xmapa.Mensagemerro
                Return False
            End If

            Dim xtexto As String = ""
            Dim xlerhtml As New StreamReader(xmapa.Nomearquivogerado)
            xtexto = xlerhtml.ReadToEnd
            xlerhtml.Close()

            Dim email As New clsEnvioEmail
            email.configpadrao()
            email.AdicionaDestinatarios = "alertas@smartcodesolucoes.com.br"
            email.AdicionaDestinatarios = xusuarios.Listaclasse(0).Email
            email.EhHTML = True
            email.AdicionaMensagem = xtexto
            email.AdicionaAssunto = xmapa.Listaclasse(0).Assunto
            email.AdicionaAssunto = "Bem vindo ao Pralis !"
            email.ConfigPorta = 587

            Return email.EnviarEmail
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function ValidarCelular(Optional xgravarnaoquero As Boolean = False) As Boolean
        Try
            If xgravarnaoquero Then
                tb1 = tab1.IncluirAlterarDados("update tbusuarios set celular = '', semvinculo = true where nrseq = " & Nrseq)
                Return True
            End If
            tb1 = tab1.conectar("select * from tbusuarios where celular = '" & Celular & "' and nrseq <> " & Nrseq)
            If tb1.Rows.Count > 0 Then
                Mensagemerro = "Esse telefone já foi vinculado à outro acesso! Por favor, altere o telefone no seu cadastro!"

                Return False
            End If


            tb1 = tab1.IncluirAlterarDados("update tbusuarios set celular = '" & Celular & "', semvinculo = false where nrseq = " & Nrseq)

            Return True
        Catch ex As Exception
            Mensagemerro = ex.Message
            Return False
        End Try

    End Function
    Public Function alterarusuario() As Boolean
        Try

            If _nrseq = 0 Then
                _mensagemerro = "Enter a valid user ID !"
                Return False
            End If

            tb1 = tab1.conectar("select * from vwusuarios where nrseq = " & _nrseq)
            If tb1.Rows.Count = 0 Then
                _mensagemerro = "User ID " & _nrseq & " not found !"
                Return False
            End If
            Dim xsql As String = "update tbusuarios set qtdtentativas = 0, ativo = true"
            If _email <> "" Then
                xsql &= ", email = '" & tratatexto(_email) & "'"
            End If
            If _senha <> "" Then
                xsql &= ", senha = '" & tratatexto(_senha) & "'"
            End If
            If _permissao <> "" Then
                xsql &= ", permissao = '" & _permissao & "'"
            End If
            If _imagemperfil <> "" Then
                xsql &= ", imagemperfil = '" & _imagemperfil & "'"
            End If



            tb1 = tab1.IncluirAlterarDados(xsql & " where nrseq = " & _nrseq)
            If _email <> Emailantigo Then
                tb1 = tab1.IncluirAlterarDados("update tbcolaboradores set email = '" & _email & "' where nrsequsuario = " & _nrseq)
            End If
            Return True
        Catch exuser As Exception
            _mensagemerro = exuser.Message
            Return False
        End Try

    End Function
End Class