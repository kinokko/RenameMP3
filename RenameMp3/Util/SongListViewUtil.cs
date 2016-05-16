using RenameMp3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RenameMp3.Util
{
    class SongListViewUtil
    {
        public ListView SongListView { get; set; }

        public SongListViewUtil()
        {
        }

        public SongListViewUtil(ListView songListView)
        {
            SongListView = songListView;
        }

        /// <summary>
        /// Add songs to list view
        /// </summary>
        /// <param name="songPaths"></param>
        /// <returns>True if success</returns>
        public bool AddSongsToListView(List<string> songPaths)
        {
            if (SongListView == null)
            {
                return false;
            }
            else
            {
                foreach(string path in songPaths)
                {
                    using (TagLib.File song = TagLib.File.Create(path))
                    {
                        SongDetail songDetail = new SongDetail();
                        songDetail.Album = song.Tag.Album;
                        songDetail.Artist = "";
                        foreach (string performer in song.Tag.Performers)
                        {
                            if (!string.IsNullOrEmpty(songDetail.Artist))
                            {
                                songDetail.Artist += ", ";
                            }
                            songDetail.Artist += performer;
                        }
                        songDetail.Title = song.Tag.Title;
                        songDetail.TrackNum = song.Tag.Track.ToString();
                        songDetail.FileName = path.Split('\\').Last();
                        songDetail.ContainningFolderPath = path.Substring(0, path.LastIndexOf("\\"));

                        SongListView.Items.Add(songDetail);
                        
                    }
                }
                return true;
            }
        }
        

        public void RemoveDetailFromList(List<SongDetail> songDetails)
        {
            foreach(SongDetail songDetail in songDetails)
            {
                SongListView.Items.Remove(songDetail);
            }
        }
    }
}
