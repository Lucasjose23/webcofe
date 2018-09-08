using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Conexão
/// </summary>
public class Conexao
{
    //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lucas\Desktop\BancodeDados1\App_Data\integradora6.mdf;Integrated Security = True";
    //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lucas\Desktop\INTEGRADORA\BancodeDados1\App_Data\integradora6.mdf;Integrated Security = True";
    //string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\INTEGRADORA\BancodeDados1\App_Data\Banco.mdf;Integrated Security = True";
    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lucas\Desktop\INTEGRADORA\INTEGRADORA\BancodeDados1\App_Data\integradora6.mdf;Integrated Security = True";
    SqlConnection conexao = new SqlConnection();
	public Conexao()
	{
		
	}

    public SqlConnection Conectar()
    {
        conexao.ConnectionString = connectionString;
        conexao.Open();
        return conexao;
    }

    public void Desconectar()
    {
        conexao.Close();
    }

}