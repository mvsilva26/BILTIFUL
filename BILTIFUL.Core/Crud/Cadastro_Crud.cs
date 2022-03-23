using BILTIFUL.Core.Entidades;
using BILTIFUL.Core.Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILTIFUL.Crud
{
    public class Cadastro_Crud
    {

            private static string datasource = @"DESKTOP-EA8QKM6";//instancia do servidor
            private static string database = "biltiful"; //Base de Dados
            private static string username = "sa"; //usuario da conexão
            private static string password = "147258"; //senha



       static string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;


        //SqlConnection connection = new SqlConnection(connString);


        public void InserirProduto(Produto produto)
        {

            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("Inserir_Produto", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    sql_cmnd.Parameters.AddWithValue("@Nome", produto.Nome);
                    sql_cmnd.Parameters.AddWithValue("@Valor_Venda", produto.ValorVenda);

                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public List<Produto> PegarProduto()
        {
            SqlConnection connection = new SqlConnection(connString);
            List<Produto> produto = new List<Produto>();

            connection.Open();

            String sql = "SELECT Cod_Barras, Nome, Valor_Venda, Ultima_Venda, Data_Cadastro, Situacao FROM Produto";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produto.Add(new Produto
                        {

                            CodigoBarras = reader["Cod_Barras"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            ValorVenda = reader["Valor_Venda"].ToString(),
                            UltimaVenda = DateTime.Parse(reader["Ultima_Venda"].ToString()),
                            DataCadastro = DateTime.Parse(reader["Data_Cadastro"].ToString()),
                            Situacao = (Situacao)char.Parse(reader["Situacao"].ToString())

                        });

                    }
                }

            }

                connection.Close();
                return produto;

           

        }

        public void InserirCliente(Cliente cliente)
        {

            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("Inserir_Cliente", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    sql_cmnd.Parameters.AddWithValue("@CPF", cliente.CPF);
                    sql_cmnd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    sql_cmnd.Parameters.AddWithValue("@Data_Nascimento", cliente.DataNascimento);
                    sql_cmnd.Parameters.AddWithValue("@Sexo", (char)cliente.Sexo);
                    sql_cmnd.Parameters.AddWithValue("@Situacao", (char)cliente.Situacao);

                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public List<Cliente> PegarCliente()
        {
            SqlConnection connection = new SqlConnection(connString);
            List<Cliente> cliente = new List<Cliente>();

            connection.Open();

            String sql = "SELECT CPF, Nome, Data_Nascimento, Sexo, Ultima_Compra, Data_Cadastro, Situacao FROM Cliente";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente.Add(new Cliente
                        {

                            CPF = reader["CPF"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            DataNascimento = DateTime.Parse(reader["Data_Nascimento"].ToString()),
                            Sexo = (Sexo)char.Parse(reader["Sexo"].ToString()),
                            UltimaCompra = DateTime.Parse(reader["Ultima_Compra"].ToString()),
                            DataCadastro = DateTime.Parse(reader["Data_Cadastro"].ToString()),
                            Situacao = (Situacao)char.Parse(reader["Situacao"].ToString())

                        });

                    }
                }

            }
                connection.Close();
                return cliente;



        }

        public void InserirFornecedor(Fornecedor fornecedor)
        {

            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("Inserir_fornecedor", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    sql_cmnd.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
                    sql_cmnd.Parameters.AddWithValue("@Razao_Social", fornecedor.RazaoSocial);
                    sql_cmnd.Parameters.AddWithValue("@Data_Abertura", fornecedor.DataAbertura);
                    

                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public List<Fornecedor> PegarFornecedor()
        {
            SqlConnection connection = new SqlConnection(connString);
            List<Fornecedor> fornecedor = new List<Fornecedor>();
           
                connection.Open();

                String sql = "SELECT CNPJ, Razao_Social, Data_Abertura, Ultima_Compra, Data_Dadastro, Situacao FROM fornecedor";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fornecedor.Add(new Fornecedor
                            {

                                CNPJ = reader["CNPJ"].ToString(),
                                RazaoSocial = reader["Razao_Social"].ToString(),
                                DataAbertura = DateTime.Parse(reader["Data_Abertura"].ToString()),
                                UltimaCompra = DateTime.Parse(reader["Ultima_Compra"].ToString()),
                                DataCadastro = DateTime.Parse(reader["Data_Dadastro"].ToString()),
                                Situacao = (Situacao)char.Parse(reader["Situacao"].ToString())

                            });
                                
                        }
                    }

                }
                    connection.Close();
                    return fornecedor;

                    

        }


        public void InserirMPrima(MPrima mPrima)
        {
            SqlConnection connection = new SqlConnection(connString);
            mPrima.Id = "MP" + (Count() + 1).ToString().PadLeft(4, '0');
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERIR_MPrima", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    sql_cmnd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = mPrima.Id;
                    sql_cmnd.Parameters.AddWithValue("@Nome", SqlDbType.NVarChar).Value = mPrima.Nome;

                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
                  
        }

        public List<MPrima> PegarMPrima()
        {
            SqlConnection connection = new SqlConnection(connString);
            List<MPrima> mPrima = new List<MPrima>();

            connection.Open();

            String sql = "SELECT Id, Nome, Ultima_Compra, Data_Dadastro, Situacao FROM MPrima";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mPrima.Add(new MPrima
                        {

                            Id = reader["Id"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            UltimaCompra = DateTime.Parse(reader["Ultima_Compra"].ToString()),
                            DataCadastro = DateTime.Parse(reader["Data_Dadastro"].ToString()),
                            Situacao = (Situacao)char.Parse(reader["Situacao"].ToString())

                        });

                    }
                }

            }
                connection.Close();
                return mPrima;



        }





        public int Count()
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();

            int GReader = 0;
            string query = "select count(*) from MPrima";
            var reader = new SqlCommand(query, connection).ExecuteReader();
            reader.Read();
            GReader =  reader.GetInt32(0);

            connection.Close();

            return GReader;
        }


        public void InserirItemCompra(ItemCompra itemcompra)
        {

            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("Inserir_ItemCompra", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    sql_cmnd.Parameters.AddWithValue("@Quantidade", itemcompra.Quantidade);
                    sql_cmnd.Parameters.AddWithValue("@Valor_Unitario", itemcompra.ValorUnitario);
                    sql_cmnd.Parameters.AddWithValue("@Total_Item", itemcompra.TotalItem);


                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void InserirCompra(Compra compra)
        {

            try
            {
                SqlConnection connection = new SqlConnection(connString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("Inserir_Compra", connection);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    sql_cmnd.Parameters.AddWithValue("@Valor_Total", compra.ValorTotal);
                    sql_cmnd.Parameters.AddWithValue("@@CNPJ_fornecedor", compra.Fornecedor);


                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }



        public bool isBloqueadoCliente(string cpf)
        {
            SqlConnection connection = new SqlConnection(connString);
            bool existe;

            connection.Open();

            String sql = "SELECT CPF_Cliente FROM dbo.Risco WHERE CPF_Cliente ='" + cpf + "'";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    existe = reader.Read();
                   
                }

            }
            connection.Close();
            return existe;


        }

        public void BloquearCliente(string cpf)
        {
            SqlConnection connection = new SqlConnection(connString);
            using (connection)
            {
                    //SqlConnection connection = new SqlConnection(connString);
                    connection.Open();
                    SqlCommand sql_cmnd = new SqlCommand("INSERT INTO Risco(CPF_Cliente) VALUES(@cpf)", connection);

           
                    sql_cmnd.Parameters.AddWithValue("@cpf", cpf);


                    sql_cmnd.ExecuteNonQuery();
                    connection.Close();
            }
            
          
        }

        public void RemoverClienteInadimplente(string cpf)
        {
            SqlConnection connection = new SqlConnection(connString);
            using (connection)
            {
                connection.Open();
                SqlCommand sql_cmnd = new SqlCommand("DELETE from Risco WHERE CPF_Cliente = @cpf", connection);


                sql_cmnd.Parameters.AddWithValue("@cpf", cpf);


                sql_cmnd.ExecuteNonQuery();
                connection.Close();
            }


        }


        public bool isBloqueadoFornecedor(string cnpj)
        {
            SqlConnection connection = new SqlConnection(connString);
            bool existe;

            connection.Open();

            String sql = "SELECT CNPJ_Fornecedor FROM Bloqueado WHERE CNPJ_Fornecedor ='" + cnpj + "'";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    existe = reader.Read();

                }

            }
            connection.Close();
            return existe;


        }

        public void BloquearFornecedor(string cnpj)
        {
            SqlConnection connection = new SqlConnection(connString);
            using (connection)
            {
                connection.Open();
                SqlCommand sql_cmnd = new SqlCommand("INSERT INTO Bloqueado(CNPJ_Fornecedor) VALUES(@cnpj)", connection);


                sql_cmnd.Parameters.AddWithValue("@cnpj", cnpj);


                sql_cmnd.ExecuteNonQuery();
                connection.Close();
            }


        }

        public void RemoverFornecedorBloqueado(string cnpj)
        {

            SqlConnection connection = new SqlConnection(connString);
            using (connection)
            {
                connection.Open();
                SqlCommand sql_cmnd = new SqlCommand("DELETE from Bloqueado WHERE CNPJ_Fornecedor = @cnpj", connection);


                sql_cmnd.Parameters.AddWithValue("@cnpj", cnpj);


                sql_cmnd.ExecuteNonQuery();
                connection.Close();
            }


        }










        public bool RemoverProduto(long codigoBarras)
        {
            SqlConnection connection = new SqlConnection(connString);
            string query = $"UPDATE Produto SET Situacao='{(char)Situacao.Inativo}' WHERE CodigoBarras = @codigoBarras";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@codigoBarras", codigoBarras);
            return command.ExecuteNonQuery() == 1 ? true : false;
        }

        public bool RemoverFornecedor(long CNPJ)
        {
            SqlConnection connection = new SqlConnection(connString);
            string query = $"UPDATE Fornecedor SET Situacao='{(char)Situacao.Inativo}' WHERE CNPJ = @CNPJ";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CNPJ", CNPJ);
            return command.ExecuteNonQuery() == 1 ? true : false;
        }

        public bool RemoverCliente(long CPF)
        {
            SqlConnection connection = new SqlConnection(connString);
            string query = $"UPDATE Cliente SET Situacao='{(char)Situacao.Inativo}' WHERE CPF = @CPF";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CPF", CPF);
            return command.ExecuteNonQuery() == 1 ? true : false;
        }

        public bool RemoverMPrima(string Id)
        {
            SqlConnection connection = new SqlConnection(connString);
            string query = $"UPDATE MPrima SET Situacao='{(char)Situacao.Inativo}' WHERE Id = @Id";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            return command.ExecuteNonQuery() == 1 ? true : false;
        }




    }
}
