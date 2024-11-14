<%@ Page Language="VB" AutoEventWireup="false" CodeFile="block.aspx.vb" Inherits="block" %>

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

    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-colorpicker/2.5.3/js/bootstrap-colorpicker.min.js"></script>--%>
    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-colorpicker/2.5.3/css/bootstrap-colorpicker.min.css" />--%>

    <link rel="stylesheet" href="/bower_components/select2/dist/css/select2.min.css">
    <script src="/bower_components/select2/dist/js/select2.full.min.js"></script>
    <link rel="stylesheet" href="/dist/css/AdminLTE.min.css">
    <script src="https://kit.fontawesome.com/dfed75f8a4.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="script01" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="update01" runat="server">
            <ContentTemplate>


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

                                <h3><b>BlockList IP</b></h3>
                            </div>
                        </div>

                        <div class="row">
                            <br />
                            <br />
                            <div class="col-lg-1">
                            </div>
                            <div class="col-lg-10">
                                <b>Your IP has been blocked due to too many login attempts:</b>
                                <br />
                                - Check the user used;
                    <br />
                                - Check the password entered;
                    <br />
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:Repeater ID="rptitens" runat="server">
                                    <HeaderTemplate>
                                        <div class="row">
                                            <div class="col-lg-2">
                                            </div>
                                            <div class="col-lg-2">
                                                <b>Date</b>
                                            </div>
                                            <div class="col-lg-4">
                                                <b>IP/MAC</b>
                                            </div>
                                            <div class="col-lg-2">
                                                <b>User</b>
                                            </div>
                                        </div>

                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-lg-2">
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="lbldtcad" runat="server" Text='<%#Bind("dtcad") %>'></asp:Label>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:Label ID="lblip" runat="server" Text='<%#Bind("endereco") %>'></asp:Label>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="lbluser" runat="server" Text='<%#Bind("usercad") %>'></asp:Label>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <hr style="border-color: black" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="text-center">
                                    <b>O que posso fazer?</b>
                                </div>
                                <div class="text-left ">
                                    <br />
                                    - Request the unlocking of your PC in our database;
                          <br />
                                    - Contact SmartCode support via email <b>suporte@smartcodesolucoes.com.br</b>
                                </div>
                            </div>
                            <div id="divemail" runat="server">
                                <div class="col-lg-1">
                                </div>
                                <div class="col-lg-3 text-center">
                                    <br />
                                    <b>Informe seu e-mail</b>
                                    <br />
                                    <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="btnenviarpedido" runat="server" CssClass="btn btn-success ">Solicitar Desbloqueio</asp:LinkButton>
                                </div>


                            </div>
                            <div id="divcode" runat="server" style="padding: 10rem" class="col-lg-6">
                                <div class="row">
                                    <div class="col-lg-6 ">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/forgot.png" Style="height: 15rem" />
                                    </div>
                                    <div class="col-lg-6 ">
                                        <b>Please, enter the Recover Code</b>
                                        <br />
                                        <asp:TextBox ID="txtcode" runat="server" Style="text-align: center" TextMode="Password" Font-Size="XX-Large" MaxLength="6" CssClass="form-control "></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 text-center ">
                                        <br />
                                        <asp:LinkButton ID="btnvercode" runat="server" BackColor="Navy" ForeColor="white" CssClass="btnlegal " Style="padding: 1rem; border-radius: 15px">Verify Code</asp:LinkButton>
                                    </div>
                                    <div class="col-lg-6 text-center ">
                                        <br />
                                        <asp:LinkButton ID="btncancel" runat="server" CssClass="btn btn-danger  " Style="padding: 1rem; border-radius: 15px"> <i class="fa fa-fa-undo "></i> Cancel</asp:LinkButton>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
