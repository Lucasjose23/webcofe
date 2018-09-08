using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


    public class AmostraCafe
    {
        private int id;
        private string cnpjcoop;
        private string cpfpro;
        private int idtipo;
        private int idbebida;
        private double valorporsaca;

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

        public int Idtipo
        {
            get
            {
                return idtipo;
            }

            set
            {
                idtipo = value;
            }
        }

        public int Idbebida
        {
            get
            {
                return idbebida;
            }

            set
            {
                idbebida = value;
            }
        }


        public double Valorporsaca
        {
            get
            {
                return valorporsaca;
            }

            set
            {
                valorporsaca = value;
            }
        }

        public void inserir(string cnpj, string cpf, int idtipo, int idbebida, double valorporsaca)
        {
            Conexao c = new Conexao();
            string sql = "INSERT INTO Amostra VALUES('" + cnpj + "','" + cpf+ "'," + idtipo + "," + idbebida + "," + valorporsaca + ")";
            SqlConnection conn = c.Conectar();
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.ExecuteNonQuery();
            c.Desconectar();

        }
 
        public void delete()//nao vai precisar
        {
            Conexao c = new Conexao();
            string sql = "DELETE FROM Amostra WHERE Id=" + this.Id;
            SqlConnection conn = c.Conectar();
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.ExecuteNonQuery();
            c.Desconectar();
        }

        //pesquisa amostras relacionada a um cliente
        //public DataSet PesquisaAmostraProd(Produtor p)
        //{
        //    Conexao c = new Conexao();
        //    string sql = "SELECT * FROM Amostra WHERE CpfPro='" + this.Cpfpro + "'"; 
        //    SqlDataAdapter d = new SqlDataAdapter();
        //    d.SelectCommand = new SqlCommand(sql, c.Conectar());
        //    DataSet ds = new DataSet();
        //    d.Fill(ds, "Amostra");
        //    return ds;

        //}

        //pesquisa amostras relacionada a uma cooperativa
        //public DataSet PesquisaAmostraCoo()
        //{
        //    Conexao c = new Conexao();
        //    string sql = "SELECT CpfPro, IdTipo, IdBebida, ValorPorSaca FROM Amostra WHERE CnpjCoop='" + this.Cnpjcoop + "'";
        //    SqlDataAdapter d = new SqlDataAdapter();
        //    d.SelectCommand = new SqlCommand(sql, c.Conectar());
        //    DataSet ds = new DataSet();
        //    d.Fill(ds, "Amostra");
        //    return ds;

        //}
     public DataSet PesquisaamostraProdutor(string cpf)//inner join para amostra do lado do produtor
    {
    
        Conexao c = new Conexao();
      
        string sql = "SELECT Cooperativa.Cnpj, Cooperativa.Nome, Tipo.TNome, Bebida.BNome, Amostra.ValorPorSaca,Amostra.Id FROM Amostra INNER JOIN Cooperativa ON Amostra.CnpjCoop = Cooperativa.Cnpj INNER JOIN Tipo ON Amostra.IdTipo = Tipo.Id INNER JOIN Bebida ON Amostra.IdBebida = Bebida.Id WHERE Amostra.CpfPro='" + cpf + "'";
        SqlDataAdapter d = new SqlDataAdapter();
        d.SelectCommand = new SqlCommand(sql, c.Conectar());
        DataSet ds = new DataSet();
        d.Fill(ds, "Amostra");
        return ds;

    }
    public DataSet PesquisaamostraCooperativa(string cnpj)//inner join para amostra do lado da cooperativa
    {

        Conexao c = new Conexao();

        string sql = "SELECT Produtor.Nome, Tipo.TNome, Bebida.BNome, Amostra.ValorPorSaca FROM Amostra INNER JOIN Produtor ON Amostra.CpfPro = Produtor.Cpf INNER JOIN Tipo ON Amostra.IdTipo = Tipo.Id INNER JOIN Bebida ON Amostra.IdBebida = Bebida.Id WHERE Amostra.CnpjCoop='" + cnpj + "'";
        SqlDataAdapter d = new SqlDataAdapter();
        d.SelectCommand = new SqlCommand(sql, c.Conectar());
        DataSet ds = new DataSet();
        d.Fill(ds, "Amostra");
        return ds;

    }

}
