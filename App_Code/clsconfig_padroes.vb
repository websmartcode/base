Imports Microsoft.VisualBasic
Imports clssessoes
Imports clsSmart

Imports System.IO
Imports SelectPdf
Imports iTextSharp.text.pdf

Public Class clsconfig_padroes

#Region "emailspadroes"
    Dim _remetente As String
    Dim _destinatarios As New List(Of String)
    Dim _anexos As New List(Of String)
    Dim _assuntoemail As String
    Dim _ocultos As New List(Of String)
    Dim _textoemail As String
    Dim _textotratado As String
#End Region

    Dim _nomearquivogerado As String = ""

    Dim _nomearquivogeradoPDF As String = ""
    Dim _paramentrossql As New Dictionary(Of String, String)
    Dim _paramentrosmontagem As New Dictionary(Of String, String)
    Dim _listaclasse As New List(Of clsconfig_padroes)
    Dim _listatags As New List(Of clsconfig_padroes_tags)
    Dim _dicionariodestinatarios As New List(Of clscaixamensagens_destinatarios)
    Dim tbx As New Data.DataTable
    Dim tabx As New clabancopsql
    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _dtexclui As Date
    Dim _userexlui As String
    Dim _tipodeemail As String
    Dim _nrseqconfig As Integer
    Dim _corpo As String
    Dim _vinculo As String
    Dim _filtro_nome As String = ""
    Dim _salvarem As String
    Dim _assunto As String = ""
    Dim _padraoemail As String = ""
    Dim _nrseq As Integer = 0
    Dim _texto As String = ""
    Dim _nome As String = ""
    Dim _ativo As Boolean = False
    Dim _dtcad As Date
    Dim _usercad As String = ""
    Dim _arquivo As String = ""
    Dim _novoagente As Boolean = False
    Dim _mensagemerro As String = ""
    Dim _filtro_nrseqconfig As Integer = 0
    Dim _nrseqcotacao As Integer = 0
    Dim _filtro_pais As String = ""

    Dim _filtro_vinculo As String = ""
    Dim _textohtml As String
    Dim _nrseqcarga As Integer = 0
    Dim _horatemp As String = ""
    Dim _datatemp As String = ""

    Public Sub New()
        _usercad = buscarsessoes("usuario")
        _dtcad = data()
    End Sub

    Public Property Nrseq As Integer
        Get
            Return _nrseq
        End Get
        Set(value As Integer)
            _nrseq = value
        End Set
    End Property

    Public Property Texto As String
        Get
            Return _texto
        End Get
        Set(value As String)
            _texto = value
            'tratatextoemail()
        End Set
    End Property

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(value As String)
            _nome = tratatexto(value)
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

    Public Property Arquivo As String
        Get
            Return _arquivo
        End Get
        Set(value As String)
            _arquivo = value
        End Set
    End Property

    Public Property Novoagente As Boolean
        Get
            Return _novoagente
        End Get
        Set(value As Boolean)
            _novoagente = value
        End Set
    End Property

    Public Property Mensagemerro As String
        Get
            Return _mensagemerro
        End Get
        Set(value As String)
            _mensagemerro = value
        End Set
    End Property

    Public Property Salvarem As String
        Get
            Return _salvarem
        End Get
        Set(value As String)
            _salvarem = value
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
            _remetente = tratatexto(value)
        End Set
    End Property
    Public Property Assuntoemail As String
        Get
            Return _assuntoemail
        End Get
        Set(value As String)
            _assuntoemail = tratatexto(value)
        End Set
    End Property

    Public Property Ocultos As List(Of String)
        Get
            Return _ocultos
        End Get
        Set(value As List(Of String))
            _ocultos = (value)
        End Set
    End Property

    Public Property Textoemail As String
        Get
            Return _textoemail
        End Get
        Set(value As String)
            _textoemail = tratatexto(value)
        End Set
    End Property

    Public Property Padraoemail As String
        Get
            Return _padraoemail
        End Get
        Set(value As String)
            _padraoemail = tratatexto(value, 145)
        End Set
    End Property

    Public Property Textotratado As String
        Get
            Return _textotratado
        End Get
        Set(value As String)
            _textotratado = value
        End Set
    End Property

    Public Property Destinatarios As List(Of String)
        Get
            Return _destinatarios
        End Get
        Set(value As List(Of String))
            _destinatarios = value
        End Set
    End Property

    Public Property Anexos As List(Of String)
        Get
            Return _anexos
        End Get
        Set(value As List(Of String))
            _anexos = value
        End Set
    End Property

    Public Property Listaclasse As List(Of clsconfig_padroes)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clsconfig_padroes))
            _listaclasse = value
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

    Public Property Userexlui As String
        Get
            Return _userexlui
        End Get
        Set(value As String)
            _userexlui = value
        End Set
    End Property

    Public Property Tipodeemail As String
        Get
            Return _tipodeemail
        End Get
        Set(value As String)
            _tipodeemail = value
        End Set
    End Property

    Public Property Nrseqconfig As Integer
        Get
            Return _nrseqconfig
        End Get
        Set(value As Integer)
            _nrseqconfig = value
        End Set
    End Property

    Public Property Corpo As String
        Get
            Return _corpo
        End Get
        Set(value As String)
            _corpo = value
        End Set
    End Property

    Public Property Filtro_nome As String
        Get
            Return _filtro_nome
        End Get
        Set(value As String)
            _filtro_nome = value
        End Set
    End Property

    Public Property Nrseqcotacao As Integer
        Get
            Return _nrseqcotacao
        End Get
        Set(value As Integer)
            _nrseqcotacao = value
        End Set
    End Property

    Public Property Dicionariodestinatarios As List(Of clscaixamensagens_destinatarios)
        Get
            Return _dicionariodestinatarios
        End Get
        Set(value As List(Of clscaixamensagens_destinatarios))
            _dicionariodestinatarios = value
        End Set
    End Property

    Public Property Filtro_pais As String
        Get
            Return _filtro_pais
        End Get
        Set(value As String)
            _filtro_pais = value
        End Set
    End Property

    Public Property Nomearquivogerado As String
        Get
            Return _nomearquivogerado
        End Get
        Set(value As String)
            _nomearquivogerado = value
        End Set
    End Property

    Public Property NomearquivogeradoPDF As String
        Get
            Return _nomearquivogeradoPDF
        End Get
        Set(value As String)
            _nomearquivogeradoPDF = value
        End Set
    End Property

    Public Property Paramentrossql As Dictionary(Of String, String)
        Get
            Return _paramentrossql
        End Get
        Set(value As Dictionary(Of String, String))
            _paramentrossql = value
        End Set
    End Property

    Public Property Paramentrosmontagem As Dictionary(Of String, String)
        Get
            Return _paramentrosmontagem
        End Get
        Set(value As Dictionary(Of String, String))
            _paramentrosmontagem = value
        End Set
    End Property

    Public Property Filtro_nrseqconfig As Integer
        Get
            Return _filtro_nrseqconfig
        End Get
        Set(value As Integer)
            _filtro_nrseqconfig = value
        End Set
    End Property

    Public Property Vinculo As String
        Get
            Return _vinculo
        End Get
        Set(value As String)
            _vinculo = value
        End Set
    End Property

    Public Property Textohtml As String
        Get
            Return _textohtml
        End Get
        Set(value As String)
            _textohtml = value
        End Set
    End Property

    Public Property Nrseqcarga As Integer
        Get
            Return _nrseqcarga
        End Get
        Set(value As Integer)
            _nrseqcarga = value
        End Set
    End Property

    Public Property Horatemp As String
        Get
            Return _horatemp
        End Get
        Set(value As String)
            _horatemp = value
        End Set
    End Property

    Public Property Datatemp As String
        Get
            Return _datatemp
        End Get
        Set(value As String)
            _datatemp = value
        End Set
    End Property

    Public Property Filtro_vinculo As String
        Get
            Return _filtro_vinculo
        End Get
        Set(value As String)
            _filtro_vinculo = value
        End Set
    End Property
