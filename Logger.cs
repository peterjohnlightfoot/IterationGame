using System;
using System.IO;

namespace IterationGame {
   public class Logger {

      public enum LogLevel {
         Verbose = 0,
         Simple
      }

      private const LogLevel LOG_LEVEL = LogLevel.Verbose;

      private readonly LogLevel _Level;
      private readonly StreamWriter _Writer;

      private Logger( LogLevel level ) {
         _Writer = new StreamWriter(GetOutputFile());
         _Level = level;
      }

      private static Stream GetOutputFile() {
         string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
         var dir = new DirectoryInfo(Path.GetDirectoryName(exePath));
         string txtPath = Path.Combine(dir.Parent.Parent.Parent.FullName, "output.txt");
         return File.Open(txtPath, FileMode.Create, FileAccess.Write);
      }

      public void Verbose( string text ) {
         if( _Level == LogLevel.Verbose ) {
            Write(text);
         }
      }

      private void Write( string text ) {
         _Writer.WriteLine(text);
         Console.WriteLine(text);
      }

      public void Close() {
         _Writer.Close();
      }

      public static Logger Instance { get; } = new Logger(LOG_LEVEL);
   }
}
