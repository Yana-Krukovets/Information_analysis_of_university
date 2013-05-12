namespace Information_analysis_of_university
{
    partial class MasterQueryBuilding
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataStreamsModel = new System.Windows.Forms.CheckBox();
            this.capacityWorkingPlaces = new System.Windows.Forms.CheckBox();
            this.useCaseModel = new System.Windows.Forms.CheckBox();
            this.WorkProcassModel = new System.Windows.Forms.CheckBox();
            this.responsibilityModel = new System.Windows.Forms.CheckBox();
            this.lifeCycleModel = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Далее";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите модель";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataStreamsModel
            // 
            this.dataStreamsModel.AutoSize = true;
            this.dataStreamsModel.Location = new System.Drawing.Point(15, 49);
            this.dataStreamsModel.Name = "dataStreamsModel";
            this.dataStreamsModel.Size = new System.Drawing.Size(149, 17);
            this.dataStreamsModel.TabIndex = 2;
            this.dataStreamsModel.Text = "Модель потоков данных";
            this.dataStreamsModel.UseVisualStyleBackColor = true;
            // 
            // capacityWorkingPlaces
            // 
            this.capacityWorkingPlaces.AutoSize = true;
            this.capacityWorkingPlaces.Location = new System.Drawing.Point(15, 72);
            this.capacityWorkingPlaces.Name = "capacityWorkingPlaces";
            this.capacityWorkingPlaces.Size = new System.Drawing.Size(210, 17);
            this.capacityWorkingPlaces.TabIndex = 3;
            this.capacityWorkingPlaces.Text = "Модель нагружености рабочих мест";
            this.capacityWorkingPlaces.UseVisualStyleBackColor = true;
            this.capacityWorkingPlaces.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // useCaseModel
            // 
            this.useCaseModel.AutoSize = true;
            this.useCaseModel.Location = new System.Drawing.Point(15, 95);
            this.useCaseModel.Name = "useCaseModel";
            this.useCaseModel.Size = new System.Drawing.Size(202, 17);
            this.useCaseModel.TabIndex = 4;
            this.useCaseModel.Text = "Модель вариантов использования";
            this.useCaseModel.UseVisualStyleBackColor = true;
            // 
            // WorkProcassModel
            // 
            this.WorkProcassModel.AutoSize = true;
            this.WorkProcassModel.Location = new System.Drawing.Point(15, 118);
            this.WorkProcassModel.Name = "WorkProcassModel";
            this.WorkProcassModel.Size = new System.Drawing.Size(165, 17);
            this.WorkProcassModel.TabIndex = 5;
            this.WorkProcassModel.Text = "Модель рабочих процессов";
            this.WorkProcassModel.UseVisualStyleBackColor = true;
            this.WorkProcassModel.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // responsibilityModel
            // 
            this.responsibilityModel.AutoSize = true;
            this.responsibilityModel.Location = new System.Drawing.Point(15, 141);
            this.responsibilityModel.Name = "responsibilityModel";
            this.responsibilityModel.Size = new System.Drawing.Size(219, 17);
            this.responsibilityModel.TabIndex = 6;
            this.responsibilityModel.Text = "Модель распределения обязательств";
            this.responsibilityModel.UseVisualStyleBackColor = true;
            // 
            // lifeCycleModel
            // 
            this.lifeCycleModel.AutoSize = true;
            this.lifeCycleModel.Location = new System.Drawing.Point(15, 164);
            this.lifeCycleModel.Name = "lifeCycleModel";
            this.lifeCycleModel.Size = new System.Drawing.Size(162, 17);
            this.lifeCycleModel.TabIndex = 7;
            this.lifeCycleModel.Text = "Модель жизненного цикла";
            this.lifeCycleModel.UseVisualStyleBackColor = true;
            // 
            // MasterQueryBuilding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lifeCycleModel);
            this.Controls.Add(this.responsibilityModel);
            this.Controls.Add(this.WorkProcassModel);
            this.Controls.Add(this.useCaseModel);
            this.Controls.Add(this.capacityWorkingPlaces);
            this.Controls.Add(this.dataStreamsModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "MasterQueryBuilding";
            this.Text = "MasterQueryBuilding";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox dataStreamsModel;
        private System.Windows.Forms.CheckBox capacityWorkingPlaces;
        private System.Windows.Forms.CheckBox useCaseModel;
        private System.Windows.Forms.CheckBox WorkProcassModel;
        private System.Windows.Forms.CheckBox responsibilityModel;
        private System.Windows.Forms.CheckBox lifeCycleModel;
    }
}