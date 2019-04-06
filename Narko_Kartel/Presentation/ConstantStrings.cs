using System;

namespace SQLapp.Presentation
{
    public static class ConstantStrings
    {
        public static readonly string[] KillStrings = {
            "died in a car crash.",
            "slipped in his bathroom and died.",
            "got a heart attack.",
            "fell off a cliff and died.",
            "got shot in the head. The killer is missing.",
            "was killed by a bear in the forest.",
            "was stabbed by a burglar in his oun house.",
            "broke his neck, rolling down the stairs."
        };

        public static readonly string[] HelpStrings =
        {
            "COMMAND:           | DESCRIPTION:   ",
            "___________________|_________________________________________________________",
            "LIST DEALERS       | Print a list of all your dealers.",
            "LIST BUYERS        | Print a list of all your buyers.",
            "LIST DRUGS         | Print a list of all your drugs",
            "BALANCE            | Print your current balance.",
            "                   | ",
            "DEALER [Nickname]  | Print detailed information about a specific dealer.",
            "DRUG [Name]        | Print detailed information about a specific drug.",
            "                   | ",
            "KILL [Nickname]    | Kill one of your dealers. It will be shown on the News.",
            "HIRE DEALER        | Hire a new dealer.",
            "ADD BUYER          | Add a new buyer to your buyers list.",
            "NEW DRUG           | Start selling a new drug.",
            "                   | ",
            "SELL               | Sell drugs.",
            "BUY DRUGS          | Buy drugs for selling.",
            "PAY SALARIES       | Pay your dealers salaries.",
            "                   |                 (10% of what they have sold this month).",
            "                   | ",
            "END                | Terminate the program.",
            "___________________|_________________________________________________________"
        };
        
        public const string StealString = "bank was robbed today!";

        public const string BalanceString = "Your company has ";

        public const string ConnectingString = "-> Connecting to data base server...";

        public const string EndString = "Terminating program...";

        public const string InvalidCommandString = "Invalid command.";

        public const string DoneString = "Done.";
            
        public const string Line = "-----------------------------------------------------------------------------";

        public const string UnderLine = "_____________________________________________________________________________";

        public const string BreakingNews =
            "----------------------------BREAKING NEWS------------------------------------";

        public const string Blank = "Don't leave blank spaces!";

        public const string ValidNumber = "must be a valid number!";

        public const string NotFound = "not found!";

        public const string AlreadyExists = "already exists!";

        public const string PositiveNumber = "must be a positive number!";

        public const string NotEnough = "Not enough";

        public const string Drug = "Drug";
        
        public const string Money = "Money";
        
        public const string Dealer = "Dealer";
        
        public const string Buyer = "Buyer";

        public const string Quantity = "Quantity";
        
        public const string Amount = "Amount";

        public const string MoneyKey = "KartelMoney";

        public const string SellAndAcquire = "Sell price and acquire price both";

    }
}