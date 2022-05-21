using SimpleSystemMetrics.Entities;

namespace SimpleSystemMetrics
{
    partial class OverviewForm
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
            this.UsedSystemMemory_Text = new System.Windows.Forms.TextBox();
            this.UsedSystemMemory_Label = new System.Windows.Forms.Label();
            this.AvailableSystemMemory_Label = new System.Windows.Forms.Label();
            this.AvailableSystemMemory_Text = new System.Windows.Forms.TextBox();
            this.TotalSystemMemory_Label = new System.Windows.Forms.Label();
            this.TotalSystemMemory_Text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UsedSystemMemory_Text
            // 
            this.UsedSystemMemory_Text.Location = new System.Drawing.Point(206, 88);
            this.UsedSystemMemory_Text.Name = "UsedSystemMemory_Text";
            this.UsedSystemMemory_Text.Size = new System.Drawing.Size(100, 23);
            this.UsedSystemMemory_Text.TabIndex = 0;
            // 
            // UsedSystemMemory_Label
            // 
            this.UsedSystemMemory_Label.AutoSize = true;
            this.UsedSystemMemory_Label.Location = new System.Drawing.Point(56, 91);
            this.UsedSystemMemory_Label.Name = "UsedSystemMemory_Label";
            this.UsedSystemMemory_Label.Size = new System.Drawing.Size(122, 15);
            this.UsedSystemMemory_Label.TabIndex = 1;
            this.UsedSystemMemory_Label.Text = "Used System Memory";
            // 
            // AvailableSystemMemory_Label
            // 
            this.AvailableSystemMemory_Label.AutoSize = true;
            this.AvailableSystemMemory_Label.Location = new System.Drawing.Point(56, 120);
            this.AvailableSystemMemory_Label.Name = "AvailableSystemMemory_Label";
            this.AvailableSystemMemory_Label.Size = new System.Drawing.Size(144, 15);
            this.AvailableSystemMemory_Label.TabIndex = 3;
            this.AvailableSystemMemory_Label.Text = "Available System Memory";
            // 
            // AvailableSystemMemory_Text
            // 
            this.AvailableSystemMemory_Text.Location = new System.Drawing.Point(206, 117);
            this.AvailableSystemMemory_Text.Name = "AvailableSystemMemory_Text";
            this.AvailableSystemMemory_Text.Size = new System.Drawing.Size(100, 23);
            this.AvailableSystemMemory_Text.TabIndex = 2;
            // 
            // TotalSystemMemory_Label
            // 
            this.TotalSystemMemory_Label.AutoSize = true;
            this.TotalSystemMemory_Label.Location = new System.Drawing.Point(56, 149);
            this.TotalSystemMemory_Label.Name = "TotalSystemMemory_Label";
            this.TotalSystemMemory_Label.Size = new System.Drawing.Size(121, 15);
            this.TotalSystemMemory_Label.TabIndex = 5;
            this.TotalSystemMemory_Label.Text = "Total System Memory";
            // 
            // TotalSystemMemory_Text
            // 
            this.TotalSystemMemory_Text.Location = new System.Drawing.Point(206, 146);
            this.TotalSystemMemory_Text.Name = "TotalSystemMemory_Text";
            this.TotalSystemMemory_Text.Size = new System.Drawing.Size(100, 23);
            this.TotalSystemMemory_Text.TabIndex = 4;
            // 
            // OverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TotalSystemMemory_Label);
            this.Controls.Add(this.TotalSystemMemory_Text);
            this.Controls.Add(this.AvailableSystemMemory_Label);
            this.Controls.Add(this.AvailableSystemMemory_Text);
            this.Controls.Add(this.UsedSystemMemory_Label);
            this.Controls.Add(this.UsedSystemMemory_Text);
            this.Name = "OverviewForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox UsedSystemMemory_Text;
        private Label UsedSystemMemory_Label;
        private Label AvailableSystemMemory_Label;
        private TextBox AvailableSystemMemory_Text;
        private Label TotalSystemMemory_Label;
        private TextBox TotalSystemMemory_Text;

        public void SetMemoryUsageTexts(MemoryMetrics memoryMetrics)
        {
            if (UsedSystemMemory_Text.InvokeRequired == true)
            {
                UsedSystemMemory_Text.Invoke(new Action(() => {
                    UsedSystemMemory_Text.Text = memoryMetrics.Used.ToString();
                }));
            }
            if (AvailableSystemMemory_Text.InvokeRequired == true)
            {
                AvailableSystemMemory_Text.Invoke(new Action(() => {
                    AvailableSystemMemory_Text.Text = memoryMetrics.Free.ToString();
                }));
            }
            if (TotalSystemMemory_Text.InvokeRequired == true)
            {
                TotalSystemMemory_Text.Invoke(new Action(() => {
                    TotalSystemMemory_Text.Text = memoryMetrics.Total.ToString();
                }));
            }
            //UsedSystemMemory_Text.Text = memoryMetrics.Used.ToString();
            //AvailableSystemMemory_Text.Text = memoryMetrics.Free.ToString();
            //TotalSystemMemory_Text.Text = memoryMetrics.Total.ToString();
        }
    }
}