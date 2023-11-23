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
        private string fileName = "";
        private int headerLength = -1;
        Dictionary<string, PointF> starts = new Dictionary<string, PointF>();

        public Form1()
        {
            InitializeComponent();
            cboBase.SelectedIndex = 0;
            cboChromosome.SelectedIndex = 0;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            if (cboChromosome.SelectedIndex == 0 || cboBase.SelectedIndex == 0)
            { MessageBox.Show("Please select a chromosome and Alt base"); return; }
            int place = -1;
            try
            {
                place = Convert.ToInt32(txtPlace.Text.Trim().Replace(",", ""));
                if (place <0 || place > 250000000)
                { throw new Exception("Number out of range"); }
            }
            catch { MessageBox.Show("Please enter a interger number for the chromosomal location"); return; }            

            FindLocation(fileName, place.ToString(), cboBase.Text.ToUpper(), cboChromosome.Text.ToLower()); ;
        }

        private void FindLocation(string fileName, string place, string altBase, string chromosome)
        {
            System.IO.FileStream sf = null;
            string data = "";
            try
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                long size = fi.Length;                
                sf = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                long top = fi.Length;
                long bottom = headerLength;
                string chr = chromosome;
                long position = (fi.Length - headerLength) / 2;
                data = newLine(sf, position, fi.Length, headerLength);
                long lastPosition = -1;
                while (true)
                {
                    string[] items = data.Split('\t');
                    long diff = items[0].CompareTo(chr);
                    if (diff == 0)
                    {
                        diff = Convert.ToInt64(items[1]) - Convert.ToInt64(place);
                        if (diff == 0)
                        {
                            data = GetMatch(sf, position, chromosome, place, altBase, items, fi.Length, headerLength);
                            break;
                        }
                    }

                    if (diff == 0)
                    { break; }
                    else if (diff < 0)
                    {
                        bottom = position;
                        long i = top - bottom;
                        position += (top - bottom) / 2;
                        data = newLine(sf, position, fi.Length, headerLength);

                    }
                    else if (diff > 0)
                    {
                        top = position;
                        position -= (top - bottom) / 2;
                        data = newLine(sf, position, fi.Length, headerLength);
                    }
                    System.Diagnostics.Debug.WriteLine(data + "\t" + top + "\t" + bottom + "\t" + position);
                    if (lastPosition == position)
                    {
                        sf.Close();
                        txtAnswer.Text = "Couldn't fine the position. Nearest line:\r\n" + data;
                        return;
                    }
                    lastPosition = position;
                }
            }
            catch { MessageBox.Show("Couldn't open file"); }
            finally { if (sf != null) { sf.Close(); } }
            txtAnswer.Text ="Best matc\rh\n" + data;
        }

        private string GetMatch(System.IO.FileStream sf, long position, string chromosome, string place, string altBase, string[] items, long filelength, int headerlength)
        {
            string answer = "";

            position -= 300;
            if (position < headerLength)
            { position = headerLength; }

            long positionStart = position;
            string line = "";

            while (position - positionStart < 600 && position < filelength)
            {
                line = newLine(sf, position, filelength, headerlength);
                string[] bits = line.Split('\t');

                if (items[0].ToLower() == chromosome && bits[1] == place)
                {
                    if (altBase == "ANY" || altBase==bits[2] )
                    {
                        if (answer.Contains(line) == false)
                        { answer += "\r\n" + line; }
                    }
                    else
                    {
                        if (altBase == bits[3])
                        {
                            answer = line;
                            return answer;
                        }
                    }
                }
                position += 50 ;
            }

            return answer;
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

            btnSearchLocation.Enabled = true;
            lblIndex.Visible = false;

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            fileName = FileString.OpenAs("Select the score matrix file", "*.tsv|*.tsv");
            if (System.IO.File.Exists(fileName) == false) { return; }

            System.IO.StreamReader fs = null;
            try
            {
                fs = new System.IO.StreamReader(fileName);
                headerLength = -1;
                int counter = 1;
                char lastC = '\0';
                while (fs.Peek() > 0 && headerLength == -1)
                {
                    char c = (char)fs.Read();

                    if ((lastC == '\r' || lastC == '\n') && c != '#')
                    { headerLength = counter; }
                    lastC = c;
                    counter++;
                }


                headerLength--;
            }
            finally { if (fs != null) { fs.Close(); } }

            if (headerLength > -1)
            {
                starts = new Dictionary<string, PointF>();

                btnSearchLocation.Enabled = true;
                btnIndex.Enabled = true;
                string indexFile = fileName.Substring(0, fileName.LastIndexOf(".")) + ".index";
                if (System.IO.File.Exists(indexFile)== false)
                {
                    btnSearchName.Enabled = false;
                    lblIndex.Visible = true;
                    btnIndex.Enabled = true;
                }
                else
                {
                    btnSearchName.Enabled = true;
                    lblIndex.Visible = false;
                    btnIndex.Enabled = false;
                }

            }
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader fs = null;

            try
            {
                if (starts.Count == 0)
                {
                    string indexFile = fileName.Substring(0, fileName.LastIndexOf(".")) + ".index";
                    fs= new System.IO.StreamReader(indexFile);

                    string line = "";
                    string[] items = null;

                    while (fs.Peek() > 0)
                    {
                        line = fs.ReadLine();
                        items = line.Split('\t');
                       
                        if (items.Length > 2)
                        {
                            long sValue = Convert.ToInt64(items[1]);
                            long eValuee = Convert.ToInt64(items[2]);
                            PointF p = new PointF(sValue, eValuee);
                            if (starts.ContainsKey(items[0].ToLower()) == false)
                            { starts.Add(items[0].ToLower(), p); }
                        }
                    }

                }
            }
            catch(Exception ex)
            { }
            finally
            { if (fs != null) { fs.Close(); } }

            string data = "";
            string name = txtName.Text.Trim().ToLower();
            if (starts.ContainsKey(name) == true)
            {
                PointF p = starts[name];
                System.IO.FileStream sf = null;               
                try
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                    long size = fi.Length;
                    sf = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                    data = GetMatchs(sf, (long)p.X, (long)p.Y, name, size, headerLength);
                }
                finally { if (sf != null) { sf.Close(); } }
            }
            txtAnswer.Text=data;

        }

        private string GetMatchs(System.IO.FileStream sf, long positionStart, long positionEnd, string name, long filelength, int headerlength)
        {
            string answer = "";

            long position = positionStart - 300;
            if (position < headerLength)
            { position = headerLength; }
                        
            string line = "";

            while (position < positionEnd + 300 && position < filelength)
            {
                line = newLine(sf, position, filelength, headerlength);
                string[] bits = line.Split('\t');

                if (bits[5].ToLower() == name || bits[6].ToLower() == name)
                {
                    if (answer.Contains(line) == false)
                    { answer += "\r\n" + line; }
                }
                position += 50;
            }

            return answer;
        }

    }
}
