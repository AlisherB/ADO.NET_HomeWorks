using AdoBankingSystem.DAL.Interfaces;
using AdoBankingSystem.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoBankingSystem.DAL.DAOs
{
    public class BankManagerDao : IDAO<BankManagerDto>
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PrimaryConnectionString"].ToString();
        string sql = @"SELECT * FROM BankManagers";
        private BankManagerDto bankManagerDTOToReturn;

        public string Create(BankManagerDto record)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionString))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "BankManagers");

                    DataRow dataRowToAdd = dataSet.Tables["BankManagers"].NewRow();

                    foreach (var item in record.GetType().GetProperties())
                    {
                        dataRowToAdd[item.Name] = item.GetValue(record, null);
                    }

                    dataSet.Tables["BankManagers"].Rows.Add(dataRowToAdd);

                    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

                    adapter.Update(dataSet.Tables["BankManagers"]);
                }
                sqlConnection.Close();
                return record.Id;
            }
        }

        public BankManagerDto Read(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionString))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "BankManagerDto");
                    dataSet.Tables["BankManagerDto"].PrimaryKey = new DataColumn[] { dataSet.Tables["BankManagerDto"].Columns["Id"] };

                    DataRow dataRowToReturn = dataSet.Tables["BankManagerDto"].Rows.Find(id);

                    foreach (var item in dataRowToReturn.ItemArray.ToList())
                    {
                        Console.WriteLine(item);
                    }
                }
                sqlConnection.Close();
            }
            return null;
        }

        public ICollection<BankManagerDto> Read()
        {
            ICollection<BankManagerDto> users = new List<BankManagerDto>();
            using (SqlConnection sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                string realQuery = "SELECT * FROM BankManagers";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = realQuery;

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        users.Add(new BankManagerDto()
                        {
                            Id = reader["Id"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            PasswordHash = reader["PasswordHash"].ToString(),
                            CreatedTime = DateTime.Parse(reader["CreatedTime"].ToString()),
                            EntityStatus = (EntityStatusType)Int32.Parse(reader["EntityStatus"].ToString())
                        });
                    }
                }
                sqlConnection.Close();
            }
            return users;
        }

        public void Remove(string id)
        {
            using (SqlConnection sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                string baseQuery = "DELETE FROM [AdoBankingSystem].[dbo].[BankManagers] WHERE Id = '{0}'";
                string realQuery = String.Format(baseQuery, id);

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(realQuery, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        public string Update(BankManagerDto record)
        {
            using (SqlConnection sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                string baseQuery = "UPDATE [AdoBankingSystem].[dbo].[BankManagers] SET Id = '{0}', Email = '{1}', FirstName = '{2}', LastName = {3}, PasswordHash = {4}, CreatedTime = {5}, EntityStatus = {6}";
                string realQuery = String.Format(baseQuery, record.Id, record.Email, record.FirstName, record.LastName, record.PasswordHash, record.CreatedTime, record.EntityStatus);

                sqlConnection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(realQuery, connectionString))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    DataColumn[] key = new DataColumn[1];
                    key[0] = dataSet.Tables[0].Columns[0];
                    dataSet.Tables[0].PrimaryKey = key;

                    DataRow dataRow = dataSet.Tables[0].Rows.Find(record.Id);

                    dataRow.BeginEdit();

                    dataRow["Id"] = record.Id;

                    dataRow.EndEdit();
                    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

                    adapter.Update(dataSet);
                }
                return record.ToString();
            }
        }
    }
}
