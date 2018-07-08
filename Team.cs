using System;

namespace IterationGame {
   public abstract class Team {

      private float _Progress;

      protected Team( string name ) {
         Name = name;
      }

      public string Name { get; }

      protected Vector2 InitialTarget { get; set; }

      protected Vector2 RefinedTarget { get; set; }

      public Vector2 CurrentTarget { get; private set; }

      public Vector2 Position { get; set; }

      public float DistanceToCurrentTarget { get => DistanceToTarget(CurrentTarget); }

      private float DistanceToTarget( Vector2 target )
         => (target - Position).Length;

      public void InitializeTarget( Vector2 target )
         => InitialTarget = CurrentTarget = target;

      public void ExecuteIteration( Vector2 target, int iteration ) {
         Plan(target);
         Sprint(target, iteration);
      }

      private void Plan( Vector2 target ) {
         RefinedTarget = target;
         UpdateTarget(target);
      }

      protected abstract void UpdateTarget( Vector2 target );

      protected void SetCurrentTarget( Vector2 target ) {
         CurrentTarget = target;
         Logger.Instance.Verbose($"\tTarget is {target}");
         Logger.Instance.Verbose($"\tDistance is {DistanceToCurrentTarget}");
      }

      private void Sprint( Vector2 target, int iteration ) {
         UpdatePosition();
         Logger.Instance.Verbose("\tDistance from (actual) target is " + (RefinedTarget - Position).Length);
      }

      protected abstract void UpdatePosition();

      private float Progress() {
         float progress = (float)(1.0 - Machine.NumberGenerator.NextDouble());
         Logger.Instance.Verbose($"\tApplying progress of {Math.Round(progress * 100, 1)}%");
         return progress;
      }

      protected Vector2 NewPosition() {
         Vector2 position = (CurrentTarget - Position) * Progress() + Position;
         Logger.Instance.Verbose($"\tNew position is {position}");
         return position;
      }

      public override string ToString() => Name;
   }
}
