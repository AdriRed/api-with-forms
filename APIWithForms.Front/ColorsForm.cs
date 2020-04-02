using APIWithForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APIWithForms.Front
{
    public partial class ColorsForm : Form
    {
        private static HttpClient client = new HttpClient();
        private readonly string API_URL;
        private bool adding = false;
        private HashSet<int> editedIds;
        bool getting = false;
        List<Models.UserColorModel> Colors;

        public ColorsForm()
        {
            InitializeComponent();
        }

        public ColorsForm(string apiUrl) : this()
        {
            API_URL = apiUrl;
        }

        private void ColorsForm_Load(object sender, EventArgs e)
        {
            this.FormClosing += (s, ev) =>
            {
                client.Dispose();
            };
            OnChangeNUD();
            bsc_list.ListChanged += ItemChanged;
        }

        #region Buttons

        private void btn_add_Click(object sender, EventArgs e)
        {
            adding = !adding;
            if (adding)
            {
                btn_add.Text = "ADD";
                NewElement();
            }
            else
            {
                btn_add.Text = "NEW";
                AddElement();
            }
        }

        private void btn_addHex_Click(object sender, EventArgs e)
        {
            AddHexForm frm = new AddHexForm(AddHex);
            frm.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeleteColor((UserColorModel)bsc_list.Current);
        }

        private void btn_get_Click(object sender, EventArgs e)
        {
            GetColors();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            bool hasChanges = false;
            List<Task> tasks = new List<Task>();
            foreach (var color in (List<UserColorModel>)bsc_list.DataSource)
            {
                if (color.Id == -1)
                {
                    hasChanges = true;
                    tasks.Add(PostColor(color));
                }
                else if (editedIds.Contains(color.Id))
                {
                    hasChanges = true;
                    tasks.Add(PutColor(color));
                }
            }

            if (hasChanges)
                Task.WhenAll(tasks.ToArray()).ContinueWith(_ => GetColors());
            else
            {
                MessageBox.Show("No changes!");
            }
        }
        #endregion

        #region Relacionat amb Bindings

        private void AddDataBindings()
        {
            ClearBindings();

            bsc_list.SuspendBinding();

            bsc_list.DataSource = Colors;
            lbx_colors.DisplayMember = "Name";

            nud_alpha.DataBindings.Add("Value", bsc_list, "Alpha");
            nud_red.DataBindings.Add("Value", bsc_list, "Red");
            nud_green.DataBindings.Add("Value", bsc_list, "Green");
            nud_blue.DataBindings.Add("Value", bsc_list, "Blue");

            tbx_colorName.DataBindings.Add("Text", bsc_list, "Name");

            bsc_list.ResumeBinding();
        }

        private void ClearBindings()
        {
            nud_alpha.DataBindings.Clear();
            nud_red.DataBindings.Clear();
            nud_green.DataBindings.Clear();
            nud_blue.DataBindings.Clear();
            tbx_colorName.DataBindings.Clear();
        }

        private void OnChangeNUD()
        {
            nud_alpha.ValueChanged += (s, ev) => pnl_color.BackColor = Color.FromArgb((byte)nud_alpha.Value,
                (byte)nud_red.Value,
                (byte)nud_green.Value,
                (byte)nud_blue.Value);
            nud_red.ValueChanged += (s, ev) => pnl_color.BackColor = Color.FromArgb((byte)nud_alpha.Value,
                (byte)nud_red.Value,
                (byte)nud_green.Value,
                (byte)nud_blue.Value);
            nud_green.ValueChanged += (s, ev) => pnl_color.BackColor = Color.FromArgb((byte)nud_alpha.Value,
                (byte)nud_red.Value,
                (byte)nud_green.Value,
                (byte)nud_blue.Value);
            nud_blue.ValueChanged += (s, ev) => pnl_color.BackColor = Color.FromArgb((byte)nud_alpha.Value,
                (byte)nud_red.Value,
                (byte)nud_green.Value,
                (byte)nud_blue.Value);
        }

        private void ItemChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (getting) return;
            int id = e.NewIndex;
            UserColorModel current = ((List<UserColorModel>)bsc_list.DataSource)[id];
            if (!editedIds.Contains(current.Id))
                editedIds.Add(current.Id);
        }

        #endregion

        #region Respostes API

        private void ManageDelete(Task<string> obj)
        {
            GetColors();
        }

        private void ManageGet(Task<string> obj)
        {
            string result = obj.Result;

            Colors = JsonConvert.DeserializeObject<Models.UserColorModel[]>(result).ToList();

            lbx_colors.Invoke((self) =>
            {
                //self.Items.Clear();
                //self.Items.AddRange(colors.Select(x => x.Name).ToArray());
                getting = true;
                AddDataBindings();
                getting = false;


            });
        }

        private void ManagePostPut(HttpResponseMessage result)
        {
            if (!result.IsSuccessStatusCode)
            {
                MessageBox.Show(result.ReasonPhrase);
            }
        }

        #endregion

        #region Trucades API

        public void GetColors()
        {
            editedIds = new HashSet<int>();
            client.GetAsync(API_URL + "/api/usercolors").ContinueWith((response) => response.Result.Content.ReadAsStringAsync().ContinueWith(ManageGet));
        }

        private Task PostColor(UserColorModel color)
        {
            return client.PostAsync(API_URL + "/api/usercolors", new StringContent(JsonConvert.SerializeObject(color), Encoding.UTF8, "application/json"))
                .ContinueWith((response) => ManagePostPut(response.Result));
        }

        private Task PutColor(UserColorModel color)
        {
            return client.PutAsync(API_URL + "/api/usercolors/" + color.Id, new StringContent(JsonConvert.SerializeObject(color), Encoding.UTF8, "application/json"))
                .ContinueWith((response) => ManagePostPut(response.Result));
        }

        private void DeleteColor(Models.UserColorModel color)
        {
            if (color.Id == -1)
            {
                bsc_list.RemoveCurrent();
            }
            else
            {
                client.DeleteAsync(API_URL + "/api/usercolors/" + color.Id)
               .ContinueWith((response) => response.Result.Content.ReadAsStringAsync().ContinueWith(ManageDelete));
            }

        }

        #endregion

        #region Afegir Local

        private void NewElement()
        {
            ClearBindings();

            nud_alpha.ResetText();
            nud_red.ResetText();
            nud_green.ResetText();
            nud_blue.ResetText();
            tbx_colorName.ResetText();
        }

        private void AddHex(string name, string hex)
        {
            hex = hex.TrimStart('#');
            if (hex.Length == 6)
                hex = "FF" + hex;

            Color c = Color.FromArgb(Int32.Parse(hex, System.Globalization.NumberStyles.HexNumber));

            UserColorModel color = new UserColorModel 
            { 
                Id = -1,
                Name = name, 
                Alpha = c.A,
                Red = c.R,
                Green = c.G,
                Blue = c.B
            };

            bsc_list.Add(color);

        }

        private void AddElement()
        {
            Colors.Add(new Models.UserColorModel
            {
                Id = -1,
                Name = tbx_colorName.Text,
                Alpha = (byte)nud_alpha.Value,
                Red = (byte)nud_red.Value,
                Green = (byte)nud_green.Value,
                Blue = (byte)nud_green.Value
            });
            AddDataBindings();
        }

        #endregion
    }
}