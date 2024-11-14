Imports Microsoft.VisualBasic
Imports clsSmart
Imports System.Data.Common.CommandTrees.ExpressionBuilder
Imports System.IO
Imports System.Drawing
Imports Newtonsoft.Json
Imports SelectPdf

Public Class clsmodeloscontratos

    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _mensagemerro As String
    Dim _mensagemtitulo As String = "Ops !"
    Dim _mensagemicone As String = "Error"
    Dim _filtro_nrseq As Integer = 0
    Dim _filtro_vinculo As String = ""
    Dim _filtro_nome As String = ""
    Dim _listaclasse As New List(Of clsmodeloscontratos)
    Dim _tags As New List(Of clsconfig_padroes_tags)
    Dim _nrseq As Integer
    Dim _texto As String
    Dim _nome As String
    Dim _ativo As Boolean
    Dim _dtcad As Date
    Dim _usercad As String
    Dim _dtexclui As Date
    Dim _userexclui As String
    Dim _vinculo As String
    Dim _nrseqpadraoemail As Integer
    Dim _permiteenviaremail As Boolean

    Dim _nomearquivogerado As String = ""
    Dim _nomearquivogeradoPDF As String = ""
    Dim _paramentrossql As New Dictionary(Of String, String)


    Public Sub New()
        Usercad = HttpContext.Current.Session("usuario")
    End Sub

    Public Property Paramentrossql As Dictionary(Of String, String)
        Get
            Return _paramentrossql
        End Get
        Set(value As Dictionary(Of String, String))
            _paramentrossql = value
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

    Public Property Filtro_nrseq As Integer
        Get
            Return _filtro_nrseq
        End Get
        Set(value As Integer)
            _filtro_nrseq = value
        End Set
    End Property

    Public Property Listaclasse As List(Of clsmodeloscontratos)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clsmodeloscontratos))
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

    Public Property Texto As String
        Get
            Return _texto
        End Get
        Set(value As String)
            _texto = value
        End Set
    End Property

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(value As String)
            _nome = value
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

    Public Property userexclui As String
        Get
            Return _userexclui
        End Get
        Set(value As String)
            _userexclui = value
        End Set
    End Property

    Public Property Nrseqpadraoemail As Integer
        Get
            Return _nrseqpadraoemail
        End Get
        Set(value As Integer)
            _nrseqpadraoemail = value
        End Set
    End Property

    Public Property Permiteenviaremail As Boolean
        Get
            Return _permiteenviaremail
        End Get
        Set(value As Boolean)
            _permiteenviaremail = value
        End Set
    End Property

    Public Property Tags As List(Of clsconfig_padroes_tags)
        Get
            Return _tags
        End Get
        Set(value As List(Of clsconfig_padroes_tags))
            _tags = value
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

    Public Property Filtro_vinculo As String
        Get
            Return _filtro_vinculo
        End Get
        Set(value As String)
            _filtro_vinculo = value
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
End Class

