using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;

namespace LetsProgrammed
{
    public class LetsProgrammed : BaseScript
    {
        List<Entity> AllPlayers = new List<Entity>();
        public LetsProgrammed()
            : base()
        {
            base.PlayerConnected += connected;
            base.PlayerDisconnected += disconnected;
        }

        public void connected(Entity player)
        {
            AllPlayers.Add(player);
            Log.Write(LogLevel.All, "Player " + player.Name.ToString() + "[" + player.GUID.ToString() + "] ist auf dem Server connected!(" + GetPlayerAnzahl() + "/" + Call<int>("getvarint","sv_maxclients") + ")"); 
        }

        public void disconnected(Entity player)
        {
            AllPlayers.Remove(player);
            Log.Write(LogLevel.All, "Player " + player.Name.ToString() + "[" + player.GUID.ToString() + "] ist vom Server gegangen!(" + GetPlayerAnzahl() + "/" + Call<int>("getvarint", "sv_maxclients") + ")"); 
        }
        public int GetPlayerAnzahl()
        {
            int i = 0;
            foreach (Entity player in AllPlayers)
            {
                i = i + 1;
            }
            return i;
        }

    }
}
