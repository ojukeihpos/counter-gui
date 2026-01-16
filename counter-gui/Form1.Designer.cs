namespace yt_dlp_gui
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            addButton = new Button();
            subtractButton = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            changeBackgroundColourToolStripMenuItem = new ToolStripMenuItem();
            changeTextColourToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            panel1 = new Panel();
            colorDialog1 = new ColorDialog();
            loadFileButton = new Button();
            label2 = new Label();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.Location = new Point(320, 54);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 94);
            addButton.TabIndex = 0;
            addButton.Text = "+";
            addButton.UseVisualStyleBackColor = true;
            addButton.MouseDown += addButton_MouseDown;
            // 
            // subtractButton
            // 
            subtractButton.Location = new Point(320, 154);
            subtractButton.Name = "subtractButton";
            subtractButton.Size = new Size(75, 116);
            subtractButton.TabIndex = 1;
            subtractButton.Text = "-";
            subtractButton.UseVisualStyleBackColor = true;
            subtractButton.MouseDown += subtractButton_MouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { changeBackgroundColourToolStripMenuItem, changeTextColourToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(220, 48);
            contextMenuStrip1.ItemClicked += contextMenuStrip1_ItemClicked;
            // 
            // changeBackgroundColourToolStripMenuItem
            // 
            changeBackgroundColourToolStripMenuItem.Name = "changeBackgroundColourToolStripMenuItem";
            changeBackgroundColourToolStripMenuItem.Size = new Size(219, 22);
            changeBackgroundColourToolStripMenuItem.Text = "Change background colour";
            // 
            // changeTextColourToolStripMenuItem
            // 
            changeTextColourToolStripMenuItem.Name = "changeTextColourToolStripMenuItem";
            changeTextColourToolStripMenuItem.Size = new Size(219, 22);
            changeTextColourToolStripMenuItem.Text = "Change text colour";
            // 
            // label1
            // 
            label1.Font = new Font("Noto Sans JP", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(256, 215);
            label1.TabIndex = 3;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.ContextMenuStrip = contextMenuStrip1;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(58, 54);
            panel1.Name = "panel1";
            panel1.Size = new Size(256, 215);
            panel1.TabIndex = 4;
            // 
            // loadFileButton
            // 
            loadFileButton.Location = new Point(320, 25);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(75, 23);
            loadFileButton.TabIndex = 5;
            loadFileButton.Text = "Load File";
            loadFileButton.UseVisualStyleBackColor = true;
            loadFileButton.MouseDown += loadFileButton_MouseDown;
            // 
            // label2
            // 
            label2.Location = new Point(58, 25);
            label2.Name = "label2";
            label2.Size = new Size(256, 23);
            label2.TabIndex = 6;
            label2.Text = "label2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 307);
            Controls.Add(label2);
            Controls.Add(loadFileButton);
            Controls.Add(panel1);
            Controls.Add(subtractButton);
            Controls.Add(addButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Hakurei Counter";
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button addButton;
        private Button subtractButton;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private Panel panel1;
        private ColorDialog colorDialog1;
        private ToolStripMenuItem changeBackgroundColourToolStripMenuItem;
        private ToolStripMenuItem changeTextColourToolStripMenuItem;
        private Button loadFileButton;
        private Label label2;
    }
}
