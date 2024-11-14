Imports Microsoft.VisualBasic
Imports clsSmart
Imports System.IO
Public Class clssessoes
    Inherits BasePage
    Dim _listacookies As New List(Of clscookies)
    Private Shared _mensagemerro As String
    Public Shared cookieName As String = "smcolegio"
    Private Shared _listacookiessistema As New List(Of String)

    Public Property Listacookies As List(Of clscookies)
        Get
            Return _listacookies
        End Get
        Set(value As List(Of clscookies))
            _listacookies = value
        End Set
    End Property

    Public Shared Function cookieExpire() As DateTime
        cookieExpire = DateTime.Now.AddDays(5.0)
        Return cookieExpire
    End Function
    Public Sub New()

    End Sub

    Public Shared Sub versessao()

        ' Aqui, controlamos o acessos aos formulários, assim como todos os cookies e sessões.
        ' Ao ccolocar esse exit sub, a rotina para e não controlará a seggurança do sistema


        cookie_sessao()

        If HttpContext.Current.Session("usuario") = "" Then
            HttpContext.Current.Response.Redirect("\login.aspx")
            Exit Sub
        End If
        ' Se for html / pdf
        '     If mARQUIVO(HttpContext.Current.Request.Path, True) = "gerarpad.aspx" Then Exit Sub
        If mARQUIVO(HttpContext.Current.Request.Path, True) = "block.aspx" Then Exit Sub
        'If mARQUIVO(HttpContext.Current.Request.Path, True) = "gerarpad.aspx" Then Exit Sub
        If mARQUIVO(HttpContext.Current.Request.Path, True) = "imprimirindicadores.aspx" Then Exit Sub
        If mARQUIVO(HttpContext.Current.Request.Path, True) = "noacess.aspx" Then Exit Sub
        If mARQUIVO(HttpContext.Current.Request.Path, True) = "seguranca.aspx" Then Exit Sub
        If mARQUIVO(HttpContext.Current.Request.Path, True) = "loadimage.aspx" Then Exit Sub
        If mARQUIVO(HttpContext.Current.Request.Path, True) = "imprimir_carne.aspx" Then Exit Sub

        Exit Sub


        Dim resultado As String = validarusuario(HttpContext.Current.Session("usuario"), HttpContext.Current.Server.HtmlDecode(HttpContext.Current.Session("permissao")), mARQUIVO(HttpContext.Current.Request.Path, True), "").ToLower
        If valordata(HttpContext.Current.Session("dtultimologin")) <> data() Then
            Dim xlogin As New clslogin

            If gravalogin(HttpContext.Current.Session("usuario"), xlogin.Cliente, HttpContext.Current.Session("pais"), True) = "Concluído" Then

                HttpContext.Current.Session("dtultimologin") = data()
                gravarcookie("dtultimologin", data())
            End If
        End If
        Select Case resultado
            Case Is = "login"

                If Not HttpContext.Current.Request.Cookies.Get(cookieName) Is Nothing Then
                    'If (HttpContext.Current.Request.Cookies.Get(cookieName)("permissao") = "" OrElse HttpContext.Current.Request.Cookies.Get(cookieName)("permissao") Is Nothing) Then
                    '    HttpContext.Current.Response.Redirect("login.aspx")
                    '    Exit Sub
                    'Else
                    HttpContext.Current.Session("urlretorno") = HttpContext.Current.Request.Path


                    HttpContext.Current.Response.Redirect("\login.aspx")
                    'End If



                Else
                    HttpContext.Current.Session("urlretorno") = HttpContext.Current.Request.Path


                    HttpContext.Current.Response.Redirect("login.aspx")
                End If
                Exit Sub
            Case Is = "suspenso"
                HttpContext.Current.Response.Redirect("erro.aspx?mensagem=Seu acesso ao sistema foi suspenso!")
            Case Is = "seguranca"
                If Not HttpContext.Current.Request.Path.ToLower.Contains("seguranca.aspx") Then
                    HttpContext.Current.Response.Redirect("seguranca.aspx")
                End If

            Case Is = "semacesso"
                If Not HttpContext.Current.Request.Path.ToLower.Contains("noacess.aspx") Then
                    Dim logerro As New StreamWriter(HttpContext.Current.Server.MapPath("~") & "\logerros\erroacesso" & sonumeros(HttpContext.Current.Request.UserHostAddress) & sonumeros(data) & sonumeros(hora(True)) & ".txt")

                    logerro.WriteLine("Log de erro - Data: " & data() & " / Hora: " & hora(True) & " Acesso Negado ")
                    logerro.WriteLine("Usuário: " & HttpContext.Current.Session("usuario"))
                    logerro.WriteLine("Página: " & mARQUIVO(HttpContext.Current.Request.Path, True))
                    logerro.WriteLine("Permissão: " & HttpContext.Current.Server.HtmlDecode(HttpContext.Current.Session("permissao")))

                    logerro.Close()


                    HttpContext.Current.Response.Redirect("noacess.aspx")
                End If

            Case Is = "erro"

                Exit Sub
        End Select


    End Sub
    Public Function listartodassessoes() As Boolean
        Try
            Listacookies.Clear()
            For x As Integer = 0 To _listacookiessistema.Count - 1
                Try
                    Listacookies.Add(New clscookies With {.Chave = _listacookiessistema(x), .Valor = HttpContext.Current.Session(_listacookiessistema(x))})
                Catch ex2 As Exception
                    Listacookies.Add(New clscookies With {.Chave = _listacookiessistema(x), .Valor = "Erro"})
                End Try
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Shared Sub carregacookies()
        Try
            _listacookiessistema.Clear()
            _listacookiessistema.Add("id")
            _listacookiessistema.Add("idusuario")
            _listacookiessistema.Add("usuario")
            _listacookiessistema.Add("nomeusuario")
            _listacookiessistema.Add("permissao")
            _listacookiessistema.Add("usuario")
            _listacookiessistema.Add("email")
            _listacookiessistema.Add("permissao")
            _listacookiessistema.Add("usuariomaster")
            _listacookiessistema.Add("imagemperfil")
            _listacookiessistema.Add("urlretorno")
            _listacookiessistema.Add("nomecliente")
            _listacookiessistema.Add("enderecocliente")
            _listacookiessistema.Add("bairrocliente")
            _listacookiessistema.Add("cidadecliente")
            _listacookiessistema.Add("ufcliente")
            _listacookiessistema.Add("paiscliente")
            _listacookiessistema.Add("telefonecliente")
            _listacookiessistema.Add("logocliente")
            _listacookiessistema.Add("corpadrao")
            _listacookiessistema.Add("master")
            _listacookiessistema.Add("sql")
            _listacookiessistema.Add("novasenhaem")
            _listacookiessistema.Add("utc")
            _listacookiessistema.Add("dtultimologin")
            _listacookiessistema.Add("hrultimologin")
            _listacookiessistema.Add("pais")
            _listacookiessistema.Add("tipodeacesso")
            _listacookiessistema.Add("modal")
            _listacookiessistema.Add("nrseqempresa")
            _listacookiessistema.Add("nrsequnidade")
            _listacookiessistema.Add("imagemempresa")
            _listacookiessistema.Add("semclientes")


        Catch ex As Exception

        End Try




    End Sub

    Public Shared Sub limparCookieTemporario()



        carregacookies()
        Dim xCoockie As HttpCookie
        xCoockie = verificarCookies()

        For x As Integer = 0 To _listacookiessistema.Count - 1
            Try
                If _listacookiessistema(x) Is Nothing Then Exit For

                If xCoockie.Values(_listacookiessistema(x)) Is Nothing Then
                    xCoockie.Values(_listacookiessistema(x)) = ""


                End If

                HttpContext.Current.Session(_listacookiessistema(x)) = HttpContext.Current.Server.HtmlDecode(xCoockie.Values(_listacookiessistema(x)))
            Catch extam As Exception
                Exit For
            End Try



        Next
        xCoockie.Expires = cookieExpire()
        HttpContext.Current.Response.Cookies.Add(xCoockie)
    End Sub

    Public Shared Sub cookie_sessao(Optional chave As String = "")

        carregacookies()
        Dim xCoockie As HttpCookie
        xCoockie = verificarCookies()

        For x As Integer = 0 To _listacookiessistema.Count - 1
            Try
                If _listacookiessistema(x) Is Nothing Then Exit For
                If chave = "" Then
                    If xCoockie.Values(_listacookiessistema(x)) Is Nothing Then
                        xCoockie.Values(_listacookiessistema(x)) = ""


                    End If
                    If HttpContext.Current.Server.HtmlDecode(xCoockie.Values(_listacookiessistema(x))) <> "" Then
                        HttpContext.Current.Session(_listacookiessistema(x)) = IIf(HttpContext.Current.Server.HtmlDecode(xCoockie.Values(_listacookiessistema(x))).Substring(0, 1) = ",", HttpContext.Current.Server.HtmlDecode(xCoockie.Values(_listacookiessistema(x))).Substring(1), HttpContext.Current.Server.HtmlDecode(xCoockie.Values(_listacookiessistema(x))))
                    Else
                        HttpContext.Current.Session(_listacookiessistema(x)) = ""
                    End If
                Else
                    If _listacookiessistema(x).ToLower = chave.ToLower Then
                        HttpContext.Current.Session(_listacookiessistema(x)) = IIf(HttpContext.Current.Server.HtmlDecode(xCoockie.Values(_listacookiessistema(x))).Substring(0, 1) = ",", HttpContext.Current.Server.HtmlDecode(xCoockie.Values(_listacookiessistema(x))).Substring(1), HttpContext.Current.Server.HtmlDecode(xCoockie.Values(_listacookiessistema(x))))
                    End If
                End If

            Catch extam As Exception
                Exit For
            End Try

        Next

        xCoockie.Expires = DateTime.Now.AddDays(4)
        HttpContext.Current.Response.Cookies.Add(xCoockie)
    End Sub


    Public Shared Function gravarcookie(chave As String, valor As String) As Boolean

        Dim xCoockie As HttpCookie
        xCoockie = verificarCookies()


        xCoockie.Values(chave) = ""
        xCoockie.Values.Add(chave, valor)
        HttpContext.Current.Response.AppendCookie(xCoockie)
        Return True


    End Function

    Public Shared Function gravarcookie(xcookies As List(Of clscookies)) As Boolean

        Dim xCoockie As HttpCookie
        xCoockie = verificarCookies()
        For x As Integer = 0 To xcookies.Count - 1
            xCoockie.Values(xcookies(x).Chave) = ""
            xCoockie.Values.Add(xcookies(x).Chave, xcookies(x).Valor)
            HttpContext.Current.Response.AppendCookie(xCoockie)
        Next
        Return True
    End Function
    Public Shared Function buscarsessoes(chave As String) As String

        carregacookies()

        Dim xCoockie As HttpCookie
        xCoockie = verificarCookies()

        For x As Integer = 0 To _listacookiessistema.Count - 1
            If _listacookiessistema(x) Is Nothing Then Exit For

            If xCoockie.Values(_listacookiessistema(x)) Is Nothing Then
                xCoockie.Values(_listacookiessistema(x)) = ""


            End If




        Next

        Dim valorretorno As String = ""
        If chave <> "" Then
            If xCoockie.Values(chave) Is Nothing Then
                valorretorno = ""
            Else
                valorretorno = xCoockie.Values(chave)
            End If

        End If

        If valorretorno.Length > 0 AndAlso valorretorno.Substring(0, 1) = "," Then
            valorretorno = valorretorno.Substring(1, valorretorno.Length - 1)
        End If
        xCoockie.Expires = DateTime.Now.AddDays(30)
        HttpContext.Current.Response.Cookies.Add(xCoockie)

        Return valorretorno

    End Function

    Private Shared Function verificarCookies() As HttpCookie
        Try
            If HttpContext.Current.Request.Cookies(cookieName) Is Nothing Then
                Dim aCookie As New HttpCookie(cookieName)

                aCookie.Expires = DateTime.Now.AddDays(30)
                HttpContext.Current.Response.Cookies.Add(aCookie)
                Return aCookie
            Else

                Return HttpContext.Current.Request.Cookies(cookieName)
            End If
        Catch excoockie As Exception
            Dim aCookie As New HttpCookie(cookieName)

            aCookie.Expires = DateTime.Now.AddDays(30)
            HttpContext.Current.Response.Cookies.Add(aCookie)
            Return aCookie
            _mensagemerro = excoockie.Message
            Return Nothing
        End Try

    End Function



    Public Shared Sub novocockielogin()
        Dim aCookie As New HttpCookie(cookieName)
        aCookie.Values("id") = HttpContext.Current.Session("id")
        aCookie.Values("lastVisit") = DateTime.Now.ToString()
        aCookie.Values("usuario") = HttpContext.Current.Session("usuario")
        aCookie.Values("idusuario") = HttpContext.Current.Session("idusuario")
        aCookie.Values("permissao") = HttpContext.Current.Session("permissao")
        aCookie.Values("nomeusuario") = HttpContext.Current.Session("nomeusuario")
        aCookie.Values("email") = HttpContext.Current.Session("email")

        aCookie.Values("usuariomaster") = HttpContext.Current.Session("usuariomaster")

        aCookie.Values("imagemperfil") = HttpContext.Current.Session("imagemperfil")


        aCookie.Values("nomecliente") = HttpContext.Current.Session("nomecliente")
        aCookie.Values("enderecocliente") = HttpContext.Current.Session("enderecocliente")
        aCookie.Values("bairrocliente") = HttpContext.Current.Session("bairrocliente")
        aCookie.Values("cidadecliente") = HttpContext.Current.Session("cidadecliente")
        aCookie.Values("ufcliente") = HttpContext.Current.Session("ufcliente")
        aCookie.Values("paiscliente") = HttpContext.Current.Session("paiscliente")
        aCookie.Values("telefonecliente") = HttpContext.Current.Session("telefonecliente")
        aCookie.Values("logocliente") = HttpContext.Current.Session("logocliente")
        aCookie.Values("corpadrao") = HttpContext.Current.Session("corpadrao")
        aCookie.Values("master") = HttpContext.Current.Session("master")
        aCookie.Values("novasenhaem") = HttpContext.Current.Session("novasenhaem")
        aCookie.Values("dtultimologin") = HttpContext.Current.Session("dtultimologin")
        aCookie.Values("hrultimologin") = HttpContext.Current.Session("hrultimologin")
        aCookie.Values("pais") = HttpContext.Current.Session("pais")
        aCookie.Values("tipodeacesso") = HttpContext.Current.Session("tipodeacesso")
        aCookie.Values("nrseqprofessor") = numeros(HttpContext.Current.Session("nrseqprofessor"))
        aCookie.Values("nomealuno") = HttpContext.Current.Session("nomealuno")
        aCookie.Values("nrseqaluno") = HttpContext.Current.Session("nrseqaluno")
        aCookie.Expires = DateTime.Now.AddDays(1)
        HttpContext.Current.Response.Cookies.Add(aCookie)
    End Sub

    Public Shared Sub versessao2()



        Dim resultado As String = valida(HttpContext.Current.Session("usuario"), mARQUIVO(HttpContext.Current.Request.Path, True), HttpContext.Current.Session("usuariomaster")).ToLower
        Select Case resultado
            Case Is = "login"

                If Not HttpContext.Current.Request.Cookies.Get("cevawms") Is Nothing Then
                    HttpContext.Current.Session("id") = HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.Cookies.Get("cevawms")("id"))
                    HttpContext.Current.Session("usuariomaster") = HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.Cookies.Get("cevawms")("usuariomaster"))
                    HttpContext.Current.Session("usuario") = HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.Cookies.Get("cevawms")("usuario"))
                    HttpContext.Current.Session("idusuario") = HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.Cookies.Get("cevawms")("idusuario"))
                    HttpContext.Current.Session("usertransp") = HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.Cookies.Get("cevawms")("usertransp"))
                    HttpContext.Current.Session("permissao") = HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.Cookies.Get("cevawms")("permissao"))
                    HttpContext.Current.Session("permissao") = HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.Cookies.Get("cevawms")("permissao"))
                    'aCookie.Values("nomecliente") = HttpContext.Current.Session("nomecliente")
                    'aCookie.Values("enderecocliente") = HttpContext.Current.Session("enderecocliente")
                    'aCookie.Values("bairrocliente") = HttpContext.Current.Session("bairrocliente")
                    'aCookie.Values("cidadecliente") = HttpContext.Current.Session("cidadecliente")
                    'aCookie.Values("ufcliente") = HttpContext.Current.Session("ufcliente")
                    'aCookie.Values("paiscliente") = HttpContext.Current.Session("paiscliente")
                    'aCookie.Values("telefonecliente") = HttpContext.Current.Session("telefonecliente")
                    'aCookie.Values("logocliente") = HttpContext.Current.Session("logocliente")
                    'aCookie.Values("corpadrao") = HttpContext.Current.Session("corpadrao")
                Else
                    HttpContext.Current.Session("urlretorno") = HttpContext.Current.Request.Path


                    HttpContext.Current.Response.Redirect("login.aspx")
                End If
                Exit Sub
            Case Is = "erro"

                Exit Sub
        End Select


    End Sub
End Class
