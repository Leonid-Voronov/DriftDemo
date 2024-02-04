using System;
using System.Collections.Generic;

namespace Services
{
    public interface IEnumStringConvertService
    {
        List<string> Convert<Type>(List<Type> enums) where Type : Enum;
    }
}