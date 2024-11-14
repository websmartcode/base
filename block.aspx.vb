
Partial Class block
    Inherits BasePage

    Private Sub block_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete

    End Sub

    Private Sub block_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then Exit Sub
        Dim xip As New clsbloqueioips
        xip.Endereco = HttpContext.Current.Request.UserHostAddress
        xip.moostrarbloqueados()
        If xip.Tb1.Rows.Count = 0 Then
            '   Response.Redirect("login.aspx")
            '   Exit Sub
        End If
        rptitens.DataSource = xip.Tb1
        rptitens.DataBind()
        divcode.Style.Add("display", "none")
    End Sub

    Private Sub rptitens_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptitens.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lbl As Label = e.Item.FindControl("lbldtcad")
            lbl.Text = FormatDateTime(e.Item.DataItem("dtcad").ToString, DateFormat.ShortDate)
        End If
    End Sub

    Private Sub btnenviarpedido_Click(sender As Object, e As EventArgs) Handles btnenviarpedido.Click
        Dim xvalida As New clsrecuperasenha
        xvalida.Email = txtemail.Text
        If Not xvalida.EnviarCodigo() Then
            sm("swal({title: 'Atenção!',text: '" & xvalida.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")

            Exit Sub
        End If

        divcode.Style.Remove("display")
        divemail.Style.Add("display", "none")
    End Sub
    Private Sub sm(funcao As String, Optional nome As String = "")
        If nome = "" Then
            nome = funcao
        End If
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), nome, funcao, True)
    End Sub

    Private Sub btnvercode_Click(sender As Object, e As EventArgs) Handles btnvercode.Click
        Dim xvalida As New clsrecuperasenha
        xvalida.Email = txtemail.Text
        xvalida.Codigo = txtcode.Text
        If Not xvalida.ValidaCodigo() Then
            sm("swal({title: 'Atenção!',text: '" & xvalida.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")

            Exit Sub
        End If
        Response.Redirect("\login.aspx")
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Response.Redirect("\login.aspx")
    End Sub

    Private Sub rptitens_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptitens.ItemCommand

    End Sub
End Class
