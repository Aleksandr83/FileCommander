using Agl.Helpers;
using FileCommander.Services;

namespace FileCommander;

public static class CommandRegistrator
{        

    public static void Registration()
    {
        var commandManager = BasicServices.GetCommandManagerService();

        if (commandManager == null) return;
                    
        commandManager.CommandRegistration
            (Actions.CreateVirtualStorage, "Create virtual storage",CommandsId.__CREATE_VIRTUAL_STORAGE);
        
        commandManager.CommandRegistration
            (Actions.LoadVirtualStorage,   "Load virtual storage",  CommandsId.__LOAD_VIRTUAL_STORAGE);

        commandManager.CommandRegistration
            (Actions.SaveVirtualStorage,   "Save virtual storage",  CommandsId.__SAVE_VIRTUAL_STORAGE);
        
        commandManager.CommandRegistration
            (Actions.CreateVirtualFile,    "Create virtual file",   CommandsId.__CREATE_VIRTUAL_FILE);
        
        commandManager.CommandRegistration
            (Actions.CreateVirtualFolder,  "Create virtual folder", CommandsId.__CREATE_VIRTUAL_FOLDER);

        
    }


}