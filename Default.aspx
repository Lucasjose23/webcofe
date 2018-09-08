<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/default.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
         <%-- div de alerta --%>
            <div class="alert alert-success   " id="Alerta" runat="server"> 
                <asp:Label ID="Labelalerta" runat="server" Text="Label"></asp:Label>
                <span class="close" onclick="this.parentElement.style.display='none';">&times;</span> 
            </div>
             <%-- div de alerta  de erro--%>
            <div class="alert alert-danger" id="Div_Error" runat="server"> 
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <span class="close" onclick="this.parentElement.style.display='none';">&times;</span> 
            </div>
        <div>
           <center> <asp:Label ID="Label2" runat="server" Text="Web Coffee" Font-Bold="True" Font-Italic="True" Font-Names="Arial Black" Font-Size="XX-Large" ForeColor="#666633"></asp:Label></center>
        </div>
        <div class="login-body">
            <article class="container-login center-block">
		        <section>
			        <ul id="top-bar" class="nav nav-tabs nav-justified">
				        <li class="active"><a href="#login-access">Produtor</a></li>
				        <li><a href="Default2.aspx">Cooperativa</a></li>
			        </ul>
			        <div class="tab-content tabs-login col-lg-12 col-md-12 col-sm-12 cols-xs-12">
				        <div id="login-access" class="tab-pane fade active in">
					        <h2><i class="glyphicon glyphicon-user "></i> Produtor</h2>						
					
						        <div runat="server" id="DivLoginFazen" class="form-group ">
							        <label for="login" class="sr-only">Email</label>
							        <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                                    <br/>
							        <label for="password" class="sr-only">Password</label>
							        <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Senha" TextMode="Password"></asp:TextBox>
                                    <br/>				
							        <asp:Button ID="Button1" runat="server" Text="Entrar" class="btn btn-lg btn-success" OnClick="Button1_Click"/>	
                                    <asp:Button ID="Button2" runat="server" Text="Cadastrar-se" class="btn btn-lg btn-success" OnClick="Button2_Click"/>	
						        </div>

                                <div runat="server" id="DivCadFazen" class="form-group ">
                                    <label for="login" class="sr-only">CPF:</label>
                                    <asp:TextBox ID="TextBoxCPF" runat="server" class="form-control" placeholder="CPF"></asp:TextBox>
                                    <br/>	
                                    <label for="login" class="sr-only">Nome:</label>
                                    <asp:TextBox ID="TextBoxNOME" runat="server" class="form-control" placeholder="Nome"></asp:TextBox>
                                    <br/>	
                                    <label for="login" class="sr-only">Telefone:</label>
                                    <asp:TextBox ID="TextBoxTELEFONE" runat="server" class="form-control" placeholder="Telefone"></asp:TextBox>
                                    <br/>	
                                    <label for="password" class="sr-only">Cidade</label>
                                    <asp:DropDownList ID="DropDownESTADO" runat="server" class="form-control" placeholder="Estado"></asp:DropDownList>
                                    <br/>
                                    <label for="password" class="sr-only">Estado</label>
				                    
                                    <asp:DropDownList ID="DropDownCIDADE" runat="server" class="form-control" placeholder="Cidade"></asp:DropDownList>
                                    
                                    <br/>	
                                    <label for="login" class="sr-only">Login</label>
                                    <asp:TextBox ID="TextBoxEMAIL" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                                    <br/>	
                                    <label for="login" class="sr-only">Senha:</label>
                                    <asp:TextBox ID="TextBoxSENHA" runat="server" class="form-control" placeholder="Senha"></asp:TextBox>	
                                    <br/>			
							        <asp:Button ID="Button3" runat="server" Text="Cadastrar" class="btn btn-lg btn-success" OnClick="Button3_Click"/>	

						        </div>

                            
				        </div>
			        </div>
		        </section>
	        </article>
        </div>
        	
	        
    </div>
      
        
    </form>
    <footer id="rodape" style="position: absolute; bottom: 136px; top: 647px; left: 7px;"><!--conteudo do rpdape-->
            <p>Desenvolvido por: Lucas José da Silva, Diego Barbosa Pereira, Guilherme Damasceno</p>
            <p><a href="youtube.com">Facebook</a> | Twitter</p>
        </footer>
</body>
</html>

