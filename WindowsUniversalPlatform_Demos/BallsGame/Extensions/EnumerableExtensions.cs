using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsGame.Extensions
{
  public static class EnumerableExtensions
  {
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
      foreach (var item in collection)
      {
        action(item);
      }
    }
  }
}
