using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using alg.Services;
using ReactiveUI;

namespace FileCommander.Services
{
     public class CommandManagerService : ICommandManagerService
     {
          Dictionary<string, CommandInfo> _Commands = new Dictionary<string, CommandInfo>();

          public CommandManagerService()
          {
               
          }

          public string CommandRegistration(Action<object> action, string description="", string commandId = "") 
          {              
               CommandInfo cmd = new CommandInfo();   
               //commandId       = cmd._CommandId;     

               cmd._Command    = ReactiveCommand.Create(action); 
               if (!string.IsNullOrEmpty(commandId)) 
                    cmd._CommandId = commandId;
               cmd._Description = description;

               _Commands.Add(cmd._CommandId, cmd);

               return cmd._CommandId;
          }

          public void ExecuteCommandById(string commandId, object? parameter = null)
          {
               if (string.IsNullOrEmpty(commandId)) return;

               if (_Commands.ContainsKey(commandId))
               {
                    var cmd = _Commands[commandId];

                    if (cmd._Command?.CanExecute(parameter)??false)
                        cmd._Command.Execute(parameter);
               }
          }

     }
}