using System.Data.SqlClient;

namespace WcfServicesToujoursDebout
{
    public interface IEntite<T> where T:new()
    {
        T Remplire(SqlDataReader data);
    }
}