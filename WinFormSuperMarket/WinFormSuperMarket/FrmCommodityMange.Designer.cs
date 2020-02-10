namespace WinFormSuperMarket
{
    partial class FrmCommodityMange
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
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("正价商品");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("特价商品");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("所有商品", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            this.tv_Tree = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Mod = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.dgv_List = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).BeginInit();
            this.SuspendLayout();
            // 
            // tv_Tree
            // 
            this.tv_Tree.Location = new System.Drawing.Point(13, 13);
            this.tv_Tree.Name = "tv_Tree";
            treeNode4.Name = "正价商品";
            treeNode4.Text = "正价商品";
            treeNode5.Name = "特价商品";
            treeNode5.Text = "特价商品";
            treeNode6.Name = "所有商品";
            treeNode6.Text = "所有商品";
            this.tv_Tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.tv_Tree.Size = new System.Drawing.Size(188, 425);
            this.tv_Tree.TabIndex = 0;
            this.tv_Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Tree_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Close);
            this.groupBox1.Controls.Add(this.btn_Del);
            this.groupBox1.Controls.Add(this.btn_Mod);
            this.groupBox1.Controls.Add(this.btn_Add);
            this.groupBox1.Location = new System.Drawing.Point(208, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "商品显示";
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(260, 20);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 50);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "退出";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.Location = new System.Drawing.Point(179, 20);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(75, 50);
            this.btn_Del.TabIndex = 2;
            this.btn_Del.Text = "删除";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Mod
            // 
            this.btn_Mod.Location = new System.Drawing.Point(98, 20);
            this.btn_Mod.Name = "btn_Mod";
            this.btn_Mod.Size = new System.Drawing.Size(75, 50);
            this.btn_Mod.TabIndex = 1;
            this.btn_Mod.Text = "修改";
            this.btn_Mod.UseVisualStyleBackColor = true;
            this.btn_Mod.Click += new System.EventHandler(this.btn_Mod_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(17, 20);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 50);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "增加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // dgv_List
            // 
            this.dgv_List.AllowUserToAddRows = false;
            this.dgv_List.AllowUserToDeleteRows = false;
            this.dgv_List.AllowUserToResizeRows = false;
            this.dgv_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_List.Location = new System.Drawing.Point(208, 101);
            this.dgv_List.Name = "dgv_List";
            this.dgv_List.RowHeadersVisible = false;
            this.dgv_List.RowTemplate.Height = 23;
            this.dgv_List.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_List.Size = new System.Drawing.Size(608, 337);
            this.dgv_List.TabIndex = 2;
            // 
            // FrmCommodityMange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 451);
            this.Controls.Add(this.dgv_List);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tv_Tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCommodityMange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品列表";
            this.Load += new System.EventHandler(this.FrmCommodityMange_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv_Tree;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_Mod;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridView dgv_List;
    }
}