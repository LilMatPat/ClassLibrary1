﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Mapper
    {
        public void Assert (bool condition, string message)
        {
            if (!condition)
            {
                throw new Exception(message);
            }
        }
        public string GetStringOrDefault(SqlDataReader reader, int ordinal, string defaultValue = "")
        {
            if( reader.IsDBNull(ordinal))
            {
                return defaultValue;
            }
            else
            {
                return reader.GetString(ordinal);
            }
        }
        public int
            GetInt32OrDefault(SqlDataReader reader, int Ordinal, int defaultValue = 0)
        {
            if (reader.IsDBNull(Ordinal))
            {
                return defaultValue;
            }
            else
            {
                return reader.GetInt32(Ordinal);
            }
        }
    }
}
