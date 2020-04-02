using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APIWithForms.Front
{
    public partial class Init : Form
    {
        static HttpClient client = new HttpClient();

        public Init()
        {
            InitializeComponent();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            client.GetAsync(tbx_url.Text + "/api/hello").ContinueWith(ManageHelloResponse);
        }

        private void ManageHelloResponse(Task<HttpResponseMessage> obj)
        {
            if (obj.Result.IsSuccessStatusCode)
            {
                ColorsForm form = new ColorsForm(tbx_url.Text);
                form.FormClosed += (s, ev) =>
                {
                    client.Dispose();
                    this.Close();
                };
                this.Invoke((self) => 
                { 
                    self.Hide();
                    form.Show();
                });
            } else
            {
                MessageBox.Show("Api not valid\nExample: localhost:41323");
            }
        }
    }
}
