using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace AdoSamples.ConsoleUI;
public class SqlSamples
{
    private SqlConnection connection;
    public SqlSamples()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.InitialCatalog = "OnlineShopDb";
        builder.DataSource = ".";
        builder.Password = "1qaz!QAZ";
        builder.UserID = "sa";
        builder.Encrypt = false;
        builder.CommandTimeout = 100;
        builder.CommandTimeout = 200;

        connection = new(builder.ConnectionString);
    }
    public void FirstSample()
    {
        string connectionString = "Server=.; Initial catalog=OnlineShopDb;User Id=sa; Password=1qaz!QAZ;Encrypt=False";

        SqlConnection connection = new(connectionString);

        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.Text;
        command.CommandText = "Select * from Categories";
        connection.Open();
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader["Id"]}\t\t Name:{reader["CategoryName"]}");
        }
        connection.Close();
    }

    public void WorkingWithConnection()
    {
        string connectionString = "Server=.; Initial catalog=OnlineShopDb;User Id=sa; Password=1qaz!QAZ;Encrypt=False";

        SqlConnection connection = new(connectionString);

        Console.WriteLine(connection.Database);
        Console.WriteLine(connection.DataSource);
        Console.WriteLine(connection.CommandTimeout);
        Console.WriteLine(connection.ConnectionTimeout);

        connection.Close();
    }
    public void ConnectionBuilder()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.InitialCatalog = "OnlineShopDb";
        builder.DataSource = ".";
        builder.Password = "1qaz!QAZ";
        builder.UserID = "sa";
        builder.Encrypt = false;
        builder.CommandTimeout = 100;
        builder.CommandTimeout = 200;

        SqlConnection connection = new(builder.ConnectionString);

        Console.WriteLine(connection.Database);
        Console.WriteLine(connection.DataSource);
        Console.WriteLine(connection.CommandTimeout);
        Console.WriteLine(connection.ConnectionTimeout);
        Console.WriteLine(connection.State);

        connection.Close();
    }

    public void TestCommand()
    {
        SqlCommand command = new SqlCommand
        {
            Connection = connection,
            CommandType = CommandType.Text,
            CommandText = "Select * from Categories"
        };
        connection.Open();
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader["Id"]}\t\t Name:{reader["CategoryName"]}");
        }
        connection.Close();
    }

    public void TestReader()
    {
        SqlCommand command = new SqlCommand
        {
            Connection = connection,
            CommandType = CommandType.Text,
            CommandText = "Select * from Categories"
        };
        connection.Open();
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write(reader.GetName(i));
                Console.Write(":");
                Console.Write(reader.GetValue(i));
                Console.Write("\t");
            }
            Console.WriteLine();
        }
        connection.Close();
    }

    public void TestReaderMultiple()
    {
        SqlCommand command = new SqlCommand
        {
            Connection = connection,
            CommandType = CommandType.StoredProcedure,
            CommandText = "MultipeResult"
        };
        connection.Open();
        var reader = command.ExecuteReader();
        do
        {


            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i));
                    Console.Write(":");
                    Console.Write(reader.GetValue(i));
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("".PadLeft(100, '_'));
        } while (reader.NextResult());

        connection.Close();

    }

    public void AddProduct(int categoryId, string productName, string description, int price)
    {
        SqlCommand command = new SqlCommand
        {
            Connection = connection,
            CommandType = CommandType.Text,
            CommandText = $"insert into products(CategoryId,ProductName,Description,Price) values ({categoryId},'{productName}','{description}',{price})"
        };
        connection.Open();
        int result = command.ExecuteNonQuery();
        Console.WriteLine($"Affected row {result}");
    }

    public void AddProductParameter(int categoryId, string productName, string description, int price)
    {
        SqlParameter categoryIdParam = new SqlParameter
        {
            ParameterName = "@CategoryId",
            DbType = DbType.Int32,
            Direction = ParameterDirection.Input,
            Value = categoryId
        };
        SqlParameter productNameParam = new SqlParameter
        {
            ParameterName = "@productName",
            DbType = DbType.String,
            Direction = ParameterDirection.Input,
            Value = productName
        };
        SqlParameter descriptionParam = new SqlParameter
        {
            ParameterName = "@description",
            DbType = DbType.String,
            Direction = ParameterDirection.Input,
            Value = description
        };
        SqlParameter priceParam = new SqlParameter
        {
            ParameterName = "@price",
            DbType = DbType.Int32,
            Direction = ParameterDirection.Input,
            Value = price
        };

        SqlCommand command = new SqlCommand
        {
            Connection = connection,
            CommandType = CommandType.Text,
            CommandText = $"insert into products(CategoryId,ProductName,Description,Price) values (@CategoryId,@productName,@description,@price)"
        };

        command.Parameters.Add(categoryIdParam);
        command.Parameters.Add(productNameParam);
        command.Parameters.Add(descriptionParam);
        command.Parameters.Add(priceParam);
        connection.Open();
        int result = command.ExecuteNonQuery();
        Console.WriteLine($"Affected row {result}");
    }

    public void AddTransactional(string categoryName, int categoryId, string productName, string description, int price)
    {
        SqlTransaction transaction = null;
        SqlCommand AddProduct = new SqlCommand
        {
            Connection = connection,
            CommandType = CommandType.Text,
            CommandText = $"insert into products(CategoryId,ProductName,Description,Price) values ({categoryId},'{productName}','{description}',{price})"
        };
        SqlCommand AddCategory = new SqlCommand
        {
            Connection = connection,
            CommandType = CommandType.Text,
            CommandText = $"insert into Categories(CategoryName) values ('{categoryName}')"
        };


        connection.Open();
        try
        {
            transaction = connection.BeginTransaction();
            int result = AddProduct.ExecuteNonQuery();
            result += AddCategory.ExecuteNonQuery();
            transaction.Commit();
            Console.WriteLine($"Affected row {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            transaction.Rollback();
        }

         

    }

    public void SimpleBulkInsert()
    {
        SqlCommand command = new SqlCommand
        {
            CommandType = CommandType.Text,
            Connection = connection,
        };
        connection.Open();
        Stopwatch stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < 1000; i++)
        {
            command.CommandText = $"Insert into BulkTable(Name,[Desc]) values ('Name {i}','Desc {i}')";
            command.ExecuteNonQuery();
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
    }


    public void SqlBulkCopySample()
    {
        
        SqlBulkCopy sqlBulk  = new SqlBulkCopy(connection);
        sqlBulk.DestinationTableName = "BulkTable";

        connection.Open();

        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Name"));
        dt.Columns.Add(new DataColumn("Desc"));
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < 1000; i++)
        {
            dt.Rows.Add(new object[] { $"Name {i}", $"Desc {i}" });
        }
        sqlBulk.WriteToServer(dt);
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
    }
}
