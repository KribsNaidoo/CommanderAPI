using CommanderAPI.Domain.Commander.Abstract;
using CommanderAPI.Models;
using System.Collections.Generic;

namespace CommanderAPI.Domain.Commander
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetCommands()
        {
            Command[] commandsArray = 
            {
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pot" },
                new Command { Id = 0, HowTo = "Toast bread", Line = "Turn on toaster", Platform = "Toaster" },
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pot" }
            };

            var commands = new List<Command>(commandsArray);

            return commands;
        }

        public Command GetCommandById(int Id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pot" };
        }
    }
}
