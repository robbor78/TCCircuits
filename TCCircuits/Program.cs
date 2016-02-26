using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCircuits
{
  public class Program
  {
    static void Main(string[] args)
    {
    }

    public int howLong(String[] connects, String[] costs)
    {
      int[][] graph = BuildGraph(connects, costs);

      int max = 0;

      int numNodes = graph.Length;

      for (int node = 0; node < numNodes; node++)
      {
        int[] links = graph[node];
        int numLinks = links.Length;
        for (int link = 0; link < numLinks; link++)
        {
          Stack<int> stack = new Stack<int>();
          stack.Push(link);

          int pathLength = 0;
          while (stack.Count() > 0)
          {
            int current = stack.Pop();

            pathLength += graph[node][current];

            int[] neighbors = graph[link];
            Array.ForEach(neighbors, n => stack.Push(n));

          }

          if (pathLength > max)
          {
            max = pathLength;
          }
        }

      }

      return max;
    }

    private int[][] BuildGraph(string[] connects, string[] costs)
    {
      int numNodes = connects.Length;
      int[][] graph = new int[numNodes][];

      for (int i = 0; i < numNodes; i++)
      {
        graph[i] = Enumerable.Repeat(-1, numNodes).ToArray();

        int[] connect = connects[i].Split().Select(x => int.Parse(x)).ToArray();
        int[] linkCosts = costs[i].Split().Select(x => int.Parse(x)).ToArray();

        int numLinks = connect.Length;
        for (int j = 0; j < numLinks; j++)
        {
          int link = connect[j];
          int cost = linkCosts[j];
          graph[i][link] = cost;
        }
      }
      return graph;
    }
  }
}
