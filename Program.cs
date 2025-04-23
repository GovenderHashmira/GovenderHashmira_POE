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
                //SoundPlayer player = new SoundPlayer("greeting.wav");
                SoundPlayer player = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "greeting.wav");
                player.PlaySync(); // Plays the WAV and waits until it finishes
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
  _____                      _                         _       
 / ____|                    | |                       | |      
| |     ___  _ __ ___  _ __ | ___  ___ ___  _ __   ___| |_ ___ 
| |    / _ \| '_ ` _ \| '_ \|/ _ \/ __/ _ \| '_ \ / _ \ __/ _ \
| |___| (_) | | | | | | |_) |  __/ (_| (_) | | | |  __/ ||  __/
 \_____\___/|_| |_| |_| .__/ \___|\___\___/|_| |_|\___|\__\___|
                     | |                                       
                     |_|                                       
");
            Console.ResetColor();
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nYou can ask me things like:");
            Console.WriteLine("- How are you?");
            Console.WriteLine("- What's your purpose?");
            Console.WriteLine("- What can I ask you about?");
            Console.WriteLine("- Password safety?");
            Console.WriteLine("- Phishing?");
            Console.WriteLine("- Safe browsing?");
        }

        static void RespondToQuestion(string question)
        {
            switch (question)
            {
                case "how are you?":
                    TypeText("I'm functioning well, thanks for asking!", 35);
                    break;
                case "what's your purpose?":
                    TypeText("I'm here to help you stay safe online.", 35);
                    break;
                case "what can i ask you about?":
                    TypeText("You can ask about password safety, phishing, and safe browsing.", 35);
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
            //test commit 2.1
            //testing workflow
        }
    }
}
