using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Youtube_Downloader
{
    public partial class Form1 : Form
    {
        public Video video;

        public Form1()
        {
            InitializeComponent();
            InitializeJSON();
        }

        public void InitializeJSON()
        {
            string jsonString = File.ReadAllText("./scripts/output.json");
            video = JsonSerializer.Deserialize<Video>(jsonString);
        }
    }
}
