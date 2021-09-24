using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Exceptions
{
    class DeclarationIsNotAvailableException : Exception
    {
        public DeclarationIsNotAvailableException(DateTime dateTime) : base(String.Format("Declaration is not available on this date: {0}", dateTime))
        {

        }
    }
    class DeclarationPeriodCanNotBeSetException : Exception
    {
        public DeclarationPeriodCanNotBeSetException(DateTime dateTime) : base(String.Format("Declaration period can not be set on this date: {0}", dateTime))
        {
        }
    }
}
