using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FlappyBird
{
    class HighScore
    {
        protected string Name { get; set; }
        public int Score { get; set; }
        protected Dictionary<string, int> savedHighScore = new Dictionary<string, int>();
        private string filePath;

        private int TopHighScoreCount = 0;
        private int min;

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
        // Set default file path
        public void setDefaultFilePath()
        {
            filePath = @"C:.\highscore.txt";
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

            for (int i = 0; i < 10; i++)
            {
                foreach (KeyValuePair<string, int> keyVal in savedHighScore.OrderByDescending(key => key.Value))
                {
                    Console.ResetColor();
                    if (scorePrinted == 0)
                    {
                        if (keyVal.Value == 0)
                        {
                            Console.SetCursorPosition(79, x+1);
                            Console.Write("Top 5 highscore not set yet!");
                        }
                        else
                        {
                            Console.SetCursorPosition(79, x + 1);
                            Console.Write("{0}. {1}: ", x - 5, keyVal.Key);
                            Console.SetCursorPosition(100, x + 1);
                            Console.Write(keyVal.Value + " p");
                        }
                    }
                    x++;
                }
                scorePrinted = 1;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(75, 15);
            Console.WriteLine("╚═════════════════════════════════╝");
            Console.ResetColor();
            Console.ReadKey();
        }
        // Load highscore from text file into SavedHighScore dictionary
        public void LoadFile()
        {
            if (File.Exists(filePath))
            {
                if (new FileInfo(filePath).Length == 0)
                {
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
                FileStream fs = File.Create(filePath);
                fs.Close();
                StreamWriter fileWriter = new StreamWriter(filePath);
                fileWriter.WriteLine("No records yet!");
                fileWriter.WriteLine(0);
                fileWriter.Close();
                savedHighScore.Add("No records yet", 0);
            }
        }
        // Save highscore to text file from SavedHighScore dictonary
        public void WriteToFile()
        {
            if ((!File.Exists(filePath)))
            {
                FileStream fs = File.Create(filePath);
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
        // Let the player insert their name if qualified for highscore list
        public void ReadAlias()
        {
            bool nameExists = true;
            while (nameExists)
            {
                try
                {
                    Console.SetCursorPosition(40, 20);
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("  Enter your name to highscore list!  ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(40, 21);
                    Console.Write("                                      "); 
                    Console.SetCursorPosition(42, 21);
                    Name = Console.ReadLine();
                    Console.ResetColor();
                    if (savedHighScore.ContainsKey(Name) || Name == "")
                    {
                        Console.Write("Name already exists or input is empty. Try again.");
                        Console.ReadKey();
                        Console.Write("                                                ");
                    }
                    else
                    {
                        nameExists = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Problem with input. Try again: ");
                }
            }
        }
        // Check if player is qualified for top 5. Different text output depending on place in list
        // Save player to dictionary
        public void CheckTopHighScore()
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


            string scoreExist = @"
                                       SORRY! 
                                SCORE ALREADY TAKEN";

            min = savedHighScore.Min(m => m.Value);
            foreach (KeyValuePair<string, int> keyVal in savedHighScore)
            {
                if (min == keyVal.Value)
                {
                    TopHighScoreCount = keyVal.Value;
                }
            }
            if (Score < TopHighScoreCount)
            {
                Console.WriteLine("\n" + loser);
                Console.SetCursorPosition(45, 19);
                Console.WriteLine(" You didn´t even make it to top 5!");
            }
            else if (savedHighScore.ContainsValue(Score))
            {
                Console.WriteLine(scoreExist);
            }
            else
            {
                if (Score > savedHighScore.Values.Max())
                {
                    Console.SetCursorPosition(24, 1);
                    Console.WriteLine(" ****************** CONGRATULATIONS ********************");
                    Console.WriteLine(winner);

                    Console.SetCursorPosition(26, 12);
                    Console.WriteLine(" ****************** TOP SCORE ********************");
                    foreach (KeyValuePair<string, int> keyVal in savedHighScore.OrderBy(key => key.Value))
                    {
                        if (Score > keyVal.Value && savedHighScore.Count() >=5 || keyVal.Value == 0)
                        {
                            savedHighScore.Remove(keyVal.Key);
                        }
                    }
                }
                else
                {
                    Console.WriteLine(middleScore);
                    foreach (KeyValuePair<string, int> keyVal in savedHighScore.OrderBy(key => key.Value))
                    {
                        if (Score > keyVal.Value && savedHighScore.Count() >= 5 || keyVal.Value == 0)
                        {
                            savedHighScore.Remove(keyVal.Key);
                        }
                    }
                }
                ReadAlias();
                savedHighScore.Add(Name, Score);
                Score = 0;
            }
            Console.ReadKey();
        }
    }
}