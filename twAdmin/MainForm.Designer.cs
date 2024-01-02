using System.Windows.Forms;

namespace twAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gvUsers = new System.Windows.Forms.DataGridView();
            this.username_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullname_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.lockUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlockUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUnblock = new System.Windows.Forms.Button();
            this.cbStates = new System.Windows.Forms.ComboBox();
            this.cbApps = new System.Windows.Forms.ComboBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblUser = new System.Windows.Forms.ToolStripLabel();
            this.checkRolesButton = new System.Windows.Forms.ToolStripButton();
            this.cmSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roleMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).BeginInit();
            this.cmUsers.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.cmSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gvUsers);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1MinSize = 340;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabs);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2MinSize = 400;
            this.splitContainer1.Size = new System.Drawing.Size(901, 560);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.TabIndex = 4;
            // 
            // gvUsers
            // 
            this.gvUsers.AllowUserToAddRows = false;
            this.gvUsers.AllowUserToDeleteRows = false;
            this.gvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.username_cl,
            this.fullname_cl});
            this.gvUsers.ContextMenuStrip = this.cmUsers;
            this.gvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvUsers.Location = new System.Drawing.Point(0, 34);
            this.gvUsers.MultiSelect = false;
            this.gvUsers.Name = "gvUsers";
            this.gvUsers.ReadOnly = true;
            this.gvUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvUsers.Size = new System.Drawing.Size(340, 526);
            this.gvUsers.TabIndex = 9;
            this.gvUsers.SelectionChanged += new System.EventHandler(this.gvUsers_SelectionChanged);
            // 
            // username_cl
            // 
            this.username_cl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.username_cl.HeaderText = "Username";
            this.username_cl.Name = "username_cl";
            this.username_cl.ReadOnly = true;
            this.username_cl.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.username_cl.Width = 80;
            // 
            // fullname_cl
            // 
            this.fullname_cl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fullname_cl.HeaderText = "Fullname";
            this.fullname_cl.Name = "fullname_cl";
            this.fullname_cl.ReadOnly = true;
            this.fullname_cl.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cmUsers
            // 
            this.cmUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectToolStripMenuItem,
            this.toolStripSeparator5,
            this.lockUserToolStripMenuItem,
            this.unlockUserToolStripMenuItem});
            this.cmUsers.Name = "cmUsers";
            this.cmUsers.Size = new System.Drawing.Size(138, 76);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(134, 6);
            // 
            // lockUserToolStripMenuItem
            // 
            this.lockUserToolStripMenuItem.Name = "lockUserToolStripMenuItem";
            this.lockUserToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.lockUserToolStripMenuItem.Text = "Lock User";
            this.lockUserToolStripMenuItem.Click += new System.EventHandler(this.lockUserToolStripMenuItem_Click);
            // 
            // unlockUserToolStripMenuItem
            // 
            this.unlockUserToolStripMenuItem.Name = "unlockUserToolStripMenuItem";
            this.unlockUserToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.unlockUserToolStripMenuItem.Text = "Unlock User";
            this.unlockUserToolStripMenuItem.Click += new System.EventHandler(this.unlockUserToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUnblock);
            this.panel1.Controls.Add(this.cbStates);
            this.panel1.Controls.Add(this.cbApps);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(344, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 34);
            this.panel1.TabIndex = 8;
            // 
            // btnUnblock
            // 
            this.btnUnblock.Location = new System.Drawing.Point(264, 6);
            this.btnUnblock.Name = "btnUnblock";
            this.btnUnblock.Size = new System.Drawing.Size(75, 23);
            this.btnUnblock.TabIndex = 8;
            this.btnUnblock.Text = "Unblock";
            this.btnUnblock.UseVisualStyleBackColor = true;
            this.btnUnblock.Click += new System.EventHandler(this.btnUnblock_Click);
            // 
            // cbStates
            // 
            this.cbStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStates.FormattingEnabled = true;
            this.cbStates.Items.AddRange(new object[] {
            "ALL",
            "Connected",
            "Locked"});
            this.cbStates.Location = new System.Drawing.Point(8, 7);
            this.cbStates.Name = "cbStates";
            this.cbStates.Size = new System.Drawing.Size(119, 21);
            this.cbStates.TabIndex = 7;
            this.cbStates.SelectedIndexChanged += new System.EventHandler(this.cbStates_SelectedIndexChanged);
            // 
            // cbApps
            // 
            this.cbApps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApps.FormattingEnabled = true;
            this.cbApps.Location = new System.Drawing.Point(133, 7);
            this.cbApps.Name = "cbApps";
            this.cbApps.Size = new System.Drawing.Size(125, 21);
            this.cbApps.TabIndex = 5;
            this.cbApps.SelectedIndexChanged += new System.EventHandler(this.cbApps_SelectedIndexChanged);
            // 
            // tabs
            // 
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 25);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(557, 535);
            this.tabs.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.toolStripSeparator1,
            this.btnCancel,
            this.toolStripSeparator4,
            this.btnSave,
            this.toolStripSeparator2,
            this.btnCopy,
            this.toolStripSeparator3,
            this.lblUser,
            this.checkRolesButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(557, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(31, 22);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCancel
            // 
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCancel.Enabled = false;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(47, 22);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(35, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCopy.Enabled = false;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(39, 22);
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 22);
            // 
            // checkRolesButton
            // 
            this.checkRolesButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.checkRolesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.checkRolesButton.Image = ((System.Drawing.Image)(resources.GetObject("checkRolesButton.Image")));
            this.checkRolesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkRolesButton.Name = "checkRolesButton";
            this.checkRolesButton.Size = new System.Drawing.Size(75, 22);
            this.checkRolesButton.Text = "Check Roles";
            this.checkRolesButton.Click += new System.EventHandler(this.checkRolesButton_Click);
            // 
            // cmSelect
            // 
            this.cmSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.deselectAllToolStripMenuItem});
            this.cmSelect.Name = "cmSelect";
            this.cmSelect.Size = new System.Drawing.Size(136, 48);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // deselectAllToolStripMenuItem
            // 
            this.deselectAllToolStripMenuItem.Name = "deselectAllToolStripMenuItem";
            this.deselectAllToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.deselectAllToolStripMenuItem.Text = "Deselect All";
            this.deselectAllToolStripMenuItem.Click += new System.EventHandler(this.deselectAllToolStripMenuItem_Click);
            // 
            // roleMenu
            // 
            this.roleMenu.Name = "roleMenu";
            this.roleMenu.Size = new System.Drawing.Size(61, 4);
            this.roleMenu.Opening += new System.ComponentModel.CancelEventHandler(this.roleMenu_Opening);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 560);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TW Admin";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).EndInit();
            this.cmUsers.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private TabControl tabs;
        private ContextMenuStrip cmSelect;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem deselectAllToolStripMenuItem;
        private ComboBox cbApps;
        private DataGridView gvUsers;
        private DataGridViewTextBoxColumn username_cl;
        private DataGridViewTextBoxColumn fullname_cl;
        private Panel panel1;
        private ContextMenuStrip cmUsers;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem lockUserToolStripMenuItem;
        private ToolStripMenuItem unlockUserToolStripMenuItem;
        private ComboBox cbStates;
        private ToolStripLabel lblUser;
        private Button btnUnblock;
        private ToolStripButton checkRolesButton;
        private ContextMenuStrip roleMenu;
    }
}

