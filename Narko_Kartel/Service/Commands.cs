using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using SQLapp.Controller;
using SQLapp.Data;
using SQLapp.Data.Model;
using SQLapp.Presentation;

namespace SQLapp.Service
{
    public class Commands : IService
    {
        private static NarkoKartelContext c;
        private Money money;

        public Commands(NarkoKartelContext cont)
        {
            c = cont;
            //money = c.Money.Single(e => e.MoneyKey == ConstantStrings.MoneyKey);
        }
        public Commands()
        {
            c = new NarkoKartelContext();
            money = c.Money.Single(e => e.MoneyKey == ConstantStrings.MoneyKey);
        }
        
        /// <help>  
        ///  This method prints a table with all commands and their descriptions.  
        ///  </help>
        public void Help()
        {
            OutputPrinter.Help();
        }
        
        /// <listDealers>  
        ///  This method prints a list with all dealers in the database, with the amount of money they have made this month.  
        /// </listDealers> 
        public void ListDealers()
        {
            OutputPrinter.Connecting();

            var dealers = GetAllDealers();
            
            OutputPrinter.Done();
            
            OutputPrinter.ListDealers(dealers);
        }
        public List<Dealer> GetAllDealers()
        {
            var dealers = c.Dealers.ToList();
            return dealers;
        }
        
        /// <listBuyers>  
        ///  This method prints a list with all buyers in the database, with the dealer they are buying from.
        /// </listBuyers> 
        public void ListBuyers()
        {
            OutputPrinter.Connecting();

            var buyers = GetAllBuyers();
            
            OutputPrinter.Done();
            
            OutputPrinter.ListBuyers(buyers);
        }
        public List<Buyer> GetAllBuyers()
        {
            var buyers = c.Buyers.ToList();
            return buyers;
        }
        
        /// <listDrugs>  
        ///  This method prints a list with all drugs ever registered in the database, with their current quantity.
        /// </listDrugs> 
        public void ListDrugs()
        {
            OutputPrinter.Connecting();

            var drugs = GetAllDrugs();
            
            OutputPrinter.Done();
            
            OutputPrinter.ListDrugs(drugs);
        }
        public List<Drug> GetAllDrugs()
        {
            var drugs = c.Drugs.ToList();
            return drugs;
        }
        
        /// <dealer>  
        ///  This method takes a dealer nickname as an argument.
        ///  It prints a detailed information about the specified dealer.
        ///  (full name, nickname, the city they are working at, amount of money they have brought this month)
        /// </dealer> 
        public void Dealer(string nickname)
        {
            Dealer dealer;
            OutputPrinter.Connecting();
            try
            {
                try
                {
                    dealer = c.Dealers.Single(e => e.Nickname == nickname);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException(ConstantStrings.Dealer + $" with nickname '{nickname}'"+ConstantStrings.NotFound);
                }

                OutputPrinter.Done();

                OutputPrinter.Dealer(dealer);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                OutputPrinter.InvalidCommand();
            }
        }
        
        /// <drug>  
        ///  This method takes a drug name as an argument.
        ///  It prints a detailed information about the specified drug.
        ///  (drug name, the price for one sell, the price for buying one, the current quantity)
        /// </drug> 
        public void Drug(string name)
        {
            Drug drug;
            OutputPrinter.Connecting();
            try
            {
                try
                {
                    drug = c.Drugs.Single(e => e.Name == name);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException(ConstantStrings.Drug + $" with name '{name}' "+ConstantStrings.NotFound);
                }

                OutputPrinter.Done();

                OutputPrinter.Drug(drug);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                OutputPrinter.InvalidCommand();
            }
        }
        
