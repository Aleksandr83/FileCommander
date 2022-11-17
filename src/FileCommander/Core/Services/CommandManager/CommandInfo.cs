using System;
using System.Windows.Input;

namespace FileCommander.Services
{
    public class CommandInfo
    {
        internal string          _CommandId;
        internal string          _Description;
        internal ICommand        _Command;
        internal string          _Gesture;       
        internal CommandFilter   _CommandFilter; 


        public CommandInfo()
        {
            _CommandId = Guid.NewGuid().ToString();
        }    

        public bool IsSetFilter()
        {
            return false;
        }

    }
}