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

      for (int nodeIndex = 0; nodeIndex < numNodes; nodeIndex++)
      {
        Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();

        stack.Push(new Tuple<int, int>(-1, nodeIndex));
        int pathLength = 0;
        while (stack.Count() > 0)
        {
          var node = stack.Pop();

          int parent = node.Item1;
          int child = node.Item2;

          if (parent == -1)
          {
            AddNeighbors(stack, graph, child);
          }
          else
          {
            pathLength += graph[parent][child];
            int[] neighbors = graph[child];

            int count = neighbors.Count(x => x != -1);

            if (count == 0)
            {
              if (pathLength > max)
              {
                max = pathLength;
              }
              pathLength = 0;
            }
            else {
              AddNeighbors(stack, graph, child);
            }
          }
        }

        //int[] links = graph[node];
        //int numLinks = links.Length;
        //for (int linkIndex = 0; linkIndex < numLinks; linkIndex++)
        //{
        //  Stack<int> stack = new Stack<int>();
        //  int link = links[linkIndex];
        //  if (link==-1) { continue; }
        //  stack.Push(link);

        //  int pathLength = 0;
        //  while (stack.Count() > 0)
        //  {
        //    int currLink = stack.Pop();

        //    pathLength += graph[node][currLink];

        //    int[] neighbors = graph[linkIndex];
        //    Array.ForEach(neighbors, n => stack.Push(n));

        //  }

        //  if (pathLength > max)
        //  {
        //    max = pathLength;
        //  }
        //}

      }

      return max;
    }

    private void AddNeighbors(Stack<Tuple<int, int>> stack, int[][] graph, int index)
    {
      int[] neighbors = graph[index];

      for (int n = 0; n < neighbors.Length; n++)
      {
        if (neighbors[n] != -1)
        {
          stack.Push(new Tuple<int, int>(index, n));
        }
      }
    }

    private int[][] BuildGraph(string[] connects, string[] costs)
    {
      int numNodes = connects.Length;
      int[][] graph = new int[numNodes][];

      for (int i = 0; i < numNodes; i++)
      {
        graph[i] = Enumerable.Repeat(-1, numNodes).ToArray();

        int[] connect = GetValues(connects[i]);
        int[] linkCosts = GetValues(costs[i]);

        if (connect != null && linkCosts != null)
        {
          int numLinks = connect.Length;
          for (int j = 0; j < numLinks; j++)
          {
            int link = connect[j];
            int cost = linkCosts[j];
            graph[i][link] = cost;
          }
        }
      }
      return graph;
    }

    private int[] GetValues(string str)
    {
      if (String.IsNullOrEmpty(str)) { return null; }
      var arr = str.Split();
      if (arr == null || arr.Length == 0) { return null; }
      return arr.Select(x => int.Parse(x)).ToArray();
    }
  }
}
