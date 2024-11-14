Imports Microsoft.VisualBasic
Imports clsSmart
Imports Newtonsoft.Json


Public Class clsrecuperasenha

    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _mensagemerro As String
    Dim _mensagemtitulo As String = "Ops !"
    Dim _mensagemicone As String = "error"
    Dim _listaclasse As New List(Of clsrecuperasenha)
    Dim _nrseq As Integer
    Dim _nrsequsuario As Integer
    Dim _codigo As String
    Dim _dtcad As Date
    Dim _hrcad As String
    Dim _usercad As String
    Dim _dtexclui As Date
    Dim _userexclui As String
    Dim _ativo As Boolean
    Dim _nrseqctrl As String
    Dim _validoate As String
    Dim _usuario As String
    Dim _imagemperfil As String
    Dim _email As String

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

    Public Property Listaclasse As List(Of clsrecuperasenha)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clsrecuperasenha))
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

    Public Property Nrsequsuario As Integer
        Get
            Return _nrsequsuario
        End Get
        Set(value As Integer)
            _nrsequsuario = value
        End Set
    End Property

    Public Property Codigo As String
        Get
            Return _codigo
        End Get
        Set(value As String)
            Try
                _codigo = value.ToLower.Replace("'", "").Replace(";", "").Replace("--", "").Replace("delete", "").Replace("create", "").Replace("drop", "").Replace("select", "").Replace("union", "")
            Catch ex As Exception

            End Try

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

    Public Property Hrcad As String
        Get
            Return _hrcad
        End Get
        Set(value As String)
            _hrcad = value
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

    Public Property Ativo As Boolean
        Get
            Return _ativo
        End Get
        Set(value As Boolean)
            _ativo = value
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

    Public Property Validoate As String
        Get
            Return _validoate
        End Get
        Set(value As String)
            _validoate = value
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

    Public Property Imagemperfil As String
        Get
            Return _imagemperfil
        End Get
        Set(value As String)
            _imagemperfil = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            Try
                _email = value.ToLower.Replace("'", "").Replace(";", "").Replace("--", "").Replace("delete", "").Replace("create", "").Replace("drop", "").Replace("select", "").Replace("union", "")
            Catch ex As Exception

            End Try

        End Set
    End Property
End Class

