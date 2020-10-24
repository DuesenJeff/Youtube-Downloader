using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube_Downloader
{
    public class Video
    {
        public string Name { get; set; }
        public string Uploader { get; set; }
        public string Duration { get; set; }
        public int Length { get; set; }
        public Stream[] Streams { get; set; }

    }
}
