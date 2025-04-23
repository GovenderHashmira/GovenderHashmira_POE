using System;
using System.Media;
using System.Threading;

namespace CybersecurityChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayVoiceGreeting();
            DisplayAsciiArt();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nWhat is your name? ");
            string name = Console.ReadLine();
            Console.ResetColor();

            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Guest";
                Console.WriteLine("No name entered. I'll call you Guest.");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nNice to meet you, {name}!");
            Console.ResetColor();

            DisplayMenu();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nAsk me something: ");
            string question = Console.ReadLine().ToLower();
            Console.ResetColor();

            RespondToQuestion(question);

            TypeText("\nThank you for chatting! Stay safe online, " + name + "!", 40);
        }

        static void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "greeting.wav");
                player.PlaySync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Voice greeting could not be played: " + ex.Message);
            }
        }

        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
__        __   _                                   
\ \      / /__| | ___ ___  _ __ ___   ___   
 \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ 
  \ V  V /  __/ | (_| (_) | | | | | |  __/ 
   \_/\_/ \___|_|\___\___/|_| |_| |_|\___|  
                                                    
");
            Console.ResetColor();
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nYou can ask me things like:");
            Console.WriteLine("- DDOS Attack?");
            Console.WriteLine("- Firewall?");
            Console.WriteLine("- Ransomware?");
            Console.WriteLine("- Password safety?");
            Console.WriteLine("- Phishing?");
            Console.WriteLine("- Safe browsing?");
        }

        static void RespondToQuestion(string question)
        {
            switch (question)
            {
                case "ddos attack?":
                    TypeText("A DDoS attack floods a website or service with too much traffic, causing it to crash or slow down.", 35);
                    break;
                case "firewall?":
                    TypeText("A firewall is a security system that monitors and controls incoming and outgoing network traffic.", 35);
                    break;
                case "ransomware?":
                    TypeText("Ransomware is malicious software that locks your files until you pay a ransom. Always back up your data!", 35);
                    break;
                case "password safety?":
                    TypeText("Use strong, unique passwords and a trusted password manager.", 35);
                    break;
                case "phishing?":
                    TypeText("Avoid suspicious links and always verify the sender of emails.", 35);
                    break;
                case "safe browsing?":
                    TypeText("Keep your browser updated, use antivirus, and avoid shady websites.", 35);
                    break;
                default:
                    TypeText("I didn't quite understand that. Could you rephrase?", 35);
                    break;
            }
        }

        static void TypeText(string text, int delay = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }
    }
}

