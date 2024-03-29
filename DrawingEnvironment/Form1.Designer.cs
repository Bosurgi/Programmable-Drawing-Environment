﻿namespace DrawingEnvironment
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
        /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.saveFileStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coloursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsRedItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsGreenItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsBlueItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsWhiteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsCircleItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsTriangleItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsSquareItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsRectangleItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.saveFileStripItem,
            this.loadFileStripItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // saveFileStripItem
            // 
            this.saveFileStripItem.Name = "saveFileStripItem";
            resources.ApplyResources(this.saveFileStripItem, "saveFileStripItem");
            this.saveFileStripItem.Click += new System.EventHandler(this.saveFileStripItem_Click);
            // 
            // loadFileStripItem
            // 
            this.loadFileStripItem.Name = "loadFileStripItem";
            resources.ApplyResources(this.loadFileStripItem, "loadFileStripItem");
            this.loadFileStripItem.Click += new System.EventHandler(this.loadFileStripItem_Click);
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
            this.ToolsRedItem,
            this.ToolsGreenItem,
            this.ToolsBlueItem,
            this.ToolsWhiteItem});
            this.coloursToolStripMenuItem.Name = "coloursToolStripMenuItem";
            resources.ApplyResources(this.coloursToolStripMenuItem, "coloursToolStripMenuItem");
            // 
            // ToolsRedItem
            // 
            this.ToolsRedItem.Name = "ToolsRedItem";
            resources.ApplyResources(this.ToolsRedItem, "ToolsRedItem");
            this.ToolsRedItem.Click += new System.EventHandler(this.ToolsRedItem_Click);
            // 
            // ToolsGreenItem
            // 
            this.ToolsGreenItem.Name = "ToolsGreenItem";
            resources.ApplyResources(this.ToolsGreenItem, "ToolsGreenItem");
            this.ToolsGreenItem.Click += new System.EventHandler(this.ToolsGreenItem_Click);
            // 
            // ToolsBlueItem
            // 
            this.ToolsBlueItem.Name = "ToolsBlueItem";
            resources.ApplyResources(this.ToolsBlueItem, "ToolsBlueItem");
            this.ToolsBlueItem.Click += new System.EventHandler(this.ToolsBlueItem_Click);
            // 
            // ToolsWhiteItem
            // 
            this.ToolsWhiteItem.Name = "ToolsWhiteItem";
            resources.ApplyResources(this.ToolsWhiteItem, "ToolsWhiteItem");
            this.ToolsWhiteItem.Click += new System.EventHandler(this.ToolsWhiteItem_Click);
            // 
            // shapesToolStripMenuItem
            // 
            this.shapesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsCircleItem,
            this.ToolsTriangleItem,
            this.ToolsSquareItem,
            this.ToolsRectangleItem});
            this.shapesToolStripMenuItem.Name = "shapesToolStripMenuItem";
            resources.ApplyResources(this.shapesToolStripMenuItem, "shapesToolStripMenuItem");
            // 
            // ToolsCircleItem
            // 
            this.ToolsCircleItem.Name = "ToolsCircleItem";
            resources.ApplyResources(this.ToolsCircleItem, "ToolsCircleItem");
            this.ToolsCircleItem.Click += new System.EventHandler(this.ToolsCircleItem_Click);
            // 
            // ToolsTriangleItem
            // 
            this.ToolsTriangleItem.Name = "ToolsTriangleItem";
            resources.ApplyResources(this.ToolsTriangleItem, "ToolsTriangleItem");
            this.ToolsTriangleItem.Click += new System.EventHandler(this.ToolsTriangleItem_Click);
            // 
            // ToolsSquareItem
            // 
            this.ToolsSquareItem.Name = "ToolsSquareItem";
            resources.ApplyResources(this.ToolsSquareItem, "ToolsSquareItem");
            this.ToolsSquareItem.Click += new System.EventHandler(this.ToolsSquareItem_Click);
            // 
            // ToolsRectangleItem
            // 
            this.ToolsRectangleItem.Name = "ToolsRectangleItem";
            resources.ApplyResources(this.ToolsRectangleItem, "ToolsRectangleItem");
            this.ToolsRectangleItem.Click += new System.EventHandler(this.ToolsRectangleItem_Click);
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
            this.commandListToolStripMenuItem.Click += new System.EventHandler(this.commandListToolStripMenuItem_Click);
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
            this.programmingArea.AcceptsReturn = true;
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
        private System.Windows.Forms.ToolStripMenuItem saveFileStripItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileStripItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coloursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsRedItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsGreenItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsBlueItem;
        private System.Windows.Forms.ToolStripMenuItem shapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsCircleItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsTriangleItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsSquareItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsRectangleItem;
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
        private System.Windows.Forms.ToolStripMenuItem ToolsWhiteItem;
    }

}

