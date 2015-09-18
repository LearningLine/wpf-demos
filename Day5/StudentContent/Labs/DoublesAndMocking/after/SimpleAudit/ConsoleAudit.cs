using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Audit;

namespace SimpleAudit
{
    public class ConsoleAudit : IAudit
    {
        #region IAudit Members

        public void Message(string message)
        {
            Console.WriteLine("*** Audit message:" + message);
        }

        #endregion
    }
}
