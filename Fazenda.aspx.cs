using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Fazenda : System.Web.UI.Page
{
    Produtor p = new Produtor();
    public string cnpj = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string cpf;
        try
        {
            cpf = Request.QueryString["CPF"].ToString();
            this.Div_Busca_Cooperativa.Visible = false;
            this.Div_Amostra_Solicitada.Visible = false;
            this.Div_Perfil_do_Produtor.Visible = false;
            this.Div_Historico_de_Negociação.Visible = false;
            this.Div_Editar_Perfil.Visible = false;
            this.Div_Iniciar_Negociação.Visible = false;
            this.Alerta.Visible = false;
            this.Div_Error.Visible = false;
            p.alocaprodutor(cpf);
            LabelBemvindo.Text = "Bem vindo (a) " + p.Nome;
        }
        catch(Exception error)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Coop c = new Coop();
        GridViewBuscaCooperativa.DataSource = c.PesquisaCooperativa();
        GridViewBuscaCooperativa.DataBind();
        
        this.Div_Busca_Cooperativa.Visible = true;
        this.Div_Amostra_Solicitada.Visible = false;
        this.Div_Perfil_do_Produtor.Visible = false;
        this.Div_Historico_de_Negociação.Visible = false;
        this.Div_Editar_Perfil.Visible = false;
        this.Divbemvindo.Visible = false;
        this.Div_Iniciar_Negociação.Visible = false;
        this.Div_Error.Visible = false;
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        AmostraCafe a = new AmostraCafe();
        GridViewAmostrax.DataSource = a.PesquisaamostraProdutor(p.Cpf);
        GridViewAmostrax.DataBind();
        

        this.Div_Busca_Cooperativa.Visible = false;
        this.Div_Amostra_Solicitada.Visible = true;
        this.Div_Perfil_do_Produtor.Visible = false;
        this.Div_Historico_de_Negociação.Visible = false;
        this.Divbemvindo.Visible = false;
        this.Div_Iniciar_Negociação.Visible = false;
        this.Div_Error.Visible = false;
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        this.Div_Busca_Cooperativa.Visible = false;
        this.Div_Amostra_Solicitada.Visible = false;
        this.Div_Perfil_do_Produtor.Visible = true;
        this.Div_Historico_de_Negociação.Visible = false;
        this.Div_Editar_Perfil.Visible = false;
        this.Divbemvindo.Visible = false;
        this.Div_Iniciar_Negociação.Visible = false;
        this.Div_Error.Visible = false;
        LabelNome.Text = p.Nome;
        LabelTelefone.Text = p.Telefone;
        Labelemail.Text = p.Email;
        Cidade c = new Cidade();
        LabelCidade.Text = c.nomecidade(p.Idcidade);
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Negociacao n = new Negociacao();
        GridViewNegociação.DataSource = n.PesquisanegProdutor(p.Cpf);
        GridViewNegociação.DataBind();
        this.Div_Busca_Cooperativa.Visible = false;
        this.Div_Amostra_Solicitada.Visible = false;
        this.Div_Perfil_do_Produtor.Visible = false;
        this.Div_Historico_de_Negociação.Visible = true;
        this.Div_Editar_Perfil.Visible = false;
        this.Divbemvindo.Visible = false;
        this.Div_Iniciar_Negociação.Visible = false;
        this.Div_Error.Visible = false;
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        this.Div_Busca_Cooperativa.Visible = false;
        this.Div_Amostra_Solicitada.Visible = false;
        this.Div_Perfil_do_Produtor.Visible = false;
        this.Div_Historico_de_Negociação.Visible = false;
        this.Div_Editar_Perfil.Visible = true;
        this.Divbemvindo.Visible = false;
        this.Div_Iniciar_Negociação.Visible = false;
        this.Div_Error.Visible = false;

        TextBoxnome.Text =LabelNome.Text;
        TextBoxTelefone.Text = p.Telefone;
        TextBoxEmail.Text = p.Email;

    }
   
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            p.Nome = TextBoxnome.Text;
            p.Telefone = TextBoxTelefone.Text;
            p.Email = TextBoxEmail.Text;
            p.Idcidade = int.Parse(DropDownCidade.SelectedValue);
            p.atualizar();
            Labelalerta.Text = "Perfil Atualizado!!";
            Alerta.Visible = true;
            Div_Perfil_do_Produtor.Visible = true;

        }
        catch (Exception x)
        {

            Label1.Text = x.Message;
            this.Div_Iniciar_Negociação.Visible = true;
            this.Div_Error.Visible = true;
        }
      
    }

    protected void GridViewAmostrax_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int num = Convert.ToInt32(e.CommandArgument);
             BoxCoo.Text= GridViewAmostrax.Rows[num].Cells[2].Text.ToString();
            TextBoxINCoop .Text = GridViewAmostrax.Rows[num].Cells[3].Text;
            TextBoxINTipo.Text = GridViewAmostrax.Rows[num].Cells[4].Text;
            TextBoxINBebida.Text = GridViewAmostrax.Rows[num].Cells[5].Text;
            TextBoxINValorSaca.Text = GridViewAmostrax.Rows[num].Cells[6].Text;
            this.Div_Iniciar_Negociação.Visible = true;
        }
        
    }

    protected void ButtonINNegociar_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBoxINQuantidade.Text != "" && p.Cpf != null && BoxCoo.Text != null && TextBoxINTipo.Text != null && TextBoxINBebida.Text != null && TextBoxINValorSaca.Text != null)
            {
                Negociacao N = new Negociacao();
                double ValorTotal = double.Parse(TextBoxINQuantidade.Text) * double.Parse(TextBoxINValorSaca.Text);
                N.inserir(double.Parse(TextBoxINQuantidade.Text), ValorTotal, "Negociando", p.Cpf, BoxCoo.Text, TextBoxINTipo.Text, TextBoxINBebida.Text);
                Labelalerta.Text = "Negociação Aberta";
                Alerta.Visible = true;

                this.Div_Busca_Cooperativa.Visible = false;
                this.Div_Amostra_Solicitada.Visible = false;
                this.Div_Perfil_do_Produtor.Visible = false;
                this.Div_Historico_de_Negociação.Visible = true;
                this.Div_Editar_Perfil.Visible = false;
                this.Divbemvindo.Visible = false;
                this.Div_Iniciar_Negociação.Visible = false;
                this.Div_Error.Visible = false;
                TextBoxINQuantidade.Text = "";
            }
            else
            {
                this.Div_Iniciar_Negociação.Visible = true;
                this.Div_Error.Visible = true;
            }
        }
        catch (Exception p)
        {
            Label1.Text = p.Message;
            this.Div_Iniciar_Negociação.Visible = true;
            this.Div_Error.Visible = true;
        }
       
    }


    protected void GridViewAmostrax_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridViewAmostrax_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells.Count > 1)
        {
            e.Row.Cells[7].Visible = false;
        }
    }

    protected void GridViewAmostrax_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
            int num = Convert.ToInt32(e.RowIndex);
            AmostraCafe a = new AmostraCafe();
            a.Id = Convert.ToInt32(GridViewAmostrax.Rows[num].Cells[7].Text);
            a.delete();
            Labelalerta.Text = "Amostra Deletada";
            Alerta.Visible = true;
            Div_Amostra_Solicitada.Visible = true;

        
    }

    protected void GridViewNegociação_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int num = Convert.ToInt32(e.RowIndex);
        Negociacao n = new Negociacao();
        n.Id = Convert.ToInt32(GridViewNegociação.Rows[num].Cells[7].Text);
        n.delete();
        Labelalerta.Text = "Negociação Deletada";
        Alerta.Visible = true;
        Div_Historico_de_Negociação.Visible = true;
    }



    protected void GridViewBuscaCooperativa_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Text = "Cidade";
        }
    }
}