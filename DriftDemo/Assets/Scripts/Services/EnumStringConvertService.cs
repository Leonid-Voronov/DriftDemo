using System.Collections.Generic;
using System;

namespace Services
{
    public class EnumStringConvertService : IEnumStringConvertService
    {
        public List<string> Convert<Type>(List<Type> enums) where Type : Enum
        {
            List<string> result = new List<string>();
            enums.ForEach(t => result.Add(t.ToString()));
            return result;
        }
    }
}