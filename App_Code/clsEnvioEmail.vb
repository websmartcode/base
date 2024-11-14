Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports clsSmart

Public Class clsEnvioEmail
    Dim _emailenviado As Boolean = False
    Dim tentativas As Integer = 0
    Dim mensagem As New MailMessage
    Dim arquivos As Attachment
    Dim origem As MailAddress
    Dim destino As MailAddress
    Dim envio As New SmtpClient
    Dim log As StreamWriter
    Dim _usarssl As String
    Dim _mensagemerroemail As String
    Dim _local As String
    Dim _mypassword As String
    Dim _myuser As String
    Dim arquivosanexados(100) As String

    Dim _email As String
    Dim _destinatarios_email As New List(Of clsEnvioEmail)

    Dim _gravarinterno As Boolean = False
    Dim _usuariosistema As String = ""
    Public Sub New(xusuario As String)

    End Sub
    Public Sub New()
        _local = HttpContext.Current.Server.MapPath("~\logemails\logemail") & Directory.GetFiles(HttpContext.Current.Server.MapPath("~\logemails"), "*.log").Length + 1 & ".log"
        Try
            log = New StreamWriter(_local)
            log.WriteLine("Iniciou a montagem do email")

            mensagem.Attachments.Clear()
            mensagem.Bcc.Clear()
            mensagem.CC.Clear()
            mensagem.To.Clear()
        Catch ex As Exception
            Dim teste As String = ex.Message
        End Try
    End Sub

    Public Property AdicionaAssunto() As String
        Set(ByVal value As String)
            Dim valortemp As String = value
            Dim meuservidor As New clsbanco
            If meuservidor.servidor = "191.252.3.96" Then
                valortemp = "E-MAIL TEST! PLEASE IGNORE THIS MESSAGE! THANKS! " & valortemp
            End If
            log.WriteLine("Adicionou o assunto : " & value)
            mensagem.Subject = valortemp
        End Set
        Get
            Return mensagem.Subject
        End Get
    End Property
    Public Sub configpadrao()
        origem = New MailAddress("alertas@smartcodesolucoes.com.br")
        mensagem.From = origem
        _myuser = "alertas@smartcodesolucoes.com.br"
        _mypassword = "Sousmart@747791"
        envio.Port = 587
        envio.Host = "smartcodesolucoes.com.br"
        envio.UseDefaultCredentials = False
        envio.Credentials = New NetworkCredential(_myuser, _mypassword)
        log.WriteLine("Configurou as credenciais : usuario:" & _myuser & " senha: " & _mypassword)
    End Sub
    Public Property mensagemerro() As String
        Set(ByVal value As String)
            log.WriteLine("Apresentou erro :" & _mensagemerroemail)
            _mensagemerroemail = value
        End Set
        Get
            Return _mensagemerroemail
        End Get
    End Property


    Public WriteOnly Property responderpara() As String
        Set(ByVal value As String)
            log.WriteLine("Definiu o caminho de responder para : " & value)
            destino = New MailAddress(value)
            mensagem.ReplyToList.Add(destino)
        End Set

    End Property

    Public Sub Credenciais(ByVal myuser As String, ByVal mypassword As String, ByVal mydominio As String)
        _myuser = myuser
        _mypassword = mypassword
        envio.UseDefaultCredentials = False
        envio.Credentials = New NetworkCredential(myuser, mypassword)
        log.WriteLine("Configurou as credenciais : usuario:" & myuser & " senha: " & mypassword)
    End Sub
    Public WriteOnly Property ConfigPorta() As String
        Set(ByVal value As String)
            log.WriteLine("Configurou a porta : " & value)
            envio.Port = value
        End Set
    End Property
    Public WriteOnly Property AdicionaDestinatariosocultos() As String
        Set(ByVal value As String)
            If value IsNot Nothing AndAlso value.Contains("@") Then
                destino = New MailAddress(value)
                log.WriteLine("Adicionou destinatário oculto : " & value)
                mensagem.Bcc.Add(destino)
            End If
        End Set
    End Property
    Public WriteOnly Property usarSSL() As Boolean

        Set(ByVal value As Boolean)
            log.WriteLine("Usar SSL : " & IIf(value, "Sim", "Não"))
            If value = True Then

                '    envio.UseDefaultCredentials = True
                envio.EnableSsl = True
            Else
                log.WriteLine("Adicionou destinatário : " & value)
                '  envio.UseDefaultCredentials = True
                envio.EnableSsl = False
            End If
        End Set
    End Property
    Public Property emailenviado() As Boolean
        Set(ByVal value As Boolean)
            _emailenviado = value
        End Set
        Get
            Return _emailenviado
        End Get
    End Property



    Public WriteOnly Property ConfigSMTP() As String
        Set(ByVal value As String)
            log.WriteLine("Adicionou o config SMTP : " & value.ToLower)
            envio.Host = value.ToLower
            'client.UseDefaultCredentials = true;
            'client.EnableSsl = True

        End Set
    End Property
    Public Property AdicionaMensagem() As String
        Get
            Return mensagem.Body
        End Get
        Set(ByVal value As String)
            log.WriteLine("Adicionou a mensagem : " & value)
            mensagem.Body = value
        End Set

    End Property
    Public WriteOnly Property AdicionaAnexos() As String
        Set(ByVal value As String)
            'log.WriteLine("Adicionou o anexo : " & value)
            'For x As Integer = 0 To arquivosanexados.Count - 1
            '    If arquivosanexados(x) = "" OrElse arquivosanexados(x) Is Nothing Then
            '        arquivosanexados(x) = mARQUIVO(value)
            '        Try
            '            My.Computer.Network.UploadFile(value, "ftp://emails.smartcodesolucoes.com.br/logemails/" & mARQUIVO(value), "usrsmartftp", "Codesmart@747791")
            '        Catch ex As Exception
            '            Dim erro As String = ex.Message
            '        End Try

            '        Exit Property
            '    End If
            'Next
            'My.Computer.Network.UploadFile(value, "ftp://emails.smartcodesolucoes.com.br/logemails" & "/" & mARQUIVO(value), "usrsmartftp", "Codesmart@747791")
            Dim wcvalor As New Attachment(value)
            mensagem.Attachments.Add(wcvalor)
            'arquivosanexados.Add(value)
        End Set
    End Property
    Dim _QtdAnexos As Integer

    Public ReadOnly Property QtdAnexos() As Integer
        Get
            Return mensagem.Attachments.Count
        End Get

    End Property

    'Dim _listaanexos As List

    'Public ReadOnly Property QtdAnexos() As Integer
    '    Get
    '        Return mensagem.Attachments.Count
    '    End Get

    'End Property
    'w

    Public WriteOnly Property AdicionaDestinatarios() As String
        Set(ByVal value As String)
            If value IsNot Nothing AndAlso value.Contains("@") Then
                Try
                    log.WriteLine("Adicionou o destinatário : " & value)
                    destino = New MailAddress(value)
                    mensagem.To.Add(destino)
                Catch ex As Exception

                End Try

            End If
        End Set
    End Property
    Public WriteOnly Property AdicionarCopiaPara() As String
        Set(ByVal value As String)
            log.WriteLine("Adicionou o destinatário cópia : " & value)
            destino = New MailAddress(value)
            mensagem.CC.Add(destino)
        End Set
    End Property
    Public Property EhHTML() As Boolean
        Set(ByVal value As Boolean)

            'log = New StreamWriter(_local)
            log.WriteLine("O e-mail é HTML ? " & IIf(value, "Sim", "Não"))
            mensagem.IsBodyHtml = value
        End Set
        Get
            Return mensagem.IsBodyHtml
        End Get
    End Property
    Public WriteOnly Property AdicionaRemetente() As String
        Set(ByVal value As String)
            log.WriteLine("Adicionou o remetente : " & value)
            origem = New MailAddress(value)
            mensagem.From = origem
        End Set
    End Property

    Public Property Destinatarios_email As List(Of clsEnvioEmail)
        Get
            Return _destinatarios_email
        End Get
        Set(value As List(Of clsEnvioEmail))
            _destinatarios_email = value
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

    Public Property Gravarinterno As Boolean
        Get
            Return _gravarinterno
        End Get
        Set(value As Boolean)
            _gravarinterno = value
        End Set
    End Property

    Public Property Usuariosistema As String
        Get
            Return _usuariosistema
        End Get
        Set(value As String)
            _usuariosistema = value
        End Set
    End Property

    Public Function EnviarEmail(Optional email As String = "") As Boolean

        emailenviado = False
        Dim resultado As Boolean = False
        envio.Port = 587
