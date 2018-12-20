using Smod2;
using Smod2.Commands;
using System;
using System.Collections.Generic;

namespace ExamplePlugin
{
    class SaveDataCommand : ICommandHandler
    {
        private Plugin plugin;
        public SaveDataCommand(Plugin plugin)
        {
            this.plugin = plugin;
        }

        public string GetCommandDescription()
        {
            // This prints when someone types HELP HELLO
            return "Save game info";
        }

        public string GetUsage()
        {
            // This prints when someone types HELP HELLO
            return "Write save";
        }

        public string[] OnCall(ICommandSender sender, string[] args)
        {
            List<string> comandRes = new List<string>();
            comandRes.Add("Command called");

            string fName = args[0].Equals("") ? "output.txt" : args[0];
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fName)) {
                //Player num
                int plCount = plugin.Server.NumPlayers;
                file.WriteLine("Player: " + plCount);
                //Num round


                //Plugins
                file.WriteLine("List Of Pluggins:");
                plugin.pluginManager.Plugins.ForEach(e => { file.WriteLine(e.Details.name); });
                //Time
                int totalSeconds=plugin.Round.Duration;//к сожаление не могу написать код считающий время сервера точно так же как и е его номер
                int hours = totalSeconds / 3600;
                int min = totalSeconds / 60;
                int sec = totalSeconds % 60;
                string totalTime = hours + ":" + min + ":" + sec;
                file.WriteLine("Uptime:" + totalTime);
            }
            
            return new string[] { "Game succesfull saved!"};
        }
    }
}