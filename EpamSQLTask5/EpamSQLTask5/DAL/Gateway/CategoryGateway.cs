using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace EpamSQLTask5 {
    public class CategoryGateway : IGateway<Category> {

        private static string con = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        private SqlConnection sqlConnection;

        public CategoryGateway() {
            sqlConnection = new SqlConnection(con);
        }

        public void addEntity(Category entity) {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO Category_Product (Category,Product_id) VALUES (@name,@prod_id)";
            command.Parameters.AddWithValue("@name", entity.CategoryName);
            command.Parameters.AddWithValue("@prod_id", entity.Product_id);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Category> getAll() {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Category_Product";
            SqlDataReader reader = command.ExecuteReader();
            List<Category> list = new List<Category>();
            while (reader.Read()) {
                Category p = new Category(Int32.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), Int32.Parse(reader.GetValue(2).ToString()));
                list.Add(p);
            }
            sqlConnection.Close();
            return list;
        }

        public Category getEntityById(int id) {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Category_Product WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Category p = null;
            while (reader.Read()) {
                p = new Category(Int32.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), Int32.Parse(reader.GetValue(2).ToString()));
            }
            sqlConnection.Close();
            return p;
        }

        public void removeEntity(int id) {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM Category_Product WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void updateEntity(Category entity) {
            sqlConnection.Open();
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "UPDATE Product SET Category = @name, Product_id = @prod_id WHERE Id = @id";
            command.Parameters.AddWithValue("@name", entity.CategoryName);
            command.Parameters.AddWithValue("@prod_id", entity.Product_id);
            command.Parameters.AddWithValue("@id", entity.Id);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
