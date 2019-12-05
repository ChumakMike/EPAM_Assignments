using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EpamSQLTask5 {
    public class ProviderGateway : IGateway<Provider> {

        private static string con = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        private SqlConnection sqlConnection;

        public ProviderGateway() {
            sqlConnection =  new SqlConnection(con);
        }

        public void addEntity(Provider entity) {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO Provider (Name,Adress) VALUES (@name,@adr)";
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@adr", entity.Adress);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Provider> getAll() {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Provider";
            SqlDataReader reader = command.ExecuteReader();
            List<Provider> list = new List<Provider>();
            while (reader.Read()) {
                Provider p = new Provider(Int32.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), reader.GetValue(2).ToString());
                list.Add(p);
            }
            sqlConnection.Close();
            return list;
        }

        public Provider getEntityById(int id) {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Provider WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Provider p = null;
            while (reader.Read()) {
                p = new Provider(Int32.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), reader.GetValue(2).ToString());
            }
            sqlConnection.Close();
            return p;
        }

        public void removeEntity(int id) {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM Provider WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void updateEntity(Provider entity) {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "UPDATE Provider SET Name = @name, Adress = @adr WHERE Id = @id";
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@adr", entity.Adress);
            command.Parameters.AddWithValue("@id", entity.Id);
            command.ExecuteNonQuery();
        }
    }
}
