Imports clsSmart
Imports System.IO
Imports clssessoes
Imports System.Globalization

Partial Class restrito_MasterPage
    Inherits System.Web.UI.MasterPage

    Private Sub restrito_MasterPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then Exit Sub

        'If File.Exists(Server.MapPath("~") & "social\" & Session("logocliente")) Then

        '    Dim xred As New clsredimensiona
        '    xred.Arquivo = Server.MapPath("~") & "social\" & Session("logocliente")
        '    xred.Max = 10
        '    If xred.redimensionar Then
        '        imlogo.Style.Remove("Height")
        '        imlogo.Style.Remove("Width")
        '        imlogo.Style.Add("Height", xred.Novaaltura & "rem")
        '        imlogo.Style.Add("Width", xred.Novalargura & "rem")
        '    End If
        '    imlogo.ImageUrl = "/social/" & Session("logocliente")
        'Else
        '    Dim xred As New clsredimensiona
        '    xred.Arquivo = Server.MapPath("~") & "img\cevanovo.png"
        '    xred.Max = 10
        '    If xred.redimensionar Then
        '        imlogo.Style.Remove("Height")
        '        imlogo.Style.Remove("Width")
        '        imlogo.Style.Add("Height", xred.Novaaltura & "rem")
        '        imlogo.Style.Add("Width", xred.Novalargura & "rem")
        '    End If
        '    imlogo.ImageUrl = "/img/cevanovo.png"
        'End If
        'Exit Sub
        'Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo("pt-BR")
        'Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo("pt-BR")
        'Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ","
        'Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberDecimalSeparator = ","
        'Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberGroupSeparator = ""
        'Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ""




        'lblusuario.Text = Session("usuario")



        'ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "alteraposicao(Image6, 1)", "alteraposicao(Image6, 1)", True)

        '  lblversao.Text = minhaversao
        'Dim tbcarregaimagemm As New Data.DataTable
        'Dim tabcarrega As New clabancopsql
        'tbcarregaimagemm = tabcarrega.conectar("select * from vwusuarios where  usuario = '" & Session("usuario") & "' and ativo = true ")

        'If tbcarregaimagemm.Rows.Count > 0 Then
        '    Session("agente") = "" 'tbcarregaimagemm.Rows(0)("agente").ToString
        '    Session("imagemperfil") = tbcarregaimagemm.Rows(0)("imagemperfil").ToString
        '    lblusuariocompleto.Text = tbcarregaimagemm.Rows(0)("usuario").ToString
        '    lbldtcaduser.Text = "Since " & MesExtenso(CDate(valordata(tbcarregaimagemm.Rows(0)("dtcad").ToString)).Month) & " / " & CDate(valordata(tbcarregaimagemm.Rows(0)("dtcad").ToString)).Year
        '    If System.IO.File.Exists(Request.MapPath("~/social/" & tbcarregaimagemm.Rows(0)("imagemperfil").ToString)) Then
        '        imgperfil1.ImageUrl = "/social/" & tbcarregaimagemm.Rows(0)("imagemperfil").ToString
        '        imgperfilfixo.ImageUrl = "/social/" & tbcarregaimagemm.Rows(0)("imagemperfil").ToString
        '    Else
        '        imgperfil1.ImageUrl = "/img/semimagem01.png"
        '        imgperfilfixo.ImageUrl = "/img/semimagem01.png"

        '    End If
        'Else
        '    imgperfil1.ImageUrl = "/img/semimagem01.png"
        '    imgperfilfixo.ImageUrl = "/img/semimagem01.png"
        'End If
    End Sub

    'Private Sub imgperfil1_Click(sender As Object, e As ImageClickEventArgs) Handles imgperfil1.Click
    '    Session("chave") = Session("idusuario")
    '    Session("origem") = "usuarios"
    '    Response.Redirect("/loadimage.aspx")
    'End Sub

    Private Sub restrito_MasterPage_Init(sender As Object, e As EventArgs) Handles Me.Init

        versessao()

    End Sub
End Class

