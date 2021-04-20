using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FlappyBird
{
    class HighScore 
    {
        protected string Name { get; set; }
        public int Score { get; set; }
        protected Dictionary<string, int> savedHighScore = new Dictionary<string, int>();
        private string filePath;
        bool fileExist = true;
        private int TopHighScoreCount => 10;
        public HighScore()
        {
            Score = 0;
            setDefaultFilePath();
        }
        public HighScore(string name)
        {
            Name = name;
            Score = 0;
            setDefaultFilePath();
        }
        public string FilePath
        {
            get { return filePath; }
            set { filePath =value; }
        }
        // Set default file path
        
        public void setDefaultFilePath()
        {
            //https://stackoverflow.com/questions/12335618/file-path-for-project-files
            string fileName = "hightscore.txt";
            string path = Path.Combine(Environment.CurrentDirectory,
            @"OOP-project2-group2-FlappyBird\", fileName);

            //filePath = @"D:\Users\ulrika\Programming\hightscore.txt";
        }
        // Update highscore
        public void Update(Obstacle[] obstacles, Bird bird, int i)
        {
            if (obstacles[i].xpos == bird.X - 4)
            {
                Score++;
            }
        }
        // Print highscore in menu option
        public void PrintHighScore()
        {
            int x = 6;
            int scorePrinted = 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(77, 3);
            Console.WriteLine("******  TOP 5 HIGHSCORE  ******");
            Console.SetCursorPosition(75, 5);
            Console.WriteLine("╔═════════════════════════════════╗");

            for (int i = 0; i < 5; i++)
            {
                foreach (KeyValuePair<string, int> kvp in savedHighScore)
                {
                    Console.SetCursorPosition(75, x);
                    Console.Write("║");
                    Console.ResetColor();
                    if (scorePrinted == 0)
                    {
                        Console.Write("    {0}. {1}:   {2} p", x - 5, kvp.Key, kvp.Value);
                    }
                    Console.SetCursorPosition(109, x);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("║");
                    x++;
                }
                scorePrinted = 1;
            }


            //Console.SetCursorPosition(80, x);
            //Console.WriteLine("No records of top 5 yet!");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(75, 15);
            Console.WriteLine("╚═════════════════════════════════╝");
            Console.ReadKey();
        }
        // Load highscore from text file into SavedHighScore dictionary
        public void LoadFile()
        {
            if (File.Exists(filePath))
            {
                if (new FileInfo(fileName).Length == 0)
                {
                    StreamWriter fileWriter = new StreamWriter(filePath);
                    fileWriter.WriteLine("Name");
                    fileWriter.WriteLine("Score");
                    savedHighScore.Add("No records yet", 0);
                }
                else
                {
                    string[] arrFromFile = File.ReadAllLines(filePath);
                    for (int i = 0; i < arrFromFile.Length; i += 2)
                    {
                        savedHighScore.Add(arrFromFile[i], int.Parse(arrFromFile[i + 1]));
                    }              
                }             
            }
            else
            {
                FileStream fs = File.Create("highscore.txt");
                fs.Close();
                return false;
            }
        }
        // Save highscore to text file from SavedHighScore dictonary
        public void WriteToFile()
        {
            if ((!File.Exists("highscore.txt")))
            {
                FileStream fs = File.Create("highscore.txt");
                fs.Close();
                WriteToFile();
            }
            else
            {
                StreamWriter fileWriter = new StreamWriter(filePath);
                foreach (KeyValuePair<string, int> keyVal in savedHighScore)
                {
                    fileWriter.WriteLine(keyVal.Key);
                    fileWriter.WriteLine(keyVal.Value);
                }
                fileWriter.Close();
            }
        }
        public void CheckTopHighScore()
        {
            if (Score <= TopHighScoreCount)
            {
                if (savedHighScore.ContainsValue(Score))
                {
                    Console.WriteLine("Sorry for you :( You didn´t make it to the top 5");
                }
                else
                {
                    foreach (KeyValuePair<string, int> keyVal in savedHighScore)
                    {
                        if (Score > keyVal.Value)
                        {
                            savedHighScore.Remove(keyVal.Key);
                            savedHighScore.Add(Name, Score);
                        }
                    }
                }              
            }
        }
        public static void CheckTopHighScore(string Name, int Score, int TopHighScoreCount, Dictionary<string, int> savedHighScore)
        {
            string loser = @"
                             _
                            | |
                            | | ___  ___ ___ _ ____
                            | |/ _ \/ __ |/ _ \ '__|
                            | | (_) \__  \  __/ |
                            |_|\___ /|___/\___|_|
                                                    ";
            string winner = @"
                  
                           ░██╗░░░░░░░██╗██╗███╗░░██╗███╗░░██╗███████╗██████╗░
                           ░██║░░██╗░░██║██║████╗░██║████╗░██║██╔════╝██╔══██╗
                           ░╚██╗████╗██╔╝██║██╔██╗██║██╔██╗██║█████╗░░██████╔╝
                           ░░████╔═████║░██║██║╚████║██║╚████║██╔══╝░░██╔══██╗
                           ░░╚██╔╝░╚██╔╝░██║██║░╚███║██║░╚███║███████╗██║░░██║
                           ░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚══╝╚══════╝╚═╝░░╚═╝
                                                                                ";
            string middleScore = @"
                                   
                                █▀▀ █▀█ █▀▀ ▄▀█ ▀█▀ █   ▀█▀ █▀█ █▀█   █▀ █
                                █▄█ █▀▄ ██▄ █▀█ ░█░ ▄   ░█░ █▄█ █▀▀   ▄█ ▄
                                                                                 ";


            if (Score < TopHighScoreCount || savedHighScore.ContainsValue(Score))
            {
 
                Console.WriteLine("\n" + loser);
                Console.SetCursorPosition(45, 6);
                Console.WriteLine(" You didn´t even make it to top 5!");
            }

            else if (Score > savedHighScore.Values.Max())
            {
                Console.SetCursorPosition(24, 1);
                Console.WriteLine(" ****************** CONGRATULATIONS ********************");
                Console.WriteLine(winner);
                Console.SetCursorPosition(26,12);
                Console.WriteLine(" ****************** TOP SCORE ********************");
                savedHighScore.Add(Name, Score);
            }
            else
            {
                foreach (KeyValuePair<string, int> keyVal in savedHighScore.OrderBy(key => key.Value))
                {
                    if (Score > keyVal.Value)
                    {
                        savedHighScore.Remove(keyVal.Key);
                        savedHighScore.Add(Name, Score);
                    }
                }
                Console.WriteLine(middleScore);
            }
        }
    }
}
