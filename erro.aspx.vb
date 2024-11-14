Imports clsSmart
Partial Class erro
    Inherits BasePage

    Private Sub erro_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then Exit Sub
        hdopcao.Value = Session("opcao")
        hdsql.Value = Session("sql")
        hdvoltar.Value = Session("voltar")
        txtmensagem.Text = Session("erro")
        If hdopcao.Value = "Não" Then btnretentar.Text = "Voltar"

    End Sub

    Private Sub btnretentar_Click(sender As Object, e As EventArgs) Handles btnretentar.Click

        'Dim xteste As New List(Of clsPropostas_itens_valorespreenchidos)

        'xteste.Add(New clsPropostas_itens_valorespreenchidos With {.Campo = "c"})
        'xteste.Add(New clsPropostas_itens_valorespreenchidos With {.Campo = "z"})
        'xteste.Add(New clsPropostas_itens_valorespreenchidos With {.Campo = "b"})
        'xteste.Add(New clsPropostas_itens_valorespreenchidos With {.Campo = "a"})
        'xteste.Add(New clsPropostas_itens_valorespreenchidos With {.Campo = "d"})

        'Dim orderByResult = From s In xteste
        '                    Order By s.Campo
        '                    Select s

        'Dim orderByDescendingResult = From s In xteste
        '                              Order By s.Campo Descending
        '                              Select s

        'Console.WriteLine("Ascending Order")

        'For Each stud As clsPropostas_itens_valorespreenchidos In orderByResult
        '    txtmensagem.Text &= (stud.Campo & Environment.NewLine)

        'Next

        Exit Sub


        If btnretentar.Text = "Voltar" Then
            Response.Redirect(hdvoltar.Value)
        Else
            Dim tb1 As New Data.DataTable
            Dim tab1 As New clabancopsql
            tb1 = tab1.IncluirAlterarDados(hdsql.Value)


            Dim envio As New clsEnvioEmail
            envio.configpadrao()
            envio.AdicionaDestinatarios = "suporte@smartcodesolucoes.com.br"
            envio.AdicionaDestinatarios = "claudiosmart@smartcodesoluces.com.br"
            envio.AdicionaAssunto = "Erro sistema QuoteSystem - " & data() & " / " & hora()
            envio.EhHTML = True
            Dim xmensagem As String = "<html>"

            xmensagem &= "<br> <Center> <img src=""http://www.smartcodesolucoes.com.br/img/simbolo.jpg"" width=""37px"" height=""32px""> <br> "
            xmensagem &= "<span color=red> Relatório de erros </span> </center> <br>"
            xmensagem &= "<hr>"
            xmensagem &= "<br> Usuário:" & HttpContext.Current.Session("usuario")
            xmensagem &= "<br> Email:" & HttpContext.Current.Session("email")
            xmensagem &= "<br> O comando foi processado com sucesso depois de apresentado o erro !"
            xmensagem &= "<br> Página: " & HttpContext.Current.Request.Url.AbsoluteUri(HttpContext.Current.Request.Url.Segments.Count - 1)
            xmensagem &= "<br> Expressão: " & hdsql.Value

            xmensagem &= "</html>"

            envio.AdicionaMensagem = xmensagem
            If envio.EnviarEmail Then
            End If

            Response.Redirect(hdvoltar.Value)

        End If
    End Sub
End Class
