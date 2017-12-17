namespace MyFacebookApp
{
    public partial class CheckInOnMapForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInOnMapForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CheckInLinkLabel = new System.Windows.Forms.LinkLabel();
            this.ModeGroupBox = new System.Windows.Forms.GroupBox();
            this.AllCheckInsRadioButton = new System.Windows.Forms.RadioButton();
            this.SingleCheckInRadioButton = new System.Windows.Forms.RadioButton();
            this.ShowLocationButton = new System.Windows.Forms.Button();
            this.CurrentCheckInPictureBox = new System.Windows.Forms.PictureBox();
            this.DesiredCheckInLabel = new System.Windows.Forms.Label();
            this.CheckInsListBox = new System.Windows.Forms.ListBox();
            this.CheckInGMapControl = new GMap.NET.WindowsForms.GMapControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ModeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentCheckInPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.CheckInLinkLabel);
            this.splitContainer1.Panel1.Controls.Add(this.ModeGroupBox);
            this.splitContainer1.Panel1.Controls.Add(this.ShowLocationButton);
            this.splitContainer1.Panel1.Controls.Add(this.CurrentCheckInPictureBox);
            this.splitContainer1.Panel1.Controls.Add(this.DesiredCheckInLabel);
            this.splitContainer1.Panel1.Controls.Add(this.CheckInsListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CheckInGMapControl);
            this.splitContainer1.Size = new System.Drawing.Size(1185, 714);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(31, 630);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 80);
            this.label1.TabIndex = 25;
            this.label1.Text = "Press on event from list to see details";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MyFacebookApp.Properties.Resources.Info;
            this.pictureBox1.Location = new System.Drawing.Point(4, 611);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // CheckInLinkLabel
            // 
            this.CheckInLinkLabel.AutoSize = true;
            this.CheckInLinkLabel.Location = new System.Drawing.Point(28, 658);
            this.CheckInLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CheckInLinkLabel.Name = "CheckInLinkLabel";
            this.CheckInLinkLabel.Size = new System.Drawing.Size(12, 17);
            this.CheckInLinkLabel.TabIndex = 5;
            this.CheckInLinkLabel.TabStop = true;
            this.CheckInLinkLabel.Text = ".";
            this.CheckInLinkLabel.Click += new System.EventHandler(this.checkInLinkLabel_Click);
            // 
            // ModeGroupBox
            // 
            this.ModeGroupBox.Controls.Add(this.AllCheckInsRadioButton);
            this.ModeGroupBox.Controls.Add(this.SingleCheckInRadioButton);
            this.ModeGroupBox.Location = new System.Drawing.Point(29, 30);
            this.ModeGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ModeGroupBox.Name = "ModeGroupBox";
            this.ModeGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ModeGroupBox.Size = new System.Drawing.Size(331, 90);
            this.ModeGroupBox.TabIndex = 4;
            this.ModeGroupBox.TabStop = false;
            this.ModeGroupBox.Text = "Mode:";
            // 
            // AllCheckInsRadioButton
            // 
            this.AllCheckInsRadioButton.AutoSize = true;
            this.AllCheckInsRadioButton.Checked = true;
            this.AllCheckInsRadioButton.Location = new System.Drawing.Point(9, 53);
            this.AllCheckInsRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AllCheckInsRadioButton.Name = "AllCheckInsRadioButton";
            this.AllCheckInsRadioButton.Size = new System.Drawing.Size(109, 21);
            this.AllCheckInsRadioButton.TabIndex = 1;
            this.AllCheckInsRadioButton.TabStop = true;
            this.AllCheckInsRadioButton.Text = "All Check Ins";
            this.AllCheckInsRadioButton.UseVisualStyleBackColor = true;
            // 
            // SingleCheckInRadioButton
            // 
            this.SingleCheckInRadioButton.AutoSize = true;
            this.SingleCheckInRadioButton.Location = new System.Drawing.Point(9, 25);
            this.SingleCheckInRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SingleCheckInRadioButton.Name = "SingleCheckInRadioButton";
            this.SingleCheckInRadioButton.Size = new System.Drawing.Size(126, 21);
            this.SingleCheckInRadioButton.TabIndex = 0;
            this.SingleCheckInRadioButton.Text = "Single Check In";
            this.SingleCheckInRadioButton.UseVisualStyleBackColor = true;
            // 
            // ShowLocationButton
            // 
            this.ShowLocationButton.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowLocationButton.Location = new System.Drawing.Point(175, 431);
            this.ShowLocationButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ShowLocationButton.Name = "ShowLocationButton";
            this.ShowLocationButton.Size = new System.Drawing.Size(201, 52);
            this.ShowLocationButton.TabIndex = 3;
            this.ShowLocationButton.Text = "Show Location!";
            this.ShowLocationButton.UseVisualStyleBackColor = true;
            this.ShowLocationButton.Click += new System.EventHandler(this.showLocationButton_Click);
            // 
            // CurrentCheckInPictureBox
            // 
            this.CurrentCheckInPictureBox.Location = new System.Drawing.Point(175, 490);
            this.CurrentCheckInPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CurrentCheckInPictureBox.Name = "CurrentCheckInPictureBox";
            this.CurrentCheckInPictureBox.Size = new System.Drawing.Size(201, 127);
            this.CurrentCheckInPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CurrentCheckInPictureBox.TabIndex = 2;
            this.CurrentCheckInPictureBox.TabStop = false;
            // 
            // DesiredCheckInLabel
            // 
            this.DesiredCheckInLabel.AutoSize = true;
            this.DesiredCheckInLabel.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesiredCheckInLabel.Location = new System.Drawing.Point(16, 130);
            this.DesiredCheckInLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DesiredCheckInLabel.Name = "DesiredCheckInLabel";
            this.DesiredCheckInLabel.Size = new System.Drawing.Size(269, 30);
            this.DesiredCheckInLabel.TabIndex = 1;
            this.DesiredCheckInLabel.Text = "Choose your desired check in:";
            // 
            // CheckInsListBox
            // 
            this.CheckInsListBox.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckInsListBox.FormattingEnabled = true;
            this.CheckInsListBox.ItemHeight = 28;
            this.CheckInsListBox.Location = new System.Drawing.Point(16, 164);
            this.CheckInsListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckInsListBox.Name = "CheckInsListBox";
            this.CheckInsListBox.Size = new System.Drawing.Size(359, 256);
            this.CheckInsListBox.TabIndex = 0;
            // 
            // CheckInGMapControl
            // 
            this.CheckInGMapControl.Bearing = 0F;
            this.CheckInGMapControl.CanDragMap = true;
            this.CheckInGMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.CheckInGMapControl.GrayScaleMode = false;
            this.CheckInGMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.CheckInGMapControl.LevelsKeepInMemmory = 5;
            this.CheckInGMapControl.Location = new System.Drawing.Point(4, 0);
            this.CheckInGMapControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckInGMapControl.MarkersEnabled = true;
            this.CheckInGMapControl.MaxZoom = 18;
            this.CheckInGMapControl.MinZoom = 0;
            this.CheckInGMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.CheckInGMapControl.Name = "CheckInGMapControl";
            this.CheckInGMapControl.NegativeMode = false;
            this.CheckInGMapControl.PolygonsEnabled = true;
            this.CheckInGMapControl.RetryLoadTile = 0;
            this.CheckInGMapControl.RoutesEnabled = true;
            this.CheckInGMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.CheckInGMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.CheckInGMapControl.ShowTileGridLines = false;
            this.CheckInGMapControl.Size = new System.Drawing.Size(781, 710);
            this.CheckInGMapControl.TabIndex = 0;
            this.CheckInGMapControl.Zoom = 10D;
            // 
            // CheckInOnMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 714);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CheckInOnMapForm";
            this.Text = "Check Ins On Map";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.checkInOnMapForm_FormClosing);
            this.Load += new System.EventHandler(this.checkInOnMapForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ModeGroupBox.ResumeLayout(false);
            this.ModeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentCheckInPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox CurrentCheckInPictureBox;
        private System.Windows.Forms.Label DesiredCheckInLabel;
        private System.Windows.Forms.ListBox CheckInsListBox;
        private GMap.NET.WindowsForms.GMapControl CheckInGMapControl;
        private System.Windows.Forms.Button ShowLocationButton;
        private System.Windows.Forms.GroupBox ModeGroupBox;
        private System.Windows.Forms.RadioButton AllCheckInsRadioButton;
        private System.Windows.Forms.RadioButton SingleCheckInRadioButton;
        private System.Windows.Forms.LinkLabel CheckInLinkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}