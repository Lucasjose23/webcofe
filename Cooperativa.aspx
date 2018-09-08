<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cooperativa.aspx.cs" Inherits="Cooperativa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <link href="css/cooperativa.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--menu-->
            <ul id="top-bar" class="nav nav-tabs nav-justified btn-success ">
			    <li >
                     <asp:LinkButton ID="LinkButton1" runat="server" class="menu" ForeColor="#666666" OnClick="LinkButton1_Click">Nova Amostra</asp:LinkButton>
			    </li>
			    <li>
                    <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="#666666" OnClick="LinkButton2_Click">Amostras analizadas</asp:LinkButton>
		       </li>
               <li> 
                    <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="#666666" OnClick="LinkButton3_Click">Contatos</asp:LinkButton>
               </li>
               <li> 
                    <asp:LinkButton ID="LinkButton4" runat="server" ForeColor="#666666" OnClick="LinkButton4_Click">Perfil da empreza</asp:LinkButton>
               </li>
               <li> 
                    <asp:LinkButton ID="LinkButton5" runat="server" ForeColor="#666666" OnClick="LinkButton5_Click">Historico de Negociação</asp:LinkButton>
               </li>
               <li> 
                    <asp:LinkButton ID="LinkButton6" runat="server" ForeColor="#666666" OnClick="LinkButton6_Click">Sair</asp:LinkButton>
               </li>
	        </ul>
            <%-- div de alerta --%>
            <div class="alert alert-success   " id="Alerta" runat="server"> 
                <asp:Label ID="Labelalerta" runat="server" Text="Label"></asp:Label>
                <span class="close" onclick="this.parentElement.style.display='none';">&times;</span> 
            </div>
             <%-- div de alerta  de erro--%>
            <div class="alert alert-danger" id="Div_Erro" runat="server"> 
                <asp:Label ID="Label1" runat="server">Algum campo não foi preenchido corretamente</asp:Label>
                <span class="close" onclick="this.parentElement.style.display='none';">&times;</span> 
            </div>


            <!--Pagina Inicial-->
            <center><div runat="server" id="Divbemvindo" style="background:rgba(66, 72, 55, 0.16); width: 80%; margin-top:10px; border:1px solid;">
                <div id="Div6" runat="server"  class="form-group ">
                    <h1><asp:Label ID="LabelBemvindo" runat="server" Text="Label"></asp:Label></h1>
		        </div>
			</div></center>

            <!--Nova Amostra-->
            <center><div runat="server" id="Div_Nova_Amostra" style=" background:rgba(66, 72, 55, 0.16); width: 80%; margin-top:10px; border:1px solid;">					
            <div runat="server"  class="form-group ">
                <h1>Cadastrar Nova Amostra</h1>
                <br/>
				<label  class="sr-only">Produtor</label>
                <asp:DropDownList ID="DropDownProdutor" runat="server" class="form-control" placeholder="Produtor"></asp:DropDownList>
                <br/>
                <label for="password" class="sr-only">Tipo</label>
                <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" placeholder="Tipo"></asp:DropDownList>
                <br/>
                <label for="password" class="sr-only">Bebida</label>
				<asp:DropDownList ID="DropDownList2" runat="server" class="form-control" placeholder="Bebida"></asp:DropDownList>
                <br/>
                <label for="password" class="sr-only">Valor por Saca</label>
				<asp:TextBox ID="TextBox9" runat="server" class="form-control" placeholder="Valor por Saca R$"></asp:TextBox>
                <br/>					
                <asp:Button ID="Button2" runat="server" Text="Cadastrar" class="btn btn-lg btn-success" OnClick="Button2_Click"/>	
			</div>
           </div></center>

           <!--Amostra Analizadas-->
           <center><div runat="server" id="Div_Amostra_Analizada" style="background:rgba(66, 72, 55, 0.16); width: 80%; margin-top:10px; border:1px solid;">		
           <div id="Div1" runat="server"  class="form-group ">
                <h1>Amostras Analizadas</h1>
               <asp:GridView ID="GridViewAmostra" runat="server" class="table table-bordered" AutoGenerateColumns="False" >       
                    <Columns>
                        <asp:TemplateField HeaderText="Produtor" ControlStyle-CssClass="grid_descri">
                            <ItemTemplate>    <%#Eval("Nome") %>     </ItemTemplate>

