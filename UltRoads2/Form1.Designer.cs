namespace UltRoads2
{
    partial class FolderBrowserDialog
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
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.btnLoadGeoJson = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnDownloadJSON = new System.Windows.Forms.Button();
            this.lblDownloadProgress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadFromAPI = new System.Windows.Forms.Button();
            this.optiGEOJSON = new System.Windows.Forms.Button();
            this.lblOverallProgress = new System.Windows.Forms.Label();
            this.lblSpecificProgress = new System.Windows.Forms.Label();
            this.regionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEliminationCount = new System.Windows.Forms.TextBox();
            this.btnOpti = new System.Windows.Forms.Button();
            this.btnCaptureMapImage = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(2, 3);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(795, 377);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // btnLoadGeoJson
            // 
            this.btnLoadGeoJson.Location = new System.Drawing.Point(848, 519);
            this.btnLoadGeoJson.Name = "btnLoadGeoJson";
            this.btnLoadGeoJson.Size = new System.Drawing.Size(134, 23);
            this.btnLoadGeoJson.TabIndex = 1;
            this.btnLoadGeoJson.Text = "Load GEOJSON";
            this.btnLoadGeoJson.UseVisualStyleBackColor = true;
            this.btnLoadGeoJson.Click += new System.EventHandler(this.btnLoadGeoJson_Click_1);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(848, 484);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(117, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Select file path";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click_1);
            // 
            // btnDownloadJSON
            // 
            this.btnDownloadJSON.Location = new System.Drawing.Point(827, 165);
            this.btnDownloadJSON.Name = "btnDownloadJSON";
            this.btnDownloadJSON.Size = new System.Drawing.Size(119, 23);
            this.btnDownloadJSON.TabIndex = 3;
            this.btnDownloadJSON.Text = "Download from API";
            this.btnDownloadJSON.UseVisualStyleBackColor = true;
            this.btnDownloadJSON.Click += new System.EventHandler(this.btnDownloadJSON_Click);
            // 
            // lblDownloadProgress
            // 
            this.lblDownloadProgress.AutoSize = true;
            this.lblDownloadProgress.Location = new System.Drawing.Point(762, 494);
            this.lblDownloadProgress.Name = "lblDownloadProgress";
            this.lblDownloadProgress.Size = new System.Drawing.Size(57, 13);
            this.lblDownloadProgress.TabIndex = 4;
            this.lblDownloadProgress.Text = "Progress...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(762, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // btnLoadFromAPI
            // 
            this.btnLoadFromAPI.Location = new System.Drawing.Point(538, 494);
            this.btnLoadFromAPI.Name = "btnLoadFromAPI";
            this.btnLoadFromAPI.Size = new System.Drawing.Size(201, 23);
            this.btnLoadFromAPI.TabIndex = 6;
            this.btnLoadFromAPI.Text = "Load GEOJSON from API";
            this.btnLoadFromAPI.UseVisualStyleBackColor = true;
            this.btnLoadFromAPI.Click += new System.EventHandler(this.btnLoadFromAPI_Click);
            // 
            // optiGEOJSON
            // 
            this.optiGEOJSON.Location = new System.Drawing.Point(538, 452);
            this.optiGEOJSON.Name = "optiGEOJSON";
            this.optiGEOJSON.Size = new System.Drawing.Size(75, 23);
            this.optiGEOJSON.TabIndex = 7;
            this.optiGEOJSON.Text = "optimize";
            this.optiGEOJSON.UseVisualStyleBackColor = true;
            this.optiGEOJSON.Click += new System.EventHandler(this.optiGEOJSON_Click);
            // 
            // lblOverallProgress
            // 
            this.lblOverallProgress.AutoSize = true;
            this.lblOverallProgress.Location = new System.Drawing.Point(12, 394);
            this.lblOverallProgress.Name = "lblOverallProgress";
            this.lblOverallProgress.Size = new System.Drawing.Size(93, 13);
            this.lblOverallProgress.TabIndex = 8;
            this.lblOverallProgress.Text = "Overall Progress...";
            // 
            // lblSpecificProgress
            // 
            this.lblSpecificProgress.AutoSize = true;
            this.lblSpecificProgress.Location = new System.Drawing.Point(12, 424);
            this.lblSpecificProgress.Name = "lblSpecificProgress";
            this.lblSpecificProgress.Size = new System.Drawing.Size(88, 13);
            this.lblSpecificProgress.TabIndex = 9;
            this.lblSpecificProgress.Text = "Specific progress";
            // 
            // regionName
            // 
            this.regionName.Location = new System.Drawing.Point(922, 52);
            this.regionName.Name = "regionName";
            this.regionName.Size = new System.Drawing.Size(100, 20);
            this.regionName.TabIndex = 10;
            this.regionName.Text = "Catalunya";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(824, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Region Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(824, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Timeout";
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(922, 91);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(43, 20);
            this.txtTimeout.TabIndex = 13;
            this.txtTimeout.Text = "60";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(814, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Query Info";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(971, 94);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "seconds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(824, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Marker Interval";
            // 
            // txtEliminationCount
            // 
            this.txtEliminationCount.Location = new System.Drawing.Point(922, 129);
            this.txtEliminationCount.Name = "txtEliminationCount";
            this.txtEliminationCount.Size = new System.Drawing.Size(43, 20);
            this.txtEliminationCount.TabIndex = 17;
            this.txtEliminationCount.Text = "1000";
            // 
            // btnOpti
            // 
            this.btnOpti.Location = new System.Drawing.Point(848, 452);
            this.btnOpti.Name = "btnOpti";
            this.btnOpti.Size = new System.Drawing.Size(75, 23);
            this.btnOpti.TabIndex = 18;
            this.btnOpti.Text = "Place Gas";
            this.btnOpti.UseVisualStyleBackColor = true;
            this.btnOpti.Click += new System.EventHandler(this.btnOpti_Click);
            // 
            // btnCaptureMapImage
            // 
            this.btnCaptureMapImage.Location = new System.Drawing.Point(827, 206);
            this.btnCaptureMapImage.Name = "btnCaptureMapImage";
            this.btnCaptureMapImage.Size = new System.Drawing.Size(119, 23);
            this.btnCaptureMapImage.TabIndex = 19;
            this.btnCaptureMapImage.Text = "Capture Image";
            this.btnCaptureMapImage.UseVisualStyleBackColor = true;
            this.btnCaptureMapImage.Click += new System.EventHandler(this.btnCaptureMapImage_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(525, 411);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Debugging Tools";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(525, 424);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(493, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "_________________________________________________________________________________" +
    "";
            // 
            // FolderBrowserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 554);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCaptureMapImage);
            this.Controls.Add(this.btnOpti);
            this.Controls.Add(this.txtEliminationCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTimeout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.regionName);
            this.Controls.Add(this.lblSpecificProgress);
            this.Controls.Add(this.lblOverallProgress);
            this.Controls.Add(this.optiGEOJSON);
            this.Controls.Add(this.btnLoadFromAPI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDownloadProgress);
            this.Controls.Add(this.btnDownloadJSON);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnLoadGeoJson);
            this.Controls.Add(this.gMapControl1);
            this.Name = "FolderBrowserDialog";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Button btnLoadGeoJson;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnDownloadJSON;
        private System.Windows.Forms.Label lblDownloadProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadFromAPI;
        private System.Windows.Forms.Button optiGEOJSON;
        private System.Windows.Forms.Label lblOverallProgress;
        private System.Windows.Forms.Label lblSpecificProgress;
        private System.Windows.Forms.TextBox regionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEliminationCount;
        private System.Windows.Forms.Button btnOpti;
        private System.Windows.Forms.Button btnCaptureMapImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

