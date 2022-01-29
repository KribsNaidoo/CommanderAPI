using CommanderAPI.Domain.Commander.Abstract;
using CommanderAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace CommanderAPI.Domain.Commander
{
    public class CommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _commanderContext;

        public CommanderRepo(CommanderContext commanderContext)
        {
            _commanderContext = commanderContext;
        }

        public IEnumerable<Command> GetCommands()
        {
            return _commanderContext.Commands.ToList();
        }
        public Command GetCommandById(int Id)
        {
            return _commanderContext.Commands.FirstOrDefault(c => c.Id == Id);
        }
    }
}
