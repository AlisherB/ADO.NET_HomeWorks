﻿using AdoBankingSystem.DAL.Interfaces;
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
    public class CurrentSessionDao : IDAO<CurrentSessionDto>, IExtendedCurrentSession
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PrimaryConnectionString"].ToString();
        private CurrentSessionDto currentSessionDTOToReturn;

        public string Create(CurrentSessionDto record)
        {
            record.Id = Guid.NewGuid().ToString();
            using (SqlConnection sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                string baseQuery = "INSERT INTO [dbo].[CurrentSessions] " +
                    "([Id], [UserId], [SignInTime], [LastOperationTime], [CreatedTime], [EntityStatus])" +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5})";

                string realQuery = String.Format
                    (baseQuery, record.Id, record.UserId, record.SignInTime,
                    record.LastOperationTime, record.CreatedTime, (int)record.EntityStatus);

                sqlConnection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(realQuery, connectionString))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "CurrentSessions");

                    DataRow dataRowToAdd = dataSet.Tables["CurrentSessions"].NewRow();

                    foreach (var item in record.GetType().GetProperties())
                    {
                        dataRowToAdd[item.Name] = item.GetValue(record, null);
                    }

                    dataSet.Tables["CurrentSessions"].Rows.Add(dataRowToAdd);

                    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

                    adapter.Update(dataSet.Tables["CurrentSessions"]);
                }
                sqlConnection.Close();
                return record.Id;
            }
        }

        public string GetCurrentSessionIdByUserId(string userId)
        {
            string idToReturn = null;
            using (SqlConnection sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                string baseQuery = "SELECT * FROM dbo.CurrentSessions WHERE UserId = '{0}'";
                string realQuery = String.Format(baseQuery, userId);
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = realQuery;
                    sqlCommand.CommandType = CommandType.Text;

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        idToReturn = reader["Id"].ToString();
                    }             
                    sqlConnection.Close();
                }
            }
            return idToReturn;
        }
        public CurrentSessionDto Read(string id)
        {
            using (SqlConnection sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    string baseSelectQuery = @"SELECT * FROM [AdoBankingSystem].[dbo].[CurrentSessions] WHERE [Id = {0}]";
                    string realSelectQuery = String.Format(baseSelectQuery, id.ToString());

                    sqlCommand.CommandText = realSelectQuery;
                    sqlCommand.CommandType = CommandType.Text;

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        currentSessionDTOToReturn = new CurrentSessionDto()
                        {
                            Id = reader["Id"].ToString(),
                            UserId = reader["UserId"].ToString(),
                            SignInTime = DateTime.Parse(reader["SignInTime"].ToString()),
                            LastOperationTime = DateTime.Parse(reader["LastOperationTime"].ToString()),
                            CreatedTime = DateTime.Parse(reader["CreatedTime"].ToString()),
                            EntityStatus = (EntityStatusType)Int32.Parse(reader["EntityStatus"].ToString())
                        };
                    }
                }
                sqlConnection.Close();
            }
            return currentSessionDTOToReturn;
        }

        public ICollection<CurrentSessionDto> Read()
        {
            ICollection<CurrentSessionDto> sessions = new List<CurrentSessionDto>();
            using (SqlConnection sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                string realQuery = "SELECT * FROM dbo.CurrentSessions";              

                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = realQuery;

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        sessions.Add(new CurrentSessionDto()
                        {
                            Id = reader["Id"].ToString(),
                            UserId = reader["UserId"].ToString(),
                            SignInTime = DateTime.Parse(reader["SignInTime"].ToString()),
                            LastOperationTime = DateTime.Parse(reader["LastOperationTime"].ToString()),
                            CreatedTime = DateTime.Parse(reader["CreatedTime"].ToString()),
                            EntityStatus = (EntityStatusType)Int32.Parse(reader["EntityStatus"].ToString())
                        });
                    }
                }
                sqlConnection.Close();
            }
            return sessions;
        }

        public void Remove(string id)
        {
            using (SqlConnection sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                string baseQuery = "DELETE FROM dbo.CurrentSessions WHERE Id='{0}'";
                string realQuery = String.Format(baseQuery, id);

                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = realQuery;

                    sqlCommand.ExecuteNonQuery();     
                }
                sqlConnection.Close();
            }
        }

        public string Update(CurrentSessionDto record)
        {
            using (SqlConnection sqlConnection = DatabaseConnectionFactory.GetConnection())
            {
                string baseQuery = "UPDATE [AdoBankingSystem].[dbo].[CurrentSessions] SET Id = '{0}', UserId = '{1}', SignInTIme = '{2}', LastOperationTime = {3}, CreatedTime = {4}, EntityStatus = {5}";
                string realQuery = String.Format(baseQuery, record.Id, record.UserId, record.SignInTime, record.LastOperationTime, record.CreatedTime, record.EntityStatus);

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
