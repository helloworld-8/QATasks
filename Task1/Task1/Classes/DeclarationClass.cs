using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Exceptions;
using Task1.Extensions;

namespace Task1.Classes
{
    public class DeclarationClass
    {
        public DateTime? AccountingPeriodStartDate { get; set; } = null;
        public DateTime? AccountingPeriodEndDate { get; set; } = null;
        public AccountingPeriod CurrentAccoutingPeriod { get; set; } = AccountingPeriod.None;
        public enum AccountingPeriod
        {
            None,
            PreviousMonth,
            CurrentMonth
        }

        public void Declare(DateTime currentDeclarationDate)
        {
            this.SetAccountingPeriod(currentDeclarationDate);
        }

        public void Declare(string _currentDeclarationDate)
        {
            DateTime currentDeclarationDate = DateTime.Parse(_currentDeclarationDate);
            this.SetAccountingPeriod(currentDeclarationDate);
        }

        private void SetAccountingPeriod(DateTime currentDeclarationDate)
        {
            // „Jeigu einamoji (deklaravimo) diena yra mažesnė nei 10-toji mėnesio diena, tai apskaitos periodas yra prieš tai buvęs mėnuo.“
            if (currentDeclarationDate.Day < 10)
            {
                this.CurrentAccoutingPeriod = AccountingPeriod.PreviousMonth;
                this.AccountingPeriodStartDate = currentDeclarationDate.SubtractMonths(1).StartOfMonth();
                this.AccountingPeriodEndDate = currentDeclarationDate.SubtractMonths(1).EndOfMonth();
            }

            // „Jeigu  einamoji diena yra didesnė nei 20-toji mėnesio diena, tai apskaitos periodas yra einamasis mėnuo.“
            else if (currentDeclarationDate.Day > 20)
            {
                this.CurrentAccoutingPeriod = AccountingPeriod.CurrentMonth;
                this.AccountingPeriodStartDate = currentDeclarationDate.StartOfMonth();
                this.AccountingPeriodEndDate = currentDeclarationDate.EndOfMonth();
            }

            // „Jeigu einamoji diena yra didesnė nei 10 - toji mėnesio diena, bet mažesnė arba lygi 20 - tąjai mėnesio dienai, tai deklaravimas yra negalimas.“
            else if (currentDeclarationDate.Day > 10 && currentDeclarationDate.Day <= 20)
            {
                throw new DeclarationIsNotAvailableException(currentDeclarationDate);
            }

            else
            {
                throw new DeclarationPeriodCanNotBeSetException(currentDeclarationDate);
            }
        }

    }

    


}