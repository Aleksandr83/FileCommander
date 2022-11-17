namespace Types.Generic
{
    public class Command<TCommand>
    {
        string      _CommandName = "";
        TCommand    _Command;

        public string CommandName => _CommandName;        

        public Command(TCommand command, string commandName)
        {
            _Command     = command;
            _CommandName = commandName;
        }

    }
}