using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APIWithForms.Front
{
    public partial class AddHexForm : Form
    {
        public AddHexForm()
        {
            InitializeComponent();
        }

        Action<string, string> _postHex;

        public AddHexForm(Action<string, string> postHex) : this()
        {
            _postHex = postHex;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            _postHex.Invoke(tbx_name.Text, tbx_hex.Text);
            this.Close();
        }
    }
}
