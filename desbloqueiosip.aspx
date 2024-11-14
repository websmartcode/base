<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="desbloqueiosip.aspx.vb" Inherits="desbloqueiosip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="Server">
    <div class="box box-primary" style="padding: 1rem; -webkit-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77); -moz-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77); box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77);">
        <div class="box box-header">
            <b>Desbloqueio de IPs</b>
        </div>
        <asp:UpdatePanel runat="server" ID="updategeral">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="updategeral">
                    <ProgressTemplate>
                        <center>

                            <div class="UpdatePG_Centro">
                                <asp:Label ID="lblaguarde" runat="server" Font-Size="15" Text="Aguarde! Carregando..." ForeColor="White" Font-Bold="true"></asp:Label>
                                <br />
                                <br />
                                <img src="../img/carregando1.gif" style="height: 10rem; width: 10rem;" />
                            </div>
                        </center>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-12 text-center">
                            <b>Desbloqueie as maquinas desejadas na lista abaixo</b>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 text-center">
                            <br />
                            <asp:Repeater ID="rptitens" runat="server">
                                <HeaderTemplate>
                                    <div class="row">
                                        <div class="col-lg-1">
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
                                        <div class="col-lg-1">
                                            <asp:Label ID="lblitrpt" runat="server" Text='<%#Container.ItemIndex + 1 %>' CssClass="badge" BackColor="Red"></asp:Label>
                                            <asp:HiddenField ID="hdnrseqrpt" runat="server" Value='<%#Bind("nrseq") %>' />
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
                                        <div class="col-lg-1">
                                            <asp:LinkButton ID="btnhabilitarrpt" CommandName="ok" runat="server" CssClass="btn btn-success btn-xs"><i class="fa fa-thumbs-up "></i> </asp:LinkButton>
                                        </div>
                                    </div>

                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                </div> 
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


</asp:Content>

