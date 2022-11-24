using System;
using System.Threading.Tasks;
using Agl.Helpers;
using FileCommander.Views.Dialogs;

namespace FileCommander;

public static class Actions
{
    public static void CreateVirtualStorage(object e)
    {
        var storageService = FileCommanderServices.GetStorageService(); 
        storageService?.CreateNewStorage();
    }

    public static void LoadVirtualStorage(object e)
    {
        var storageService = FileCommanderServices.GetStorageService(); 
        storageService?.LoadDefaultStorage();
    }

    public async static void SaveVirtualStorage(object e)
    {
        var storageService = FileCommanderServices.GetStorageService(); 
        storageService?.SaveDefaultStorage();

        await Task.Delay(1);
    }

    public async static void CreateVirtualFile(object e)
    {
        var storageService = FileCommanderServices.GetStorageService(); 
        dynamic? app = Avalonia.Application.Current?.ApplicationLifetime;
    
        var dlg = new EnterTextDlg() {Title = "CreateFile", Watermark="FileName" };

        dlg.ShowDialog(app?.MainWindow);

        await Task.Run(() => dlg.Wait()); 

        string fileName = dlg.DialogResult;
        if (String.IsNullOrEmpty(fileName)) return;

        storageService?.CreateFile(fileName);
    }

    public async static void CreateVirtualFolder(object e)
    {
        var storageService = FileCommanderServices.GetStorageService(); 
        dynamic? app = Avalonia.Application.Current?.ApplicationLifetime;
    
        var dlg = new EnterTextDlg() {Title = "CreateFolder", Watermark="FolderName" };

        dlg.ShowDialog(app?.MainWindow);
         
        await Task.Run(() => dlg.Wait());

        string folderName = dlg.DialogResult;
        if (String.IsNullOrEmpty(folderName)) return;

        storageService?.CreateFolder(folderName);
    }

}