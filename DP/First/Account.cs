using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.DP.First
{
    /// <summary>
    /// The problem with code is that the code must be changed for handel the states.
    /// </summary>
    public class Account
    {
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }

        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;//Do other things...
            //Deposit money...
        }

        public void WithDraw(decimal amount)
        {
            if (!this.IsVerified)
                return; //Do other things...
            if (this.IsClosed)
                return; //Do other things...

            //Whitdraw money...


        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }
    }
}
