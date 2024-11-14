<%@ Page Language="VB" AutoEventWireup="false" CodeFile="aviso.aspx.vb" Inherits="aviso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Ops...</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="msg-erro/css/style.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.0.0/animate.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/wow/1.1.2/wow.min.js">
    <script src="http://code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <!-- <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script> -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/wow/1.1.2/wow.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.7.0/animate.css">
</head>
<body class="img-fundo">
    <form id="form1" runat="server">
        <a href="http://www.smartcodesolucoes.com.br/" target="_blank" class="wow fadeIn" data-wow-delay="3.2s">
            <img class="img-logo" src="msg-erro/img/logo.png" alt="Smartcode soluções">
        </a>
        <div class="container-fluid">
            <div class="row align-items-center">

                <div class="col-md-7">
                    <h2 class="wow fadeIn bigger" data-wow-duration="4s" data-wow-delay="2s"><%=Resources.Resource.idocorreuumerro%></h2>

                </div>
                <div class="col-md-5 wow slideInLeft" data-wow-duration="4s">
                    <img src="msg-erro/img/foguete.png" style="transform: rotate(45deg); width: 250px;">
                </div>
            </div>
            <div class="container">
                <div class="wow fadeInUp col-md-8 mb-5" data-wow-delay="3s">
                    <div class="card">
                        <div class="card-body">
                            <p class="text-white">
                                <b id="txtexemplo" runat="server">

                                    <!--AQUI VEM A MENSAGEM DE ERRO CUSTOMIZADA-->

                                    What is Lorem Ipsum?
                                Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. 

                                </b>

                            </p>
                        </div>
                    </div>

                </div>

            </div>
            <br />
            <div class="wow fadeInTop" data-wow-delay="5s">
                <asp:Button ID="btnvoltar" runat="server" CssClass="button animate__animated animate__fadeInDown animate__delay-4s" Text='Retornar' />
                <%--<button class="button animate__animated animate__fadeInDown animate__delay-4s" onclick="window.location.href = 'default.aspx';">
                <span><%=Resources.Resource.btnvoltarinicio%></span>
            </button>--%>
            </div>
        </div>




        <script type="text/javascript">
            $(document).ready(function () {
                $('.has-animation').each(function (index) {
                    $(this).delay($(this).data('delay')).queue(function () {
                        $(this).addClass('animate-in');
                    });
                });
            });
            document.querySelector('.button').onmousemove = function (e) {

                var x = e.pageX - e.target.offsetLeft;
                var y = e.pageY - e.target.offsetTop;

                e.target.style.setProperty('--x', x + 'px');
                e.target.style.setProperty('--y', y + 'px');
            };

        </script>
        <script type="text/javascript">

            wow = new WOW(
                {
                    animateClass: 'animated',
                    offset: 100,
                    callback: function (box) {
                        console.log("WOW: animating <" + box.tagName.toLowerCase() + ">")
                    }
                }
            );
            wow.init();
            document.getElementById('moar').onclick = function () {
                var section = document.createElement('section');
                section.className = 'section--purple wow fadeInDown';
                this.parentNode.insertBefore(section, this);
            };
        </script>

        <script src="msg-erro/js/wow.min.js"></script>
        <script>
            new WOW().init();
        </script>

    </form>
</body>
</html>
