using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SQLapp.Data
{
    public class Configuration
    {
        public SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        public Configuration()
        {
            ConfigureConnectionString();
        }
        public void ConfigureConnectionString()
        {
            builder.DataSource = "localhost"; // update me
            builder.UserID = "SA"; // update me
            builder.Password = "yourStrong(!)Password"; // update me
            builder.InitialCatalog = "NarkoKartelDB";
        }
    }
}