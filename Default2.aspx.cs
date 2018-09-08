using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Default2 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        this.DivCadCoop.Visible = false;
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
        this.DivCadCoop.Visible = true;
        this.DivLoginCoop.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.DivCadCoop.Visible = false;
        this.DivLoginCoop.Visible = true;
        Coop c = new Coop();
        try
        {
            if (c.verificaCoope(TextBox1.Text, TextBox2.Text)||((TextBox1.Text==" ") && (TextBox2.Text==" ")))
            {


                string cnpj = c.Cnpj;
                Response.Redirect("Cooperativa.aspx?CNPJ=" + cnpj);
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
        try
        {
            if (TextBoxCNPJ.Text != "" && int.Parse(DropDownCIDADE.SelectedValue) != 0 && TextBoxNOME.Text != "" && TextBoxTELEFONE.Text != "" && TextBoxDESCRI.Text != "" && TextBoxEMAIL.Text != "" && TextBoxSENHA.Text != "" && TextBoxSITE.Text != "")
            {
                Coop c = new Coop(TextBoxCNPJ.Text, int.Parse(DropDownCIDADE.SelectedValue), TextBoxNOME.Text, TextBoxTELEFONE.Text, TextBoxDESCRI.Text, TextBoxEMAIL.Text, TextBoxSENHA.Text, TextBoxSITE.Text);
                c.inserir();
                string cnpj = c.Cnpj;
                this.DivCadCoop.Visible = false;
                this.DivLoginCoop.Visible = true;
                Labelalerta.Text = "Cadastrado com Sucesso!!";
                Alerta.Visible = true;
            }
            else
            {
                Label1.Text = "Algum campo não foi preenchido corretamente!";
                Div_Error.Visible = true;
                this.DivCadCoop.Visible = true;
                this.DivLoginCoop.Visible = false;
                TextBoxCNPJ.Text = "";
                TextBoxNOME.Text = "";
                TextBoxTELEFONE.Text = "";
                TextBoxDESCRI.Text = "";
                TextBoxEMAIL.Text = "";
                TextBoxSENHA.Text = "";
                TextBoxSITE.Text = "";
            }

        }
        catch (Exception p)
        {

            Label1.Text = p.Message;
            Div_Error.Visible = true;
            this.DivCadCoop.Visible = true;
            this.DivLoginCoop.Visible = false;
            TextBoxCNPJ.Text = "";
            TextBoxNOME.Text = "";
            TextBoxTELEFONE.Text = "";
            TextBoxDESCRI.Text = "";
            TextBoxEMAIL.Text = "";
            TextBoxSENHA.Text = "";
            TextBoxSITE.Text = "";
        }
      
        // Response.Redirect("Cooperativa.aspx?CNPJ=" + cnpj);
    }
}