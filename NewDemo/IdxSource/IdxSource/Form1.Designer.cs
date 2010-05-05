namespace IdxSource
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.radioBaiduNews = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioTianyaGoogle = new System.Windows.Forms.RadioButton();
            this.radioGoogle = new System.Windows.Forms.RadioButton();
            this.radioSogouNews = new System.Windows.Forms.RadioButton();
            this.radioBaidu = new System.Windows.Forms.RadioButton();
            this.tb_path1 = new System.Windows.Forms.TextBox();
            this.tb_URLSeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_RegExpress = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox_Content = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.richTextBox_hot = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_codein = new System.Windows.Forms.TextBox();
            this.tb_codeout = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_Link = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_KeyWords = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.tb_fileSeed = new System.Windows.Forms.TextBox();
            this.btn_match = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.bn_OUTXML = new System.Windows.Forms.Button();
            this.bn_do = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.tb_pageCount = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.richTextBox_RegSameNews = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button6 = new System.Windows.Forms.Button();
            this.tb_seconds = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox_ts = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "GetOut";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioBaiduNews
            // 
            this.radioBaiduNews.AutoSize = true;
            this.radioBaiduNews.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioBaiduNews.Location = new System.Drawing.Point(6, 20);
            this.radioBaiduNews.Name = "radioBaiduNews";
            this.radioBaiduNews.Size = new System.Drawing.Size(71, 16);
            this.radioBaiduNews.TabIndex = 1;
            this.radioBaiduNews.TabStop = true;
            this.radioBaiduNews.Text = "百度新闻";
            this.radioBaiduNews.UseVisualStyleBackColor = true;
            this.radioBaiduNews.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioTianyaGoogle);
            this.groupBox1.Controls.Add(this.radioGoogle);
            this.groupBox1.Controls.Add(this.radioSogouNews);
            this.groupBox1.Controls.Add(this.radioBaidu);
            this.groupBox1.Controls.Add(this.radioBaiduNews);
            this.groupBox1.Location = new System.Drawing.Point(41, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(874, 52);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // radioTianyaGoogle
            // 
            this.radioTianyaGoogle.AutoSize = true;
            this.radioTianyaGoogle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioTianyaGoogle.Location = new System.Drawing.Point(402, 20);
            this.radioTianyaGoogle.Name = "radioTianyaGoogle";
            this.radioTianyaGoogle.Size = new System.Drawing.Size(71, 16);
            this.radioTianyaGoogle.TabIndex = 5;
            this.radioTianyaGoogle.TabStop = true;
            this.radioTianyaGoogle.Text = "天涯站内";
            this.radioTianyaGoogle.UseVisualStyleBackColor = true;
            this.radioTianyaGoogle.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioGoogle
            // 
            this.radioGoogle.AutoSize = true;
            this.radioGoogle.Location = new System.Drawing.Point(309, 20);
            this.radioGoogle.Name = "radioGoogle";
            this.radioGoogle.Size = new System.Drawing.Size(83, 16);
            this.radioGoogle.TabIndex = 4;
            this.radioGoogle.TabStop = true;
            this.radioGoogle.Text = "googleNews";
            this.radioGoogle.UseVisualStyleBackColor = true;
            this.radioGoogle.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioSogouNews
            // 
            this.radioSogouNews.AutoSize = true;
            this.radioSogouNews.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioSogouNews.Location = new System.Drawing.Point(208, 20);
            this.radioSogouNews.Name = "radioSogouNews";
            this.radioSogouNews.Size = new System.Drawing.Size(71, 16);
            this.radioSogouNews.TabIndex = 3;
            this.radioSogouNews.TabStop = true;
            this.radioSogouNews.Text = "搜狗新闻";
            this.radioSogouNews.UseVisualStyleBackColor = true;
            this.radioSogouNews.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioBaidu
            // 
            this.radioBaidu.AutoSize = true;
            this.radioBaidu.Location = new System.Drawing.Point(107, 20);
            this.radioBaidu.Name = "radioBaidu";
            this.radioBaidu.Size = new System.Drawing.Size(47, 16);
            this.radioBaidu.TabIndex = 2;
            this.radioBaidu.TabStop = true;
            this.radioBaidu.Text = "百度";
            this.radioBaidu.UseVisualStyleBackColor = true;
            this.radioBaidu.CheckedChanged += new System.EventHandler(this.radioBaidu_CheckedChanged);
            // 
            // tb_path1
            // 
            this.tb_path1.Location = new System.Drawing.Point(415, 163);
            this.tb_path1.Name = "tb_path1";
            this.tb_path1.Size = new System.Drawing.Size(180, 21);
            this.tb_path1.TabIndex = 3;
            // 
            // tb_URLSeed
            // 
            this.tb_URLSeed.Location = new System.Drawing.Point(75, 70);
            this.tb_URLSeed.Name = "tb_URLSeed";
            this.tb_URLSeed.Size = new System.Drawing.Size(840, 21);
            this.tb_URLSeed.TabIndex = 4;
            this.tb_URLSeed.TextChanged += new System.EventHandler(this.textBox_URLInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "正则";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "URL";
            // 
            // richTextBox_RegExpress
            // 
            this.richTextBox_RegExpress.Location = new System.Drawing.Point(41, 223);
            this.richTextBox_RegExpress.Name = "richTextBox_RegExpress";
            this.richTextBox_RegExpress.Size = new System.Drawing.Size(874, 46);
            this.richTextBox_RegExpress.TabIndex = 7;
            this.richTextBox_RegExpress.Text = "";
            this.richTextBox_RegExpress.TextChanged += new System.EventHandler(this.richTextBox_RegExpress_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "正则对应关系";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(41, 418);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(874, 67);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(402, 39);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(45, 21);
            this.textBox8.TabIndex = 11;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(216, 39);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(45, 21);
            this.textBox7.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(168, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "Content";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(345, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "SrcType";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(65, 39);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(45, 21);
            this.textBox6.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "DateTime";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(402, 14);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(45, 21);
            this.textBox5.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(343, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "SiteName";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(216, 14);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(45, 21);
            this.textBox4.TabIndex = 3;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Title";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(65, 14);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(45, 21);
            this.textBox3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "URL";
            // 
            // richTextBox_Content
            // 
            this.richTextBox_Content.Location = new System.Drawing.Point(41, 518);
            this.richTextBox_Content.Name = "richTextBox_Content";
            this.richTextBox_Content.Size = new System.Drawing.Size(874, 62);
            this.richTextBox_Content.TabIndex = 10;
            this.richTextBox_Content.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(356, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "输出参数";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(672, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 13;
            this.label11.Text = "输出";
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(731, 163);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(184, 21);
            this.tb_path.TabIndex = 12;
            this.tb_path.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // richTextBox_hot
            // 
            this.richTextBox_hot.Location = new System.Drawing.Point(41, 287);
            this.richTextBox_hot.Name = "richTextBox_hot";
            this.richTextBox_hot.Size = new System.Drawing.Size(874, 46);
            this.richTextBox_hot.TabIndex = 14;
            this.richTextBox_hot.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 272);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 15;
            this.label12.Text = "正则捕获";
            // 
            // tb_codein
            // 
            this.tb_codein.Location = new System.Drawing.Point(41, 491);
            this.tb_codein.Name = "tb_codein";
            this.tb_codein.Size = new System.Drawing.Size(215, 21);
            this.tb_codein.TabIndex = 16;
            this.tb_codein.TextChanged += new System.EventHandler(this.tb_codein_TextChanged);
            // 
            // tb_codeout
            // 
            this.tb_codeout.Location = new System.Drawing.Point(262, 491);
            this.tb_codeout.Name = "tb_codeout";
            this.tb_codeout.Size = new System.Drawing.Size(653, 21);
            this.tb_codeout.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "Links";
            // 
            // tb_Link
            // 
            this.tb_Link.Location = new System.Drawing.Point(75, 133);
            this.tb_Link.Name = "tb_Link";
            this.tb_Link.Size = new System.Drawing.Size(840, 21);
            this.tb_Link.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(76, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "GetLink";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(39, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 22;
            this.label14.Text = "搜索参数";
            // 
            // tb_KeyWords
            // 
            this.tb_KeyWords.Location = new System.Drawing.Point(133, 100);
            this.tb_KeyWords.Name = "tb_KeyWords";
            this.tb_KeyWords.Size = new System.Drawing.Size(658, 21);
            this.tb_KeyWords.TabIndex = 21;
            this.tb_KeyWords.TextChanged += new System.EventHandler(this.tb_urlparam_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(240, 194);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "GetPage";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(39, 166);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 25;
            this.label15.Text = "输出参数";
            // 
            // tb_fileSeed
            // 
            this.tb_fileSeed.Location = new System.Drawing.Point(98, 163);
            this.tb_fileSeed.Name = "tb_fileSeed";
            this.tb_fileSeed.Size = new System.Drawing.Size(180, 21);
            this.tb_fileSeed.TabIndex = 24;
            // 
            // btn_match
            // 
            this.btn_match.Location = new System.Drawing.Point(321, 194);
            this.btn_match.Name = "btn_match";
            this.btn_match.Size = new System.Drawing.Size(75, 23);
            this.btn_match.TabIndex = 26;
            this.btn_match.Text = "匹配";
            this.btn_match.UseVisualStyleBackColor = true;
            this.btn_match.Click += new System.EventHandler(this.btn_match_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(402, 194);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 27;
            this.button4.Text = "映射";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // bn_OUTXML
            // 
            this.bn_OUTXML.Location = new System.Drawing.Point(483, 194);
            this.bn_OUTXML.Name = "bn_OUTXML";
            this.bn_OUTXML.Size = new System.Drawing.Size(75, 23);
            this.bn_OUTXML.TabIndex = 28;
            this.bn_OUTXML.Text = "输出";
            this.bn_OUTXML.UseVisualStyleBackColor = true;
            this.bn_OUTXML.Click += new System.EventHandler(this.bn_OUTXML_Click);
            // 
            // bn_do
            // 
            this.bn_do.Location = new System.Drawing.Point(840, 194);
            this.bn_do.Name = "bn_do";
            this.bn_do.Size = new System.Drawing.Size(75, 23);
            this.bn_do.TabIndex = 29;
            this.bn_do.Text = "输出";
            this.bn_do.UseVisualStyleBackColor = true;
            this.bn_do.Click += new System.EventHandler(this.bn_do_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(797, 103);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 31;
            this.label16.Text = "页数";
            // 
            // tb_pageCount
            // 
            this.tb_pageCount.Location = new System.Drawing.Point(844, 100);
            this.tb_pageCount.Name = "tb_pageCount";
            this.tb_pageCount.Size = new System.Drawing.Size(75, 21);
            this.tb_pageCount.TabIndex = 30;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(564, 194);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 32;
            this.button5.Text = "Hot";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // richTextBox_RegSameNews
            // 
            this.richTextBox_RegSameNews.Location = new System.Drawing.Point(41, 351);
            this.richTextBox_RegSameNews.Name = "richTextBox_RegSameNews";
            this.richTextBox_RegSameNews.Size = new System.Drawing.Size(874, 46);
            this.richTextBox_RegSameNews.TabIndex = 34;
            this.richTextBox_RegSameNews.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(39, 336);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 33;
            this.label17.Text = "相同正则";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(41, 587);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(179, 21);
            this.dateTimePicker1.TabIndex = 35;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(226, 585);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 36;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tb_seconds
            // 
            this.tb_seconds.Location = new System.Drawing.Point(321, 585);
            this.tb_seconds.Name = "tb_seconds";
            this.tb_seconds.Size = new System.Drawing.Size(183, 21);
            this.tb_seconds.TabIndex = 37;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(510, 583);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 38;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox_ts
            // 
            this.textBox_ts.Location = new System.Drawing.Point(591, 585);
            this.textBox_ts.Name = "textBox_ts";
            this.textBox_ts.Size = new System.Drawing.Size(171, 21);
            this.textBox_ts.TabIndex = 39;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 626);
            this.Controls.Add(this.textBox_ts);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.tb_seconds);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.richTextBox_RegSameNews);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tb_pageCount);
            this.Controls.Add(this.bn_do);
            this.Controls.Add(this.bn_OUTXML);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_match);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tb_fileSeed);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tb_KeyWords);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tb_Link);
            this.Controls.Add(this.tb_codeout);
            this.Controls.Add(this.tb_codein);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.richTextBox_hot);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.richTextBox_Content);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox_RegExpress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_URLSeed);
            this.Controls.Add(this.tb_path1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioBaiduNews;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioGoogle;
        private System.Windows.Forms.RadioButton radioSogouNews;
        private System.Windows.Forms.RadioButton radioBaidu;
        private System.Windows.Forms.TextBox tb_path1;
        private System.Windows.Forms.TextBox tb_URLSeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox_RegExpress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox richTextBox_Content;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.RichTextBox richTextBox_hot;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_codein;
        private System.Windows.Forms.TextBox tb_codeout;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_Link;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_KeyWords;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tb_fileSeed;
        private System.Windows.Forms.Button btn_match;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button bn_OUTXML;
        private System.Windows.Forms.Button bn_do;
        private System.Windows.Forms.RadioButton radioTianyaGoogle;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tb_pageCount;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RichTextBox richTextBox_RegSameNews;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox tb_seconds;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox_ts;
    }
}

