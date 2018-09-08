<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fazenda.aspx.cs" Inherits="Fazenda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/fazenda.css" rel="stylesheet" />
    <script src="javascript/fazenda.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server" style="background-image: none; background-color: #FFFFFF;">

        <!--menu-->
        <ul id="top-bar" class="nav nav-tabs nav-justified btn-success ">
			<li >
                 <asp:LinkButton ID="LinkButton1" runat="server" class="menu" ForeColor="#666666" OnClick="LinkButton1_Click">Cooperativas</asp:LinkButton>
			</li>
		    <li>
                 <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="#666666" OnClick="LinkButton2_Click">Amostras solicitadas</asp:LinkButton>
		    </li>
            <li> 
                 <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="#666666" OnClick="LinkButton3_Click">Meu Perfil</asp:LinkButton>
            </li>
            <li> 
                 <asp:LinkButton ID="LinkButton4" runat="server" ForeColor="#666666" OnClick="LinkButton4_Click">Historico de Negociação</asp:LinkButton>
            </li>
            <li> 
                 <asp:LinkButton ID="LinkButton5" runat="server" ForeColor="#666666" OnClick="LinkButton5_Click">Sair</asp:LinkButton>
            </li>
	    </ul>
        <asp:TextBox ID="BoxCoo" runat="server" Visible="False"></asp:TextBox>
        <%-- div de alerta --%>
            <div class="alert alert-success   " id="Alerta" runat="server"> 
                <asp:Label ID="Labelalerta" runat="server" Text="Label"></asp:Label>
                <span class="close" onclick="this.parentElement.style.display='none';">&times;</span> 
            </div>
          <%-- div de alerta  de erro--%>
            <div class="alert alert-danger" id="Div_Error" runat="server"> 
                <asp:Label ID="Label1" runat="server">Não foi posivel Iniciar a negociação pois algum campo não foi preenchido corretamente</asp:Label>
                <span class="close" onclick="this.parentElement.style.display='none';">&times;</span> 
            </div>

        <!--tela de bem vindo-->
         <center><div runat="server" id="Divbemvindo" style="background:rgba(66, 72, 55, 0.16); width: 80%; margin-top:10px; border:1px solid;">
                <div id="Div6" runat="server"  class="form-group ">
                <h1><asp:Label ID="LabelBemvindo" runat="server" Text="Label"></asp:Label></h1>
                </div>
			</div></center>


        <!--busca coperativa-->
        <center><div runat="server" id="Div_Busca_Cooperativa" style="background:rgba(66, 72, 55, 0.16); width: 80%; margin-top:10px; border:1px solid;">
                <div id="Div3" runat="server"  class="form-group ">
                <h1>Cooperativas
                    
                    </h1>
                    <asp:GridView ID="GridViewBuscaCooperativa" runat="server" class="table table-bordered "  BorderColor="#66FF66" OnRowDataBound="GridViewBuscaCooperativa_RowDataBound"  >     
                        <HeaderStyle BackColor="#5AC23D" BorderColor="#66FF66" />
                                              
                </asp:GridView>
                 </div>
			</div></center>


           <!--Amostra Solicitadas-->
           <center><div runat="server" id="Div_Amostra_Solicitada" style="background:rgba(66, 72, 55, 0.16); width: 80%; margin-top:10px; border:1px solid;">		
                <div id="Div2" runat="server"  class="form-group ">
                    <h1>Amostras Solicitadas<asp:Label ID="Labelteste" runat="server" Visible="False"></asp:Label>
                    </h1>                
                    <asp:GridView ID="GridViewAmostrax" runat="server" class="table table-bordered" OnRowCommand="GridViewAmostrax_RowCommand" OnSelectedIndexChanged="GridViewAmostrax_SelectedIndexChanged" OnRowDataBound="GridViewAmostrax_RowDataBound" OnRowDeleting="GridViewAmostrax_RowDeleting">
                        <Columns> 
                            <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Abrir Negociação" />
                            <asp:CommandField DeleteText="Deletar Amostra" ShowDeleteButton="True" ButtonType="Button"></asp:CommandField>

                        </Columns>
                        <HeaderStyle BackColor="#5AC23D" BorderColor="#66FF66" />
                    </asp:GridView>  
                
                  

               </div>
           </div></center>

        <!--perfil do produtor-->
             <div class="container" id="Div_Perfil_do_Produtor" runat="server">    
                <div class="jumbotron">
                  <div class="row">
                      <div class="col-md-4 col-xs-12 col-sm-6 col-lg-4">
                          <img src="https://www.svgimages.com/svg-image/s5/man-passportsize-silhouette-icon-256x256.png" alt="stack photo" class="img">
                      </div>
                      <div class="col-md-8 col-xs-12 col-sm-6 col-lg-8">
                          <div class="container" style="border-bottom:1px solid black">
                            <h2><asp:Label ID="LabelNome" runat="server" Text="Label"></asp:Label>&nbsp;</h2>
                          </div>
                            <hr>
                          <ul class="container details">
                            <li><p><span class="glyphicon glyphicon-earphone one" style="width:50px;"></span><asp:Label ID="LabelTelefone" runat="server" Text="Label"></asp:Label></p></li>
                            <li><p><span class="glyphicon glyphicon-envelope one" style="width:50px;"></span><asp:Label ID="Labelemail" runat="server" Text="Label"></asp:Label></p></li>
                             <li><p><span class="glyphicon glyphicon-home" style="width:50px;"></span><asp:Label ID="LabelCidade" runat="server" Text="Label"></asp:Label></p></li>
                            <p align="Right"><asp:LinkButton ID="LinkButton7" runat="server" ForeColor="#666666" style="color: rgb(0, 0, 255);" OnClick="LinkButton7_Click">Editar Dados</asp:LinkButton></p>
                          </ul>
                      </div>
                  </div>
                </div>
              </div>

        <!--Historico de Negociação-->
           <center><div runat="server" id="Div_Historico_de_Negociação" style=" background:rgba(66, 72, 55, 0.16); width: 80%; margin-top:10px; border:1px solid;">		
               <h1>Negociações</h1>	
            <div id="Div1" runat="server"  class="form-group ">
                
					
		        <asp:GridView ID="GridViewNegociação" runat="server" class="table table-bordered" OnRowDeleting="GridViewNegociação_RowDeleting">
                       <Columns> 
                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Deletar Negociação" />
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
				<asp:TextBox ID="TextBoxnome" runat="server" class="form-control" placeholder="Nome"></asp:TextBox>
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
                <asp:DropDownList ID="DropDownCidade" class="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nome" DataValueField="Id"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Nome] FROM [Cidade]"></asp:SqlDataSource>
                <br/>
                <asp:Button ID="Button3" runat="server" Text="Salvar" class="btn btn-lg btn-success" OnClick="Button3_Click"/>	
			</div>
           </div></center>

        <!--Iniciar Negociação-->
        <center><div runat="server" id="Div_Iniciar_Negociação" style=" background:rgba(66, 72, 55, 0.16); width: 80%; margin-top:10px; border:1px solid;">					
            <div runat="server"  class="form-group ">
                <h1>Iniciar Negociação</h1>
                <br/>
				<label for="password" class="sr-only">Cooperativa</label>
				<asp:TextBox ID="TextBoxINCoop" runat="server" class="form-control" placeholder="Cooperativa"></asp:TextBox>
                <br/>
                <label for="password" class="sr-only">Valor por Saca</label>
				<asp:TextBox ID="TextBoxINValorSaca" runat="server" class="form-control" placeholder="Valor por Saca"></asp:TextBox>
                <br/>
                <label for="password" class="sr-only">Tipo</label>
				<asp:TextBox ID="TextBoxINTipo" runat="server" class="form-control" placeholder="Tipo"></asp:TextBox>
                <br/>
                <label for="password" class="sr-only">Bebida</label>
				<asp:TextBox ID="TextBoxINBebida" runat="server" class="form-control" placeholder="Bebida"></asp:TextBox>
                <br/>
                <label for="password" class="sr-only">Quntidade</label>
				<asp:TextBox ID="TextBoxINQuantidade" runat="server" class="form-control" placeholder="Quantidade de Sacas" TextMode="Number"   ></asp:TextBox>
                <br/>
                <asp:Button ID="ButtonINNegociar" runat="server" Text="Negociar" class="btn btn-lg btn-success" OnClick="ButtonINNegociar_Click"/>	
			</div>
           </div></center>

    </form>
</body>
</html>

