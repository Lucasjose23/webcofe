using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


    public class Negociacao
    {
        private int id;
        
        private double quantidade;
        private double valor;
        private string status;
        private string cpfpro;
        private string cnpjcoop;
        private string nometipo;
        private string nomebebida; 
      

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

       
        public double Quantidade
        {
            get
            {
                return quantidade;
            }

            set
            {
                quantidade = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public double Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }

        public string Cpfpro
        {
            get
            {
                return cpfpro;
            }

            set
            {
                cpfpro = value;
            }
        }

        public string Cnpjcoop
        {
            get
            {
                return cnpjcoop;
            }

            set
            {
                cnpjcoop = value;
            }
        }

    public string Nometipo
    {
        get
        {
            return nometipo;
        }

        set
        {
            nometipo = value;
        }
    }

    public string Nomebebida
    {
        get
        {
            return nomebebida;
        }

        set
        {
            nomebebida = value;
        }
    }

    public void inserir(double quantidade, double valor,string status, string cpfpro, string cnpjcoop, string nometipo,string nomebebida)
        {
            Conexao c = new Conexao();
            string sql = "INSERT INTO Negociacao VALUES(" + quantidade + "," + valor + ",'"+status+ "','" + cpfpro + "','" + cnpjcoop + "','" + nometipo + "','" + nomebebida + "')";
            SqlConnection conn = c.Conectar();
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.ExecuteNonQuery();
            c.Desconectar();


        }
        public void atualizar(int Id, string status)
        {
            Conexao c = new Conexao();
            string sql = "UPDATE Negociacao SET Status='"+status+"' WHERE Id=" +Id;
            SqlConnection conn = c.Conectar();
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.ExecuteNonQuery();
            c.Desconectar();
        }
    public void delete()//nao vai precisar
    {
        Conexao c = new Conexao();
        string sql = "DELETE FROM Negociacao WHERE Id=" + this.Id;
        SqlConnection conn = c.Conectar();
        SqlCommand comando = new SqlCommand(sql, conn);
        comando.ExecuteNonQuery();
        c.Desconectar();
    }


    ////pesquisa neg dos produtor
    // public DataSet PesquisaNegProd()
    // {

    //     Conexao c = new Conexao();
    //     string sql = "SELECT * FROM Negociacao WHERE CpfProd='"+this.Cpfpro + "'";
    //     SqlDataAdapter d = new SqlDataAdapter();
    //     d.SelectCommand = new SqlCommand(sql, c.Conectar());
    //     DataSet ds = new DataSet();
    //     d.Fill(ds, "Negociacao");
    //     return ds;

    // }
    // //pesquisa neg dos cooperativa
    // public DataSet PesquisaNegCoop()
    // {

    //     Conexao c = new Conexao();
    //     string sql = "SELECT * FROM Negociacao WHERE CnpjCoop='" + this.Cnpjcoop+"'";
    //     SqlDataAdapter d = new SqlDataAdapter();
    //     d.SelectCommand = new SqlCommand(sql, c.Conectar());
    //     DataSet ds = new DataSet();
    //     d.Fill(ds, "Negociacao");
    //     return ds;

    // }

    public DataSet PesquisanegProdutor(string cpf)//inner join para neg do lado do produtor
    {

        Conexao c = new Conexao();

        string sql = "SELECT Cooperativa.Nome, Negociacao.NomeTipo, Negociacao.NomeBebida,Negociacao.Quantidade,Negociacao.ValorTotal, Negociacao.Status, Negociacao.Id FROM Negociacao INNER JOIN Cooperativa ON Negociacao.CnpjCoop = Cooperativa.Cnpj  WHERE Negociacao.CpfProd='" + cpf + "'";
        SqlDataAdapter d = new SqlDataAdapter();
        d.SelectCommand = new SqlCommand(sql, c.Conectar());
        DataSet ds = new DataSet();
        d.Fill(ds, "Negociacao");
        return ds;

    }
    public DataSet PesquisanegCooperativa(string cnpj)//inner join para neg do lado da cooperativa
    {

        Conexao c = new Conexao();

        string sql = "SELECT  Negociacao.Id,Produtor.Nome, Negociacao.NomeTipo, Negociacao.NomeBebida,Negociacao.Quantidade,Negociacao.ValorTotal, Negociacao.Status FROM Negociacao INNER JOIN Produtor ON Negociacao.CpfProd = Produtor.Cpf  WHERE Negociacao.CnpjCoop='" + cnpj + "' AND Negociacao.Status='Negociando'";
        SqlDataAdapter d = new SqlDataAdapter();
        d.SelectCommand = new SqlCommand(sql, c.Conectar());
        DataSet ds = new DataSet();
        d.Fill(ds, "Amostra");
        return ds;

    }





}