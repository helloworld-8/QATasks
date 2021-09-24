using NUnit.Framework;
using System;
using System.Collections.Generic;
using static Task1.Classes.DeclarationClass;
using Task1.Classes;
using Task1.Exceptions;
using Task1.Extensions;

namespace Task1.Tests.DeclarationTests
{
    [TestFixture]
    public class DeclarationTests
    {
        private DeclarationClass _declarationClass = new DeclarationClass();

        // From 01 to 09.
        [TestCase("2021-09-01")]
        [TestCase("2021-09-02")]
        [TestCase("2021-09-03")]
        [TestCase("2021-09-04")]
        [TestCase("2021-09-05")]
        [TestCase("2021-09-06")]
        [TestCase("2021-09-07")]
        [TestCase("2021-09-08")]
        [TestCase("2021-09-09")]

        // Day 10 is not defined in the requirements? Or maybe the programmer made a mistake. This test case will show an error
        [TestCase("2021-09-10")]
        public void The_Accounting_Period_Should_Be_The_Previous_Month(string currentDeclarationDate)
        {
            this._declarationClass.Declare(currentDeclarationDate);
            this.VerifyAccountingPeriod(currentDeclarationDate, AccountingPeriod.PreviousMonth);
        }

        // From 09-21 to 09-30.
        [TestCase("2021-09-21")]
        [TestCase("2021-09-22")]
        [TestCase("2021-09-23")]
        [TestCase("2021-09-24")]
        [TestCase("2021-09-25")]
        [TestCase("2021-09-26")]
        [TestCase("2021-09-27")]
        [TestCase("2021-09-28")]
        [TestCase("2021-09-29")]
        [TestCase("2021-09-30")]
        
        // From 10-26 to 10-31.
        [TestCase("2021-10-26")]
        [TestCase("2021-10-27")]
        [TestCase("2021-10-28")]
        [TestCase("2021-10-29")]
        [TestCase("2021-10-30")]
        [TestCase("2021-10-31")]
        public void The_Accounting_Period_Should_Be_The_Current_Month(string currentDeclarationDate)
        {
            this._declarationClass.Declare(currentDeclarationDate);
            this.VerifyAccountingPeriod(currentDeclarationDate, AccountingPeriod.CurrentMonth);
        }

        [TestCase("2021-09-11")]
        [TestCase("2021-09-12")]
        [TestCase("2021-09-13")]
        [TestCase("2021-09-14")]
        [TestCase("2021-09-15")]
        [TestCase("2021-09-16")]
        [TestCase("2021-09-17")]
        [TestCase("2021-09-18")]
        [TestCase("2021-09-19")]
        public void The_Declaration_Should_Not_Be_Available(string currentDeclarationDate)
        {
            Assert.Throws<DeclarationIsNotAvailableException>(() => this._declarationClass.Declare(currentDeclarationDate), "The declaration is available");
        }

        // Random chars, date formats
        // Some of them are valid. This raises the question of whether the program correctly defines one date format.
        [TestCase(" ")]
        [TestCase("a")]
        [TestCase("a-a-b")]
        [TestCase("1a-2a-3b")]
        [TestCase("202a-1a-1b")]
        [TestCase("2021a-12a-10b")]
        [TestCase("08-08")]
        [TestCase("20222-08")]
        [TestCase("2022-2-08-09")]
        [TestCase("20-2-0-10")]
        [TestCase("!@#!@#2022-02-08")]
        [TestCase("2025-12-12-2026-12-12")]
        [TestCase("2025-12-12 2026-12-12")]
        [TestCase("2025-12-12\n2026-12-12")]
        [TestCase("2021-09-00")]
        [TestCase("2021-09-31")]
        [TestCase("2021./09./30")]
        [TestCase("2021-/09-/30")]
        [TestCase("2021@09@30")]
        [TestCase("2021\n09\n30")]
        [TestCase("2021")]
        [TestCase("1998")]
        [TestCase("2021-12")]
        [TestCase("2021-13")]
        [TestCase("9999-12")]
        [TestCase("2999-12")]
        [TestCase("2999-13")]
        [TestCase("2021-12-35")]
        public void The_Accounting_Period_Should_Not_Be_Set_Due_To_Invalid_Date_Format(string currentDeclarationDate)
        {
            Assert.Throws<FormatException>(() => this._declarationClass.Declare(currentDeclarationDate), "The accounting period can be set due to valid date format.");
        }

        private void VerifyAccountingPeriod(string _currentDeclarationDate, AccountingPeriod accountingPeriodShouldBe)
        {
            DateTime currentDeclarationDate = DateTime.Parse(_currentDeclarationDate);
            switch (accountingPeriodShouldBe)
            {
                case AccountingPeriod.PreviousMonth:
                    Assert.AreEqual(currentDeclarationDate.SubtractMonths(1).StartOfMonth(), this._declarationClass.AccountingPeriodStartDate, "The accounting period does not start in the previous month");
                    Assert.AreEqual(currentDeclarationDate.SubtractMonths(1).EndOfMonth(), this._declarationClass.AccountingPeriodEndDate, "The accounting period does not start in the previous month");
                    break;
                case AccountingPeriod.CurrentMonth:
                    Assert.AreEqual(currentDeclarationDate.StartOfMonth(), this._declarationClass.AccountingPeriodStartDate, "The accounting period does not start in the current month");
                    Assert.AreEqual(currentDeclarationDate.EndOfMonth(), this._declarationClass.AccountingPeriodEndDate, "The accounting period does not start in the current month");
                    break;
            }
        }

    }
}
