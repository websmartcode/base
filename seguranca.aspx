<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="seguranca.aspx.vb" Inherits="seguranca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="Server">




    <div class="box box-danger" style="margin-left: 1rem; margin-right: 1rem; -webkit-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77); -moz-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77); box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77);">
        <div class="box box-header ">
            <b><%=Resources.Resource.idalterarsenha%></b>
        </div>
        <asp:UpdatePanel ID="updatesenha" runat="server">
            <ContentTemplate>
                <div class="box-body">

                    <br />
                    <br />

                    <asp:HiddenField ID="hdorigem" runat="server" />
                    <div class="row">
                        <div class="col-lg-12 text-center">
                            <%=Resources.Resource.idatencao%>,
            <asp:Label ID="lblusuario" runat="server" Text="<%$Resources:Resource,idusuario%>"></asp:Label>
                            : <%=Resources.Resource.idrazaoseg%>
                        </div>
                    </div>
                    <br />
                    <br />

                    <div class="row">
                        <div class="col-lg-2 ">
                            <asp:Image ImageUrl="../img/mulher3.png" runat="server" Visible="false" />
                        </div>
                        <div class="col-lg-4 " style="">
                            <%=Resources.Resource.idcondicao%><br />
                            <br />
                            <asp:Image ID="imgNumerosLetras" runat="server" ImageUrl="~/IMG/button_cancel.png" />
                            &nbsp;<%=Resources.Resource.idnumletras%><br />
                            <asp:Image ID="imgSimbolos" runat="server" ImageUrl="~/IMG/button_cancel.png" />
                            &nbsp;<%=Resources.Resource.idsimbolos%><br />
                            <asp:Image ID="imgLetraMaiuscula" runat="server" ImageUrl="~/IMG/button_cancel.png" />
                            &nbsp;<%=Resources.Resource.idmaiuscula%><br />
                            <asp:Image ID="imgSenhasConferem" runat="server" ImageUrl="~/IMG/button_cancel.png" />
                            &nbsp;<%=Resources.Resource.idnconferesenha%><br />
                            <asp:Image ID="imgSenhaAntiga" runat="server" ImageUrl="~/IMG/button_cancel.png" />
                            &nbsp;<%=Resources.Resource.idnconfereantiga%>
                        </div>
                        <div class="col-lg-4 ">
                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,idsenhaantiga%>" ForeColor="black"></asp:Label>
                            <asp:TextBox ID="txtSenhaAntiga" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,idnovasenha%>" ForeColor="black"></asp:Label>
                            <asp:TextBox ID="txtSenhaNova" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,idconfirmasenha%>" ForeColor="black"></asp:Label>

                            <asp:TextBox ID="txtConfirmar" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            <div class="text-center">
                                <asp:Button ID="btnConfirmar" runat="server" Text="<%$Resources:Resource,btnconfirmasenha%>" CssClass="btn btn-danger " />
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updatesenha">
                                    <ProgressTemplate>
                                        <br />
                                        <center>
                                            <img src="../img/carregando1.gif" width="50px" height="50px" />
                                        </center>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>

                        </div>
                    </div>
                    <div class="row" style="background: black; color: gold;">
                        <div class="col-lg-12 text-center">
                            <br />
                            <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,idsmart%>"></asp:Label>
                            <br />
                            <asp:Label ID="Label5" runat="server" Text="Suport: +55 (41) 3385-1270"></asp:Label>
                            <br />
                            <asp:Label ID="Label6" runat="server"
                                Text="<%$Resources:Resource,idemail%> "> 
                            </asp:Label>
                            :suporte@smartcodesolucoes.com.br
                            <br />
                        </div>
                    </div>

                    <br />
                    <br />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>

