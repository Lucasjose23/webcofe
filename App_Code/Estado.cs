using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


    public class Estado
    {
        private int id;
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
        //pesquisa todos os estados
        public DataSet PesquisaEstado()//voce pode retornar essa consulta para o dropdown
        {

            Conexao c = new Conexao();
            string sql = "SELECT * FROM Estado";
            SqlDataAdapter d = new SqlDataAdapter();
            d.SelectCommand = new SqlCommand(sql, c.Conectar());
            DataSet ds = new DataSet();
            d.Fill(ds, "Estado");
            return ds;

        }
   
}