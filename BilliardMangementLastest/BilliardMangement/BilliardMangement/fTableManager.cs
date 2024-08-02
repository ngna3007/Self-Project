using BilliardMangement.DAL___Data_Access_Layer_;
using BilliardMangement.DTO____Data_Transfer_Object_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Linq;

namespace BilliardMangement
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {

            InitializeComponent();

            BilliardFacade billiardFacade = new BilliardFacade();
            billiardFacade.LoadTable(flpTable, btn_Click);
            billiardFacade.LoadCategory(cbCategory);
            billiardFacade.LoadComboBoxTable(cbSwitchTable);
        }
        

        #region Events

        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            lsvTime.Tag = (sender as Button).Tag;

            BilliardFacade billiardFacade = new BilliardFacade();
            billiardFacade.ShowBill(tableID, lsvBill);
            billiardFacade.ShowBill(tableID, lsvBill);
            billiardFacade.ShowTimeBill(tableID, lsvTime);
            billiardFacade.AddTotalPrice(tableID, txbTotalPrice);
            billiardFacade.LoadTable(flpTable,btn_Click);
        }

        

        private void fTableManager_Load(object sender, EventArgs e)
        {

        }

        private void personalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void personalInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }


        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAL.Instance.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbFood.SelectedItem as Food).ID;
            int count = (int)nmFoodCount.Value;

            BilliardFacade billiardFacade = new BilliardFacade();
            billiardFacade.AddFood(table, idBill, foodID, count, lsvBill, txbTotalPrice);
        }

        private void lsvTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int discount = (int)nmDiscount.Value;
            BilliardFacade billiardFacade = new BilliardFacade();
            billiardFacade.CheckOut(table, discount, txbTotalPrice, lsvBill, lsvTime, flpTable, btn_Click);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BilliardFacade billiardFacade = new BilliardFacade();
            billiardFacade.LoadFoodListByCategoryID(sender, cbFood);
        }

        private void btnStartTable_Click(object sender, EventArgs e)
        {
            Table table = lsvTime.Tag as Table;
            BilliardFacade billiardFacade = new BilliardFacade();
            billiardFacade.StartTable(table, lsvTime, flpTable, btn_Click);
        }

        private void btnStopTable_Click(object sender, EventArgs e)
        {
            Table table = lsvTime.Tag as Table;
            BilliardFacade billiardFacade = new BilliardFacade();
            billiardFacade.StopTable(table, lsvTime, txbTotalPrice, flpTable, btn_Click);
        }

        private void cbFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            Table table = lsvTime.Tag as Table;
            int id1 = (lsvBill.Tag as Table).ID;
            int id2 = (cbSwitchTable.SelectedItem as Table).ID;
            string name1 = (lsvBill.Tag as Table).Name;
            string name2 = (cbSwitchTable.SelectedItem as Table).Name;
            BilliardFacade billiardFacade = new BilliardFacade();
            billiardFacade.SwitchTable(id1,id2,name1,name2,flpTable,btn_Click,table,lsvBill,lsvTime);
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
