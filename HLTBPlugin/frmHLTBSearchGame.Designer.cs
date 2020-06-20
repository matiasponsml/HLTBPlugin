namespace HLTBPlugin
{
    partial class frmHLTBGames
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
            this.lstGames = new System.Windows.Forms.ListView();
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainStory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainExtra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.completionist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtGameTitle = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lstGames
            // 
            this.lstGames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstGames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.title,
            this.mainStory,
            this.mainExtra,
            this.completionist});
            this.lstGames.Location = new System.Drawing.Point(0, 30);
            this.lstGames.MultiSelect = false;
            this.lstGames.Name = "lstGames";
            this.lstGames.Size = new System.Drawing.Size(689, 167);
            this.lstGames.TabIndex = 1;
            this.lstGames.UseCompatibleStateImageBehavior = false;
            this.lstGames.View = System.Windows.Forms.View.Details;
            this.lstGames.SelectedIndexChanged += new System.EventHandler(this.lstGames_SelectedIndexChanged);
            // 
            // title
            // 
            this.title.Text = "Title";
            this.title.Width = 300;
            // 
            // mainStory
            // 
            this.mainStory.Text = "MainStory";
            this.mainStory.Width = 114;
            // 
            // mainExtra
            // 
            this.mainExtra.Text = "Main + Extra";
            this.mainExtra.Width = 122;
            // 
            // completionist
            // 
            this.completionist.Text = "Completionist";
            this.completionist.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "(click on game title to update game length)";
            // 
            // txtGameTitle
            // 
            this.txtGameTitle.Location = new System.Drawing.Point(6, 4);
            this.txtGameTitle.Name = "txtGameTitle";
            this.txtGameTitle.Size = new System.Drawing.Size(533, 20);
            this.txtGameTitle.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(548, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(133, 22);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(526, 201);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(151, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Support HowLongToBeat.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmHLTBGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 221);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtGameTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstGames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmHLTBGames";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Game";
            this.Load += new System.EventHandler(this.frmHLTBGames_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListView lstGames;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.ColumnHeader mainStory;
        private System.Windows.Forms.ColumnHeader mainExtra;
        private System.Windows.Forms.ColumnHeader completionist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.TextBox txtGameTitle;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}