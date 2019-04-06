namespace SQLapp.Service
{
    public interface IService
    {
        void Help();
        void ListDealers();
        void ListBuyers();
        void ListDrugs();
        void Balance();
        void Dealer(string nickname);
        void Drug(string name);
        void Kill(string nickname);
        void HireDealer();
        void AddBuyer();
        void NewDrug();
        void Steal();
        void Sell();
        void BuyDrugs();
        void PaySalaries();
        void End();
        void InvalidCommand();

    }
}