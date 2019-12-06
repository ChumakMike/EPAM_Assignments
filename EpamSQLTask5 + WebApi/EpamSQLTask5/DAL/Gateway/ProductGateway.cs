using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace EpamSQLTask5 {
    public class ProductGateway : IGateway<Product> {

        private static string con = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        private SqlConnection sqlConnection;

        public ProductGateway() {
            sqlConnection = new SqlConnection(con);
        }
        
        public void addEntity(Product entity) {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO Product (Name,Provider_id) VALUES (@name,@prov_id)";
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@prov_id", entity.Provider_id);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Product> getAll() {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Product";
            SqlDataReader reader = command.ExecuteReader();
            List<Product> list = new List<Product>();
            while (reader.Read()) {
                Product p = new Product(Int32.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), Int32.Parse(reader.GetValue(2).ToString()));
                list.Add(p);
            }
            sqlConnection.Close();
            return list;
        }
            
        public Product getEntityById(int id) {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Product WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Product p = null;
            while (reader.Read()) {
                p = new Product(Int32.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), Int32.Parse(reader.GetValue(2).ToString()));
            }
            sqlConnection.Close();
            return p;
        }

        public void removeEntity(int id) {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM Product WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void updateEntity(Product entity) {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "UPDATE Product SET Name = @name, Provider_id = @prov_id WHERE Id = @id";
            command.Parameters.AddWithValue("@name", entity.Name);
            command.Parameters.AddWithValue("@prov_id", entity.Provider_id);
            command.Parameters.AddWithValue("@id", entity.Id);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
