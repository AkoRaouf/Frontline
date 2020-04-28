using System.Collections.Generic;

namespace ConsoleApp1.Composite
{
    public abstract class GiftBase
    {
        protected string name;
        protected int price;

        public GiftBase(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
        public abstract int CalculateTotalPrice();
    }

    public interface IGiftOperation
    {
        void Add(GiftBase gift);
        void Remove(GiftBase gift);
    }

    public class CompositeGift : GiftBase, IGiftOperation
    {
        private readonly List<GiftBase> _gifts;
        public CompositeGift(string name, int price) : base(name, price)
        {
            _gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            _gifts.Add(gift);
        }

        public override int CalculateTotalPrice()
        {
            int total = 0;
            
            _gifts.ForEach(x => total += x.CalculateTotalPrice());

            return total;
        }

        public void Remove(GiftBase gift)
        {
            _gifts.Remove(gift);
        }
    }
}
