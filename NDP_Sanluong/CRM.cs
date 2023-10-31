using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NDP_Sanluong
{
    public partial class frmCRM : Form
    {
        public frmCRM()
        {
            InitializeComponent();
            DataGridViewLinkColumn dgvlc = new DataGridViewLinkColumn();
            dgvlc.UseColumnTextForLinkValue = true;
            dgvlc.Text = "Details";
            dgvlc.Name = "Details";
            dataGridView1.Columns.Insert(0, dgvlc); //To ensure that this is the first column
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            
        }

        

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (radex.Checked == true)
            {
                dataGridView2.Columns.Clear();
                dataGridView2.Refresh();
                DataGridViewLinkColumn dgvlc2 = new DataGridViewLinkColumn();
                dgvlc2.UseColumnTextForLinkValue = true;
                dgvlc2.Text = "Details";
                dgvlc2.Name = "Details";
                dataGridView2.Columns.Insert(0, dgvlc2); //To ensure that this is the first column
                dataGridView2.CellContentClick += new DataGridViewCellEventHandler(dataGridView2_CellContentClick);

                var select = @"select d.CusID,d.CusName,sum(case when c.ISO_SZTP like '4%' then 2 when c.ISO_SZTP like '2%' then 1 end ) 
                               as Teus from inv_dft a inner join inv_vat b on a.INV_No = b.INV_NO inner join EIR c on a.REF_NO=c.EIRNo inner join CUSTOMERS d on c.CusID=d.CusID 
                               where b.TPLT_NM like '%LOLO%' and b.INV_DATE >= '" + dtpFrom.Value + "' and b.INV_DATE <= '" + dtpTo.Value + "' and b.PAYMENT_STATUS='Y' and a.REF_NO is not null and c.CntrClass=3 group by d.CusID,d.CusName order by teus desc";
                var select2 = @"select top 20 d.CusID,d.CusName,sum(case when c.ISO_SZTP like '4%' then 2 when c.ISO_SZTP like '2%' then 1 end ) 
                               as Teus from inv_dft a inner join inv_vat b on a.INV_No = b.INV_NO inner join EIR c on a.REF_NO=c.EIRNo inner join CUSTOMERS d on c.CusID=d.CusID 
                               where b.TPLT_NM like '%LOLO%' and b.INV_DATE >= '" + dtpFrom.Value + "' and b.INV_DATE <= '" + dtpTo.Value + "' and b.PAYMENT_STATUS='Y' and a.REF_NO is not null and c.CntrClass=3 group by d.CusID,d.CusName order by teus desc";
                var c = new SqlConnection("Data Source=10.0.0.86\\PLTOS;Initial Catalog=NDP;User ID=ndp.user;Password=P@ssw0rd"); // Your Connection String here
                var dataAdapter = new SqlDataAdapter(select, c);
                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var dt = new DataTable();

                dataAdapter.Fill(dt);
                dt.Columns.Add("VIPStatus");

                var dataAdapter2 = new SqlDataAdapter(select2, c);
                var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
                var dt2 = new DataTable();
                dataAdapter2.Fill(dt2);


                foreach (DataRow row in dt.Rows)
                {
                    if (row.Field<int?>("Teus").Equals(null) || row.Field<int?>("Teus") < 100)
                    {
                        row.Delete();
                    }
                    else if (row.Field<int?>("Teus").Equals(null) || row.Field<int?>("Teus") < 200 && row.Field<int?>("Teus") >= 100)
                    {
                        //dataGridView2.Rows.Add(row.ItemArray);
                        row.Delete();
                        
                    }

                    else if (!row.Field<int?>("Teus").Equals(null) && row.Field<int?>("Teus")>=200 && row.Field<int?>("Teus") <=300)
                    {
                        //row.SetField<int>("Teus", 0);
                        row.SetField<string>("VIPStatus", "Vip 1 - discount 5%");
                    }
                    else if(!row.Field<int?>("Teus").Equals(null) && row.Field<int?>("Teus") > 300 && row.Field<int?>("Teus") <= 450)
                    {
                        //row.SetField<int>("Teus", 0);
                        row.SetField<string>("VIPStatus", "Vip 2 - discount 7%");
                    }
                    else if (!row.Field<int?>("Teus").Equals(null) && row.Field<int?>("Teus") > 450)
                    {
                        //row.SetField<int>("Teus", 0);
                        row.SetField<string>("VIPStatus", "Vip 3 - discount 10%");
                    }
                    

                }

                
                //
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //
                dataGridView2.DataSource = dt2;
                dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Refresh();               
                dataGridView2.ReadOnly = true;
                dataGridView2.Refresh();
            }


            if (radim.Checked == true)
            {
                dataGridView2.Columns.Clear();
                dataGridView2.Refresh();
                DataGridViewLinkColumn dgvlc2 = new DataGridViewLinkColumn();
                dgvlc2.UseColumnTextForLinkValue = true;
                dgvlc2.Text = "Details";
                dgvlc2.Name = "Details";
                dataGridView2.Columns.Insert(0, dgvlc2); //To ensure that this is the first column
                dataGridView2.CellContentClick += new DataGridViewCellEventHandler(dataGridView2_CellContentClick);
                //
                var select = @"select d.CusID,d.CusName,sum(case when c.ISO_SZTP like '4%' then 2 when c.ISO_SZTP like '2%' then 1 end ) 
                               as Teus from inv_dft a inner join inv_vat b on a.INV_No = b.INV_NO inner join EIR c on a.REF_NO=c.EIRNo inner join CUSTOMERS d on c.CusID=d.CusID  
                               where b.TPLT_NM like '%LOLO%' and b.INV_DATE >= '" + dtpFrom.Value + "' and b.INV_DATE <= '" + dtpTo.Value + "' and b.PAYMENT_STATUS='Y' and a.REF_NO is not null and c.CntrClass=1 group by d.CusID,d.CusName order by teus desc";
                //
                var select2 = @"select top 20 d.CusID,d.CusName,sum(case when c.ISO_SZTP like '4%' then 2 when c.ISO_SZTP like '2%' then 1 end ) 
                               as Teus from inv_dft a inner join inv_vat b on a.INV_No = b.INV_NO inner join EIR c on a.REF_NO=c.EIRNo inner join CUSTOMERS d on c.CusID=d.CusID  
                               where b.TPLT_NM like '%LOLO%' and b.INV_DATE >= '" + dtpFrom.Value + "' and b.INV_DATE <= '" + dtpTo.Value + "' and b.PAYMENT_STATUS='Y' and a.REF_NO is not null and c.CntrClass=1 group by d.CusID,d.CusName order by teus desc";
                var c = new SqlConnection("Data Source=10.0.0.86\\PLTOS;Initial Catalog=NDP;User ID=ndp.user;Password=P@ssw0rd"); // Your Connection String here
                var dataAdapter = new SqlDataAdapter(select, c);
                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var dt = new DataTable();
                dataAdapter.Fill(dt);
                dt.Columns.Add("VIPStatus");
                //
                var dataAdapter2 = new SqlDataAdapter(select2, c);
                var commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
                var dt2 = new DataTable();
                dataAdapter2.Fill(dt2);

                foreach (DataRow row in dt.Rows)
                {
                    if (row.Field<int?>("Teus").Equals(null) || row.Field<int?>("Teus") < 150)
                    {
                        row.Delete();

                    }
                    else if (row.Field<int?>("Teus").Equals(null) || row.Field<int?>("Teus") < 250 && row.Field<int?>("Teus") >= 150)
                    {
                        //dataGridView2.Rows.Add(row.ItemArray);
                        row.Delete();
                    }
                    else if (!row.Field<int?>("Teus").Equals(null) && row.Field<int?>("Teus") >= 250 && row.Field<int?>("Teus") <= 350)
                    {
                        //row.SetField<int>("Teus", 0);
                        row.SetField<string>("VIPStatus", "Vip 1 - discount 3%");
                    }
                    else if (!row.Field<int?>("Teus").Equals(null) && row.Field<int?>("Teus") > 350 && row.Field<int?>("Teus") <= 550)
                    {
                        //row.SetField<int>("Teus", 0);
                        row.SetField<string>("VIPStatus", "Vip 2 - discount 5%");
                    }
                    else if (!row.Field<int?>("Teus").Equals(null) && row.Field<int?>("Teus") > 550)
                    {
                        //row.SetField<int>("Teus", 0);
                        row.SetField<string>("VIPStatus", "Vip 3 - discount 10%");
                    }

                }


                //
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //
                dataGridView2.DataSource = dt2;
                dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Refresh();
                dataGridView2.ReadOnly = true;
                dataGridView2.Refresh();

            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex].Name == "Details")
            {

                var result = from cell in dataGridView1.Rows[e.RowIndex].Cells.Cast<DataGridViewCell>()
                             select cell.Value;
                //List<Object> ItemsToPass = result.ToList();
                int r = dgv.CurrentRow.Index;

                Details.cusid = Convert.ToString(dgv[1, r].Value);
                Details.fromdate = dtpFrom.Value.ToString();
                Details.todate = dtpTo.Value.ToString();
                Details.cusname = Convert.ToString(dgv[2, r].Value);
                if (radim.Checked == true)
                {
                    Details.cntrclass = "1";
                }
                else if (radex.Checked==true)
                {
                    Details.cntrclass = "3";
                }
                //frm2.Collection = ItemsToPass;
                Details frm2 = new Details();
                frm2.Show();
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex].Name == "Details")
            {

                var result = from cell in dataGridView2.Rows[e.RowIndex].Cells.Cast<DataGridViewCell>()
                             select cell.Value;
                //List<Object> ItemsToPass = result.ToList();
                int r = dgv.CurrentRow.Index;

                Details.cusid = Convert.ToString(dgv[1, r].Value);
                Details.fromdate = dtpFrom.Value.ToString();
                Details.todate = dtpTo.Value.ToString();
                Details.cusname = Convert.ToString(dgv[2, r].Value);
                if (radim.Checked == true)
                {
                    Details.cntrclass = "1";
                }
                else if (radex.Checked == true)
                {
                    Details.cntrclass = "3";
                }
                //frm2.Collection = ItemsToPass;
                Details frm2 = new Details();
                frm2.Show();
            }
        }
        private void frmCRM_Load(object sender, EventArgs e)
        {
            radim.Checked = true;
        }
    }
}
