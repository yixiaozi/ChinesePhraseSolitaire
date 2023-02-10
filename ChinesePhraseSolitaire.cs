using ChinesePhraseSolitaire.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ChinesePhraseSolitaire
{
    public partial class ChinesePhraseSolitaire : Form
    {
        public List<chengyu> chengyuData = new List<chengyu>();
        Random random = new Random();
        int index = 0;
        List<string> UsedWords = new List<string>();
        public static string logName = "";
        AutoSizeForm asc = new AutoSizeForm();

        public ChinesePhraseSolitaire()
        {
            logName += DateTime.Now.ToString("yyyyMMddHHmmss");
            InitializeComponent();
            
        }

        private void ChinesePhraseSolitaire_Load(object sender, EventArgs e)
        {
            
            //FileInfo fi = new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + @"idiom.json");
            JavaScriptSerializer js = new JavaScriptSerializer
            {
                MaxJsonLength = Int32.MaxValue
            };
            //using (StreamReader sw = fi.OpenText())
            //{
            //    string s = sw.ReadToEnd();
            //}
            chengyuData = js.Deserialize<List<chengyu>>(System.Text.Encoding.UTF8.GetString(Resources.idiom));

            for (int i = 0; i < 50; i++)
            {
                listBox_before.Items.Add(chengyuData[random.Next(0, 30000)].word);
            }
            beforenum.Text = listBox_before.Items.Count.ToString();

            index = 0;
            setDisable();
            Center();
            Textbox_Leave(null, null);
            Textbox_Leave1(null, null);
            Textbox_Leave2(null, null);
            Textbox_Leave3(null, null);
            try
            {
                
                Dictionary<Control, string> dic = new Dictionary<Control, string>();
                dic.Add(numericUpDown1, "自动模式速度(秒)");
                dic.Add(darkmodel_C, "未实现");
                dic.Add(comboBox1, "最长模式：选取待选词最多的" + Environment.NewLine + @"最短模式：选取待选词最少的" + Environment.NewLine + @"随机模式：随机选择");
                MoveOverInfoTip.SettingMutiTipInfo(dic);
            }
            catch (Exception)
            {
            }
        }
        public void Center()
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (System.Drawing.Point)new Size(x, y);         //窗体的起始位置为(x,y)
        }
        public class chengyu
        {
            public string derivation { get; set; }
            public string example { get; set; }
            public string pinyin { get; set; }
            public string word { get; set; }
            public string abbreviation { get; set; }
        }
        public class ciyu
        {
            public string ci { get; set; }
            public string explanation { get; set; }
        }
        public class xiehouyu
        {
            public string riddle { get; set; }
            public string answer { get; set; }
        }

        private void listBox_before_SelectedIndexChanged(object sender, EventArgs e)
        {
            string before=listBox_before.SelectedItem.ToString();
            showExplain(before);
            if (speek_c.Checked)
            {
                Thread th = new Thread(() => Audio.SpeakText(before));
                th.Start();
            }
            listBox_current.Items.Clear();
            foreach (chengyu item in chengyuData.Where(m => m.word.StartsWith(before.Substring(before.Length - 1))))
            {
                if (!UsedWords.Contains(item.word))
                {
                    listBox_current.Items.Add(item.word);
                }
            }
            currentnum.Text = listBox_current.Items.Count.ToString();
        }

        private void listBox_current_SelectedIndexChanged(object sender, EventArgs e)
        {
            string current = listBox_current.SelectedItem.ToString();
            showExplain(current);
            if (speek_c.Checked)
            {
                Thread th = new Thread(() => Audio.SpeakText(current));
                th.Start();
            }
            listBox_after.Items.Clear();
            foreach (chengyu item in chengyuData.Where(m => m.word.StartsWith(current.Substring(current.Length - 1))))
            {
                if (!UsedWords.Contains(item.word))
                {
                    listBox_after.Items.Add(item.word);
                }
            }
            afternum.Text = listBox_after.Items.Count.ToString();
        }
        string current = "大音希声";
        public void showExplain(string word)
        {
            explain.Clear();
            current = word;
            try
            {
                chengyu c = chengyuData.FirstOrDefault(m => m.word == word);
                explain.AppendText(c.pinyin + Environment.NewLine);
                explain.AppendText(c.derivation + Environment.NewLine);
                explain.AppendText(c.example + Environment.NewLine);
            }
            catch (Exception)
            {
            }
        }

        private void listBox_after_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string after = listBox_after.SelectedItem.ToString();
                showExplain(after);
                if (speek_c.Checked)
                {
                    Thread th = new Thread(() => Audio.SpeakText(after));
                    th.Start();
                }
                listBox_before.Items.Clear();
                foreach (chengyu item in chengyuData.Where(m => m.word.StartsWith(after.Substring(after.Length - 1))))
                {
                    if (!UsedWords.Contains(item.word))
                    {
                        listBox_before.Items.Add(item.word);
                    }
                }
                beforenum.Text = listBox_before.Items.Count.ToString();
            }
            catch (Exception)
            {
            }
        }
        public void setDisable()
        {
            switch (index)
            {
                case 0:
                    listBox_before.Enabled = true;
                    listBox_current.Enabled = false;
                    listBox_after.Enabled = false;
                    listBox_before.Focus();
                    try
                    {
                        if (listBox_after.SelectedItem!=null)
                        {
                            result_richtext.AppendText(">" + listBox_after.SelectedItem.ToString());
                            UsedWords.Add(listBox_after.SelectedItem.ToString());
                            RecordLogTxt(">" + listBox_after.SelectedItem.ToString());
                        }
                    }
                    catch (Exception)
                    {
                    }
                    break;
                case 1:
                    listBox_before.Enabled = false;
                    listBox_current.Enabled = true;
                    listBox_current.Focus();
                    listBox_after.Enabled = false;
                    try
                    {
                        result_richtext.AppendText(">" + listBox_before.SelectedItem.ToString());
                        UsedWords.Add(listBox_before.SelectedItem.ToString());
                        RecordLogTxt(">" + listBox_before.SelectedItem.ToString());
                    }
                    catch (Exception)
                    {
                    }
                    break;
                case 2:
                    listBox_before.Enabled = false;
                    listBox_current.Enabled = false;
                    listBox_after.Enabled = true;
                    listBox_after.Focus();
                    try
                    {
                        result_richtext.AppendText(">"+listBox_current.SelectedItem.ToString());
                        UsedWords.Add(listBox_current.SelectedItem.ToString());
                        RecordLogTxt(">" + listBox_current.SelectedItem.ToString());
                    }
                    catch (Exception)
                    {
                    }
                    break;
                default:
                    break;
            }
        }

        private void SelectChengyu(object sender, EventArgs e)
        {
            index = 1;
            setDisable();
        }

        private void SelectChengyu1(object sender, EventArgs e)
        {
            index = 2;
            setDisable();
        }

        private void SelectChengyu2(object sender, EventArgs e)
        {
            index = 0;
            setDisable();
        }

        private void listBox_before_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                index = 1;
                setDisable();
            }
        }

        private void listBox_current_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                index = 2;
                setDisable();
            }
        }

        private void listBox_after_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                index = 0;
                setDisable();
            }
        }

        private void result_richtext_TextChanged(object sender, EventArgs e)
        {
            Clipboard.SetText(result_richtext.Text);
        }
        public static void RecordLogTxt(string content)
        {
            if (!writelog)
            {
                return;
            }
            string logSite = AppDomain.CurrentDomain.BaseDirectory + logName + ".txt";//本地文件
            if (!System.IO.File.Exists(logSite))
            {
                System.IO.File.Create(logSite).Dispose(); ;
            }

            //历史记录读取
            List<string> historyRecord = new List<string>();
            StreamReader sr = new StreamReader(logSite, false);
            string readLine;
            while (!string.IsNullOrEmpty(readLine = sr.ReadLine()))
            {
                historyRecord.Add(readLine);
            }
            sr.Close();
            sr.Dispose();
            historyRecord.Add(content);

            //新纪录存储
            StreamWriter sw = new StreamWriter(logSite, false);
            for (int i = 0; i < historyRecord.Count; i++)
            {
                sw.WriteLine(historyRecord[i]);
            }
            sw.Close();
            sw.Dispose();
        }

        private void autoSelect_C_CheckedChanged(object sender, EventArgs e)
        {
            if (autoSelect_C.Checked)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int maxindex = 0;
                int minindex = 0;
                int maxnum = 0;
                int minnum = 0;
                if (listBox_before.Enabled)
                {
                    if (comboBox1.SelectedItem.ToString() == "最短模式" || comboBox1.SelectedItem.ToString() == "最长模式")
                    {
                        for (int i = 0; i < listBox_before.Items.Count; i++)
                        {
                            string before = listBox_before.Items[i].ToString();
                            int count = chengyuData.Count(m => m.word.StartsWith(before.Substring(before.Length - 1)));
                            if (count > maxnum)
                            {
                                maxnum = count;
                                maxindex = i;
                            }
                            else
                            {
                                if (count >= 0)
                                {
                                    minnum = count;
                                    minindex = i;
                                }
                            }
                        }
                    }
                    int randomIndex = random.Next(0, listBox_before.Items.Count);
                    if (comboBox1.SelectedItem.ToString() == "随机模式")
                    {
                        UsedWords.Add(listBox_before.Items[randomIndex].ToString());
                        listBox_before.SelectedIndex = randomIndex;
                    }
                    else if (comboBox1.SelectedItem.ToString() == "最短模式")
                    {
                        UsedWords.Add(listBox_before.Items[minindex].ToString());
                        listBox_before.SelectedIndex = minindex;
                    }
                    else if (comboBox1.SelectedItem.ToString() == "最长模式")
                    {
                        UsedWords.Add(listBox_before.Items[maxindex].ToString());
                        listBox_before.SelectedIndex = maxindex;
                    }

                    listBox_before.Refresh();
                    index = 1;
                    setDisable();
                }
                else if (listBox_current.Enabled)
                {
                    if (comboBox1.SelectedItem.ToString() == "最短模式" || comboBox1.SelectedItem.ToString() == "最长模式")
                    {
                        for (int i = 0; i < listBox_current.Items.Count; i++)
                        {
                            string before = listBox_current.Items[i].ToString();
                            int count = chengyuData.Count(m => m.word.StartsWith(before.Substring(before.Length - 1)));
                            if (count > maxnum)
                            {
                                maxnum = count;
                                maxindex = i;
                            }
                            else
                            {
                                if (count >= 0)
                                {
                                    minnum = count;
                                    minindex = i;
                                }
                            }
                        }
                    }
                    int randomIndex = random.Next(0, listBox_current.Items.Count);
                    if (comboBox1.SelectedItem.ToString() == "随机模式")
                    {
                        UsedWords.Add(listBox_current.Items[randomIndex].ToString());
                        listBox_current.SelectedIndex = randomIndex;
                    }
                    else if (comboBox1.SelectedItem.ToString() == "最短模式")
                    {
                        UsedWords.Add(listBox_current.Items[minindex].ToString());
                        listBox_current.SelectedIndex = minindex;
                    }
                    else if (comboBox1.SelectedItem.ToString() == "最长模式")
                    {
                        UsedWords.Add(listBox_current.Items[maxindex].ToString());
                        listBox_current.SelectedIndex = maxindex;
                    }
                    listBox_current.Refresh();
                    index = 2;
                    setDisable();
                }
                else if (listBox_after.Enabled)
                {
                    if (comboBox1.SelectedItem.ToString() == "最短模式" || comboBox1.SelectedItem.ToString() == "最长模式")
                    {
                        for (int i = 0; i < listBox_after.Items.Count; i++)
                        {
                            string before = listBox_after.Items[i].ToString();
                            int count = chengyuData.Count(m => m.word.StartsWith(before.Substring(before.Length - 1)));
                            if (count > maxnum)
                            {
                                maxnum = count;
                                maxindex = i;
                            }
                            else
                            {
                                if (count >= 0)
                                {
                                    minnum = count;
                                    minindex = i;
                                }
                            }
                        }
                    }
                    int randomIndex = random.Next(0, listBox_after.Items.Count);
                    if (comboBox1.SelectedItem.ToString() == "随机模式")
                    {
                        UsedWords.Add(listBox_after.Items[randomIndex].ToString());
                        listBox_after.SelectedIndex = randomIndex;
                    }
                    else if (comboBox1.SelectedItem.ToString() == "最短模式")
                    {
                        UsedWords.Add(listBox_after.Items[minindex].ToString());
                        listBox_after.SelectedIndex = minindex;
                    }
                    else if (comboBox1.SelectedItem.ToString() == "最长模式")
                    {
                        UsedWords.Add(listBox_after.Items[maxindex].ToString());
                        listBox_after.SelectedIndex = maxindex;
                    }
                    listBox_after.Refresh();
                    index = 0;
                    setDisable();
                }
            }
            catch (Exception)
            {
                autoSelect_C.Checked = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval =Convert.ToInt32(numericUpDown1.Value)* 1000;
        }

        private void speek_c_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void startWord_TextChanged(object sender, EventArgs e)
        {
            //listBox_before.Items.Clear();
            //if (startWord.Text.Replace("开始字","")==""&& endword.Text.Replace("结束字", "") == "" && Contain_txt.Text.Replace("包含字", "") == "")
            //{
            //    for (int i = 0; i < 50; i++)
            //    {
            //        listBox_before.Items.Add(chengyuData[random.Next(0, 30000)].word);
            //    }
            //}
            //else
            //{
            //    foreach (var item in chengyuData.Where(m => m.word.StartsWith(startWord.Text.Replace("开始字", "")) && m.word.EndsWith(endword.Text.Replace("结束字", "")) &&m.word.Contains(Contain_txt.Text.Replace("包含字", ""))))
            //    {
            //        listBox_before.Items.Add(item.word);
            //    }
            //}
            //index = 0;
            //setDisable();
            //Center();
        }
        //textbox获得焦点
        bool textboxHasText = false;
        private void Textbox_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false|| startWord.Text == "开始字")
                startWord.Text = "";

            startWord.ForeColor = Color.Black;
        }
        //textbox失去焦点
        private void Textbox_Leave(object sender, EventArgs e)
        {
            if (startWord.Text == "")
            {
                startWord.Text = "开始字";
                startWord.ForeColor = Color.LightGray;
                textboxHasText = false;
            }
            else
                textboxHasText = true;
        }
        bool textboxHasText1 = false;
        private void Textbox_Enter1(object sender, EventArgs e)
        {
            if (textboxHasText1 == false || endword.Text == "结束字")
                endword.Text = "";

            endword.ForeColor = Color.Black;
        }
        //textbox失去焦点
        private void Textbox_Leave1(object sender, EventArgs e)
        {
            if (endword.Text == "")
            {
                endword.Text = "结束字";
                endword.ForeColor = Color.LightGray;
                textboxHasText1 = false;
            }
            else
                textboxHasText1 = true;
        }
        bool textboxHasText2 = false;
        private void Textbox_Enter2(object sender, EventArgs e)
        {
            if (textboxHasText2 == false || Contain_txt.Text == "包含字")
                Contain_txt.Text = "";

            Contain_txt.ForeColor = Color.Black;
        }
        //textbox失去焦点
        private void Textbox_Leave2(object sender, EventArgs e)
        {
            if (Contain_txt.Text == "")
            {
                Contain_txt.Text = "包含字";
                Contain_txt.ForeColor = Color.LightGray;
                textboxHasText2 = false;
            }
            else
                textboxHasText2 = true;
        }

        bool textboxHasText3 = false;
        private void Textbox_Enter3(object sender, EventArgs e)
        {
            if (textboxHasText3 == false || contentContain.Text == "出处解释包含")
                contentContain.Text = "";

            contentContain.ForeColor = Color.Black;
        }
        //textbox失去焦点
        private void Textbox_Leave3(object sender, EventArgs e)
        {
            if (contentContain.Text == "")
            {
                contentContain.Text = "出处解释包含";
                contentContain.ForeColor = Color.LightGray;
                textboxHasText3 = false;
            }
            else
                textboxHasText3 = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listBox_before.Items.Clear();
            if (startWord.Text.Replace("开始字", "") == "" && endword.Text.Replace("结束字", "") == "" && Contain_txt.Text.Replace("包含字", "") == ""&&contentContain.Text.Replace("出处解释包含", "")=="")
            {
                for (int i = 0; i < 50; i++)
                {
                    listBox_before.Items.Add(chengyuData[random.Next(0, 30000)].word);
                }
            }
            else
            {
                foreach (var item in chengyuData.Where(m => m.word.StartsWith(startWord.Text.Replace("开始字", "")) && m.word.EndsWith(endword.Text.Replace("结束字", "")) && m.word.Contains(Contain_txt.Text.Replace("包含字", ""))&&m.derivation.Contains(contentContain.Text.Replace("出处解释包含", ""))))
                {
                    listBox_before.Items.Add(item.word);
                }
            }
            index = 0;
            setDisable();
            Center();
        }

        private void endword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                button1_Click(null,null);
            }
        }

        private void explain_TextChanged(object sender, EventArgs e)
        {

        }

        private void baiduSearch_Click(object sender, EventArgs e)
        {
            if (!ciyu_cb.Checked)
            {
                string url = @"https://hanyu.baidu.com/zici/s?wd=" + current;
                System.Diagnostics.Process.Start(url);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = @"https://baidu.com/s?ie=UTF-8&wd=" + current;
            System.Diagnostics.Process.Start(url);
        }

        private void ciyu_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (ciyu_cb.Checked)
            {
                baiduSearch.Enabled = false;
                JavaScriptSerializer js = new JavaScriptSerializer
                {
                    MaxJsonLength = Int32.MaxValue
                };
                List<ciyu> ciyuData= js.Deserialize<List<ciyu>>(System.Text.Encoding.UTF8.GetString(Resources.ci));
                chengyuData.Clear();
                foreach (ciyu item in ciyuData)
                {
                    chengyuData.Add(new chengyu() { word = item.ci, derivation = item.explanation ,pinyin="", example =""});
                }
                listBox_before.Items.Clear();
                for (int i = 0; i < 50; i++)
                {
                    listBox_before.Items.Add(chengyuData[random.Next(0, 30000)].word);
                }
                beforenum.Text = listBox_before.Items.Count.ToString();

                index = 0;
                setDisable();
                Center();
            }
            else
            {
                baiduSearch.Enabled = true;
                JavaScriptSerializer js = new JavaScriptSerializer
                {
                    MaxJsonLength = Int32.MaxValue
                };
                //using (StreamReader sw = fi.OpenText())
                //{
                //    string s = sw.ReadToEnd();
                //}
                chengyuData = js.Deserialize<List<chengyu>>(System.Text.Encoding.UTF8.GetString(Resources.idiom));

                for (int i = 0; i < 50; i++)
                {
                    listBox_before.Items.Add(chengyuData[random.Next(0, 30000)].word);
                }
                beforenum.Text = listBox_before.Items.Count.ToString();

                index = 0;
                setDisable();
                Center();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ChinesePhraseSolitaire_Resize(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                baiduSearch.Enabled = false;
                JavaScriptSerializer js = new JavaScriptSerializer
                {
                    MaxJsonLength = Int32.MaxValue
                };
                List<xiehouyu> ciyuData = js.Deserialize<List<xiehouyu>>(System.Text.Encoding.UTF8.GetString(Resources.xiehouyu));
                chengyuData.Clear();
                foreach (xiehouyu item in ciyuData)
                {
                    chengyuData.Add(new chengyu() { word = item.riddle+","+item.answer, derivation = item.riddle + "," + item.answer, pinyin = "", example = "" });
                }
                listBox_before.Items.Clear();
                for (int i = 0; i < 50; i++)
                {
                    listBox_before.Items.Add(chengyuData[random.Next(0, 14032)].word);
                }
                beforenum.Text = listBox_before.Items.Count.ToString();

                index = 0;
                setDisable();
                Center();
            }
            else
            {
                baiduSearch.Enabled = true;
                JavaScriptSerializer js = new JavaScriptSerializer
                {
                    MaxJsonLength = Int32.MaxValue
                };
                //using (StreamReader sw = fi.OpenText())
                //{
                //    string s = sw.ReadToEnd();
                //}
                chengyuData = js.Deserialize<List<chengyu>>(System.Text.Encoding.UTF8.GetString(Resources.idiom));

                for (int i = 0; i < 50; i++)
                {
                    listBox_before.Items.Add(chengyuData[random.Next(0, 30000)].word);
                }
                beforenum.Text = listBox_before.Items.Count.ToString();

                index = 0;
                setDisable();
                Center();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string word = explain.Text;
            Thread th = new Thread(() => Audio.SpeakText(word));
            th.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string word = result_richtext.Text.Replace(">", ",");
            Thread th = new Thread(() => Audio.SpeakText(word));
            th.Start();
        }

        public static bool writelog = false;
        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                writelog = true;
            }
            else
            {
                writelog = false;
            }
        }
    }
    class MoveOverInfoTip
    {
        #region   基础参数
        //信息提示组件
        private static ToolTip _toolTip = new ToolTip();
        #endregion
        #region   公有方法
        /// <summary>
        /// 设置单个控件提示信息
        /// </summary>
        /// <typeparam name="T">组件类型</typeparam>
        /// <param name="t">组件</param>
        /// <param name="tipInfo">需要显示的提示信息</param>
        public static void SettingSingleTipInfo<T>(T t, string tipInfo) where T : Control
        {
            _toolTip.SetToolTip(t, tipInfo);
        }
        /// <summary>
        /// 设置多个同种类型的提示信息
        /// </summary>
        /// <typeparam name="T">组件类型</typeparam>
        /// <param name="dic">组件和提示信息字典</param>
        public static void SettingMutiTipInfo<T>(Dictionary<T, string> dic) where T : Control
        {
            if (dic == null || dic.Count <= 0) return;

            foreach (var item in dic)
            {
                _toolTip.SetToolTip(item.Key, item.Value);
            }

        }
        #endregion
        #region   私有方法
        #endregion
    }
    public class AutoSizeForm
    {
        //(1).声明结构,只记录窗体和其控件的初始位置和大小。
        public struct controlRect
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
        }
        //(2).声明 1个对象
        //注意这里不能使用控件列表记录 List nCtrl;，因为控件的关联性，记录的始终是当前的大小。
        //     public List oldCtrl= new List();//这里将西文的大于小于号都过滤掉了，只能改为中文的，使用中要改回西文
        public List<controlRect> oldCtrl = new List<controlRect>();
        int ctrlNo = 0;//1;
                       //(3). 创建两个函数
                       //(3.1)记录窗体和其控件的初始位置和大小,
        public void controllInitializeSize(System.Windows.Forms.Control mForm)
        {
            controlRect cR;
            cR.Left = mForm.Left; cR.Top = mForm.Top; cR.Width = mForm.Width; cR.Height = mForm.Height;
            oldCtrl.Add(cR);//第一个为"窗体本身",只加入一次即可

            AddControl(mForm);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用

            //this.WindowState = (System.Windows.Forms.FormWindowState)(2);//记录完控件的初始位置和大小后，再最大化
            //0 - Normalize , 1 - Minimize,2- Maximize
        }

        private void AddControl(System.Windows.Forms.Control ctl)
        {
            foreach (System.Windows.Forms.Control c in ctl.Controls)
            {  //**放在这里，是先记录控件的子控件，后记录控件本身
               //if (c.Controls.Count > 0)
               //   AddControl(c);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
                controlRect objCtrl;
                objCtrl.Left = c.Left; objCtrl.Top = c.Top; objCtrl.Width = c.Width; objCtrl.Height = c.Height;
                oldCtrl.Add(objCtrl);
                //**放在这里，是先记录控件本身，后记录控件的子控件
                if (c.Controls.Count > 0)
                    AddControl(c);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用

            }
        }

        //(3.2)控件自适应大小,
        public void controlAutoSize(System.Windows.Forms.Control mForm)
        {
            if (ctrlNo == 0)
            { //*如果在窗体的Form1_Load中，记录控件原始的大小和位置，正常没有问题，但要加入皮肤就会出现问题，因为有些控件如dataGridView的的子控件还没有完成，个数少
              //*要在窗体的Form1_SizeChanged中，第一次改变大小时，记录控件原始的大小和位置,这里所有控件的子控件都已经形成
                controlRect cR;
                //  cR.Left = mForm.Left; cR.Top = mForm.Top; cR.Width = mForm.Width; cR.Height = mForm.Height;
                cR.Left = 0; cR.Top = 0; cR.Width = mForm.PreferredSize.Width; cR.Height = mForm.PreferredSize.Height;

                oldCtrl.Add(cR);//第一个为"窗体本身",只加入一次即可

                AddControl(mForm);//窗体内其余控件可能嵌套其它控件(比如panel),故单独抽出以便递归调用
            }
            float wScale = (float)mForm.Width / (float)oldCtrl[0].Width;//新旧窗体之间的比例，与最早的旧窗体
            float hScale = (float)mForm.Height / (float)oldCtrl[0].Height;//.Height;
            ctrlNo = 1;//进入=1，第0个为窗体本身,窗体内的控件,从序号1开始

            AutoScaleControl(mForm, wScale, hScale);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
        }

        private void AutoScaleControl(System.Windows.Forms.Control ctl, float wScale, float hScale)
        {
            int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;
            //int ctrlNo = 1;//第1个是窗体自身的 Left,Top,Width,Height，所以窗体控件从ctrlNo=1开始
            foreach (System.Windows.Forms.Control c in ctl.Controls)
            { //**放在这里，是先缩放控件的子控件，后缩放控件本身
              //if (c.Controls.Count > 0)
              //   AutoScaleControl(c, wScale, hScale);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
                if (ctrlNo > oldCtrl.Count)
                {
                    continue;
                }
                ctrLeft0 = oldCtrl[ctrlNo].Left;
                ctrTop0 = oldCtrl[ctrlNo].Top;
                ctrWidth0 = oldCtrl[ctrlNo].Width;
                ctrHeight0 = oldCtrl[ctrlNo].Height;
                //c.Left = (int)((ctrLeft0 - wLeft0) * wScale) + wLeft1;//新旧控件之间的线性比例
                //c.Top = (int)((ctrTop0 - wTop0) * h) + wTop1;
                c.Left = (int)((ctrLeft0) * wScale);//新旧控件之间的线性比例。控件位置只相对于窗体，所以不能加 + wLeft1
                c.Top = (int)((ctrTop0) * hScale);//
                c.Width = (int)(ctrWidth0 * wScale);//只与最初的大小相关，所以不能与现在的宽度相乘 (int)(c.Width * w);
                c.Height = (int)(ctrHeight0 * hScale);//
                ctrlNo++;//累加序号
                         //**放在这里，是先缩放控件本身，后缩放控件的子控件
                if (c.Controls.Count > 0)
                    AutoScaleControl(c, wScale, hScale);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用


                if (ctl is DataGridView)
                {
                    DataGridView dgv = ctl as DataGridView;
                    Cursor.Current = Cursors.WaitCursor;

                    int widths = 0;
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);  // 自动调整列宽  
                        widths += dgv.Columns[i].Width;   // 计算调整列后单元列的宽度和                       
                    }
                    if (widths >= ctl.Size.Width)  // 如果调整列的宽度大于设定列宽  
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;  // 调整列的模式 自动  
                    else
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  // 如果小于 则填充  

                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}
