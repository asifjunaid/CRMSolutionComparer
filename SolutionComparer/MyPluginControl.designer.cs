namespace CRMSolutionComparer
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnectToDest = new System.Windows.Forms.Button();
            this.lblDestination = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdDefaultSolutionBtn = new System.Windows.Forms.RadioButton();
            this.rdCustomSolutionBtn = new System.Windows.Forms.RadioButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCompare = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sourceSolutionPicker = new CRMSolutionComparer.SolutionPicker();
            this.targetSolutionPicker = new CRMSolutionComparer.SolutionPicker();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.rdCompareLocalSolution = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtBrowseSource = new System.Windows.Forms.TextBox();
            this.btnBrowserSource = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowseTarget = new System.Windows.Forms.Button();
            this.txtBrowseTarget = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnectToDest
            // 
            this.btnConnectToDest.Location = new System.Drawing.Point(3, 5);
            this.btnConnectToDest.Name = "btnConnectToDest";
            this.btnConnectToDest.Size = new System.Drawing.Size(151, 23);
            this.btnConnectToDest.TabIndex = 5;
            this.btnConnectToDest.Text = "Connect To Target";
            this.btnConnectToDest.UseVisualStyleBackColor = true;
            this.btnConnectToDest.Click += new System.EventHandler(this.btnConnectToDest_Click);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestination.Location = new System.Drawing.Point(157, 10);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(184, 13);
            this.lblDestination.TabIndex = 6;
            this.lblDestination.Text = "Target Organization Connected";
            this.lblDestination.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Source Solution";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Target Solution";
            // 
            // rdDefaultSolutionBtn
            // 
            this.rdDefaultSolutionBtn.AutoSize = true;
            this.rdDefaultSolutionBtn.Location = new System.Drawing.Point(12, 34);
            this.rdDefaultSolutionBtn.Name = "rdDefaultSolutionBtn";
            this.rdDefaultSolutionBtn.Size = new System.Drawing.Size(150, 17);
            this.rdDefaultSolutionBtn.TabIndex = 11;
            this.rdDefaultSolutionBtn.Text = "Compare Default Solutions";
            this.rdDefaultSolutionBtn.UseVisualStyleBackColor = true;
            this.rdDefaultSolutionBtn.CheckedChanged += new System.EventHandler(this.rdSolutionBtn_CheckedChanged);
            // 
            // rdCustomSolutionBtn
            // 
            this.rdCustomSolutionBtn.AutoSize = true;
            this.rdCustomSolutionBtn.Checked = true;
            this.rdCustomSolutionBtn.Location = new System.Drawing.Point(162, 34);
            this.rdCustomSolutionBtn.Name = "rdCustomSolutionBtn";
            this.rdCustomSolutionBtn.Size = new System.Drawing.Size(151, 17);
            this.rdCustomSolutionBtn.TabIndex = 12;
            this.rdCustomSolutionBtn.TabStop = true;
            this.rdCustomSolutionBtn.Text = "Compare Custom Solutions";
            this.rdCustomSolutionBtn.UseVisualStyleBackColor = true;
            this.rdCustomSolutionBtn.CheckedChanged += new System.EventHandler(this.rdSolutionBtn_CheckedChanged);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(862, 155);
            this.listView1.TabIndex = 16;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Activity";
            this.columnHeader1.Width = 600;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(486, 28);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(151, 23);
            this.btnCompare.TabIndex = 19;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 519);
            this.splitter1.TabIndex = 20;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sourceSolutionPicker);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.targetSolutionPicker);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(862, 256);
            this.splitContainer1.SplitterDistance = 426;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 21;
            // 
            // sourceSolutionPicker
            // 
            this.sourceSolutionPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceSolutionPicker.CanDisplayManagedSolutions = false;
            this.sourceSolutionPicker.Location = new System.Drawing.Point(3, 19);
            this.sourceSolutionPicker.Name = "sourceSolutionPicker";
            this.sourceSolutionPicker.Size = new System.Drawing.Size(420, 234);
            this.sourceSolutionPicker.TabIndex = 17;
            // 
            // targetSolutionPicker
            // 
            this.targetSolutionPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetSolutionPicker.CanDisplayManagedSolutions = false;
            this.targetSolutionPicker.Location = new System.Drawing.Point(3, 19);
            this.targetSolutionPicker.Name = "targetSolutionPicker";
            this.targetSolutionPicker.Size = new System.Drawing.Size(435, 234);
            this.targetSolutionPicker.TabIndex = 18;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(1, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 519);
            this.splitter2.TabIndex = 22;
            this.splitter2.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(9, 98);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listView1);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(868, 418);
            this.splitContainer2.SplitterDistance = 262;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 23;
            // 
            // rdCompareLocalSolution
            // 
            this.rdCompareLocalSolution.AutoSize = true;
            this.rdCompareLocalSolution.Location = new System.Drawing.Point(319, 34);
            this.rdCompareLocalSolution.Name = "rdCompareLocalSolution";
            this.rdCompareLocalSolution.Size = new System.Drawing.Size(161, 17);
            this.rdCompareLocalSolution.TabIndex = 24;
            this.rdCompareLocalSolution.Text = "Compare  Exported Solutions";
            this.rdCompareLocalSolution.UseVisualStyleBackColor = true;
            this.rdCompareLocalSolution.CheckedChanged += new System.EventHandler(this.rdSolutionBtn_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtBrowseSource
            // 
            this.txtBrowseSource.Enabled = false;
            this.txtBrowseSource.Location = new System.Drawing.Point(137, 53);
            this.txtBrowseSource.Name = "txtBrowseSource";
            this.txtBrowseSource.Size = new System.Drawing.Size(466, 20);
            this.txtBrowseSource.TabIndex = 25;
            // 
            // btnBrowserSource
            // 
            this.btnBrowserSource.Enabled = false;
            this.btnBrowserSource.Location = new System.Drawing.Point(607, 53);
            this.btnBrowserSource.Name = "btnBrowserSource";
            this.btnBrowserSource.Size = new System.Drawing.Size(32, 21);
            this.btnBrowserSource.TabIndex = 26;
            this.btnBrowserSource.Text = "...";
            this.btnBrowserSource.UseVisualStyleBackColor = true;
            this.btnBrowserSource.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Browse Source Solution";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Browse Target Solution";
            // 
            // btnBrowseTarget
            // 
            this.btnBrowseTarget.Enabled = false;
            this.btnBrowseTarget.Location = new System.Drawing.Point(607, 75);
            this.btnBrowseTarget.Name = "btnBrowseTarget";
            this.btnBrowseTarget.Size = new System.Drawing.Size(32, 20);
            this.btnBrowseTarget.TabIndex = 29;
            this.btnBrowseTarget.Text = "...";
            this.btnBrowseTarget.UseVisualStyleBackColor = true;
            this.btnBrowseTarget.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtBrowseTarget
            // 
            this.txtBrowseTarget.Enabled = false;
            this.txtBrowseTarget.Location = new System.Drawing.Point(137, 75);
            this.txtBrowseTarget.Name = "txtBrowseTarget";
            this.txtBrowseTarget.Size = new System.Drawing.Size(466, 20);
            this.txtBrowseTarget.TabIndex = 28;
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBrowseTarget);
            this.Controls.Add(this.txtBrowseTarget);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowserSource);
            this.Controls.Add(this.txtBrowseSource);
            this.Controls.Add(this.rdCompareLocalSolution);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.rdCustomSolutionBtn);
            this.Controls.Add(this.rdDefaultSolutionBtn);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.btnConnectToDest);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(880, 519);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnectToDest;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdDefaultSolutionBtn;
        private System.Windows.Forms.RadioButton rdCustomSolutionBtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private SolutionPicker sourceSolutionPicker;
        private SolutionPicker targetSolutionPicker;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RadioButton rdCompareLocalSolution;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtBrowseSource;
        private System.Windows.Forms.Button btnBrowserSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrowseTarget;
        private System.Windows.Forms.TextBox txtBrowseTarget;
    }
}