        /// <kill>  
        ///  This method takes a dealer nickname as an argument.
        ///  It removes the specified dealer from the database,
        ///  and prints a random cover story for the "killed" dealer.
        /// </kill> 
        public void Kill(string nickname)
        {
           OutputPrinter.Connecting();
           Dealer dealer;
           try
           {
               try
               {
                    dealer = c.Dealers.Single(e => e.Nickname == nickname);
               }
               catch (Exception)
               {
                   throw new InvalidOperationException(ConstantStrings.Dealer + $" with nickname '{nickname}' "+ConstantStrings.NotFound);
               }
               
               Kil(dealer);
               OutputPrinter.Done();
               string name = dealer.First_Name + " " + dealer.Last_Name + "(" + dealer.Nickname + ")";
               OutputPrinter.Kill(name);
           }
           catch (Exception e)
           {
               Console.WriteLine(e.Message);
               OutputPrinter.InvalidCommand();
           }
        }
        public void Kil(Dealer dealer)
        {
            c.Dealers.Remove(dealer);
            c.SaveChanges();
        }
        
        /// <hireDealer>  
        ///  This method takes from the console information for a new dealer.
        ///  (first name, last name, nickname, city)
        ///  It adds the new dealer to the database.
        /// </hireDealer>
        public void HireDealer()
        {
            string firstName;
            string lastName;
            string nickname;
            string city;
            double money = 0;

            try
            {
                Dictionary<string, string> dict = CommandReader.HireDealer();
                firstName = dict["firstName"];
                lastName = dict["lastName"];
                nickname = dict["nickname"];
                city = dict["city"];

                if (firstName == "" || lastName == "" || nickname == "" || city =="")
                {
                    throw new InvalidOperationException(ConstantStrings.Blank);
                    
                }
                OutputPrinter.Connecting();
                
                List<string> nicknames = c.Dealers.Select(e => e.Nickname).ToList();

                if (nicknames.Contains(nickname))
                {
                    throw new InvalidOperationException(ConstantStrings.Dealer + $" with nickname '{nickname}' " + ConstantStrings.AlreadyExists);
                }
                
                var dealer = new Dealer()
                {
                    First_Name = firstName,
                    Last_Name = lastName,
                    Nickname = nickname,
                    CityFrom = city,
                    Money_Brought_This_Month = money
                };
                
                Hire(dealer);
                OutputPrinter.Done();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                OutputPrinter.InvalidCommand();
            }
        }
        public void Hire(Dealer dealer)
        { 
            c.Dealers.Add(dealer);
            c.SaveChanges();
        }

        /// <addBuyer>  
        ///  This method takes from the console information for a new buyer.
        ///  (nickname, the nickname of an existing dealer)
        ///  It adds the new dealer to the database,
        ///  and assigns the new buyer to the dealer. 
        /// </addBuyer>
        public void AddBuyer()
        {
            string nickname;
            string dNickname;
            int dealerID;
            Dealer dealer;

            try
            {
                Dictionary<string, string> dict = CommandReader.AddBuyer();
                nickname = dict["nickname"];
                dNickname = dict["dealerNickname"];

                if (nickname == "" || dNickname =="")
                {
                    throw new InvalidOperationException(ConstantStrings.Blank);
                    
                }
                OutputPrinter.Connecting();

                List<string> nicknames = c.Buyers.Select(e => e.Nickname).ToList();

                if (nicknames.Contains(nickname))
                {
                    throw new InvalidOperationException(ConstantStrings.Buyer + $" with nickname '{nickname}' " + ConstantStrings.AlreadyExists);
                }

                try
                {
                    dealer = c.Dealers.Single(e => e.Nickname == dNickname);
                    dealerID = dealer.Id;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException(ConstantStrings.Dealer + $" with nickname '{nickname}' "+ConstantStrings.NotFound);
                }

                var buyer = new Buyer()
                {
                    Nickname = nickname,
                    DealerId = dealerID
                };
                Add(buyer);
                OutputPrinter.Done();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                OutputPrinter.InvalidCommand();
            }
        }
        public void Add(Buyer buyer)
        {
            c.Buyers.Add(buyer);
            c.SaveChanges();
        }

