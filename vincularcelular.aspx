<%@ Page Language="VB" AutoEventWireup="false" CodeFile="vincularcelular.aspx.vb" Inherits="vincularcelular" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Matriz de Treinamentos</title>
    <%--<script src="/socketsio/socket.io.js"></script>--%>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="js/fixGrid.js" type="text/javascript"></script>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <script src="js/JScriptmascara.js" type="text/javascript"></script>
    <script src="js/jsenviardados.js" type="text/javascript"></script>
    <script src="/js/jssocket.js" type="text/javascript"></script>
    <script src="assets/plugins/sweetalert2/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="/bower_components/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/bower_components/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="/bower_components/Ionicons/css/ionicons.min.css" />
    <link rel="stylesheet" href="/dist/css/skins/_all-skins.min.css" />
    <link rel="stylesheet" href="/css/stylejanelinha.css" />
    <link rel="stylesheet" href="/css/janelasdiversas.css" />
    <link rel="stylesheet" href="/css/smartcodemodal.css" />
    <link rel="stylesheet" href="/css/modalsmartcode.css" />
    <script src="js/shortcut.js"></script>
    <script src="js/wow.min.js"></script>
    <style type="text/css">
        .UpdatePG_Centro {
            /* position:fixed;
z-index:99;
width:100%;
height:100%;
top:0;
left:0;*/
            position: fixed;
            z-index: 99;
            width: 100%;
            height: 100%;
            top: 0;
            left: 0;
            padding-top: 200px;
            background-color: rgba(50, 50, 50, 0.77);
            border: none;
        }
    </style>
    <link rel="stylesheet" href="/css/animate.min.css" />
    <link rel="stylesheet" href="/css/animate.css" />
    <script>
        new WOW().init();
    </script>

    <script src="/dist/js/sweetalert2.all.min.js"></script>


    <script src="/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="/dist/js/adminlte.min.js"></script>


    <link rel="stylesheet" href="/bower_components/select2/dist/css/select2.min.css" />
    <script src="/bower_components/select2/dist/js/select2.full.min.js"></script>
    <link rel="stylesheet" href="/dist/css/AdminLTE.min.css" />
    <script src="js/dfed75f8a4.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.4.js" type="text/javascript"></script>

    <link rel="icon" href="/img/favicon.png" type="image/png" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="1500">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="updategeral">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress7" runat="server" AssociatedUpdatePanelID="updategeral">
                    <ProgressTemplate>
                        <center>
                            <div class="UpdatePG_Centro">
                                <asp:Label ID="lblaguarde" runat="server" Font-Size="15" Text="Carregando! Aguarde..." ForeColor="White" Font-Bold="true"></asp:Label>
                                <br />
                                <br />
                                <img src="../img/paoqueijo.gif" style="height: 15rem; width: 15rem;" />
                            </div>
                        </center>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div class="row" id="divsmart" runat="server">
                    <div class="col-lg-12 text-right  ">
                        <img id="imglogogif" src="img/imgsmart.gif" style="width: 15rem">
                    </div>
                </div>
                <div style="margin-top: 5%; margin-left: 1rem; margin-right: 1rem">
                    <div class="row">
                        <div data-wow-iteration="4" class="span3 wow swing center" data-wow-delay="3s" style="animation-iteration-count: 4; animation-name: swing;">

                            <center>
                                <asp:Image ID="imlogo" runat="server" ImageUrl="~/img/gestor01.png" />
                            </center>
                        </div>
                        <div class="col-lg-12 text-center wow fadeInRight">
                            <br />
                            <h4><b>Vincular celular</b></h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 text-center wow fadeInLeft ">

                            <br />
                            <asp:HiddenField ID="hdcodigo" runat="server" />
                            <asp:HiddenField ID="hdurldestino" runat="server" />
                            <i class="fa fa-comment "></i>Essa ação permitirá recuperar sua senha pelo whatsapp,
                        <br />
                            além de permitir baixar relatórios, informar ocorrências e muitas outras ações pelo próprio aplicativo!
                        <br />
                            <br />
                            <b>Vamos tentar?</b>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 4rem">
                        <div class="col-lg-1"></div>

                        <div class="col-lg-10" style="border-radius: 15px; padding: 2rem; background-color: antiquewhite">
                            <div class="row" id="divsolcodigo" runat="server">
                                <div class="col-lg-2 text-center">
                                    <b>País</b>
                                    <br />
                                    <asp:DropDownList ID="cbopais" AutoPostBack="true" runat="server" CssClass="form-control "></asp:DropDownList>

                                </div>
                                <div class="col-lg-2 text-center">
                                    <b>Código do país</b>
                                    <br />
                                    <asp:Label ID="lblcodigopais" runat="server"></asp:Label>
                                </div>
                                <div class="col-lg-2 text-center">
                                    <b>Código de Área</b>
                                    <br />
                                    <asp:TextBox ID="txtcodigoarea" Style="text-align: center" runat="server" CssClass="form-control "></asp:TextBox>
                                </div>
                                <div class="col-lg-2 text-center">
                                    <b>Telefone</b>
                                    <br />
                                    <asp:TextBox ID="txttelefone" Style="text-align: center" runat="server" CssClass="form-control "></asp:TextBox>
                                </div>
                                <div class="col-lg-2 text-center wow fadeInDown" data-wow-duration="2s" style="padding: 3rem">

                                    <div class="wow pulse animated" data-wow-delay="300ms" data-wow-iteration="infinite" data-wow-duration="2s" style="visibility: visible; animation-duration: 2s; animation-delay: 400ms; animation-iteration-count: infinite; animation-name: pulse;">
                                        <asp:LinkButton ID="btnsolicitarcodigo" CssClass="btn btn-warning " runat="server" ForeColor="white"><i class="fa fa-mobile-phone "></i> Solicitar Código
                                        </asp:LinkButton>
                                    </div>
                                </div>

                                <div class="col-lg-2 text-center wow fadeInUp " data-wow-duration="2s" style="padding: 3rem">

                                    <div class="wow pulse animated" data-wow-delay="300ms" data-wow-iteration="infinite" data-wow-duration="2s" style="visibility: visible; animation-duration: 2s; animation-delay: 400ms; animation-iteration-count: infinite; animation-name: pulse;">
                                        <asp:LinkButton ID="btncancelar" CssClass="btn btn-danger " runat="server" ForeColor="white"><i class="fa fa-exclamation-circle"></i> Não quero vincular
                                        </asp:LinkButton>
                                        <br />
                                        <asp:CheckBox ID="chknaosolicitar" runat="server" ForeColor="red" Text="Não me pergunte novamente" />
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="divcodigodigitar" runat="server" style="display: none">
                                <div class="col-lg-5"></div>
                                <div class="col-lg-2 text-center">
                                    <b>Informe o código recebido</b>
                                    <br />
                                    <asp:TextBox ID="txtcodigorecebido" runat="server" CssClass="form-control " Style="text-align: center"></asp:TextBox>
                                    <br />

                                    <asp:LinkButton ID="btnconfirmarcodigo" CssClass="btn btn-success" runat="server"><i class="fa fa-plus-circle "></i> Confirmar</asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="btncancelarcodigo" CssClass="btn btn-danger" runat="server"><i class="fa fa-undo"></i> Cancelar</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-1"></div>

                    </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
