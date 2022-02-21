using CommanderAPI.Models;
using System.Collections.Generic;

namespace CommanderAPI.Domain.Commander.Abstract
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetCommands();
        Command GetCommandById(int Id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
    }
}
