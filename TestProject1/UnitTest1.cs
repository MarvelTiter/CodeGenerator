using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // (?=\\b)(\\w)
            var removePrefix = "t_flow_jy".Replace("t", "").ToLower();
            var result = Regex.Replace(removePrefix, "(_)(?<=_)(\\w)", m =>
             {
                 return m.Groups[2].Value.ToUpper();
             });
            System.Console.WriteLine(result);
        }
    }
}