using System;
using System.Text;
using System.Data.SqlClient;
using SQLapp.Controller;
using SQLapp.Data;

namespace SQLapp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestConnectingSQL.TryToConnect();
            NarkoKartelController c = new NarkoKartelController();
            c.Start();  
        }
    }
}