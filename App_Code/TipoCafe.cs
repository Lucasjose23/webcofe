using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


    public class TipoCafe
    {
        private int id;
        private string nome;
        private string descri;

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
        //pesquisa todos os tipos
        public DataSet PesquisaTipo()//voce pode retornar essa consulta para o dropdown
        {

            Conexao c = new Conexao();
            string sql = "SELECT * FROM Tipo";
            SqlDataAdapter d = new SqlDataAdapter();
            d.SelectCommand = new SqlCommand(sql, c.Conectar());
            DataSet ds = new DataSet();
            d.Fill(ds, "Tipo");
            return ds;

        }

  
}