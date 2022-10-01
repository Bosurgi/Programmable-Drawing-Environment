namespace DrawingEnvironment
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coloursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variousColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variousColorsPlaceholderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variousColorsPlaceholderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.variousColorsPlaceholderToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.shapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variousShapesPlaceholderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variousColorsPlaceholderToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.variousShapesPlaceholderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.variousShapesPlaceholderToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 200);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Syntax";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 200);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Help";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.loadToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "New";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Save";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coloursToolStripMenuItem,
            this.shapesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // coloursToolStripMenuItem
            // 
            this.coloursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.variousColorsToolStripMenuItem,
            this.variousColorsPlaceholderToolStripMenuItem,
            this.variousColorsPlaceholderToolStripMenuItem1,
            this.variousColorsPlaceholderToolStripMenuItem2});
            this.coloursToolStripMenuItem.Name = "coloursToolStripMenuItem";
            this.coloursToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.coloursToolStripMenuItem.Text = "Colours";
            // 
            // variousColorsToolStripMenuItem
            // 
            this.variousColorsToolStripMenuItem.Name = "variousColorsToolStripMenuItem";
            this.variousColorsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.variousColorsToolStripMenuItem.Text = "Various colors";
            // 
            // variousColorsPlaceholderToolStripMenuItem
            // 
            this.variousColorsPlaceholderToolStripMenuItem.Name = "variousColorsPlaceholderToolStripMenuItem";
            this.variousColorsPlaceholderToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.variousColorsPlaceholderToolStripMenuItem.Text = "Various colors placeholder";
            this.variousColorsPlaceholderToolStripMenuItem.Click += new System.EventHandler(this.variousColorsPlaceholderToolStripMenuItem_Click);
            // 
            // variousColorsPlaceholderToolStripMenuItem1
            // 
            this.variousColorsPlaceholderToolStripMenuItem1.Name = "variousColorsPlaceholderToolStripMenuItem1";
            this.variousColorsPlaceholderToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.variousColorsPlaceholderToolStripMenuItem1.Text = "Various colors placeholder";
            // 
            // variousColorsPlaceholderToolStripMenuItem2
            // 
            this.variousColorsPlaceholderToolStripMenuItem2.Name = "variousColorsPlaceholderToolStripMenuItem2";
            this.variousColorsPlaceholderToolStripMenuItem2.Size = new System.Drawing.Size(212, 22);
            this.variousColorsPlaceholderToolStripMenuItem2.Text = "Various colors placeholder";
            // 
            // shapesToolStripMenuItem
            // 
            this.shapesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.variousShapesPlaceholderToolStripMenuItem,
            this.variousColorsPlaceholderToolStripMenuItem3,
            this.variousShapesPlaceholderToolStripMenuItem1,
            this.variousShapesPlaceholderToolStripMenuItem2});
            this.shapesToolStripMenuItem.Name = "shapesToolStripMenuItem";
            this.shapesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.shapesToolStripMenuItem.Text = "Shapes";
            // 
            // variousShapesPlaceholderToolStripMenuItem
            // 
            this.variousShapesPlaceholderToolStripMenuItem.Name = "variousShapesPlaceholderToolStripMenuItem";
            this.variousShapesPlaceholderToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.variousShapesPlaceholderToolStripMenuItem.Text = "Various shapes placeholder";
            this.variousShapesPlaceholderToolStripMenuItem.Click += new System.EventHandler(this.variousShapesPlaceholderToolStripMenuItem_Click);
            // 
            // variousColorsPlaceholderToolStripMenuItem3
            // 
            this.variousColorsPlaceholderToolStripMenuItem3.Name = "variousColorsPlaceholderToolStripMenuItem3";
            this.variousColorsPlaceholderToolStripMenuItem3.Size = new System.Drawing.Size(216, 22);
            this.variousColorsPlaceholderToolStripMenuItem3.Text = "Various shapes placeholder";
            // 
            // variousShapesPlaceholderToolStripMenuItem1
            // 
            this.variousShapesPlaceholderToolStripMenuItem1.Name = "variousShapesPlaceholderToolStripMenuItem1";
            this.variousShapesPlaceholderToolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this.variousShapesPlaceholderToolStripMenuItem1.Text = "Various shapes placeholder";
            // 
            // variousShapesPlaceholderToolStripMenuItem2
            // 
            this.variousShapesPlaceholderToolStripMenuItem2.Name = "variousShapesPlaceholderToolStripMenuItem2";
            this.variousShapesPlaceholderToolStripMenuItem2.Size = new System.Drawing.Size(216, 22);
            this.variousShapesPlaceholderToolStripMenuItem2.Text = "Various shapes placeholder";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandListToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // commandListToolStripMenuItem
            // 
            this.commandListToolStripMenuItem.Name = "commandListToolStripMenuItem";
            this.commandListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.commandListToolStripMenuItem.Text = "Command List";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coloursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variousColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variousColorsPlaceholderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variousColorsPlaceholderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem variousColorsPlaceholderToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem shapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variousShapesPlaceholderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variousColorsPlaceholderToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem variousShapesPlaceholderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem variousShapesPlaceholderToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

