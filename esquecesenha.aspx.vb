Imports System.Net.Mail
Imports System.Data
Imports System.IO

Partial Class restrito_esquecesenha
    Inherits BasePage
    Dim sql As String
    Private Function findSql(sql As String) As Data.DataTable
        Dim clabancopsql As New clabancopsql
        Return clabancopsql.conectar(sql)
    End Function
    Private Function persist(sql As String) As Data.DataTable
        Dim clabancopsql As New clabancopsql
        Return clabancopsql.IncluirAlterarDados(sql)
    End Function
    Private Sub btnentrar_Click(sender As Object, e As EventArgs) Handles btnentrar.Click
        If txtemail.Value = "" Then
            divalerta.Style.Remove("display")
            lblalerta.Text = "Por favor preencha o campo e-mail."
        Else
            sql = "select * from tbusuarios where email = '" & txtemail.value & "'"
            Dim tb As DataTable = findSql(sql)

            If tb.Rows.Count = 0 Then
                divalerta.Style.Remove("display")
                lblalerta.Text = "Não encontramos nenhum usuário com o e-mail informado"
            Else
                If tb.Rows(0)("ativo") = 0 Then
                    divalerta.Style.Remove("display")
                    lblalerta.Text = "O usuário que possui o e-mail informado esta desativado, por favor comunique o administrador para que ele ative seu usuário antes de realizar a recuperação de senha"
                Else
                    Dim token As String = GenerateToken(30, True)
                    Dim dataexpira = Date.Now.AddHours(24)
                    Dim usuario = tb.Rows(0)("nrseq").ToString
                    Dim nome = tb.Rows(0)("nome").ToString
                    Dim email As String = tb.Rows(0)("email").ToString
                    sql = "insert into tbrecuperasenha(token, expira, nrsequser) values('" & token & "', '" & dataexpira.ToString("yyyy-MM-dd hh:mm") & "', " & usuario & ")"
                    persist(sql)

                    enviaemail(token, nome, email)

                    divsucesso.Style.Remove("display")
                    divalerta.Style.Add("display", "none")
                    lblsucesso.Text = "Foi enviado no e-mail de alteração de senha"
                    txtemail.Value = ""

                End If
            End If
        End If
    End Sub

    Public Function GenerateToken(ByRef len As Integer, ByRef upper As Boolean) As String
        Dim rand As New Random()
        Dim allowableChars() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next

        Return IIf(upper, final.ToUpper(), final)
    End Function

    Public Function enviaemail(token As String, nome As String, email As String)

        Dim lermensagem As New StreamReader(Server.MapPath("~\restrito\emailrecuperasenha.html"))
        Dim html As String = lermensagem.ReadToEnd
        lermensagem.Close()


        Dim Mail As New MailMessage
        Mail.Subject = "Recuperação de Senha"
        Mail.To.Add(email)
        Mail.From = New MailAddress("noreply@smartcodesolucoes.com.br")

        Dim raiz As String = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath
        Dim link As String = raiz & "restrito/recuperasenha.aspx?i=" & token & ""

        html = html.Replace("{fulano}", nome).Replace("{linkrecupera}", link)
        Mail.Body = html.Replace("{fulano}", nome).Replace("{linkrecupera}", link)

        Dim SMTP As New SmtpClient("smtp.smartcodesolucoes.com.br")
        SMTP.Credentials = New System.Net.NetworkCredential("noreply@smartcodesolucoes.com.br", "Sousmart@747791")
        SMTP.Port = 587

        Try
            SMTP.Send(Mail)
        Catch ex As Exception

        End Try

    End Function
End Class
