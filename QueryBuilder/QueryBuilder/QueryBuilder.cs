using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using QueryBuilder.Models;

namespace QueryBuilder
{
    public class QueryBuilder : IDisposable
    {
        private SqliteConnection connection;
        public QueryBuilder(string databasePath)
        {
            connection = new SqliteConnection("Data Source=" + databasePath);
            connection.Open();
        }

        public T Read<T>(int id) where T : new()
        {
            var command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 0;
            command.CommandText = $"SELECT * FROM {typeof(T).Name} WHERE Id = {id}";
            using (var reader = command.ExecuteReader())
            {
                T data = new T();

                while(reader.Read())
                {
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        var propType = typeof(T).GetProperty(reader.GetName(i)).PropertyType;
                        var propName = typeof(T).GetProperty(reader.GetName(i));

                        if(propType == typeof(int))
                        {
                            propName.SetValue(data, Convert.ToInt32(reader.GetValue(i)));
                        }
                        else
                        {
                            propName.SetValue(data, reader.GetValue(i));
                        }
                    }
                }

                return data;
            }

        }

        public List<T> ReadAll<T>() where T : new()
        {
            var command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 0;
            command.CommandText = $"SELECT * FROM {typeof(T).Name}";
            using (var reader = command.ExecuteReader())
            {

                List<T> dataList = new List<T>();
                T data;

                while (reader.Read())
                {
                    data = new T();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var propType = typeof(T).GetProperty(reader.GetName(i)).PropertyType;
                        var propName = typeof(T).GetProperty(reader.GetName(i));

                        if (propType == typeof(int))
                        {
                            propName.SetValue(data, Convert.ToInt32(reader.GetValue(i)));
                        }
                        else
                        {
                            propName.SetValue(data, reader.GetValue(i));
                        }
                    }
                    dataList.Add(data);
                }

                return dataList;
            }

        }

        public void Create<T>(T obj)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            var values = new List<string>();
            var names = new List<string>();
            Console.WriteLine("Hello???");
            foreach(PropertyInfo property in properties)
            {
                values.Add("\"" + property.GetValue(obj).ToString() + "\"");
                names.Add(property.Name);
            }

            StringBuilder sbVals = new StringBuilder();
            StringBuilder sbNames = new StringBuilder();

            Console.WriteLine("Are we alive?");

            for(int i = 0; i < values.Count; i++)
            {
                if(i == values.Count - 1)
                {
                    sbVals.Append($"{values[i]}");
                    sbNames.Append($"{names[i]}");
                }
                else
                {
                    sbVals.Append($"{values[i]}, ");
                    sbNames.Append($"{names[i]}, ");
                }
            }

            Console.WriteLine("Wha");

            var command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 0;
            command.CommandText = $"INSERT INTO {typeof(T).Name} ({sbNames}) VALUES ({sbVals})";
            Console.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
            Console.WriteLine("????");

        }

        public void Update<T>(T obj) where T : IClassModel, new()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            var command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 0;
            command.CommandText = $"SELECT * FROM {typeof(T).Name} WHERE Id = {obj.Id}";
            using (var reader = command.ExecuteReader())
            {
                T data = new T();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var propType = typeof(T).GetProperty(reader.GetName(i)).PropertyType;
                        var propName = typeof(T).GetProperty(reader.GetName(i));

                        if (propType == typeof(int))
                        {
                            propName.SetValue(data, Convert.ToInt32(reader.GetValue(i)));
                        }
                        else
                        {
                            propName.SetValue(data, reader.GetValue(i));
                        }
                    }
                }

                foreach (PropertyInfo property in properties)
                {
                    if (property.GetValue(obj).ToString() != property.GetValue(data).ToString())
                    {
                        var command2 = connection.CreateCommand();
                        command2.CommandType = System.Data.CommandType.Text;
                        command2.CommandTimeout = 0;
                        command2.CommandText = $"SELECT * FROM {typeof(T).Name} WHERE Id = {obj.Id}";
                        command2.CommandText = $"UPDATE {typeof(T).Name} SET {property.Name} = \"{property.GetValue(obj).ToString()}\" WHERE Id = {obj.Id}";
                        command2.ExecuteNonQuery();
                    }
                }
            }

        }

        public void Delete<T>(T obj) where T : IClassModel
        {
            var command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 0;
            command.CommandText = $"DELETE FROM {typeof(T).Name} WHERE Id = {obj.Id}";
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
