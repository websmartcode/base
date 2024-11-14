<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="loadimage.aspx.vb" Inherits="socialnetwork_loadimage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="Server">
    <meta charset="utf-8" />
    <link rel="icon" type="image/png" href="assets/img/favicon.ico">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />



    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' name='viewport' />
    <meta name="viewport" content="width=device-width" />


    <script src="/assets/js/JScriptmascara.js" type="text/javascript"></script>
    <link href="/assets/css/crop/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <script src="/assets/js/jquery.min.js" type="text/javascript"></script>
    <script src="/assets/js/crop/jquery.Jcrop.js" type="text/javascript"></script>
    <script type="text/javascript" src="/assets/css/crop/jquery-1.8.1.js"></script>
    <script type="text/javascript" src="/assets/css/crop/core.js"></script>
    <script type="text/javascript" src="/assets/css/crop/jquery.cookie.js"></script>
    <script src="/assets/css/crop/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('#<%=imgcrop.ClientID %>').Jcrop({
                onSelect: storeCoords,
                //Set Image Box Height & Width
                boxWidth: 800, boxHeight: 600
            });
        });

        //Function to store coordinates
        function storeCoords(c) {
            jQuery('#<%=hdnX.ClientID %>').val(c.x);
            jQuery('#<%=hdnY.ClientID %>').val(c.y);
            jQuery('#<%=hdnW.ClientID %>').val(c.w);
            jQuery('#<%=hdnH.ClientID %>').val(c.h);
        };

    </script>
    <script language="javascript" type="text/javascript">
        function fecharmodaldocsparent1(caminho) {
            //$('.fechar').click(function (ev) {

            console.log(caminho);
            window.parent.fecharimagem(caminho)

            //}

        }


        function fecharmodalstatus() {
            //$('.fechar').click(function (ev) {

            $(".windowsdth").hide();
            $(".windowsdth").closest;

            //}

        }
        function exibirnovostatus() {

            $('#informarcarteira').show();
            //    $('#alterarststatus').load();
        }
        function exibiralerta1() {




            $('#alerta_conta').show();
            $('#alerta_conta').load();
        }
        function escondeexibiralerta1() {




            $('#alerta_conta').hide();
            $('#alerta_conta').hide();
        }
        function exibiralerta2() {




            $('#alerta1').show();
            $('#alerta1').load();
        }
        function escondeexibiralerta2() {




            $('#alerta1').hide();
            $('#alerta1').hide();
        }
    </script>
    <style>
        .frame {
            height: 90%;
            width: 100%;
        }

        .windowsdth {
            border-width: 2px;
            border-style: solid;
            border-color: #800000;
            display: none;
            width: 400px;
            height: 250px;
            position: absolute;
            left: 45px;
            top: 65px;
            background: white;
            z-index: 9900;
            padding: 5px;
            text-align: left;
            /*margin-top: 430px;*/
            -webkit-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77);
            -moz-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77);
            box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77);
        }
    </style>







    <div class="panel panel-primary" style="margin-left: 1rem; margin-top: 1rem; margin-right: 1rem;">

        <div class="panel-heading">
            <center>
                Shall we upload your photo? Select the desired image and click upload!
            </center>
        </div>
        <div class="panel-body">

            <asp:HiddenField ID="hdorigem" runat="server" />
            <asp:HiddenField ID="hdchave" runat="server" />
            <div class="row">
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>
                </div>
                <div class="col-lg-2">
                    <div class="form-group">

                        <asp:Button ID="Button1" runat="server" style="border-radius :25px" Text="Load !" CssClass="btn btn-primary" />

                    </div>
                </div>
                <div class="col-lg-2">
                    <div class="form-group">

                        <asp:Button ID="btnsair" runat="server" style="border-radius :25px" Text="Exit " CssClass="btn btn-warning" />

                    </div>
                </div>
            </div>


            <div class="row">
                <center>
                    <asp:Image ID="imgcrop" runat="server" style="border-radius :25px" ImageUrl="~/img/amigo.png" />
                </center>
            </div>
            <div class="row">

                <div class="col-lg-6">
                    <asp:Button ID="btnsalvar" runat="server" style="border-radius :25px" Text="Save" class="btn btn-primary" />
                </div>
            </div>

        </div>
    </div>

    <asp:Image ID="Image1" runat="server"  />
    <asp:HiddenField ID="hdnX" runat="server" />
    <asp:HiddenField ID="hdnY" runat="server" />
    <asp:HiddenField ID="hdnW" runat="server" />
    <asp:HiddenField ID="hdnH" runat="server" />


    <asp:Image ID="imgCropped" runat="server" />


</asp:Content>

