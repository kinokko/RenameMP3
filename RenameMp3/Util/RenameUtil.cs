using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using RenameMp3.Util;
using RenameMp3.Model;
using System.IO;

namespace RenameMp3.Util
{
    class RenameUtil
    {
        public RenameUtil()
        {
        }

        public void SetDefaultRenameRule(TextBox textBox)
        {
            textBox.Text = @"%Artist% - %Title%";
        }

        /// <summary>
        /// Action to rename files according to the rule
        /// </summary>
        /// <param name="songDetails"></param>
        /// <param name="rule"></param>
        /// <returns>Succeed items</returns>
        public List<SongDetail> RenameAction(ItemCollection songDetails, string rule)
        {
            List<SongDetail> succeedSongDetailList = new List<SongDetail>();

            foreach(SongDetail songDetail in songDetails)
            {
                // Todo: generate newName with reflection
                songDetail.NewName = songDetail.Artist + " - " + songDetail.Title + ".mp3";
                bool result = rename(songDetail);
                if (result == true)
                {
                    succeedSongDetailList.Add(songDetail);
                }
            }

            return succeedSongDetailList;
        }

        /// <summary>
        /// Rename file by given ListViewItem
        /// </summary>
        /// <param name="songDetail"></param>
        /// <returns>True if succeed</returns>
        private bool rename(SongDetail songDetail)
        {
            string oldPath = getOldPath(songDetail);
            string newPath = getNewPath(songDetail);

            if (string.Equals(oldPath, newPath))
            {
                return true;
            }

            if (!File.Exists(oldPath) || File.Exists(newPath) || newPath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                return false;
            }
            File.Move(getOldPath(songDetail), getNewPath(songDetail));
            return true;
        }

        private string getOldPath(SongDetail songDetail)
        {
            return songDetail.ContainningFolderPath + "\\" + songDetail.FileName;
        }

        private string getNewPath(SongDetail songDetail)
        {
            return songDetail.ContainningFolderPath + "\\" + songDetail.NewName;
        }
    }
}
