Imports System.IO
Imports clsSmart
Partial Class vincularcelular
    Inherits BasePage

    Private Sub vincularcelular_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then Exit Sub
        ' hdurldestino.Value = HttpContext.Current.Session("urlretorno")

        If File.Exists(Server.MapPath("~") & "social\" & Session("logocliente")) Then

            Dim xred As New clsredimensiona
            xred.Arquivo = Server.MapPath("~") & "social\" & Session("logocliente")
            xred.Max = 10
            If xred.redimensionar Then
                imlogo.Style.Remove("Height")
                imlogo.Style.Remove("Width")
                imlogo.Style.Add("Height", xred.Novaaltura & "rem")
                imlogo.Style.Add("Width", xred.Novalargura & "rem")
            End If
            imlogo.ImageUrl = Request.Url.OriginalString.Replace(Request.Path, "/social/" & Session("logocliente"))
        Else
            Dim xred As New clsredimensiona
            xred.Arquivo = Server.MapPath("~") & "img\cevanovo.png"
            xred.Max = 10
            If xred.redimensionar Then
                imlogo.Style.Remove("Height")
                imlogo.Style.Remove("Width")
                imlogo.Style.Add("Height", xred.Novaaltura & "rem")
                imlogo.Style.Add("Width", xred.Novalargura & "rem")
            End If
            imlogo.ImageUrl = Request.Url.OriginalString.Replace(Request.Path, "/img/cevanovo.png")
        End If

        Dim tb1 As New Data.DataTable
        Dim tab1 As New clabancopsql
        tb1 = tab1.conectar("select pais, codigotelefone from tbconfig where ativo = true order by pais")
        cbopais.Items.Clear()
        cbopais.Items.Add("")
        cbopais.Items(cbopais.Items.Count - 1).Value = ""
        For x As Integer = 0 To tb1.Rows.Count - 1
            cbopais.Items.Add(tb1.Rows(x)("pais").ToString)
            cbopais.Items(cbopais.Items.Count - 1).Value = tb1.Rows(x)("codigotelefone").ToString

        Next

    End Sub

    Private Sub cbopais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbopais.SelectedIndexChanged
        lblcodigopais.Text = cbopais.SelectedValue
    End Sub

    Private Sub btnsolicitarcodigo_Click(sender As Object, e As EventArgs) Handles btnsolicitarcodigo.Click
        Dim GeradorDeNumerosAleatorios As Random = New Random()
        GeradorDeNumerosAleatorios.Next(1000, 985711)
        hdcodigo.Value = AES_Encrypt(mLeft(zeros(sonumeros(GeradorDeNumerosAleatorios.Next(1000, 985711)), 6), 6), "Smart@0101")
        Dim _telefone As String = lblcodigopais.Text & sonumeros(txtcodigoarea.Text) & sonumeros(txttelefone.Text)
        Dim xbot As New clsbot
        xbot.enviarMensagem(_telefone, Session("usuario"), "Ola! Segue o codigo para vincular seu número ao sistema SoftClinica: " & AES_Decrypt(hdcodigo.Value, "Smart@0101"))
        divcodigodigitar.Style.Remove("display")
        divsolcodigo.Style.Add("display", "none")
    End Sub

    Private Sub btnconfirmarcodigo_Click(sender As Object, e As EventArgs) Handles btnconfirmarcodigo.Click
        If AES_Encrypt(txtcodigorecebido.Text, "Smart@0101") = hdcodigo.Value Then
            Dim xusuario As New clsusuarios
            xusuario.Nrseq = Session("idusuario")
            xusuario.Celular = lblcodigopais.Text & sonumeros(txtcodigoarea.Text) & sonumeros(txttelefone.Text)
            xusuario.ValidarCelular()
            Response.Redirect(HttpContext.Current.Session("urlretorno"))
        Else
            sm("swal({title: 'Atenção!',text: 'Desculpe, mas o código não confere com o enviado!',type: 'error',confirmButtonText: 'OK'})", "swal")

        End If
    End Sub
    Private Sub sm(funcao As String, Optional nome As String = "")
        If nome = "" Then
            nome = funcao
        End If
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), nome, funcao, True)
    End Sub

    Private Sub btncancelarcodigo_Click(sender As Object, e As EventArgs) Handles btncancelarcodigo.Click
        divsolcodigo.Style.Remove("display")

        divcodigodigitar.Style.Add("display", "none")
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        If chknaosolicitar.Checked Then
            Dim xusuario As New clsusuarios
            xusuario.Nrseq = numeros(Session("idusuario"))
            xusuario.ValidarCelular(True)
        End If
        Response.Redirect(HttpContext.Current.Session("urlretorno"))
    End Sub
End Class
