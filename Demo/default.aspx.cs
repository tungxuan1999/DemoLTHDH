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
        private static string title0 = "Frame\\Page ref";
        private static string title1 = "##############";
        private static string title2 = "#######";
        private static string title3 = "Initialization";
        ItemType itemType;
        DataDeloy dataDeloy;
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
            dataDeloy = new DataDeloy(itemType);

            GridViewFIFO.DataSource = gridViewInstall(dataDeloy, "FIFO", 0);
            GridViewFIFO.DataBind();

            GridViewLRU.DataSource = gridViewInstall(dataDeloy, "LRU", 1);
            GridViewLRU.DataBind();

            GridViewOPT.DataSource = gridViewInstall(dataDeloy, "OPT", 2);
            GridViewOPT.DataBind();

            GridViewCLOCK.DataSource = gridViewInstall(dataDeloy, "CLOCK", 3);
            GridViewCLOCK.DataBind();
        }

        public void gridViewNextFIFO(DataDeloy dataDeloy)
        {
            DataTable dataTable = new DataTable("NextFIFO");
            dataTable.Columns.Add(new DataColumn(" ", typeof(string)));
            dataTable.Columns.Add(new DataColumn(title3, typeof(string)));
            for (int i = 0; i < itemType.arrayInt.Count; i++)
            {
                dataTable.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
            }
            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = title1;
            dataTable.Rows[dataTable.Rows.Count - 1][title3] = title1;
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = title2;
            }

            //for (int i = 0; i < itemType.frame; i++)
            //{
            //    dataTable.Rows.Add();
            //    dataTable.Rows[dataTable.Rows.Count - 1][" "] = String.Format("Status[{0}]", i);
            //    for (int j = 0; j < itemType.arrayInt.Count; j++)
            //    {
            //        dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = "" + dataDeloy.loca[j][i];
            //    }
            //}
            //dataTable.Rows.Add();
            //dataTable.Rows[dataTable.Rows.Count - 1][" "] = title1;
            //for (int j = 0; j < itemType.arrayInt.Count; j++)
            //{
            //    dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = title2;
            //}
            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = "Next";
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][title3] = 0;
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = "" + dataDeloy.flag[j];
            }

            GridViewNextFIRO.DataSource = dataTable;
            GridViewNextFIRO.DataBind();
        }

        public void gridViewLocaLRU(DataDeloy dataDeloy)
        {
            DataTable dataTable = new DataTable("LocaLRU");
            dataTable.Columns.Add(new DataColumn(" ", typeof(string)));
            dataTable.Columns.Add(new DataColumn(title3, typeof(string)));
            for (int i = 0; i < itemType.arrayInt.Count; i++)
            {
                dataTable.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
            }
            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = title1;
            dataTable.Rows[dataTable.Rows.Count - 1][title3] = title1;
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = title2;
            }

            for (int i = 0; i < itemType.frame; i++)
            {
                dataTable.Rows.Add();
                dataTable.Rows[dataTable.Rows.Count - 1][" "] = String.Format("Count[{0}]", i);
                dataTable.Rows[dataTable.Rows.Count - 1][title3] = -1;
                for (int j = 0; j < itemType.arrayInt.Count; j++)
                {
                    dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = "" + dataDeloy.loca[j][i];
                }
            }
            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = title1;
            dataTable.Rows[dataTable.Rows.Count - 1][title3] = title1;
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = title2;
            }

            GridViewLOCALRU.DataSource = dataTable;
            GridViewLOCALRU.DataBind();
        }

        public void gridViewLocaOPT(DataDeloy dataDeloy)
        {
            DataTable dataTable = new DataTable("LocaOPT");
            dataTable.Columns.Add(new DataColumn(" ", typeof(string)));
            dataTable.Columns.Add(new DataColumn(title3, typeof(string)));
            for (int i = 0; i < itemType.arrayInt.Count; i++)
            {
                dataTable.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
            }
            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = title1;
            dataTable.Rows[dataTable.Rows.Count - 1][title3] = title1;
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = title2;
            }

            for (int i = 0; i < itemType.frame; i++)
            {
                dataTable.Rows.Add();
                dataTable.Rows[dataTable.Rows.Count - 1][" "] = String.Format("Count[{0}]", i);
                int count = dataDeloy.loca.Length + 1;
                dataTable.Rows[dataTable.Rows.Count - 1][title3] = "" + count;
                for (int j = 0; j < itemType.arrayInt.Count; j++)
                {
                    dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = "" + dataDeloy.loca[j][i];
                }
            }
            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = title1;
            dataTable.Rows[dataTable.Rows.Count - 1][title3] = title1;
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = title2;
            }

            GridViewLOCAOPT.DataSource = dataTable;
            GridViewLOCAOPT.DataBind();
        }

        public void gridViewStatusNextCLOCK(DataDeloy dataDeloy)
        {
            DataTable dataTable = new DataTable("STATUSNextCLOCK");
            dataTable.Columns.Add(new DataColumn(" ", typeof(string)));
            dataTable.Columns.Add(new DataColumn(title3, typeof(string)));
            for (int i = 0; i < itemType.arrayInt.Count; i++)
            {
                dataTable.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
            }
            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = title1;
            dataTable.Rows[dataTable.Rows.Count - 1][title3] = title1;
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = title2;
            }

            for (int i = 0; i < itemType.frame; i++)
            {
                dataTable.Rows.Add();
                dataTable.Rows[dataTable.Rows.Count - 1][" "] = String.Format("Status[{0}]", i);
                dataTable.Rows[dataTable.Rows.Count - 1][title3] = 0;
                for (int j = 0; j < itemType.arrayInt.Count; j++)
                {
                    dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = "" + dataDeloy.loca[j][i];
                }
            }
            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = title1;
            dataTable.Rows[dataTable.Rows.Count - 1][title3] = title1;
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = title2;
            }
            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = "Next";
            dataTable.Rows[dataTable.Rows.Count - 1][title3] = 0;
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = "" + dataDeloy.flag[j];
            }

            GridViewStatusNextCLOCK.DataSource = dataTable;
            GridViewStatusNextCLOCK.DataBind();
        }

        public DataTable gridViewInstall(DataDeloy dataDeloy, String key, int kind)
        {
   
            DataTable dataTable = new DataTable(key);
            ItemData itemData;

            // Đổ data main
            switch (kind)
            {
                case 0:
                    {
                        itemData = dataDeloy.getDataFIFO();
                    }
                    break;
                case 1:
                    {
                        itemData = dataDeloy.getDataLRU();
                    }
                    break;
                case 2:
                    {
                        itemData = dataDeloy.getDataOPT();
                    }break;
                case 3:
                    {
                        itemData = dataDeloy.getDataCLOCK();
                    }break;
                default:
                    return dataTable;
            }


            dataTable.Columns.Add(new DataColumn(" ", typeof(string)));
            dataTable.Columns.Add(new DataColumn(title3, typeof(string)));
            for (int i = 0; i < itemType.arrayInt.Count; i++)
            {
                dataTable.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
            }

            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = title0;
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = itemType.arrayInt[j];
            }
            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = title1;
            dataTable.Rows[dataTable.Rows.Count - 1][title3] = title1;
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = title2;
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
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = title1;
            dataTable.Rows[dataTable.Rows.Count - 1][title3] = title1;
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = title2;
            }
            dataTable.Rows.Add();
            dataTable.Rows[dataTable.Rows.Count - 1][" "] = "Page fault";
            dataTable.Rows[dataTable.Rows.Count - 1][title3] = title1;
            for (int j = 0; j < itemType.arrayInt.Count; j++)
            {
                if (itemData.pagefalut[j] != -1)
                {
                    dataTable.Rows[dataTable.Rows.Count - 1][j.ToString()] = "F";
                }
            }

            // Đổ data next, loca
            switch (kind)
            {
                case 0:
                    {
                        gridViewNextFIFO(dataDeloy);
                    }
                    break;
                case 1:
                    {
                        gridViewLocaLRU(dataDeloy);
                    }break;
                case 2:
                    {
                        gridViewLocaOPT(dataDeloy);
                    }
                    break;
                case 3:
                    {
                        gridViewStatusNextCLOCK(dataDeloy);
                    }
                    break;
            }
            return dataTable;
        }

        protected void GridViewLRU_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 0; i < dataDeloy.getDataLRU().pagefalut.Length; i++)
                {
                    if ((e.Row.Cells[i + 2].Text) == itemType.arrayInt[i].ToString())
                    {
                        e.Row.Cells[i + 2].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[i + 2].Font.Bold = true;
                    }
                }
            }
        }

        protected void GridViewCLOCK_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 0; i < dataDeloy.getDataCLOCK().pagefalut.Length; i++)
                {
                    if ((e.Row.Cells[i + 2].Text) == itemType.arrayInt[i].ToString())
                    {
                        e.Row.Cells[i + 2].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[i + 2].Font.Bold = true;
                    }
                }
            }
        }

        protected void GridViewOPT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 0; i < dataDeloy.getDataOPT().pagefalut.Length; i++)
                {
                    if ((e.Row.Cells[i + 2].Text) == itemType.arrayInt[i].ToString())
                    {
                        e.Row.Cells[i + 2].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[i + 2].Font.Bold = true;
                    }
                }
            }
        }

        protected void GridViewFIFO_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 0; i < dataDeloy.getDataFIFO().pagefalut.Length; i++)
                {
                    if ((e.Row.Cells[i + 2].Text) == itemType.arrayInt[i].ToString())
                    {
                        e.Row.Cells[i + 2].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[i + 2].Font.Bold = true;
                    }
                }
            }
        }
    }
}