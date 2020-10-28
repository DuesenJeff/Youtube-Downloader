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
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace Youtube_Downloader
{
    public partial class Form1 : Form
    {
        public Video video;

        public string currentLink;

        public string selectedFormat;

        public string pythonPath;

        List<Stream> videoList;

        List<Stream> audioList;

        string videoLocation;

        bool isVideo;

        delegate void FFMPEGDelegate(string path);

        public Form1()
        {
            InitializeComponent();
        }

        public void InitializeJSON()
        {
            string jsonString = File.ReadAllText("./scripts/output.json");
            video = JsonSerializer.Deserialize<Video>(jsonString);
        }

        private void RetrieveButton_Click(object sender, EventArgs e)
        {
            currentLink = YoutubeLinkBox.Text;

            this.FormatDropDown.Items.AddRange(new object[] { ".avi", ".flv", ".mov", ".mp4", ".mp3", ".ogg", ".wav", ".webm" });

            ExecutePython();

            InitializeJSON();

            this.FileNameBox.Text = string.Format("{0} - {1}", video.Name, video.Uploader);

            ExtractResolutionAndBitrate();

            progressBar1.Value = 0;
        }

        private void AddDropDownItems()
        {
            this.ResDropDown.Items.Clear();
            if(selectedFormat == ".mp3" || selectedFormat == ".wav" || selectedFormat == ".ogg")
            {
                this.ResolutionLabel.Text = "Bitrate:";
                foreach(Stream s in audioList)
                {
                    isVideo = false;
                    this.ResDropDown.Items.Add(string.Format("{0}@{1}", s.FileFormat, s.Resolution));
                }
            } else
            {
                this.ResolutionLabel.Text = "Resolution:";
                foreach (Stream s in videoList)
                {
                    isVideo = true;
                    this.ResDropDown.Items.Add(string.Format("{0}@{1}", s.FileFormat, s.Resolution));
                }
            }
        }

        private void FormatDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFormat = (string)FormatDropDown.SelectedItem;
            AddDropDownItems();
        }

        private void ExecutePython()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "python";
            info.Arguments = string.Format(@"./scripts/youtube.py ""{0}""", currentLink);
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            info.CreateNoWindow = true;
            Process p = Process.Start(info);
            StreamReader reader = p.StandardError;
            string s = "";

            while (!p.HasExited)
            {
                if(s != reader.ReadLine())
                {
                    LogBox.Text += s;
                }

                s = reader.ReadLine();
            }

            p.WaitForExit();
        }

        private void ExtractResolutionAndBitrate()
        {
            videoList = new List<Stream>();
            audioList = new List<Stream>();

            foreach(Stream s in video.Streams)
            {
                if(s.StreamType == "audio")
                {
                    audioList.Add(s);
                } else if(s.StreamType == "video")
                {
                    videoList.Add(s);
                }
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (isVideo)
            {
                videoLocation = videoList[ResDropDown.SelectedIndex].Link;
            } else
            {
                videoLocation = audioList[ResDropDown.SelectedIndex].Link;
            }

            VideoLocation.FileName = FileNameBox.Text+FormatDropDown.SelectedItem;
            VideoLocation.ShowDialog();
        }

        private void VideoLocation_FileOk(object sender, CancelEventArgs e)
        {
            string path = Path.GetDirectoryName(VideoLocation.FileName);
            DownloadButton.Enabled = false;
            Thread t = new Thread(() => ExecuteFFMPEG(path));
            t.Start();
        }

        private void ResDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DownloadButton.Enabled = true;
        }

        private void ExecuteFFMPEG(string path)
        {
            if (FormatDropDown.InvokeRequired)
            {
                var d = new FFMPEGDelegate(ExecuteFFMPEG);
                FormatDropDown.Invoke(d, new object[] { path });
            }

            if (progressBar1.InvokeRequired)
            {
                var d = new FFMPEGDelegate(ExecuteFFMPEG);
                progressBar1.Invoke(d, new object[] { path });
            }

            if (LogBox.InvokeRequired)
            {
                var d = new FFMPEGDelegate(ExecuteFFMPEG);
                LogBox.Invoke(d, new object[] { path });
            }

            else
            {
                if (isVideo)
                {
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = "./ffmpeg/bin/ffmpeg.exe";
                    info.Arguments = string.Format(@"-i ""{0}"" -y ""{1}""", videoLocation, "vid" + (string)FormatDropDown.SelectedItem);
                    info.UseShellExecute = false;
                    info.RedirectStandardOutput = true;
                    info.RedirectStandardError = true;
                    info.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    info.CreateNoWindow = true;
                    Process p = Process.Start(info);
                    StreamReader reader = p.StandardError;

                    string s = "";

                    while (!p.HasExited)
                    {
                        if(s != reader.ReadLine())
                        {
                            LogBox.Text += s;
                        }

                        s = reader.ReadLine();
                    }
                    
                    p.WaitForExit();

                    progressBar1.Value = 33;

                    ProcessStartInfo info1 = new ProcessStartInfo();
                    info1.FileName = "./ffmpeg/bin/ffmpeg.exe";
                    info1.Arguments = string.Format(@"-i ""{0}"" -y ""{1}""", audioList.Last().Link, "aud.mp3");
                    info1.UseShellExecute = false;
                    info1.RedirectStandardOutput = true;
                    info1.RedirectStandardError = true;
                    info1.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    info1.CreateNoWindow = true;
                    Process p1 = Process.Start(info1);
                    StreamReader reader1 = p1.StandardError;

                    string s1 = "";

                    while (!p1.HasExited)
                    {
                        if(s1 != reader1.ReadLine())
                        {
                            LogBox.Text += s1;
                        }

                        s1 = reader1.ReadLine();
                    }

                    p1.WaitForExit();

                    progressBar1.Value = 67;

                    ProcessStartInfo info2 = new ProcessStartInfo();
                    info2.FileName = "./ffmpeg/bin/ffmpeg.exe";
                    info2.Arguments = string.Format(@"-y -i {0} -i aud.mp3 -c copy ""{1}""", "vid" + (string)FormatDropDown.SelectedItem, VideoLocation.FileName.Replace("\\", "/"));
                    info2.UseShellExecute = false;
                    info2.CreateNoWindow = true;
                    info2.RedirectStandardError = true;
                    Process p2 = Process.Start(info2);
                    StreamReader reader2 = p2.StandardError;

                    string s2 = "";

                    while (!p2.HasExited)
                    {
                        if (s2 != reader2.ReadLine())
                        {
                            LogBox.Text += s2;
                        }

                        s2 = reader2.ReadLine();
                    }
                    p2.WaitForExit();

                    progressBar1.Value = 95;

                    File.Delete("vid" + (string)FormatDropDown.SelectedItem);
                    File.Delete("aud.mp3");

                    progressBar1.Value = 100;
                }
                else
                {
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = "./ffmpeg/bin/ffmpeg.exe";
                    info.Arguments = string.Format(@"-i ""{0}"" -y ""{1}""", videoLocation, VideoLocation.FileName.Replace("\\", "/"));
                    info.UseShellExecute = false;
                    info.CreateNoWindow = true;
                    info.RedirectStandardError = true;
                    info.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    Process p = Process.Start(info);
                    StreamReader reader = p.StandardError;
                    string s = reader.ReadLine();
                    while (!p.HasExited)
                    {
                        if (s != reader.ReadLine())
                        {
                            LogBox.Text += s;
                        }

                        s = reader.ReadLine();
                    }

                    p.WaitForExit();

                    progressBar1.Value = 100;
                }
            }
        }

        private void LogBox_TextChanged(object sender, EventArgs e)
        {
            LogBox.SelectionStart = LogBox.Text.Length;
            LogBox.ScrollToCaret();
        }
    }
}
