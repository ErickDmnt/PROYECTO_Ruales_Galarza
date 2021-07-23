using System;
using System.Data.SqlClient;

namespace PROYECTO_Ruales_Galarza
{
    internal class Sqlcommand
    {
        private string v;
        private SqlConnection con;
        public Sqlcommand(string v, SqlConnection con)
        {
            this.v = v;
            this.con = con;
        }

        internal void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }
    }
}