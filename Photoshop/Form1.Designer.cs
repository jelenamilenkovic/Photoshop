namespace Photoshop
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Load = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kanalskeSlikeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Filter_Grayscale = new System.Windows.Forms.ToolStripMenuItem();
            this.Smooth = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_inplace = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_simplysmooth = new System.Windows.Forms.ToolStripMenuItem();
            this.Color = new System.Windows.Forms.ToolStripMenuItem();
            this.EdgeDetectVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.Filter_Swirl = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_sierraDithering = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_crossdomain = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_orderedDithering = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_kuwahara = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_simpleColorize = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_xGray = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_histogram = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_unificationOfColor = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_compression = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.maxValueOfMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Zoom25 = new System.Windows.Forms.ToolStripMenuItem();
            this.Zoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.Zoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox = new System.Windows.Forms.TextBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.zoomToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(969, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(127, 484);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.UseWaitCursor = true;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_Load,
            this.File_Save,
            this.File_Exit});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(67, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // File_Load
            // 
            this.File_Load.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.File_Load.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.File_Load.Name = "File_Load";
            this.File_Load.Size = new System.Drawing.Size(110, 22);
            this.File_Load.Text = "Load";
            this.File_Load.Click += new System.EventHandler(this.File_Load_Click);
            // 
            // File_Save
            // 
            this.File_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.File_Save.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.File_Save.Name = "File_Save";
            this.File_Save.Size = new System.Drawing.Size(110, 22);
            this.File_Save.Text = "Save";
            this.File_Save.Click += new System.EventHandler(this.File_Save_Click);
            // 
            // File_Exit
            // 
            this.File_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.File_Exit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.File_Exit.Name = "File_Exit";
            this.File_Exit.Size = new System.Drawing.Size(110, 22);
            this.File_Exit.Text = "Exit";
            this.File_Exit.Click += new System.EventHandler(this.File_Exit_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kanalskeSlikeToolStripMenuItem,
            this.Filter_Grayscale,
            this.Smooth,
            this.Color,
            this.EdgeDetectVertical,
            this.Filter_Swirl,
            this.btn_sierraDithering,
            this.btn_crossdomain,
            this.btn_orderedDithering,
            this.btn_kuwahara,
            this.btn_simpleColorize,
            this.btn_xGray});
            this.filtersToolStripMenuItem.Font = new System.Drawing.Font("Ravie", 8.25F);
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(112, 21);
            this.filtersToolStripMenuItem.Text = "Filters";
            this.filtersToolStripMenuItem.Click += new System.EventHandler(this.filtersToolStripMenuItem_Click);
            // 
            // kanalskeSlikeToolStripMenuItem
            // 
            this.kanalskeSlikeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.kanalskeSlikeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.kanalskeSlikeToolStripMenuItem.Name = "kanalskeSlikeToolStripMenuItem";
            this.kanalskeSlikeToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.kanalskeSlikeToolStripMenuItem.Text = "Channel separation/View 2";
            this.kanalskeSlikeToolStripMenuItem.Click += new System.EventHandler(this.kanalskeSlikeToolStripMenuItem_Click);
            // 
            // Filter_Grayscale
            // 
            this.Filter_Grayscale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.Filter_Grayscale.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Filter_Grayscale.Name = "Filter_Grayscale";
            this.Filter_Grayscale.Size = new System.Drawing.Size(221, 22);
            this.Filter_Grayscale.Text = "Grayscale";
            this.Filter_Grayscale.Click += new System.EventHandler(this.Filter_Grayscale_Click);
            // 
            // Smooth
            // 
            this.Smooth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.Smooth.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_inplace,
            this.btn_simplysmooth});
            this.Smooth.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Smooth.Name = "Smooth";
            this.Smooth.Size = new System.Drawing.Size(221, 22);
            this.Smooth.Text = "Smoth";
            this.Smooth.Click += new System.EventHandler(this.Smooth_Click);
            // 
            // btn_inplace
            // 
            this.btn_inplace.Name = "btn_inplace";
            this.btn_inplace.Size = new System.Drawing.Size(183, 22);
            this.btn_inplace.Text = "Inplace";
            this.btn_inplace.Click += new System.EventHandler(this.btn_inplace_Click);
            // 
            // btn_simplysmooth
            // 
            this.btn_simplysmooth.Name = "btn_simplysmooth";
            this.btn_simplysmooth.Size = new System.Drawing.Size(183, 22);
            this.btn_simplysmooth.Text = "Simply Smooth";
            this.btn_simplysmooth.Click += new System.EventHandler(this.btn_simplysmooth_Click);
            // 
            // Color
            // 
            this.Color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.Color.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(221, 22);
            this.Color.Text = "Color";
            this.Color.Click += new System.EventHandler(this.Color_Click);
            // 
            // EdgeDetectVertical
            // 
            this.EdgeDetectVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.EdgeDetectVertical.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EdgeDetectVertical.Name = "EdgeDetectVertical";
            this.EdgeDetectVertical.Size = new System.Drawing.Size(221, 22);
            this.EdgeDetectVertical.Text = "EdgeDetectVertical";
            this.EdgeDetectVertical.Click += new System.EventHandler(this.EdgeDetectVertical_Click);
            // 
            // Filter_Swirl
            // 
            this.Filter_Swirl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.Filter_Swirl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Filter_Swirl.Name = "Filter_Swirl";
            this.Filter_Swirl.Size = new System.Drawing.Size(221, 22);
            this.Filter_Swirl.Text = "Swirl";
            this.Filter_Swirl.Click += new System.EventHandler(this.Filter_Swirl_Click);
            // 
            // btn_sierraDithering
            // 
            this.btn_sierraDithering.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btn_sierraDithering.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_sierraDithering.Name = "btn_sierraDithering";
            this.btn_sierraDithering.Size = new System.Drawing.Size(221, 22);
            this.btn_sierraDithering.Text = "Sierra Dithering";
            this.btn_sierraDithering.Click += new System.EventHandler(this.btn_sierraDithering_Click);
            // 
            // btn_crossdomain
            // 
            this.btn_crossdomain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btn_crossdomain.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_crossdomain.Name = "btn_crossdomain";
            this.btn_crossdomain.Size = new System.Drawing.Size(221, 22);
            this.btn_crossdomain.Text = "Cross-domain";
            this.btn_crossdomain.Click += new System.EventHandler(this.btn_crossdomain_Click);
            // 
            // btn_orderedDithering
            // 
            this.btn_orderedDithering.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btn_orderedDithering.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_orderedDithering.Name = "btn_orderedDithering";
            this.btn_orderedDithering.Size = new System.Drawing.Size(221, 22);
            this.btn_orderedDithering.Text = "Ordered Dithering";
            this.btn_orderedDithering.Click += new System.EventHandler(this.btn_orderedDithering_Click);
            // 
            // btn_kuwahara
            // 
            this.btn_kuwahara.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btn_kuwahara.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_kuwahara.Name = "btn_kuwahara";
            this.btn_kuwahara.Size = new System.Drawing.Size(221, 22);
            this.btn_kuwahara.Text = "Kuwahara";
            this.btn_kuwahara.Click += new System.EventHandler(this.btn_kuwahara_Click);
            // 
            // btn_simpleColorize
            // 
            this.btn_simpleColorize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btn_simpleColorize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_simpleColorize.Name = "btn_simpleColorize";
            this.btn_simpleColorize.Size = new System.Drawing.Size(221, 22);
            this.btn_simpleColorize.Text = "Simple colorize";
            this.btn_simpleColorize.Click += new System.EventHandler(this.btn_simpleColorize_Click);
            // 
            // btn_xGray
            // 
            this.btn_xGray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btn_xGray.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_xGray.Name = "btn_xGray";
            this.btn_xGray.Size = new System.Drawing.Size(221, 22);
            this.btn_xGray.Text = "3xGray";
            this.btn_xGray.Click += new System.EventHandler(this.btn_xGray_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_histogram,
            this.btn_unificationOfColor,
            this.btn_compression});
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("Ravie", 8.25F);
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(112, 21);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // btn_histogram
            // 
            this.btn_histogram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btn_histogram.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_histogram.Name = "btn_histogram";
            this.btn_histogram.Size = new System.Drawing.Size(218, 22);
            this.btn_histogram.Text = "Histogram";
            this.btn_histogram.Click += new System.EventHandler(this.btn_histogram_Click);
            // 
            // btn_unificationOfColor
            // 
            this.btn_unificationOfColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btn_unificationOfColor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_unificationOfColor.Name = "btn_unificationOfColor";
            this.btn_unificationOfColor.Size = new System.Drawing.Size(218, 22);
            this.btn_unificationOfColor.Text = "Unification of Color";
            this.btn_unificationOfColor.Click += new System.EventHandler(this.btn_unificationOfColor_Click);
            // 
            // btn_compression
            // 
            this.btn_compression.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btn_compression.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_compression.Name = "btn_compression";
            this.btn_compression.Size = new System.Drawing.Size(218, 22);
            this.btn_compression.Text = "Compression";
            this.btn_compression.Click += new System.EventHandler(this.btn_compression_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUndo,
            this.maxValueOfMemoryToolStripMenuItem,
            this.btnRedo});
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Ravie", 8.25F);
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(67, 21);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnUndo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(233, 22);
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // maxValueOfMemoryToolStripMenuItem
            // 
            this.maxValueOfMemoryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.maxValueOfMemoryToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.maxValueOfMemoryToolStripMenuItem.Name = "maxValueOfMemoryToolStripMenuItem";
            this.maxValueOfMemoryToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.maxValueOfMemoryToolStripMenuItem.Text = "Max value of memory";
            this.maxValueOfMemoryToolStripMenuItem.Click += new System.EventHandler(this.maxValueOfMemoryToolStripMenuItem_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnRedo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(233, 22);
            this.btnRedo.Text = "Redo";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Zoom25,
            this.Zoom50,
            this.Zoom100});
            this.zoomToolStripMenuItem.Font = new System.Drawing.Font("Ravie", 8.25F);
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(67, 21);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // Zoom25
            // 
            this.Zoom25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.Zoom25.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Zoom25.Name = "Zoom25";
            this.Zoom25.Size = new System.Drawing.Size(107, 22);
            this.Zoom25.Text = "25%";
            this.Zoom25.Click += new System.EventHandler(this.Zoom25_Click);
            // 
            // Zoom50
            // 
            this.Zoom50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.Zoom50.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Zoom50.Name = "Zoom50";
            this.Zoom50.Size = new System.Drawing.Size(107, 22);
            this.Zoom50.Text = "50%";
            this.Zoom50.Click += new System.EventHandler(this.Zoom50_Click);
            // 
            // Zoom100
            // 
            this.Zoom100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.Zoom100.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Zoom100.Name = "Zoom100";
            this.Zoom100.Size = new System.Drawing.Size(107, 22);
            this.Zoom100.Text = "100%";
            this.Zoom100.Click += new System.EventHandler(this.Zoom100_Click);
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(455, 181);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            title3.Name = "RGB";
            this.chart1.Titles.Add(title3);
            this.chart1.UseWaitCursor = true;
            this.chart1.Visible = false;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(0, 461);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(1011, 23);
            this.textBox.TabIndex = 3;
            this.textBox.UseWaitCursor = true;
            // 
            // chart2
            // 
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            this.chart2.Location = new System.Drawing.Point(461, 0);
            this.chart2.Name = "chart2";
            series6.ChartArea = "ChartArea1";
            series6.Name = "Series1";
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(413, 181);
            this.chart2.TabIndex = 4;
            this.chart2.Text = "Value";
            title4.Name = "Value";
            this.chart2.Titles.Add(title4);
            this.chart2.UseWaitCursor = true;
            this.chart2.Visible = false;
            // 
            // chart3
            // 
            chartArea7.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea7);
            this.chart3.Location = new System.Drawing.Point(0, 187);
            this.chart3.Name = "chart3";
            series7.ChartArea = "ChartArea1";
            series7.Name = "Series1";
            this.chart3.Series.Add(series7);
            this.chart3.Size = new System.Drawing.Size(455, 181);
            this.chart3.TabIndex = 5;
            this.chart3.Text = "chart3";
            this.chart3.UseWaitCursor = true;
            this.chart3.Visible = false;
            // 
            // chart4
            // 
            chartArea8.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea8);
            this.chart4.Location = new System.Drawing.Point(461, 187);
            this.chart4.Name = "chart4";
            series8.ChartArea = "ChartArea1";
            series8.Name = "Series1";
            this.chart4.Series.Add(series8);
            this.chart4.Size = new System.Drawing.Size(413, 181);
            this.chart4.TabIndex = 6;
            this.chart4.Text = "chart4";
            this.chart4.UseWaitCursor = true;
            this.chart4.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1096, 484);
            this.Controls.Add(this.chart4);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Photoshop";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem File_Load;
        private System.Windows.Forms.ToolStripMenuItem File_Save;
        private System.Windows.Forms.ToolStripMenuItem File_Exit;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kanalskeSlikeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Filter_Grayscale;
        private System.Windows.Forms.ToolStripMenuItem Smooth;
        private System.Windows.Forms.ToolStripMenuItem Color;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnUndo;
        private System.Windows.Forms.ToolStripMenuItem btnRedo;
        private System.Windows.Forms.ToolStripMenuItem maxValueOfMemoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Zoom25;
        private System.Windows.Forms.ToolStripMenuItem Zoom50;
        private System.Windows.Forms.ToolStripMenuItem Zoom100;
        private System.Windows.Forms.ToolStripMenuItem EdgeDetectVertical;
        private System.Windows.Forms.ToolStripMenuItem Filter_Swirl;
      //  private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem btn_histogram;
        private System.Windows.Forms.ToolStripMenuItem btn_sierraDithering;
        private System.Windows.Forms.ToolStripMenuItem btn_inplace;
        private System.Windows.Forms.ToolStripMenuItem btn_simplysmooth;
        private System.Windows.Forms.ToolStripMenuItem btn_crossdomain;
        private System.Windows.Forms.ToolStripMenuItem btn_orderedDithering;
        private System.Windows.Forms.ToolStripMenuItem btn_kuwahara;
        private System.Windows.Forms.ToolStripMenuItem btn_unificationOfColor;
        private System.Windows.Forms.ToolStripMenuItem btn_simpleColorize;
        private System.Windows.Forms.ToolStripMenuItem btn_compression;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ToolStripMenuItem btn_xGray;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart4;
    }
}

