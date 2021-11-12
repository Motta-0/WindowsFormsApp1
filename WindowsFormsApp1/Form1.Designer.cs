namespace Elevator
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.outDown = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outUp = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cageGrid1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.inside1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.outDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cageGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inside1)).BeginInit();
            this.SuspendLayout();
            // 
            // outDown
            // 
            this.outDown.AllowUserToAddRows = false;
            this.outDown.AllowUserToDeleteRows = false;
            this.outDown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outDown.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            this.outDown.Location = new System.Drawing.Point(748, 30);
            this.outDown.Name = "outDown";
            this.outDown.ReadOnly = true;
            this.outDown.RowHeadersVisible = false;
            this.outDown.RowHeadersWidth = 40;
            this.outDown.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.outDown.RowTemplate.Height = 24;
            this.outDown.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.outDown.Size = new System.Drawing.Size(40, 399);
            this.outDown.TabIndex = 0;
            this.outDown.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.outDown_CellClick);
            this.outDown.SelectionChanged += new System.EventHandler(this.outDown_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn3.HeaderText = "";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 1;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // outUp
            // 
            this.outUp.AllowUserToAddRows = false;
            this.outUp.AllowUserToDeleteRows = false;
            this.outUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outUp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.outUp.Location = new System.Drawing.Point(692, 30);
            this.outUp.Name = "outUp";
            this.outUp.ReadOnly = true;
            this.outUp.RowHeadersVisible = false;
            this.outUp.RowHeadersWidth = 40;
            this.outUp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.outUp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.outUp.Size = new System.Drawing.Size(40, 399);
            this.outUp.TabIndex = 1;
            this.outUp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.outUp_CellClick);
            this.outUp.SelectionChanged += new System.EventHandler(this.outUp_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn2.HeaderText = "";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 1;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // cageGrid1
            // 
            this.cageGrid1.AllowUserToAddRows = false;
            this.cageGrid1.AllowUserToDeleteRows = false;
            this.cageGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.cageGrid1.ColumnHeadersVisible = false;
            this.cageGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.cageGrid1.Location = new System.Drawing.Point(323, 30);
            this.cageGrid1.Name = "cageGrid1";
            this.cageGrid1.ReadOnly = true;
            this.cageGrid1.RowHeadersVisible = false;
            this.cageGrid1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cageGrid1.Size = new System.Drawing.Size(105, 399);
            this.cageGrid1.TabIndex = 2;
            this.cageGrid1.SelectionChanged += new System.EventHandler(this.cageGrid1_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle19.NullValue")));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle19;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // inside1
            // 
            this.inside1.AllowUserToAddRows = false;
            this.inside1.AllowUserToDeleteRows = false;
            this.inside1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inside1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.inside1.Location = new System.Drawing.Point(12, 12);
            this.inside1.Name = "inside1";
            this.inside1.ReadOnly = true;
            this.inside1.RowHeadersVisible = false;
            this.inside1.RowHeadersWidth = 40;
            this.inside1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.inside1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inside1.Size = new System.Drawing.Size(40, 426);
            this.inside1.TabIndex = 3;
            this.inside1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inside1_CellClick);
            this.inside1.SelectionChanged += new System.EventHandler(this.inside1_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 1;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.inside1);
            this.Controls.Add(this.cageGrid1);
            this.Controls.Add(this.outUp);
            this.Controls.Add(this.outDown);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.outDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cageGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inside1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView outDown;
        private System.Windows.Forms.DataGridView outUp;
        private System.Windows.Forms.DataGridView cageGrid1;
        private System.Windows.Forms.DataGridView inside1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Timer timer1;
    }
}

