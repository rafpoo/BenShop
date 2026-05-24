using System;
using System.Windows.Forms;

namespace benshop.Forms.Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            ApplyModernTheme();
        }

        private void ApplyModernTheme()
        {
            Helpers.UiHelper.ApplyForm(this, new System.Drawing.Size(900, 600));
            pnlLeft.BackColor = Helpers.UiHelper.Navy;
            pnlRight.BackColor = System.Drawing.Color.White;

            lblTitle.Font = Helpers.UiHelper.Font(32, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(72, 210);
            lblTitle.Text = "BenShop";

            lblSubtitle.Font = Helpers.UiHelper.Font(12);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            lblSubtitle.Location = new System.Drawing.Point(76, 285);
            lblSubtitle.Text = "Dashboard toko dan transaksi";

            lblUsername.Font = Helpers.UiHelper.Font(10, System.Drawing.FontStyle.Bold);
            lblUsername.ForeColor = Helpers.UiHelper.Text;
            lblPassword.Font = Helpers.UiHelper.Font(10, System.Drawing.FontStyle.Bold);
            lblPassword.ForeColor = Helpers.UiHelper.Text;

            Helpers.UiHelper.ApplyInput(txtUsername);
            Helpers.UiHelper.ApplyInput(txtPassword);
            txtUsername.Size = new System.Drawing.Size(320, 32);
            txtPassword.Size = new System.Drawing.Size(320, 32);

            Helpers.UiHelper.ApplyButton(btnLogin, Helpers.ButtonKind.Primary);
            Helpers.UiHelper.ApplyButton(btnBatal, Helpers.ButtonKind.Secondary);
            btnLogin.Text = "Masuk";
            btnBatal.Text = "Batal";
            btnLogin.Size = new System.Drawing.Size(150, 44);
            btnBatal.Size = new System.Drawing.Size(150, 44);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username dan password harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Helpers.SessionManager.CurrentUser = BLL.AuthBLL.Authenticate(username, password);

                if (Helpers.SessionManager.CurrentUser != null)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Username atau password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Terjadi kesalahan: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
