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
        private ApiManager api;
        private readonly string API_URL;
        private bool adding = false;
        private HashSet<int> editedIds;
        bool getting = false;
        List<Models.UserColorModel> Colors;

        public ColorsForm()
        {
            InitializeComponent();
        }

        public ColorsForm(string apiUrl, HttpClient client) : this()
        {
            API_URL = apiUrl;
            api = new ApiManager(client);
        }

        private void ColorsForm_Load(object sender, EventArgs e)
        {
            this.FormClosing += (s, ev) =>
            {
                api.Dispose();
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

        #region Trucades API

        public async Task GetColors()
        {
            await api.GetAsync<UserColorModel[]>(API_URL + "/api/usercolors", (result) =>
            {
                editedIds = new HashSet<int>();
                Colors = result.ToList();
                lbx_colors.Invoke((self) =>
                {
                    //self.Items.Clear();
                    //self.Items.AddRange(colors.Select(x => x.Name).ToArray());
                    getting = true;
                    AddDataBindings();
                    getting = false;


                });
            });
        }

        private async Task PostColor(UserColorModel color)
        {
            await api.PostAsync<UserColorModel, UserColorModel>(API_URL + "/api/usercolors", color);
        }

        private async Task PutColor(UserColorModel color)
        {
            await api.PutAsync<UserColorModel, UserColorModel>(API_URL + "/api/usercolors/" + color.Id, color);
        }

        private async Task DeleteColor(UserColorModel color)
        {
            if (color.Id == -1)
            {
                bsc_list.RemoveCurrent();
            }
            else
            {
                await api.DeleteAsync<UserColorModel>(API_URL + "/api/usercolors/" + color.Id, async (deleted) =>
                {
                    await GetColors();
                });
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

            Colors.Add(color);
            AddDataBindings();

        }

        private void AddElement()
        {
            Colors.Add(new UserColorModel
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