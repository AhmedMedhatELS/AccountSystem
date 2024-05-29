using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem
{
    internal class CheckingAccount : Account
    {
        double withdrawFee = 1.50;
        public CheckingAccount(string name = "Unnamed Account", double balance = 0.0) : base(name, balance)
        {

        }
        public override bool Withdraw(double amount)
        {
            return base.Withdraw(amount + withdrawFee);
        }
        public override string ToString()
        {
            return $"Checking {base.ToString()} : Withdraw Fee = {withdrawFee}";
        }
    }
}
