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
        new string[] {
        "1 2",
 "2",
 ""}
      };
      string[][] allCosts = new string[][] {
        new string[] {
        "5 3",
 "7",
 ""}
      };

      int[] allLengths = new int[] { 12 };

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
