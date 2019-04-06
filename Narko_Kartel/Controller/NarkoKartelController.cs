using System;
using System.Linq;
using SQLapp.Presentation;
using SQLapp.Service;

namespace SQLapp.Controller
{
    public class NarkoKartelController
    {
        private static bool _flag;
        private Commands service;
        public static bool Flag
        {
            get => _flag;
            set => _flag = value;
        }
        public NarkoKartelController(object h)
        {
          
        }
        public NarkoKartelController()
        {
            _flag = true;
            service = new Commands();
        }
        
        public void Start()
        { 
            while (_flag)
            {
                CommandReader.TakeInput();
                ProcessInput(CommandReader.Input);
            }
        }

        private void ProcessInput(string input)
        {
            string[] args = input.Trim().Split().ToArray();

            switch (args[0])
            {
                case "HELP":
                    if (args.Length!=1)
                      service.InvalidCommand();
                    else
                        service.Help();
                    break;
                case "LIST":
                    if (args.Length != 2)
                    {
                        service.InvalidCommand();
                    }
                    else
                    {
                        switch (args[1])
                        {
                            case "DEALERS":
                                service.ListDealers();
                                break;
                            case "BUYERS":
                                service.ListBuyers();
                                break;
                            case "DRUGS":
                                service.ListDrugs();
                                break;
                            default:
                                service.InvalidCommand();
                                break;
                        }
                    }
                    break;
                case "BALANCE":
                    if (args.Length != 1)
                    {
                        service.InvalidCommand();
                    }
                    else
                    {
                        service.Balance();
                    }
                    break;
                case "DEALER":
                    if (args.Length != 2)
                    {
                        service.InvalidCommand();
                    }
                    else
                    {
                        service.Dealer(args[1]);
                    }
                    break;
                case "DRUG":
                    if (args.Length != 2)
                    {
                        service.InvalidCommand();
                    }
                    else
                    {
                        service.Drug(args[1]);
                    }
                    break;
                case "KILL":
                    if (args.Length != 2)
                    {
                        service.InvalidCommand();
                    }
                    else
                    {
                        service.Kill(args[1]);
                    }
                    break;
                case "HIRE":
                    if (args.Length != 2)
                    {
                        service.InvalidCommand();
                    }
                    else
                    {
                        if (args[1] == "DEALER")
                        {
                            service.HireDealer();
                        }
                        else
                        {
                            service.InvalidCommand();
                        }
                    }
                    break;
                case "ADD":
                    if (args.Length != 2)
                    {
                        service.InvalidCommand();
                    }
                    else
                    {
                        if (args[1] == "BUYER")
                        {
                            service.AddBuyer();
                        }
                        else
                        {
                            service.InvalidCommand();
                        }
                    }
                    break;
                case "NEW":
                    if (args.Length != 2)
                    {
                        service.InvalidCommand();
                    }
                    else
                    {
                        if (args[1] == "DRUG")
                        {
                            service.NewDrug();
                        }
                        else
                        {
                            service.InvalidCommand();
                        }
                    }
                    break;
                case "SELL":
                    if (args.Length != 1)
                    {

                        service.InvalidCommand();
                    }
                    else
                    {
                        service.Sell();
                    }
                    break;
                case "BUY":
                    if (args.Length != 2)
                    {
                        service.InvalidCommand();
                    }
                    else
                    {
                        if (args[1] == "DRUGS")
                        {
                            service.BuyDrugs();
                        }
                        else
                        {
                            service.InvalidCommand();
                        }
                    }
                    break;
                case "PAY":
                    if (args.Length != 2)
                    {
                        service.InvalidCommand();
                    }
                    else
                    {
                        if (args[1] == "SALARIES")
                        {
                            service.PaySalaries();
                        }
                        else
                        {
                            service.InvalidCommand();
                        }
                    }
                    break;
                case "STEAL":
                    if (args.Length != 1)
                    {
                        service.InvalidCommand();
                    }
                    else
                    {
                        service.Steal();
                    }
                    break;
                case "END":
                    if (args.Length != 1)
                    {
                        service.InvalidCommand();
                    }
                    else
                    {
                        service.End();
                    }
                    break;
                default:
                    service.InvalidCommand();
                    break;
                    
            }
        }
        
    }
}