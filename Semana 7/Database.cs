using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Semana_7
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();

    }
}
