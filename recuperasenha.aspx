<%@ Page Language="VB" AutoEventWireup="false" CodeFile="recuperasenha.aspx.vb" Inherits="restrito_recuperasenha" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Área Administrativa | Login</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="plugins/iCheck/square/blue.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->


    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
</head>
<body class="hold-transition login-page">
    <div class="login-box">
        <div class="login-logo">
            <a><b style="color: red;">Red</b> & <b style="color: white;">White</b>
            </a>
        </div>
        <!-- /.login-logo -->
        <div class="login-box-body">

            <div runat="server" id="divErro" style="display: none;" class="alert alert-warning alert-dismissible" role="alert">
                <strong>Erro!</strong>
                <asp:Label runat="server" ID="lblerro"></asp:Label>
            </div>
            <div runat="server" id="divsucesso" style="display: none;" class="alert alert-success alert-dismissible" role="alert">
                <strong>Sucesso!</strong>
                <asp:Label runat="server" ID="lblsucesso"></asp:Label>
            </div>

            <form runat="server" id="formlogin">
                <div class="form-group has-feedback">
                    <input runat="server" id="txtsenha" type="password" class="form-control" placeholder="Nova senha">
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback">
                    <input runat="server" id="txtconfirma" type="password" class="form-control" placeholder="Confirme nova senha">
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                </div>
                <div class="row">
                    <div class="col-xs-8">
                        <div class="checkbox icheck">
                            <label>
                            </label>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-xs-4">
                        <asp:LinkButton runat="server" ID="btnentrar" CssClass="btn btn-primary btn-block btn-flat">Alterar</asp:LinkButton>
                    </div>
                    <!-- /.col -->
                </div>
                <div runat="server" id="divalerta" style="display: none;" class="alert alert-warning alert-dismissible" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong>Ops!</strong>
                    <asp:Label runat="server" ID="lblalerta"></asp:Label>
                </div>

            </form>




        </div>
        <!-- /.login-box-body -->
    </div>
    <!-- /.login-box -->

    <!-- jQuery 3 -->
    <script src="bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' /* optional */
            });
        });
    </script>
</body>
</html>

