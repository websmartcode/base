Imports clssessoes
Imports clsSmart
Imports System.Data.Common.CommandTrees.ExpressionBuilder
Imports System.IO

Partial Class usuarios
    Inherits BasePage
    Dim tbusers As New Data.DataTable
    Dim tabusers As New clabancopsql

    Private Sub usuarios_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If

        Dim xpermissoes As New clspermissoes
        xpermissoes.Listarpermissoes()
        cboPermissao.Items.Add("")
        cboPermissao.Items(0).Value = 0
        For x As Integer = 0 To xpermissoes.Listaclasse.Count - 1
            cboPermissao.Items.Add(xpermissoes.Listaclasse(x).Descricao)
            cboPermissao.Items(cboPermissao.Items.Count - 1).Value = xpermissoes.Listaclasse(x).Nrseq
        Next

        Dim xempresas As New clsempresas
        xempresas.Listarempresas()
        cboempresas.Items.Add("")
        cboempresas.Items(cboempresas.Items.Count - 1).Value = 0

        'cbounidades.Items.Add("")
        'cbounidades.Items(cbounidades.Items.Count - 1).Value = 0

        cboempresaprocura.Items.Add("")
        cboempresaprocura.Items(cboempresaprocura.Items.Count - 1).Value = 0

        For em As Integer = 0 To xempresas.Listaclasse.Count - 1
            cboempresaprocura.Items.Add(xempresas.Listaclasse(em).Nomefantasia)
            cboempresaprocura.Items(cboempresaprocura.Items.Count - 1).Value = xempresas.Listaclasse(em).Nrseq

            cboempresas.Items.Add(xempresas.Listaclasse(em).Nomefantasia)
            cboempresas.Items(cboempresaprocura.Items.Count - 1).Value = xempresas.Listaclasse(em).Nrseq

            'For u As Integer = 0 To xempresas.Listaclasse(em).Listaunidades.Count - 1
            '    cbounidades.Items.Add(xempresas.Listaclasse(em).Listaunidades(u).Nomeunidade)
            '    cbounidades.Items(cbounidades.Items.Count - 1).Value = xempresas.Listaclasse(em).Listaunidades(u).Nrseq
            'Next
        Next

        Dim xclasse As New clsusuarios_empresas
        xclasse.Filtro_nrsequsuario = texthide.Value

        carregagrade()
        btnnovo.Visible = True
        btnSalvar.Visible = False
        btncancelar.Visible = False
        habilitar(False)
    End Sub
    Private Sub sm(funcao As String, Optional nome As String = "")
        If nome = "" Then
            nome = funcao
        End If
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), nome, funcao, True)
    End Sub
    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Dim a = cbounidades.Items.Count

        If Not entradaTextoValida(txtusuario.Text) Or Not entradaTextoValida(txtemail.Text) Or cboPermissao.Text = "" Or cboempresas.SelectedIndex = 0 Then
            sm("swal({title: 'Atenção!',text: 'preencha todos os campos para criar o registro!',type: 'error',confirmButtonText: 'OK'})", "swal")
            Exit Sub
        End If

        Dim xclasse As New clsusuarios
        If hdnovousuario.Value = "sim" Then
            xclasse.Filtro_multiplo.Usuario = txtusuario.Text
            xclasse.Filtro_multiplo.Email = txtemail.Text
            'xclasse.Filtro_email = txtemail.Text
            xclasse.Listarusuarios()
            If xclasse.Listaclasse.Count > 0 Then
                sm("swal({title: 'Atenção!',text: 'Esse usuário ou e-mail já foram cadastrados no sistema!',type: 'error',confirmButtonText: 'OK'})", "swal")
                Exit Sub
            End If
        End If


        xclasse.Nrseq = hdnnrseq.Value
        xclasse.Usuario = txtusuario.Text
        If hdnovousuario.Value = "sim" Then
            Dim xsenha As New clsgeradorsenhas
            xsenha.Gerar()
            xclasse.Senha = tratatexto(AES_Encrypt(xsenha.Novasenha, "CodeSmart@9898"), True)
        End If
        xclasse.Descricaopermissao = cboPermissao.Text
        xclasse.Email = txtemail.Text
        xclasse.Alterado = True
        xclasse.Master = chkmaster.Checked
        xclasse.Dtalterado = hoje()
        xclasse.Useralterado = Session("usuario")
        xclasse.Hralterado = DateTime.Now.TimeOfDay.ToString
        xclasse.Email_notificar = chknotificaremail.Checked
        xclasse.Whats_notificar = chknotificarcelular.Checked
        xclasse.Celular = txtcelular.Text
        xclasse.Dtvalidadesenha = data().AddMonths(3)
        If Not xclasse.salvar(True) Then
            sm("swal({title: 'Atenção!',text: '" & xclasse.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")
            Exit Sub
        Else
            avisosButton("salvar")
        End If

        If hdnovousuario.Value = "sim" Then
            If Not xclasse.enviarsenhaemail(hdnnrseq.Value) Then
                sm("swal({title: 'Atenção!',text: '" & xclasse.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")
                limpar()
                habilitar(False)
                carregagrade()
                btnSalvar.Visible = False
                btnnovo.Visible = True
                Exit Sub
            Else
                avisosButton("senhaenviada")
            End If
        End If

        limpar()
        habilitar(False)
        carregagrade()
        btnSalvar.Visible = False
        btnnovo.Visible = True

    End Sub
    Private Sub carregagrade()
        Dim xuser As New clsusuarios
        xuser.Filtro_nrseqempresa = numeros(Session("nrseqempresa"))
        xuser.Filtro_usuario = txtpesquisar.Text
        xuser.Filtro_ativo = chkexibirativos.Checked
        xuser.Filtro_master = chkfiltro_master.Checked
        xuser.Filtro_suspensos = chkexibirsuspensos.Checked
        xuser.Filtro_excluidos = chkexibirinativos.Checked

        If xuser.Filtro_ativo Or xuser.Filtro_master Or xuser.Filtro_suspensos Or xuser.Filtro_excluidos Then
            xuser.Listarusuarios(0)
            grade.DataSource = xuser.Listaclasse.Where(Function(x) x.Usuario <> "").OrderBy(Function(x) x.Usuario)
        End If

        grade.DataBind()
    End Sub
    Private Sub habilitar(valor As Boolean)
        cboempresas.Enabled = valor
        btnaddempresa.Enabled = valor
        chknotificaremail.Enabled = valor
        chknotificarcelular.Enabled = valor
        cboPermissao.Enabled = valor
        txtemail.Enabled = valor
        btnSalvar.Visible = valor
        btncancelar.Visible = valor
        btnnovo.Visible = Not valor
        txtusuario.Enabled = False
        chkmaster.Enabled = valor
        txtcelular.Enabled = valor
        cboempresas.Enabled = valor
        cbounidades.Enabled = valor
    End Sub
    Private Sub limpar()
        hdnnrseq.Value = ""
        txtusuario.Text = ""
        cboempresas.SelectedIndex = 0
        cbounidades.Items.Clear()
        divunidades.Visible = False
        txtemail.Text = ""
        cboPermissao.SelectedIndex = 0
        chkmaster.Checked = False
        chknotificarcelular.Checked = False
        chknotificaremail.Checked = False
        txtcelular.Text = ""
        rptempresasunidades.DataSource = Nothing
        rptempresasunidades.DataBind()

    End Sub

    Private Sub Grade_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grade.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = grade.Rows(index)
        Dim hdnrseqgrade As HiddenField = grade.Rows(index).FindControl("hdnrseqgrade")
        Dim lblusuariograde As Label = grade.Rows(index).FindControl("lblusuariograde")
        Dim lblemailgrade As Label = grade.Rows(index).FindControl("lblemailgrade")
        Dim xempresas As New clsusuarios_empresas
        xempresas.Filtro_nrsequsuario = hdnrseqgrade.Value
        texthide.Value = hdnrseqgrade.Value

        Select Case e.CommandName.ToLower.Trim()
            Case Is = "editar"

                Dim xclasse As New clsusuarios
                xclasse.Nrseq = hdnrseqgrade.Value

                If Not xclasse.procurar() Then
                    sm("swal({title: 'Atenção!',text: '" & xclasse.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")
                    Exit Sub
                Else
                    avisosButton("procurar")
                End If
                hdnrsequsuario.Value = hdnrseqgrade.Value
                txtusuario.Text = xclasse.Usuario
                txtemail.Text = xclasse.Email
                cboPermissao.Text = If(cboPermissao.Items.FindByValue(xclasse.Nrseqpermissao) IsNot Nothing, xclasse.Nrseqpermissao, 0)
                hdnnrseq.Value = xclasse.Nrseq

                xempresas.Listarusuarios_empresas()
                rptempresasunidades.DataSource = xempresas.Listaclasse()
                rptempresasunidades.DataBind()

                txtusuario.Enabled = False
                cboempresas.Enabled = True
                btnaddempresa.Enabled = True
                cboPermissao.Enabled = True
                cbounidades.Enabled = True
                btnSalvar.Enabled = True
                btnSalvar.Visible = True

            Case Is = "master"
                Dim hdusergrade As HiddenField = row.FindControl("hdusergrade")
                Dim imgusergrade As Object = row.FindControl("imgusergrade")
                Dim btnmaster As LinkButton = row.FindControl("btnmaster")
                imgusergrade.Attributes.remove("class")
                If logico(hdusergrade.Value) = "True" Then
                    imgusergrade.Attributes.add("class", "fa fa-user-secret")
                    hdusergrade.Value = 0
                Else
                    imgusergrade.Attributes.add("class", "fa fa-user-circle-o")
                    hdusergrade.Value = 1
                End If

                Dim xusuario As New clsusuarios
                xusuario.Nrseq = hdnrseqgrade.Value
                xusuario.Master = logico(hdusergrade.Value)
                xusuario.SalvarMaster()

                Exit Sub
            Case Is = "recuperarsenha"
                Dim xusuarios As New clsusuarios
                If xusuarios.RecuperarSenha(hdnrseqgrade.Value) Then
                    sm("swal({title: 'Que Bom!',text: '" & xusuarios.Mensagemerro & "',type: 'success',confirmButtonText: 'OK'})", "swal")
                Else
                    sm("swal({title: 'Atenção!',text: '" & xusuarios.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")
                End If
                Exit Sub

            Case Is = "excluir"
                Dim xclasse As New clsusuarios
                xclasse.Nrseq = hdnrseqgrade.Value
                If Not xclasse.excluir() Then
                    sm("swal({title: 'Atenção!',text: '" & xclasse.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")
                    Exit Sub
                Else
                    avisosButton("excluir")
                End If

                carregagrade()

                If e.CommandSource.ID = "btnexcluirgrade" Then
                    avisosButton("excluir")
                ElseIf e.CommandSource.ID = "btnreativar" Then
                    avisosButton("itemreativado")
                End If

                xempresas.Listarusuarios_empresas()
                rptempresasunidades.DataSource = xempresas.Listaclasse()
                rptempresasunidades.DataBind()
        End Select

    End Sub

    Private Sub chkexibirinativos_CheckedChanged(sender As Object, e As EventArgs) Handles chkexibirinativos.CheckedChanged, chkexibirativos.CheckedChanged, chkexibirsuspensos.CheckedChanged, chkfiltro_master.CheckedChanged
        carregagrade()
    End Sub

    Private Sub Grade_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grade.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Dim rptpaisesgrade As Repeater = e.Row.FindControl("rptpaisesgrade")
            Dim hdusergrade As HiddenField = e.Row.FindControl("hdusergrade")
            Dim hdwhats_notificargrade As HiddenField = e.Row.FindControl("hdwhats_notificargrade")
            Dim hdemail_notificargrade As HiddenField = e.Row.FindControl("hdemail_notificargrade")
            Dim hdnativo As HiddenField = e.Row.FindControl("hdnativo")
            Dim hdnsuspenso As HiddenField = e.Row.FindControl("hdnsuspenso")
            Dim imgusergrade As Object = e.Row.FindControl("imgusergrade")
            Dim btnmaster As LinkButton = e.Row.FindControl("btnmaster")
            Dim divwhats_notifgrade As Object = e.Row.FindControl("divwhats_notifgrade")
            Dim divemail_notifgrade As Object = e.Row.FindControl("divemail_notifgrade")
            Dim divnotificagrade As Object = e.Row.FindControl("divnotificagrade")
            Dim divempresasgrade As Object = e.Row.FindControl("divempresasgrade")
            Dim rptempresasgrade As Repeater = e.Row.FindControl("rptempresasgrade")
            Dim lblpermissao As Label = e.Row.FindControl("lblpermissao")
            Dim btnreativar As LinkButton = e.Row.FindControl("btnreativar")
            Dim btnalterargrade As LinkButton = e.Row.FindControl("btnalterargrade")
            Dim btnexcluirgrade As LinkButton = e.Row.FindControl("btnexcluirgrade")
            Dim btnrecuperarsenha As LinkButton = e.Row.FindControl("btnrecuperarsenha")
            imgusergrade.Attributes.remove("class")
            btnmaster.Attributes.Remove("class")

            btnexcluirgrade.Visible = hdnativo.Value = "True" Or hdnsuspenso.Value = 1
            btnalterargrade.Visible = hdnativo.Value = "True" Or hdnsuspenso.Value = 1
            btnrecuperarsenha.Visible = hdnativo.Value = "True" Or hdnsuspenso.Value = 1
            btnreativar.Visible = hdnativo.Value = "False"

            If hdnativo.Value = "False" Then
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff9292")
            End If
            If hdnsuspenso.Value = 1 Then
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffc5ff")
            End If
            If lblpermissao.Text = "Master" Then
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffd17d")
            End If
            If logico(hdusergrade.Value) = "True" Then
                ' btnaddpais.Attributes
                imgusergrade.Attributes.add("class", "fa fa-user-circle-o")
                btnmaster.Attributes.Add("class", "btn btn-danger  btn-xs")
                'divnotificagrade.style.remove("display")
                If logico(hdemail_notificargrade.Value) = "True" Then
                    divemail_notifgrade.style.add("background-color", "gold")
                End If
                If logico(hdwhats_notificargrade.Value) = "True" Then
                    divwhats_notifgrade.style.add("background-color", "gold")
                End If
            Else
                imgusergrade.Attributes.add("class", "fa fa-user-secret")
                btnmaster.Attributes.Add("class", "btn btn-primary  btn-xs")
                'divnotificagrade.style.add("display", "none")
            End If
            If Not Session("usuariomaster") = "Sim" Then
                btnmaster.Visible = False
            End If

            Dim xclasse As New clsusuarios
            Dim xempresas As New clsusuarios_empresas
            xclasse = CType(e.Row.DataItem, clsusuarios)

            rptempresasgrade.DataSource = xclasse.Listaempresas.OrderBy(Function(x) x.Usuario)
            rptempresasgrade.DataBind()

            If xclasse.Listaempresas.Count > 0 Then
                'divempresasgrade.style.remove("display")
            End If
        End If
    End Sub
    Private Sub btnnovo_Click(sender As Object, e As EventArgs) Handles btnnovo.Click
        Dim xclasse As New clsusuarios
        xclasse.Usercad = Session("usuario")
        xclasse.Dtcad = hoje()

        If Not xclasse.novo() Then
            sm("swal({title: 'Atenção!',text: '" & xclasse.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")
            Exit Sub
        Else
            avisosButton("itemnovo")
        End If
        hdnovousuario.Value = "sim"
        hdnnrseq.Value = xclasse.Nrseq
        hdnrsequsuario.Value = xclasse.Nrseq
        habilitar(True)
        txtusuario.Enabled = True
    End Sub

    Private Sub btnpesquisar_Click(sender As Object, e As EventArgs) Handles btnpesquisar.Click
        carregagrade()
    End Sub

    Private Sub cboempresas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboempresas.SelectedIndexChanged
        cbounidades.Items.Clear()
        divunidades.Visible = False
        If cboempresas.SelectedIndex <> 0 Then
            Dim xempresas As New clsempresas_unidades
            xempresas.Filtro_nrseqempresa = cboempresas.SelectedValue
            xempresas.Listarempresas_unidades()

            'divunidades.Style.Remove("display")
            cbounidades.Items.Add("")

            cbounidades.Items(cbounidades.Items.Count - 1).Value = 0
            For u As Integer = 0 To xempresas.Listaclasse.Count - 1
                cbounidades.Items.Add(xempresas.Listaclasse(u).Nomeunidade)
                cbounidades.Items(cbounidades.Items.Count - 1).Value = xempresas.Listaclasse(u).Nrseq
            Next
            divunidades.Visible = xempresas.Listaclasse.Count > 0
        End If

    End Sub

    Private Sub btnaddempresa_Click(sender As Object, e As EventArgs) Handles btnaddempresa.Click

        If numeros(hdnnrseq.Value) = 0 Then
            sm("swal({title: 'Atenção!',text: 'Informe um nome de usuário!',type: 'error',confirmButtonText: 'OK'})", "swal")
            Exit Sub
        End If
        If cboempresas.SelectedItem.Text = "" Then
            sm("swal({title: 'Atenção!',text: 'Informe uma empresa!',type: 'error',confirmButtonText: 'OK'})", "swal")
            Exit Sub
        End If
        If cbounidades.SelectedItem.Text = "" Then
            sm("swal({title: 'Atenção!',text: 'Informe uma unidade!',type: 'error',confirmButtonText: 'OK'})", "swal")
            Exit Sub
        End If

        Dim xempresas As New clsusuarios_empresas
        xempresas.nrsequsuario = numeros(hdnrsequsuario.Value)
        xempresas.nrseqempresa = numeros(cboempresas.SelectedItem.Value)
        xempresas.salvar(True, True)

        If cbounidades.Text <> "" Then
            Dim xunidades As New clsusuarios_empresas_unidades
            xunidades.Nrsequnidade = cbounidades.SelectedItem.Value
            xunidades.Nrsequsuariosempresas = xempresas.Nrseq
            xunidades.salvar(True, True)
        End If

        xempresas.Filtro_nrsequsuario = hdnnrseq.Value
        xempresas.Listarusuarios_empresas()
        rptempresasunidades.DataSource = xempresas.Listaclasse
        rptempresasunidades.DataBind()
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        btnnovo.Visible = True
        btncancelar.Visible = False
        btnSalvar.Visible = False
        limpar()
        habilitar(False)
    End Sub

    Private Sub cboempresaprocura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboempresaprocura.SelectedIndexChanged
        Dim xnova As New clsempresas_unidades
        xnova.Filtro_nrseqempresa = 0
        xnova.Listarempresas_unidades()

    End Sub

    Private Sub rptempresasunidades_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptempresasunidades.ItemCommand
        Dim xempresas As New clsusuarios_empresas
        Dim hdnrseqacao As HiddenField = e.Item.FindControl("hdnrseqacao")

        xempresas.Filtro_nrseq = hdnrseqacao.Value
        xempresas.Listarusuarios_empresas()
        Select Case e.CommandName.ToLower.Trim()
            Case Is = "excluir"
                xempresas.Nrseq = hdnrseqacao.Value
                If Not xempresas.excluir() Then
                    sm("swal({title: 'Atenção!',text: '" & xempresas.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")
                    Exit Sub
                Else
                    avisosButton("excluir")
                End If
                xempresas.Filtro_nrseq = hdnrseqacao.Value
                xempresas.Listarusuarios_empresas()
                rptempresasunidades.DataSource = xempresas.Listaclasse
                rptempresasunidades.DataBind()
        End Select
    End Sub

    Private Sub rptempresasunidades_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptempresasunidades.ItemDataBound
        If e.Item.ItemType = DataControlRowType.DataRow Then
            Dim rptunidadesrptt As Repeater = e.Item.FindControl("rptunidadesrptt")
            Dim lblitemrpt As Label = e.Item.FindControl("lblitemrpt")
            Dim hdnrseqacaounidades As HiddenField = e.Item.FindControl("hdnrseqacaounidades")
            Dim xempresas As New clsusuarios_empresas
            xempresas.Listarusuarios_empresas()
            For em As Integer = 0 To xempresas.Listaclasse.Count - 1
                For u As Integer = 0 To xempresas.Listaempresas_unidades.Count - 1
                    rptunidadesrptt.DataSource = xempresas.Listaclasse(em).Listaempresas_unidades(u).Nomeunidade
                    rptunidadesrptt.DataBind()
                Next
            Next
            lblitemrpt.Text = rptempresasunidades.Items.Count
        End If
    End Sub
End Class
