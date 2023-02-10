
namespace ChinesePhraseSolitaire
{
    partial class ChinesePhraseSolitaire
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChinesePhraseSolitaire));
            this.result_richtext = new System.Windows.Forms.RichTextBox();
            this.listBox_before = new System.Windows.Forms.ListBox();
            this.listBox_current = new System.Windows.Forms.ListBox();
            this.listBox_after = new System.Windows.Forms.ListBox();
            this.explain = new System.Windows.Forms.RichTextBox();
            this.startWord = new System.Windows.Forms.TextBox();
            this.endword = new System.Windows.Forms.TextBox();
            this.speek_c = new System.Windows.Forms.CheckBox();
            this.autoSelect_C = new System.Windows.Forms.CheckBox();
            this.darkmodel_C = new System.Windows.Forms.CheckBox();
            this.baiduSearch = new System.Windows.Forms.Button();
            this.ciyu_cb = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Contain_txt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.contentContain = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.beforenum = new System.Windows.Forms.Label();
            this.currentnum = new System.Windows.Forms.Label();
            this.afternum = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // result_richtext
            // 
            this.result_richtext.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.result_richtext.Location = new System.Drawing.Point(16, 610);
            this.result_richtext.Name = "result_richtext";
            this.result_richtext.Size = new System.Drawing.Size(1038, 136);
            this.result_richtext.TabIndex = 0;
            this.result_richtext.Text = "";
            this.result_richtext.TextChanged += new System.EventHandler(this.result_richtext_TextChanged);
            // 
            // listBox_before
            // 
            this.listBox_before.Enabled = false;
            this.listBox_before.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_before.FormattingEnabled = true;
            this.listBox_before.ItemHeight = 24;
            this.listBox_before.Location = new System.Drawing.Point(12, 84);
            this.listBox_before.Name = "listBox_before";
            this.listBox_before.Size = new System.Drawing.Size(295, 508);
            this.listBox_before.TabIndex = 1;
            this.listBox_before.SelectedIndexChanged += new System.EventHandler(this.listBox_before_SelectedIndexChanged);
            this.listBox_before.DoubleClick += new System.EventHandler(this.SelectChengyu);
            this.listBox_before.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox_before_KeyUp);
            // 
            // listBox_current
            // 
            this.listBox_current.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_current.FormattingEnabled = true;
            this.listBox_current.ItemHeight = 24;
            this.listBox_current.Location = new System.Drawing.Point(322, 84);
            this.listBox_current.Name = "listBox_current";
            this.listBox_current.Size = new System.Drawing.Size(455, 316);
            this.listBox_current.TabIndex = 2;
            this.listBox_current.SelectedIndexChanged += new System.EventHandler(this.listBox_current_SelectedIndexChanged);
            this.listBox_current.DoubleClick += new System.EventHandler(this.SelectChengyu1);
            this.listBox_current.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox_current_KeyUp);
            // 
            // listBox_after
            // 
            this.listBox_after.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_after.FormattingEnabled = true;
            this.listBox_after.ItemHeight = 24;
            this.listBox_after.Location = new System.Drawing.Point(802, 84);
            this.listBox_after.Name = "listBox_after";
            this.listBox_after.Size = new System.Drawing.Size(252, 508);
            this.listBox_after.TabIndex = 3;
            this.listBox_after.SelectedIndexChanged += new System.EventHandler(this.listBox_after_SelectedIndexChanged);
            this.listBox_after.DoubleClick += new System.EventHandler(this.SelectChengyu2);
            this.listBox_after.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox_after_KeyUp);
            // 
            // explain
            // 
            this.explain.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.explain.Location = new System.Drawing.Point(322, 424);
            this.explain.Name = "explain";
            this.explain.Size = new System.Drawing.Size(455, 127);
            this.explain.TabIndex = 4;
            this.explain.Text = "";
            this.explain.TextChanged += new System.EventHandler(this.explain_TextChanged);
            // 
            // startWord
            // 
            this.startWord.Location = new System.Drawing.Point(16, 12);
            this.startWord.Name = "startWord";
            this.startWord.Size = new System.Drawing.Size(65, 21);
            this.startWord.TabIndex = 5;
            this.startWord.TextChanged += new System.EventHandler(this.startWord_TextChanged);
            this.startWord.Enter += new System.EventHandler(this.Textbox_Enter);
            this.startWord.KeyUp += new System.Windows.Forms.KeyEventHandler(this.endword_KeyUp);
            this.startWord.Leave += new System.EventHandler(this.Textbox_Leave);
            // 
            // endword
            // 
            this.endword.Location = new System.Drawing.Point(175, 12);
            this.endword.Name = "endword";
            this.endword.Size = new System.Drawing.Size(64, 21);
            this.endword.TabIndex = 7;
            this.endword.TextChanged += new System.EventHandler(this.startWord_TextChanged);
            this.endword.Enter += new System.EventHandler(this.Textbox_Enter1);
            this.endword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.endword_KeyUp);
            this.endword.Leave += new System.EventHandler(this.Textbox_Leave1);
            // 
            // speek_c
            // 
            this.speek_c.AutoSize = true;
            this.speek_c.Checked = true;
            this.speek_c.CheckState = System.Windows.Forms.CheckState.Checked;
            this.speek_c.Location = new System.Drawing.Point(322, 14);
            this.speek_c.Name = "speek_c";
            this.speek_c.Size = new System.Drawing.Size(72, 16);
            this.speek_c.TabIndex = 10;
            this.speek_c.Text = "语音播放";
            this.speek_c.UseVisualStyleBackColor = true;
            this.speek_c.CheckedChanged += new System.EventHandler(this.speek_c_CheckedChanged);
            // 
            // autoSelect_C
            // 
            this.autoSelect_C.AutoSize = true;
            this.autoSelect_C.Location = new System.Drawing.Point(400, 12);
            this.autoSelect_C.Name = "autoSelect_C";
            this.autoSelect_C.Size = new System.Drawing.Size(72, 16);
            this.autoSelect_C.TabIndex = 11;
            this.autoSelect_C.Text = "自动模式";
            this.autoSelect_C.UseVisualStyleBackColor = true;
            this.autoSelect_C.CheckedChanged += new System.EventHandler(this.autoSelect_C_CheckedChanged);
            // 
            // darkmodel_C
            // 
            this.darkmodel_C.AutoSize = true;
            this.darkmodel_C.Enabled = false;
            this.darkmodel_C.Location = new System.Drawing.Point(802, 14);
            this.darkmodel_C.Name = "darkmodel_C";
            this.darkmodel_C.Size = new System.Drawing.Size(72, 16);
            this.darkmodel_C.TabIndex = 12;
            this.darkmodel_C.Text = "黑暗模式";
            this.darkmodel_C.UseVisualStyleBackColor = true;
            // 
            // baiduSearch
            // 
            this.baiduSearch.Location = new System.Drawing.Point(322, 557);
            this.baiduSearch.Name = "baiduSearch";
            this.baiduSearch.Size = new System.Drawing.Size(133, 35);
            this.baiduSearch.TabIndex = 13;
            this.baiduSearch.Text = "百度汉语";
            this.baiduSearch.UseVisualStyleBackColor = true;
            this.baiduSearch.Click += new System.EventHandler(this.baiduSearch_Click);
            // 
            // ciyu_cb
            // 
            this.ciyu_cb.AutoSize = true;
            this.ciyu_cb.Location = new System.Drawing.Point(681, 13);
            this.ciyu_cb.Name = "ciyu_cb";
            this.ciyu_cb.Size = new System.Drawing.Size(96, 16);
            this.ciyu_cb.TabIndex = 14;
            this.ciyu_cb.Text = "词语接龙模式";
            this.ciyu_cb.UseVisualStyleBackColor = true;
            this.ciyu_cb.CheckedChanged += new System.EventHandler(this.ciyu_cb_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(478, 11);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(55, 21);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "最长模式",
            "最短模式",
            "随机模式"});
            this.comboBox1.Location = new System.Drawing.Point(539, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.Text = "随机模式";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Contain_txt
            // 
            this.Contain_txt.Location = new System.Drawing.Point(87, 12);
            this.Contain_txt.Name = "Contain_txt";
            this.Contain_txt.Size = new System.Drawing.Size(82, 21);
            this.Contain_txt.TabIndex = 17;
            this.Contain_txt.TextChanged += new System.EventHandler(this.startWord_TextChanged);
            this.Contain_txt.Enter += new System.EventHandler(this.Textbox_Enter2);
            this.Contain_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.endword_KeyUp);
            this.Contain_txt.Leave += new System.EventHandler(this.Textbox_Leave2);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 49);
            this.button1.TabIndex = 18;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contentContain
            // 
            this.contentContain.Location = new System.Drawing.Point(16, 39);
            this.contentContain.Name = "contentContain";
            this.contentContain.Size = new System.Drawing.Size(223, 21);
            this.contentContain.TabIndex = 19;
            this.contentContain.Enter += new System.EventHandler(this.Textbox_Enter3);
            this.contentContain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.endword_KeyUp);
            this.contentContain.Leave += new System.EventHandler(this.Textbox_Leave3);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(469, 558);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 34);
            this.button2.TabIndex = 20;
            this.button2.Text = "百度搜索";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(681, 41);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 16);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "歇后语接龙模式";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // beforenum
            // 
            this.beforenum.AutoSize = true;
            this.beforenum.Location = new System.Drawing.Point(126, 595);
            this.beforenum.Name = "beforenum";
            this.beforenum.Size = new System.Drawing.Size(11, 12);
            this.beforenum.TabIndex = 22;
            this.beforenum.Text = "0";
            // 
            // currentnum
            // 
            this.currentnum.AutoSize = true;
            this.currentnum.Location = new System.Drawing.Point(504, 406);
            this.currentnum.Name = "currentnum";
            this.currentnum.Size = new System.Drawing.Size(11, 12);
            this.currentnum.TabIndex = 23;
            this.currentnum.Text = "0";
            // 
            // afternum
            // 
            this.afternum.AutoSize = true;
            this.afternum.Location = new System.Drawing.Point(904, 595);
            this.afternum.Name = "afternum";
            this.afternum.Size = new System.Drawing.Size(11, 12);
            this.afternum.TabIndex = 24;
            this.afternum.Text = "0";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(596, 558);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 34);
            this.button3.TabIndex = 25;
            this.button3.Text = "朗读解释";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(694, 558);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 34);
            this.button4.TabIndex = 26;
            this.button4.Text = "朗读历史";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(802, 41);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(90, 16);
            this.checkBox2.TabIndex = 27;
            this.checkBox2.Text = "保存Txt日志";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_1);
            // 
            // ChinesePhraseSolitaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1066, 758);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.afternum);
            this.Controls.Add(this.currentnum);
            this.Controls.Add(this.beforenum);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.contentContain);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Contain_txt);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.ciyu_cb);
            this.Controls.Add(this.baiduSearch);
            this.Controls.Add(this.darkmodel_C);
            this.Controls.Add(this.autoSelect_C);
            this.Controls.Add(this.speek_c);
            this.Controls.Add(this.endword);
            this.Controls.Add(this.startWord);
            this.Controls.Add(this.explain);
            this.Controls.Add(this.listBox_after);
            this.Controls.Add(this.listBox_current);
            this.Controls.Add(this.listBox_before);
            this.Controls.Add(this.result_richtext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChinesePhraseSolitaire";
            this.Text = "成语接龙";
            this.Load += new System.EventHandler(this.ChinesePhraseSolitaire_Load);
            this.Resize += new System.EventHandler(this.ChinesePhraseSolitaire_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox result_richtext;
        private System.Windows.Forms.ListBox listBox_before;
        private System.Windows.Forms.ListBox listBox_current;
        private System.Windows.Forms.ListBox listBox_after;
        private System.Windows.Forms.RichTextBox explain;
        private System.Windows.Forms.TextBox startWord;
        private System.Windows.Forms.TextBox endword;
        private System.Windows.Forms.CheckBox speek_c;
        private System.Windows.Forms.CheckBox autoSelect_C;
        private System.Windows.Forms.CheckBox darkmodel_C;
        private System.Windows.Forms.Button baiduSearch;
        private System.Windows.Forms.CheckBox ciyu_cb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox Contain_txt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox contentContain;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label beforenum;
        private System.Windows.Forms.Label currentnum;
        private System.Windows.Forms.Label afternum;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

