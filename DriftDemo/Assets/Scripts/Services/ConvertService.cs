using System.Collections.Generic;
using System;
using UnityEngine;

namespace Services
{
    public class ConvertService : IConvertService
    {
        public List<string> ConvertEnumToString<T>(List<T> enums) where T : Enum
        {
            List<string> result = new List<string>();
            enums.ForEach(t => result.Add(t.ToString()));
            return result;
        }

        public List<string> ConvertMaterialsToString(List<Material> objects)
        {
            List<string> result = new List<string>();
            objects.ForEach(t => result.Add(t.name));
            return result;
        }
    }
}