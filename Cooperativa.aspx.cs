using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cooperativa : System.Web.UI.Page
{
    Coop c = new Coop();
    protected void Page_Load(object sender, EventArgs e)
    {
        string cnpj;
        try
        {
            cnpj = Request.QueryString["CNPJ"].ToString();
            this.Div_Nova_Amostra.Visible = false;
            this.Div_Amostra_Analizada.Visible = false;
            this.Div_Contato.Visible = false;
            this.Div_Perfil_da_Empreza.Visible = false;
            this.Div_Historico_de_Negociação.Visible = false;
            this.Div_Editar_Perfil.Visible = false;
            this.Divbemvindo.Visible = true;
            this.Alerta.Visible = false;
            this.Div_Erro.Visible = false;
            this.Div_FinalizarNeg.Visible = false;

            c.alocacooperativa(cnpj);
            LabelBemvindo.Text = c.Nome;
        }
        catch(Exception error)
        {
            Response.Redirect("Default2.aspx");
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e) //Nova Amostra
    {
        Produtor p = new Produtor();
        DropDownProdutor.DataSource = p.PesquisaProdutor();
        DropDownProdutor.DataTextField = "Nome";
        DropDownProdutor.DataValueField = "Cpf";
        DropDownProdutor.DataBind();
        DropDownProdutor.Items.Insert(0, new ListItem("Produtor", "0"));
        TipoCafe TC = new TipoCafe();
        DropDownList1.DataSource = TC.PesquisaTipo();
        DropDownList1.DataTextField = "TNome";
        DropDownList1.DataValueField = "Id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("Tipo", "0"));
        BebidaCafe BC = new BebidaCafe();
        DropDownList2.DataSource = BC.PesquisaBebida();
        DropDownList2.DataTextField = "BNome";
        DropDownList2.DataValueField = "Id";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("Bebida", "0"));
        this.Div_Nova_Amostra.Visible = true;
        this.Div_Amostra_Analizada.Visible = false;
        this.Div_Contato.Visible = false;
        this.Div_Perfil_da_Empreza.Visible = false;
        this.Div_Historico_de_Negociação.Visible = false;
        this.Div_Editar_Perfil.Visible = false;
        this.Divbemvindo.Visible = false;
        this.Div_Erro.Visible = false;
        TextBox9.Text = "";
    }

    protected void LinkButton2_Click(object sender, EventArgs e) //Amostras Analizadas
    {
        AmostraCafe a = new AmostraCafe();
        GridViewAmostra.DataSource = a.PesquisaamostraCooperativa(c.Cnpj);
        GridViewAmostra.DataBind();

        this.Div_Nova_Amostra.Visible = false;
        this.Div_Amostra_Analizada.Visible = true;
        this.Div_Contato.Visible = false;
        this.Div_Perfil_da_Empreza.Visible = false;
        this.Div_Historico_de_Negociação.Visible = false;
        this.Div_Editar_Perfil.Visible = false;
        this.Divbemvindo.Visible = false;
        this.Div_Erro.Visible = false;
    }

    protected void LinkButton3_Click(object sender, EventArgs e) //Contato
    {
        Produtor p = new Produtor();
        GridViewContato.DataSource = p.PesquisaProdutor();
        GridViewContato.DataBind();
        this.Div_Nova_Amostra.Visible = false;
        this.Div_Amostra_Analizada.Visible = false;
        this.Div_Contato.Visible = true;
        this.Div_Perfil_da_Empreza.Visible = false;
        this.Div_Historico_de_Negociação.Visible = false;
        this.Div_Editar_Perfil.Visible = false;
        this.Divbemvindo.Visible = false;
        this.Div_Erro.Visible = false;
    }

    protected void LinkButton4_Click(object sender, EventArgs e) //Perfil da Empreza
    {
        this.Div_Nova_Amostra.Visible = false;
        this.Div_Amostra_Analizada.Visible = false;
        this.Div_Contato.Visible = false;
        this.Div_Perfil_da_Empreza.Visible = true;
        this.Div_Historico_de_Negociação.Visible = false;
        this.Div_Editar_Perfil.Visible = false;
        this.Divbemvindo.Visible = false;
        this.Div_Erro.Visible = false;
        LabelNome.Text = c.Nome;
        LabelTelefone.Text = c.Telefone;
        LabelEmail.Text = c.Email;
        Cidade ci = new Cidade();
        LabelEndereco.Text = ci.nomecidade(c.Idcidade);
        LabelSite.Text = c.Site;
    }

    protected void LinkButton5_Click(object sender, EventArgs e) //Historico de Negociação
    {
        Negociacao n = new Negociacao();
        GridViewNegociação.DataSource = n.PesquisanegCooperativa(c.Cnpj);
        
        GridViewNegociação.DataBind();
        this.Div_Nova_Amostra.Visible = false;
        this.Div_Amostra_Analizada.Visible = false;
        this.Div_Contato.Visible = false;
        this.Div_Perfil_da_Empreza.Visible = false;
        this.Div_Historico_de_Negociação.Visible = true;
        this.Div_Editar_Perfil.Visible = false;
        this.Divbemvindo.Visible = false;
        this.Div_Erro.Visible = false;
    }

    protected void LinkButton6_Click(object sender, EventArgs e) //Sair
    {
        Response.Redirect("Default2.aspx");
    }

    protected void LinkButton7_Click(object sender, EventArgs e) //Editar Perfil
    {
        this.Div_Nova_Amostra.Visible = false;
        this.Div_Amostra_Analizada.Visible = false;
        this.Div_Contato.Visible = false;
        this.Div_Perfil_da_Empreza.Visible = false;
        this.Div_Historico_de_Negociação.Visible = false;
        this.Div_Editar_Perfil.Visible = true;
        this.Div_Erro.Visible = false;
        this.Divbemvindo.Visible = false;
        TextBoxNome.Text = c.Nome;
        TextBoxTelefone.Text = c.Telefone;
        TextBoxEmail.Text = c.Email;
        TextBoxSite.Text = c.Site;


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            c.Nome = TextBoxNome.Text;
            c.Telefone = TextBoxTelefone.Text;
            c.Email = TextBoxEmail.Text;
            c.Idcidade = int.Parse(DropDownCidade.SelectedValue);
            c.Site = TextBoxSite.Text;
            c.atualizar();
            Labelalerta.Text = "Perfil Atualizado!!";
            Alerta.Visible = true;
            Div_Perfil_da_Empreza.Visible = true;
            this.Divbemvindo.Visible = false;

        }
        catch (Exception p)
        {

            Label1.Text = p.Message;
            Div_Nova_Amostra.Visible = true;
            Div_Erro.Visible = true;
            this.Divbemvindo.Visible = false; 
        }
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            if (c.Cnpj != null && DropDownProdutor.SelectedValue.ToString() != "Nome" && int.Parse(DropDownList1.SelectedValue) != 0 && int.Parse(DropDownList2.SelectedValue) != 0 && TextBox9.Text != "")
            {
                AmostraCafe a = new AmostraCafe();
                a.inserir(c.Cnpj, DropDownProdutor.SelectedValue.ToString(), int.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue), double.Parse(TextBox9.Text));
                Labelalerta.Text = "Amostra enviada!!";
                Alerta.Visible = true;
                Div_Amostra_Analizada.Visible = true;
                Divbemvindo.Visible = false;
            }
            else
            {
                Label1.Text ="Dados Preenchidos incorretamente";
                Div_Nova_Amostra.Visible = true;
                Div_Erro.Visible = true;
                this.Divbemvindo.Visible = false;
            }
        }
        catch (Exception p)
        {
            Label1.Text = p.Message;
            Div_Nova_Amostra.Visible = true;
            Div_Erro.Visible = true;
            this.Divbemvindo.Visible = false;
        }
  
    }

    protected void GridViewNegociação_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int num = Convert.ToInt32(e.CommandArgument);
            labelstatus.Text = GridViewNegociação.Rows[num].Cells[1].Text.ToString();
            TextBoxINProd.Text+= GridViewNegociação.Rows[num].Cells[2].Text.ToString();
            TextBoxINTipo.Text+= GridViewNegociação.Rows[num].Cells[3].Text.ToString();
            TextBoxINBebida.Text+= GridViewNegociação.Rows[num].Cells[4].Text.ToString();
            TextBoxINQuantidade.Text+= GridViewNegociação.Rows[num].Cells[5].Text.ToString();
            TextBoxINValorTotal.Text+= GridViewNegociação.Rows[num].Cells[6].Text.ToString();
            //Response.Write("<script>alert('Negociação Fechada!');</script>");
            this.Div_FinalizarNeg.Visible = true;
            this.Divbemvindo.Visible = false;


        }
    }

    protected void GridViewNegociação_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells.Count > 1)
        {
            e.Row.Cells[1].Visible = false;
        }
    }





    protected void ButtonINNegociar_Click(object sender, EventArgs e)
    {
        try
        {
            Negociacao n = new Negociacao();
            n.atualizar(Convert.ToInt32(labelstatus.Text), "Fechado");
            Labelalerta.Text = "Negociação fechada";
            Alerta.Visible = true;
            this.Div_Historico_de_Negociação.Visible = true;
            TextBoxINProd.Text = "Produtor= ";
            TextBoxINBebida.Text = "Bebida=";
            TextBoxINQuantidade.Text = "Quantidade=";
            TextBoxINValorTotal.Text = "Valor Total = R$";
            TextBoxINTipo.Text = "Tipo=";
        }
        catch (Exception p)
        {

            Label1.Text = p.Message;
            Div_Nova_Amostra.Visible = true;
            Div_Erro.Visible = true;
            this.Divbemvindo.Visible = false;
        }
     

    }
}