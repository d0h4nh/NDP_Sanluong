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
    public partial class frmCustomer : Form
    {
       
        SqlConnection c = new SqlConnection("Data Source=10.0.0.86;Initial Catalog=NDP;User ID=ndp.user;Password=P@ssw0rd"); // Your Connection String here
        SqlDataAdapter dataAdapter; 
        SqlCommandBuilder commandBuilder;
        DataTable dt = new DataTable();
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void btnSearchC_Click(object sender, EventArgs e)
        {
            if (txtCom.Text != "")
            {
                var select = @"select cusid as 'Mã số thuế',CusName as 'Tên công ty', Address as 'Địa chỉ' from customers where cusname like'%" + txtCom.Text + "%' ";
                dataAdapter = new SqlDataAdapter(select, c);
                commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(dt);
                dataCusname.ReadOnly = true;
                dataCusname.DataSource = dt;
                dataCusname.Refresh();
                
            }
            else
                MessageBox.Show("Nhập tên công ty đã", "Làm từ từ thôi");
            
        }

        private void frmCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
