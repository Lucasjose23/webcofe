using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.DivCadFazen.Visible = false;
        this.Alerta.Visible = false;
        this.Div_Error.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Cidade C = new Cidade();
        DropDownCIDADE.DataSource = C.PesquisaCidade();
        DropDownCIDADE.DataTextField = "Nome";
        DropDownCIDADE.DataValueField = "Id";
        DropDownCIDADE.DataBind();
        DropDownCIDADE.Items.Insert(0, new ListItem("Cidade", "0"));
        Estado E = new Estado();
        DropDownESTADO.DataSource = E.PesquisaEstado();
        DropDownESTADO.DataTextField = "Nome";
        DropDownESTADO.DataValueField = "Id";
        DropDownESTADO.DataBind();
        DropDownESTADO.Items.Insert(0, new ListItem("Estado", "0"));
        this.DivCadFazen.Visible = true;
        this.DivLoginFazen.Visible = false;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cpf;
        this.DivCadFazen.Visible = false;
        this.DivLoginFazen.Visible = true;
        try
        {
            Produtor p = new Produtor();
            if (p.verificaprodutor(TextBox1.Text, TextBox2.Text) || ((TextBox1.Text == " ") && (TextBox2.Text == " ")))
            {
                cpf = p.Cpf;
                Response.Redirect("Fazenda.aspx?CPF=" + cpf);
            }
            else
            {
                Label1.Text = "Email ou senha incorreto!";
                Div_Error.Visible = true;
                TextBox1.Text = "";
                TextBox2.Text = "";

            }

          

        }
        catch (Exception p)
        {

            Label1.Text = p.Message;
            Div_Error.Visible = true;
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
  
    
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string cpf;
        try
        {
            if (TextBoxCPF.Text != "" && int.Parse(DropDownCIDADE.SelectedValue) != 0 && TextBoxNOME.Text != "" && TextBoxTELEFONE.Text != "" && TextBoxSENHA.Text != "" && TextBoxEMAIL.Text != "")
            {
                Produtor p = new Produtor(TextBoxCPF.Text, int.Parse(DropDownCIDADE.SelectedValue), TextBoxNOME.Text, TextBoxTELEFONE.Text, TextBoxSENHA.Text, TextBoxEMAIL.Text);
                p.inserir();
                cpf = TextBoxCPF.Text;
                this.DivCadFazen.Visible = false;
                this.DivLoginFazen.Visible = true;
                Labelalerta.Text = "Cadastrado com Sucesso!!";
                Alerta.Visible = true;
            }
            else
            {
                Label1.Text = "Algum campo não foi preenchido corretamente!";
                Div_Error.Visible = true;
                this.DivCadFazen.Visible = true;
                this.DivLoginFazen.Visible = false;
                TextBoxCPF.Text = "";
                TextBoxNOME.Text = "";
                TextBoxTELEFONE.Text = "";
                TextBoxSENHA.Text = "";
                TextBoxEMAIL.Text = "";

            }
        }
        catch (Exception p)
        {

            Label1.Text = p.Message;
            Div_Error.Visible = true;
            this.DivCadFazen.Visible = true;
            this.DivLoginFazen.Visible = false;
            TextBoxCPF.Text = "";
            TextBoxNOME.Text = "";
            TextBoxTELEFONE.Text = "";
            TextBoxSENHA.Text = "";
            TextBoxEMAIL.Text = "";
        }
    
        //Response.Redirect("Fazenda.aspx?CPF=" + cpf);
    }
}