        /// <newDrug>  
        ///  This method takes from the console information for a new drug.
        ///  (name, sell price, acquire price)
        ///  It adds the new drug to the database.
        /// </newDrug>        
        public void NewDrug()
        {
           string name;
           double sellPrice;
           double acquirePrice;
           int quantity = 0;

           try
           {
               Dictionary<string,string> dict  = CommandReader.NewDrug();
               name = dict["name"];

               if (name == "" || dict["sell"] =="" || dict["acquire"]=="")
               {
                   throw new InvalidOperationException(ConstantStrings.Blank);
                    
               }
               OutputPrinter.Connecting();

               List<string> names = c.Drugs.Select(e => e.Name).ToList();

               if (names.Contains(name))
               {
                   throw new InvalidOperationException(ConstantStrings.Drug + $" with name '{name}' " + ConstantStrings.AlreadyExists);
               }

               try
               {
                   sellPrice = double.Parse(dict["sell"]);
                   acquirePrice = double.Parse(dict["acquire"]);
               }
               catch (Exception)
               {
                   throw new InvalidOperationException(ConstantStrings.SellAndAcquire + " " + ConstantStrings.ValidNumber);
               }
               
               if (sellPrice <= 0 || acquirePrice <= 0)
               {
                   throw new InvalidOperationException(ConstantStrings.SellAndAcquire + " " + ConstantStrings.PositiveNumber);
               }

               var drug = new Drug
               {
                   Name = name,
                   Sell_Price = sellPrice,
                   Acquire_Price = acquirePrice,
                   Quantity = quantity
               };

               New(drug);
               OutputPrinter.Done();
           }
           catch (Exception e)
           {
               Console.WriteLine(e.Message);
               OutputPrinter.InvalidCommand();
           }
        }
        public void New(Drug drug)
        {
            c.Drugs.Add(drug);
            c.SaveChanges();
        }
        
        /// <sell>  
        ///  This method takes from the console information for a sell.
        ///  (buyer nickname, drug name, drug quantity)
        ///  It decreases the quantity on the specified drug from the database with the specified quantity,
        ///  increases the balance with the sell price of the drug multiplied by the selected quantity,
        ///  and increases the dealer's 'money_brought_this_month'.
        /// </sell>
        public void Sell()
        {
            Dealer dealer;
            Buyer buyer;
            Drug drug;
            int quantity;

            try
            {
                Dictionary<string, string> dict = CommandReader.Sell();
                OutputPrinter.Connecting();

                if (dict["bNickname"] == "" || dict["drugName"] == "" || dict["quantity"] == "")
                {
                    throw new InvalidOperationException(ConstantStrings.Blank);
                }
                
                try
                {
                    buyer = c.Buyers.Single(e => e.Nickname == dict["bNickname"]);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException(ConstantStrings.Buyer+ " " + ConstantStrings.NotFound);
                }
                
                dealer = c.Dealers.Single(e => e.Id == buyer.DealerId);
                
                try
                {
                    drug = c.Drugs.Single(e => e.Name == dict["drugName"]);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException(ConstantStrings.Drug + " " + ConstantStrings.NotFound);
                }

                try
                {
                    quantity = int.Parse(dict["quantity"]);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException(ConstantStrings.Quantity + " " + ConstantStrings.ValidNumber);
                }
               
                if (quantity <= 0)
                {
                    throw new InvalidOperationException(ConstantStrings.Quantity + " " + ConstantStrings.PositiveNumber);
                }
                
                if (quantity > drug.Quantity)
                {
                    throw new InvalidOperationException(ConstantStrings.NotEnough + $" {drug.Name}!");
                }
                
                double price = drug.Sell_Price * quantity;

                money.Money_Amount += price;
                dealer.Money_Brought_This_Month += price;
                Sel(drug,quantity);
                OutputPrinter.Done();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                OutputPrinter.InvalidCommand();
            }
        }
        public void Sel(Drug drug,int quantity)
        {
            drug.Quantity -= quantity;
            c.SaveChanges();
        }
        
