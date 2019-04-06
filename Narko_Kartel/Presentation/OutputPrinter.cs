using System;
using System.Collections.Generic;
using System.Linq;
using SQLapp.Data;
using SQLapp.Data.Model;

namespace SQLapp.Presentation
{
    public static class OutputPrinter
    {
        public static void Help()
        {
            Console.WriteLine(ConstantStrings.Line);
            foreach (var helpString in ConstantStrings.HelpStrings)
            {
                Console.WriteLine(helpString);
            }
            Console.WriteLine();

        }

        public static void InvalidCommand()
        {
            Console.WriteLine(ConstantStrings.InvalidCommandString);
            Console.WriteLine(ConstantStrings.UnderLine);
            Console.WriteLine();

        }
        public static void End()
        {
            Console.WriteLine(ConstantStrings.EndString);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(".");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(".");
            System.Threading.Thread.Sleep(1200);
            Console.WriteLine(".");
            System.Threading.Thread.Sleep(900);
            Done();
        }
        public static void Connecting()
        {
            Console.WriteLine(ConstantStrings.ConnectingString);
        }
        public static void Done()
        {
            Console.WriteLine(ConstantStrings.DoneString);
            Console.WriteLine(ConstantStrings.UnderLine);
            Console.WriteLine();
        }

        public static void Kill(string name)
        {
            Random r = new Random();
            int n = r.Next(0, 8);

            string text = ConstantStrings.KillStrings[n];
            
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine(ConstantStrings.BreakingNews);
            Console.WriteLine();
            Console.WriteLine(name + " " + text);
            Console.WriteLine();
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine(ConstantStrings.UnderLine);
            Console.WriteLine();
        }

        public static void Steal(string bank)
        {
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine(ConstantStrings.BreakingNews);
            Console.WriteLine("");
            Console.WriteLine(bank + " " + ConstantStrings.StealString);
            Console.WriteLine("");
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine(ConstantStrings.UnderLine);
            Console.WriteLine("");
        }

        public static void Balance(double amount)
        {
            Console.WriteLine(ConstantStrings.BalanceString + $"{amount:f2}lv.");
            Console.WriteLine(ConstantStrings.UnderLine);
            Console.WriteLine();
        }

        public static void ListDealers(List<Dealer> dealers)
        {
            Console.WriteLine("DEALERS:");
            foreach (var dealer in dealers)
            {
                Console.WriteLine(ConstantStrings.Line);
                Console.WriteLine($"| {dealer.Nickname} has made {dealer.Money_Brought_This_Month:f2}lv. this month.");
            }
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine(ConstantStrings.UnderLine);
            Console.WriteLine();
        }
        
        public static void ListBuyers(List<Buyer> buyers)
        {
            NarkoKartelContext c = new NarkoKartelContext();
         
            Console.WriteLine("Buyers:");
            foreach (var buyer in buyers)
            {
                Dealer dealer = c.Dealers.Single(e => e.Id == buyer.DealerId);
                
                Console.WriteLine(ConstantStrings.Line);
                Console.WriteLine($"| {buyer.Nickname} is buying from {dealer.Nickname}");
            }
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine(ConstantStrings.UnderLine);
            Console.WriteLine();
        }
        public static void ListDrugs(List<Drug> drugs)
        {
            NarkoKartelContext c = new NarkoKartelContext();
         
            Console.WriteLine("Drugs:");
            foreach (var drug in drugs)
            {   
                Console.WriteLine(ConstantStrings.Line);
                Console.WriteLine($"| {drug.Name} - quantity: {drug.Quantity}");
            }
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine(ConstantStrings.UnderLine);
            Console.WriteLine();
        }

        public static void Dealer(Dealer dealer)
        {
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine($"| {dealer.First_Name} {dealer.Last_Name}({dealer.Nickname}) | From: {dealer.CityFrom} | Money brought this month: {dealer.Money_Brought_This_Month:f2}");
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine(ConstantStrings.UnderLine);
            Console.WriteLine();
        }
        
        public static void Drug(Drug drug)
        {
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine($"| {drug.Name} | Sell price: {drug.Sell_Price} | Acquire price: {drug.Acquire_Price} | Quantity: {drug.Quantity}");
            Console.WriteLine(ConstantStrings.Line);
            Console.WriteLine(ConstantStrings.UnderLine);
            Console.WriteLine();
        }

        public static void PaySalaries(double amount)
        {
            Console.WriteLine($"You payed {amount}lv. for salaries this month.");
            Console.WriteLine(ConstantStrings.UnderLine);
            Console.WriteLine();
        }
    }
}