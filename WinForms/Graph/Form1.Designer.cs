namespace Graph
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
            this.Plane = new System.Windows.Forms.PictureBox();
            this.AddNodeButton = new System.Windows.Forms.Button();
            this.FromNodeComboBox = new System.Windows.Forms.ComboBox();
            this.NodeNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ToNodeComboBox = new System.Windows.Forms.ComboBox();
            this.AddEdgeButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AlgorithmsComboBox = new System.Windows.Forms.ComboBox();
            this.ComputeAlgorithmButton = new System.Windows.Forms.Button();
            this.RedrawGraphButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.MoveNodeComboBox = new System.Windows.Forms.ComboBox();
            this.MoveNodeButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.WeigthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Plane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeigthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Plane
            // 
            this.Plane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Plane.BackColor = System.Drawing.Color.White;
            this.Plane.Location = new System.Drawing.Point(12, 12);
            this.Plane.Name = "Plane";
            this.Plane.Size = new System.Drawing.Size(751, 674);
            this.Plane.TabIndex = 0;
            this.Plane.TabStop = false;
            this.Plane.Click += new System.EventHandler(this.Plane_Click);
            // 
            // AddNodeButton
            // 
            this.AddNodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNodeButton.Location = new System.Drawing.Point(769, 88);
            this.AddNodeButton.Name = "AddNodeButton";
            this.AddNodeButton.Size = new System.Drawing.Size(161, 29);
            this.AddNodeButton.TabIndex = 1;
            this.AddNodeButton.Text = "Add";
            this.AddNodeButton.UseVisualStyleBackColor = true;
            this.AddNodeButton.Click += new System.EventHandler(this.AddNodeButton_Click);
            // 
            // FromNodeComboBox
            // 
            this.FromNodeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromNodeComboBox.FormattingEnabled = true;
            this.FromNodeComboBox.Location = new System.Drawing.Point(769, 163);
            this.FromNodeComboBox.Name = "FromNodeComboBox";
            this.FromNodeComboBox.Size = new System.Drawing.Size(161, 28);
            this.FromNodeComboBox.TabIndex = 2;
            // 
            // NodeNameTextBox
            // 
            this.NodeNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NodeNameTextBox.Location = new System.Drawing.Point(769, 55);
            this.NodeNameTextBox.Name = "NodeNameTextBox";
            this.NodeNameTextBox.Size = new System.Drawing.Size(161, 27);
            this.NodeNameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(769, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(769, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Edge";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(769, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "From Node";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(769, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "To Node";
            // 
            // ToNodeComboBox
            // 
            this.ToNodeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToNodeComboBox.FormattingEnabled = true;
            this.ToNodeComboBox.Location = new System.Drawing.Point(769, 217);
            this.ToNodeComboBox.Name = "ToNodeComboBox";
            this.ToNodeComboBox.Size = new System.Drawing.Size(161, 28);
            this.ToNodeComboBox.TabIndex = 8;
            // 
            // AddEdgeButton
            // 
            this.AddEdgeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEdgeButton.Location = new System.Drawing.Point(769, 304);
            this.AddEdgeButton.Name = "AddEdgeButton";
            this.AddEdgeButton.Size = new System.Drawing.Size(161, 29);
            this.AddEdgeButton.TabIndex = 9;
            this.AddEdgeButton.Text = "Add";
            this.AddEdgeButton.UseVisualStyleBackColor = true;
            this.AddEdgeButton.Click += new System.EventHandler(this.AddEdgeButton_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(769, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Node";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(769, 336);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Algorithms";
            // 
            // AlgorithmsComboBox
            // 
            this.AlgorithmsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlgorithmsComboBox.FormattingEnabled = true;
            this.AlgorithmsComboBox.Location = new System.Drawing.Point(769, 359);
            this.AlgorithmsComboBox.Name = "AlgorithmsComboBox";
            this.AlgorithmsComboBox.Size = new System.Drawing.Size(161, 28);
            this.AlgorithmsComboBox.TabIndex = 12;
            // 
            // ComputeAlgorithmButton
            // 
            this.ComputeAlgorithmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComputeAlgorithmButton.Location = new System.Drawing.Point(769, 393);
            this.ComputeAlgorithmButton.Name = "ComputeAlgorithmButton";
            this.ComputeAlgorithmButton.Size = new System.Drawing.Size(161, 29);
            this.ComputeAlgorithmButton.TabIndex = 13;
            this.ComputeAlgorithmButton.Text = "Compute";
            this.ComputeAlgorithmButton.UseVisualStyleBackColor = true;
            this.ComputeAlgorithmButton.Click += new System.EventHandler(this.ComputeAlgorithmButton_Click);
            // 
            // RedrawGraphButton
            // 
            this.RedrawGraphButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RedrawGraphButton.Location = new System.Drawing.Point(769, 657);
            this.RedrawGraphButton.Name = "RedrawGraphButton";
            this.RedrawGraphButton.Size = new System.Drawing.Size(161, 29);
            this.RedrawGraphButton.TabIndex = 14;
            this.RedrawGraphButton.Text = "Redraw Graph";
            this.RedrawGraphButton.UseVisualStyleBackColor = true;
            this.RedrawGraphButton.Click += new System.EventHandler(this.RedrawGraphButton_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(769, 425);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Move Node";
            // 
            // MoveNodeComboBox
            // 
            this.MoveNodeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveNodeComboBox.FormattingEnabled = true;
            this.MoveNodeComboBox.Location = new System.Drawing.Point(769, 448);
            this.MoveNodeComboBox.Name = "MoveNodeComboBox";
            this.MoveNodeComboBox.Size = new System.Drawing.Size(161, 28);
            this.MoveNodeComboBox.TabIndex = 16;
            // 
            // MoveNodeButton
            // 
            this.MoveNodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveNodeButton.Location = new System.Drawing.Point(769, 482);
            this.MoveNodeButton.Name = "MoveNodeButton";
            this.MoveNodeButton.Size = new System.Drawing.Size(161, 29);
            this.MoveNodeButton.TabIndex = 17;
            this.MoveNodeButton.Text = "Move";
            this.MoveNodeButton.UseVisualStyleBackColor = true;
            this.MoveNodeButton.Click += new System.EventHandler(this.MoveNodeButton_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(769, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Weigth";
            // 
            // WeigthNumericUpDown
            // 
            this.WeigthNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WeigthNumericUpDown.DecimalPlaces = 3;
            this.WeigthNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.WeigthNumericUpDown.Location = new System.Drawing.Point(769, 271);
            this.WeigthNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.WeigthNumericUpDown.Name = "WeigthNumericUpDown";
            this.WeigthNumericUpDown.Size = new System.Drawing.Size(161, 27);
            this.WeigthNumericUpDown.TabIndex = 19;
            this.WeigthNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 698);
            this.Controls.Add(this.WeigthNumericUpDown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.MoveNodeButton);
            this.Controls.Add(this.MoveNodeComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RedrawGraphButton);
            this.Controls.Add(this.ComputeAlgorithmButton);
            this.Controls.Add(this.AlgorithmsComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AddEdgeButton);
            this.Controls.Add(this.ToNodeComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NodeNameTextBox);
            this.Controls.Add(this.FromNodeComboBox);
            this.Controls.Add(this.AddNodeButton);
            this.Controls.Add(this.Plane);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Plane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeigthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox Plane;
        private Button AddNodeButton;
        private ComboBox FromNodeComboBox;
        private TextBox NodeNameTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox ToNodeComboBox;
        private Button AddEdgeButton;
        private Label label5;
        private Label label6;
        private ComboBox AlgorithmsComboBox;
        private Button ComputeAlgorithmButton;
        private Button RedrawGraphButton;
        private Label label7;
        private ComboBox MoveNodeComboBox;
        private Button MoveNodeButton;
        private Label label8;
        private NumericUpDown WeigthNumericUpDown;
    }
}