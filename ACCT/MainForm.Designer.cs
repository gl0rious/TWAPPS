namespace ACCT
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvLocal = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilIcons = new System.Windows.Forms.ImageList(this.components);
            this.lvRemote = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSend.Location = new System.Drawing.Point(0, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(400, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Envoyer";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnShow
            // 
            this.btnShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShow.Location = new System.Drawing.Point(0, 0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(377, 23);
            this.btnShow.TabIndex = 0;
            this.btnShow.Text = "Afficher";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvLocal);
            this.splitContainer1.Panel1.Controls.Add(this.btnSend);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvRemote);
            this.splitContainer1.Panel2.Controls.Add(this.btnShow);
            this.splitContainer1.Size = new System.Drawing.Size(781, 441);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 2;
            // 
            // lvLocal
            // 
            this.lvLocal.AllowDrop = true;
            this.lvLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLocal.FullRowSelect = true;
            this.lvLocal.Location = new System.Drawing.Point(0, 23);
            this.lvLocal.Name = "lvLocal";
            this.lvLocal.ShowItemToolTips = true;
            this.lvLocal.Size = new System.Drawing.Size(400, 418);
            this.lvLocal.SmallImageList = this.ilIcons;
            this.lvLocal.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvLocal.TabIndex = 2;
            this.lvLocal.UseCompatibleStateImageBehavior = false;
            this.lvLocal.View = System.Windows.Forms.View.Details;
            this.lvLocal.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLocal_ColumnClick);
            this.lvLocal.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvLocal_DragDrop);
            this.lvLocal.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvLocal_DragEnter);
            this.lvLocal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvLocal_KeyDown);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Filename";
            this.columnHeader3.Width = 240;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Modified Date";
            this.columnHeader4.Width = 100;
            // 
            // ilIcons
            // 
            this.ilIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.ilIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lvRemote
            // 
            this.lvRemote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRemote.FullRowSelect = true;
            this.lvRemote.Location = new System.Drawing.Point(0, 23);
            this.lvRemote.Name = "lvRemote";
            this.lvRemote.ShowItemToolTips = true;
            this.lvRemote.Size = new System.Drawing.Size(377, 418);
            this.lvRemote.SmallImageList = this.ilIcons;
            this.lvRemote.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvRemote.TabIndex = 1;
            this.lvRemote.UseCompatibleStateImageBehavior = false;
            this.lvRemote.View = System.Windows.Forms.View.Details;
            this.lvRemote.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvRemote_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Filename";
            this.columnHeader1.Width = 240;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Modified Date";
            this.columnHeader2.Width = 100;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 441);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Envoi ACCT";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvRemote;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lvLocal;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ImageList ilIcons;
    }
}

