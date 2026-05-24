using System.Drawing;
using System.Windows.Forms;

namespace benshop.Helpers
{
    public enum ButtonKind
    {
        Primary,
        Secondary,
        Info,
        Danger,
        Warning
    }

    public static class UiHelper
    {
        public static readonly Color Navy = Color.FromArgb(15, 23, 42);
        public static readonly Color NavySoft = Color.FromArgb(30, 41, 59);
        public static readonly Color Teal = Color.FromArgb(13, 148, 136);
        public static readonly Color Blue = Color.FromArgb(59, 130, 246);
        public static readonly Color Red = Color.FromArgb(239, 68, 68);
        public static readonly Color Amber = Color.FromArgb(245, 158, 11);
        public static readonly Color Page = Color.FromArgb(248, 250, 252);
        public static readonly Color Panel = Color.White;
        public static readonly Color Border = Color.FromArgb(226, 232, 240);
        public static readonly Color Muted = Color.FromArgb(100, 116, 139);
        public static readonly Color Text = Color.FromArgb(30, 41, 59);

        public static Font Font(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font("Segoe UI", size, style);
        }

        public static void ApplyForm(Form form, Size minimumSize)
        {
            form.BackColor = Page;
            form.Font = Font(10);
            form.MinimumSize = minimumSize;
        }

        public static void ApplyHeader(Panel panel, Label title, string titleText)
        {
            panel.BackColor = Navy;
            panel.Height = 72;
            title.Text = titleText;
            title.Font = Font(18, FontStyle.Bold);
            title.ForeColor = Color.White;
            title.Location = new Point(24, 18);
            title.AutoSize = true;
        }

        public static void ApplySection(Panel panel)
        {
            panel.BackColor = Panel;
            panel.BorderStyle = BorderStyle.None;
            panel.Padding = new Padding(20);
        }

        public static Label SectionTitle(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Font = Font(12, FontStyle.Bold),
                ForeColor = Text
            };
        }

        public static Label SectionHint(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Font = Font(9),
                ForeColor = Muted
            };
        }

        public static void ApplyButton(Button button, ButtonKind kind)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.Font = Font(10, kind == ButtonKind.Secondary ? FontStyle.Regular : FontStyle.Bold);
            button.Height = button.Height < 38 ? 38 : button.Height;

            if (kind == ButtonKind.Primary)
            {
                button.BackColor = Teal;
                button.ForeColor = Color.White;
            }
            else if (kind == ButtonKind.Info)
            {
                button.BackColor = Blue;
                button.ForeColor = Color.White;
            }
            else if (kind == ButtonKind.Danger)
            {
                button.BackColor = Red;
                button.ForeColor = Color.White;
            }
            else if (kind == ButtonKind.Warning)
            {
                button.BackColor = Amber;
                button.ForeColor = Color.White;
            }
            else
            {
                button.BackColor = Border;
                button.ForeColor = Text;
            }
        }

        public static void ApplySideButton(Button button)
        {
            button.BackColor = Color.Transparent;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = Font(11, FontStyle.Bold);
            button.ForeColor = Color.FromArgb(203, 213, 225);
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Height = 46;
            button.Cursor = Cursors.Hand;
        }

        public static void ApplyInput(Control control)
        {
            control.Font = Font(10);
            control.BackColor = Color.White;
            if (control is TextBox)
                ((TextBox)control).BorderStyle = BorderStyle.FixedSingle;
        }

        public static void ApplyGrid(DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Border;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeight = 42;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Navy;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = Font(10, FontStyle.Bold);
            grid.DefaultCellStyle.Font = Font(10);
            grid.DefaultCellStyle.ForeColor = Text;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 251, 241);
            grid.DefaultCellStyle.SelectionForeColor = Text;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Page;
            grid.RowTemplate.Height = 38;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly = true;
        }
    }
}