Partial Public Class clsmodeloscontratos

    Public Function Listarmodeloscontratos() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "select * from tbmodeloscontratos where ativo = true"
            If Filtro_nrseq <> 0 Then
                xsql &= " and nrseq = " & Filtro_nrseq
            End If
            If Filtro_nome <> "" Then
                xsql &= " and nome like '%" & Filtro_nome & "%'"
            End If
            If Filtro_vinculo <> "" Then
                xsql &= " and vinculo = '" & Filtro_vinculo & "'"
            End If
            xsql &= " order by nome"
            tb1 = tab1.conectar(xsql)
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clsmodeloscontratos With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Texto = tb1.Rows(x)("texto").ToString, .Nome = tb1.Rows(x)("nome").ToString, .Ativo = logico(tb1.Rows(x)("ativo").ToString), .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Usercad = tb1.Rows(x)("usercad").ToString, .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .userexclui = tb1.Rows(x)("userexclui").ToString, .Vinculo = tb1.Rows(x)("vinculo").ToString, .Nrseqpadraoemail = numeros(tb1.Rows(x)("nrseqpadraoemail").ToString), .Permiteenviaremail = logico(tb1.Rows(x)("permiteenviaremail").ToString)})
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
                Return False
            End If
            Dim xsql As String = "select * from tbmodeloscontratos where nrseq = " & Nrseq
            tb1 = tab1.conectar(xsql)
            If tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(tb1.Rows(0)("nrseq").ToString)
            Texto = tb1.Rows(0)("texto").ToString
            Nome = tb1.Rows(0)("nome").ToString
            Ativo = logico(tb1.Rows(0)("ativo").ToString)
            Dtcad = FormatDateTime(valordata(tb1.Rows(0)("dtcad").ToString), DateFormat.ShortDate)
            Usercad = tb1.Rows(0)("usercad").ToString
            Dtexclui = FormatDateTime(valordata(tb1.Rows(0)("dtexclui").ToString), DateFormat.ShortDate)
            userexclui = tb1.Rows(0)("userexclui").ToString
            Vinculo = tb1.Rows(0)("vinculo").ToString
            Nrseqpadraoemail = numeros(tb1.Rows(0)("nrseqpadraoemail").ToString)
            Permiteenviaremail = logico(tb1.Rows(0)("permiteenviaremail").ToString)
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function

    Public Function salvar(Optional xnovo As Boolean = False) As Boolean
        Try
            If xnovo = True Then
                novo()
            End If
            Dim xsql As String
            Dim xprocura As New clsmodeloscontratos
            Dim xjaexiste As Boolean = True
            xprocura.Nrseq = Nrseq
            If Not xprocura.procurar() Then
                xjaexiste = False
            End If
            xsql = "update tbmodeloscontratos Set ativo = true"
            If xjaexiste Then
                If Texto <> xprocura.Texto Then
                    'Dim bytes As Byte()
                    'bytes = Encoding.Default.GetBytes(tratatexto(Texto))
                    'xsql &= ",texto = '" & Encoding.UTF8.GetString(bytes) & "'"
                    xsql &= ",texto = '" & Texto & "'"
                End If
            Else
                If Texto <> "" Then
                    'Dim bytes As Byte()
                    'bytes = Encoding.Default.GetBytes(tratatexto(Texto))
                    'xsql &= ",texto = '" & Encoding.UTF8.GetString(bytes) & "'"
                    xsql &= ",texto = '" & Texto & "'"
                End If
            End If
            If xjaexiste Then
                If Nome <> xprocura.Nome Then
                    xsql &= ",nome = '" & tratatexto(Nome) & "'"
                End If
            Else
                If Nome <> "" Then
                    xsql &= ",nome = '" & tratatexto(Nome) & "'"
                End If
            End If
            If xjaexiste Then
                If Vinculo <> xprocura.Vinculo Then
                    xsql &= ",vinculo = '" & tratatexto(Vinculo) & "'"
                End If
            Else
                If Vinculo <> "" Then
                    xsql &= ",vinculo = '" & tratatexto(Vinculo) & "'"
                End If
            End If
            If xjaexiste Then
                If userexclui <> xprocura.userexclui Then
                    xsql &= ",userexclui = '" & tratatexto(userexclui) & "'"
                End If
            Else
                If userexclui <> "" Then
                    xsql &= ",userexclui = '" & tratatexto(userexclui) & "'"
                End If
            End If
            If xjaexiste Then
                If Nrseqpadraoemail <> numeros(xprocura.Nrseqpadraoemail) Then
                    xsql &= ",nrseqpadraoemail = " & numeros(Nrseqpadraoemail)
                End If
            Else
                If Nrseqpadraoemail <> 0 Then
                    xsql &= ",nrseqpadraoemail = " & numeros(Nrseqpadraoemail)
                End If
            End If
            If xjaexiste Then
                If logico(Permiteenviaremail) <> logico(xprocura.Permiteenviaremail) Then
                    xsql &= ",permiteenviaremail = logico(" & logico(Permiteenviaremail) & ")"
                End If
            Else
                If Permiteenviaremail <> True Then
                    xsql &= ",permiteenviaremail = " & logico(Permiteenviaremail)
                End If
            End If
            xsql &= " where nrseq = " & Nrseq
            tb1 = tab1.IncluirAlterarDados(xsql)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function

    Public Function novo() As Boolean
        Try
            Dim wcnrseqctrl As String = gerarnrseqcontrole()
            tb1 = tab1.IncluirAlterarDados("insert into tbmodeloscontratos (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            tb1 = tab1.conectar("Select * from  tbmodeloscontratos where nrseqctrl = '" & wcnrseqctrl & "'")
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
            tb1 = tab1.IncluirAlterarDados("update tbmodeloscontratos set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function

    Public Function gerarHTMLdocumento(xtipodocumento As String, xnomedocumento As String) As Boolean
        Try
            tb1 = tab1.conectar("select * from tbmodeloscontratos where ativo = true and nome = '" & xnomedocumento & "'")
            If tb1.Rows.Count = 0 Then
                _mensagemerro = "O documento não foi encontrado!"
                Return False
            End If
            If Not tratardocumento(tb1.Rows(0)("texto").ToString, xtipodocumento) Then

                Return False
            End If
            Dim xnomedoc As String = HttpContext.Current.Server.MapPath("~") & "arquivos\documentos\docgerado.html"
            xnomedoc = alteranome(xnomedoc)
            Dim xgravar As New StreamWriter(xnomedoc)
            xgravar.Write("<html>")
            xgravar.Write("<head>")
            xgravar.Write("<meta charset=""UTF-8"">")
            xgravar.Write("</head>")


            xgravar.Write(_texto)
            xgravar.Write("</html>")
            xgravar.Close()
            _nomearquivogerado = xnomedoc
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
                Case Is = "vwanoletivo_alunos"
                    xsql2 = "select * from vwanoletivo_alunos where matriculaativa = true and  ativo = true and not nome is null  "

                    For y As Integer = 0 To Paramentrossql.Keys.Count - 1



                        xsql2 &= " and " & Paramentrossql.Keys(y).Replace("@", "") & " = " & Paramentrossql.Keys(y) & ""

                    Next
                    xsql2 &= " order by nome"

                    tabdados.Paramentrossql = Paramentrossql

                    tbdados = tabdados.conectar(xsql2)

                    If tbdados.Rows.Count = 0 Then
                        _mensagemerro = "A turma não foi localizada "
                        Return False
                    End If

                    For x As Integer = 0 To listaffiltrada(0).Listaclasse.Count - 1
                        If listaffiltrada(0).Listaclasse(x).Valor.Contains("{") Then
                            Select Case listaffiltrada(0).Listaclasse(x).Valor

                                Case Is = "{cpf}"
                                    xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, tbdados.Rows(0)("cpf").ToString)
                                Case Is = "{fone}"
                                    Try
                                        'Dim xcontatos As New clsalunos_contatos
                                        'xcontatos.Filtrar_nrseqaluno = numeros(tbdados.Rows(0)("nrseqaluno").ToString)
                                        'xcontatos.Listaralunos_contatos()
                                        'Dim xtemp As String = ""
                                        'For xy As Integer = 0 To xcontatos.Listaclasse.Count - 1
                                        '    xtemp &= xcontatos.Listaclasse(xy).Valor & "/"
                                        'Next
                                        'xtemp = xtemp.Substring(0, xtemp.Length - 1)
                                        'xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, xtemp)
                                    Catch exfone As Exception
                                        xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, "Não informado!")
                                    End Try
                                Case Is = "{emailfinanceiro}"
                                    'Dim xrespo As New clsalunos_responsaveis
                                    'xrespo.Filtro_nrseqaluno = tbdados.Rows(0)("nrseqaluno").ToString
                                    'xrespo.Filtrar_financeiro = True
                                    'xrespo.Listaralunos_responsaveis()
                                    'If xrespo.Listaclasse.Count = 0 Then
                                    '    xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, "NAO INFORMADO")
                                    'Else
                                    '    Dim xtempfin As String = ""
                                    '    For y As Integer = 0 To xrespo.Listaclasse.Count - 1
                                    '        xtempfin &= xrespo.Listaclasse(y).Emailresponsavel & ","
                                    '    Next
                                    '    xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, xtempfin.Substring(0, xtempfin.Length - 1))
                                    'End If
                                Case Is = "{dia}"
                                    xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, data().Day)
                                Case Is = "{mes}"
                                    xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, MesExtenso(data().Month))
                                Case Is = "{ano}"
                                    xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, data().Year)
                                Case Is = "{empresa}"
                                    xtexto = xtexto.Replace(listaffiltrada(0).Listaclasse(x).Campo, HttpContext.Current.Session("nomecliente"))
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

            End Select
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
            Dim FullPath = raiz & "/arquivos/documentos/" & mARQUIVO(xarquivo)


            Dim converter As New HtmlToPdf()
            converter.Header.DisplayOnOddPages = True
            converter.Header.DisplayOnEvenPages = True
            converter.Header.Height = 20
            Dim doc1 As PdfDocument = converter.ConvertHtmlString(FullPath)

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

            Dim doc As PdfDocument = converter.ConvertUrl(FullPath)
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
            Dim doc As PdfDocument = converter.ConvertUrl(FullPath)
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


