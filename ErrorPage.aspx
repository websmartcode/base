<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ErrorPage.aspx.vb" Inherits="ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8">--%>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>SmartCode Soluções em Softwares</title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <script src="js/JScriptmascara.js" type="text/javascript"></script>
    <%--<script src="js/shortcut.js" type="text/javascript"></script>--%>
    <script src="js/calculogeralresultado.js" type="text/javascript"></script>
    <script src="js/jaudio.js" type="text/javascript"></script>
    <script src="assets/plugins/sweetalert2/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="/bower_components/bootstrap/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="/bower_components/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="/bower_components/Ionicons/css/ionicons.min.css">
    <link rel="stylesheet" href="/dist/css/skins/_all-skins.min.css">
    <link rel="stylesheet" href="/css/janelasdiversas.css">
    <link rel="stylesheet" href="/css/colecaolegais.css">

    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">

    <script src="/dist/js/sweetalert2.all.min.js"></script>
    <%--<script src="https://cdn.jsdelivr.net/npm/promise-polyfill"></script>--%>

    <script src="/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="/dist/js/adminlte.min.js"></script>
    <script src="js/jquery.mask.js"></script>



    <link rel="stylesheet" href="/bower_components/select2/dist/css/select2.min.css">
    <script src="/bower_components/select2/dist/js/select2.full.min.js"></script>
    <link rel="stylesheet" href="/dist/css/AdminLTE.min.css">
    <script src="https://kit.fontawesome.com/dfed75f8a4.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row" style="margin-top: 5rem">
            <div class="col-lg-1 ">
            </div>
            <div class="col-lg-10 " style="border-radius: 15px; background-color: antiquewhite; padding: 1rem; -webkit-box-shadow: 0px 0px 18px 0px rgba(50, 50, 50, 0.75); -moz-box-shadow: 0px 0px 18px 0px rgba(50, 50, 50, 0.75); box-shadow: 0px 0px 18px 0px rgba(50, 50, 50, 0.75); padding-bottom: 3rem">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-lg-2 text-center">
                        <asp:Image ID="imglogo" runat="server" ImageUrl="~/img/simbolo.jpg" Style="height: 3rem; width: 3.5rem" />
                    </div>
                    <div class="col-lg-8 text-center">

                        <h3><b>Sorry, page not found</b></h3>
                    </div>
                </div>


                <br />
                <br />

            </div>
        </div>
    </form>
</body>
</html>
