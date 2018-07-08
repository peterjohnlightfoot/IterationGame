using System;

namespace IterationGame {
   public struct Vector2 {

      public readonly float X;
      public readonly float Y;

      public Vector2( float x, float y ) {
         X = x;
         Y = y;
      }

      public float Length => (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));

      public override string ToString() => $"({X}, {Y})";

      public static Vector2 operator -( Vector2 a, Vector2 b )
         => new Vector2(a.X - b.X, a.Y - b.Y);

      public static Vector2 operator +( Vector2 a, Vector2 b )
         => new Vector2(a.X + b.X, a.Y + b.Y);

      public static Vector2 operator *( Vector2 a, float d )
         => new Vector2(a.X * d, a.Y * d);
   }
}
