using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


    public class Produtor
    {
        private string cpf;
        private int idcidade;
        private string nome;
        private string telefone;
    
        private string senha;
        private string email;

        public Produtor(string cpf, int idcidade, string nome, string telefone, string senha, string email)
        {
            this.cpf = cpf;
            this.idcidade = idcidade;
            this.nome = nome;
            this.telefone = telefone;
          
            this.email = email;
            this.senha = senha;
        }
    public Produtor()
    {
       
    }

    public string Cpf
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
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

        //funções do banco
        public void inserir()
        {
            Conexao c = new Conexao();
            string sql = "INSERT INTO Produtor VALUES('" + this.Cpf + "'," + this.Idcidade + ",'" + this.Nome + "','" + this.Telefone + "','" + this.Email + "','" + this.Senha + "')";
            SqlConnection conn = c.Conectar();
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.ExecuteNonQuery();
            c.Desconectar();


        }
        public void atualizar()
        {
            Conexao c = new Conexao();
            string sql = "UPDATE Produtor SET Nome='" + this.Nome + "', Email='" + this.Email + "',Telefone='" + this.Telefone + "',Senha='" + this.Senha + "',IdCidade=" + this.Idcidade + " WHERE Cpf='" + this.Cpf+"'";
            SqlConnection conn = c.Conectar();
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.ExecuteNonQuery();
            c.Desconectar();
        }
        public void delete()//nao vai precisar
        {
            Conexao c = new Conexao();
            string sql = "DELETE FROM Produtor WHERE Cpf='" + this.Cpf+"'";
            SqlConnection conn = c.Conectar();
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.ExecuteNonQuery();
            c.Desconectar();
        }

    public DataSet PesquisaProdutor()
    {
        Conexao c = new Conexao();
        string sql = "SELECT * FROM Produtor";
        SqlDataAdapter d = new SqlDataAdapter();
        d.SelectCommand = new SqlCommand(sql, c.Conectar());
        DataSet ds = new DataSet();
        d.Fill(ds, "Bebida");
        return ds;
    }
    public bool verificaprodutor(string email, string senha)
    {
        Conexao c = new Conexao();
        bool verifica = false;
        string sql = "SELECT Cpf FROM Produtor WHERE Email='" + email + "' AND Senha='" + senha + "'";
        SqlConnection conn = c.Conectar();
        SqlCommand comando = new SqlCommand(sql, conn);
        SqlDataReader reader = comando.ExecuteReader();
        if (reader.HasRows)
        {
            verifica = true;


        }
        if (reader.Read())
        {
            this.Cpf = reader.GetString(0).ToString();
        }
        return verifica;



    }
    public void alocaprodutor(string cpf)
    {
        Conexao c = new Conexao();
        bool verifica = false;
        string sql = "SELECT * FROM Produtor WHERE Cpf='" + cpf +"'";
        SqlConnection conn = c.Conectar();
        SqlCommand comando = new SqlCommand(sql, conn);
        SqlDataReader reader = comando.ExecuteReader();
        if (reader.HasRows)
        {
            verifica = true;


        }
        if (reader.Read())
        {
            this.Cpf = reader.GetString(0).ToString();
            this.Idcidade = Convert.ToInt32(reader.GetInt32(1));
            this.Nome = reader.GetString(2).ToString();
            this.Telefone = reader.GetString(3).ToString();
            this.Email = reader.GetString(4).ToString();
            this.Senha = reader.GetString(5).ToString();
        }
    



    }



}