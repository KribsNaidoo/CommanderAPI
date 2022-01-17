using CommanderAPI.Models;
using System.Collections.Generic;

namespace CommanderAPI.Domain.Commander.Abstract
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetCommands();
        Command GetCommandById(int Id);
    }
}
