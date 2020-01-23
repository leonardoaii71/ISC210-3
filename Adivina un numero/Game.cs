using System;
using System.IO;
using System.Text;


namespace ISC210_3
{

    public class Game
    {
        public enum eGameState
        {
            Starting,
            Playing,
            Over
        }

        public enum AttemptResult
        {
            Guessed,
            Lower,
            Greater
        }
        const int MIN = 1, MAX = 1000;
        const string DEFALUTPATH = "score.txt";
        public int SecretNumber { get; set; }
        public eGameState CurrentState { get; set; }
        public int lastTry;
        public int Attempts { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ScorePath { get; set; }
        public TimeSpan TimeSpent{
            get
            {   
                return EndTime.Subtract(StartTime);
            }
        }
    
        public void GameInit(){
            SecretNumber = GenerateNumber(MIN, MAX);
            CurrentState = eGameState.Starting;
            Attempts = 0;
            //TimeSpan tmp = new TimeSpan();
            StartTime = DateTime.Now;
            ScorePath = DEFALUTPATH;
        }
        
        private int GenerateNumber(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
        public AttemptResult CheckIfGuessed()
        {
            Attempts++;
            if (lastTry == SecretNumber){
                return AttemptResult.Guessed;
            }
            else if (lastTry > SecretNumber)
            {
                return AttemptResult.Greater;
            }
            else 
            {
                return AttemptResult.Lower;
            }
        }

        public void SaveState(){
            /*using (FileStream fstream = File.Open(ScorePath, FileMode.Append))
            {
                UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
                var buffer = unicodeEncoding.GetBytes($"Tiempo: {TimeSpent.TotalSeconds} - Intentos: {Attempts}");
                fstream.Write(buffer, 0, buffer.Length);

            }
            */
            using(StreamWriter strm = File.AppendText(ScorePath)){
               strm.Write($"Tiempo: {TimeSpent.TotalSeconds} - Intentos: {Attempts}");
            }
        }
    }
}