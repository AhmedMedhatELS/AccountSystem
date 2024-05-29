using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AccountSystem
{
    internal class SavingsAccount : Account
    {
        double interestRata;

        public SavingsAccount(string name = "Unnamed Account", double balance = 0.0, double interestRata = 1.5):base(name,balance)
        {
            this.interestRata = interestRata;
        }
        public override bool Deposit(double amount)
        {
            return base.Deposit(amount + amount * (interestRata / 100));
        }
        public override string ToString()
        {
            return $"Saving {base.ToString()} : Interest Rate = {interestRata}";
        }
    }
}
