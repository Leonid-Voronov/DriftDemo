using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public interface IConvertService
    {
        List<string> ConvertEnumToString<Type>(List<Type> enums) where Type : Enum;
        public List<string> ConvertMaterialsToString(List<Material> objects);
    }
}