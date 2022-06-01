namespace SubscriberCounterDeskBand
{
    partial class BandControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.avatarPic = new System.Windows.Forms.PictureBox();
            this.infoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPic)).BeginInit();
            this.SuspendLayout();
            // 
            // avatarPic
            // 
            this.avatarPic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.avatarPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.avatarPic.Location = new System.Drawing.Point(0, 0);
            this.avatarPic.Name = "avatarPic";
            this.avatarPic.Size = new System.Drawing.Size(36, 36);
            this.avatarPic.TabIndex = 0;
            this.avatarPic.TabStop = false;
            // 
            // infoLabel
            // 
            this.infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.Location = new System.Drawing.Point(36, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(92, 36);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "{0}\r\n{1} Subs";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BandControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.avatarPic);
            this.Name = "BandControl";
            this.Size = new System.Drawing.Size(128, 36);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.PictureBox avatarPic;
        public System.Windows.Forms.Label infoLabel;
    }
}
