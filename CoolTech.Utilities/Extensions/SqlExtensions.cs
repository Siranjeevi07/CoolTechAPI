using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace CoolTech.Utilities
{
    public static class SqlExtensions
    {
        public static SqlParameter CreateSQLParameter(this string ParameterName, string value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.NVarChar, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter(this string ParameterName, byte[] value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.Binary, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter(this string ParameterName, decimal? value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.Decimal, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter(this string ParameterName, decimal value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.Decimal, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter(this string ParameterName, TimeSpan value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.Time, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter(this string ParameterName, double value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.Decimal, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter(this string ParameterName, DateTimeOffset value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.DateTimeOffset, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter(this string ParameterName, DateTimeOffset? value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.DateTimeOffset, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter(this string ParameterName, int value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.Int, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter(this string ParameterName, int? value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.Int, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter(this string ParameterName, bool value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.Bit, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter(this string ParameterName, bool? value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.Bit, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter(this string ParameterName, long value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.BigInt, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter(this string ParameterName, long? value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            return ParameterName.CreateSQLParameter(value, SqlDbType.BigInt, parameterDirection);
        }

        public static SqlParameter CreateSQLParameter<T>(this string ParameterName, T value, SqlDbType dbType, ParameterDirection parameterDirection)
        {
            if (value != null)
                return new SqlParameter { ParameterName = ParameterName, Value = value, SqlDbType = dbType, Direction = parameterDirection };
            else
                return new SqlParameter { ParameterName = ParameterName, Value = DBNull.Value, SqlDbType = dbType, Direction = parameterDirection };
        }

        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(System.DayOfWeek))
                {
                    DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                    property.SetValue(item, day, null);
                }
                else
                {
                    if (row[property.Name] == DBNull.Value)
                        property.SetValue(item, null, null);
                    else
                    {
                        if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                        {
                            //nullable
                            object convertedValue = null;
                            try
                            {
                                convertedValue = System.Convert.ChangeType(row[property.Name], Nullable.GetUnderlyingType(property.PropertyType));
                            }
                            catch (Exception ex)
                            {
                            }
                            property.SetValue(item, convertedValue, null);
                        }
                        else
                            property.SetValue(item, row[property.Name], null);
                    }
                }
            }
            return item;
        }


    }
}
