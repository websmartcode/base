Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Xml
Imports System.IO
Imports System.IO.Directory
Imports System.Collections.Generic
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports ExceptionHelper
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Data.Services
Imports System.Net
Imports System.Net.Http
Imports Newtonsoft.Json.Linq
Imports Org.BouncyCastle.Asn1.Ocsp
Imports System.Threading.Tasks

Public Class clsSmart

    Public Shared wctermoqtdcaracterlinha As Integer = 160
    Public Shared wcusuario As String = ""
    Public Shared wcgrupo As String = ""
    Public Shared wcempresa As String = ""
    Public Shared wcemailsolicitante As String = ""
    Public Shared wcplano As String = ""
    Private Shared meubanco As New clabancopsql
    Public Shared minhaversao As String = "3.00 (release " & sonumeros(meubanco.servidor) & ")"
    Public Shared meucliente As String = "Cerqueira"
    Public Shared meuproduto As String = "Colegio"
    Public Shared vwBoletosClientes As String = "Select tbemissaoboletos_map.*,tbclientes_map.nrseq as codigocliente, tbclientes_map.nrseq as codauxcliente, tbclientes_map.matricula as matriculacliente , tbclientes_map.nome as nomecliente,  tbclientes_map.logradouro as endereco, tbclientes_map.numero, tbclientes_map.cidade, tbclientes_map.uf, tbclientes_map.cep, tbclientes_map.bairro, tbclientes_map.cpf as documento, tbclientes_map.complemento,   tbconfig_boletos.banco as configbanco, tbconfig_boletos.carteira as configcarteira, tbclientes_map.nrseq as codigosubst,  tbconfig_boletos.dllsmart, tbconfig_boletos.bancosmart , tbconfig_boletos.carteirasmart,  tbclientes_map.email from tbemissaoboletos_map inner join  tbconfig_boletos on tbemissaoboletos_map.banco = tbconfig_boletos.banco and tbemissaoboletos_map.carteira = tbconfig_boletos.carteira inner join tbclientes_map on tbclientes_map.matricula = tbemissaoboletos_map.matricula where  1=1"

    Public Shared Function gerarserialprocedimento(ByVal wcnrseq As Integer) As String

        Dim wchoraatual As Integer = Date.Now.TimeOfDay.Seconds + Date.Now.Hour + Date.Now.Minute
        Dim serial1 As Integer = Date.Now.Year + Date.Now.Day + Date.Now.Month + Date.Now.DayOfWeek + Date.Now.DayOfYear + wchoraatual
        Dim serial2 As Integer = wchoraatual + (5000 * wcnrseq)
        Dim serial3 As String = zeros(wcnrseq.ToString & serial1.ToString & serial2.ToString, 20)

        Return serial3
    End Function
    Public Shared Function sonumeros(ByVal valor As String) As String
        Dim wcnumero As String, x As Integer
        wcnumero = ""
        For x = 1 To Len(valor)
            If IsNumeric(Mid(valor, x, 1)) Then
                wcnumero = wcnumero & Mid(valor, x, 1)
            End If
        Next
        Return (wcnumero)
    End Function
    Public Shared Function criarpastas(caminho As String) As String
        Try


            Dim pastatemp As String = ""
            caminho &= "\"


            For x As Integer = 0 To caminho.Length - 1
                If caminho.Substring(x, 1) = "\" And pastatemp <> "" Then
                    If Not Directory.Exists(pastatemp) Then
                        Try
                            Directory.CreateDirectory(pastatemp)
                        Catch ex2 As Exception

                        End Try

                    End If
                End If
                pastatemp &= caminho.Substring(x, 1)

            Next
            Return "Concluído"

        Catch ex As Exception
            Return "erro " & ex.Message
        End Try


    End Function
    Public Shared Function MesExtenso(ByVal mes As Integer) As String
        Select Case mes
            Case Is = 1
                Return "Janeiro"
            Case Is = 2
                Return "Fevereiro"
            Case Is = 3
                Return "Março"
            Case Is = 4
                Return "Abril"
            Case Is = 5
                Return "Maio"
            Case Is = 6
                Return "Junho"
            Case Is = 7
                Return "Julho"
            Case Is = 8
                Return "Agosto"
            Case Is = 9
                Return "Setembro"
            Case Is = 10
                Return "Outubro"
            Case Is = 11
                Return "Novembro"
            Case Is = 12
                Return "Dezembro"
        End Select
    End Function
    Public Shared Function DiaSemana(ByVal dia As Integer) As String
        Select Case dia
            Case Is = 0
                DiaSemana = "Domingo"
            Case Is = 1
                DiaSemana = "Segunda"
            Case Is = 2
                DiaSemana = "Terça"
            Case Is = 3
                DiaSemana = "Quarta"
            Case Is = 4
                DiaSemana = "Quinta"
            Case Is = 5
                DiaSemana = "Sexta"
            Case Is = 6
                DiaSemana = "Sábado"
        End Select

        Return DiaSemana

    End Function
    Public Shared Function tratatexto(ByVal texto As String, Optional comaspas As Boolean = True) As String
        Try
            If comaspas Then
                Return texto.Replace("'", "''")
            Else
                Return texto.Replace("'", "")
            End If
        Catch ex As Exception
            Return ""
        End Try



    End Function
    Public Shared Function hoje() As String
        Return formatadatamysql(data())
    End Function
    Public Shared Function logico(valor As String) As String

        If valor = "1" OrElse valor.ToLower = "true" OrElse valor.ToLower = "yes" OrElse valor.ToLower = "sim" Then
            Return "True"
        Else
            Return "False"
        End If
    End Function
    Public Shared Function validaemail(email As String) As Boolean
        If email.Contains("@") AndAlso email.Contains(".") Then
            Return True
        End If
        Return False
    End Function
    Public Shared Function validadata(ByVal Texto As String) As Boolean
        Dim Dia As String
        Dim Mes As String
        Dim Ano As String
        Texto = Replace(Texto, "/", "")
        Dia = Left(Texto, 2)
        Mes = Mid(Texto, 3, 2)
        Ano = Right(Texto, 4)
        Try
            Dim data As String = CDate(Mes & "/" & Dia & "/" & Ano)
            If IsDate(data) = True Then
                validadata = True
            Else
                validadata = False
            End If
        Catch ex As Exception
            validadata = False
        End Try
    End Function
    Public Shared Function tratatexto(ByVal expressao As String) As String
        If expressao = "" Then Return ""
        Return Replace(Replace(expressao, "'", "''"), ",", ",")
    End Function
    Public Shared Function lerxml2(doc1 As String) As Data.DataTable
        Try
            Dim documento As New XmlDocument
            documento.Load(doc1)

            Dim tbdados As New Data.DataTable
            tbdados.Columns.Clear()
            tbdados.Rows.Clear()
            If documento.ChildNodes.Count = 0 Then
                tbdados.Columns.Add("Erro")
                tbdados.Rows.Add()
                tbdados.Rows(0)("Erro") = ("Nenhum registro localizado !")
                Return tbdados
            End If
            For Y As Integer = 0 To documento.ChildNodes(0).ChildNodes(0).ChildNodes.Count - 1
                If tbdados.Columns.Contains(documento.ChildNodes(0).ChildNodes(0).ChildNodes(Y).Name) Then
                    Exit For
                End If

                tbdados.Columns.Add(documento.ChildNodes(0).ChildNodes(0).ChildNodes(Y).Name)
            Next
            'MsgBox(documento.ChildNodes(0).ChildNodes(0).ChildNodes.Count)
            '   MsgBox(tbdados.Columns.Count)
            For x As Integer = 0 To documento.ChildNodes(0).ChildNodes.Count - 1
                tbdados.Rows.Add()

                For Y As Integer = 0 To documento.ChildNodes(0).ChildNodes(0).ChildNodes.Count - 1
                    'Debug.Print(documento.ChildNodes(0).ChildNodes(0).ChildNodes(Y).Name)
                    'Debug.Print(documento.ChildNodes(0).ChildNodes(0).ChildNodes.Count)
                    'Debug.Print(documento.ChildNodes(0).ChildNodes(0).ChildNodes(Y).InnerText)
                    tbdados.Rows(x)(documento.ChildNodes(0).ChildNodes(0).ChildNodes(Y).Name) = documento.ChildNodes(0).ChildNodes(x).ChildNodes(Y).InnerText
                Next
            Next
            'Debug.Print(tbdados.Rows.Count)
            Return tbdados

        Catch ex2 As Exception
            Threading.Thread.Sleep(10)
        End Try
    End Function
    Public Shared Function tratanumeros(ByVal expressao As String) As String
        If expressao = "" Then
            expressao = 0
        End If
        expressao = Replace(expressao, ",", ".")
        Return expressao
    End Function
    Public Shared Function encontrachr(ByVal texto As String, ByVal caract As String, ByVal posicao As Integer) As String
        Dim y As Integer
        Dim posicoes As Integer
        Dim ultima As Integer
        Dim achou As Boolean
        Dim retorno As String
        posicoes = 1
        ultima = 0
        achou = False
        retorno = ""
        For y = 1 To Len(texto)

            If Mid(texto, y, 1) = caract Then
                If posicoes = posicao Then
                    retorno = Mid(texto, IIf(ultima = 0, 1, ultima), IIf(ultima = 0, y - ultima - 1, y - ultima))
                    achou = True
                    Exit For
                Else
                    achou = False
                End If
                posicoes = posicoes + 1
                ultima = y + 1
            End If
        Next
        If achou = False Then
            retorno = Mid(texto, IIf(ultima = 0, 1, ultima), IIf(ultima = 0, y - ultima - 1, y - ultima))
        End If
        Return retorno
    End Function
    Public Shared Function primeiraletra(ByVal palavra As String)
        If palavra.Length = 0 Then
            Return ""
            Exit Function
        End If
        Dim x As Integer
        Dim nova As String
        nova = ""
        nova = palavra.Substring(0, 1).ToUpper

        For x = 1 To palavra.Length - 1
            If palavra.Substring(x - 1, 1).ToUpper = " " Then
                nova = nova & palavra.Substring(x, 1).ToUpper
            Else
                nova = nova & palavra.Substring(x, 1).ToLower
            End If
        Next
        Return nova
    End Function
    Public Shared Function formatadatamysql(ByVal data As String, Optional ByVal inverter As Boolean = False) As String
        Dim novadata As Date
        '    Dim xlogdata As New clslogs("data", "data")
        '   xlogdata.Entrada = data

        If IsDate(data) = False Then
            novadata = CDate("01/01/1900")
        Else
            novadata = CDate(data)
        End If
        '  xlogdata.Entrada = novadata
        'If comhoras Then
        '    If Not inverter Then
        '        Return Format(novadata, "yyyy/MM/dd hh:mm:ss")
        '    Else
        '        Return Format(novadata, "dd/MM/yyyy")
        '    End If
        'Else
        '  xlogdata.Entrada = inverter
        If Not inverter Then
            '  xlogdata.Entrada = Format(novadata, "yyyy/MM/dd")
            '  xlogdata.finalizar()
            Return Format(novadata, "yyyy/MM/dd")
        Else
            ' xlogdata.Entrada = Format(novadata, "dd/MM/yyyy")
            ' xlogdata.finalizar()
            Return Format(novadata, "dd/MM/yyyy")
        End If
        ' End If


    End Function
    Public Shared Function moeda(ByVal valor As String, Optional ByVal tela As Boolean = False) As String
        Dim negativo As Boolean = False
        If valor = "" Then
            moeda = 0
            Exit Function
        End If
        If valor.Contains(".") Then
            Return valor.Replace("R$", "")
        End If
        'If valor.Contains("-") = True Then
        '    negativo = True
        'End If
        Dim novovalor As String = valor.Replace("R$", "").Replace(".", "")
        If tela = False Then
            Return novovalor.Replace(",", ".").Trim
        Else
            Return novovalor
        End If
    End Function
    Public Shared Function gerarsenhaautomatica(ByVal nome As String) As String
        Dim valor As String

        valor = Replace(Date.Now, ":", "")
        valor = Replace(valor, "/", "")
        valor = Replace(valor, " ", "")
        Dim novovalor As Integer

        ' novovalor = valor
        'For x As Integer = 0 To Len(valor) - 1
        '     novovalor = novovalor + Mid(valor, x + 1, 1)
        'Next

        gerarsenhaautomatica = Mid(nome, 1, 5) & novovalor

    End Function
    Public Shared Function zeros(ByVal expr As String, ByVal qtd As Integer) As String
        Dim dd As String
        Dim x As Integer
        dd = ""
        If qtd <= Len(expr) Then
            Return expr
            Exit Function
        End If
        For x = 1 To (qtd - Len(expr))
            dd = dd & "0"
        Next
        Return dd & expr

    End Function
    Public Shared Function sonumeros(ByVal valor As String, Optional pontos As Boolean = False) As String
        Dim wcnumero As String, x As Integer
        wcnumero = ""
        For x = 1 To Len(valor)
            If IsNumeric(Mid(valor, x, 1)) OrElse (pontos AndAlso (Mid(valor, x, 1) = "." OrElse Mid(valor, x, 1) = ",")) Then
                wcnumero = wcnumero & Mid(valor, x, 1)
            End If
        Next
        sonumeros = (wcnumero)
    End Function
    Public Shared Function gerarnrseqcontrole(Optional xnumero As String = "") As String
        Dim var As String = ""
        If xnumero = "" Then
            var = sonumeros(Date.Now.ToString) & sonumeros(hora(True)) & mRight(sonumeros(Microsoft.VisualBasic.VBMath.Rnd(3)), 5)
        Else
            var = sonumeros(xnumero) & sonumeros(Date.Now.ToString) & sonumeros(hora(True)) & mRight(sonumeros(Microsoft.VisualBasic.VBMath.Rnd(3)), 5)
        End If


        Return mRight(var, 40)
    End Function
    Public Shared Function mLeft(ByVal expressao As String, ByVal qtd As Integer) As String
        Return Microsoft.VisualBasic.Left(expressao, qtd)
    End Function
    Public Shared Function mRight(ByVal expressao As String, ByVal qtd As Integer) As String
        Return Microsoft.VisualBasic.Right(expressao, qtd)
    End Function
    Public Shared Function mARQUIVO(ByVal wcCAMINHO As String, Optional ByVal web As Boolean = False) As String
        Dim xx As Integer
        Dim simbolo As String = "\"
        If web Then
            simbolo = "/"
        End If
        For xx = 1 To Microsoft.VisualBasic.Len(wcCAMINHO)
            'Debug.Print(Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(wcCAMINHO, xx + 1), 1))
            If Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(wcCAMINHO, xx + 1), 1) = simbolo Then
                mARQUIVO = Microsoft.VisualBasic.Right(wcCAMINHO, xx)
                xx = Microsoft.VisualBasic.Len(wcCAMINHO)
                Exit For
            End If
        Next

    End Function
    Public Shared Function mPASTA(ByVal wcCAMINHO As String) As String
        If wcCAMINHO = "" Then Return ""
        Dim wctemp As String = ""
        Dim xx As Integer
        For xx = 1 To wcCAMINHO.Length
            If Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(wcCAMINHO, xx + 1), 1) = "\" Then
                wctemp = (Microsoft.VisualBasic.Right(wcCAMINHO, xx).Length)
                mPASTA = Microsoft.VisualBasic.Left(wcCAMINHO, (wcCAMINHO.Length) - wctemp)
                xx = (wcCAMINHO.Length)
            End If
        Next

    End Function
    Public Shared Function validarusuario(ByVal sessao As String, grupo As String, pagina As String, funcao As String) As String
        'sessao = verificar se esta logado 
        'pagina informa a pagina que o usuario esta tentando acessar
        'função o que ele esta tendnado fazer na pagina (criar,editar,deletar)
        'Return "Ok"
        If sessao = Nothing Then


            Return "login"
        Else
            '   Return "Autenticacao"
        End If
        Dim tb1 As New Data.DataTable
        Dim tab1 As New clabancopsql


        tb1 = tab1.conectar("select * from vwusuarios where usuario = '" & HttpContext.Current.Session("usuario") & "'")
        If tb1.Rows.Count > 0 Then
            'If CDate(valordata(tb1.Rows(0)("dtvalidadesenha").ToString)).AddMonths(tb1.Rows(0)("novasenhaem").ToString) <= data() Then
            '    tb1.Rows(0)("alterado") = "0"
            '    Return "seguranca"
            'End If
        End If


        '    'If tb1.Rows(0)("gravado").ToString = "0" Then
        '    '    Return "completardadosagente"
        '    'End If
        'Else
        '        Return "login"
        'End If



        tb1 = tab1.conectar("select * from vwpermissoes where descricao='" & grupo & "' and pagina='" & pagina & "'  and usuario = '" & sessao & "'")

        If tb1.Rows.Count = 0 Then
            Return "semacesso"
        Else
            If Not HttpContext.Current.Request.Url.OriginalString.Contains(tb1.Rows(0)("pasta").ToString & "/" & pagina) Then
                Return "semacesso"
            End If
            'If CDate(tb1.Rows(0)("novasenhaem").ToString) <= data() Then
            '    tb1.Rows(0)("alterado") = "0"
            'End If
            If tb1.Rows(0)("forcarlogin").ToString = "1" OrElse tb1.Rows(0)("usuarioativo").ToString = "0" Then
                Return "login"
            End If
            If tb1.Rows(0)("alterado").ToString = "0" OrElse tb1.Rows(0)("alterado").ToString = "" Then
                Return "seguranca"
            End If
            If tb1.Rows(0)("suspenso").ToString = "1" Then
                Return "suspenso"
            End If
            If tb1.Rows(0)("ativo").ToString = True Then
                Return "Ok"
            Else
                Return "semacesso"
            End If

        End If

    End Function
    Public Shared Function gravalogin(usuario As String, xcliente As String, xpais As String, xapi As Boolean) As String
        Try
            If xpais = "" Then xpais = "Brasil"
            meucliente = HttpContext.Current.Request.Url.Host.Replace("www.", "")
            Dim ip As String = HttpContext.Current.Request.UserHostAddress
            Dim nrseqctrl As String = gerarnrseqcontrole()
            Dim plataforma As String = HttpContext.Current.Request.Browser.Platform & " - " & HttpContext.Current.Request.Browser.Browser

            Dim xenvio As New clsacessos
            xenvio.Maquina = ip
            xenvio.Nomecliente = meucliente
            xenvio.Cliente = xcliente
            xenvio.Usuario = usuario
            xenvio.Usuariosistema = usuario
            xenvio.Versao = minhaversao
            xenvio.Sistema = meuproduto
            xenvio.Dominio = HttpContext.Current.Request.Url.OriginalString
            xenvio.Sistemaoperacional = plataforma
            xenvio.Pais = xpais

            Dim xconteudo As String = Newtonsoft.Json.JsonConvert.SerializeObject(xenvio)
            Dim xprocessarapi As New clsprocessarAPI
            Dim xurl As String = "http://api.sistemapad.com.br/api/smartcode/gravaracesso"
            ' xurl = "http://localhost:44355/api/smartcode/gravaracesso"
            If xprocessarapi.enviarAPI(xconteudo, xurl, True) Then
                Return "Concluído"
            Else
                Return "cliente bloqueado"
            End If


        Catch ex As Exception
            Return "Erro base de dados"
        End Try
        Return True
    End Function
    Public Shared Function data() As Date

        If HttpContext.Current.Session("utc") = "" Then
            Dim xconfig As New clsconfig
            If Not xconfig.carregar OrElse xconfig.Utc = "" Then
                HttpContext.Current.Session("utc") = "Argentina Standard Time"
            Else
                HttpContext.Current.Session("utc") = xconfig.Utc
            End If


        End If

        Dim dateNow As Date = Date.Now
        Dim localtime As Date = Date.Now
        ' Console.WriteLine("The date and time are {0} UTC.",
        'TimeZoneInfo.ConvertTimeToUtc(dateNow))
        ' txtutctime.Text = TimeZoneInfo.ConvertTimeToUtc(dateNow)
        dateNow = TimeZoneInfo.ConvertTimeToUtc(dateNow)
        Dim easternTime As New Date(Year(dateNow), Month(dateNow), Day(dateNow), dateNow.Hour, dateNow.Minute, dateNow.Second)
        Dim easternZoneId As String = HttpContext.Current.Session("utc")
        Try
            Dim easternZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId)
            localtime = TimeZoneInfo.ConvertTimeFromUtc(easternTime, easternZone)
            Console.WriteLine("The date and time are {0} UTC.",
                      TimeZoneInfo.ConvertTimeToUtc(easternTime, easternZone))
        Catch ez As TimeZoneNotFoundException
            Console.WriteLine("Unable to find the {0} zone in the registry.",
                      easternZoneId)
        Catch ex As InvalidTimeZoneException
            Console.WriteLine("Registry data on the {0} zone has been corrupted.",
                      easternZoneId)
        End Try
        Return localtime.Now.Date
    End Function
    Public Shared Function hora(Optional segundos As Boolean = False) As String

        If HttpContext.Current.Session("utc") = "" Then
            Dim xconfig As New clsconfig
            If Not xconfig.carregar OrElse xconfig.Utc = "" Then
                HttpContext.Current.Session("utc") = "Argentina Standard Time"
            Else
                HttpContext.Current.Session("utc") = xconfig.Utc
            End If


        End If

        Dim dateNow As Date = Date.Now
        Dim localtime As Date = Date.Now
        ' Console.WriteLine("The date and time are {0} UTC.",
        'TimeZoneInfo.ConvertTimeToUtc(dateNow))
        ' txtutctime.Text = TimeZoneInfo.ConvertTimeToUtc(dateNow)
        dateNow = TimeZoneInfo.ConvertTimeToUtc(dateNow)
        Dim easternTime As New Date(Year(dateNow), Month(dateNow), Day(dateNow), dateNow.Hour, dateNow.Minute, dateNow.Second)
        Dim easternZoneId As String = HttpContext.Current.Session("utc")
        Try
            Dim easternZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId)
            localtime = TimeZoneInfo.ConvertTimeFromUtc(easternTime, easternZone)
            Console.WriteLine("The date and time are {0} UTC.",
                      TimeZoneInfo.ConvertTimeToUtc(easternTime, easternZone))
        Catch ez As TimeZoneNotFoundException
            Console.WriteLine("Unable to find the {0} zone in the registry.",
                      easternZoneId)
        Catch ex As InvalidTimeZoneException
            Console.WriteLine("Registry data on the {0} zone has been corrupted.",
                      easternZoneId)
        End Try


        Return IIf(segundos, mLeft(localtime.TimeOfDay.ToString, 5), mLeft(localtime.TimeOfDay.ToString, 8))

    End Function
    Public Shared Function retiraCaracteresEspeciais(ByVal strAFiltrar As String, Optional removerespacosfinal As Boolean = True)

        Dim posASubstituir As Integer = 0
        Dim curPos As Integer = 0
        Dim curChar As String = ""
        Dim substituirDe As String = ""
        Dim substituirPara As String = ""
        Dim strFiltrada As String = ""

        substituirDe = "äáàãâÄÁÀÃéèêëËÉÈÊíìïÍÌÎÏóòôõöÓÒÔÕÖúùûüÚÙÛÜçÇÂ'�ºª~`´'"
        substituirPara = "aaaaaAAAAeeeeEEEEiiiIIIIoooooOOOOOuuuuUUUUcCA       "

        For curPos = 1 To Len(strAFiltrar) 'ciclo na string a filtrar...
            curChar = Mid(strAFiltrar, curPos, 1) 'pega em cada caracter da string
            posASubstituir = InStr(substituirDe, curChar) 'verifica se está na string de caracteres a substituir
            If posASubstituir Then  ' se estiver,
                strFiltrada = strFiltrada & Mid(substituirPara, posASubstituir, 1) 'entra na string filtrada o equivalente não-acentuado
            Else 'se não estiver
                strFiltrada = strFiltrada & curChar 'entra na string filtrada tal como está
            End If
        Next curPos
        For x As Integer = 1 To 31
            strFiltrada = strFiltrada.Replace(Chr(x), "")
        Next
        For x As Integer = 126 To 254
            strFiltrada = strFiltrada.Replace(Chr(x), "")
        Next
        strFiltrada = strFiltrada.Replace("@", "").Replace(".", "")

        If removerespacosfinal Then
            Return strFiltrada.Trim
        Else
            Return strFiltrada
        End If

    End Function
    Public Shared Function valida(usuario As String, pagina As String, ehmaster As String) As String
        If usuario Is Nothing Then
            Return "login"
        End If
        Dim tbpagina As New Data.DataTable
        Dim tabpagina As New clabancopsql
        If ehmaster.ToLower = "sim" Then
            Return "ok"
        End If
        tbpagina = tabpagina.conectar("SELECT tbpermissoes.*,tbpermissoesdth.pagina  FROM tbpermissoes inner join tbpermissoesdth on tbpermissoes.nrseq = tbpermissoesdth.nrseqpermissao inner join tbusuarios on tbusuarios.permissao = tbpermissoes.descricao where tbpermissoesdth.pagina = '" & pagina & "' and tbpermissoes.ativo = true and tbpermissoesdth.ativo = true and tbusuarios.usuario = '" & usuario & "'")
        If tbpagina.Rows.Count = 0 Then
            HttpContext.Current.Response.Redirect("erro.aspx?mensagem=Descupe! Você não tem acesso à essa página!{novalinha}Entre em contato com o administrador do sistema para solicitar o acesso!")
            Return "erro"
        End If
        Return "ok"
    End Function
    Public Shared Function tratatexto(ByVal texto As String, Optional comaspas As Boolean = True, Optional tamanho As Integer = 0) As String
        Try
            If comaspas Then
                Return IIf(tamanho = 0, texto.Replace("'", "''"), mLeft(texto.Replace("'", "''"), tamanho))
            Else
                Return IIf(tamanho = 0, texto.Replace("'", ""), mLeft(texto.Replace("'", ""), tamanho))
            End If
        Catch ex As Exception
            Return ""
        End Try



    End Function
    Public Shared Function gravalog(acao As String, tipo As String) As Boolean
        Try

            Dim ip As String = HttpContext.Current.Request.UserHostAddress
            Dim nrseqctrl As String = gerarnrseqcontrole()
            Dim navegador As String = HttpContext.Current.Request.Browser.Browser & " Versão:" & HttpContext.Current.Request.Browser.Version
            Dim url As String = HttpContext.Current.Request.Url.ToString
            Dim idusuario As Integer = HttpContext.Current.Session("idusuario")
            Dim dtcad As String = hoje()
            Dim hora As String = TimeOfDay.ToString()

            Dim tblog As New Data.DataTable
            Dim tablog As New clabancopsql


            tblog = tablog.IncluirAlterarDados("insert into tblog (nrsequsuario,dtcad,acao,nrseqctrl,ip,url,navegador,hora, tipodelog) values (" & idusuario & ",'" & hoje() & "','" & acao & "','" & nrseqctrl & "','" & ip & "','" & url & "','" & navegador & "','" & TimeOfDay & "','" & tipo.ToString & "') ")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Public Shared Function alteranome(nome As String, Optional xrnd As Boolean = False) As String
        If Not xrnd Then
            If Not File.Exists(nome) Then
                Return nome
            End If
            Dim novonome As String = mPASTA(nome) & encontrachr(mARQUIVO(nome), ".", 1) & "(" & Directory.GetFiles(mPASTA(nome), (encontrachr(mARQUIVO(nome), ".", 1) & "*." & encontrachr(mARQUIVO(nome), ".", 0))).Length & ")" & "." & encontrachr(mARQUIVO(nome), ".", 0)
            Return novonome
        Else
            Dim novonome As String = mPASTA(nome) & encontrachr(mARQUIVO(nome), ".", 1) & sonumeros(hoje()) & sonumeros(hora(True)) & sonumeros(Rnd(100)) & "." & encontrachr(mARQUIVO(nome), ".", 0)
            Return novonome
        End If

    End Function
    Public Shared Function SearchForFiles(ByVal RootFolder As String, ByVal FileFilter() As String) As List(Of String)
        Dim ReturnedData As New List(Of String)                             'List to hold the search results
        Dim FolderStack As New Stack(Of String)                             'Stack for searching the folders
        FolderStack.Push(RootFolder)                                        'Start at the specified root folder
        Do While FolderStack.Count > 0                                      'While there are things in the stack
            Dim ThisFolder As String = FolderStack.Pop                      'Grab the next folder to process
            Try                                                             'Use a try to catch any errors
                For Each SubFolder In GetDirectories(ThisFolder)            'Loop through each sub folder in this folder
                    FolderStack.Push(SubFolder)                             'Add to the stack for further processing
                Next                                                        'Process next sub folder
                For Each FileExt In FileFilter                              'For each File filter specified


                    ReturnedData.AddRange(GetFiles(ThisFolder, FileExt))    'Search for and return the matched file names


                Next                                                        'Process next FileFilter
            Catch ex As Exception                                           'For simplicity sake
            End Try                                                         'We'll ignore the errors
        Loop                                                                'Process next folder in the stack
        Return ReturnedData                                                 'Return the list of files that match
    End Function
    Public Shared Function valordata(data As String) As String
        If data = "" Then data = "01/01/1900"
        If IsDate(data) = False Then data = "01/01/1900"
        If data.Contains("01/01/0001") Then data = "01/01/1900"
        Return FormatDateTime(data, Microsoft.VisualBasic.DateFormat.ShortDate)

    End Function
    Public Shared Function numeros(valor As String, Optional v As Boolean = False) As Decimal
        If valor = "" OrElse Not IsNumeric(valor) Then
            Return 0
        End If
        Return CType(valor, Decimal)
    End Function
    Public Shared Function AES_Encrypt(input As String, pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = System.Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
        End Try
    End Function
    Public Shared Function AES_Decrypt(input As String, pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = System.Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
            Dim xerro As String = ex.Message
        End Try
    End Function
#Region "Codigo de barras"
    Public Shared Function fncI25Encode(StringNumber)
        Dim asPattern(), sSTART, sSTOP
        ReDim asPattern(10)

        ' Padrões de Inicio e fim
        sSTART = "1111"
        sSTOP = "311"

        ' Padrões do código de barras
        asPattern(0) = "11331"
        asPattern(1) = "31113"
        asPattern(2) = "13113"
        asPattern(3) = "33111"
        asPattern(4) = "11313"
        asPattern(5) = "31311"
        asPattern(6) = "13311"
        asPattern(7) = "11133"
        asPattern(8) = "31131"
        asPattern(9) = "13131"

        If (Len(StringNumber) Mod 2) <> 0 Then
            ' O número de caracteres no
            ' argumento devem ser diferentes
            StringNumber = "0" & StringNumber
            'fncI25Encode = ""
            'Exit Function
        End If


        If Not IsNumeric(StringNumber) Then
            ' Argumento deve ser numérico
            fncI25Encode = ""
            Exit Function
        Else
            If (InStr(StringNumber, ".") <> 0) Or (InStr(StringNumber, ",") <> 0) Then
                ' O argumento é numero mais contem
                ' caracteres invalidos para nós
                fncI25Encode = ""
                Exit Function
            End If
        End If

        Dim sEncodedSTR, sUnit
        Dim iCharRead, sDigit1, sDigit2, i

        sEncodedSTR = ""
        For iCharRead = 1 To Len(StringNumber) Step 2
            sDigit1 = asPattern(Asc(Mid(StringNumber, iCharRead, 1)) - 48)
            sDigit2 = asPattern(Asc(Mid(StringNumber, iCharRead + 1, 1)) - 48)

            sUnit = ""

            For i = 1 To 5
                sUnit = sUnit & Mid(sDigit1, i, 1) & Mid(sDigit2, i, 1)
            Next

            sEncodedSTR = sEncodedSTR & sUnit
        Next
        Return sSTART & sEncodedSTR & sSTOP
    End Function
#End Region


End Class








