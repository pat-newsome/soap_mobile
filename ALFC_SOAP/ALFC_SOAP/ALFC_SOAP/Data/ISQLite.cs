using SQLite.Net;
using System;


namespace ALFC_SOAP
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
