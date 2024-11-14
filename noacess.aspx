<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="noacess.aspx.vb" Inherits="noacess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="Server">
    <div class="box box-success " style="padding: 1rem; -webkit-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77); -moz-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77); box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77);">
        <div class="box-body ">
            <div class="row">
                <div class="col-lg-2 ">
                    <asp:Image ID="imgsemacesso" runat="server" ImageUrl="~/img/alerta01.png" Style="width: 5rem; height: 5rem" />
                </div>
                <div class="col-lg-10 ">
                    <asp:Label ID="lblacesso" runat="server" Text="Desculpe, você não tem acesso à essa operação!" Font-Bold="true" Font-Size="15"></asp:Label>
                </div>
            </div>
            <div class="row">

                <div class="col-lg-12 text-center">
                    <br />
                    <br />
                    <br />
                    <asp:Image ImageUrl="~/img/robo.png" runat="server" ID="imgrobo" Style="height: 25rem" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

