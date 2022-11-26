using Agl.Helpers;
using FileCommander.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.ViewModels.Controls.FileManagerPanels.FS
{
    public class FsViewModel : ViewModelBase
    {
        const string __UPDATE_STORAGE_PATH_EVENT = EventNames.__UPDATE_STORAGE_PATH_EVENT;

        public FsViewModel()
        {

        }

        void OnUpdatePath(object sender, EventArgs e)
        {
            Path = StorageService?.GetCurrentPath().ToString() ?? string.Empty;
        }

        #region Properties

        public string Path
        {
            get { return _Path ?? string.Empty; }
            set
            {
                _Path = value;
                OnPropertyChanged("Path");
            }
        }

        IVirtualStorageService? StorageService
        {
            get
            {
                if (_StorageService == null)
                    _StorageService = FileCommanderServices.GetStorageService();
                return _StorageService;
            }
        }

        #endregion Properties


        private string? _Path;

        private IEventManagerService? _EventManager;
        private IVirtualStorageService? _StorageService;

    }
}
