using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;



    public class Cidade
    {
        private int id;
        private Estado estado;
        private string nome;

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

        public Estado Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
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
        //pesquisa todos os cidades
        public DataSet PesquisaCidade()//voce pode retornar essa consulta para o dropdown
        {

            Conexao c = new Conexao();
            string sql = "SELECT * FROM Cidade";
            SqlDataAdapter d = new SqlDataAdapter();
            d.SelectCommand = new SqlCommand(sql, c.Conectar());
            DataSet ds = new DataSet();
            d.Fill(ds, "Cidade");
            return ds;

        }
      public string nomecidade(int id)//voce pode retornar essa consulta para o dropdown
      {
        string nome="";
        Conexao c = new Conexao();
        string sql = "SELECT Nome FROM Cidade WHERE Id="+id;
        SqlConnection conn = c.Conectar();
        SqlCommand comando = new SqlCommand(sql, conn);
        SqlDataReader reader = comando.ExecuteReader();

        if (reader.Read())
        {
            nome = reader.GetString(0).ToString();
            
        }
        return nome;


    }

}