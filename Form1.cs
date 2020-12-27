using MonyTansfer.Core;
using MonyTansfer.Exeptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonyTansfer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            decimal _amount = Convert.ToDecimal(txt_Amount.Text.ToString());
            Transfer transfer = new Transfer();
            try
            {
                transfer.TrasferMoney(txt_To.Text.ToString(), txt_from.Text.ToString(), _amount);
            }
            catch (TransferExpetion ex)
            {

                MessageBox.Show(ex.TransferField);
            }
        }
    }
}
