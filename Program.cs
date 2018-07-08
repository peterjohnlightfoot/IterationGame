using System;
using System.Collections.Generic;
using System.IO;

namespace IterationGame {
   class Program {
      public static void Main( string[] args ) {
         Console.WriteLine("Starting...");

         IEnumerable<Team> teams = new Team[] {
            new PotentiallyShippableTeam(),
            new ContinuousDeploymentTeam()
         };

         (new Machine(teams)).Run();
         Logger.Instance.Close();

         Console.WriteLine("\r\nDone. Press any key to exit.");
         Console.ReadKey();
      }
   }
}
