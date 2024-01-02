namespace Opposition {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.kryptonNavigator = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.saveToolbarButton = new System.Windows.Forms.ToolStripButton();
            this.printToolbarButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator)).BeginInit();
            this.kryptonNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(833, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolbarButton,
            this.printToolbarButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(833, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // kryptonNavigator
            // 
            this.kryptonNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator.Location = new System.Drawing.Point(0, 49);
            this.kryptonNavigator.Name = "kryptonNavigator";
            this.kryptonNavigator.Size = new System.Drawing.Size(833, 426);
            this.kryptonNavigator.TabIndex = 2;
            this.kryptonNavigator.Text = "kryptonNavigator1";
            // 
            // saveToolbarButton
            // 
            this.saveToolbarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveToolbarButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolbarButton.Image")));
            this.saveToolbarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolbarButton.Name = "saveToolbarButton";
            this.saveToolbarButton.Size = new System.Drawing.Size(67, 22);
            this.saveToolbarButton.Text = "Enregistrer";
            // 
            // printToolbarButton
            // 
            this.printToolbarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolbarButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolbarButton.Image")));
            this.printToolbarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolbarButton.Name = "printToolbarButton";
            this.printToolbarButton.Size = new System.Drawing.Size(23, 22);
            this.printToolbarButton.Text = "toolStripButton1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 475);
            this.Controls.Add(this.kryptonNavigator);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Oppositions";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator)).EndInit();
            this.kryptonNavigator.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator;
        private System.Windows.Forms.ToolStripButton saveToolbarButton;
        private System.Windows.Forms.ToolStripButton printToolbarButton;
    }
}

