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
        public List<string> FilePaths { get; set; }

        public FileUtil()
        {
        }

        
        /// <summary>
        /// Open dialog to choose mp3 files
        /// </summary>
        /// <returns>True if file(s) is(are) chose</returns>
        public bool ChooseFiles(OpenFileDialog fileDialog)
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

            if (dialogResult == true)
            {
                FilePaths = fileDialog.FileNames.ToList();
                return true;
            }
            return false;
        }
    }
}
