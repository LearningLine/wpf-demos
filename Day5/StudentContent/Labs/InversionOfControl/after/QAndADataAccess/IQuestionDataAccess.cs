using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QAndAModel;

namespace QAndADataAccess
{
    public interface IQuestionDataAccess
    {
        Question GetQuestion(int id);
    }

}