End Class

Partial Public Class clsconfig_padroes
    Public Function salvarpadroes() As Boolean
        Try
            If _nome = "" Then
                _mensagemerro = "Enter a model name valid  !"
                Return False
            End If
            If _texto = "" Then
                _mensagemerro = "Enter a valid text !"
                Return False
            End If

            tb1 = tab1.conectar("select * from tbconfig_padroes where ativo = true and nome = '" & _nome & "'")
            If tb1.Rows.Count = 0 Then
                tb1 = tab1.IncluirAlterarDados("insert into tbconfig_padroes (nome, arquivo, ativo, dtcad, usercad, assunto, padraoemail, texto, vinculo) values ('" & _nome & "',' ', true, '" & hoje() & "','" & _usercad & "','" & _assunto & "', '" & _padraoemail & "','" & tratatexto(_texto) & "','" & Vinculo & "')")
            Else
                tb1 = tab1.IncluirAlterarDados("update tbconfig_padroes set assunto = '" & _assunto & "' , arquivo = '',   padraoemail = '" & _padraoemail & "', texto = '" & tratatexto(_texto) & "', vinculo = '" & Vinculo & "' where ativo = true and nome = '" & _nome & "'")
            End If

            Return True
        Catch ex As Exception
            Mensagemerro = ex.Message
            Return False
        End Try
    End Function

    Public Function tratatextoemail() As Boolean
        Try
            Dim xconfig As New clsconfig
            xconfig.carregar()

            carregar()
            _textoemail = _texto
            Dim xcargas As New clsagenda
            xcargas.Nrseq = _nrseqcarga

            If Not xcargas.procurar Then
                _mensagemerro = "Selecione uma carga válida !"
                Return False
            End If

            Dim textodadosagenda As String = "<center><table style=""border:none;text-align:center"">"
            textodadosagenda &= "<tr><th width=""25%"" >Data Agendamento</th><th width=""25%"">Hora Agendamento</th><th width=""25%"">Doca</th><th width=""25%"">Data/Hora Chegada do Veículo</th></tr>"
            textodadosagenda &= "<tr><td>" & xcargas.Data & "</td><td>" & xcargas.Hora & "</td><td>" & xcargas.Nomefornecedor & "</td><td>" & xcargas.Data & "  " & xcargas.Hora & "</td></tr>"
            textodadosagenda &= "</table></center>"

            Dim xbr As New Barcode128
            Dim wcnomebarras As String = HttpContext.Current.Server.MapPath("~") & "\social\barras\chave.jpg"
            wcnomebarras = alteranome(wcnomebarras)
            xbr.Code = xcargas.Nrseq

            xbr.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White).Save(wcnomebarras)
            Dim wcxlogo As String = "<img src=""" & HttpContext.Current.Request.Url.OriginalString.Replace(HttpContext.Current.Request.Path, "/social/" & HttpContext.Current.Session("logocliente")) & """ Width=""90px"" Height=""45px""><br>"
            Dim wcxlogos As String = "<center><table align=center style=""border:none""><tr><th width=""50%""><img src=""" & HttpContext.Current.Request.Url.OriginalString.Replace(HttpContext.Current.Request.Path, "/img/rihappylogo.png") & """ Width=""90px"" Height=""60px""></th><th width=""50%""><img src=""" & HttpContext.Current.Request.Url.OriginalString.Replace(HttpContext.Current.Request.Path, "/social/" & HttpContext.Current.Session("logocliente")) & """ Width=""90px"" Height=""45px""></th></tr></table></center><br>"
            Horatemp = Horatemp.Substring(0, Horatemp.Length - 1)
            _textoemail = _textoemail.Replace("{usuario}", xcargas.Usercad).Replace("{horaagenda}", Horatemp).Replace("{dataagenda}", IIf(Datatemp <> "", Datatemp, xcargas.Data)).Replace("{fornecedor}", xcargas.Nomefornecedor).Replace("{codigoagenda}", _nrseqcarga).Replace("{logo}", wcxlogo).Replace("{logosistema}", "<img src=""" & xconfig.Logosistema & """ Width=""27px"" Height=""27px"">").Replace("{codigobarras}", "<center><img style=""width: 2.8cm"" src=""" & HttpContext.Current.Request.Url.OriginalString.Replace(HttpContext.Current.Request.Path, "/social/barras/" & mARQUIVO(wcnomebarras)) & """  ></center>").Replace("{logos}", wcxlogos).Replace("{dadosagendamento}", textodadosagenda)


            _assuntoemail = _assunto.Replace("{usuario}", xcargas.Usercad).Replace("{horaagenda}", Horatemp).Replace("{dataagenda}", IIf(Datatemp <> "", Datatemp, xcargas.Data)).Replace("{fornecedor}", xcargas.Nomefornecedor).Replace("{codigoagenda}", _nrseqcarga).Replace("{logo}", wcxlogo).Replace("{logosistema}", "<img src=""" & xconfig.Logosistema & """ Width=""27px"" Height=""27px"">").Replace("{codigobarras}", "<center><img style=""width: 2.8cm"" src=""" & HttpContext.Current.Request.Url.OriginalString.Replace(HttpContext.Current.Request.Path, "/social/barras/" & mARQUIVO(wcnomebarras)) & """  ></center>").Replace("{logos}", wcxlogos).Replace("{dadosagendamento}", textodadosagenda)

            Return True
        Catch extrataemail As Exception
            Mensagemerro = extrataemail.Message
            Return False
        End Try
    End Function
    Public Function listatags() As List(Of clsconfig_padroes_tags)
        Dim lista As New List(Of clsconfig_padroes_tags)

        lista.Add(New clsconfig_padroes_tags With {.Tag = "{logo} - Logo"})
        lista.Add(New clsconfig_padroes_tags With {.Tag = "{username} - Usuário"})
        lista.Add(New clsconfig_padroes_tags With {.Tag = "{usuario} - Usuário"})
        lista.Add(New clsconfig_padroes_tags With {.Tag = "{password} - Senha"})
        lista.Add(New clsconfig_padroes_tags With {.Tag = "{senha} - Senha"})
        lista.Add(New clsconfig_padroes_tags With {.Tag = "{nrlote} - Número Lote"})
        lista.Add(New clsconfig_padroes_tags With {.Tag = "{resultado} - Resultado"})
        lista.Add(New clsconfig_padroes_tags With {.Tag = "{dataextenso} - Data por extenso"})
        lista.Add(New clsconfig_padroes_tags With {.Tag = "{tabela} - Tabela de valores aprovados"})
        lista.Add(New clsconfig_padroes_tags With {.Tag = "{cancelado} - Motivos de erros"})

        Return lista

    End Function
    'Public Function carregar(Optional xpropriousuario As String = "") As Boolean

    '    Try
    '        Listaconfig_padroes_usuarios.Clear()
    '        tb1 = tab1.conectar("select * from tbconfig_padroes where nome = '" & _nome & "' and ativo = true")

    '        If tb1.Rows.Count = 0 Then
    '            _texto = ""
    '            _arquivo = ""
    '            _nrseq = 0
    '            _assunto = ""
    '            _padraoemail = ""
    '        Else
    '            _texto = tb1.Rows(0)("corpo").ToString

    '            _assunto = tb1.Rows(0)("assuntoemail").ToString
    '            _padraoemail = tb1.Rows(0)("padraoemail").ToString
    '            '_arquivo = HttpContext.Current.Server.MapPath("~\modelosemails\") & tb1.Rows(0)("arquivo").ToString
    '            _nrseq = tb1.Rows(0)("nrseq").ToString
    '            If xpropriousuario = "" Then
    '                tbx = tabx.conectar("select * from vwconfig_padroes_usuarios_users where nrseqpadrao = " & _nrseq & " and pais = '" & Filtro_pais & "' and ativo = true and descricaopermissao <> 'Operational'")
    '                For x As Integer = 0 To tbx.Rows.Count - 1
    '                    Dim xexiste As Boolean = False
    '                    For y As Integer = 0 To Listaconfig_padroes_usuarios.Count - 1
    '                        If Listaconfig_padroes_usuarios(y).Usuario = tbx.Rows(x)("usuario").ToString Then
    '                            xexiste = True
    '                            Exit For
    '                        End If
    '                    Next
    '                    If xexiste Then
    '                        Continue For
    '                    End If
    '                    Listaconfig_padroes_usuarios.Add(New clsconfig_padroes_usuarios With {.Nrseq = numeros(tbx.Rows(x)("nrseq").ToString), .Nrseqpadrao = numeros(tbx.Rows(x)("nrseqpadrao").ToString), .Nrseqpermissao = numeros(tbx.Rows(x)("nrseqpermissao").ToString), .Ativo = logico(tbx.Rows(x)("ativo").ToString), .Dtcad = valordata(tbx.Rows(x)("dtcad").ToString), .Usercad = tbx.Rows(x)("usercad").ToString, .Dtexclui = valordata(tbx.Rows(x)("dtexclui").ToString), .Userexclui = tbx.Rows(x)("userexclui").ToString, .Nrseqctrl = tbx.Rows(x)("nrseqctrl").ToString, .Descricaopadrao = tbx.Rows(x)("Descricaopadrao").ToString, .Descricaopermissao = tbx.Rows(x)("Descricaopermissao").ToString, .Usuario = tbx.Rows(x)("usuario").ToString, .Email = tbx.Rows(x)("email").ToString})
    '                Next
    '            Else

    '            End If
    '        End If


    '        Return True

    '    Catch ex As Exception
    '        _mensagemerro = ex.Message
    '        Return False
    '    End Try

    'End Function

    Public Function carregar(Optional xemail As String = "") As Boolean
        Try
            tb1 = tab1.conectar("select * from tbconfig_padroes where nome = '" & _nome & "' and ativo = true")

            If tb1.Rows.Count = 0 Then
                _texto = ""
                _arquivo = ""
                _nrseq = 0
                _assunto = ""
                _padraoemail = ""
                _vinculo = ""
            Else
                _assunto = tb1.Rows(0)("assunto").ToString
                _texto = tb1.Rows(0)("texto").ToString
                Textohtml = tb1.Rows(0)("textohtml").ToString
                _padraoemail = tb1.Rows(0)("padraoemail").ToString
                _vinculo = tb1.Rows(0)("vinculo").ToString
                _arquivo = HttpContext.Current.Server.MapPath("~\modelosemails\") & tb1.Rows(0)("arquivo").ToString
                _nrseq = tb1.Rows(0)("nrseq").ToString
            End If

            Return True
        Catch ex As Exception
            Mensagemerro = ex.Message
            Return False
        End Try
    End Function

    Public Function apagar() As Boolean
        Try
            tb1 = tab1.conectar("select * from tbconfig_padroes where nome = '" & _nome & "' and ativo = true")

            If tb1.Rows.Count <> 0 Then
                tb1 = tab1.conectar("update tbconfig_padroes set ativo = false, dtexclui = '" & hoje() & "', userexclui = '" & _usercad & "' where nome = '" & _nome & "' and ativo = true")
            End If

            Return True
        Catch ex As Exception
            Mensagemerro = ex.Message
            Return False
        End Try
    End Function

    Public Function enviaremail() As Boolean
        Try
            If _nome = "" Then
                _mensagemerro = Resources.Resource.erroselectextpadraoemail
                Return False
            End If
            carregar()
            Dim xconfig As New clsconfig
            xconfig.carregar()
novoteste:
            Dim email As New clsEnvioEmail("usuario")

            If _padraoemail = "" Then
                email.ConfigPorta = 587
                email.ConfigSMTP = "smtp.smartcodesolucoes.com.br"
                email.Credenciais("alertas@smartcodesolucoes.com.br", "Sousmart@747791", "smtp.smartcodesolucoes.com.br")
                email.AdicionaRemetente = "alertas@smartcodesolucoes.com.br"
            Else
                Dim xpadraoemail As New clscontasemails
                xpadraoemail.Usuario = _padraoemail
                If Not xpadraoemail.carregar Then
                    _padraoemail = ""
                    GoTo novoteste
                End If

                email.ConfigPorta = xpadraoemail.Porta
                email.ConfigSMTP = xpadraoemail.Servidor
                email.Credenciais(xpadraoemail.Usuario, xpadraoemail.Senha, xpadraoemail.Servidor)
                email.AdicionaRemetente = xpadraoemail.Usuario
            End If

            email.EhHTML = True

            For x As Integer = 0 To Anexos.Count - 1
                email.AdicionaAnexos = Anexos(x)
            Next
            For x As Integer = 0 To Destinatarios.Count - 1
                email.AdicionaDestinatarios = Destinatarios(x)
            Next
            For x As Integer = 0 To Ocultos.Count - 1
                email.AdicionaDestinatariosocultos = Ocultos(x)
            Next

            email.AdicionaAssunto = _assuntoemail
            Dim xmensagem As String = _textoemail.Replace("{logo}", "<img src=""" & xconfig.Logoweb & """ Width=""60px"" Height=""60px""><br>").Replace("{logosistema}", "<img src=""" & xconfig.Logosistema & """ Width=""27px"" Height=""27px"">")

            Dim xcargas As New clsagenda
            xcargas.Nrseq = Nrseqcarga

            If Not xcargas.procurar Then
                _mensagemerro = "Selecione uma carga válida !"
                Return False
            End If

            xmensagem = xmensagem.Replace("{usuario}", xcargas.Usercad).Replace("{horaagenda}", xcargas.Hora).Replace("{dataagenda}", xcargas.Data).Replace("{fornecedor}", xcargas.Nomefornecedor)

            email.AdicionaMensagem = xmensagem
            If email.EnviarEmail() Then
                _mensagemerro = "E-mail Enviado !"
                Return True
            Else
                _mensagemerro = email.mensagemerro
                Return False
            End If

            Return True
        Catch exenvio As Exception
            _mensagemerro = exenvio.Message
            Return False
        End Try
    End Function

    Public Function Listarconfig_padroes() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "select * from tbconfig_padroes where ativo = true"
            If Filtro_nome <> "" Then
                xsql &= " and nome like '%" & Filtro_nome & "%'"
            End If
            If Filtro_vinculo <> "" Then
                xsql &= " and vinculo like '%" & Filtro_vinculo & "%'"
            End If
            xsql &= " order by nome"
            tb1 = tab1.conectar(xsql)

            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clsconfig_padroes With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Texto = tb1.Rows(x)("texto").ToString, .Nome = tb1.Rows(x)("nome").ToString, .Ativo = logico(tb1.Rows(x)("ativo").ToString), .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Usercad = tb1.Rows(x)("usercad").ToString, .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Userexlui = tb1.Rows(x)("userexclui").ToString, .Arquivo = tb1.Rows(x)("arquivo").ToString, .Assunto = tb1.Rows(x)("assunto").ToString, .Padraoemail = tb1.Rows(x)("padraoemail").ToString, .Nrseqconfig = numeros(tb1.Rows(x)("nrseqconfig").ToString), .Corpo = tb1.Rows(x)("texto").ToString, .Vinculo = tb1.Rows(x)("vinculo").ToString})
            Next
            Return True
        Catch excons As Exception
            _mensagemerro = excons.Message
            Return False
        End Try
    End Function
    Public Function gerarHTMLdocumento(xtipodocumento As String, xnomedocumento As String) As Boolean
        Try
            tb1 = tab1.conectar("select * from tbconfig_padroes where ativo = true and vinculo = '" & xnomedocumento & "'")
            If tb1.Rows.Count = 0 Then
                _mensagemerro = "O documento não foi encontrado!"
                Return False
            End If
            If Not tratardocumento(tb1.Rows(0)("texto").ToString, xnomedocumento) Then
                Return False
            End If

            Dim xnomedoc As String = HttpContext.Current.Server.MapPath("~") & "arquivos\documentos\docgerado.html"
            xnomedoc = alteranome(xnomedoc)

            Dim xgravar As New StreamWriter(xnomedoc)
            xgravar.Write("<html>")
            xgravar.Write("<head>")
            xgravar.Write("<meta charset=""UTF-8"">")
            xgravar.Write("<style>")
            xgravar.Write(".vertical {")
            xgravar.Write("writing-mode: vertical-rl;}")
            xgravar.Write("</style>")
            xgravar.Write("<style>")
            xgravar.Write("body {")
            xgravar.Write("font-family: Arial, Helvetica, sans - serif;")
            xgravar.Write("}")
            xgravar.Write(".badge {")
            xgravar.Write("background - color: red;")
            xgravar.Write("color:    white;")
            xgravar.Write("padding: 4px 8px;")
            xgravar.Write("Text-align: center;")
            xgravar.Write("border-radius:  5px;")
            xgravar.Write("}")
            xgravar.Write("</style>")
            xgravar.Write("</head>")
            xgravar.Write(_texto)
            xgravar.Write("</html>")
            xgravar.Close()

            Nomearquivogerado = xnomedoc

            Return True
        Catch ex As Exception
            _mensagemerro = ex.Message
            Return False
        End Try
    End Function
    Private Function tratardocumento(xtexto As String, xtipodocumento As String) As Boolean
        Try
            Dim xsql2 As String = ""
            Dim tbdados As New Data.DataTable
            Dim tabdados As New clabancopsql
            Dim xclasse As New clsmodeloscontratos_conteudo
            xclasse.aplicar()

            Dim listaffiltrada As List(Of clsmodeloscontratos_conteudo) = xclasse.Listaclasse.FindAll(Function(p As clsmodeloscontratos_conteudo) (p.Vinculo = xtipodocumento))

            If listaffiltrada.Count = 0 Then
                _mensagemerro = "Não existem origens de dados válidos para o tipo de documento " & xtipodocumento
                Return False
            End If

            Select Case listaffiltrada(0).Tabela.ToLower
                Case Is = "vwusuarios"
                    xsql2 = "select * from vwusuarios where ativo = true"
                    For y As Integer = 0 To Paramentrossql.Keys.Count - 1
                        xsql2 &= " and " & Paramentrossql.Keys(y).Replace("@", "") & " = " & Paramentrossql.Values(0) & ""
                    Next

                    If Paramentrosmontagem.Keys.Count > 0 Then
                        Dim xtemp As String = ""
                        For y As Integer = 0 To Paramentrosmontagem.Keys.Count - 1
                            xtemp &= Paramentrosmontagem.Values(y) & ","
                        Next

                        xsql2 &= " order by " & xtemp.Substring(0, xtemp.Length - 1)
                    Else
                        xsql2 &= " order by usuario"
                    End If

                    tbdados = tabdados.conectar(xsql2)
                    If tbdados.Rows.Count = 0 Then
                        _mensagemerro = "O usuário não foi localizado "
                        Return False
                    End If
            End Select

            For x As Integer = 0 To listaffiltrada(0).Listaclasse.Count - 1
                If listaffiltrada(0).Listaclasse(x).Valor.Contains("[") Then
                    Dim xtextotemp As String = ""
                    xtextotemp &= "<table width=""100%"">"

                    If listaffiltrada(0).Listaclasse(x).Valor = "[caixaresumido]" Then
                        xtextotemp &= "<tr>"
                        xtextotemp &= "<th>"
                        xtextotemp &= "<b>It </b></th>"
                        xtextotemp &= "<th>"
                        xtextotemp &= "<b>Plano </b></th>"
                        xtextotemp &= "<th>"
                        xtextotemp &= "<b>Qtd de Entradas</b></th>"
                        xtextotemp &= "<th>"
                        xtextotemp &= "<b>Total de Créditos</b></th>"
                        xtextotemp &= "<th>"
                        xtextotemp &= "<b>Total de Débitos</b></th>"
                        xtextotemp &= "</tr>"

                        Dim wctotalcredito As Decimal = 0
                        Dim wctotaldebito As Decimal = 0
                        Dim wctotal As Integer = 0
                        For o As Integer = 0 To tbdados.Rows.Count - 1
                            If o Mod 2 = 0 Then
                                xtextotemp &= "<tr>"
                            Else
                                xtextotemp &= "<tr style=""background-color:#E5ECE3 "">"
                            End If

                            xtextotemp &= "<td>"
                            xtextotemp &= "<b>" & x + 1 & " </b></td>"
                            xtextotemp &= "<td>"
                            xtextotemp &= tbdados.Rows(o)("descricaoplano").ToString & "</td>"
                            xtextotemp &= "<td>"
                            xtextotemp &= tbdados.Rows(o)("qtdlancamentos").ToString & "</td>"
                            xtextotemp &= "<td><span style=""color:green"">"
                            xtextotemp &= FormatCurrency(tbdados.Rows(o)("totalcredito").ToString) & "</span></td>"
                            xtextotemp &= "<td><span style=""color:red"">"
                            xtextotemp &= FormatCurrency(tbdados.Rows(o)("totaldebito").ToString) & "</span></td>"
                            xtextotemp &= "</tr>"
                            wctotal += numeros(tbdados.Rows(o)("qtdlancamentos").ToString)
                            wctotalcredito += numeros(tbdados.Rows(o)("totalcredito").ToString)
                            wctotaldebito += numeros(tbdados.Rows(o)("totaldebito").ToString)
                        Next

                        xtextotemp &= "<tr style=""background-color:#BEC5BB "">"
                        xtextotemp &= "<td>"
                        xtextotemp &= "<b> Total </b></td>"
                        xtextotemp &= "<td>"
                        xtextotemp &= "</td>"
                        xtextotemp &= "<td><b>"
                        xtextotemp &= wctotal & "</b></td>"
                        xtextotemp &= "<td><span style=""color:green""><b>"
                        xtextotemp &= FormatCurrency(wctotalcredito) & "</b></span></td>"
                        xtextotemp &= "<td><span style=""color:red""><b>"
                        xtextotemp &= FormatCurrency(wctotaldebito) & "</b></span></td>"
                        xtextotemp &= "</tr>"
                        xtextotemp &= "</table>"
                        xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, xtextotemp)
                    End If
                    Continue For
                End If

                If listaffiltrada(0).Listaclasse(x).Valor.Contains("{") Then
                    Select Case listaffiltrada(0).Listaclasse(x).Valor

                        Case Is = "{cpf}"
                            xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, tbdados.Rows(0)("cpf").ToString)
                        Case Is = "{fone}"
                            'xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, tbdados.Rows(0)("fone").ToString)
                        Case Is = "{hoje}"
                            xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, FormatDateTime(data(), DateFormat.ShortDate))
                        Case Is = "{dia}"
                            xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, data().Day)
                        Case Is = "{mes}"
                            xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, MesExtenso(data().Month))
                        Case Is = "{ano}"
                            xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, data().Year)
                        Case Is = "{empresa}"
                            xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, HttpContext.Current.Session("nomecliente"))
                        Case Is = "{usuario}"
                            xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, HttpContext.Current.Session("usuario"))
                        Case Is = "{logo}"
                            Dim xhtml As String = "<img src='" & "../../social/" & HttpContext.Current.Session("logocliente") & "' style=""width:96px;height:96px""/>"
                            xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, xhtml)
                        Case Is = "{listaalunos}"
                            Dim xhtml As String = " "

                            For y As Integer = 0 To tbdados.Rows.Count - 1
                                xhtml &= zeros(y + 1, 2) & " - " & tbdados.Rows(y)("nome").ToString & "<br>"
                            Next

                            xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, xhtml)
                    End Select
                Else
                    If listaffiltrada(0).Listaclasse(x).Valor.ToString.Contains("|") Then
                        Dim xcampo As String = listaffiltrada(0).Listaclasse(x).Valor.ToString.Split("|")(1)
                        xcampo = tbdados.Rows(0)(xcampo).ToString

                        Select Case listaffiltrada(0).Listaclasse(x).Valor.ToString.Split("|")(0).ToLower
                            Case Is = "decrypt"
                                xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, AES_Decrypt(xcampo, "CodeSmart@9898"))
                            Case Is = "encrypt"
                                xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, AES_Encrypt(xcampo, "CodeSmart@9898"))
                            Case Is = "data"
                                xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, FormatDateTime(valordata(xcampo), DateFormat.ShortDate).ToString)
                            Case Is = "numero"
                                xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, numeros(xcampo).ToString)
                            Case Is = "moeda"
                                xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, FormatCurrency(numeros(xcampo)).ToString)
                            Case Is = "maiusculo"
                                xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, (xcampo.ToString.ToUpper).ToString)
                            Case Is = "primeiraletra"
                                xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, primeiraletra(xcampo).ToString)
                        End Select
                    Else
                        xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, tbdados.Rows(0)(listaffiltrada(0).Listaclasse(x).Valor).ToString)
                    End If

                End If
            Next
            Texto = xtexto

            Return True
        Catch ex As Exception
            _mensagemerro = ex.Message
            Return False
        End Try
    End Function
    Public Function converterHTMLDocPDF(xarquivo As String) As Boolean
        Try
            Dim raiz As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath
            Dim r As String = ""
            Dim salvarEm As String = HttpContext.Current.Server.MapPath("~/")
            Dim arquivo As String = "documento" & ".pdf"
            salvarEm &= "arquivos\documentos\" & arquivo
            salvarEm = alteranome(salvarEm)
            Dim FullPath = raiz & "/arquivos/documentos/" & (xarquivo)
            Dim converter As New HtmlToPdf()
            converter.Header.DisplayOnOddPages = True
            converter.Header.DisplayOnEvenPages = True
            converter.Header.Height = 20
            Dim doc1 As SelectPdf.PdfDocument = converter.ConvertHtmlString(FullPath)

            converter.Options.DisplayFooter = True
            converter.Footer.DisplayOnFirstPage = True
            converter.Footer.DisplayOnOddPages = True
            converter.Footer.DisplayOnEvenPages = True
            converter.Footer.Height = 50
            converter.Footer.TotalPagesOffset += doc1.Pages.Count - 1
            converter.Footer.FirstPageNumber += doc1.Pages.Count - 1

            Dim text As New PdfTextSection(0, 10, "Página: {page_number} de {total_pages}  ", New System.Drawing.Font("Arial", 8))
            text.HorizontalAlign = PdfTextHorizontalAlign.Right
            converter.Footer.Add(text)

            Dim doc As SelectPdf.PdfDocument = converter.ConvertUrl(FullPath)
            Dim pdf As Byte() = doc.Save()
            doc.Close()

            File.WriteAllBytes(salvarEm, pdf)

            NomearquivogeradoPDF = salvarEm
            Return True
        Catch ex As Exception
            _mensagemerro = ex.Message
            Return False
        End Try
    End Function

    Public Function converterHTMLDocPDF(xarquivo As String, xpasta As String) As Boolean
        Try
            Dim raiz As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath
            Dim r As String = ""
            Dim salvarEm As String = HttpContext.Current.Server.MapPath("~/")
            Dim arquivo As String = "documento" & ".pdf"

            salvarEm &= xpasta & arquivo
            salvarEm = alteranome(salvarEm)

            Dim FullPath = raiz & "/arquivos/documentos/" & xarquivo
            Dim converter As New HtmlToPdf()
            Dim doc As SelectPdf.PdfDocument = converter.ConvertUrl(FullPath)
            Dim pdf As Byte() = doc.Save()
            doc.Close()

            File.WriteAllBytes(salvarEm, pdf)
            NomearquivogeradoPDF = salvarEm
            Return True
        Catch ex As Exception
            _mensagemerro = ex.Message
            Return False
        End Try
    End Function
End Class