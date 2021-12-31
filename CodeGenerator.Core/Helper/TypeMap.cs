using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core.Helper
{
    public class TypeMap
    {
       
        public static string Map(string dbType, string nullable)
        {
            /*
             * 临时硬编码
             */
            var d = dbType.ToLower();
            if (d.Contains("char"))
            {
                return "string";
            }
            else if (d.Contains("int") || d.Contains("bit"))
            {
                return nullable == "YES" ? "int?" : "int";
            }
            else if (d.Contains("date"))
            {
                return nullable == "YES" ? "DateTime?" : "DateTime";
            }
            else
            {
                throw new Exception($"未知数据类型 {dbType}");
            }
        }
        public TypeMap()
        {

        }
    }
}