novamente:
        Try
            envio.Send(mensagem)
            emailenviado = True
            log.WriteLine("E-mail enviado !")
        Catch ex As ArgumentException
            log.WriteLine("E-mail não enviado ! (" & ex.Message & ")")
            mensagemerro = ex.Message
            emailenviado = False
        Catch ex2 As InvalidOperationException
            log.WriteLine("E-mail não enviado ! (" & ex2.Message & ")")
            mensagemerro = ex2.Message
        Catch ex3 As SmtpException
            log.WriteLine("E-mail não enviado ! (" & ex3.Message & ")")
            mensagemerro = ex3.Message
            emailenviado = False
        End Try

        If (emailenviado AndAlso Gravarinterno) AndAlso Usuariosistema <> "" Then
            Dim xmens As New clscaixamensagens
            xmens.Remetente = Usuariosistema
            xmens.Origemdeemailenviado = True
            xmens.Assunto = AdicionaAssunto
            xmens.Corpo = AdicionaMensagem

            For x As Integer = 0 To mensagem.Attachments.Count - 1
                Dim xdocs As New clscaixamensagens_anexos
                xdocs.Arquivo = mensagem.Attachments(x).Name
                xdocs.Caminho = HttpContext.Current.Server.MapPath("~") & "\arquivos\temp"
                xdocs.Nrseqmensagem = -1
                xmens.anexos.Add(xdocs)
            Next
            For x As Integer = 0 To mensagem.To.Count - 1
                Dim xdest As New clscaixamensagens_destinatarios
                xdest.Usuario = mensagem.To(x).Address
                xmens.destinatarios.Add(xdest)
            Next
            For x As Integer = 0 To mensagem.CC.Count - 1
                Dim xdest As New clscaixamensagens_destinatarios
                xdest.Usuario = mensagem.To(x).Address
                xmens.destinatarios.Add(xdest)
            Next

            xmens.enviar()
        End If

        log.WriteLine("Resultado do envio: " & IIf(emailenviado, "Enviado", "Não enviado:" & mensagemerro))
        log.Close()
        Return emailenviado
    End Function
End Class
