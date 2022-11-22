using System.Collections.Generic;
using Types.Generic;

namespace Types.Generic;

public class CommandManager<TCommand>
{
    public CommandManager()
    {

    }

    public void Registration(TCommand command, string commandName)
    {
        if (IsContain(commandName)) return;

        var registredCommand = new Command<TCommand>(command, commandName);
        _Commands.Add(registredCommand);
    }

    public bool IsContain(string commandName)
    {
        if (_Commands.Count == 0 || string.IsNullOrEmpty(commandName))
            return false;

        foreach (var command in _Commands)
        {
            if (command.CommandName == commandName)
            return true;
        }

        return false;
    }

    private List<Command<TCommand>> _Commands = new();

}