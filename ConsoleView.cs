using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RaidLog
{
    internal class ConsoleView
    {

        string logo = @"
   ___       _    __  __            
  / _ \___ _(_)__/ / / /  ___  ___ _
 / , _/ _ `/ / _  / / /__/ _ \/ _ `/
/_/|_|\_,_/_/\_,_/ /____/\___/\_, / 
                             /___/  
";

        public void Start()
        {
            Console.Title = "Raid Log";
            RunMainMenu();

        }

        private void RunMainMenu()
        {

            string prompt = logo + @"Welcome to the Raid Log. What would you like to do?
(Use the arrow keys to cycle through options and press enter to select an option.)

";
            string[] options = { "Choose player", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    ChoosePlayer();
                    break;
                case 1:
                    DisplayAbout();
                    break;
                case 2:
                    ExitLog();
                    break;

            }

        }

        private void ExitLog()
        {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
        private void DisplayAbout()
        {

            Console.Clear();
            string prompt = logo + @"
This program was created by Artemiusz Urbanik as a homework for 'Programowanie Obiektowe' class at WSB University to be hopefully developed to functional program that allow to track players raid performance in TapTitans2 mobile game.
ASCII art created using assets from: http://patorjk.com/software/taag/
";
            string[] options = { "Return to main menu" };
            Menu displayMenu = new Menu(prompt, options);
            int selectedIndex = displayMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunMainMenu();
                    break;
            }



        }
        private void ChoosePlayer()
        {
            Console.Clear();
            string prompt = logo + "Select player to display statistics";


            PlayerParser parser = new PlayerParser();
            List<Player> players = parser.Parse(@"Data\TT2MasterAppExport.csv");
            string[] options = {
                players[0].Name,
                players[1].Name,
                players[2].Name,
                players[3].Name,
                players[4].Name,
                "Return to main menu"
            };

            Menu playerMenu = new Menu(prompt, options);
            int selectedIndex = playerMenu.Run();

            ConsolePlayerView dP = new ConsolePlayerView();


            switch (selectedIndex)
            {
                case 0:
                    dP.DiplayPlayerView(0);
                    break;
                case 1:
                    dP.DiplayPlayerView(1);
                    break;
                case 2:
                    dP.DiplayPlayerView(2);
                    break;
                case 3:
                    dP.DiplayPlayerView(3);
                    break;
                case 4:
                    dP.DiplayPlayerView(4);
                    break;
                case 5:
                    RunMainMenu();
                    break;
            }


            ExitLog();
        }


    }
}