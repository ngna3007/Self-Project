using BilliardMangement.DAL___Data_Access_Layer_;
using BilliardMangement.DTO____Data_Transfer_Object_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilliardMangement
{
    public class BilliardFacade
    {
        #region fTableManager
        #region Table
        private void UpdateStatus(int id)
        {
            string query = "UPDATE dbo.BilliardTable SET STATUS = N'PLAYING',starttime = GETDATE() WHERE STATUS = N'EMPTY' AND id = " + id;
            DataProvider.Instance.ExecuteQuery(query);
        }

        private void GetEndTime(int id)
        {
            string query = "DECLARE @currentDateTime DATETIME = GETDATE(); UPDATE dbo.BilliardTable SET status = 'EMPTY', endtime = @currentDateTime, playtime = DATEDIFF(MINUTE, starttime, @currentDateTime) WHERE STATUS = N'PLAYING' AND id = " + id;
            DataProvider.Instance.ExecuteQuery(query);
        }

        private void CloseTable(int id)
        {
            string query = "UPDATE dbo.BilliardTable SET STATUS = N'EMPTY' WHERE id = " + id;
            DataProvider.Instance.ExecuteQuery(query);
        }

        public void LoadComboBoxTable(ComboBox cbSwitchTable)
        {
            cbSwitchTable.DataSource = TableDAL.Instance.LoadTableList();
            cbSwitchTable.DisplayMember = "Name";
        }

        public void SwitchTable(int id1, int id2, string name1, string name2, FlowLayoutPanel flpTable, EventHandler btn_Click, Table table, ListView lsvBill, ListView lsvTime)
        {
            if (MessageBox.Show(String.Format("Do you want to switch table {0} to table {1}?", name1, name2), "Switch Table", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2", new object[] { id1, id2 });
                LoadTable(flpTable, btn_Click);
                ShowBill(table.ID, lsvBill);
                ShowTimeBill(table.ID, lsvTime);
            }
        }

        public void LoadTable(FlowLayoutPanel flpTable, EventHandler btn_Click)
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAL.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAL.TableWidth, Height = TableDAL.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;


                switch (item.Status)
                {
                    case "EMPTY":
                        btn.BackColor = Color.LightCyan;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }

        public void StartTable(Table table, ListView lsvTime, FlowLayoutPanel flpTable, EventHandler btn_Click)
        {
            if (MessageBox.Show("Do you want to start this table?", "Start table", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UpdateStatus(table.ID);
            }
            LoadTable(flpTable, btn_Click);
            ShowTimeBill(table.ID, lsvTime);
        }

        public void StopTable(Table table, ListView lsvTime, TextBox txbTotalPrice, FlowLayoutPanel flpTable, EventHandler btn_Click)
        {
            if (MessageBox.Show("Do you want to stop this table?", "Stop table", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GetEndTime(table.ID);
            }
            LoadTable(flpTable, btn_Click);
            ShowTimeBill(table.ID, lsvTime);
            AddTotalPrice(table.ID, txbTotalPrice);
        }
        #endregion

        #region Bill and Checkout
        public void ShowBill(int tableID, ListView lsvBill)
        {
            lsvBill.Items.Clear();
            List<DTO____Data_Transfer_Object_.Menu> listBillInfo = MenuDAL.Instance.LoadMenuList(tableID.ToString());
            foreach (DTO____Data_Transfer_Object_.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                lsvBill.Items.Add(lsvItem);
            }
        }

        public void ShowTimeBill(int id, ListView lsvTime)
        {
            lsvTime.Items.Clear();
            List<DTO____Data_Transfer_Object_.Time> listBillInfo = MenuDAL.Instance.LoadTimeList(id.ToString());

            foreach (DTO____Data_Transfer_Object_.Time item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.StartTime.ToString());
                lsvItem.SubItems.Add(item.EndTime.ToString());
                lsvItem.SubItems.Add(item.PlayTime.ToString());
                lsvItem.SubItems.Add(item.TotalTimePrice.ToString());
                lsvTime.Items.Add(lsvItem);
            }
        }
        public void AddTotalPrice(int id, TextBox txbTotalPrice)
        {
            float totalTimePrice = 0;
            List<DTO____Data_Transfer_Object_.Time> TimeInfo = MenuDAL.Instance.LoadTimeList(id.ToString());
            foreach (DTO____Data_Transfer_Object_.Time item in TimeInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.TotalTimePrice.ToString());
                if (float.TryParse(item.TotalTimePrice, out float number))
                {
                    totalTimePrice += number;
                }
                else
                {
                    totalTimePrice = 0;
                }
            }
            float totalFoodPrice = 0;
            List<DTO____Data_Transfer_Object_.Menu> FoodInfo = MenuDAL.Instance.LoadMenuList(id.ToString());
            foreach (DTO____Data_Transfer_Object_.Menu item in FoodInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.TotalPrice.ToString());
                totalFoodPrice += item.TotalPrice;
            }
            float Total = totalTimePrice + totalFoodPrice;

            CultureInfo culture = new CultureInfo("vi-VN");

            txbTotalPrice.Text = Total.ToString("c", culture);
        }

        public void CheckOut(Table table, int discount, TextBox txbTotalPrice, ListView lsvBill, ListView lsvTime, FlowLayoutPanel flpTable, EventHandler btn_Click)
        {
            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
            int idBill = BillDAL.Instance.GetUncheckBillIDByTableID(table.ID);

            if (MessageBox.Show(string.Format("Do you want to check out {0}\n Total - (Total/100) x Discount = {1} - ({1}/100) x {2} = {3}", table.Name, totalPrice * 1000, discount, finalTotalPrice * 1000), "Check out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BillDAL.Instance.CheckOutFood(idBill, discount);
                BillDAL.Instance.CheckOutTime(table.ID);
                ShowBill(table.ID, lsvBill);
                ShowTimeBill(table.ID, lsvTime);
                CloseTable(table.ID);
                LoadTable(flpTable, btn_Click);
            }
        }
        #endregion

        #region Category and Food
        public void LoadCategory(ComboBox cbCategory)
        {
            List<Category> listCategory = CategoryDAL.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }

        public void LoadFoodListByCategoryID(object sender, ComboBox cbFood)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;
            List<Food> listFood = FoodDAL.Instance.GetFoodByCategoryID(id.ToString());
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "Name";
        }

        public void AddFood(Table table, int idBill, int foodID, int count, ListView lsvBill, TextBox txbTotalPrice)
        {
            if (idBill == -1)
            {
                BillDAL.Instance.InsertBill(table.ID);
                BillInfoDAL.Instance.InsertBillInfo(BillDAL.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAL.Instance.InsertBillInfo(idBill, foodID, count);
            }
            ShowBill(table.ID, lsvBill);
            AddTotalPrice(table.ID, txbTotalPrice);
        }
        #endregion
        #endregion

        #region fAccountProfile

        bool Login(string username, string password)
        {
            return AccountDAL.Instance.Login(username, password);
        }

        public void Login_Click(string username, string password)
        {
            if (Login(username, password))
            {
                fTableManager f = new fTableManager();
                fLogin fLogin = new fLogin();
                fLogin.Hide();
                f.ShowDialog();
                fLogin.Show();
            }
            else
            {
                MessageBox.Show("Wrong user name or password!");
            }
        }

        public void Form_Closing(FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit the program?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #endregion
    }
}
