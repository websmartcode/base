
Partial Class aviso
    Inherits BasePage

    Private Sub aviso_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then Exit Sub
        txtexemplo.InnerText = Request.QueryString("mensagem")
    End Sub

    Private Sub btnvoltar_Click(sender As Object, e As EventArgs) Handles btnvoltar.Click
        Response.Redirect("default.aspx")
    End Sub
End Class
