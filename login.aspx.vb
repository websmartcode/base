Imports clsSmart
Imports System.IO
Partial Class login
    Inherits BasePage

    'Private Sub login_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    If IsPostBack Then Exit Sub
    '    'divsmart.Style.Add("display", "none")
    '    'btndownload.Visible = False
    '    Dim Files = SearchForFiles(Server.MapPath("~/imagenspublicas/"), {"*.png", "*.jpg", "*.jpeg", "*.gif"})

    '    For i As Integer = 0 To Files.Count - 1
    '        Files.Item(i) = Files.Item(i).Replace(Files.Item(i).Substring(0, Files.Item(i).IndexOf("\imagenspublicas") + 1), "")
    '    Next

    '    If Files.Count > 1 Then

    '        For i As Integer = 0 To Files.Count - 1
    '            Dim divcontrol As HtmlGenericControl = New HtmlGenericControl("div")
    '            Dim imgcontrol As HtmlGenericControl = New HtmlGenericControl("img")
    '            imgcontrol.Attributes.Add("src", Files.Item(i))
    '            divcontrol.Controls.Add(imgcontrol)
    '        Next
    '    Else
    '        Dim divcontrol As HtmlGenericControl = New HtmlGenericControl("div")
    '        Dim imgcontrol As HtmlGenericControl = New HtmlGenericControl("img")
    '        imgcontrol.Attributes.Add("src", "/imagenspublicas/family-01.jpg")
    '        divcontrol.Controls.Add(imgcontrol)


    '    End If

    '    'If data.Month = 12 Then
    '    '    divnatal.Style.Remove("display")
    '    'Else
    '    '    divnatal.Style.Add("display", "none")
    '    'End If

    '    Dim xconfig As New clsconfig
    '    xconfig.carregar()


    '    If File.Exists(Server.MapPath("~") & "\social\" & Session("logocliente")) Then
    '        'imlogo.ImageUrl = Server.MapPath("~") & "img\cevanovo.png" Request.Url.OriginalString.Replace(Request.Path, "/social/" & Session("logocliente"))

    '        Dim xred As New clsredimensiona

    '        xred.Arquivo = (Server.MapPath("~") & "social\" & Session("logocliente"))

    '        'If xred.redimensionar Then
    '        '    imlogo.Style.Remove("height")
    '        '    imlogo.Style.Remove("width")
    '        '    imlogo.Style.Add("height", xred.Novaaltura & "rem")
    '        '    imlogo.Style.Add("width", xred.Novalargura & "rem")
    '        'End If
    '        'imlogo.ImageUrl = Request.Url.OriginalString.Replace(Request.Path, "/social/" & Session("logocliente"))
    '        'Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~") & "social\" & Session("logocliente"))
    '        'Dim imgaltura As Decimal = img.PhysicalDimension.Height
    '        'Dim imglargura As Decimal = img.PhysicalDimension.Width
    '        'Dim fator As Decimal = Int((imgaltura / imglargura) * 16)
    '        'Dim novaaltura As Decimal = (16 * 100) / imgaltura
    '        'If (img.Width >= img.Height) Then
    '        '    fator = (16 / img.Width)
    '        'Else
    '        '    fator = (16 / img.Height)
    '        'End If

    '        'newWidth = CInt(img.Width * fator)
    '        'newHeight = CInt(img.Height * fator)

    '        'logo.Style.Add("height", moeda(FormatNumber(novaaltura, 2)) & "%")
    '        'logo.Style.Add("width", moeda(FormatNumber(novaaltura, 2)) & "%")

    '    Else
    '        Dim xred As New clsredimensiona
    '        xred.Max = 10
    '        xred.Arquivo = (Server.MapPath("~") & "img\padlogo.png")

    '        'If xred.redimensionar Then
    '        '    imlogo.Style.Remove("height")
    '        '    imlogo.Style.Remove("width")
    '        '    imlogo.Style.Add("height", xred.Novaaltura & "rem")
    '        '    imlogo.Style.Add("width", xred.Novalargura & "rem")
    '        'End If
    '        'imlogo.ImageUrl = "/img/padlogo.png"
    '        ' imlogo.Visible = False
    '    End If
    '    'btndownload.Visible = True
    '    'If Not verapks() Then
    '    '    btndownload.Visible = False
    '    'End If
    'End Sub

    Private Sub sm(funcao As String, Optional nome As String = "")
        If nome = "" Then
            nome = funcao
        End If
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), nome, funcao, True)
    End Sub
    Private Sub btnentrar_Click(sender As Object, e As EventArgs) Handles btnentrar.Click

        Dim xlogin As New clslogin
        xlogin.Usuario = txtemail.Value
        xlogin.Senha = txtsenha.Value
        If Not xlogin.logar Then
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "qweqwe", "exibirAviso('é preciso responder a questão!');", True)

            Exit Sub
        End If
        Response.Redirect(xlogin.Urlretorno)
    End Sub
End Class
