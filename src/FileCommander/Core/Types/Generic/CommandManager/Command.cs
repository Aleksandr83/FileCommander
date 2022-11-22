namespace Types.Generic;

public class Command<TCommand>
{
    public Command(TCommand command, string commandName)
    {
        _Command     = command;
        _CommandName = commandName;
    }

    public string CommandName => _CommandName;

    private string   _CommandName = "";
    private TCommand _Command;

}