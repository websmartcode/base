<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="config.aspx.vb" Inherits="config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="Server">
    <div class="box box-primary" style="margin-left: 1rem; margin-top: 1rem; margin-right: 1rem; -webkit-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77); -moz-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77); box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77);">
        <div class="box box-header ">
            <b>Configurações</b>
            <asp:Button ID="teste" Text="teste" runat="server" Visible="false" />
        </div>
        <div class="box-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress7" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
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
                    <div class="row">
                        <div class="col-lg-12 ">
                            <div class="box box-primary">
                                <div class="box box-header">
                                    <b>Identidade Visual & Licença</b>
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-lg-1 "></div>
                                        <div class="col-lg-3 " style="background-color: antiquewhite; padding: 3rem;">
                                            <div class="row">
                                                <div class="col-lg-12 text-center">
                                                    <asp:LinkButton ID="btncarregarlogo" runat="server" CssClass="btn btn-success "> <i class="fa fa-photo"></i>  Salvar Logo  </asp:LinkButton>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12 text-center">
                                                    <br />
                                                    <asp:ImageButton runat="server" ID="imglogocliente" ImageUrl="~/img/padlogo.png" Style="width: 11rem; height: 11rem;" alt="User Image" />
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-lg-8 ">
                                            <asp:UpdatePanel ID="updateclientes" runat="server">
                                                <ContentTemplate>

                                                    <div class="row">
                                                        <div class="col-lg-8 ">
                                                            Cliente
                                            <br />
                                                            <asp:TextBox ID="txtnomecliente" runat="server" CssClass="form-control "></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-4 ">
                                                            CNPJ
                                            <br />
                                                            <asp:TextBox ID="txtcnpjcliente" runat="server" MaxLength="18" CssClass="form-control " onkeyup="formataCNPJ(this,event);"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-3 ">
                                                            CEP
                                            <br />
                                                            <asp:TextBox ID="txtcep" AutoPostBack="true" MaxLength="9" onkeyup="formataCEP(this,event);" runat="server" CssClass="form-control "></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-9 ">
                                                            Endereço
                                            <br />
                                                            <asp:TextBox ID="txtenderecocliente" runat="server" CssClass="form-control "></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-4 ">
                                                            Bairro
                                            <br />
                                                            <asp:TextBox ID="txtbairrocliente" runat="server" CssClass="form-control "></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-6 ">
                                                            Cidade
                                            <br />
                                                            <asp:TextBox ID="txtcidadecliente" runat="server" CssClass="form-control "></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2 ">
                                                            UF
                                            <br />
                                                            <asp:TextBox ID="txtufcliente" runat="server" CssClass="form-control " MaxLength="2"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-4 ">
                                                            País
                                            <br />
                                                            <asp:TextBox ID="txtpaiscliente" runat="server" CssClass="form-control "></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-4 ">
                                                            Telefone
                                            <br />
                                                            <asp:TextBox ID="txttelefonecliente" onkeyup="formataTelefone(this,event);" runat="server" CssClass="form-control "></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-4 ">
                                                            <br />
                                                            <asp:LinkButton ID="btnsalvarcliente" runat="server" CssClass="btn btn-success "><asp:Image ImageUrl="~/img/salvar01.png" style="width:2rem;height:2rem;" runat="server"/> Salvar </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 ">
                            <div class="box box-primary">
                                <div class="box box-header">
                                    <b>Configurações</b>
                                </div>
                                <div class="box-body">
                                    <asp:UpdatePanel ID="updateconfig" runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-lg-4 ">
                                                    TimeZone
                                                            <br />
                                                    <asp:DropDownList ID="cbotime" runat="server" CssClass="form-control " AutoPostBack="true"></asp:DropDownList>
                                                </div>
                                                <div class="col-lg-3 ">
                                                    UTC Time
                                                            <br />
                                                    <asp:TextBox ID="txtutctime" runat="server" CssClass="form-control "></asp:TextBox>
                                                </div>
                                                <div class="col-lg-3 ">
                                                    Local Time
                                                            <br />
                                                    <asp:TextBox ID="txtlocaltime" runat="server" CssClass="form-control "></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12 text-center">
                                                    <br />
                                                    <asp:LinkButton ID="btnsalvarconfig" runat="server" CssClass="btn btn-success "><asp:Image ImageUrl="~/img/salvar01.png" style="width:2rem;height:2rem;" runat="server"/> Salvar </asp:LinkButton>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 ">
                            <div class="box box-danger">
                                <div class="box box-header  ">
                                    <b>Textos dos e-mails
                                    </b>
                                </div>
                                <div class="box-body">
                                    <asp:UpdatePanel ID="updateemails" runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <asp:Label ID="Label2" runat="server" Text="Tipo de Texto:"></asp:Label>
                                                    <br />
                                                    <asp:DropDownList ID="cbotipotexto" runat="server" CssClass="form-control" AutoPostBack="true">
                                                        <%--<asp:ListItem>(NOVO)</asp:ListItem>--%>
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>New user or password</asp:ListItem>
                                                        <asp:ListItem>Esqueci minha senha</asp:ListItem>
                                                        <asp:ListItem>Pedido de cotação</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <br />
                                                    Vínculo
                                                    <br />
                                                    <asp:DropDownList ID="cbovinculo" runat="server" CssClass="form-control" AutoPostBack="true">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>Reset de senha</asp:ListItem>
                                                        <asp:ListItem>Novo usuario</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-3 ">
                                                    Assunto do E-mail                            
                                                    <br />
                                                    <asp:TextBox ID="txtassunto" runat="server" CssClass="form-control "></asp:TextBox>
                                                    <br />
                                                    E-mail de envio
                                                    <br />
                                                    <asp:DropDownList ID="cboenvioemail" runat="server" CssClass="form-control" AutoPostBack="true">
                                                        <asp:ListItem>(Padrão)</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2 text-center ">
                                                    <br />
                                                    <asp:Button ID="btnopen" runat="server" Text="Abrir" class="btn btn-primary" />
                                                </div>
                                                <div class="col-lg-4 ">
                                                    <div class="box box-primary ">
                                                        <div class="box-header ">
                                                            Use as tags abaixo para configurar no texto
                                                        </div>
                                                        <div class="box-body ">
                                                            <div class="row" style="padding: 1rem;">
                                                                <asp:Repeater ID="rpttags" runat="server">
                                                                    <ItemTemplate>
                                                                        <div class="text-left ">
                                                                            <asp:Label ID="lbltags" runat="server" Text='<%#Bind("tag") %>' CssClass="label label-success"></asp:Label>
                                                                            <br />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                            </div>
                                            <div id="divtexto" runat="server">
                                                <br />
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <asp:TextBox ID="txtcorpo" Style="margin-right: 10px; margin-left: 10px;" Height="420px" runat="server" Width="100%">
                                                        </asp:TextBox>
                                                        <ajaxToolkit:HtmlEditorExtender ID="TextBox1_HtmlEditorExtender" runat="server" TargetControlID="txtcorpo" EnableSanitization="false">
                                                        </ajaxToolkit:HtmlEditorExtender>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-4 text-center "></div>
                                                <div class="col-lg-4 text-center ">
                                                    <br />
                                                    <asp:Button ID="btnsalvar1" runat="server" Text="Salvar" class="btn btn-warning " />
                                                </div>
                                            </div>
                                            <div id="myTesteEmail" class="modal fade" role="dialog">
                                                <div class="modal-dialog" style="width: 80vw; height: 80vh;">
                                                    <!-- Modal content-->
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                            <h4 class="modal-title text-center">
                                                                <asp:Label ID="Label1" runat="server" CssClass="label-success"></asp:Label></h4>
                                                        </div>
                                                        <div class="modal-body">
                                                            <asp:UpdatePanel ID="updatedocas" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="row">
                                                                        <div class="col-lg-12 text-center">
                                                                            <b>Assunto do E-mail</b>
                                                                            <br />
                                                                            <asp:Label ID="lbltesteemail" runat="server">
                                                                            </asp:Label>
                                                                            <br />
                                                                            <b>Corpo do e-mail</b>
                                                                            <br />
                                                                            <center>
                                                                                <iframe id="frameteste" runat="server" style="width: 70vw; height: 30vw"></iframe>
                                                                            </center>

                                                                            <%--  <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="txttesteemail" EnableSanitization="false">
                                                </ajaxToolkit:HtmlEditorExtender>--%>
                                                                        </div>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

