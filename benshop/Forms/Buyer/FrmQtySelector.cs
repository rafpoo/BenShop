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
            ApplyModernTheme();
            lblProduct.Text = productName;
            nudQty.Maximum = maxStock;
            nudQty.Minimum = 1;
            nudQty.Value = 1;
        }

        private void ApplyModernTheme()
        {
            Helpers.UiHelper.ApplyForm(this, new Size(350, 200));
            lblProduct.Font = Helpers.UiHelper.Font(12, FontStyle.Bold);
            lblProduct.ForeColor = Helpers.UiHelper.Text;
            Helpers.UiHelper.ApplyInput(nudQty);
            Helpers.UiHelper.ApplyButton(btnOK, Helpers.ButtonKind.Primary);
            Helpers.UiHelper.ApplyButton(btnCancel, Helpers.ButtonKind.Secondary);
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
