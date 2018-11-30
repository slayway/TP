namespace Project
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAdd1 = new System.Windows.Forms.Button();
            this.buttonShowTasksPJ = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAdd2 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.проектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказчикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.фильтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поСоздателюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поДатеСозданияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поТекущемуИспЛицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.календарьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDel1 = new System.Windows.Forms.Button();
            this.buttonDel2 = new System.Windows.Forms.Button();
            this.buttonChange1 = new System.Windows.Forms.Button();
            this.buttonChange2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 59);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(636, 325);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(226, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список проектов";
            // 
            // buttonAdd1
            // 
            this.buttonAdd1.BackColor = System.Drawing.Color.Yellow;
            this.buttonAdd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd1.Location = new System.Drawing.Point(21, 405);
            this.buttonAdd1.Name = "buttonAdd1";
            this.buttonAdd1.Size = new System.Drawing.Size(89, 39);
            this.buttonAdd1.TabIndex = 2;
            this.buttonAdd1.Text = "Добавить";
            this.buttonAdd1.UseVisualStyleBackColor = false;
            this.buttonAdd1.Click += new System.EventHandler(this.buttonCreatePj_Click);
            // 
            // buttonShowTasksPJ
            // 
            this.buttonShowTasksPJ.BackColor = System.Drawing.Color.Yellow;
            this.buttonShowTasksPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonShowTasksPJ.Location = new System.Drawing.Point(185, 405);
            this.buttonShowTasksPJ.Name = "buttonShowTasksPJ";
            this.buttonShowTasksPJ.Size = new System.Drawing.Size(89, 39);
            this.buttonShowTasksPJ.TabIndex = 3;
            this.buttonShowTasksPJ.Text = "Просмотр задач";
            this.buttonShowTasksPJ.UseVisualStyleBackColor = false;
            this.buttonShowTasksPJ.Click += new System.EventHandler(this.buttonShowTasksPJ_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(679, 60);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(526, 325);
            this.dataGridView2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(889, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Список задач";
            // 
            // buttonAdd2
            // 
            this.buttonAdd2.BackColor = System.Drawing.Color.Yellow;
            this.buttonAdd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd2.Location = new System.Drawing.Point(679, 405);
            this.buttonAdd2.Name = "buttonAdd2";
            this.buttonAdd2.Size = new System.Drawing.Size(89, 39);
            this.buttonAdd2.TabIndex = 6;
            this.buttonAdd2.Text = "Добавить";
            this.buttonAdd2.UseVisualStyleBackColor = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(195)))), ((int)(((byte)(226)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1183, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проектыToolStripMenuItem,
            this.заказчикиToolStripMenuItem,
            this.сотрудникиToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::Project.Properties.Resources.menuIcon;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "Меню";
            // 
            // проектыToolStripMenuItem
            // 
            this.проектыToolStripMenuItem.Name = "проектыToolStripMenuItem";
            this.проектыToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.проектыToolStripMenuItem.Text = "Проекты";
            this.проектыToolStripMenuItem.Click += new System.EventHandler(this.проектыToolStripMenuItem_Click);
            // 
            // заказчикиToolStripMenuItem
            // 
            this.заказчикиToolStripMenuItem.Name = "заказчикиToolStripMenuItem";
            this.заказчикиToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.заказчикиToolStripMenuItem.Text = "Заказчики";
            this.заказчикиToolStripMenuItem.Click += new System.EventHandler(this.заказчикиToolStripMenuItem_Click);
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(195)))), ((int)(((byte)(226)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фильтрToolStripMenuItem,
            this.документыToolStripMenuItem,
            this.календарьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(1183, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(88, 478);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // фильтрToolStripMenuItem
            // 
            this.фильтрToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поСоздателюToolStripMenuItem,
            this.поДатеСозданияToolStripMenuItem,
            this.поТекущемуИспЛицуToolStripMenuItem});
            this.фильтрToolStripMenuItem.Name = "фильтрToolStripMenuItem";
            this.фильтрToolStripMenuItem.Size = new System.Drawing.Size(75, 19);
            this.фильтрToolStripMenuItem.Text = "Фильтр";
            // 
            // поСоздателюToolStripMenuItem
            // 
            this.поСоздателюToolStripMenuItem.Name = "поСоздателюToolStripMenuItem";
            this.поСоздателюToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.поСоздателюToolStripMenuItem.Text = "По создателю";
            this.поСоздателюToolStripMenuItem.Click += new System.EventHandler(this.поСоздателюToolStripMenuItem_Click);
            // 
            // поДатеСозданияToolStripMenuItem
            // 
            this.поДатеСозданияToolStripMenuItem.Name = "поДатеСозданияToolStripMenuItem";
            this.поДатеСозданияToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.поДатеСозданияToolStripMenuItem.Text = "По дате создания";
            this.поДатеСозданияToolStripMenuItem.Click += new System.EventHandler(this.поДатеСозданияToolStripMenuItem_Click);
            // 
            // поТекущемуИспЛицуToolStripMenuItem
            // 
            this.поТекущемуИспЛицуToolStripMenuItem.Name = "поТекущемуИспЛицуToolStripMenuItem";
            this.поТекущемуИспЛицуToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.поТекущемуИспЛицуToolStripMenuItem.Text = "По текущему исп. лицу";
            this.поТекущемуИспЛицуToolStripMenuItem.Click += new System.EventHandler(this.поТекущемуИспЛицуToolStripMenuItem_Click);
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(75, 19);
            this.документыToolStripMenuItem.Text = "Документы";
            this.документыToolStripMenuItem.Click += new System.EventHandler(this.документыToolStripMenuItem_Click);
            // 
            // календарьToolStripMenuItem
            // 
            this.календарьToolStripMenuItem.Name = "календарьToolStripMenuItem";
            this.календарьToolStripMenuItem.Size = new System.Drawing.Size(75, 19);
            this.календарьToolStripMenuItem.Text = "Календарь";
            // 
            // buttonDel1
            // 
            this.buttonDel1.BackColor = System.Drawing.Color.Yellow;
            this.buttonDel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDel1.Location = new System.Drawing.Point(568, 405);
            this.buttonDel1.Name = "buttonDel1";
            this.buttonDel1.Size = new System.Drawing.Size(89, 39);
            this.buttonDel1.TabIndex = 9;
            this.buttonDel1.Text = "Удалить";
            this.buttonDel1.UseVisualStyleBackColor = false;
            // 
            // buttonDel2
            // 
            this.buttonDel2.BackColor = System.Drawing.Color.Yellow;
            this.buttonDel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDel2.Location = new System.Drawing.Point(1116, 405);
            this.buttonDel2.Name = "buttonDel2";
            this.buttonDel2.Size = new System.Drawing.Size(89, 39);
            this.buttonDel2.TabIndex = 10;
            this.buttonDel2.Text = "Удалить";
            this.buttonDel2.UseVisualStyleBackColor = false;
            // 
            // buttonChange1
            // 
            this.buttonChange1.BackColor = System.Drawing.Color.Yellow;
            this.buttonChange1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChange1.Location = new System.Drawing.Point(373, 405);
            this.buttonChange1.Name = "buttonChange1";
            this.buttonChange1.Size = new System.Drawing.Size(89, 39);
            this.buttonChange1.TabIndex = 11;
            this.buttonChange1.Text = "Изменить";
            this.buttonChange1.UseVisualStyleBackColor = false;
            // 
            // buttonChange2
            // 
            this.buttonChange2.BackColor = System.Drawing.Color.Yellow;
            this.buttonChange2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChange2.Location = new System.Drawing.Point(910, 405);
            this.buttonChange2.Name = "buttonChange2";
            this.buttonChange2.Size = new System.Drawing.Size(89, 39);
            this.buttonChange2.TabIndex = 12;
            this.buttonChange2.Text = "Изменить";
            this.buttonChange2.UseVisualStyleBackColor = false;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.BackgroundImage = global::Project.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(1271, 478);
            this.Controls.Add(this.buttonChange2);
            this.Controls.Add(this.buttonChange1);
            this.Controls.Add(this.buttonDel2);
            this.Controls.Add(this.buttonDel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonAdd2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.buttonShowTasksPJ);
            this.Controls.Add(this.buttonAdd1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1287, 517);
            this.MinimumSize = new System.Drawing.Size(1287, 517);
            this.Name = "AdminForm";
            this.Text = "Система управления проектами";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAdd1;
        private System.Windows.Forms.Button buttonShowTasksPJ;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAdd2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem проектыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказчикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem фильтрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поСоздателюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поДатеСозданияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поТекущемуИспЛицуToolStripMenuItem;
        private System.Windows.Forms.Button buttonDel1;
        private System.Windows.Forms.Button buttonDel2;
        private System.Windows.Forms.Button buttonChange1;
        private System.Windows.Forms.Button buttonChange2;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem календарьToolStripMenuItem;
    }
}