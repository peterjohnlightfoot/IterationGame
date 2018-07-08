using System;
using System.Collections.Generic;

namespace IterationGame {
   public class Machine {

      private const int MAX = 100;
      private const int MIN = -MAX;
      private const float STEP = 25f;

      public Machine( IEnumerable<Team> teams ) {
         Teams = teams;
      }

      public static Random NumberGenerator { get; } = new Random(Environment.TickCount);

      public IEnumerable<Team> Teams { get; }

      private static Vector2 GetNewTarget()
         => new Vector2(NumberGenerator.Next(MIN, MAX), NumberGenerator.Next(MIN, MAX));

      private static Vector2 ApplyRefinement( int scale, Vector2 previous, Vector2 current )
         => previous + (current * (1f / scale));

      public void Run() {
         var refinement = new List<Vector2>();
         Vector2 target = InitializeTarget();
         refinement.Add(target);

         // 4 iterations per cycle
         for( int n = 1; n <= 4; n++ ) {
            target = RunIteration(refinement, n);
         }
      }

      private Vector2 InitializeTarget() {
         Vector2 target = GetNewTarget();
         foreach( Team team in Teams ) {
            team.InitializeTarget(target);
         }

         return target;
      }

      private Vector2 RunIteration( List<Vector2> refinement, int n ) {
         Logger.Instance.Verbose($"\r\nIteration {n}...");
         Vector2 target = RefineTarget(refinement, n);
         foreach( Team team in Teams ) {
            RunTeamIteration(team, target, n);
         }
         Logger.Instance.Verbose("End of iteration " + n);
         return target;
      }

      private static Vector2 RefineTarget( List<Vector2> refinement, int n ) {
         Vector2 target = ApplyRefinement(n + 1, refinement[n - 1], GetNewTarget());
         Logger.Instance.Verbose($"\r\n{(n != 0 ? "Refined t" : "T")}arget is {target}");
         refinement.Add(target);
         return target;
      }

      private void RunTeamIteration( Team team, Vector2 target, int iteration ) {
         Logger.Instance.Verbose($"\r\n{team}");
         team.ExecuteIteration(target, iteration);
      }
   }
}
