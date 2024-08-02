namespace BilliardMangement
{
    partial class fTableManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalInformationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvTime = new System.Windows.Forms.ListView();
            this.Starttime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endtime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbSwitchTable = new System.Windows.Forms.ComboBox();
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.btnStopTable = new System.Windows.Forms.Button();
            this.btnStartTable = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.txbTotalPrice = new System.Windows.Forms.TextBox();
            this.nmDiscount = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbDiscount = new System.Windows.Forms.Label();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.personalInformationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1144, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // personalInformationToolStripMenuItem
            // 
            this.personalInformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personalInformationToolStripMenuItem1,
            this.logOutToolStripMenuItem});
            this.personalInformationToolStripMenuItem.Name = "personalInformationToolStripMenuItem";
            this.personalInformationToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.personalInformationToolStripMenuItem.Text = "Account Information";
            this.personalInformationToolStripMenuItem.Click += new System.EventHandler(this.personalInformationToolStripMenuItem_Click);
            // 
            // personalInformationToolStripMenuItem1
            // 
            this.personalInformationToolStripMenuItem1.Name = "personalInformationToolStripMenuItem1";
            this.personalInformationToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.personalInformationToolStripMenuItem1.Text = "Personal Information";
            this.personalInformationToolStripMenuItem1.Click += new System.EventHandler(this.personalInformationToolStripMenuItem1_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvTime);
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Location = new System.Drawing.Point(555, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(440, 292);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lsvTime
            // 
            this.lsvTime.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Starttime,
            this.endtime,
            this.columnHeader5,
            this.columnHeader6});
            this.lsvTime.GridLines = true;
            this.lsvTime.HideSelection = false;
            this.lsvTime.Location = new System.Drawing.Point(1, 179);
            this.lsvTime.Name = "lsvTime";
            this.lsvTime.Size = new System.Drawing.Size(439, 115);
            this.lsvTime.TabIndex = 1;
            this.lsvTime.UseCompatibleStateImageBehavior = false;
            this.lsvTime.View = System.Windows.Forms.View.Details;
            this.lsvTime.SelectedIndexChanged += new System.EventHandler(this.lsvTime_SelectedIndexChanged);
            // 
            // Starttime
            // 
            this.Starttime.Text = "Start time";
            this.Starttime.Width = 130;
            // 
            // endtime
            // 
            this.endtime.Text = "End Time";
            this.endtime.Width = 130;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Play Time";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Total Price";
            this.columnHeader6.Width = 115;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(1, 0);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(439, 180);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            this.lsvBill.SelectedIndexChanged += new System.EventHandler(this.lsvBill_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Food name";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Count";
            this.columnHeader2.Width = 63;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price";
            this.columnHeader3.Width = 93;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Total Price";
            this.columnHeader4.Width = 149;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbSwitchTable);
            this.panel3.Controls.Add(this.btnSwitchTable);
            this.panel3.Controls.Add(this.btnStopTable);
            this.panel3.Controls.Add(this.btnStartTable);
            this.panel3.Location = new System.Drawing.Point(555, 373);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(440, 47);
            this.panel3.TabIndex = 3;
            // 
            // cbSwitchTable
            // 
            this.cbSwitchTable.FormattingEnabled = true;
            this.cbSwitchTable.Location = new System.Drawing.Point(345, 14);
            this.cbSwitchTable.Name = "cbSwitchTable";
            this.cbSwitchTable.Size = new System.Drawing.Size(95, 21);
            this.cbSwitchTable.TabIndex = 4;
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.Location = new System.Drawing.Point(230, 0);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(109, 47);
            this.btnSwitchTable.TabIndex = 2;
            this.btnSwitchTable.Text = "Switch Table";
            this.btnSwitchTable.UseVisualStyleBackColor = true;
            this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
            // 
            // btnStopTable
            // 
            this.btnStopTable.Location = new System.Drawing.Point(115, 0);
            this.btnStopTable.Name = "btnStopTable";
            this.btnStopTable.Size = new System.Drawing.Size(109, 47);
            this.btnStopTable.TabIndex = 1;
            this.btnStopTable.Text = "Stop Table";
            this.btnStopTable.UseVisualStyleBackColor = true;
            this.btnStopTable.Click += new System.EventHandler(this.btnStopTable_Click);
            // 
            // btnStartTable
            // 
            this.btnStartTable.Location = new System.Drawing.Point(0, 0);
            this.btnStartTable.Name = "btnStartTable";
            this.btnStartTable.Size = new System.Drawing.Size(109, 47);
            this.btnStartTable.TabIndex = 0;
            this.btnStartTable.Text = "Start Table";
            this.btnStartTable.UseVisualStyleBackColor = true;
            this.btnStartTable.Click += new System.EventHandler(this.btnStartTable_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(0, 348);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(131, 44);
            this.btnCheckOut.TabIndex = 4;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // txbTotalPrice
            // 
            this.txbTotalPrice.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalPrice.Location = new System.Drawing.Point(0, 314);
            this.txbTotalPrice.Name = "txbTotalPrice";
            this.txbTotalPrice.ReadOnly = true;
            this.txbTotalPrice.Size = new System.Drawing.Size(131, 25);
            this.txbTotalPrice.TabIndex = 8;
            this.txbTotalPrice.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // nmDiscount
            // 
            this.nmDiscount.Location = new System.Drawing.Point(15, 252);
            this.nmDiscount.Name = "nmDiscount";
            this.nmDiscount.Size = new System.Drawing.Size(91, 20);
            this.nmDiscount.TabIndex = 4;
            this.nmDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nmFoodCount);
            this.panel4.Controls.Add(this.btnAddFood);
            this.panel4.Controls.Add(this.cbFood);
            this.panel4.Controls.Add(this.cbCategory);
            this.panel4.Location = new System.Drawing.Point(555, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(440, 42);
            this.panel4.TabIndex = 4;
            // 
            // nmFoodCount
            // 
            this.nmFoodCount.Location = new System.Drawing.Point(395, 13);
            this.nmFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmFoodCount.Name = "nmFoodCount";
            this.nmFoodCount.Size = new System.Drawing.Size(45, 20);
            this.nmFoodCount.TabIndex = 3;
            this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(274, 0);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(115, 42);
            this.btnAddFood.TabIndex = 2;
            this.btnAddFood.Text = "Add Food";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // cbFood
            // 
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(0, 21);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(266, 21);
            this.cbFood.TabIndex = 1;
            this.cbFood.SelectedIndexChanged += new System.EventHandler(this.cbFood_SelectedIndexChanged);
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(0, 0);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(266, 21);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(13, 27);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(537, 393);
            this.flpTable.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbTotalPrice);
            this.panel1.Controls.Add(this.lbDiscount);
            this.panel1.Controls.Add(this.txbTotalPrice);
            this.panel1.Controls.Add(this.nmDiscount);
            this.panel1.Controls.Add(this.btnCheckOut);
            this.panel1.Location = new System.Drawing.Point(1001, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 392);
            this.panel1.TabIndex = 6;
            // 
            // lbDiscount
            // 
            this.lbDiscount.AutoSize = true;
            this.lbDiscount.Location = new System.Drawing.Point(31, 226);
            this.lbDiscount.Name = "lbDiscount";
            this.lbDiscount.Size = new System.Drawing.Size(49, 13);
            this.lbDiscount.TabIndex = 9;
            this.lbDiscount.Text = "Discount";
            this.lbDiscount.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.Location = new System.Drawing.Point(31, 289);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(58, 13);
            this.lbTotalPrice.TabIndex = 10;
            this.lbTotalPrice.Text = "Total Price";
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 429);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Billiard Management";
            this.Load += new System.EventHandler(this.fTableManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personalInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personalInformationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.ComboBox cbSwitchTable;
        private System.Windows.Forms.NumericUpDown nmDiscount;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txbTotalPrice;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.ListView lsvTime;
        private System.Windows.Forms.ColumnHeader Starttime;
        private System.Windows.Forms.ColumnHeader endtime;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSwitchTable;
        private System.Windows.Forms.Button btnStopTable;
        private System.Windows.Forms.Button btnStartTable;
        private System.Windows.Forms.Label lbDiscount;
        private System.Windows.Forms.Label lbTotalPrice;
    }
}