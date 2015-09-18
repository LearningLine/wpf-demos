using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QAndAService
{
    public interface IQAndAService
    {
        int VoteUpQuestion(int questionId);
    }
}
