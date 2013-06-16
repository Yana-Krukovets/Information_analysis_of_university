namespace Information_analysis_of_university
{
    partial class PropertyForm<T>
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
            this.documentPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // documentPropertyGrid
            // 
            this.documentPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.documentPropertyGrid.Location = new System.Drawing.Point(1, 1);
            this.documentPropertyGrid.Name = "documentPropertyGrid";
            this.documentPropertyGrid.Size = new System.Drawing.Size(282, 262);
            this.documentPropertyGrid.TabIndex = 0;
            this.documentPropertyGrid.Click += new System.EventHandler(this.documentPropertyGrid_Click);
            // 
            // PropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.documentPropertyGrid);
            this.Name = "PropertyForm";
            this.Text = "Атрибуты объекта";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid documentPropertyGrid;
    }
}