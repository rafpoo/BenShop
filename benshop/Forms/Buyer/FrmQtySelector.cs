using System;
using System.Drawing;
using System.Windows.Forms;

namespace benshop.Forms.Buyer
{
    public partial class FrmQtySelector : Form
    {
        public int Quantity { get { return (int)nudQty.Value; } }

        public FrmQtySelector(string productName, int maxStock)
        {
            InitializeComponent();
            lblProduct.Text = productName;
            nudQty.Maximum = maxStock;
            nudQty.Minimum = 1;
            nudQty.Value = 1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
