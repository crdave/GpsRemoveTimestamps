using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace RemGpsTimes
{
    public partial class Form1 : Form
    {
        string BasePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\RemGpsTimes\";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearLabels();
            lblAction.Text = "Convert gpx to kml and vice versa";
            GetSetGpsbabelExePath("Get");
            ExeFileExists();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            ClearLabels();
            if (ExeFileExists())
            {
                GetSetGpsbabelExePath("Set");
                SetStatusLabel("Working", Color.Blue);
                ProcessFiles();
                SetStatusLabel("Done", Color.Green);     
            }

           
        }

        private void ProcessFiles()
        {
            //for testing
            //lstbxFiles.Items.Add(@"E:\Data\Other\Tracks\North\MtShasta\Test\pig-farm-trail.kml");

            
            for (int i = 0; i < lstbxFiles.Items.Count; i++)
            {
                string[] fileParts = GetFileParts(lstbxFiles.Items[i].ToString());
                switch (GetAction())
                {
                    case "00"://Convert gpx to kml and vice versa
                        ConvertFile(fileParts, false);
                        break;
                    case "01"://Will not do anything

                        break;
                    case "10"://Remove timestamps and Convert gpx to kml and vice versa
                        ConvertFile(fileParts, true);
                        break;
                    case "11"://Remove timestamps, but retain file type (appends _Mod to file name)
                        RemoveTimeHistory(fileParts, "_Mod");
                        break;
                }


            }
        }

        private void ConvertFile(string[] fileParts, bool removeTimes)
        {
            string newExt = "kml";
            if (fileParts[3] == "kml")
            {
                newExt = "gpx";
            }
            string newPath = fileParts[0].Replace(fileParts[1], fileParts[2] + "." + newExt);

            //"E:\Program Files (x86)\GPSBabel\gpsbabel.exe" -i gpx -f "E:\Data\Other\Tracks\North\MtShasta\test\pig-farm-trail_orig - Copy.gpx" -o kml,trackdata=0 -F "E:\Data\Other\Tracks\North\MtShasta\test\cmdlinetest.kml"
            //string cmdLine = "\"" + exePath + "\" -i " + fileParts[3] + " -f \"" + fileParts[0] + "\" -o " + newExt + " -F \"" + newPath + "\"";

            string gpsbabelExe = "\"" + txtGpsBabelExeLoc.Text + "\"";
            string args = " -i " + fileParts[3] + " -f \"" + fileParts[0] + "\" -o " + newExt + " -F \"" + newPath + "\"";

            ProcessStartInfo stInfo = new ProcessStartInfo();
            stInfo.FileName = gpsbabelExe;
            stInfo.Arguments = args;

            try
            {
                using (Process p = Process.Start(stInfo))
                {
                    p.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (removeTimes)
            {
                fileParts = GetFileParts(newPath);
                RemoveTimeHistory(fileParts, "");
            }

        }

        private string[] GetFileParts(string fullPath)
        {
            string[] retArr = { "fullpath", "filename", "filename w/o ext", "ext" };
            retArr[0] = fullPath;
            string[] bsArr = { @"\" };
            string[] pathParts = fullPath.Split(bsArr, StringSplitOptions.None);
            retArr[1] = pathParts[pathParts.Length - 1];//filename with ext
            string[] fileParts = retArr[1].Split('.');
            retArr[2] = fileParts[0].ToLower();
            retArr[3] = fileParts[1].ToLower();
            return retArr;
        }

        private void RemoveTimeHistory(string[] fileParts, string appendToName)
        {
            //E:\Data\Other\Tracks\North\MtShasta\filename.gpx

            //if appendToName == "", then source file is overwritten. Should only happen when also converting to different format
            string newPath = fileParts[0].Replace(fileParts[1], fileParts[2] + appendToName + "." + fileParts[3]);

            if (fileParts[3] == "gpx")
            {
                RemTimeHistory(fileParts[0], newPath, "time");
            }
            else //kml
            {
                RemTimeHistory(fileParts[0], newPath, "TimeSpan");
                RemTimeHistory(newPath, newPath, "TimeStamp");
            }

        }

        private void RemTimeHistory(string source, string dest, string eleName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(source);

            XmlNodeList timeNodes = xDoc.GetElementsByTagName(eleName);
            for (int i = timeNodes.Count - 1; i > -1; i--)
            {
                timeNodes[i].ParentNode.RemoveChild(timeNodes[i]);
            }

            xDoc.Save(dest);
        }

        private void SetStatusLabel(string msg, Color clr)
        {
            lblStatus.Text = msg;
            lblStatus.ForeColor = clr;
            lblStatus.Refresh();
        }

        private void ClearLabels()
        {
            lblError.Text = "";
            lblStatus.Text = "";
        }

        private void lstbxFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void lstbxFiles_DragDrop(object sender, DragEventArgs e)
        {
            lstbxFiles.Items.Clear(); //or add a button to the page to clear items
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                lstbxFiles.Items.Add(file);
        }

        private void SetActionLabel()
        {
            switch (GetAction())
            {
                case "00":
                    lblAction.Text = "Convert gpx to kml and vice versa";
                    break;
                case "01":
                    lblAction.Text = "Will not do anything";
                    break;
                case "10":
                    lblAction.Text = "Remove timestamps and Convert gpx to kml and vice versa";
                    break;
                case "11":
                    lblAction.Text = "Remove timestamps, but retain file type (appends _Mod to file name)";
                    break;
            }

        }

        private string GetAction()
        {
            string retVal = chkbxRemTimeHist.Checked ? "1" : "0";
            retVal += chkbxKeepFileType.Checked ? "1" : "0";
            return retVal;
        }

        private void chkbxRemTimeHist_CheckedChanged(object sender, EventArgs e)
        {
            SetActionLabel();
        }

        private void chkbxKeepFileType_CheckedChanged(object sender, EventArgs e)
        {
            SetActionLabel();
        }

        private void GetSetGpsbabelExePath(string getSet)
        {
            try
            {
                if (!Directory.Exists(BasePath))
                {
                    Directory.CreateDirectory(BasePath);
                }
                string fullPath = BasePath + "GpsbabelExePath.txt";
                if (!File.Exists(fullPath))
                {
                    CreateGpsbabelPathFile(fullPath, @"c:\Program Files (x86)\GPSBabel\gpsbabel.exe"); //set default
                }

                if (getSet == "Get")
                {
                    StreamReader sr = new StreamReader(fullPath);
                    txtGpsBabelExeLoc.Text = sr.ReadLine();
                    sr.Close();
                }
                else
                {
                    CreateGpsbabelPathFile(fullPath, txtGpsBabelExeLoc.Text);
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void CreateGpsbabelPathFile(string filePath, string exeLocation)
        {
            StreamWriter sw = new StreamWriter(filePath);
            sw.Write(exeLocation);
            sw.Close();
        }

        private bool ExeFileExists()
        {
            if (!File.Exists(txtGpsBabelExeLoc.Text))
            {
                lblError.Text = "Above file doesn't exist. Enter full path to 'gpsbabel.exe' in textbox ";
                return false;
            }
            else
            {
                return true;
            }
            
        }


    }//
}
