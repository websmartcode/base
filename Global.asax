<%@ Application Language="VB" %>
<%@ Import Namespace ="clssmart" %>
<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

        gravalog(0, "Entrou no site")
        ' Code that runs when a new session is started
    End Sub


    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub


    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)

        ' check is secure connection used
        If Not Request.IsSecureConnection Then
            ' redirect visitor to SSL connection
            '\\\\      Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"))
        End If
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub


</script>