using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameMp3.Util
{
    class FileUtil
    {
        private string _filePaths;
        public string FilePaths { get; set; }

        public FileUtil()
        {
        }

        
        /// <summary>
        /// Open dialog to choose mp3 files
        /// </summary>
        /// <returns>The list of paths for selected files</returns>
        public List<string> ChooseFiles(OpenFileDialog fileDialog)
        {
            fileDialog.Filter = "MP3 (*.mp3) | *.mp3";
            fileDialog.DefaultExt = ".mp3";
#if DEBUG
            fileDialog.Filter += "| All (*.*) | *.*";
            fileDialog.DefaultExt = ".*";
#endif
            fileDialog.Multiselect = true;
            fileDialog.ValidateNames = true;
            fileDialog.CheckPathExists = true;

            Nullable<bool> dialogResult = fileDialog.ShowDialog();

            // Choose file only when  the dialog is shown successfully
            if (dialogResult == true)
            {
                List<string> filePaths = fileDialog.FileNames.ToList();
                return filePaths;
            }
            return null;
        }
    }
}
