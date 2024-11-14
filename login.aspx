<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>SmartCode | Login</title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
<script src="
https://cdn.jsdelivr.net/npm/sweetalert2@11.12.4/dist/sweetalert2.all.min.js
"></script>
<link href="
https://cdn.jsdelivr.net/npm/sweetalert2@11.12.4/dist/sweetalert2.min.css
" rel="stylesheet">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.7.1.js" integrity="sha256-eKhayi8LEQwp4NKxN+CfCh+3qOVUtJn3QNZ0TciWLP4=" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/notyf@3/notyf.min.css">
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

    
    <script>
            function exibirAviso(texto) {
                var message = $('#toastMessage')[0]
                var cor = 'rgb(255, 255, 255, 0.8)'
                var icone = "<span class='material-symbols-outlined pe-4'>info</span>"
                var divTexto = `<span class='flex-grow-1 text-center'>${texto}</span>`

                message.innerHTML = `${icone}${divTexto}`
                message.parentElement.parentElement.style.backgroundColor = 'rgb(255,255,255,0.95)'
                message.parentElement.parentElement.style.color = $('body')[0].style.backgroundColor

                var toast = new bootstrap.Toast($('#liveToast')[0])
                console.log(toast);
                toast.show()

            }
        </script>
</head>

<body>
    <div class="position-fixed top-0 start-50 translate-middle-x m-3" style="z-index: 11">
        <div id="liveToast" clientidmode="Static" class="toast aviso" role="alert" aria-live="assertive" aria-atomic="true" data-bs-delay="2500">
            <div class="d-flex">
                <div clientidmode="Static" id="toastMessage" class="toast-body d-flex align-items-center flex-grow-1 texto-fundo-pagina">
                </div>
                <button type="button" class="me-2 m-auto btn-fechar" data-bs-dismiss="toast" aria-label="Close">X</button>
            </div>
        </div>
    </div>
    <form runat="server" id="formlogin">
        <div id="divlogindados" runat="server">
            <div class="form-group has-feedback">
                <input runat="server" id="txtemail" class="form-control" placeholder="Login" style="text-align: center">
                <span class="glyphicon glyphicon-user form-control-feedback"></span>
            </div>
            <div class="form-group has-feedback">
                <input runat="server" id="txtsenha" type="password" class="form-control" placeholder="Password" style="text-align: center">
                <span class="glyphicon glyphicon-lock form-control-feedback"></span>
            </div>
            <div class="col-xs-6 text-center">
                <asp:LinkButton runat="server" ID="btnentrar" CssClass="btn btn-primary btn-block btn-flat"><i class="fa fa-key" aria-hidden="true"></i> Entrar</asp:LinkButton>
            </div>
            </div>
    </form>

</body>
</html>
