using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCCircuits;

namespace UnitTestProject1
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      string[][] allConnects = new string[][] {
        new string[] {"1 2", "2", ""},
        new string[] {"1 2 3 4 5","2 3 4 5","3 4 5","4 5","5",""},
        new string[]  { "1","2","3","","5","6","7",""},
        new string[] {        "","2 3 5","4 5","5 6","7","7 8","8 9","10", "10 11 12","11","12","12",""},
        new string[] { "","2 3","3 4 5","4 6","5 6","7","5 7",""}
      };
      string[][] allCosts = new string[][] {
        new string[] {"5 3", "7", ""},
        new string[] {"2 2 2 2 2","2 2 2 2","2 2 2","2 2","2",""},
        new string[]  { "2","2","2","","3","3","3",""},
        new string[]  {        "","3 2 9","2 4","6 9","3","1 2","1 2","5", "5 6 9","2","5","3",""},
        new string[]  { "","30 50","19 6 40","12 10","35 23","8","11 20",""}
      };

      int[] allLengths = new int[] { 12, 10, 9, 22, 105 };

      Program p = new Program();
      int length = allConnects.Length;
      for (int i = 0; i < length; i++)
      {
        string[] connects = allConnects[i];
        string[] costs = allCosts[i];

        int actual = p.howLong(connects, costs);

        int expected = allLengths[i];

        Assert.AreEqual(expected, actual);
      }
    }
  }
}
