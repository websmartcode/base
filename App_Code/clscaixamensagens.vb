Imports Microsoft.VisualBasic
Imports clssessoes
Imports clsSmart
Imports System.IO
Imports System.Data

Public Class clscaixamensagens
    Dim tbemail As New Data.DataTable
    Dim tabemail As New clabancopsql
    Public destinatarios As New List(Of clscaixamensagens_destinatarios)()

    Public anexos As New List(Of clscaixamensagens_anexos)()
    Dim _origemdeemailenviado As Boolean = False
    Dim _corpo As String
    Dim _assunto As String
    Dim _remetente As String = HttpContext.Current.Session("usuario")
    Dim _nrseqremetente As Integer = HttpContext.Current.Session("idusuario")
    Dim _tbanexos As New Data.DataTable
    Dim _urgente As Boolean = False
    Dim _qtdanexos As Integer = 0
    Dim _nrseq As Integer

    ' nrseq,assunto,nrseqremetente,dtcad,usercad,ativo,dtexclui,userexclui,corpo,anexo,urgente,nrseqctrl,hrcad,    solicitarresposta,tipo,publico,nrseqanoletivo,nrseqturma,nrseqturno,nrseqcurso


    Dim _Mensagemerro As String

    Public Sub New(Optional validar As Boolean = False)
        If Not validar Then
            Dim wcnrseqctrl As String = gerarnrseqcontrole()
            tbemail = tabemail.IncluirAlterarDados("insert into tbcaixaemails (nrseqctrl, ativo) values ('" & wcnrseqctrl & "',false)")
            tbemail = tabemail.conectar("select nrseq from tbcaixaemails where nrseqctrl = '" & wcnrseqctrl & "'")
            Nrseq = tbemail.Rows(0)("nrseq").ToString
        End If
    End Sub

    Property Corpo As String
        Get
            Return _corpo
        End Get
        Set(value As String)
            _corpo = tratatexto(value, True)
        End Set
    End Property

    Public Property Assunto As String
        Get
            Return _assunto
        End Get
        Set(value As String)
            _assunto = tratatexto(value)
        End Set
    End Property

    Public Property Remetente As String
        Get
            Return _remetente
        End Get
        Set(value As String)
            _remetente = value
            _nrseqremetente = 0
            If _remetente.Contains("@") Then
                tbemail = tabemail.conectar("select * from tbusuarios where email = '" & _remetente & "'")
            Else
                tbemail = tabemail.conectar("select * from tbusuarios where usuario = '" & _remetente & "'")

            End If
            If tbemail.Rows.Count <> 0 Then
                _nrseqremetente = tbemail.Rows(0)("nrseq").ToString
            End If
        End Set
    End Property

    Public Property Nrseqremetente As Integer
        Get
            Return _nrseqremetente
        End Get
        Set(value As Integer)
            _nrseqremetente = value
            _remetente = ""


            tbemail = tabemail.conectar("select * from tbusuarios where nrseq = " & _nrseqremetente)

            If tbemail.Rows.Count <> 0 Then
                _remetente = tbemail.Rows(0)("usuario").ToString
            End If
        End Set
    End Property

    Public Property Urgente As Boolean
        Get
            Return _urgente
        End Get
        Set(value As Boolean)
            _urgente = value
        End Set
    End Property

    Public Property Qtdanexos As Integer
        Get
            Return _qtdanexos
        End Get
        Set(value As Integer)
            _qtdanexos = value
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

    Public Property Origemdeemailenviado As Boolean
        Get
            Return _origemdeemailenviado
        End Get
        Set(value As Boolean)
            _origemdeemailenviado = value
        End Set
    End Property

    Public Property Tbanexos As DataTable
        Get
            Return _tbanexos
        End Get
        Set(value As DataTable)
            _tbanexos = value
        End Set
    End Property

    Public Property Mensagemerro As String
        Get
            Return _Mensagemerro
        End Get
        Set(value As String)
            _Mensagemerro = value
        End Set
    End Property

    Public Sub apagar(Optional nrmensagem As Integer = 0)
        If nrmensagem = 0 Then
            nrmensagem = _nrseq
        End If
        Dim tb1 As New Data.DataTable
        Dim tab1 As New clabancopsql
        tb1 = tab1.IncluirAlterarDados("update tbcaixaemails_destinatarios set excluida = true, dtexcluida = '" & hoje() & "'  where nrseq = " & nrmensagem)
    End Sub
    Public Function abrir(marcarlida As Boolean, Optional nrmensagem As Integer = 0) As Boolean
        If nrmensagem = 0 Then
            nrmensagem = _nrseq
        End If
        Dim tb1 As New Data.DataTable
        Dim tab1 As New clabancopsql
        tb1 = tab1.conectar("select * from vwcaixaemails  where nrseqdest = " & nrmensagem)
        If tb1.Rows.Count = 0 Then
            Return False
        End If
        With tb1

            _assunto = .Rows(0)("assunto").ToString
            _corpo = .Rows(0)("corpo").ToString
            _nrseqremetente = .Rows(0)("nrseqremetente").ToString
            _remetente = .Rows(0)("nomeremetente").ToString
            _urgente = logico(.Rows(0)("urgente").ToString)
        End With
        If marcarlida Then
            tb1 = tab1.IncluirAlterarDados("update tbcaixaemails_destinatarios set lida = true, dtlida = '" & hoje() & "'  where nrseq = " & nrmensagem)
        End If
        _tbanexos = tab1.conectar("select * from vwcaixaemails_anexos where nrseqdest = " & nrmensagem & " order by arquivo")
        Return True
    End Function
    Public Function novamensagem() As Integer
        Dim tb1 As New Data.DataTable
        Dim tab1 As New clabancopsql
        tb1 = tab1.conectar("select count(*) as total from vwcaixaemails where nrseqdestinatario = " & _nrseqremetente & " and excluida = false and lida = false order by  nrseq desc")
        If tb1.Rows.Count = 0 Then
            Return 0
        Else
            Return tb1.Rows(0)("total").ToString
        End If
    End Function
    Public Function enviar() As Boolean
        Try

            If destinatarios.Count = 0 Then
                Return False
            End If
            Dim tememail As Boolean = False
            For x As Integer = 0 To destinatarios.Count - 1

                If destinatarios(x).Nrsequsuario <> 0 Then
                    tbemail = tabemail.IncluirAlterarDados("insert into tbcaixaemails_destinatarios (nrsequsuario, lida, nrseqmensagem, excluida, rascunho, enviada) values (" & moeda(destinatarios(x).Nrsequsuario) & ",False," & _nrseq & ",False, False, True)")
                End If
                If destinatarios(x).Email <> "" Then
                    tememail = True
                End If
            Next
            For x As Integer = 0 To anexos.Count - 1
                If File.Exists(anexos(x).Caminho & "\" & anexos(x).Arquivo) Then
                    tbemail = tabemail.IncluirAlterarDados("insert into tbcaixaemails_anexos (arquivo, caminho, ativo, dtcad, usercad, nrseqmensagem) values ('" & anexos(x).Arquivo & "','" & anexos(x).Caminho.Replace("\", "\\") & "', true, '" & hoje() & "', '" & HttpContext.Current.Session("usuario") & "', " & _nrseq & ")")
                End If
            Next
            tbemail = tabemail.IncluirAlterarDados("update tbcaixaemails set assunto = '" & (_assunto) & "', corpo = '" & _corpo & "', dtcad = '" & hoje() & "', usercad = '" & _remetente & "', nrseqremetente = " & _nrseqremetente & ", urgente = " & logico(_urgente) & ", ativo = true, anexo = " & IIf(anexos.Count = 0, "False", "True") & ", hrcad = '" & hora() & "' where nrseq = " & _nrseq)

            'envia por email
            If tememail AndAlso Not Origemdeemailenviado Then
                Dim novoemail As New clsEnvioEmail
                novoemail.EhHTML = True
                novoemail.configpadrao()

                Dim cabecalhomens As String = "<html><br> <Center> <img src=""http://www.smartcodesolucoes.com.br/imgemails/logo_cte_smartcode3.png"" > <br> <span color=red> Nova Mensagem </span> </center> <br> Ola! Você está recebendo uma nova mensagem no sistema Cte! <br> Segue abaixo a mensagem, que também está disponível no seu sistema "

                Dim rodapemens As String = "<html><br> <Center> <img src=""http://www.smartcodesolucoes.com.br/imgemails/smartcode.png"" > SmartCode Soluções em Softwares</Center> <br>"
                novoemail.AdicionaMensagem = cabecalhomens & "<br><hr><br>" & _corpo & "<br><hr><br>" & rodapemens
                For x As Integer = 0 To destinatarios.Count - 1
                    If Not destinatarios(x).Email Is Nothing AndAlso destinatarios(x).Email.Contains("@") Then
                        If destinatarios(x).Oculto Then
                            novoemail.AdicionaDestinatariosocultos = destinatarios(x).Email
                        Else
                            novoemail.AdicionaDestinatarios = destinatarios(x).Email
                        End If

                    End If
                Next
                For x As Integer = 0 To anexos.Count - 1
                    If File.Exists(anexos(x).Caminho & anexos(x).Arquivo) Then
                        novoemail.AdicionaAnexos = anexos(x).Caminho & anexos(x).Arquivo
                    End If
                Next
                novoemail.AdicionaAssunto = _assunto
                novoemail.ConfigPorta = 587

                Dim result As Boolean = novoemail.EnviarEmail()
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class
