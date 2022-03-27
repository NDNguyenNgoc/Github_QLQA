
namespace QLQA
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
            this.tsmiAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInfor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewPersonalInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSigOut = new System.Windows.Forms.ToolStripMenuItem();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbTotalFunds = new System.Windows.Forms.TextBox();
            this.lbCategoryFood = new System.Windows.Forms.Label();
            this.lbFood = new System.Windows.Forms.Label();
            this.lbQuantily = new System.Windows.Forms.Label();
            this.nbudQuantily = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.cbCategoryFood = new System.Windows.Forms.ComboBox();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvBill = new System.Windows.Forms.ListView();
            this.FoodName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantily = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UnitPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbVND = new System.Windows.Forms.Label();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.txbTotalPrice = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nbudDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnBillPayment = new System.Windows.Forms.Button();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbSwapTable = new System.Windows.Forms.ComboBox();
            this.btnSwapTable = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbudQuantily)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbudDiscount)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdmin,
            this.tsmiInfor});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1106, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiAdmin
            // 
            this.tsmiAdmin.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiAdmin.Name = "tsmiAdmin";
            this.tsmiAdmin.Size = new System.Drawing.Size(83, 23);
            this.tsmiAdmin.Text = "Quảng lý";
            this.tsmiAdmin.Click += new System.EventHandler(this.tsmiAdmin_Click);
            // 
            // tsmiInfor
            // 
            this.tsmiInfor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewPersonalInformation,
            this.tsmiSigOut});
            this.tsmiInfor.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiInfor.Name = "tsmiInfor";
            this.tsmiInfor.Size = new System.Drawing.Size(141, 23);
            this.tsmiInfor.Text = "Thông tin cá nhân";
            // 
            // tsmiViewPersonalInformation
            // 
            this.tsmiViewPersonalInformation.Name = "tsmiViewPersonalInformation";
            this.tsmiViewPersonalInformation.Size = new System.Drawing.Size(243, 26);
            this.tsmiViewPersonalInformation.Text = "Xem thông tin cá nhân";
            this.tsmiViewPersonalInformation.Click += new System.EventHandler(this.tsmiViewPersonalInformation_Click);
            // 
            // tsmiSigOut
            // 
            this.tsmiSigOut.Name = "tsmiSigOut";
            this.tsmiSigOut.Size = new System.Drawing.Size(243, 26);
            this.tsmiSigOut.Text = "Đăng xuất";
            this.tsmiSigOut.Click += new System.EventHandler(this.tsmiSigOut_Click);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(559, 172);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(535, 446);
            this.flpTable.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbTotalFunds);
            this.panel1.Controls.Add(this.lbCategoryFood);
            this.panel1.Controls.Add(this.lbFood);
            this.panel1.Controls.Add(this.lbQuantily);
            this.panel1.Controls.Add(this.nbudQuantily);
            this.panel1.Controls.Add(this.btnAddFood);
            this.panel1.Controls.Add(this.cbCategoryFood);
            this.panel1.Controls.Add(this.cbFood);
            this.panel1.Location = new System.Drawing.Point(542, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 136);
            this.panel1.TabIndex = 2;
            // 
            // txbTotalFunds
            // 
            this.txbTotalFunds.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txbTotalFunds.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalFunds.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txbTotalFunds.Location = new System.Drawing.Point(17, 88);
            this.txbTotalFunds.Name = "txbTotalFunds";
            this.txbTotalFunds.ReadOnly = true;
            this.txbTotalFunds.Size = new System.Drawing.Size(38, 34);
            this.txbTotalFunds.TabIndex = 7;
            // 
            // lbCategoryFood
            // 
            this.lbCategoryFood.AutoSize = true;
            this.lbCategoryFood.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategoryFood.Location = new System.Drawing.Point(280, 13);
            this.lbCategoryFood.Name = "lbCategoryFood";
            this.lbCategoryFood.Size = new System.Drawing.Size(111, 27);
            this.lbCategoryFood.TabIndex = 6;
            this.lbCategoryFood.Text = "Danh mục";
            // 
            // lbFood
            // 
            this.lbFood.AutoSize = true;
            this.lbFood.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFood.Location = new System.Drawing.Point(12, 13);
            this.lbFood.Name = "lbFood";
            this.lbFood.Size = new System.Drawing.Size(57, 27);
            this.lbFood.TabIndex = 5;
            this.lbFood.Text = "Món";
            // 
            // lbQuantily
            // 
            this.lbQuantily.AutoSize = true;
            this.lbQuantily.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantily.Location = new System.Drawing.Point(116, 91);
            this.lbQuantily.Name = "lbQuantily";
            this.lbQuantily.Size = new System.Drawing.Size(110, 26);
            this.lbQuantily.TabIndex = 4;
            this.lbQuantily.Text = "Số lượng:";
            // 
            // nbudQuantily
            // 
            this.nbudQuantily.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbudQuantily.Location = new System.Drawing.Point(232, 89);
            this.nbudQuantily.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nbudQuantily.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nbudQuantily.Name = "nbudQuantily";
            this.nbudQuantily.Size = new System.Drawing.Size(120, 34);
            this.nbudQuantily.TabIndex = 3;
            this.nbudQuantily.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFood
            // 
            this.btnAddFood.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.Location = new System.Drawing.Point(371, 82);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(162, 42);
            this.btnAddFood.TabIndex = 2;
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // cbCategoryFood
            // 
            this.cbCategoryFood.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoryFood.FormattingEnabled = true;
            this.cbCategoryFood.ItemHeight = 26;
            this.cbCategoryFood.Location = new System.Drawing.Point(285, 42);
            this.cbCategoryFood.Name = "cbCategoryFood";
            this.cbCategoryFood.Size = new System.Drawing.Size(248, 34);
            this.cbCategoryFood.TabIndex = 1;
            this.cbCategoryFood.SelectedIndexChanged += new System.EventHandler(this.cbCategoryFood_SelectedIndexChanged);
            // 
            // cbFood
            // 
            this.cbFood.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFood.FormattingEnabled = true;
            this.cbFood.ItemHeight = 26;
            this.cbFood.Location = new System.Drawing.Point(17, 42);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(250, 34);
            this.cbFood.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvBill);
            this.panel2.Location = new System.Drawing.Point(9, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 529);
            this.panel2.TabIndex = 3;
            // 
            // lvBill
            // 
            this.lvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FoodName,
            this.Quantily,
            this.UnitPrice,
            this.Total});
            this.lvBill.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBill.GridLines = true;
            this.lvBill.HideSelection = false;
            this.lvBill.Location = new System.Drawing.Point(0, 0);
            this.lvBill.Name = "lvBill";
            this.lvBill.Size = new System.Drawing.Size(524, 524);
            this.lvBill.TabIndex = 0;
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            // 
            // FoodName
            // 
            this.FoodName.Text = "Tên món";
            this.FoodName.Width = 200;
            // 
            // Quantily
            // 
            this.Quantily.Text = "Số lượng";
            this.Quantily.Width = 80;
            // 
            // UnitPrice
            // 
            this.UnitPrice.Text = "Đơn giá";
            this.UnitPrice.Width = 120;
            // 
            // Total
            // 
            this.Total.Text = "Thành tiền";
            this.Total.Width = 120;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbVND);
            this.panel3.Controls.Add(this.lbTotalPrice);
            this.panel3.Controls.Add(this.txbTotalPrice);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(518, 51);
            this.panel3.TabIndex = 4;
            // 
            // lbVND
            // 
            this.lbVND.AutoSize = true;
            this.lbVND.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVND.Location = new System.Drawing.Point(438, 12);
            this.lbVND.Name = "lbVND";
            this.lbVND.Size = new System.Drawing.Size(62, 27);
            this.lbVND.TabIndex = 2;
            this.lbVND.Text = "VND";
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPrice.Location = new System.Drawing.Point(18, 12);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(117, 26);
            this.lbTotalPrice.TabIndex = 1;
            this.lbTotalPrice.Text = "Tổng tiền:";
            // 
            // txbTotalPrice
            // 
            this.txbTotalPrice.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalPrice.Location = new System.Drawing.Point(141, 9);
            this.txbTotalPrice.Name = "txbTotalPrice";
            this.txbTotalPrice.ReadOnly = true;
            this.txbTotalPrice.Size = new System.Drawing.Size(291, 34);
            this.txbTotalPrice.TabIndex = 0;
            this.txbTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nbudDiscount);
            this.panel4.Controls.Add(this.btnBillPayment);
            this.panel4.Controls.Add(this.btnDiscount);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Location = new System.Drawing.Point(12, 577);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(524, 112);
            this.panel4.TabIndex = 4;
            // 
            // nbudDiscount
            // 
            this.nbudDiscount.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbudDiscount.Location = new System.Drawing.Point(205, 67);
            this.nbudDiscount.Name = "nbudDiscount";
            this.nbudDiscount.Size = new System.Drawing.Size(120, 34);
            this.nbudDiscount.TabIndex = 7;
            // 
            // btnBillPayment
            // 
            this.btnBillPayment.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillPayment.Location = new System.Drawing.Point(350, 59);
            this.btnBillPayment.Name = "btnBillPayment";
            this.btnBillPayment.Size = new System.Drawing.Size(162, 42);
            this.btnBillPayment.TabIndex = 6;
            this.btnBillPayment.Text = "Thanh toán";
            this.btnBillPayment.UseVisualStyleBackColor = true;
            this.btnBillPayment.Click += new System.EventHandler(this.btnBillPayment_Click);
            // 
            // btnDiscount
            // 
            this.btnDiscount.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.Location = new System.Drawing.Point(11, 59);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(162, 42);
            this.btnDiscount.TabIndex = 5;
            this.btnDiscount.Text = "Giảm giá";
            this.btnDiscount.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cbSwapTable);
            this.panel5.Controls.Add(this.btnSwapTable);
            this.panel5.Location = new System.Drawing.Point(542, 624);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(552, 65);
            this.panel5.TabIndex = 5;
            // 
            // cbSwapTable
            // 
            this.cbSwapTable.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSwapTable.FormattingEnabled = true;
            this.cbSwapTable.ItemHeight = 26;
            this.cbSwapTable.Location = new System.Drawing.Point(17, 18);
            this.cbSwapTable.Name = "cbSwapTable";
            this.cbSwapTable.Size = new System.Drawing.Size(335, 34);
            this.cbSwapTable.TabIndex = 8;
            // 
            // btnSwapTable
            // 
            this.btnSwapTable.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwapTable.Location = new System.Drawing.Point(371, 12);
            this.btnSwapTable.Name = "btnSwapTable";
            this.btnSwapTable.Size = new System.Drawing.Size(162, 42);
            this.btnSwapTable.TabIndex = 7;
            this.btnSwapTable.Text = "Chuyển bàn";
            this.btnSwapTable.UseVisualStyleBackColor = true;
            this.btnSwapTable.Click += new System.EventHandler(this.btnSwapTable_Click);
            // 
            // fTableManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1106, 701);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bán hàng";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbudQuantily)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbudDiscount)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdmin;
        private System.Windows.Forms.ToolStripMenuItem tsmiInfor;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewPersonalInformation;
        private System.Windows.Forms.ToolStripMenuItem tsmiSigOut;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nbudQuantily;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ComboBox cbCategoryFood;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.Label lbQuantily;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvBill;
        private System.Windows.Forms.ColumnHeader FoodName;
        private System.Windows.Forms.ColumnHeader Quantily;
        private System.Windows.Forms.ColumnHeader UnitPrice;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.TextBox txbTotalPrice;
        private System.Windows.Forms.Label lbVND;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.Button btnBillPayment;
        private System.Windows.Forms.NumericUpDown nbudDiscount;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cbSwapTable;
        private System.Windows.Forms.Button btnSwapTable;
        private System.Windows.Forms.Label lbCategoryFood;
        private System.Windows.Forms.Label lbFood;
        private System.Windows.Forms.TextBox txbTotalFunds;
    }
}