using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaMissenseViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = FileString.OpenAs("Select the score matrix file", "*.tsv|*.tsv");
            if (System.IO.File.Exists(fileName) == false) { return; }


            System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
            long size = fi.Length;

            System.IO.StreamReader fs = null;
            fs = new System.IO.StreamReader(fileName);

            int headerLength =-1;
            int lineLength = -1;
            int counter = 1;
            bool hasslashN = false;
            bool hasSlashR = false;
            char lastC = '\0';
            while (fs.Peek() > 0 && headerLength ==-1)
            {
                char c = (char)fs.Read();

                if ((lastC == '\r' || lastC == '\n') && c != '#')
                { headerLength = counter; }
                else if (c == '\n') 
                { hasslashN = true; }
                else if (c == '\r') 
                { hasSlashR = true; }
                lastC = c;
                counter++;
                System.Diagnostics.Debug.Write(c);
            }
           

            headerLength--;

            System.Diagnostics.Debug.WriteLine("Has n " + hasslashN.ToString());
            System.Diagnostics.Debug.WriteLine("Has r " + hasSlashR.ToString());
            System.Diagnostics.Debug.WriteLine("Header len " + headerLength.ToString());
            System.Diagnostics.Debug.WriteLine("Line len " + lineLength.ToString());

            fs.Close();
             

            System.IO.FileStream sf = new System.IO.FileStream(fileName,System.IO.FileMode.Open);
            long top = fi.Length;
            long bottom = headerLength;
            string chr = "chr13";
            string place = "40665648";
            long position = (fi.Length - headerLength)/2;
            string data = newLine(sf, position, fi.Length, headerLength);
            long lastPosition = -1;
            while (true)
            {
                string[] items = data.Split('\t');
                long diff = items[0].CompareTo(chr);
                if (diff == 0)
                {
                    diff = Convert.ToInt64(items[1]) - Convert.ToInt64(place);
                }

                if (diff ==0)
                { break; }
                else if (diff < 0)
                {
                    bottom = position;
                    long i = top - bottom;
                    position += (top - bottom) / 2;
                    data = newLine(sf, position, fi.Length, headerLength);

                }
                else if (diff>0)
                {
                    top = position;
                    position -= (top - bottom) / 2;
                    data = newLine(sf, position, fi.Length, headerLength);
                }
                System.Diagnostics.Debug.WriteLine(data + "\t" + top + "\t" + bottom + "\t" + position);
                if (lastPosition==position)
                { break; }
                lastPosition = position;
            }
                        

                sf.Close();

            if (true==true)
            { }

            

        }

        private string newLine(System.IO.FileStream sf, long position, long filelength, int headerlength)
        {
            int arrayLength = 300;
            if (arrayLength + position > filelength)
            { arrayLength = (int)(filelength - position); }
            if (position < headerlength)
            { position = headerlength; }

            byte[] line = new byte[arrayLength];
            sf.Position = position;
            sf.Read(line, 0, line.Length);
            bool newline = false;
            string data = "";
            for (int index = 0; index < line.Length; index++)
            {
                if (line[index] == 10 && newline == false)
                { newline = true; }
                else if (line[index] == 10 && newline == true)
                { break; }
                else if (newline == true)
                { data += ((char)line[index]).ToString(); }
            }
            return data;
        }

        private void btnIndex_Click(object sender, EventArgs e)
        {
            string fileName = FileString.OpenAs("Select the score matrix file", "*.tsv|*.tsv");
            if (System.IO.File.Exists(fileName) == false) { return; }

            Dictionary<string, long> firstUniprot = new Dictionary<string, long>();
            Dictionary<string, long> firstTranscript = new Dictionary<string, long>();
            Dictionary<string, long> lastUniprot = new Dictionary<string, long>();
            Dictionary<string, long> lastTranscript = new Dictionary<string, long>();
            long counter = 0;
            System.IO.StreamReader fs = null;
            try 
            {
                fs = new System.IO.StreamReader(fileName);
                string[] items = null;
                while (fs.Peek() > 0)
                {
                    string line = fs.ReadLine();
                    items = line.Split('\t');
                    if (items[0].StartsWith("#") == false)
                    {
                        if (firstUniprot.ContainsKey(items[5]) == false)
                        {
                            firstUniprot.Add(items[5], counter - 10);
                            lastUniprot.Add(items[5], counter - 10);
                        }
                        else
                        {
                            lastUniprot[items[5]] = counter - 10;
                        }

                        if (firstTranscript.ContainsKey(items[6]) == false)
                        {
                            firstTranscript.Add(items[6], counter - 10);
                            lastTranscript.Add(items[6], counter - 10);
                        }
                        else
                        {
                            lastTranscript[items[6]] = counter - 10;
                        }
                    }
                    counter += line.Length + 1;
                }
            
            }
            finally{ if (fs != null) { fs.Close(); } }

            System.IO.StreamWriter fw = null;
            try
            {
                string indexFile = fileName.Substring(0, fileName.LastIndexOf(".")) + ".index";
                fw = new System.IO.StreamWriter(indexFile);

                foreach (string key in firstUniprot.Keys)
                { fw.WriteLine(key + "\t" + firstUniprot[key] + "\t" + lastUniprot[key]); }
                foreach (string key in firstTranscript.Keys)
                { fw.WriteLine(key + "\t" + firstTranscript[key] + "\t" + lastTranscript[key]); }

            }
            finally { if (fw != null) { fw.Close(); } }
        
        }
    }
}
