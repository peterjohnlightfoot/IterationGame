namespace IterationGame {
   public class PotentiallyShippableTeam : Team {

      public PotentiallyShippableTeam() : base("A:PotentiallyShippable") { }

      protected override void UpdateTarget( Vector2 target ) {
         // nothing to do
      }

      protected override void UpdatePosition() {
         Position = NewPosition();
      }
   }
}
