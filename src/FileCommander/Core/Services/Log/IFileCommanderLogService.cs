using FileCommander.Models.FileManagerPanels.VirtualFS;

namespace FileCommander.Services;

public interface IFileCommanderLogService : ILogService
{
    void LogBootRecord(string message, BootRecord bootRecord);
    void LogFileRecord(string message, FileRecord fileRecord);
}