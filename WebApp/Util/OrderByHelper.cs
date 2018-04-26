using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Personel.Util
{
    public class OrderByHelper<T>
    {
        /// <summary>
        /// We expecting information such as "FirstName" etc
        /// if column isn't found we sort on the first column
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static Func<T, string> GetOrderByExpression(string columnName)
        {
            var propertiesOfElement = typeof(T).GetTypeInfo().GetProperties();
            var matchingElement = propertiesOfElement.FirstOrDefault(p => p.Name.ToUpper() == columnName.ToUpper());
            if (matchingElement != null) //if column found
                return x => matchingElement.GetValue(x, null).ToString();
            else
                return x => propertiesOfElement[0].GetValue(x, null).ToString(); //order by the first element if no element is found
         }
    }
}
