
namespace AlphaMissenseViewer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblIndex = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBase = new System.Windows.Forms.ComboBox();
            this.cboChromosome = new System.Windows.Forms.ComboBox();
            this.btnIndex = new System.Windows.Forms.Button();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.btnSearchLocation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtAnswer);
            this.groupBox1.Controls.Add(this.btnSearchName);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblIndex);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboBase);
            this.groupBox1.Controls.Add(this.cboChromosome);
            this.groupBox1.Controls.Add(this.btnIndex);
            this.groupBox1.Controls.Add(this.txtPlace);
            this.groupBox1.Controls.Add(this.btnSearchLocation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 480);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnswer.Location = new System.Drawing.Point(13, 234);
            this.txtAnswer.Multiline = true;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAnswer.Size = new System.Drawing.Size(526, 240);
            this.txtAnswer.TabIndex = 15;
            this.txtAnswer.WordWrap = false;
            // 
            // btnSearchName
            // 
            this.btnSearchName.Enabled = false;
            this.btnSearchName.Location = new System.Drawing.Point(469, 172);
            this.btnSearchName.Name = "btnSearchName";
            this.btnSearchName.Size = new System.Drawing.Size(75, 23);
            this.btnSearchName.TabIndex = 14;
            this.btnSearchName.Text = "Search";
            this.btnSearchName.UseVisualStyleBackColor = true;
            this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 172);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(353, 20);
            this.txtName.TabIndex = 4;
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndex.ForeColor = System.Drawing.Color.Red;
            this.lblIndex.Location = new System.Drawing.Point(10, 177);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(94, 13);
            this.lblIndex.TabIndex = 13;
            this.lblIndex.Text = "Make Index file";
            this.lblIndex.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "To index the file press the Index button";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(529, 42);
            this.label6.TabIndex = 11;
            this.label6.Text = "To find all Vaiants in data set for a UniProt or Ensembl ID enter name in tetx bo" +
    "x and press \'Search\'. Before you can use this function you must make an index fi" +
    "le by pressing the Index button. ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(469, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Select data file";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Alt variant";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chromosome";
            // 
            // cboBase
            // 
            this.cboBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBase.FormattingEnabled = true;
            this.cboBase.Items.AddRange(new object[] {
            "Select",
            "A",
            "C",
            "G",
            "T",
            "Any"});
            this.cboBase.Location = new System.Drawing.Point(405, 88);
            this.cboBase.Name = "cboBase";
            this.cboBase.Size = new System.Drawing.Size(58, 21);
            this.cboBase.TabIndex = 5;
            // 
            // cboChromosome
            // 
            this.cboChromosome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChromosome.FormattingEnabled = true;
            this.cboChromosome.Items.AddRange(new object[] {
            "Select",
            "Chr1",
            "Chr2",
            "Chr3",
            "Chr4",
            "Chr5",
            "Chr6",
            "Chr7",
            "Chr8",
            "Chr9",
            "Chr10",
            "Chr11",
            "Chr12",
            "Chr13",
            "Chr14",
            "Chr15",
            "Chr16",
            "Chr17",
            "Chr18",
            "Chr19",
            "Chr20",
            "Chr21",
            "Chr22",
            "ChrX",
            "ChrY"});
            this.cboChromosome.Location = new System.Drawing.Point(96, 88);
            this.cboChromosome.Name = "cboChromosome";
            this.cboChromosome.Size = new System.Drawing.Size(85, 21);
            this.cboChromosome.TabIndex = 4;
            // 
            // btnIndex
            // 
            this.btnIndex.Enabled = false;
            this.btnIndex.Location = new System.Drawing.Point(469, 205);
            this.btnIndex.Name = "btnIndex";
            this.btnIndex.Size = new System.Drawing.Size(75, 23);
            this.btnIndex.TabIndex = 3;
            this.btnIndex.Text = "Index";
            this.btnIndex.UseVisualStyleBackColor = true;
            this.btnIndex.Click += new System.EventHandler(this.btnIndex_Click);
            // 
            // txtPlace
            // 
            this.txtPlace.Location = new System.Drawing.Point(239, 88);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(100, 20);
            this.txtPlace.TabIndex = 2;
            // 
            // btnSearchLocation
            // 
            this.btnSearchLocation.Enabled = false;
            this.btnSearchLocation.Location = new System.Drawing.Point(469, 86);
            this.btnSearchLocation.Name = "btnSearchLocation";
            this.btnSearchLocation.Size = new System.Drawing.Size(75, 23);
            this.btnSearchLocation.TabIndex = 1;
            this.btnSearchLocation.Text = "Search";
            this.btnSearchLocation.UseVisualStyleBackColor = true;
            this.btnSearchLocation.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter chromosome, location and alt variant (if known)";
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.Location = new System.Drawing.Point(488, 498);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 528);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Search AlphaMissense_hg38/19.tsv data file";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPlace;
        private System.Windows.Forms.Button btnSearchLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnIndex;
        private System.Windows.Forms.ComboBox cboBase;
        private System.Windows.Forms.ComboBox cboChromosome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearchName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAnswer;
    }
}

