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
    public partial class frmMain : Form
    {
        public List<object> Collection { get; internal set; }

        public frmMain()
        {
            InitializeComponent();
            this.Text = "Superior CRM software by HanhDD - ITNDP v1.2";
        }

        private void btnCus_Click(object sender, EventArgs e)
        {
            frmCustomer f2 = new frmCustomer();
            f2.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (radCus.Checked == true)
            {
                if (txtCusID.Text != "")
                {
                    var select = @"select d.CusName as Customer,c.CntrNo as ContainerNo,c.BLNo as BillingNo,c.BookingNo,c.ISO_SZTP as ISO,
                                   case 
                                   when c.ISO_SZTP like '4%' then 2 
                                   when c.ISO_SZTP like '2%' then 1 
                                   end as Teus,
                                   CASE 
                                   WHEN c.CntrClass = 1 THEN 'Import' 
                                   WHEN c.CntrClass = 3 THEN 'Export' 
                                   WHEN c.CntrClass = 2 THEN 'Storage empty' 
                                   END as 'Im/Ex',e.ShipName,c.OprID,c.CmdID as 'Commodity'
                                   from inv_dft a inner join inv_vat b on a.INV_No = b.INV_NO inner join EIR c on a.REF_NO=c.EIRNo inner join CUSTOMERS d on c.CusID=d.CusID inner join  VESSELS e on c.ShipID=e.ShipID
                                   where b.TPLT_NM like '%LOLO%' and b.INV_DATE >= '" + dtpFrom.Value + "' and b.INV_DATE <= '" + dtpTo.Value + "' and b.PAYMENT_STATUS='Y' and a.REF_NO is not null and c.CusID='" + txtCusID.Text + "'order by c.cntrno";
                    var c = new SqlConnection("Data Source=10.0.0.86\\PLTOS;Initial Catalog=NDP;User ID=ndp.user;Password=P@ssw0rd"); // Your Connection String here
                    var dataAdapter = new SqlDataAdapter(select, c);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var dt = new DataTable();
                    dataAdapter.Fill(dt);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    teus_counting(dt);
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                }
                else
                    MessageBox.Show("Đã nhập mã số thuế đâu mà bấm????", "Nhìn kĩ vào");
            }
            if (radOPR.Checked == true)
            {
                if (txtOpr.Text != "")
                {
                    var select = @"select d.CusName as Customer,c.CntrNo as ContainerNo,c.BLNo as BillingNo,c.BookingNo,c.ISO_SZTP as ISO,
                                   case 
                                   when c.ISO_SZTP like '4%' then 2 
                                   when c.ISO_SZTP like '2%' then 1 
                                   end as Teus,
                                   CASE 
                                   WHEN c.CntrClass = 1 THEN 'Import' 
                                   WHEN c.CntrClass = 3 THEN 'Export' 
                                   WHEN c.CntrClass = 2 THEN 'Storage empty' 
                                   END as 'Im/Ex',e.ShipName,c.OprID,c.CmdID as 'Commodity'
                                   from inv_dft a inner join inv_vat b on a.INV_No = b.INV_NO inner join EIR c on a.REF_NO=c.EIRNo inner join CUSTOMERS d on c.CusID=d.CusID inner join  VESSELS e on c.ShipID=e.ShipID
                                   where b.TPLT_NM like '%LOLO%' and b.INV_DATE >= '" + dtpFrom.Value + "' and b.INV_DATE <= '" + dtpTo.Value + "' and b.PAYMENT_STATUS='Y' and a.REF_NO is not null and c.OprID='" + txtOpr.Text + "'order by c.cntrno";
                    var c = new SqlConnection("Data Source=10.0.0.86\\PLTOS;Initial Catalog=NDP;User ID=ndp.user;Password=P@ssw0rd"); // Your Connection String here
                    var dataAdapter = new SqlDataAdapter(select, c);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var dt = new DataTable();
                    dataAdapter.Fill(dt);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    teus_counting(dt);
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                else
                    MessageBox.Show("Đã nhập hãng tàu đâu mà bấm????", "Nhìn kĩ vào");

            }
            

        }
        private void teus_counting(DataTable dt)
        {
            int im = 0;
            int ex = 0;
            int em = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (r.Field<String>("Im/Ex") == "Import")
                {
                    im += r.Field<int>("Teus");
                }
                if (r.Field<String>("Im/Ex") == "Export")
                {
                    ex += r.Field<int>("Teus");
                }
                if (r.Field<String>("Im/Ex") == "Storage empty")
                {
                    em += r.Field<int>("Teus");
                }
            }
            lblEm.Text = em.ToString() + " teus";
            lblEx.Text = ex.ToString() + " teus";
            lblIm.Text = im.ToString() + " teus";
            lbltotal.Text = (im + ex + em).ToString() + " teus";
        }           
            

            
        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            txtOpr.Enabled = false;
            txtCusID.Enabled = true;
        }

        private void radOPR_CheckedChanged(object sender, EventArgs e)
        {
            txtCusID.Enabled = false;
            txtOpr.Enabled = true;
        }

        private void btnCRM_Click(object sender, EventArgs e)
        {
            frmCRM f3 = new frmCRM();
            f3.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtOpr.Enabled = false;
        }


    }
}



