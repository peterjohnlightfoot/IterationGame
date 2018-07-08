namespace IterationGame {
   public class ContinuousDeploymentTeam : Team {

      public ContinuousDeploymentTeam() : base("B:ContinuousDeployment") { }

      protected override void UpdateTarget( Vector2 target ) {
         SetCurrentTarget(target);
      }

      protected override void UpdatePosition() {
         Position = NewPosition();
      }
   }
}