<ControlStyle CssClass="grid_descri"></ControlStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tipo">
                            <ItemTemplate>    <%#Eval("TNome") %>    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bebida">
                            <ItemTemplate>    <%#Eval("BNome") %>    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor por saca">
                            <ItemTemplate>    <%#Eval("ValorPorSaca") %>    </ItemTemplate>
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="True" />
                        </asp:TemplateField>

                    </Columns>
                    <HeaderStyle BackColor="#5AC23D" BorderColor="#66FF66" />
                </asp:GridView>
               </div>
           </div></center>

            <!--Contato-->
            <center><div runat="server" id="Div_Contato" style="background:rgba(66, 72, 55, 0.16); width: 80%; margin-top:10px; border:1px solid;">
                <div id="Div2" runat="server"  class="form-group ">
                    <h1>Contatos</h1>
                    <asp:GridView ID="GridViewContato" runat="server"  class="table table-bordered" AutoGenerateColumns="False" >       
                        <Columns>
                            <asp:TemplateField HeaderText="Nome Produtor" ControlStyle-CssClass="grid_descri">
                                <ItemTemplate>    <%#Eval("Nome") %>     </ItemTemplate>

                                <ControlStyle CssClass="grid_descri"></ControlStyle>
                            </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Telefone">
                                <ItemTemplate>    <%#Eval("Telefone") %>    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>    <%#Eval("Email") %>    </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#5AC23D" BorderColor="#66FF66" />
                    </asp:GridView>
                </div>
			</div></center>

            <!--perfil da empreza-->
            <div class="container" id="Div_Perfil_da_Empreza" runat="server">    
                <div class="jumbotron">
                  <div class="row">
                      <div class="col-md-4 col-xs-12 col-sm-6 col-lg-4">
                          <img src="https://www.svgimages.com/svg-image/s5/man-passportsize-silhouette-icon-256x256.png" alt="stack photo" class="img">
                      </div>
                      <div class="col-md-8 col-xs-12 col-sm-6 col-lg-8">
                          
                          <div class="container" style="border-bottom:1px solid black">
                            <h2><asp:Label ID="LabelNome" runat="server" Text="Label"></asp:Label></h2>
                          </div>
                            <hr>
                          <ul class="container details">
                            <li><p><span class="glyphicon glyphicon-earphone one" style="width:50px;"></span><asp:Label ID="LabelTelefone" runat="server" Text="Label"></asp:Label></p></li>
                            <li><p><span class="glyphicon glyphicon-envelope one" style="width:50px;"></span><asp:Label ID="LabelEmail" runat="server" Text="Label"></asp:Label></p></li>
                            <li><p><span class="glyphicon glyphicon-map-marker one" style="width:50px;"></span><asp:Label ID="LabelEndereco" runat="server" Text="Label"></asp:Label></p></li>
                            <li><p><span class="glyphicon glyphicon-new-window one" style="width:50px;"></span><a href="#"><asp:Label ID="LabelSite" runat="server" Text="Label"></asp:Label></p></a>
                            <p align="Right"><asp:LinkButton ID="LinkButton7" runat="server" ForeColor="#666666" style="color: rgb(0, 0, 255);" OnClick="LinkButton7_Click">Editar Dados</asp:LinkButton></p>
                          </ul>
                      </div>
                  </div>
                </div>
              </div>


            <!--Historico de Negociação-->
           <center><div runat="server" id="Div_Historico_de_Negociação" style=" background:rgba(66, 72, 55, 0.16); width: 80%; margin-top:10px; border:1px solid;">		
               <div id="Div3" runat="server"  class="form-group ">
                   <h1>Negociações</h1>	
                   <asp:Label ID="labelstatus" runat="server" Text="Label" Visible="False"></asp:Label>
                   <asp:GridView ID="GridViewNegociação" runat="server" class="table table-bordered" OnRowCommand="GridViewNegociação_RowCommand" OnRowDataBound="GridViewNegociação_RowDataBound" >
                       <Columns>
                           <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Fechar Negociação" />
                       </Columns>
                     
                       <HeaderStyle BackColor="#5AC23D" BorderColor="#66FF66" />
                     
                   </asp:GridView>
		       </div>
          </div></center> 

            <!--Editar Perfil-->
            <center><div runat="server" id="Div_Editar_Perfil" style=" background:rgba(66, 72, 55, 0.16); width: 80%; margin-top:10px; border:1px solid;">					
            <div id="Div4" runat="server"  class="form-group ">
                <h1>Editar Perfil</h1>
                <br/>
				<label class="sr-only">Nome</label>
				<asp:TextBox ID="TextBoxNome" runat="server" class="form-control" placeholder="Nome"></asp:TextBox>
                <br/>
				<label class="sr-only">Telefone</label>
				<asp:TextBox ID="TextBoxTelefone" runat="server" class="form-control" placeholder="Telefone"></asp:TextBox>
                <br/>
                <label class="sr-only">Email</label>
				<asp:TextBox ID="TextBoxEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                <br/>
				<label class="sr-only">Endereço</label>
				<asp:DropDownList ID="DropDownEstado" class="form-control" runat="server" DataSourceID="SqlDataSource2" DataTextField="Nome" DataValueField="Id"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Nome] FROM [Estado]"></asp:SqlDataSource>
                <br/>
                <asp:DropDownList ID="DropDownCidade" runat="server" class="form-control" DataSourceID="SqlDataSource1" DataTextField="Nome" DataValueField="Id"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Nome], [Id] FROM [Cidade]"></asp:SqlDataSource>
                <br/>
                <label class="sr-only">Site</label>
				<asp:TextBox ID="TextBoxSite" runat="server" class="form-control" placeholder="Site"></asp:TextBox>
                <br/>					
                <asp:Button ID="Button1" runat="server" Text="Salvar" class="btn btn-lg btn-success" OnClick="Button1_Click"/>	
			</div>
           </div></center>
         <!--Iniciar Negociação-->
        <center><div runat="server" id="Div_FinalizarNeg" style=" background:rgba(66, 72, 55, 0.16); width: 80%; margin-top:10px; border:1px solid;">					
            <div runat="server"  class="form-group ">
                <h1>Finalizar Negociação</h1>
                <br/>
				<label for="password" class="sr-only">Produtor</label>
				<asp:TextBox ID="TextBoxINProd" runat="server" class="form-control" placeholder="Produtor" AutoCompleteType="FirstName">Produtor=</asp:TextBox>
                <br/>
                <label for="password" class="sr-only">Valor Total</label>
				<asp:TextBox ID="TextBoxINValorTotal" runat="server" class="form-control" placeholder="Valor Total" AutoCompleteType="FirstName">Valor Total =R$</asp:TextBox>
                <br/>
                <label for="password" class="sr-only">Tipo</label>
				<asp:TextBox ID="TextBoxINTipo" runat="server" class="form-control" placeholder="Tipo" AutoCompleteType="FirstName">Tipo=</asp:TextBox>
                <br/>
                <label for="password" class="sr-only">Bebida</label>
				<asp:TextBox ID="TextBoxINBebida" runat="server" class="form-control" placeholder="Bebida" AutoCompleteType="FirstName">Bebida=</asp:TextBox>
                <br/>
                <label for="password" class="sr-only">Quantidade</label>
				<asp:TextBox ID="TextBoxINQuantidade" runat="server" class="form-control" placeholder="Quantidade" AutoCompleteType="FirstName"   >Quantidade=</asp:TextBox>
                <br/>
                <asp:Button ID="ButtonINNegociar" runat="server" Text="Finalizar" class="btn btn-lg btn-success" OnClick="ButtonINNegociar_Click"/>	
			</div>
           </div></center>






        </div>
    </form>
</body>
</html>
