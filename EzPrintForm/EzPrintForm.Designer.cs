namespace EzPrintForm
{
    partial class EzPaintForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveToGoogleDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._printPanel = new EzPrintForm.DoubleBufferedPanel();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._undoToolStripMenuItem,
            this._redoToolStripMenuItem,
            this._rectangleToolStripMenuItem,
            this._triangleToolStripMenuItem,
            this._circleToolStripMenuItem,
            this._lineToolStripMenuItem,
            this._saveToolStripMenuItem,
            this._saveToGoogleDriveToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(1008, 30);
            this._menuStrip.TabIndex = 0;
            this._menuStrip.Text = "menuStrip";
            // 
            // _undoToolStripMenuItem
            // 
            this._undoToolStripMenuItem.Name = "_undoToolStripMenuItem";
            this._undoToolStripMenuItem.Size = new System.Drawing.Size(67, 26);
            this._undoToolStripMenuItem.Text = "Undo";
            this._undoToolStripMenuItem.Click += new System.EventHandler(this.ClickUndoToolStripMenuItem);
            // 
            // _redoToolStripMenuItem
            // 
            this._redoToolStripMenuItem.Name = "_redoToolStripMenuItem";
            this._redoToolStripMenuItem.Size = new System.Drawing.Size(65, 26);
            this._redoToolStripMenuItem.Text = "Redo";
            this._redoToolStripMenuItem.Click += new System.EventHandler(this.ClickRedoToolStripMenuItem);
            // 
            // _rectangleToolStripMenuItem
            // 
            this._rectangleToolStripMenuItem.Name = "_rectangleToolStripMenuItem";
            this._rectangleToolStripMenuItem.Size = new System.Drawing.Size(101, 26);
            this._rectangleToolStripMenuItem.Text = "Rectangle";
            this._rectangleToolStripMenuItem.Click += new System.EventHandler(this.ClickRectangleToolStripMenuItem);
            // 
            // _triangleToolStripMenuItem
            // 
            this._triangleToolStripMenuItem.Name = "_triangleToolStripMenuItem";
            this._triangleToolStripMenuItem.Size = new System.Drawing.Size(86, 26);
            this._triangleToolStripMenuItem.Text = "Triangle";
            this._triangleToolStripMenuItem.Click += new System.EventHandler(this.ClickTriangleToolStripMenuItem);
            // 
            // _circleToolStripMenuItem
            // 
            this._circleToolStripMenuItem.Name = "_circleToolStripMenuItem";
            this._circleToolStripMenuItem.Size = new System.Drawing.Size(65, 26);
            this._circleToolStripMenuItem.Text = "Circle";
            this._circleToolStripMenuItem.Click += new System.EventHandler(this.ClickCircleToolStripMenuItem);
            // 
            // _lineToolStripMenuItem
            // 
            this._lineToolStripMenuItem.Name = "_lineToolStripMenuItem";
            this._lineToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this._lineToolStripMenuItem.Text = "Line";
            this._lineToolStripMenuItem.Click += new System.EventHandler(this.ClickLineToolStripMenuItem);
            // 
            // _saveToolStripMenuItem
            // 
            this._saveToolStripMenuItem.Name = "_saveToolStripMenuItem";
            this._saveToolStripMenuItem.Size = new System.Drawing.Size(60, 26);
            this._saveToolStripMenuItem.Text = "Save";
            this._saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // _saveToGoogleDriveToolStripMenuItem
            // 
            this._saveToGoogleDriveToolStripMenuItem.Name = "_saveToGoogleDriveToolStripMenuItem";
            this._saveToGoogleDriveToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this._saveToGoogleDriveToolStripMenuItem.Text = "Upload to Google Drive";
            this._saveToGoogleDriveToolStripMenuItem.Click += new System.EventHandler(this.ClickSaveToGoogleDriveToolStripMenuItem);
            // 
            // _printPanel
            // 
            this._printPanel.BackColor = System.Drawing.Color.White;
            this._printPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._printPanel.Location = new System.Drawing.Point(0, 30);
            this._printPanel.Name = "_printPanel";
            this._printPanel.Size = new System.Drawing.Size(1008, 699);
            this._printPanel.TabIndex = 1;
            this._printPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PrintPanelPaint);
            this._printPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PrintPanelMouseDown);
            this._printPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PrintPanelMouseMove);
            this._printPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PrintPanelMouseUp);
            // 
            // EzPaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this._printPanel);
            this.Controls.Add(this._menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this._menuStrip;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "EzPaintForm";
            this.Text = "EzPaintForm";
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _triangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveToolStripMenuItem;
        private DoubleBufferedPanel _printPanel;
        private System.Windows.Forms.ToolStripMenuItem _lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveToGoogleDriveToolStripMenuItem;
    }
}

