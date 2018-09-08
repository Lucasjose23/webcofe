using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Coop
/// </summary>
public class Coop
{
    public Coop()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private string cnpj;
    private int idcidade;
    private string nome;
    private string telefone;
    private string descri;

    private string email;
    private string senha;
    private string site;

    public Coop(string cnpj, int idcidade, string nome, string telefone, string descri, string email, string senha, string site)
    {
        this.cnpj = cnpj;
        this.idcidade = idcidade;
        this.nome = nome;
        this.telefone = telefone;
        this.descri = descri;
        this.email = email;
        this.senha = senha;
        this.site = site;
    }

    public string Cnpj
    {
        get
        {
            return cnpj;
        }

        set
        {
            cnpj = value;
        }
    }

    public int Idcidade
    {
        get
        {
            return idcidade;
        }

        set
        {
            idcidade = value;
        }
    }

    public string Nome
    {
        get
        {
            return nome;
        }

        set
        {
            nome = value;
        }
    }

    public string Telefone
    {
        get
        {
            return telefone;
        }

        set
        {
            telefone = value;
        }
    }

    public string Descri
    {
        get
        {
            return descri;
        }

        set
        {
            descri = value;
        }
    }

    public string Senha
    {
        get
        {
            return senha;
        }

        set
        {
            senha = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    public string Site
    {
        get
        {
            return site;
        }

        set
        {
            site = value;
        }
    }


    //funções do banco
    public void inserir()
    {
        Conexao c = new Conexao();
        string sql = "INSERT INTO Cooperativa VALUES('" + this.Cnpj + "'," + this.Idcidade + ",'" + this.Nome + "','" + this.Telefone + "','" + this.Descri + "','" + this.Email + "','" + this.Senha + "','" + this.Site + "')";
        SqlConnection conn = c.Conectar();
        SqlCommand comando = new SqlCommand(sql, conn);
        comando.ExecuteNonQuery();
        c.Desconectar();


    }
    public void atualizar()
    {
        Conexao c = new Conexao();
        string sql = "UPDATE Cooperativa SET Nome='" + this.Nome + "', Email='" + this.Email + "',Telefone='" + this.Telefone + "',Senha='" + this.Senha + "',IdCidade=" + this.Idcidade + ",Site='" + this.Site + "' ,Descri='" + this.Descri + "' WHERE Cnpj='" + this.Cnpj + "'";
        SqlConnection conn = c.Conectar();
        SqlCommand comando = new SqlCommand(sql, conn);
        comando.ExecuteNonQuery();
        c.Desconectar();
    }
    public void delete()//nao vai precisar
    {
        Conexao c = new Conexao();
        string sql = "DELETE FROM Cooperativa WHERE Cpf='" + this.Cnpj + "'";
        SqlConnection conn = c.Conectar();
        SqlCommand comando = new SqlCommand(sql, conn);
        comando.ExecuteNonQuery();
        c.Desconectar();
    }

    public DataSet PesquisaCooperativa()
    {
        Conexao c = new Conexao();
        string sql = "SELECT Cooperativa.Nome, Cidade.Nome, Telefone, Email FROM Cooperativa INNER JOIN Cidade ON Cidade.Id=Cooperativa.IdCidade";
        SqlDataAdapter d = new SqlDataAdapter();
        d.SelectCommand = new SqlCommand(sql, c.Conectar());
        DataSet ds = new DataSet();
        d.Fill(ds, "Bebida");
        return ds;
    }
    public bool verificaCoope(string email, string senha)
    {
        Conexao c = new Conexao();
        bool verifica = false;
        string sql = "SELECT Cnpj FROM Cooperativa WHERE Email='" + email + "' AND Senha='" + senha + "'";
        SqlConnection conn = c.Conectar();
        SqlCommand comando = new SqlCommand(sql, conn);
        SqlDataReader reader = comando.ExecuteReader();
        if (reader.HasRows)
        {
            verifica = true;


        }
        if (reader.Read())
        {
            this.Cnpj = reader.GetString(0).ToString();
        }
        return verifica;



    }
    public void alocacooperativa(string cnpj)
    {
        Conexao c = new Conexao();
        bool verifica = false;
        string sql = "SELECT * FROM Cooperativa WHERE Cnpj='" + cnpj + "'";
        SqlConnection conn = c.Conectar();
        SqlCommand comando = new SqlCommand(sql, conn);
        SqlDataReader reader = comando.ExecuteReader();
        if (reader.HasRows)
        {
            verifica = true;


        }
        if (reader.Read())
        {
            this.Cnpj = reader.GetString(0).ToString();
            this.Idcidade = Convert.ToInt32(reader.GetInt32(1));
            this.Nome = reader.GetString(2).ToString();
            this.Telefone = reader.GetString(3).ToString();
            this.Descri = reader.GetString(4).ToString();
            this.Email = reader.GetString(5).ToString();
            this.Senha = reader.GetString(6).ToString();
            this.Site = reader.GetString(7).ToString();
        }
    }
}
