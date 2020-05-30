using System;

namespace Frontline.DP.Second
{
    /// <summary>
    /// The problem with code is that the code must be changed for handel the states.
    /// </summary>
    public class Account
    {
        public decimal Balance { get; private set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        private bool IsFrozen { get; set; }

        private Action OnUnfreeze { get; }
        private Action ManageUnfreezing { get; set; }

        public Account(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
            this.ManageUnfreezing = () =>
            {
                if (this.IsFrozen)
                {
                    UnFreeze();
                }
                else
                {
                    StayUnFreeze();
                }
            };
        }

        // #1: Deposit 10, Close, Deposit 1 - Balance == 10
        // #1: Deposit 10, Deposit 1 - Balance == 11
        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;//Do other things...
            ManageUnfreezing();
            this.Balance += amount;
        }

        // #3: Deposit 10, Withdraw 1 - Balance == 10
        // #4: Deposit 10, Verify, Closed, Withdraw 1 -Balance == 10
        // #5: Deposit 10, Verify, Withdraw 1- Balance == 9
        public void WithDraw(decimal amount)
        {
            if (!this.IsVerified)
                return; //Do other things...
            if (this.IsClosed)
                return; //Do other things...
            this.ManageUnfreezing();
            this.Balance -= amount;
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }

        public void Freeze()
        {
            if (this.IsClosed)
                return;
            if (!this.IsVerified)
                return;
            this.IsFrozen = true;
        }
        private void UnFreeze()
        {
            this.IsFrozen = false;
            this.OnUnfreeze();
        }
        private void StayUnFreeze() { }
    }
}
