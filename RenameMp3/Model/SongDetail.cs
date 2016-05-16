using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameMp3.Model
{
    class SongDetail
    {
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string TrackNum { get; set; }
        public string FileName { get; set; }
        public string NewName { get; set; }
        public string ContainningFolderPath { get; set; }
    }
}
