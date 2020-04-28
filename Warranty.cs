using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Warranty
    {
        private DateTime DateIssued { get; }

        private TimeSpan Duration { get;}

        public Warranty(DateTime dataIssued, TimeSpan duration)
        {
            this.DateIssued = DateIssued;
            this.Duration = duration;
        }

        public bool IsValidon(DateTime date) => date.Date >= this.DateIssued && date.Date < this.DateIssued + this.Duration;
    }

    public class SoldArticle
    {
        public  Warranty MoneyBackGuarantee { get; }
        public Warranty ExpressWarranty { get; }

        public SoldArticle(Warranty moneyBack, Warranty express) 
        {
            if (moneyBack == null)
                throw new ArgumentNullException("The money back is null");
            if (express == null)
                throw new ArgumentNullException("The express is null");

            this.MoneyBackGuarantee = moneyBack;
            this.ExpressWarranty = express;
        }
    }

    public class Player
    { 
        public void ClaimWarranty(SoldArticle soldArticle, bool isInGoodCondition, bool isBroken)
        {
            DateTime now = DateTime.Now;
            if (isInGoodCondition && !isBroken && soldArticle.MoneyBackGuarantee.IsValidon(now))
                Console.WriteLine("Offer money back.");

            if (isBroken && soldArticle.ExpressWarranty.IsValidon(now))
                Console.WriteLine("Offer repair.");
        }
    }

}
