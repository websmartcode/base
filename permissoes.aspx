<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="permissoes.aspx.vb" Inherits="restrito_permissoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="Server">
    <script language="javascript" type="text/javascript">

        function ir_topo() {

            $("html, body").animate({
                scrollTop: 0
            }, 1200);
            $("html, body").animate({
                scrollTop: 0
            }, 1200);


        }

        function fecharmodalstatus() {
            //$('.fechar').click(function (ev) {

            $(".windowsdth").hide();
            $(".windowsdth").closest;

            //}

        }
        function exibirnovostatus() {
            var alturaTela = $(document).height() * 2;
            var larguraTela = $(window).width();

            // colocando o fundo preto


            //      alert('Registro gravado com sucesso2!');

            var left = ($(window).width() / 2) - ($('#alterarststatus').width() / 4);
            var top = 100;


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

    <div class="box box-primary" style="-webkit-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77); -moz-box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77); box-shadow: 9px 7px 5px rgba(50, 50, 50, 0.77);">

        <div class="box box-header ">
            <b>Permissão de Acessos</b>
        </div>
        <div class="box-body">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="row">
                        <center>
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <asp:Button ID="btnNova" runat="server" Text="   Criar Nova Permissão    " CssClass="btn btn-primary" Enabled="true" />
                                </div>
                            </div>
                        </center>
                    </div>
                    <div class="row">
                        <div class="col-lg-2">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtcodigo" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-6">
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="Descrição"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtdescricao" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            Tipo de acesso
                                <br />
                            <asp:DropDownList ID="cbogrupo" runat="server" CssClass="form-control " AutoPostBack="true">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Adm</asp:ListItem>
                                <asp:ListItem>Clientes</asp:ListItem>
                                <asp:ListItem>Departamentos</asp:ListItem>
                                <asp:ListItem>Fornecedores</asp:ListItem>

                            </asp:DropDownList>
                        </div>


                    </div>



                    <div class="row">

                        <div class="col-lg-5">
                            <div class="box box-danger ">
                                <div class="box box-header "><b>Páginas sem acesso</b></div>
                                <div class="box-body ">

                                    <asp:CheckBox ID="chkseltodos01" runat="server" Text="Select All" AutoPostBack="true" />
                                    <br />
                                    <div style="overflow: auto; max-height: 20rem">
                                        <asp:GridView ID="GradeForms" CssClass="table" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="Nothing page found" Style="text-align: center; margin-bottom: 0px;" Width="100%" GridLines="none">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sel">

                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="sel" runat="server" />

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="pagina" HeaderText="Name" />
                                            </Columns>

                                            <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                            <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                            <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                            <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                        </asp:GridView>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 text-center">
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnadd" runat="server" Text="Adicionar" CssClass="btn btn-success" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <br />
                                <br />
                                <br />
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnremove" runat="server" Text="Remover" CssClass="btn btn-warning " />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                    <ProgressTemplate>
                                        <img src="../img/carregando1.gif" width="50px" height="50px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="col-lg-5">
                            <div class="box box-success ">
                                <div class="box box-header "><b>Páginas com Acesso</b></div>
                                <div class="panel-body ">

                                    <asp:CheckBox ID="chkseltodos02" runat="server" Text="Select All" AutoPostBack="true" />
                                    <br />
                                    <div style="overflow: auto; max-height: 20rem">
                                        <asp:GridView ID="GradeFormsSel" CssClass="table" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataText="No pages found" Style="text-align: center; margin-bottom: 0px;" Width="100%" GridLines="none">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sel">

                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="sel" runat="server" />

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="pagina" HeaderText="Name" />
                                            </Columns>

                                            <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                            <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                            <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                            <SortedDescendingHeaderStyle BackColor="#7E0000" />

                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <center>

                            <div class="col-lg-12">
                                <div class="form-group">

                                    <asp:Button ID="btnSalvar" runat="server" Text="   Salvar     " CssClass="btn btn-danger " Enabled="false" />




                                </div>
                            </div>
                        </center>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <div style="overflow: auto; max-height: 20rem">
                                    <asp:GridView ID="grade" runat="server" AutoGenerateColumns="False" CssClass="table" ForeColor="Black" GridLines="none" ShowHeaderWhenEmpty="True" EmptyDataText="No records found !" PageSize="6">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sel">

                                                <ItemTemplate>
                                                    <asp:CheckBox ID="sel2" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="nrseq" HeaderText="ID" />
                                            <asp:BoundField DataField="dtcad" HeaderText="Data" />
                                            <asp:BoundField DataField="descricao" HeaderText="Permissão" />

                                            <asp:TemplateField>

                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdativo" runat="server" Value='<%# Bind("ativo")%>'></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ButtonField ButtonType="Image" runat="server" HeaderText="Edit" CommandName="alterar" ImageUrl="~\img\alterarverde.png">
                                                <ControlStyle Width="27px" Height="27px"></ControlStyle>

                                            </asp:ButtonField>
                                            <asp:ButtonField ButtonType="Image" runat="server" HeaderText="Delete" CommandName="excluir" ImageUrl="~\img\imgnao.png">
                                                <ControlStyle Width="27px" Height="27px"></ControlStyle>

                                            </asp:ButtonField>
                                            <asp:ButtonField ButtonType="Image" runat="server" HeaderText="Open" CommandName="ver" ImageUrl="~\img\placaolho.png" Visible="false">
                                                <ControlStyle Width="27px" Height="27px"></ControlStyle>

                                            </asp:ButtonField>
                                            <%--  <asp:ButtonField ButtonType="Button" CommandName="Alterar" Text="  Alterar  ">
                                            <ControlStyle CssClass="botaoredondo" />
                                            <ItemStyle CssClass="botaored" />
                                        </asp:ButtonField>--%>
                                            <%--  <asp:ButtonField ButtonType="Button" CommandName="Excluir" Text="  Remover  ">
                                            <ControlStyle CssClass="botaoredondo" />
                                            <ItemStyle CssClass="botaored" />
                                        </asp:ButtonField>--%>
                                        </Columns>


                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:CheckBox ID="chkExibirExcluidos" Text="Show Deleted" runat="server" AutoPostBack="true" />

                            </div>
                        </div>

                        <div class="col-lg-2">
                            <div class="form-group">

                                <asp:Button ID="btnRemover" runat="server" Text="Delete selected" CssClass="btn btn-primary" Enabled="true" Visible="false" />

                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">

                                <asp:Button ID="btnBaixar" runat="server" Text="Baixar Selecionados" CssClass="btn btn-primary" Enabled="true" Visible="false" />

                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">

                                <asp:Button ID="btnProcurar" runat="server" Text="Localizar" CssClass="btn btn-primary" Enabled="true" Visible="false" />

                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">

                                <asp:Button ID="btnanexar" runat="server" Text="Anexar Documentos" CssClass="btn btn-primary" Enabled="true" Visible="false" />

                            </div>
                        </div>
                        </center>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </div>
</asp:Content>

