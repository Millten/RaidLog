using System;
using System.Collections.Generic;
using System.Text;

namespace RaidLog
{
    class ConsolePlayerView
    {
        string logo = @"
   ___       _    __  __            
  / _ \___ _(_)__/ / / /  ___  ___ _
 / , _/ _ `/ / _  / / /__/ _ \/ _ `/
/_/|_|\_,_/_/\_,_/ /____/\___/\_, / 
                             /___/  
";
        public void DiplayPlayerView(int entry)
        {
            PlayerParser parser = new PlayerParser();
            List<Player> players = parser.Parse(@"Data\TT2MasterAppExport.csv");

            Console.Clear();
            

            string prompt = logo + @"Player statistics and informations:"+
            @$"

            Player Id: {players[entry].PlayerId} 
                 Name: {players[entry].Name}  
            Max Stage: {players[entry].MaxStage}  
            Clan Role: {players[entry].ClanRole}
            
            ";
;
            string[] options = { "Return to main menu" };
            Menu displayMenu = new Menu(prompt, options);
            int selectedIndex = displayMenu.Run();


            ConsoleView view = new ConsoleView();
            switch (selectedIndex)
            {
                case 0:
                    view.Start();
                    break;
            }


        }

    }
}