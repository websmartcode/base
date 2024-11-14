Imports clsSmart
Partial Class desbloqueiosip
    Inherits BasePage

    Private Sub desbloqueiosip_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then Exit Sub

        Dim xips As New clsbloqueioips
        xips.Filtrar_ativos = True
        xips.Listarbloqueioips()
        rptitens.DataSource = xips.Listaclasse
        rptitens.DataBind()

    End Sub

    Private Sub rptitens_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptitens.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim lbldtcad As Label = e.Item.FindControl("lbldtcad")
            lbldtcad.Text = FormatDateTime(valordata(lbldtcad.Text), DateFormat.ShortDate)
        End If
    End Sub
    Private Sub sm(funcao As String, Optional nome As String = "")
        If nome = "" Then
            nome = funcao
        End If
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), nome, funcao, True)
    End Sub
    Private Sub rptitens_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptitens.ItemCommand
        Dim xips As New clsbloqueioips
        Dim hdnrseqrpt As HiddenField = e.Item.FindControl("hdnrseqrpt")
        If e.CommandName = "ok" Then
            xips.Nrseq = hdnrseqrpt.Value
            If Not xips.desbloquearIP Then
                sm("swal({title: Atenção!,text: '" & xips.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")
                Exit Sub
            End If
            xips.Filtrar_ativos = True
            xips.Listarbloqueioips()
            rptitens.DataSource = xips.Listaclasse
            rptitens.DataBind()
        End If
    End Sub
End Class
