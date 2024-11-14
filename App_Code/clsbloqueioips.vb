Imports Microsoft.VisualBasic
Imports clsSmart
Imports clssessoes
Imports System.Data

Public Class clsbloqueioips


    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _mensagemerro As String
    Dim _mensagemtitulo As String = "Ops !"
    Dim _mensagemicone As String = "error"
    Dim _listaclasse As New List(Of clsbloqueioips)
    Dim _nrseq As Integer
    Dim _endereco As String
    Dim _ativo As Boolean
    Dim _dtcad As Date

    Dim _usercad As String
    Dim _userdesbloqueio As String
    Dim _nrseqctrl As String
    Dim _userexclui As String
    Dim _hrdesbloqueio As String
    Dim _hrbloqueio As String
    Dim _dtdesbloqueio As Date
    Dim _bloqueado As Boolean
    Dim _dtexclui As Date
    Dim _filtrar_ativos As Boolean
    Dim _filtrar_resolvidos As Boolean
    Dim _filtrar_resolvidospor As String
    Dim _filtrar_dtinicio As Date
    Dim _filtrar_dtfim As Date

    Dim _filtro_nrseq As Integer = 0
    Dim _nrsequsuario As Integer = 0



    Public Sub New()
        Dtcad = data()
        Usercad = HttpContext.Current.Session("usuario")

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

    Public Property Listaclasse As List(Of clsbloqueioips)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clsbloqueioips))
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

    Public Property Endereco As String
        Get
            Return _endereco
        End Get
        Set(value As String)
            _endereco = value
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

    Public Property Bloqueado As Boolean
        Get
            Return _bloqueado
        End Get
        Set(value As Boolean)
            _bloqueado = value
        End Set
    End Property

    Public Property Userdesbloqueio As String
        Get
            Return _userdesbloqueio
        End Get
        Set(value As String)
            _userdesbloqueio = value
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

    Public Property Userexclui As String
        Get
            Return _userexclui
        End Get
        Set(value As String)
            _userexclui = value
        End Set
    End Property

    Public Property Hrdesbloqueio As String
        Get
            Return _hrdesbloqueio
        End Get
        Set(value As String)
            _hrdesbloqueio = value
        End Set
    End Property

    Public Property Hrbloqueio As String
        Get
            Return _hrbloqueio
        End Get
        Set(value As String)
            _hrbloqueio = value
        End Set
    End Property

    Public Property Dtdesbloqueio As Date
        Get
            Return _dtdesbloqueio
        End Get
        Set(value As Date)
            _dtdesbloqueio = value
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

    Public Property Filtrar_ativos As Boolean
        Get
            Return _filtrar_ativos
        End Get
        Set(value As Boolean)
            _filtrar_ativos = value
        End Set
    End Property

    Public Property Filtrar_resolvidos As Boolean
        Get
            Return _filtrar_resolvidos
        End Get
        Set(value As Boolean)
            _filtrar_resolvidos = value
        End Set
    End Property

    Public Property Filtrar_resolvidospor As String
        Get
            Return _filtrar_resolvidospor
        End Get
        Set(value As String)
            _filtrar_resolvidospor = value
        End Set
    End Property

    Public Property Filtrar_dtinicio As Date
        Get
            Return _filtrar_dtinicio
        End Get
        Set(value As Date)
            _filtrar_dtinicio = value
        End Set
    End Property

    Public Property Filtrar_dtfim As Date
        Get
            Return _filtrar_dtfim
        End Get
        Set(value As Date)
            _filtrar_dtfim = value
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

    Public Property Nrsequsuario As Integer
        Get
            Return _nrsequsuario
        End Get
        Set(value As Integer)
            _nrsequsuario = value
        End Set
    End Property

    Public Function gravarip() As Boolean
        Try
            Tb1 = tab1.IncluirAlterarDados("insert into tbbloqueioips (endereco, ativo, dtcad, usercad, hrbloqueio, bloqueado, nrsequsuario) values ('" & Endereco & "', true, '" & hoje() & "', '" & Usercad & "','" & hora() & "', true, " & numeros(Nrsequsuario) & ")")
            Dim xbot As New clsbot
            xbot.enviarMensagem("+5541999828277", "Suporte Smartcode", "Atenção: O usuário " & Usercad & " bloqueou o IP/MAC " & Endereco & " ao acesso ao sistema PAD" & Chr(13) & "Entre no sistema, pressione a tecla F9 para visualizar todos os IPs/MACs bloqueados. ")
            'xbot.enviarMensagem("+5541999828277", "Suporte Smartcode", "Entre no sistema, pressione a tecla F9 para visualizar todos os IPs bloqueados. ")



            Dim xemail As New clscaixamensagens
            Dim xuser As New clsusuarios
            xuser.Filtro_master = True
            xuser.Listarusuarios()
            For y As Integer = 0 To xuser.Listaclasse.Count - 1
                If xuser.Listaclasse(y).Email.Contains("@") Then
                    xemail.destinatarios.Add(New clscaixamensagens_destinatarios With {.Email = xuser.Listaclasse(y).Email})
                End If
            Next

            xemail.Assunto = Resources.Resource.idbloqip & " (" & Endereco & ") " & Resources.Resource.idsispad
            xemail.destinatarios.Add(New clscaixamensagens_destinatarios With {.Email = "alertas@smartcodesolucoes.com.br"})

            xemail.Corpo = Resources.Resource.idprezadoadmin & Usercad & Resources.Resource.idteveipbloq & data() & " - " & hora() & "!"
            xemail.enviar()



            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function
    Public Function moostrarbloqueados() As Boolean
        Try
            Tb1 = tab1.conectar("Select * from tbbloqueioips where endereco = '" & Endereco & "' and ativo = true")
            If Tb1.Rows.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try


    End Function

    Public Function desbloquearIP() As Boolean
        Try
            tb1 = tab1.conectar("select * from tbbloqueioips where nrseq = " & Nrseq)
            If tb1.Rows.Count > 0 Then
                Nrsequsuario = tb1.Rows(0)("nrsequsuario").ToString
                tb1 = tab1.IncluirAlterarDados("update tbbloqueioips set ativo = false,bloqueado = false,  userdesbloqueio = '" & Usercad & "', dtdesbloqueio = '" & hoje() & "', hrdesbloqueio = '" & hora() & "' where nrseq = " & Nrseq)
                Dim xnomecliente As String = HttpContext.Current.Session("nomecliente")
                If xnomecliente.Contains(" ") Then xnomecliente = xnomecliente.Split(" ")(0).ToString
                Dim xsenha As String = primeiraletra(xnomecliente) & "@" & data().Year
                xsenha = tratatexto(AES_Encrypt(xsenha, "CodeSmart@9898"), True)
                tb1 = tab1.IncluirAlterarDados("update tbusuarios set suspenso = false, alterado = false, senha = '" & xsenha & "', qtdtentativas = 0 where nrseq = " & Nrsequsuario)
            End If

            Return True
        Catch ex As Exception
            Mensagemerro = ex.Message
            Return False
        End Try
    End Function


    Public Function Listarbloqueioips() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "select * from tbbloqueioips where ativo = true"
            If Filtro_nrseq <> 0 Then
                xsql &= " and nrseq = " & Filtro_nrseq
            End If
            tb1 = tab1.conectar(xsql)
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clsbloqueioips With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Endereco = tb1.Rows(x)("endereco").ToString, .Ativo = logico(tb1.Rows(x)("ativo").ToString), .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Usercad = tb1.Rows(x)("usercad").ToString, .Bloqueado = logico(tb1.Rows(x)("bloqueado").ToString), .Hrbloqueio = tb1.Rows(x)("hrbloqueio").ToString, .Userdesbloqueio = tb1.Rows(x)("userdesbloqueio").ToString, .Dtdesbloqueio = valordata(tb1.Rows(x)("dtdesbloqueio").ToString), .Nrseqctrl = tb1.Rows(x)("nrseqctrl").ToString, .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Userexclui = tb1.Rows(x)("userexclui").ToString, .Hrdesbloqueio = tb1.Rows(x)("hrdesbloqueio").ToString})
            Next
            Return True
        Catch excons As Exception
            _mensagemerro = excons.Message
            Return False
        End Try
    End Function


    Public Function procurar() As Boolean
        Try
            If Nrseq = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Dim xsql As String = "select * from tbbloqueioips where nrseq = " & Nrseq
            Tb1 = tab1.conectar(xsql)
            If Tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(Tb1.Rows(0)("nrseq").ToString)
            Endereco = Tb1.Rows(0)("endereco").ToString
            Ativo = logico(Tb1.Rows(0)("ativo").ToString)
            Dtcad = FormatDateTime(valordata(Tb1.Rows(0)("dtcad").ToString), DateFormat.ShortDate)
            Usercad = Tb1.Rows(0)("usercad").ToString
            Bloqueado = logico(Tb1.Rows(0)("bloqueado").ToString)
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function

    Public Function salvar() As Boolean
        Try
            Dim xsql As String
            xsql = " update tbbloqueioips Set ativo = True"
            If Nrseq <> 0 Then
                xsql &= ",nrseq = " & moeda(Nrseq)
            End If
            If Endereco <> "" Then
                xsql &= ",endereco = '" & tratatexto(Endereco) & "'"
            End If


            xsql &= ",bloqueado = '" & logico(Bloqueado) & "'"

            xsql &= " where nrseq = " & Nrseq
            Tb1 = tab1.IncluirAlterarDados(xsql)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function

    Public Function novo() As Boolean
        Try
            Dim wcnrseqctrl As String = gerarnrseqcontrole()
            Tb1 = tab1.IncluirAlterarDados("insert into tbbloqueioips (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            Tb1 = tab1.conectar("Select * from  tbbloqueioips where nrseqctrl = '" & wcnrseqctrl & "'")
            Nrseq = Tb1.Rows(0)("nrseq").ToString
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
            Tb1 = tab1.IncluirAlterarDados("update tbbloqueioips set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
End Class
