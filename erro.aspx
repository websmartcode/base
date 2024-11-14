<%@ Page Language="VB" AutoEventWireup="false" CodeFile="erro.aspx.vb" Inherits="erro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <link rel="stylesheet" href="css/_folhageral.css">

    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>QuoteSystem - SmartCode Soluções em Softwares</title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <script src="js/JScriptmascara.js" type="text/javascript"></script>
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css">
    <script src="assets/plugins/sweetalert2/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">

    <script src="dist/js/sweetalert2.all.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/promise-polyfill"></script>

    <script src="bower_components/jquery/dist/jquery.min.js"></script>
    <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="dist/js/adminlte.min.js"></script>
    <script src="js/cronometro.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-colorpicker/2.5.3/js/bootstrap-colorpicker.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-colorpicker/2.5.3/css/bootstrap-colorpicker.min.css" />

    <link rel="stylesheet" href="bower_components/select2/dist/css/select2.min.css">
    <script src="bower_components/select2/dist/js/select2.full.min.js"></script>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
    <link rel="icon" href="/img/favicon.png" type="image/png">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link href="css/charisma-app.css" rel="stylesheet">
    <link href='bower_components/fullcalendar/dist/fullcalendar.css' rel='stylesheet'>
    <link href='bower_components/fullcalendar/dist/fullcalendar.print.css' rel='stylesheet' media='print'>
    <link href='bower_components/chosen/chosen.min.css' rel='stylesheet'>
    <link href='bower_components/colorbox/example3/colorbox.css' rel='stylesheet'>
    <link href='bower_components/responsive-tables/responsive-tables.css' rel='stylesheet'>
    <link href='bower_components/bootstrap-tour/build/css/bootstrap-tour.min.css' rel='stylesheet'>
    <link href='css/jquery.noty.css' rel='stylesheet'>
    <link href='css/noty_theme_default.css' rel='stylesheet'>
    <link href='css/elfinder.min.css' rel='stylesheet'>
    <link href='css/elfinder.theme.css' rel='stylesheet'>
    <link href='css/jquery.iphone.toggle.css' rel='stylesheet'>
    <link href='css/uploadify.css' rel='stylesheet'>
    <link href='css/animate.min.css' rel='stylesheet'>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <style>
        body, html {
            height: 100%;
            margin: 0;
        }

        .bg {
            /* The image used */
            background-image: url('http://www.smartcodesolucoes.com.br/img/erro02.jpg');
            /* Full height */
            height: 100%;
            /* Center and scale the image nicely */
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
        }

        .windowstatusmodelo {
            border-width: 2px;
            border-style: solid;
            border-color: black;
            background-color: rgba(0, 0, 0, 0.4);
            width: 800px;
            height: 300px;
            position: absolute;
            margin-top: 10px;
            margin-left: 10px;
            left: 400px;
            top: 150px;
            z-index: 9999;
            text-align: left;
            -webkit-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77);
            -moz-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77);
            box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77);
        }
    </style>
</head>

<body class="bg">
    <form id="form1" runat="server">
        <div class="windowstatusmodelo">

            <br />
            <br />
            <div style="margin-left: 100px">
                <asp:HiddenField ID="hdsql" runat="server" />
                <asp:HiddenField ID="hdvoltar" runat="server" />
                <asp:HiddenField ID="hdopcao" runat="server" />
                <asp:TextBox ID="txtmensagem" runat="server" class="form-control" BackColor="Transparent" ForeColor="GreenYellow" Font-Size="X-Large" BorderStyle="none" Width="600px" Height="150px" TextMode="MultiLine" Style="text-align: center;"></asp:TextBox>
                <br />
                <div class="text-center">
                    <asp:Button ID="btnretentar" runat="server" Text="Vamos de novo?" CssClass="btn btn-warning" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
