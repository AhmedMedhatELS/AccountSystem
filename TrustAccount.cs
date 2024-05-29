using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem
{
    internal class TrustAccount : SavingsAccount
    {
        double DepositBonus = 50.00;
        double MinDepositForBonus = 5000.00;
        double maxWithdrawPercantge = 0.2;
        DateTime captureTheCurrentDateTime = DateTime.MinValue;
        int maxWithdrawTimesPerYear = 3;
        int withdrawAreadyHappened = 0;

        public TrustAccount(string name = "Unnamed Account", double balance = 0.0, double interestRata = 1.5) : base(name, balance, interestRata)
        { }
        public override bool Deposit(double amount)
        {
            return base.Deposit(amount >= MinDepositForBonus ? amount + DepositBonus : amount);
        }
        public override bool Withdraw(double amount)
        {
            if(maxWithdrawPercantge * base.GetBalance() <= amount || amount <= 0)
                return false;

            if (withdrawAreadyHappened == 0)
            {
                withdrawAreadyHappened++;
                captureTheCurrentDateTime = DateTime.Now;
                return base.Withdraw(amount);
            }

            if (captureTheCurrentDateTime.AddYears(1) > DateTime.Now)
            {
                if (withdrawAreadyHappened < maxWithdrawTimesPerYear)
                {
                    withdrawAreadyHappened++;
                    return base.Withdraw(amount);
                }
                else { return false; }
            }
            else
            {
                withdrawAreadyHappened = 1;
                captureTheCurrentDateTime = DateTime.Now;
                return base.Withdraw(amount);
            }
        }
        public override string ToString()
        {
            string s = base.ToString();
            s = $"{s.Replace("Saving", "Trust")}";
            return $"{s} : withdraw Aready Happened = {withdrawAreadyHappened}";
        }

    }
}
