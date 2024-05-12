using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RaidLog
{
    public class PlayerParser
    {
        public List<Player> Parse(string filePath)
        {
            // string path = filePath;
            
            List<Player> players = new List<Player>();
            List<string> lines = File.ReadAllLines(filePath).ToList();
            for (int i=1; i<lines.Count; i++)
            {
                string line = lines[i];
                string [] parts = line.Split(",");
                Player player = new Player();
                player.Name = parts[1];
                player.PlayerId = parts[0];
                player.ClanRole = parts[9];
                player.MaxStage = Convert.ToInt32(parts[4]);
                players.Add(player);
            
            }
            return players;
        }
    }

}