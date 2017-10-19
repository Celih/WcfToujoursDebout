using System.Collections.Generic;
using System.Data.SqlClient;

namespace WcfServicesToujoursDebout
{
    public interface IEntite<T> where T:new()
    {
        List<T> Remplire(SqlDataReader data);
    }
}