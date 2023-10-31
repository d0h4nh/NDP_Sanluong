using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NDP_Sanluong
{
    public partial class Details : Form

    {
        public static string cusname;
        public static string cusid;
        public static string fromdate;
        public static string todate;
        public static string cntrclass;
        public Details()
        {
            InitializeComponent();
            
            this.Text = "Details of " + cusid + " - " + cusname;
            var select = @"select c.CntrNo as ContainerNo,c.BLNo as BillingNo,c.BookingNo,c.ISO_SZTP as ISO,
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
                                   where b.TPLT_NM like '%LOLO%' and b.INV_DATE >= '" + fromdate + "' and b.INV_DATE <= '" + todate + "' and b.PAYMENT_STATUS='Y' and a.REF_NO is not null and c.cntrclass= '" + cntrclass + "' and c.CusID='" + cusid + "'order by c.cntrno";
            var c = new SqlConnection("Data Source=10.0.0.86\\PLTOS;Initial Catalog=NDP;User ID=ndp.user;Password=P@ssw0rd"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var dt = new DataTable();

            dataAdapter.Fill(dt);
            int teus=0;
            foreach (DataRow r in dt.Rows)
            {
                teus += r.Field<int>("Teus");
            }
            this.Text += " "+ teus+ " teus";
            
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void Details_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
