using Microsoft.Data.SqlClient;
using System.Data;

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

    }
}
