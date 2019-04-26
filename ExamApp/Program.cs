using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace ExamApp
{
    class Program
    {

        static void Main(string[] args)
        {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\МырзабекДи\source\repos\ExamApp\ExamApp.Database\Database.mdf;Integrated Security=True";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryStreetTableCreate =
                "CREATE TABLE [dbo].[Street](" +
                "[Id] INT NOT NULL PRIMARY KEY, " +
                "[Name] NVARCHAR(MAX) NOT NULL," +
                "[Location] NVARCHAR(MAX) NOT NULL)";

                string queryCityTableCreate =
               "CREATE TABLE [dbo].[City](" +
               "[Id] INT NOT NULL PRIMARY KEY, " +
               "[Name] NVARCHAR(MAX) NOT NULL," +
               "[Location] NVARCHAR(MAX) NOT NULL)," +
               "[StreetId] int FOREIGN KEY REFERENCES [Street](Id)";
                
                string queryCountryTableCreate =
              "CREATE TABLE [dbo].[Coutry](" +
              "[Id] INT NOT NULL PRIMARY KEY, " +
              "[Name] NVARCHAR(MAX) NOT NULL," +
              "[CityId] int FOREIGN KEY REFERENCES City(Id)";


                string queryStreetTableSelect = "Select * from [Street] where name=@name";
                string queryCityTableSelect = "Select * from [City] where name=@name";
                string queryCountryTableSelect = "Select * from [Country] where name=@name";


                string queryStreetTableUpdate = "UPDATE Street Name = @name," +
                    " Location = @location Where Id = @id";
                string queryCityTableUpdate = "UPDATE City Name = @name," +
                    " Location = @location Where Id = @id";
                string queryCountryTableUpdate = "UPDATE Country Name = @name," +
                    " Location = @location Where Id = @id";

                string items = "1.Улица/n2.Город/n3.Страна";
                DataAccess dataAccess = new DataAccess();
                

                bool isProgarmWorking = true;
                while (isProgarmWorking)
                {
                    Console.WriteLine("Что вы хотите сделать/n/n" +
                        "1.Создать" +
                        "2.Прочитать" +
                        "3.Обновить" +
                        "4.Удалить");
                    try
                    {
                        int answer = int.Parse(Console.ReadLine());
                        Console.Write("Что вы хотите ");
                        switch (answer)
                        {
                            case 1:
                                Console.Write("создать");
                                Console.WriteLine(items);
                                answer = int.Parse(Console.ReadLine());
                                switch (answer)
                                {
                                    case 1:
                                        SqlCommand createTableStreet = new SqlCommand(queryStreetTableCreate, connection);
                                        dataAccess.DoCommand(connectionString, createTableStreet);
                                        break;
                                    case 2:
                                        SqlCommand createTableCity = new SqlCommand(queryCityTableCreate, connection);
                                        dataAccess.DoCommand(connectionString, createTableCity);
                                        break;
                                    case 3:
                                        SqlCommand createTableCountry = new SqlCommand(queryCountryTableCreate, connection);
                                        dataAccess.DoCommand(connectionString, createTableCountry);
                                        break;
                                    default:
                                        Console.WriteLine("некоррекные данные");
                                        break;
                                }
                                break;
                            case 2:
                                Console.Write("прочитать");
                                Console.WriteLine(items);
                                answer = int.Parse(Console.ReadLine());
                                switch (answer)
                                {
                                    case 1:
                                        SqlCommand selectTableStreet = new SqlCommand(queryStreetTableSelect, connection);

                                        Console.WriteLine("Введите название: ");
                                        selectTableStreet.Parameters.AddWithValue("@name", Console.ReadLine());
                                        using (SqlDataReader reader = selectTableStreet.ExecuteReader())
                                        {
                                            if (reader.Read())
                                            {
                                                Console.WriteLine(reader.GetString(0));
                                            }
                                        }
                                        dataAccess.DoCommand(connectionString, selectTableStreet);

                                        break;
                                    case 2:
                                        SqlCommand selectTableCity = new SqlCommand(queryCityTableSelect, connection);
                                        dataAccess.DoCommand(connectionString, selectTableCity);

                                        Console.WriteLine("Введите название: ");
                                        selectTableCity.Parameters.AddWithValue("@name", Console.ReadLine());
                                        using (SqlDataReader reader = selectTableCity.ExecuteReader())
                                        {
                                            if (reader.Read())
                                            {
                                                Console.WriteLine(reader.GetString(0));
                                            }
                                        }
                                        break;
                                    case 3:
                                        SqlCommand selectTableCountry = new SqlCommand(queryCountryTableSelect, connection);
                                        dataAccess.DoCommand(connectionString, selectTableCountry);

                                        Console.WriteLine("Введите название: ");
                                        selectTableCountry.Parameters.AddWithValue("@name", Console.ReadLine());
                                        using (SqlDataReader reader = selectTableCountry.ExecuteReader())
                                        {
                                            if (reader.Read())
                                            {
                                                Console.WriteLine(reader.GetString(0));
                                            }
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("некоррекные данные");
                                        break;
                                }
                                break;
                            case 3:
                                Console.Write("обновить");
                                Console.WriteLine(items);

                                answer = int.Parse(Console.ReadLine());
                                switch (answer)
                                {
                                    case 1:
                                        SqlCommand updateTableStreet = new SqlCommand(queryStreetTableSelect, connection);
                                        dataAccess.DoCommand(connectionString, updateTableStreet);
                                        break;
                                    case 2:
                                        SqlCommand updateTableCity = new SqlCommand(queryCityTableSelect, connection);
                                        dataAccess.DoCommand(connectionString, updateTableCity);
                                        break;
                                    case 3:
                                        SqlCommand updateTableCountry = new SqlCommand(queryCountryTableSelect, connection);
                                        dataAccess.DoCommand(connectionString, updateTableCountry);
                                        break;
                                    default:
                                        Console.WriteLine("некоррекные данные");
                                        break;
                                }


                                break;
                            case 4:
                                Console.Write("удалить");
                                Console.WriteLine(items);
                                answer = int.Parse(Console.ReadLine());
                                Console.WriteLine("Введите название: ");
                                string name = Convert.ToString(Console.ReadLine());
                                string table;
                                switch (answer)
                                {
                                    case 1:
                                        table = "Street";
                                        break;
                                    case 2:
                                        table = "City";
                                        break;
                                    case 3:
                                        table = "Country";
                                        break;
                                    default:
                                        Console.WriteLine("некоррекные данные");
                                        table = "NoTable";
                                        break;
                                        //command.Parameters.AddWithValue("@zip", "india");
                                }
                                using (SqlCommand command = new SqlCommand("DELETE FROM " + table + " WHERE Name = " + name, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                                break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("некоррекные данные");
                        continue;
                    }
                    connection.Close();
                }
            }
        }
    }
}
