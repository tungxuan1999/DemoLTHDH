using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Control = System.Web.UI.Control;

namespace Demo
{
    public partial class _default : System.Web.UI.Page
    {
        ItemType itemType;
        ItemData itemDataFIFO, itemDataLRU, itemDataOPT, itemDataCLOCK;
        protected void Page_Load(object sender, EventArgs e)
        {
            itemType = new ItemType();
        }

        protected void ButtonDEMO_Click(object sender, EventArgs e)
        {
            if (checkEmpty())
            {
                if (!itemType.setArrayIntForString(InputArray.Text.ToString()))
                {
                    MessageBox.Show(this, "Nhập chuỗi sai định dạng");
                    return;
                }
                if (!itemType.setFrame(InputFrame.Text.ToString()))
                {
                    MessageBox.Show(this, "Nhập frame sai định dạng");
                    return;
                }
                setGridview();
            }
        }

        public bool checkEmpty()
        {
            if (InputArray.Text.ToString().CompareTo("") == 0)
            {
                MessageBox.Show(this, "Nhập chuỗi còn trống");
                return false;
            }

            if (InputFrame.Text.ToString().CompareTo("") == 0)
            {
                MessageBox.Show(this, "Nhập frame còn trống");
                return false;
            }
            return true;
        }

        public void setGridview()
        {
            itemDataFIFO = new DataDeloy(itemType).getDataFIFO();
            GridViewFIFO.DataSource = gridViewInstall(itemDataFIFO, "FIFO");
            GridViewFIFO.DataBind();

            itemDataLRU = new DataDeloy(itemType).getDataLRU();
            GridViewLRU.DataSource = gridViewInstall(itemDataLRU, "LRU");
            GridViewLRU.DataBind();

            itemDataOPT = new DataDeloy(itemType).getDataOPT();
            GridViewOPT.DataSource = gridViewInstall(itemDataOPT, "OPT");
            GridViewOPT.DataBind();

            itemDataCLOCK = new DataDeloy(itemType).getDataCLOCK();
            GridViewCLOCK.DataSource = gridViewInstall(itemDataCLOCK, "CLOCK");
            GridViewCLOCK.DataBind();
        }

        public DataTable gridViewInstall(ItemData itemData,String key)
        {
            DataTable dataTable = new DataTable(key);
            dataTable.Columns.Add(new DataColumn(" ", typeof(string)));
            for (int i = 0; i < itemType.arrayInt.Count; i++)
            {
                dataTable.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
            }

            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = "Frame\\Page ref";
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = itemType.arrayInt[j];
            }
            for (int i = 0; i < itemType.frame; i++)
            {

                dataTable.Rows.Add();
                dataTable.Rows[dataTable.Rows.Count - 1][" "] = String.Format("Frame[{0}]", i);
                for (int j = 0; j < itemType.arrayInt.Count; j++)
                {
                    if (!(itemData.xy[j][i] == -1 || itemData.xy[j][i] == -2 || itemData.pagefalut[j] == -1))
                    {
                        dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = "" + itemData.xy[j][i];

                    }
                }
            }
            dataTable.Rows.Add();
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = "#######";
            }
            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = "Page fault";
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                if (itemData.pagefalut[j] != -1)
                {
                    dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = "F";
                }
            }
            return dataTable;
        }

        protected void GridViewLRU_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 0; i < itemDataFIFO.pagefalut.Length; i++)
                {
                    if ((e.Row.Cells[i + 1].Text) == itemType.arrayInt[i].ToString())
                    {
                        e.Row.Cells[i + 1].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[i + 1].Font.Bold = true;
                    }
                }
            }
        }

        protected void GridViewCLOCK_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 0; i < itemDataFIFO.pagefalut.Length; i++)
                {
                    if ((e.Row.Cells[i + 1].Text) == itemType.arrayInt[i].ToString())
                    {
                        e.Row.Cells[i + 1].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[i + 1].Font.Bold = true;
                    }
                }
            }
        }

        protected void GridViewOPT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 0; i < itemDataFIFO.pagefalut.Length; i++)
                {
                    if ((e.Row.Cells[i + 1].Text) == itemType.arrayInt[i].ToString())
                    {
                        e.Row.Cells[i + 1].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[i + 1].Font.Bold = true;
                    }
                }
            }
        }

        protected void GridViewFIFO_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 0; i < itemDataFIFO.pagefalut.Length; i++)
                {
                    if ((e.Row.Cells[i + 1].Text) == itemType.arrayInt[i].ToString())
                    {
                        e.Row.Cells[i + 1].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[i + 1].Font.Bold = true;
                    }
                }
            }
        }
    }
}