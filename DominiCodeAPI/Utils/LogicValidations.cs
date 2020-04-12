using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominiCodeAPI.Utils
{
    public class LogicValidations
    {
        public bool IsNotNull(object parameterFromDatabase)
        {
            var IsValid = parameterFromDatabase != null;
            return IsValid;
        }

        public bool ValidateDataCount(int count)
        {
            int restrictionvalue = 0;
            var IsValid = count > restrictionvalue;
            return IsValid;
        }

        public bool IfParametersAreEquals(int idRoute, int IdModel)
        {
            var IsValid = idRoute != IdModel;
            return IsValid;
        }
    }
}
