using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace ColabManager360.Infrastructure.Data.Extensions.Context
{
    internal static class DBContextExtension
    {
        public static List<T> ExecuteSqlQuery<T>(this DbContext dbContext, string querySQL, params object[] args) where T : new()
        {
            List<T> list = new List<T>();
            var connection = dbContext.Database.GetDbConnection();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = string.Format(querySQL, args);

                bool isOpen = connection.State == ConnectionState.Open;
                if (!isOpen) connection.Open();

                //dbContext.Database.OpenConnection();

                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                T item = new T();
                                Type type = item.GetType();
                                PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                                properties.ToList().ForEach(property =>
                                {
                                    try
                                    {
                                        if (reader.IsDBNull(reader.GetOrdinal(property.Name)))
                                        {
                                            property.SetValue(item, null, null);
                                        }
                                        else
                                        {
                                            var value = reader[property.Name];
                                            property.SetValue(item, value, null);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                });
                                list.Add(item);
                            }
                        }
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public static void ExecuteSqlNonQuery(this DbContext dbContext, string querySQL, params object[] args)
        {
            var connection = dbContext.Database.GetDbConnection();
            try
            {
                using (var command = connection.CreateCommand())
                {
                    bool isOpen = connection.State == ConnectionState.Open;
                    if (!isOpen) connection.Open();

                    command.CommandText = string.Format(querySQL, args);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
