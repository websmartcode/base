Imports System.Threading
Imports System.Globalization
Imports clsSmart
Imports clssessoes
Public Class BasePage
    Inherits System.Web.UI.Page

    Protected Sub usuariologado()

    End Sub


    Protected Overrides Sub InitializeCulture()

        If Request.Url.Query = "?script=AUTOMATICO" Then
            Return
        End If

        'If Session("nivel") = Nothing AndAlso Session("validarbase") = "sim" Then
        '    Response.Redirect("login.aspx")
        'End If

        '     versessao()


        Dim language As String = "en-us"

        'Detect User's Language.
        If Request.UserLanguages IsNot Nothing Then
            'Set the Language.
            language = Request.UserLanguages(0)
        End If
        Try


            'Check if PostBack is caused by Language DropDownList.
            If Request.Form("__EVENTTARGET") IsNot Nothing AndAlso Request.Form("__EVENTTARGET").Contains("ddlLanguages") Then
                'Set the Language.
                language = Request.Form(Request.Form("__EVENTTARGET"))
            End If
        Catch ex As Exception

        End Try

        If Session("language") = Nothing Then
            'language = "br"
            language = "pt-BR"
        Else
            language = Session("language")
        End If

        language = "pt-BR"

        'Set the Culture.
        Thread.CurrentThread.CurrentCulture = New CultureInfo(language)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(language)
        Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ","
        Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberDecimalSeparator = ","
        Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberGroupSeparator = ""
        Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ""
        Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"

    End Sub
End Class