        /// <buyDrugs>  
        ///  This method takes from the console information for a drug purchase.
        ///  (existing drug name, drug quantity)
        ///  It increases the quantity on the specified drug from the database with the specified quantity,
        ///  and decreases the balance with the acquire price of the drug multiplied by the selected quantity.
        /// </buyDrugs>
        public void BuyDrugs()
        {
            Drug drug;
            int quantity;

            try
            {
                Dictionary<string, string> dict = CommandReader.Buy();

                if (dict["drugName"] == "" || dict["quantity"] == "")
                {
                    throw new InvalidOperationException(ConstantStrings.Blank);
                }
                
                OutputPrinter.Connecting();
                try
                {
                    drug = c.Drugs.Single(e => e.Name == dict["drugName"]);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException(ConstantStrings.Drug + $" with name '{dict["drugName"]}' "+ConstantStrings.NotFound);
                }
                
                try
                {
                    quantity = int.Parse(dict["quantity"]);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException(ConstantStrings.Quantity + " " + ConstantStrings.ValidNumber);
                }
               
                if (quantity <= 0)
                {
                    throw new InvalidOperationException(ConstantStrings.Quantity + " " + ConstantStrings.PositiveNumber);
                }                
                
                double price = drug.Acquire_Price * quantity;

                if (price > money.Money_Amount)
                {
                    throw new InvalidOperationException(ConstantStrings.NotEnough + " " + ConstantStrings.Money.ToLower() + "!");
                }

                money.Money_Amount -= price;
               
                Buy(drug,quantity);
                OutputPrinter.Done();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                OutputPrinter.InvalidCommand();
            }
        }
        public void Buy(Drug drug, int quantity)
        {
            drug.Quantity += quantity;
            c.SaveChanges();
        }
        
        /// <paySalaries>  
        ///  This method pays all the dealers salaries.
        ///  It decreases the balance with 10% of all 'money_brought_this_month' fields in dealers,
        ///  and zeroes these fields.
        /// </paySalaries>
        public void PaySalaries()
        {
            const double percent = 0.1;
            double total = 0;
           
            OutputPrinter.Connecting();
            List<double> moneyFromDealers = c.Dealers.Select(e => e.Money_Brought_This_Month).ToList();
            
            foreach (var moneyFromDealer in moneyFromDealers)
            {
                total += moneyFromDealer;
            }

            List<Dealer> dealers = c.Dealers.ToList();

            Pay(dealers);
            
            double moneyToPay = total * percent;
            money.Money_Amount -= moneyToPay;
            OutputPrinter.Done();
            OutputPrinter.PaySalaries(moneyToPay);
        }
        public void Pay(List<Dealer> dealers)
        {
            for (int i = 0; i < dealers.Count; i++)
            {
                dealers[i].Money_Brought_This_Month = 0;
                c.SaveChanges();
            }
        }
        
        /// <balance>  
        ///  This method prints the current balance,
        ///  which is stored in the database.
        /// </balance>
        public void Balance()
        {
            OutputPrinter.Connecting();
            double amount = money.Money_Amount;
            OutputPrinter.Done();
            OutputPrinter.Balance(amount);
        }
        
        /// <steal>  
        ///  This method takes from the console information for a bank robbery.
        ///  (amount money to steal, bank name)
        ///  It increases the balance with the specified amount,
        ///  and prints the name of the robbed bank.
        /// </steal>
        public void Steal()
        {
           double amount;
           string bank;
           try
           {

               Dictionary<string, string> dict = CommandReader.Steal();

               if (dict["bank"] == "" || dict["amount"]=="")
               {
                   throw new InvalidOperationException(ConstantStrings.Blank);
               }
               
               try
               {
                   amount = double.Parse(dict["amount"]);
               }
               catch (Exception)
               {
                   throw new InvalidOperationException(ConstantStrings.Amount + " " + ConstantStrings.ValidNumber);
               }

               bank = dict["bank"];

               OutputPrinter.Connecting();
               money.Money_Amount += amount;
               c.SaveChanges();
               OutputPrinter.Done();

               OutputPrinter.Steal(bank);

           }
           catch (Exception e)
           {
               Console.WriteLine(e.Message);
               OutputPrinter.InvalidCommand();
           }
        }
        
        /// <end>  
        ///  This method terminates the program.
        ///  It takes 3 seconds to finish the process. 
        /// </end>
        public void End()
        {
            NarkoKartelController.Flag = false;
            OutputPrinter.End();
        }
        
        /// <invalidCommand>  
        ///  This method prints an exception.
        /// </invalidCommand>
        public void InvalidCommand()
        {
            OutputPrinter.InvalidCommand();
        }
    }
}