using System;
using System.Collections.Generic;

namespace SQLapp.Presentation
{
    public static class CommandReader
    {
        public static string Input
        {
            get => input;
            set => input = value;
        }

        private static string input;

        public static void TakeInput()
        {
            Console.WriteLine("Waiting for command...  /type 'HELP' to see all commands./");
            input = Console.ReadLine();
        }

        public static Dictionary<string,string> NewDrug()
        {
            Dictionary<string,string> dict = new Dictionary<string, string>();
            
            Console.Write("  -Name: ");
            var name = Console.ReadLine().Trim();
            dict.Add("name",name);
            Console.Write("  -Sell price: ");
            var sell = Console.ReadLine().Trim();
            dict.Add("sell",sell);
            Console.Write("  -Acquire price: ");
            var acquire = Console.ReadLine().Trim();
            dict.Add("acquire",acquire);

            return dict;
        }
        
        public static Dictionary<string,string> HireDealer()
        {
            Dictionary<string,string> dict = new Dictionary<string, string>();
            
            Console.Write("  -First name: ");
            var firstName = Console.ReadLine().Trim();
            dict.Add("firstName",firstName);
            Console.Write("  -Last name: ");
            var lastName = Console.ReadLine().Trim();
            dict.Add("lastName",lastName);
            Console.Write("  -Nickname: ");
            var nickname = Console.ReadLine().Trim();
            dict.Add("nickname",nickname);
            Console.Write("  -Works in city: ");
            var city = Console.ReadLine().Trim();
            dict.Add("city",city);
            return dict;
        }
        
        public static Dictionary<string,string> AddBuyer()
        {
            Dictionary<string,string> dict = new Dictionary<string, string>();
            
            Console.Write("  -Nickname: ");
            var nickname = Console.ReadLine().Trim();
            dict.Add("nickname",nickname);
            Console.Write("  -Buys from (dealer nickname): ");
            var dNickname = Console.ReadLine().Trim();
            dict.Add("dealerNickname",dNickname);

            return dict;
        }
        public static Dictionary<string,string> Steal()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            Console.Write("  -Amount: ");
            var amount = Console.ReadLine().Trim();
            dict.Add("amount",amount);
            Console.Write("  -From bank: ");
            var bank = Console.ReadLine().Trim();
            dict.Add("bank",bank);

            return dict;

        }

        public static Dictionary<string, string> Sell()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            
            Console.Write("  -Buyer nickname: ");
            var buyerNickname = Console.ReadLine().Trim();
            dict.Add("bNickname",buyerNickname);
            Console.Write("  -Drug name: ");
            var drugName = Console.ReadLine().Trim();
            dict.Add("drugName",drugName);
            Console.Write("  -Quantity: ");
            var quantity = Console.ReadLine().Trim();
            dict.Add("quantity",quantity);
            
            return dict;
        }
        
        public static Dictionary<string, string> Buy()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            Console.Write("  -Drug name: ");
            var drugName = Console.ReadLine().Trim();
            dict.Add("drugName",drugName);
            Console.Write("  -Quantity: ");
            var quantity = Console.ReadLine().Trim();
            dict.Add("quantity",quantity);
            
            return dict;
        }
    }
}