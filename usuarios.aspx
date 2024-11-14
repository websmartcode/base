<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="usuarios.aspx.vb" Inherits="usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">

     <%--   <Triggers>
            <asp:PostBackTrigger ControlID="btnaddempresa" />
        </Triggers>--%>

        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress7" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
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

            <div class="row" style="margin-left: 1rem; margin-top: 1rem; margin-right: 1rem;">
                <div class="box box-primary " style="-webkit-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77); -moz-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77); box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77);">

                    <div class="box box-header">
                        <b>Usuários</b>
                        <asp:HiddenField ID="hdnnrseq" runat="server" />
                        <asp:HiddenField ID="hdnovousuario" runat="server" Value="nao" />
                    </div>
                    <div class="box-body" style="padding: 1rem">
                        <div class="row">
                            <div class="col-lg-12 text-center">
                                <asp:LinkButton ID="btnnovo" runat="server" CssClass="btn btn-primary "><i class="fas fa-plus-circle"></i> Novo</asp:LinkButton>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-3">

                                <asp:HiddenField ID="hdnrsequsuario" runat="server" />
                                <asp:HiddenField ID="hdemailantigo" runat="server" />
                                <b>Usuário</b>
                                <br />
                                <asp:TextBox ID="txtusuario" runat="server" class="form-control input-sem-mascara"></asp:TextBox>

                            </div>

                            <div class="col-lg-3">

                                <b>E-mail</b>
                                <br />
                                <asp:TextBox ID="txtemail" runat="server" class="form-control input-sem-mascara"></asp:TextBox>

                            </div>
                            <div class="col-lg-3">
                                <b>Permissão de acesso</b>
                                <br />
                                <asp:DropDownList ID="cboPermissao" runat="server" class="form-control" AutoPostBack="True">
                                </asp:DropDownList>
                                <br />
                                <asp:CheckBox ID="chkmaster" runat="server" Text="Usuário Master" Checked="false" Visible="false" />
                            </div>

                            <div class="col-lg-2">
                                <b>Empresas</b>
                                <br />
                                <asp:DropDownList ID="cboempresas" runat="server" class="form-control" AutoPostBack="True">
                                </asp:DropDownList>
                                <div class="row" visible =" false" id="divunidades" autopostback="True" runat="server">
                                    <div class="col-lg-12">
                                        <b>Unidades</b>
                                        <br />
                                        <asp:DropDownList ID="cbounidades" runat="server" class="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-1">
                                <br />
                                <asp:LinkButton ID="btnaddempresa" runat="server" CssClass="btn btn-xs" BackColor="Green" ForeColor="white"><i class="fa fa-plus" AutoPostBack="True"></i></asp:LinkButton>
                            </div>

                        </div>
                        <div class="row" style="margin-top: 1rem">
                            <div class="col-lg-6"></div>
                            <div class="col-lg-5" style="padding: 1rem; border-radius: 15px; background-color: antiquewhite">
                                <div class="text-center " style="margin-bottom: 1rem">
                                    <b>Empresas e Unidades do Usuários</b>
                                    <asp:HiddenField runat="server" ID="texthide" Value="0" />
                                </div>
                                <asp:Repeater ID="rptempresasunidades" runat="server">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnrseqacao" runat="server" Value='<%#Bind("nrseq") %>'></asp:HiddenField>
                                        <asp:HiddenField ID="hdativograde" runat="server" Value='<%#Bind("ativo")%>'></asp:HiddenField>
                                        <div class="row">
                                            <div class="col-lg-1 text-center">
                                                <asp:Label ID="lblitemrpt" runat="server" Text='<%#Container.ItemIndex + 1 %>' CssClass="badge"></asp:Label>
                                            </div>
                                            <div class="col-lg-8 text-center">
                                                <asp:Label ID="lblempresarpt" runat="server" Text='<%#Bind("Razaosocialempresa") %>'></asp:Label>
                                                <br />
                                                <asp:Repeater ID="rptunidadesrptt" runat="server">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdnrseqacaounidades" runat="server" Value='<%#Bind("nrseq") %>'></asp:HiddenField>
                                                        <div class="row">
                                                            <div class="col-lg-1">
                                                                <asp:Label ID="lblitrpt" runat="server" CssClass="badge" Text='<%#Container.ItemIndex + 1 %>'></asp:Label>
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <asp:Label ID="lblunidaderpt" runat="server" CssClass="label label-success " Text='<%#Bind("nomeunidade") %>'></asp:Label>
                                                            </div>
                                                            <asp:LinkButton ID="btnexcluirrpt" runat="server" CssClass="btn btn-xs" BackColor="Red" ForeColor="White" Style="margin-left: 0.5rem"><i class="fa fa-trash "></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div class="col-lg-2 text-center">
                                                <asp:LinkButton ID="btnexcluirrpt" runat="server" CommandName="excluir" CssClass="btn btn-xs" BackColor="Red" ForeColor="White"><i class="fa fa-trash "></i></asp:LinkButton>
                                            </div>

                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-2 ">
                                <b>Celular</b>
                                <br />
                                <asp:TextBox ID="txtcelular" onkeyup="formataCelular(this,event);" runat="server" CssClass="form-control "></asp:TextBox>
                            </div>
                            <div class="col-lg-2 ">
                                <asp:CheckBox ID="chknotificaremail" Enabled="false" runat="server" Text="Notificar por e-mail" />
                                <br />
                                <asp:CheckBox ID="chknotificarcelular" Enabled="false" runat="server" Text="Notificar por celular" />


                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6 text-center">
                                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="127px" CssClass="btn btn-primary " />
                            </div>
                            <div class="col-lg-6 text-center">
                                <asp:LinkButton ID="btncancelar" runat="server" CssClass="btn btn-danger "><i class="fa fa-ban" aria-hidden="true"></i> Cancel</asp:LinkButton>
                            </div>
                        </div>
                        <br />

                        <div class="box box-success ">
                            <div class="box box-header ">
                            </div>
                            <div class="box-body ">
                                <div class="row">
                                    <asp:Panel runat="server" DefaultButton="btnpesquisar">
                                        <div class="col-lg-12">
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    Procurar usuários
                                        <br />
                                                    <asp:TextBox ID="txtpesquisar" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>

                                                <div class="col-lg-2">
                                                    Empresa
                                                    <br />
                                                    <asp:DropDownList ID="cboempresaprocura" runat="server" CssClass="form-control "></asp:DropDownList>
                                                </div>
                                                <div class="col-lg-1" style="margin-left: -20px">
                                                    <br />
                                                    <asp:LinkButton ID="btnpesquisar" runat="server" CssClass="btn btn-primary"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-4"></div>
                                                <div class="col-lg-2">
                                                    <asp:Repeater ID="rptprocunidades" runat="server">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkselrpt" runat="server" />
                                                            <asp:Label ID="lblunidaderpt" runat="server" Text='<%Bind("unidade") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                        <style>
                                            .lblcheck label {
                                                padding: 0 0.5rem;
                                            }
                                        </style>
                                        <div class="row">
                                            <div class="col-lg-3 ">
                                                <asp:CheckBox ID="chkexibirativos" runat="server" Checked="true" Text="Usuários ativos" AutoPostBack="true" CssClass="lblcheck" />
                                                <br />
                                                <asp:CheckBox ID="chkfiltro_master" runat="server" Checked="true" BackColor="#ffd17d" Text="Usuários masters" AutoPostBack="true" CssClass="lblcheck" />
                                                <br />
                                                <asp:CheckBox ID="chkexibirsuspensos" runat="server" Text="Usuários suspensos" AutoPostBack="true" BackColor="#ffc5ff" CssClass="lblcheck" />
                                                <br />
                                                <asp:CheckBox ID="chkexibirinativos" runat="server" Text="Usuários excluidos" AutoPostBack="true" BackColor="#ff9292" CssClass="lblcheck" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12">
                                <br />
                                <div style="overflow: auto; max-height: 20rem">
                                    <asp:GridView ID="grade" runat="server" ShowHeaderWhenEmpty="true" EmptyDataText="Nenhum usuário encontrado !" CssClass="table" GridLines="none" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="It">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Container.DisplayIndex + 1 %>' CssClass="badge"></asp:Label>
                                                    <asp:HiddenField ID="hdnrseqgrade" runat="server" Value='<%#Bind("nrseq")%>'></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnativo" runat="server" Value='<%#Bind("ativo")%>'></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnsuspenso" runat="server" Value='<%#Bind("suspenso")%>'></asp:HiddenField>
                                                    <asp:HiddenField ID="hdemail_notificargrade" runat="server" Value='<%#Bind("email_notificar")%>'></asp:HiddenField>
                                                    <asp:HiddenField ID="hdwhats_notificargrade" runat="server" Value='<%#Bind("whats_notificar")%>'></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="User">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblusuariograde" Text='<%#Bind("usuario") %>'></asp:Label>
                                                    <br />
                                                    <asp:Label runat="server" ID="lblemailgrade" Text='<%#Bind("email") %>' Font-Size="X-Small"></asp:Label>
                                                    <br />
                                                    <asp:Label runat="server" ID="lblcelulargrade" Text='<%#Bind("celular") %>' Font-Size="X-Small"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Permissão">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblpermissao" Text='<%#Bind("permissao") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Notificações">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblemail_notifgrade" runat="server" Text="E-mail" Style="margin-left: 1rem"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblwhats_notifgrade" runat="server" Text="Whatsapp" Style="margin-left: 1rem"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Empresas" HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:Repeater ID="rptempresasgrade" runat="server">
                                                        <ItemTemplate>
                                                            <div class="row">

                                                                <div class="col-lg-1 text-center">
                                                                    <asp:Label ID="lblitemrpt" runat="server" Text='<%#Container.ItemIndex + 1 %>' CssClass="badge"></asp:Label>
                                                                </div>
                                                                <div class="col-lg-11 text-center">
                                                                    <asp:Label ID="lblempresarpt" runat="server" Text='<%#Bind("Razaosocialempresa") %>'></asp:Label>
                                                                    <br />
                                                                    <asp:Repeater ID="rptunidadesrpt" runat="server">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblunidaderpt" runat="server" CssClass="label label-success " Text='<%#Bind("nomeunidade") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnalterargrade" runat="server" CssClass="btn btn-primary btn-xs" CommandName="editar" CommandArgument='<%#Container.DataItemIndex%>'><i class="fa fa-pencil-square-o" aria-hidden="true"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="btnexcluirgrade" runat="server" CssClass="btn btn-danger btn-xs" CommandName="excluir" CommandArgument='<%#Container.DataItemIndex%>'><i class="fa fa-trash" aria-hidden="true"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="btnreativar" runat="server" CssClass="btn btn-danger btn-xs" Visible="false" CommandName="excluir" CommandArgument='<%#Container.DataItemIndex%>'><i class="fa fa-refresh" aria-hidden="true"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="btnrecuperarsenha" runat="server" CssClass="btn btn-warning btn-xs" CommandName="recuperarsenha" CommandArgument='<%#Container.DataItemIndex%>'><i class="fa fa-key" aria-hidden="true"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="btnmaster" runat="server" CssClass="btn btn-bitbucket     btn-xs" ToolTip="Change user to master or normal access" CommandName="master" CommandArgument='<%#Container.DataItemIndex%>'><i class="fa fa-user-secret" id="imgusergrade" runat="server" aria-hidden="true"></i></asp:LinkButton>
                                                    <asp:HiddenField ID="hdusergrade" runat="server" Value='<%#Bind("master") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>

                            </div>
                        </div>
                        <br />





                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

