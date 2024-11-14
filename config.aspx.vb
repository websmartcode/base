Imports clsSmart
Imports System.IO
Partial Class config
    Inherits BasePage

    Private Sub config_Load(sender As Object, e As EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "aplicarMascaraNosInputs();", True)
        If IsPostBack Then Exit Sub
        carregarzona()
        Dim xconf As New clsconfig
        xconf.carregar()

        txtnomecliente.Text = xconf.Nomecliente
        txtenderecocliente.Text = xconf.Endereco
        txtcep.Text = xconf.Cep
        txtcnpjcliente.Text = xconf.Cnpj
        txtbairrocliente.Text = xconf.Bairro
        txtcidadecliente.Text = xconf.Cidade
        txtpaiscliente.Text = xconf.Pais
        txttelefonecliente.Text = xconf.Telefone
        txtufcliente.Text = xconf.Uf

        cbotime.Text = xconf.Utc
        calculautcexemplo()

        If File.Exists(Server.MapPath("~") & "social\" & xconf.Logo) Then
            imglogocliente.ImageUrl = Request.Url.OriginalString.Replace(Request.Path, "/social/" & xconf.Logo)
            Dim xred As New clsredimensiona
            xred.Max = 11
            xred.Arquivo = (Server.MapPath("~") & "social\" & xconf.Logo)

            If xred.redimensionar Then
                imglogocliente.Style.Remove("height")
                imglogocliente.Style.Remove("width")
                imglogocliente.Style.Add("height", xred.Novaaltura & "rem")
                imglogocliente.Style.Add("width", xred.Novalargura & "rem")
            End If
        End If


        Dim xemail As New clsconfig_emails
        xemail.Listarconfig_emails()
        cboenvioemail.Items.Add("(Padrão)")
        For x As Integer = 0 To xemail.Listaclasse.Count - 1
            cboenvioemail.Items.Add(xemail.Listaclasse(x).Usuario)
        Next

        'txtnomecliente.Text = TimeZone.CurrentTimeZone.DaylightName & " - " & TimeZone.CurrentTimeZone.StandardName
        Dim dateNow As Date = Date.Now
        ' Console.WriteLine("The date and time are {0} UTC.",
        'TimeZoneInfo.ConvertTimeToUtc(dateNow))
        'txtnomecliente.Text = "UTC:" & TimeZoneInfo.ConvertTimeToUtc(dateNow).TimeOfDay.ToString
        Dim xtags As New clsconfig_padroes
        rpttags.DataSource = xtags.listatags
        rpttags.DataBind()

    End Sub
    Public Sub carregarzona()
        cbotime.Items.Add("")
        For Each x As TimeZoneInfo In TimeZoneInfo.GetSystemTimeZones
            cbotime.Items.Add(x.Id)
        Next
    End Sub
    Private Sub btnsalvarconfig_Click(sender As Object, e As EventArgs) Handles btnsalvarconfig.Click
        Dim xconf As New clsconfig
        xconf.Utc = cbotime.Text
        If Not xconf.salvar() Then
            sm("swal({title: 'Sorry!',text: '" & xconf.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")
            Exit Sub
        Else
            avisosButton("salvar")
        End If
        sm("swal({title: 'Very Good!',text: '" & xconf.Mensagemerro & "',type: 'success',confirmButtonText: 'OK'})", "swal")

    End Sub
    Private Sub sm(funcao As String, Optional nome As String = "")
        If nome = "" Then
            nome = funcao
        End If
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), nome, funcao, True)
    End Sub
    Private Sub calculautcexemplo()
        Dim dateNow As Date = Date.Now
        ' Console.WriteLine("The date and time are {0} UTC.",
        'TimeZoneInfo.ConvertTimeToUtc(dateNow))
        txtutctime.Text = TimeZoneInfo.ConvertTimeToUtc(dateNow)
        dateNow = TimeZoneInfo.ConvertTimeToUtc(dateNow)
        Dim easternTime As New Date(Year(dateNow), Month(dateNow), Day(dateNow), dateNow.Hour, dateNow.Minute, dateNow.Second)
        Dim easternZoneId As String = cbotime.Text
        Try
            Dim easternZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId)
            txtlocaltime.Text = TimeZoneInfo.ConvertTimeFromUtc(easternTime, easternZone)
            '  Console.WriteLine("The date and time are {0} UTC.",
            ' TimeZoneInfo.ConvertTimeToUtc(easternTime, easternZone))
        Catch ez As TimeZoneNotFoundException
            '  Console.WriteLine("Unable to find the {0} zone in the registry.",
            '  easternZoneId)
        Catch ex As InvalidTimeZoneException
            '  Console.WriteLine("Registry data on the {0} zone has been corrupted.",
            ' easternZoneId)
        End Try
    End Sub

    Private Sub cbotime_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotime.SelectedIndexChanged
        calculautcexemplo()
    End Sub

    Private Sub btnsalvarcliente_Click(sender As Object, e As EventArgs) Handles btnsalvarcliente.Click
        Dim xconf As New clsconfig

        xconf.Nomecliente = txtnomecliente.Text
        xconf.Endereco = txtenderecocliente.Text
        xconf.Bairro = txtbairrocliente.Text
        xconf.Cep = txtcep.Text
        xconf.Cidade = txtcidadecliente.Text
        xconf.Cnpj = txtcnpjcliente.Text
        xconf.Uf = txtufcliente.Text
        xconf.Telefone = txttelefonecliente.Text

        If Not xconf.salvar() Then
            sm("swal({title: 'Sorry!',text: '" & xconf.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")
            Exit Sub
        Else
            avisosButton("salvar")
        End If
        sm("swal({title: 'Very Good!',text: '" & xconf.Mensagemerro & "',type: 'success',confirmButtonText: 'OK'})", "swal")

    End Sub

    Private Sub imglogocliente_Click(sender As Object, e As ImageClickEventArgs) Handles imglogocliente.Click
        Session("origem") = "Empresa"
        Response.Redirect("loadimage.aspx")
    End Sub

    Private Sub cbotipotexto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotipotexto.SelectedIndexChanged
        If cbotipotexto.Text = "" Then
            Exit Sub
        End If
        Dim xclasse As New clsconfig_padroes
        xclasse.Filtro_nome = cbotipotexto.SelectedItem.Text
        xclasse.Listarconfig_padroes()
        If xclasse.Listaclasse.Count = 0 Then
            sm("swal({title: 'Sorry!',text: 'Desculpe, não econtramos esse padrão!',type: 'error',confirmButtonText: 'OK'})", "swal")
            Exit Sub
        End If
        txtassunto.Text = xclasse.Listaclasse(0).Assunto
        txtcorpo.Text = xclasse.Listaclasse(0).Texto
        cbovinculo.Text = xclasse.Listaclasse(0).Vinculo
    End Sub

    Private Sub btnsalvar1_Click(sender As Object, e As EventArgs) Handles btnsalvar1.Click
        Dim xclasse As New clsconfig_padroes
        xclasse.Nome = cbotipotexto.SelectedItem.Text
        xclasse.Texto = txtcorpo.Text
        xclasse.Assunto = txtassunto.Text
        xclasse.Vinculo = cbovinculo.Text
        'xclasse.Usuario = cboenvioemail.SelectedItem.Text
        If Not xclasse.salvarpadroes Then
            sm("swal({title: 'Atenção!',text: '" & xclasse.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")
            Exit Sub
        Else
            avisosButton("salvar")
        End If
        txtassunto.Text = ""
        txtcorpo.Text = ""
        cbotipotexto.Text = ""
        sm("swal({title: 'Opa!',text: 'Padrão salvo com sucesso !',type: 'success',confirmButtonText: 'OK'})", "swal")
    End Sub

    Private Sub txtcep_TextChanged(sender As Object, e As EventArgs) Handles txtcep.TextChanged
        Dim xdist As New clscep
        Dim xcep As String = sonumeros(txtcep.Text)
        If xcep = "" Then
            txtcep.Text = "CEP não informado"
            txtcep.Focus()
            Exit Sub
        End If
        xdist.Cep = xcep
        If Not xdist.buscarcep Then
            sm("swal({title: 'Atenção!',text: '" & xdist.Mensagemerro & "',type: 'error',confirmButtonText: 'OK'})", "swal")
            Exit Sub
        Else
            avisosButton("procurar")
        End If
        txtbairrocliente.Text = xdist.Bairro
        txtcidadecliente.Text = xdist.Cidade
        txtenderecocliente.Text = xdist.Endereco
        txtufcliente.Text = xdist.Uf
        txtenderecocliente.Focus()
    End Sub
End Class
