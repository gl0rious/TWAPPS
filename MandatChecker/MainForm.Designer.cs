namespace MandatChecker {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && (components != null) ) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.errorsButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ordLabel = new System.Windows.Forms.Label();
            this.accountLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.mandatNumLabel = new System.Windows.Forms.Label();
            this.lineCountLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.zeroLabel = new System.Windows.Forms.Label();
            this.starLabel = new System.Windows.Forms.Label();
            this.starTextBox = new System.Windows.Forms.TextBox();
            this.accountTextBox = new System.Windows.Forms.TextBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.computedTotalTextBox = new System.Windows.Forms.TextBox();
            this.lineCountTextBox = new System.Windows.Forms.TextBox();
            this.computedLineCountTextBox = new System.Windows.Forms.TextBox();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.ordTextBox = new System.Windows.Forms.TextBox();
            this.mandatNumTextBox = new System.Windows.Forms.TextBox();
            this.zeroTextBox = new System.Windows.Forms.TextBox();
            this.tailTextBox = new System.Windows.Forms.TextBox();
            this.tailLabel = new System.Windows.Forms.Label();
            this.usersGridView = new System.Windows.Forms.DataGridView();
            this.clIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clStar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clZeroOne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorsTextBox = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.errorsButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1101, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(98, 22);
            this.btnOpen.Text = "Ouvrir Fichier";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // errorsButton
            // 
            this.errorsButton.CheckOnClick = true;
            this.errorsButton.Enabled = false;
            this.errorsButton.Image = ((System.Drawing.Image)(resources.GetObject("errorsButton.Image")));
            this.errorsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.errorsButton.Name = "errorsButton";
            this.errorsButton.Size = new System.Drawing.Size(63, 22);
            this.errorsButton.Text = "Erreurs";
            this.errorsButton.CheckedChanged += new System.EventHandler(this.toolStripButton1_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.errorsTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(1101, 622);
            this.splitContainer1.SplitterDistance = 531;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.usersGridView);
            this.splitContainer2.Size = new System.Drawing.Size(1101, 531);
            this.splitContainer2.SplitterDistance = 65;
            this.splitContainer2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ordLabel, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.accountLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.totalLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.mandatNumLabel, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lineCountLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateLabel, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.zeroLabel, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.starLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.starTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.accountTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.totalTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.computedTotalTextBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lineCountTextBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.computedLineCountTextBox, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateTextBox, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.ordTextBox, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.mandatNumTextBox, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.zeroTextBox, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.tailTextBox, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.tailLabel, 8, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(639, 65);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // ordLabel
            // 
            this.ordLabel.AutoSize = true;
            this.ordLabel.Location = new System.Drawing.Point(370, 0);
            this.ordLabel.Name = "ordLabel";
            this.ordLabel.Size = new System.Drawing.Size(107, 17);
            this.ordLabel.TabIndex = 7;
            this.ordLabel.Text = "Ordonnateur";
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Location = new System.Drawing.Point(26, 0);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(62, 17);
            this.accountLabel.TabIndex = 0;
            this.accountLabel.Text = "Compte";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(94, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(125, 17);
            this.totalLabel.TabIndex = 2;
            this.totalLabel.Text = "Montant Total";
            // 
            // mandatNumLabel
            // 
            this.mandatNumLabel.AutoSize = true;
            this.mandatNumLabel.Location = new System.Drawing.Point(483, 0);
            this.mandatNumLabel.Name = "mandatNumLabel";
            this.mandatNumLabel.Size = new System.Drawing.Size(89, 17);
            this.mandatNumLabel.TabIndex = 11;
            this.mandatNumLabel.Text = "N° Mandat";
            // 
            // lineCountLabel
            // 
            this.lineCountLabel.AutoSize = true;
            this.lineCountLabel.Location = new System.Drawing.Point(225, 0);
            this.lineCountLabel.Name = "lineCountLabel";
            this.lineCountLabel.Size = new System.Drawing.Size(89, 17);
            this.lineCountLabel.TabIndex = 9;
            this.lineCountLabel.Text = "N° Lignes";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(320, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(44, 17);
            this.dateLabel.TabIndex = 5;
            this.dateLabel.Text = "Date";
            // 
            // zeroLabel
            // 
            this.zeroLabel.AutoSize = true;
            this.zeroLabel.Location = new System.Drawing.Point(578, 0);
            this.zeroLabel.Name = "zeroLabel";
            this.zeroLabel.Size = new System.Drawing.Size(17, 17);
            this.zeroLabel.TabIndex = 13;
            this.zeroLabel.Text = "0";
            this.zeroLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // starLabel
            // 
            this.starLabel.AutoSize = true;
            this.starLabel.Location = new System.Drawing.Point(3, 0);
            this.starLabel.Name = "starLabel";
            this.starLabel.Size = new System.Drawing.Size(17, 17);
            this.starLabel.TabIndex = 14;
            this.starLabel.Text = "*";
            this.starLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // starTextBox
            // 
            this.starTextBox.BackColor = System.Drawing.Color.LimeGreen;
            this.starTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.starTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.starTextBox.Location = new System.Drawing.Point(3, 20);
            this.starTextBox.Name = "starTextBox";
            this.starTextBox.ReadOnly = true;
            this.starTextBox.Size = new System.Drawing.Size(17, 17);
            this.starTextBox.TabIndex = 21;
            this.starTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // accountTextBox
            // 
            this.accountTextBox.BackColor = System.Drawing.Color.LimeGreen;
            this.accountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.accountTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.accountTextBox.Location = new System.Drawing.Point(26, 20);
            this.accountTextBox.Name = "accountTextBox";
            this.accountTextBox.ReadOnly = true;
            this.accountTextBox.Size = new System.Drawing.Size(62, 17);
            this.accountTextBox.TabIndex = 22;
            this.accountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalTextBox
            // 
            this.totalTextBox.BackColor = System.Drawing.Color.LimeGreen;
            this.totalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.totalTextBox.Location = new System.Drawing.Point(94, 20);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.ReadOnly = true;
            this.totalTextBox.Size = new System.Drawing.Size(125, 17);
            this.totalTextBox.TabIndex = 23;
            this.totalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // computedTotalTextBox
            // 
            this.computedTotalTextBox.BackColor = System.Drawing.Color.LimeGreen;
            this.computedTotalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.computedTotalTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.computedTotalTextBox.Location = new System.Drawing.Point(94, 43);
            this.computedTotalTextBox.Name = "computedTotalTextBox";
            this.computedTotalTextBox.ReadOnly = true;
            this.computedTotalTextBox.Size = new System.Drawing.Size(125, 17);
            this.computedTotalTextBox.TabIndex = 24;
            this.computedTotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lineCountTextBox
            // 
            this.lineCountTextBox.BackColor = System.Drawing.Color.LimeGreen;
            this.lineCountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lineCountTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.lineCountTextBox.Location = new System.Drawing.Point(225, 20);
            this.lineCountTextBox.Name = "lineCountTextBox";
            this.lineCountTextBox.ReadOnly = true;
            this.lineCountTextBox.Size = new System.Drawing.Size(89, 17);
            this.lineCountTextBox.TabIndex = 25;
            this.lineCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // computedLineCountTextBox
            // 
            this.computedLineCountTextBox.BackColor = System.Drawing.Color.LimeGreen;
            this.computedLineCountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.computedLineCountTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.computedLineCountTextBox.Location = new System.Drawing.Point(225, 43);
            this.computedLineCountTextBox.Name = "computedLineCountTextBox";
            this.computedLineCountTextBox.ReadOnly = true;
            this.computedLineCountTextBox.Size = new System.Drawing.Size(89, 17);
            this.computedLineCountTextBox.TabIndex = 26;
            this.computedLineCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dateTextBox
            // 
            this.dateTextBox.BackColor = System.Drawing.Color.LimeGreen;
            this.dateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateTextBox.Location = new System.Drawing.Point(320, 20);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.ReadOnly = true;
            this.dateTextBox.Size = new System.Drawing.Size(44, 17);
            this.dateTextBox.TabIndex = 27;
            this.dateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ordTextBox
            // 
            this.ordTextBox.BackColor = System.Drawing.Color.LimeGreen;
            this.ordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ordTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ordTextBox.Location = new System.Drawing.Point(370, 20);
            this.ordTextBox.Name = "ordTextBox";
            this.ordTextBox.ReadOnly = true;
            this.ordTextBox.Size = new System.Drawing.Size(107, 17);
            this.ordTextBox.TabIndex = 28;
            this.ordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mandatNumTextBox
            // 
            this.mandatNumTextBox.BackColor = System.Drawing.Color.LimeGreen;
            this.mandatNumTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mandatNumTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.mandatNumTextBox.Location = new System.Drawing.Point(483, 20);
            this.mandatNumTextBox.Name = "mandatNumTextBox";
            this.mandatNumTextBox.ReadOnly = true;
            this.mandatNumTextBox.Size = new System.Drawing.Size(89, 17);
            this.mandatNumTextBox.TabIndex = 29;
            this.mandatNumTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // zeroTextBox
            // 
            this.zeroTextBox.BackColor = System.Drawing.Color.LimeGreen;
            this.zeroTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zeroTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.zeroTextBox.Location = new System.Drawing.Point(578, 20);
            this.zeroTextBox.Name = "zeroTextBox";
            this.zeroTextBox.ReadOnly = true;
            this.zeroTextBox.Size = new System.Drawing.Size(17, 17);
            this.zeroTextBox.TabIndex = 30;
            this.zeroTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tailTextBox
            // 
            this.tailTextBox.BackColor = System.Drawing.Color.LimeGreen;
            this.tailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tailTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.tailTextBox.Location = new System.Drawing.Point(601, 20);
            this.tailTextBox.Name = "tailTextBox";
            this.tailTextBox.ReadOnly = true;
            this.tailTextBox.Size = new System.Drawing.Size(35, 17);
            this.tailTextBox.TabIndex = 31;
            // 
            // tailLabel
            // 
            this.tailLabel.AutoSize = true;
            this.tailLabel.Location = new System.Drawing.Point(601, 0);
            this.tailLabel.Name = "tailLabel";
            this.tailLabel.Size = new System.Drawing.Size(35, 17);
            this.tailLabel.TabIndex = 32;
            this.tailLabel.Text = "---";
            // 
            // usersGridView
            // 
            this.usersGridView.AllowUserToAddRows = false;
            this.usersGridView.AllowUserToDeleteRows = false;
            this.usersGridView.AllowUserToResizeColumns = false;
            this.usersGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.usersGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.usersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.usersGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.usersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.usersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clIndex,
            this.clStar,
            this.clAccount,
            this.clAmount,
            this.clFullname,
            this.clZeroOne,
            this.clTail});
            this.usersGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersGridView.Location = new System.Drawing.Point(0, 0);
            this.usersGridView.MultiSelect = false;
            this.usersGridView.Name = "usersGridView";
            this.usersGridView.ReadOnly = true;
            this.usersGridView.RowHeadersVisible = false;
            this.usersGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.usersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.usersGridView.Size = new System.Drawing.Size(1101, 462);
            this.usersGridView.TabIndex = 0;
            this.usersGridView.VirtualMode = true;
            this.usersGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.usersGridView_CellEnter);
            this.usersGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.UsersGridView_CellValueNeeded);
            this.usersGridView.Leave += new System.EventHandler(this.usersGridView_Leave);
            // 
            // clIndex
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clIndex.DefaultCellStyle = dataGridViewCellStyle3;
            this.clIndex.HeaderText = "#";
            this.clIndex.Name = "clIndex";
            this.clIndex.ReadOnly = true;
            this.clIndex.Width = 42;
            // 
            // clStar
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clStar.DefaultCellStyle = dataGridViewCellStyle4;
            this.clStar.HeaderText = "*";
            this.clStar.Name = "clStar";
            this.clStar.ReadOnly = true;
            this.clStar.Width = 42;
            // 
            // clAccount
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clAccount.DefaultCellStyle = dataGridViewCellStyle5;
            this.clAccount.HeaderText = "Compte";
            this.clAccount.Name = "clAccount";
            this.clAccount.ReadOnly = true;
            this.clAccount.Width = 87;
            // 
            // clAmount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.clAmount.HeaderText = "Montant";
            this.clAmount.Name = "clAmount";
            this.clAmount.ReadOnly = true;
            this.clAmount.Width = 96;
            // 
            // clFullname
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clFullname.DefaultCellStyle = dataGridViewCellStyle7;
            this.clFullname.HeaderText = "Nom";
            this.clFullname.Name = "clFullname";
            this.clFullname.ReadOnly = true;
            this.clFullname.Width = 60;
            // 
            // clZeroOne
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clZeroOne.DefaultCellStyle = dataGridViewCellStyle8;
            this.clZeroOne.HeaderText = "1";
            this.clZeroOne.Name = "clZeroOne";
            this.clZeroOne.ReadOnly = true;
            this.clZeroOne.Width = 42;
            // 
            // clTail
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clTail.DefaultCellStyle = dataGridViewCellStyle9;
            this.clTail.HeaderText = "---";
            this.clTail.Name = "clTail";
            this.clTail.ReadOnly = true;
            this.clTail.Width = 60;
            // 
            // errorsTextBox
            // 
            this.errorsTextBox.BackColor = System.Drawing.Color.LightGray;
            this.errorsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorsTextBox.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorsTextBox.ForeColor = System.Drawing.Color.White;
            this.errorsTextBox.Location = new System.Drawing.Point(0, 0);
            this.errorsTextBox.Name = "errorsTextBox";
            this.errorsTextBox.ReadOnly = true;
            this.errorsTextBox.Size = new System.Drawing.Size(1101, 87);
            this.errorsTextBox.TabIndex = 0;
            this.errorsTextBox.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Text files|*.txt";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 647);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Mandat Checker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label mandatNumLabel;
        private System.Windows.Forms.Label lineCountLabel;
        private System.Windows.Forms.Label ordLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.DataGridView usersGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label zeroLabel;
        private System.Windows.Forms.Label starLabel;
        private System.Windows.Forms.ToolStripButton errorsButton;
        private System.Windows.Forms.RichTextBox errorsTextBox;
        private System.Windows.Forms.TextBox starTextBox;
        private System.Windows.Forms.TextBox accountTextBox;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.TextBox computedTotalTextBox;
        private System.Windows.Forms.TextBox lineCountTextBox;
        private System.Windows.Forms.TextBox computedLineCountTextBox;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.TextBox ordTextBox;
        private System.Windows.Forms.TextBox mandatNumTextBox;
        private System.Windows.Forms.TextBox zeroTextBox;
        private System.Windows.Forms.TextBox tailTextBox;
        private System.Windows.Forms.Label tailLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn clZeroOne;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTail;
    }
}

