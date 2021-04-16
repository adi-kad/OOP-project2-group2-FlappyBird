using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace FlappyBird
{
    class HighScore
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public Dictionary<string, int> SavedHighScore { get; set; }

        public HighScore()
        {
        }
        public HighScore(string name, int score, Dictionary<string, int> savedHighScore)
        {
            Name = name;
            Score = score;
            SavedHighScore = savedHighScore;
        }
        public void SaveHighScore()
        {

        }
        // Load highscore from file
        public void LoadHighScoreXml()
        {
   
        }
        // Save highscore to file
        public void WriteHighScoreXml()
        {
            XmlSerializer xmlSerialiser = new XmlSerializer(typeof(Dictionary<string, int>));
            TextWriter FileStream = new StreamWriter(@"D:.\HighScore.xml");
            xmlSerialiser.Serialize(FileStream, SavedHighScore);
            FileStream.Close();
        }
    }
}
