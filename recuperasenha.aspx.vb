Imports System.Net.Mail
Imports System.Data
Imports System.IO
Imports System.Security.Cryptography

Partial Class restrito_recuperasenha
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


    Private Sub restrito_recuperasenha_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("token") = Request.QueryString("i")

        sql = "select * from tbrecuperasenha where token = '" & Session("token") & "'"
        Dim tb As DataTable = findSql(sql)

        If tb.Rows.Count = 0 Then
            formlogin.Style.Add("display", "none")
            divErro.Style.Remove("display")
            lblerro.Text = "Não foi possivel encontrar o token informado"
        Else
            If tb.Rows(0)("utilizado") = 1 Then
                formlogin.Style.Add("display", "none")
                divErro.Style.Remove("display")
                lblerro.Text = "Esse token já foi utilizado"
            Else
                Dim dataexpira As DateTime = Convert.ToDateTime(tb.Rows(0)("expira"))
                Dim datahoje = DateTime.Now

                Dim result = Date.Compare(dataexpira, datahoje)

                If result <> 1 Then
                    formlogin.Style.Add("display", "none")
                    divErro.Style.Remove("display")
                    lblerro.Text = "Esse token expirou por favor faça novamente uma solicitação de recuperação de senha, <a href='esquecesenha.aspx'>Clique Aqui</a>"
                End If
            End If
        End If
    End Sub

    Public Shared Function GenerateSHA512String(ByVal inputString) As String
        Dim sha512 As SHA512 = SHA512Managed.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputString)
        Dim hash As Byte() = sha512.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()

        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next

        Return stringBuilder.ToString()
    End Function

    Private Sub btnentrar_Click(sender As Object, e As EventArgs) Handles btnentrar.Click
        sql = "select * from tbrecuperasenha where token = '" & Session("token") & "'"
        Dim tb As DataTable = findSql(sql)

        If tb.Rows.Count = 0 Then
            formlogin.Style.Add("display", "none")
            divErro.Style.Remove("display")
            lblerro.Text = "Não foi possivel encontrar o token informado"
        Else
            If tb.Rows(0)("utilizado") = 1 Then
                formlogin.Style.Add("display", "none")
                divErro.Style.Remove("display")
                lblerro.Text = "Esse token já foi utilizado"
            Else
                Dim dataexpira As DateTime = Convert.ToDateTime(tb.Rows(0)("expira"))
                Dim datahoje = DateTime.Now

                Dim result = Date.Compare(dataexpira, datahoje)

                If result <> 1 Then
                    formlogin.Style.Add("display", "none")
                    divErro.Style.Remove("display")
                    lblerro.Text = "Esse token expirou por favor faça novamente uma solicitação de recuperação de senha, <a href='esquecesenha.aspx'>Clique Aqui</a>"
                Else
                    If txtsenha.Value <> txtconfirma.Value Then
                        divalerta.Style.Remove("display")
                        lblalerta.Text = "As senhas devem iguais"
                    Else
                        Dim senha As String = GenerateSHA512String(txtsenha.Value)

                        sql = "update tbusuarios set senha = '" & senha & "' where nrseq = " & tb.Rows(0)("nrsequser") & ""
                        persist(sql)

                        sql = "update tbrecuperasenha set utilizado = true where nrseq = " & tb.Rows(0)("nrseq") & ""
                        persist(sql)

                        formlogin.Style.Add("display", "none")
                        divsucesso.Style.Remove("display")
                        lblsucesso.Text = "Senha alterada com sucesso, <a href='index.aspx'>Fazer Login</a>"
                    End If
                End If
            End If
        End If
    End Sub
End Class
