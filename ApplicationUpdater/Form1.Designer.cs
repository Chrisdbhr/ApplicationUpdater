namespace ApplicationUpdater
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
			this.launcherLogo_pictureBox = new System.Windows.Forms.PictureBox();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnPlay = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label_notRunningAsAdm = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.launcherLogo_pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// launcherLogo_pictureBox
			// 
			this.launcherLogo_pictureBox.BackColor = System.Drawing.Color.Transparent;
			this.launcherLogo_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.launcherLogo_pictureBox.Location = new System.Drawing.Point(0, 0);
			this.launcherLogo_pictureBox.Name = "launcherLogo_pictureBox";
			this.launcherLogo_pictureBox.Size = new System.Drawing.Size(227, 112);
			this.launcherLogo_pictureBox.TabIndex = 0;
			this.launcherLogo_pictureBox.TabStop = false;
			this.launcherLogo_pictureBox.Click += new System.EventHandler(this.PictureBox1_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(569, 219);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(110, 33);
			this.btnUpdate.TabIndex = 2;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// btnPlay
			// 
			this.btnPlay.Location = new System.Drawing.Point(569, 258);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(110, 33);
			this.btnPlay.TabIndex = 3;
			this.btnPlay.Text = "Play";
			this.btnPlay.UseVisualStyleBackColor = true;
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.label2.Location = new System.Drawing.Point(72, 339);
			this.label2.Name = "label2";
			this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label2.Size = new System.Drawing.Size(22, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "1.0";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.label3.Location = new System.Drawing.Point(12, 339);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Launcher";
			// 
			// label_notRunningAsAdm
			// 
			this.label_notRunningAsAdm.AutoSize = true;
			this.label_notRunningAsAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label_notRunningAsAdm.ForeColor = System.Drawing.Color.Red;
			this.label_notRunningAsAdm.Location = new System.Drawing.Point(492, 9);
			this.label_notRunningAsAdm.Name = "label_notRunningAsAdm";
			this.label_notRunningAsAdm.Size = new System.Drawing.Size(187, 17);
			this.label_notRunningAsAdm.TabIndex = 6;
			this.label_notRunningAsAdm.Text = "Not running as administrator";
			this.label_notRunningAsAdm.Visible = false;
			this.label_notRunningAsAdm.Click += new System.EventHandler(this.label_notRunningAsAdm_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(693, 361);
			this.Controls.Add(this.label_notRunningAsAdm);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnPlay);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.launcherLogo_pictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Application Launcher and Updater";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.launcherLogo_pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox launcherLogo_pictureBox;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label_notRunningAsAdm;
	}
}

