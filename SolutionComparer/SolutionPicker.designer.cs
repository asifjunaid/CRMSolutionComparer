namespace CRMSolutionComparer
{
    partial class SolutionPicker
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
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilter
            // 
            this.txtFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilter.Location = new System.Drawing.Point(44, 0);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(378, 20);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lvSolutions
            // 
            this.lvSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSolutions.FullRowSelect = true;
            this.lvSolutions.HideSelection = false;
            this.lvSolutions.Location = new System.Drawing.Point(0, 19);
            this.lvSolutions.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(422, 352);
            this.lvSolutions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSolutions.TabIndex = 2;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
            this.lvSolutions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvSolutions_ColumnClick);
            this.lvSolutions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LvSolutions_ColumnClick);
            this.lvSolutions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSolutions_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Display name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Publisher";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Installed date";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Version";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.txtFilter);
            this.pnlHeader.Controls.Add(this.lblFilter);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(422, 19);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblFilter
            // 
            this.lblFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFilter.Location = new System.Drawing.Point(0, 0);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(44, 19);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SolutionPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvSolutions);
            this.Controls.Add(this.pnlHeader);
            this.Name = "SolutionPicker";
            this.Size = new System.Drawing.Size(422, 371);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFilter;
    }
}
