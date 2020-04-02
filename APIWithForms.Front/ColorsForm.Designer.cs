namespace APIWithForms.Front
{
    partial class ColorsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_get = new System.Windows.Forms.Button();
            this.lbx_colors = new System.Windows.Forms.ListBox();
            this.bsc_list = new System.Windows.Forms.BindingSource(this.components);
            this.nud_red = new System.Windows.Forms.NumericUpDown();
            this.nud_blue = new System.Windows.Forms.NumericUpDown();
            this.nud_green = new System.Windows.Forms.NumericUpDown();
            this.nud_alpha = new System.Windows.Forms.NumericUpDown();
            this.lbl_colorName = new System.Windows.Forms.Label();
            this.pnl_color = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.tbx_colorName = new System.Windows.Forms.TextBox();
            this.btn_addHex = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsc_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_alpha)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_get
            // 
            this.btn_get.Location = new System.Drawing.Point(42, 29);
            this.btn_get.Name = "btn_get";
            this.btn_get.Size = new System.Drawing.Size(139, 23);
            this.btn_get.TabIndex = 0;
            this.btn_get.Text = "GET";
            this.btn_get.UseVisualStyleBackColor = true;
            this.btn_get.Click += new System.EventHandler(this.btn_get_Click);
            // 
            // lbx_colors
            // 
            this.lbx_colors.DataSource = this.bsc_list;
            this.lbx_colors.FormattingEnabled = true;
            this.lbx_colors.Location = new System.Drawing.Point(42, 67);
            this.lbx_colors.Name = "lbx_colors";
            this.lbx_colors.Size = new System.Drawing.Size(139, 238);
            this.lbx_colors.TabIndex = 1;
            // 
            // nud_red
            // 
            this.nud_red.Hexadecimal = true;
            this.nud_red.Location = new System.Drawing.Point(322, 140);
            this.nud_red.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_red.Name = "nud_red";
            this.nud_red.Size = new System.Drawing.Size(120, 20);
            this.nud_red.TabIndex = 2;
            // 
            // nud_blue
            // 
            this.nud_blue.Hexadecimal = true;
            this.nud_blue.Location = new System.Drawing.Point(322, 215);
            this.nud_blue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_blue.Name = "nud_blue";
            this.nud_blue.Size = new System.Drawing.Size(120, 20);
            this.nud_blue.TabIndex = 3;
            // 
            // nud_green
            // 
            this.nud_green.Hexadecimal = true;
            this.nud_green.Location = new System.Drawing.Point(322, 177);
            this.nud_green.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_green.Name = "nud_green";
            this.nud_green.Size = new System.Drawing.Size(120, 20);
            this.nud_green.TabIndex = 4;
            // 
            // nud_alpha
            // 
            this.nud_alpha.Hexadecimal = true;
            this.nud_alpha.Location = new System.Drawing.Point(322, 100);
            this.nud_alpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_alpha.Name = "nud_alpha";
            this.nud_alpha.Size = new System.Drawing.Size(120, 20);
            this.nud_alpha.TabIndex = 5;
            // 
            // lbl_colorName
            // 
            this.lbl_colorName.AutoSize = true;
            this.lbl_colorName.Location = new System.Drawing.Point(254, 67);
            this.lbl_colorName.Name = "lbl_colorName";
            this.lbl_colorName.Size = new System.Drawing.Size(62, 13);
            this.lbl_colorName.TabIndex = 6;
            this.lbl_colorName.Text = "Color Name";
            // 
            // pnl_color
            // 
            this.pnl_color.Location = new System.Drawing.Point(526, 43);
            this.pnl_color.Name = "pnl_color";
            this.pnl_color.Size = new System.Drawing.Size(220, 221);
            this.pnl_color.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Alpha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Red";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Green";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Blue";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(671, 287);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "SAVE";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(509, 287);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 13;
            this.btn_add.Text = "NEW";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(428, 287);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 14;
            this.btn_delete.Text = "DELETE";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // tbx_colorName
            // 
            this.tbx_colorName.Location = new System.Drawing.Point(322, 64);
            this.tbx_colorName.Name = "tbx_colorName";
            this.tbx_colorName.Size = new System.Drawing.Size(120, 20);
            this.tbx_colorName.TabIndex = 15;
            // 
            // btn_addHex
            // 
            this.btn_addHex.Location = new System.Drawing.Point(590, 287);
            this.btn_addHex.Name = "btn_addHex";
            this.btn_addHex.Size = new System.Drawing.Size(75, 23);
            this.btn_addHex.TabIndex = 16;
            this.btn_addHex.Text = "NEW HEX";
            this.btn_addHex.UseVisualStyleBackColor = true;
            this.btn_addHex.Click += new System.EventHandler(this.btn_addHex_Click);
            // 
            // ColorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 328);
            this.Controls.Add(this.btn_addHex);
            this.Controls.Add(this.tbx_colorName);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnl_color);
            this.Controls.Add(this.lbl_colorName);
            this.Controls.Add(this.nud_alpha);
            this.Controls.Add(this.nud_green);
            this.Controls.Add(this.nud_blue);
            this.Controls.Add(this.nud_red);
            this.Controls.Add(this.lbx_colors);
            this.Controls.Add(this.btn_get);
            this.Name = "ColorsForm";
            this.Text = "Colors";
            this.Load += new System.EventHandler(this.ColorsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsc_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_alpha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_get;
        private System.Windows.Forms.ListBox lbx_colors;
        private System.Windows.Forms.NumericUpDown nud_red;
        private System.Windows.Forms.NumericUpDown nud_blue;
        private System.Windows.Forms.NumericUpDown nud_green;
        private System.Windows.Forms.NumericUpDown nud_alpha;
        private System.Windows.Forms.Label lbl_colorName;
        private System.Windows.Forms.Panel pnl_color;
        private System.Windows.Forms.BindingSource bsc_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TextBox tbx_colorName;
        private System.Windows.Forms.Button btn_addHex;
    }
}