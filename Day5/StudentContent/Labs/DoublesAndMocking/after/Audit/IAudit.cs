using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Audit
{
    public interface IAudit
    {
        void Message(string message);
    }
}
