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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.runBtn = new System.Windows.Forms.Button();
            this.syntaxCheckButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
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
            this.shapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variousShapesPlaceholderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variousColorsPlaceholderToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.variousShapesPlaceholderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.variousShapesPlaceholderToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userInput = new System.Windows.Forms.TextBox();
            this.programmingArea = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.drawingArea = new System.Windows.Forms.PictureBox();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.CursorPosLabelInfo = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
            this.LabelCurrentColor = new System.Windows.Forms.Label();
            this.BoxCurrentColor = new System.Windows.Forms.PictureBox();
            this.LabelFill = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxCurrentColor)).BeginInit();
            this.SuspendLayout();
            // 
            // runBtn
            // 
            resources.ApplyResources(this.runBtn, "runBtn");
            this.runBtn.Name = "runBtn";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runButton_Click);
            // 
            // syntaxCheckButton
            // 
            resources.ApplyResources(this.syntaxCheckButton, "syntaxCheckButton");
            this.syntaxCheckButton.Name = "syntaxCheckButton";
            this.syntaxCheckButton.UseVisualStyleBackColor = true;
            this.syntaxCheckButton.Click += new System.EventHandler(this.syntaxCheckButton_Click);
            // 
            // helpButton
            // 
            resources.ApplyResources(this.helpButton, "helpButton");
            this.helpButton.Name = "helpButton";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.loadToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            resources.ApplyResources(this.loadToolStripMenuItem, "loadToolStripMenuItem");
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            resources.ApplyResources(this.loadToolStripMenuItem1, "loadToolStripMenuItem1");
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coloursToolStripMenuItem,
            this.shapesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // coloursToolStripMenuItem
            // 
            this.coloursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.variousColorsToolStripMenuItem,
            this.variousColorsPlaceholderToolStripMenuItem,
            this.variousColorsPlaceholderToolStripMenuItem1});
            this.coloursToolStripMenuItem.Name = "coloursToolStripMenuItem";
            resources.ApplyResources(this.coloursToolStripMenuItem, "coloursToolStripMenuItem");
            // 
            // variousColorsToolStripMenuItem
            // 
            this.variousColorsToolStripMenuItem.Name = "variousColorsToolStripMenuItem";
            resources.ApplyResources(this.variousColorsToolStripMenuItem, "variousColorsToolStripMenuItem");
            // 
            // variousColorsPlaceholderToolStripMenuItem
            // 
            this.variousColorsPlaceholderToolStripMenuItem.Name = "variousColorsPlaceholderToolStripMenuItem";
            resources.ApplyResources(this.variousColorsPlaceholderToolStripMenuItem, "variousColorsPlaceholderToolStripMenuItem");
            this.variousColorsPlaceholderToolStripMenuItem.Click += new System.EventHandler(this.variousColorsPlaceholderToolStripMenuItem_Click);
            // 
            // variousColorsPlaceholderToolStripMenuItem1
            // 
            this.variousColorsPlaceholderToolStripMenuItem1.Name = "variousColorsPlaceholderToolStripMenuItem1";
            resources.ApplyResources(this.variousColorsPlaceholderToolStripMenuItem1, "variousColorsPlaceholderToolStripMenuItem1");
            // 
            // shapesToolStripMenuItem
            // 
            this.shapesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.variousShapesPlaceholderToolStripMenuItem,
            this.variousColorsPlaceholderToolStripMenuItem3,
            this.variousShapesPlaceholderToolStripMenuItem1,
            this.variousShapesPlaceholderToolStripMenuItem2});
            this.shapesToolStripMenuItem.Name = "shapesToolStripMenuItem";
            resources.ApplyResources(this.shapesToolStripMenuItem, "shapesToolStripMenuItem");
            // 
            // variousShapesPlaceholderToolStripMenuItem
            // 
            this.variousShapesPlaceholderToolStripMenuItem.Name = "variousShapesPlaceholderToolStripMenuItem";
            resources.ApplyResources(this.variousShapesPlaceholderToolStripMenuItem, "variousShapesPlaceholderToolStripMenuItem");
            this.variousShapesPlaceholderToolStripMenuItem.Click += new System.EventHandler(this.variousShapesPlaceholderToolStripMenuItem_Click);
            // 
            // variousColorsPlaceholderToolStripMenuItem3
            // 
            this.variousColorsPlaceholderToolStripMenuItem3.Name = "variousColorsPlaceholderToolStripMenuItem3";
            resources.ApplyResources(this.variousColorsPlaceholderToolStripMenuItem3, "variousColorsPlaceholderToolStripMenuItem3");
            // 
            // variousShapesPlaceholderToolStripMenuItem1
            // 
            this.variousShapesPlaceholderToolStripMenuItem1.Name = "variousShapesPlaceholderToolStripMenuItem1";
            resources.ApplyResources(this.variousShapesPlaceholderToolStripMenuItem1, "variousShapesPlaceholderToolStripMenuItem1");
            // 
            // variousShapesPlaceholderToolStripMenuItem2
            // 
            this.variousShapesPlaceholderToolStripMenuItem2.Name = "variousShapesPlaceholderToolStripMenuItem2";
            resources.ApplyResources(this.variousShapesPlaceholderToolStripMenuItem2, "variousShapesPlaceholderToolStripMenuItem2");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandListToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // commandListToolStripMenuItem
            // 
            this.commandListToolStripMenuItem.Name = "commandListToolStripMenuItem";
            resources.ApplyResources(this.commandListToolStripMenuItem, "commandListToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // userInput
            // 
            resources.ApplyResources(this.userInput, "userInput");
            this.userInput.Name = "userInput";
            this.userInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userInput_KeyDown_1);
            // 
            // programmingArea
            // 
            resources.ApplyResources(this.programmingArea, "programmingArea");
            this.programmingArea.Name = "programmingArea";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // drawingArea
            // 
            this.drawingArea.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.drawingArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.drawingArea, "drawingArea");
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.TabStop = false;
            this.drawingArea.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingArea_Paint);
            // 
            // PositionLabel
            // 
            this.PositionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.PositionLabel, "PositionLabel");
            this.PositionLabel.Name = "PositionLabel";
            // 
            // errorLabel
            // 
            resources.ApplyResources(this.errorLabel, "errorLabel");
            this.errorLabel.Name = "errorLabel";
            // 
            // CursorPosLabelInfo
            // 
            resources.ApplyResources(this.CursorPosLabelInfo, "CursorPosLabelInfo");
            this.CursorPosLabelInfo.Name = "CursorPosLabelInfo";
            // 
            // BtnClear
            // 
            resources.ApplyResources(this.BtnClear, "BtnClear");
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // LabelCurrentColor
            // 
            resources.ApplyResources(this.LabelCurrentColor, "LabelCurrentColor");
            this.LabelCurrentColor.Name = "LabelCurrentColor";
            // 
            // BoxCurrentColor
            // 
            this.BoxCurrentColor.BackColor = System.Drawing.Color.White;
            this.BoxCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.BoxCurrentColor, "BoxCurrentColor");
            this.BoxCurrentColor.Name = "BoxCurrentColor";
            this.BoxCurrentColor.TabStop = false;
            // 
            // LabelFill
            // 
            resources.ApplyResources(this.LabelFill, "LabelFill");
            this.LabelFill.Name = "LabelFill";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.LabelFill);
            this.Controls.Add(this.BoxCurrentColor);
            this.Controls.Add(this.LabelCurrentColor);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.CursorPosLabelInfo);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.drawingArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.programmingArea);
            this.Controls.Add(this.userInput);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.syntaxCheckButton);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxCurrentColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Button syntaxCheckButton;
        private System.Windows.Forms.Button helpButton;
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
        private System.Windows.Forms.ToolStripMenuItem shapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variousShapesPlaceholderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variousColorsPlaceholderToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem variousShapesPlaceholderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem variousShapesPlaceholderToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TextBox userInput;
        private System.Windows.Forms.TextBox programmingArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox drawingArea;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label CursorPosLabelInfo;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Label LabelCurrentColor;
        private System.Windows.Forms.PictureBox BoxCurrentColor;
        private System.Windows.Forms.Label LabelFill;
    }

}

