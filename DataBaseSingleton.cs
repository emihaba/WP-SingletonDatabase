using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Project
{
    class DataBaseSingleton
    {
        static DataBaseSingleton instance;
        SQLiteConnection m_dbConnection;

        private DataBaseSingleton()
        {
            if (!File.Exists("Database.sqlite"))
            {
                SQLiteConnection.CreateFile("Database.sqlite");
            }
            m_dbConnection = new SQLiteConnection("Data Source=Database.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE IF NOT EXISTS Products (id_product INT PRIMARY KEY, price DOUBLE, created_at DATETIME, updated_at DATETIME, modified_by INT, updated_by INT)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "CREATE TABLE IF NOT EXISTS People (id_person INT PRIMARY KEY, name VARCHAR(50), age INT, created_at DATETIME, updated_at DATETIME, modified_by INT, updated_by INT, product_id INT)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

        }

        public static DataBaseSingleton getInstance()
        {
            if (instance == null)
            {
                instance = new DataBaseSingleton();
            }
            return instance;    
        }

        public Person getPerson(int idPerson)
        {
            string sql = "SELECT * FROM people WHERE id_person=" + idPerson;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader read = command.ExecuteReader();

            if(read.Read())
            {
                Person person = new Person();
                person.setIdPerson(read.GetInt32(0));
                person.setName(read.GetString(1));
                person.setAge(read.GetInt32(2));
                person.setCreationDate(DateTime.Parse(read.GetString(3)));
                person.setUpdateDate(DateTime.Parse(read.GetString(4)));
                person.setIdProduct(read.GetInt32(7));

                return person;
            }
            else
            {
                throw new Exception("A person with given ID could not be found");
            }
        }

        public Product getProduct(int idProduct)
        {
            string sql = "SELECT * FROM products WHERE id_product=" + idProduct;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader read = command.ExecuteReader();

            if (read.Read())
            {
                Product product = new Product();
                product.setIdProduct(read.GetInt32(0));
                product.setPrice(read.GetDouble(1));
                product.setCreationDate(read.GetDateTime(3));
                product.setUpdateDate(read.GetDateTime(4));               

                return product;
            }
            else
            {
                throw new Exception("A product with given ID could not be found");
            }
        }

        public DataBaseSingleton PersonToDatebase(Person person)
        {
            string sql;
            try
            {
                getPerson(person.getIdPerson());
                sql = "UPDATE Products SET name = '" + person.getName() + "', age = " + person.getAge() + ",  updated_at = " + DateTime.Now + ", product_id = " + person.getProductId() + " WHERE id_person =" + person.getIdPerson();
            }
            catch (Exception)
            {
                sql = "INSERT INTO People (id_person, name, age, created_at, updated_at, product_id) VALUES (" + person.getIdPerson() + ",'" + person.getName() + "'," + person.getAge() + ",'" + DateTimeSQLite(DateTime.Now) + "','" + DateTimeSQLite(DateTime.Now) + "'," + person.getProductId()+")";
            }

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            return this;

        }

        public DataBaseSingleton ProductToDatebase(Product product)
        {
            string sql;
            try
            {
                getProduct(product.getIdProduct());
                sql = "UPDATE Products SET price = '" + product.getPrice() +  ",  updated_at = '" + DateTimeSQLite(DateTime.Now) + " WHERE id_product =" + product.getIdProduct();
            }
            catch (Exception)
            {
                sql = "INSERT INTO Products (id_product, price, created_at) VALUES (" + product.getIdProduct() + "," + product.getPrice() + ",'" + DateTimeSQLite(DateTime.Now) + "')";
            }

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            return this;

        }

        private string DateTimeSQLite(DateTime datetime)
        {
            string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
            return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
        }

    }
}