Partial Public Class clsrecuperasenha

    Public Function Listarrecuperasenha() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "select * from vwrecuperasenha where ativo = true"
            tb1 = tab1.conectar(xsql)
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clsrecuperasenha With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Nrsequsuario = numeros(tb1.Rows(x)("nrsequsuario").ToString), .Codigo = tb1.Rows(x)("codigo").ToString, .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Hrcad = tb1.Rows(x)("hrcad").ToString, .Usercad = tb1.Rows(x)("usercad").ToString, .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Userexclui = tb1.Rows(x)("userexclui").ToString, .Ativo = logico(tb1.Rows(x)("ativo").ToString), .Nrseqctrl = tb1.Rows(x)("nrseqctrl").ToString, .Validoate = tb1.Rows(x)("validoate").ToString, .Usuario = tb1.Rows(x)("usuario").ToString, .Imagemperfil = tb1.Rows(x)("imagemperfil").ToString, .Email = tb1.Rows(x)("email").ToString})
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
            Dim xsql As String = "select * from vwrecuperasenha where nrseq = " & Nrseq
            tb1 = tab1.conectar(xsql)
            If tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(tb1.Rows(0)("nrseq").ToString)
            Nrsequsuario = numeros(tb1.Rows(0)("nrsequsuario").ToString)
            Codigo = tb1.Rows(0)("codigo").ToString
            Dtcad = FormatDateTime(valordata(tb1.Rows(0)("dtcad").ToString), DateFormat.ShortDate)
            Hrcad = tb1.Rows(0)("hrcad").ToString
            Usercad = tb1.Rows(0)("usercad").ToString
            Dtexclui = FormatDateTime(valordata(tb1.Rows(0)("dtexclui").ToString), DateFormat.ShortDate)
            Userexclui = tb1.Rows(0)("userexclui").ToString
            Ativo = logico(tb1.Rows(0)("ativo").ToString)
            Nrseqctrl = tb1.Rows(0)("nrseqctrl").ToString
            Validoate = tb1.Rows(0)("validoate").ToString
            Usuario = tb1.Rows(0)("usuario").ToString
            Imagemperfil = tb1.Rows(0)("imagemperfil").ToString
            Email = tb1.Rows(0)("email").ToString
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
            Dim xprocura As New clsrecuperasenha
            Dim xjaexiste As Boolean = True
            xprocura.Nrseq = Nrseq
            If Not xprocura.procurar() Then
                xjaexiste = False
            End If
            xsql = " update tbrecuperasenha Set ativo = True"
            If xjaexiste Then
                If Nrsequsuario <> numeros(xprocura.Nrsequsuario) Then
                    xsql &= ",nrsequsuario = " & numeros(Nrsequsuario)
                End If
            Else
                If Nrsequsuario <> 0 Then
                    xsql &= ",nrsequsuario = " & numeros(Nrsequsuario)
                End If
            End If
            If xjaexiste Then
                If Codigo <> xprocura.Codigo Then
                    xsql &= ",codigo = '" & tratatexto(Codigo) & "'"
                End If
            Else
                If Codigo <> "" Then
                    xsql &= ",codigo = '" & tratatexto(Codigo) & "'"
                End If
            End If
            If xjaexiste Then
                If Hrcad <> xprocura.Hrcad Then
                    xsql &= ",hrcad = '" & tratatexto(Hrcad) & "'"
                End If
            Else
                If Hrcad <> "" Then
                    xsql &= ",hrcad = '" & tratatexto(Hrcad) & "'"
                End If
            End If
            If xjaexiste Then
                If Validoate <> xprocura.Validoate Then
                    xsql &= ",validoate = '" & tratatexto(Validoate) & "'"
                End If
            Else
                If Validoate <> "" Then
                    xsql &= ",validoate = '" & tratatexto(Validoate) & "'"
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
            tab1.Paramentrossql.Clear()
            tb1 = tab1.IncluirAlterarDados("insert into tbrecuperasenha (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            tb1 = tab1.conectar("Select * from  tbrecuperasenha where nrseqctrl = '" & wcnrseqctrl & "'")
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
            tb1 = tab1.IncluirAlterarDados("update vwrecuperasenha set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function

    Public Function ValidaCodigo() As Boolean

        Try
            tb1 = tab1.conectar("select * from vwusuarios where email = '" & _email & "' and ativo = true")
            If tb1.Rows.Count = 0 Then
                _mensagemerro = "This e-mail not found !"
                Return False
            End If
            Nrsequsuario = tb1.Rows(0)("nrseq").ToString
            tb1 = tab1.conectar("select * from vwrecuperasenha where nrsequsuario = " & Nrsequsuario & " and codigo = '" & sonumeros(Codigo) & "' and ativo = true")
            If tb1.Rows.Count = 0 Then
                _mensagemerro = "This code or e-mail not found."
                Return False
            End If
            Dim xconfig As New clsconfig
            xconfig.carregar()

            Dim xsenha As String = primeiraletra(retiraCaracteresEspeciais(xconfig.Nomecliente.Replace(" ", "").Split(" ")(0).ToString)) & "@" & data().Year
            tb1 = tab1.IncluirAlterarDados("update tbusuarios set alterado = false, suspenso = false, senha = '" & xsenha & "' where email = '" & Email & "'")
            tb1 = tab1.IncluirAlterarDados("update tbrecuperasenha set ativo = false where nrsequsuario = " & Nrsequsuario & " and codigo = '" & sonumeros(Codigo) & "'")

            Return True
        Catch ex As Exception
            _mensagemerro = ex.Message
            Return False
        End Try
    End Function
    Public Function EnviarCodigo() As Boolean
        Try
            Dim tbrecup As New Data.DataTable
            Dim tabrecup As New clabancopsql
            Dim xexiste As Boolean = False
            If Not validaemail(_email) Then
                _mensagemerro = "Please, enter a valid e-mail!"
                Return False
            End If
            tabrecup.Paramentrossql.Clear()
            tabrecup.Paramentrossql.Add("@email", Email)
            tbrecup = tabrecup.conectar("select * from vwrecuperasenha where email = @email and ativo = true")
            If tbrecup.Rows.Count > 0 Then
                Static t_inicio As DateTime
                Static t_fim As DateTime
                Dim t_diferenca As TimeSpan

                t_inicio = CDate(data() & " " & tbrecup.Rows(0)("hrcad").ToString)

                t_fim = Now
                t_diferenca = t_fim.Subtract(t_inicio)
                If mLeft(t_diferenca.ToString, 2) = 0 Then
                    xexiste = True
                Else
                    xexiste = False
                    tab1.Paramentrossql.Clear()
                    tab1.Paramentrossql.Add("@nrseq", tbrecup.Rows(0)("nrseq").ToString)
                    tb1 = tab1.IncluirAlterarDados("update tbrecuperasenha set ativo = false where nrseq = @nrseq")
                End If

            End If
            tab1.Paramentrossql.Clear()
            tab1.Paramentrossql.Add("@email", _email)
            tb1 = tab1.conectar("select * from vwusuarios where email = @email and ativo = true")
            If tb1.Rows.Count = 0 Then
                _mensagemerro = "This e-mail not found !"
                Return False
            End If

            _nrsequsuario = tb1.Rows(0)("nrseq").ToString
            _usuario = tb1.Rows(0)("usuario").ToString

            If xexiste Then
                _codigo = tbrecup.Rows(0)("codigo").ToString
                _validoate = tbrecup.Rows(0)("validoate").ToString
                _hrcad = tbrecup.Rows(0)("hrcad").ToString
                _dtcad = valordata(tbrecup.Rows(0)("dtcad").ToString)
                _nrseq = tbrecup.Rows(0)("nrseq").ToString
                If Not salvar() Then
                    Return False
                End If
            Else
                _hrcad = hora()
                Dtcad = data()
                Validoate = IIf(xexiste, "", mLeft(Date.Now.AddHours(1).TimeOfDay.ToString, 5))
                Dim GeradorDeNumerosAleatorios As Random = New Random()
                GeradorDeNumerosAleatorios.Next(1000, 985711)
                _codigo = mLeft(zeros(sonumeros(GeradorDeNumerosAleatorios.Next(1000, 985711)), 6), 6)
                If Not salvar(True) Then
                    Return False
                End If
            End If


            Dim xconfig As New clsconfig
            xconfig.carregar()
            Dim xsenha As String = primeiraletra(xconfig.Nomecliente.Split(" ")(0).ToString) & "@" & data().Year
            Dim xlog As New clslogs(_nrseq, "EmailAutomatico")

            xlog.Entrada = "Início"

            Try
                Dim xmens As New clscaixamensagens
                Dim xpadrao As New clsconfig_padroes
                Dim xbuscar As New clsprocessarAPI

                ' Dim xurlAPI As String = "http://localhost:44355/api/smartcode/textoemails"
                Dim xurlAPI As String = "http://api.sistemapad.com.br/api/smartcode/textoemails"
                xbuscar.Listaheaders.Add(New clsprocessarAPI_headers With {.Headers = "API-KEY", .Valor = "8hgliBD6blCQ2pyxI9KJboI46Vy2ummNaANhvOKT/Uw="})
                If xbuscar.enviarAPI("Forgot my password", xurlAPI, True) Then

                    xpadrao = JsonConvert.DeserializeObject(Of clsconfig_padroes)(xbuscar.Mensagemerro)
                    If xpadrao.Mensagemerro = "" Then


                        'xpadrao.Nome = "Forgot my password"
                        ' xpadrao.carregar(_email)

                        Dim _url As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "")

                        xmens.Corpo = xpadrao.Corpo.Replace("{hoje}", FormatDateTime(data(), DateFormat.ShortDate)).Replace("{recovercode}", _codigo).Replace("{password}", xsenha).Replace("{usuario}", _usuario).Replace("{sistema}", Resources.Resource.idpad).Replace("url", _url)
                        xmens.Assunto = Resources.Resource.idpad & " recover password:" & xpadrao.Assuntoemail
                        xmens.Remetente = "alertas@smartcodesolucoes.com.br"
                        xmens.Urgente = True
                        xlog.Entrada = "Enviando"
                        xmens.destinatarios.Add(New clscaixamensagens_destinatarios With {.Usuario = _email})
                        If Not xmens.enviar() Then
                            _mensagemerro = xmens.Mensagemerro
                            Return False
                        End If
                        xlog.Entrada = "Enviado"
                        _mensagemerro = "O e-mail foi enviado para os destinatários do grupo !"

                    End If
                Else
                    _mensagemerro = xbuscar.Mensagemerro
                End If
                xlog.finalizar()
                Return True
            Catch exenvioemail As Exception
                xlog.Entrada = "Erro:" & exenvioemail.Message
                _mensagemerro = exenvioemail.Message
                xlog.finalizar()
                Return False
            End Try

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class


