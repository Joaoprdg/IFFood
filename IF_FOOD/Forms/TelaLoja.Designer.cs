namespace IFFood.Forms
{
    partial class TelaLoja
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
            TreeNode treeNode1 = new TreeNode("- Cadastrar");
            TreeNode treeNode2 = new TreeNode("- Editar");
            TreeNode treeNode3 = new TreeNode("- Listar");
            TreeNode treeNode4 = new TreeNode("+ Produtos", new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            TreeNode treeNode5 = new TreeNode("- Cadastrar");
            TreeNode treeNode6 = new TreeNode("- Editar");
            TreeNode treeNode7 = new TreeNode("- Listar");
            TreeNode treeNode8 = new TreeNode("+ Gestão de Usuários", new TreeNode[] { treeNode5, treeNode6, treeNode7 });
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pn_PerfilInfoU = new Panel();
            flp_PerfilInfoU = new FlowLayoutPanel();
            pn_CNomeInfoU = new Panel();
            lbl_UserNameInfo = new Label();
            pb_FPerfilinfoU = new PictureBox();
            lbl_InfoNomeU = new Label();
            pn_OutrosDadosInfoU = new Panel();
            lbl_IdadeInfoU = new Label();
            lbl_EmailInfoU = new Label();
            pn_T2P = new Panel();
            btn_T2Perfil = new Button();
            pn_PMCarrinho = new Panel();
            btn_VerCarrinho = new Button();
            pn_PMAdm = new Panel();
            trv_MenuAdmFunc = new TreeView();
            btn_PMAdm = new Button();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pn_PerfilInfoU.SuspendLayout();
            flp_PerfilInfoU.SuspendLayout();
            pn_CNomeInfoU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_FPerfilinfoU).BeginInit();
            pn_OutrosDadosInfoU.SuspendLayout();
            pn_T2P.SuspendLayout();
            pn_PMCarrinho.SuspendLayout();
            pn_PMAdm.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(361, 853);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(pn_PerfilInfoU);
            flowLayoutPanel1.Controls.Add(pn_T2P);
            flowLayoutPanel1.Controls.Add(pn_PMCarrinho);
            flowLayoutPanel1.Controls.Add(pn_PMAdm);
            flowLayoutPanel1.Location = new Point(24, 34);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(292, 1145);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // pn_PerfilInfoU
            // 
            pn_PerfilInfoU.BackColor = Color.Gainsboro;
            pn_PerfilInfoU.Controls.Add(flp_PerfilInfoU);
            pn_PerfilInfoU.Location = new Point(3, 3);
            pn_PerfilInfoU.Name = "pn_PerfilInfoU";
            pn_PerfilInfoU.Size = new Size(287, 192);
            pn_PerfilInfoU.TabIndex = 1;
            pn_PerfilInfoU.Paint += pn_PerfilInfoU_Paint;
            // 
            // flp_PerfilInfoU
            // 
            flp_PerfilInfoU.Controls.Add(pn_CNomeInfoU);
            flp_PerfilInfoU.Controls.Add(pn_OutrosDadosInfoU);
            flp_PerfilInfoU.FlowDirection = FlowDirection.TopDown;
            flp_PerfilInfoU.Location = new Point(3, 17);
            flp_PerfilInfoU.Name = "flp_PerfilInfoU";
            flp_PerfilInfoU.Size = new Size(281, 170);
            flp_PerfilInfoU.TabIndex = 0;
            flp_PerfilInfoU.Paint += flp_PerfilInfoU_Paint;
            // 
            // pn_CNomeInfoU
            // 
            pn_CNomeInfoU.BackColor = Color.Transparent;
            pn_CNomeInfoU.Controls.Add(lbl_UserNameInfo);
            pn_CNomeInfoU.Controls.Add(pb_FPerfilinfoU);
            pn_CNomeInfoU.Controls.Add(lbl_InfoNomeU);
            pn_CNomeInfoU.Location = new Point(3, 3);
            pn_CNomeInfoU.MinimumSize = new Size(0, 70);
            pn_CNomeInfoU.Name = "pn_CNomeInfoU";
            pn_CNomeInfoU.Size = new Size(275, 70);
            pn_CNomeInfoU.TabIndex = 3;
            // 
            // lbl_UserNameInfo
            // 
            lbl_UserNameInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbl_UserNameInfo.AutoSize = true;
            lbl_UserNameInfo.Location = new Point(3, 35);
            lbl_UserNameInfo.Name = "lbl_UserNameInfo";
            lbl_UserNameInfo.Size = new Size(18, 20);
            lbl_UserNameInfo.TabIndex = 3;
            lbl_UserNameInfo.Text = "#";
            // 
            // pb_FPerfilinfoU
            // 
            pb_FPerfilinfoU.BackColor = Color.Transparent;
            pb_FPerfilinfoU.Image = Properties.Resources._8207765;
            pb_FPerfilinfoU.Location = new Point(215, 0);
            pb_FPerfilinfoU.Name = "pb_FPerfilinfoU";
            pb_FPerfilinfoU.Size = new Size(60, 60);
            pb_FPerfilinfoU.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_FPerfilinfoU.TabIndex = 2;
            pb_FPerfilinfoU.TabStop = false;
            pb_FPerfilinfoU.Click += pb_FPerfilinfoU_Click;
            // 
            // lbl_InfoNomeU
            // 
            lbl_InfoNomeU.AutoSize = true;
            lbl_InfoNomeU.BackColor = Color.Transparent;
            lbl_InfoNomeU.Font = new Font("Segoe UI", 10F);
            lbl_InfoNomeU.Location = new Point(3, 3);
            lbl_InfoNomeU.Name = "lbl_InfoNomeU";
            lbl_InfoNomeU.Size = new Size(66, 23);
            lbl_InfoNomeU.TabIndex = 1;
            lbl_InfoNomeU.Text = "Nome: ";
            // 
            // pn_OutrosDadosInfoU
            // 
            pn_OutrosDadosInfoU.BackColor = Color.Transparent;
            pn_OutrosDadosInfoU.Controls.Add(lbl_IdadeInfoU);
            pn_OutrosDadosInfoU.Controls.Add(lbl_EmailInfoU);
            pn_OutrosDadosInfoU.Location = new Point(3, 79);
            pn_OutrosDadosInfoU.MinimumSize = new Size(0, 75);
            pn_OutrosDadosInfoU.Name = "pn_OutrosDadosInfoU";
            pn_OutrosDadosInfoU.Size = new Size(275, 75);
            pn_OutrosDadosInfoU.TabIndex = 4;
            // 
            // lbl_IdadeInfoU
            // 
            lbl_IdadeInfoU.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbl_IdadeInfoU.AutoSize = true;
            lbl_IdadeInfoU.Location = new Point(10, 46);
            lbl_IdadeInfoU.Name = "lbl_IdadeInfoU";
            lbl_IdadeInfoU.Size = new Size(54, 20);
            lbl_IdadeInfoU.TabIndex = 1;
            lbl_IdadeInfoU.Text = "Idade: ";
            // 
            // lbl_EmailInfoU
            // 
            lbl_EmailInfoU.AutoSize = true;
            lbl_EmailInfoU.BackColor = Color.Transparent;
            lbl_EmailInfoU.Location = new Point(10, 11);
            lbl_EmailInfoU.Name = "lbl_EmailInfoU";
            lbl_EmailInfoU.Size = new Size(59, 20);
            lbl_EmailInfoU.TabIndex = 0;
            lbl_EmailInfoU.Text = "E-Mail: ";
            // 
            // pn_T2P
            // 
            pn_T2P.BackColor = Color.DimGray;
            pn_T2P.Controls.Add(btn_T2Perfil);
            pn_T2P.Location = new Point(3, 201);
            pn_T2P.Name = "pn_T2P";
            pn_T2P.Size = new Size(287, 256);
            pn_T2P.TabIndex = 0;
            // 
            // btn_T2Perfil
            // 
            btn_T2Perfil.Location = new Point(0, 0);
            btn_T2Perfil.Name = "btn_T2Perfil";
            btn_T2Perfil.Size = new Size(287, 50);
            btn_T2Perfil.TabIndex = 0;
            btn_T2Perfil.Text = "Editar Perfil";
            btn_T2Perfil.UseVisualStyleBackColor = true;
            btn_T2Perfil.Click += btn_T2Perfil_Click;
            // 
            // pn_PMCarrinho
            // 
            pn_PMCarrinho.BackColor = Color.DimGray;
            pn_PMCarrinho.Controls.Add(btn_VerCarrinho);
            pn_PMCarrinho.Location = new Point(3, 463);
            pn_PMCarrinho.Name = "pn_PMCarrinho";
            pn_PMCarrinho.Size = new Size(289, 253);
            pn_PMCarrinho.TabIndex = 1;
            // 
            // btn_VerCarrinho
            // 
            btn_VerCarrinho.Location = new Point(2, 0);
            btn_VerCarrinho.Name = "btn_VerCarrinho";
            btn_VerCarrinho.Size = new Size(287, 50);
            btn_VerCarrinho.TabIndex = 1;
            btn_VerCarrinho.Text = "Ver Carrinho";
            btn_VerCarrinho.UseVisualStyleBackColor = true;
            btn_VerCarrinho.Click += btn_VerCarrinho_Click;
            // 
            // pn_PMAdm
            // 
            pn_PMAdm.BackColor = Color.DimGray;
            pn_PMAdm.Controls.Add(trv_MenuAdmFunc);
            pn_PMAdm.Controls.Add(btn_PMAdm);
            pn_PMAdm.Location = new Point(3, 722);
            pn_PMAdm.Name = "pn_PMAdm";
            pn_PMAdm.Size = new Size(289, 270);
            pn_PMAdm.TabIndex = 2;
            // 
            // trv_MenuAdmFunc
            // 
            trv_MenuAdmFunc.BackColor = SystemColors.Menu;
            trv_MenuAdmFunc.Location = new Point(9, 65);
            trv_MenuAdmFunc.MinimumSize = new Size(272, 0);
            trv_MenuAdmFunc.Name = "trv_MenuAdmFunc";
            treeNode1.Name = "no_CadastrarProd";
            treeNode1.Text = "- Cadastrar";
            treeNode2.Name = "no_EditarProd";
            treeNode2.Text = "- Editar";
            treeNode3.Name = "no_ListarProd";
            treeNode3.Text = "- Listar";
            treeNode4.Name = "no_EdicaoProdutos";
            treeNode4.NodeFont = new Font("Microsoft Sans Serif", 12.2F, FontStyle.Bold);
            treeNode4.Text = "+ Produtos";
            treeNode5.Name = "no_CadastrarUs";
            treeNode5.Text = "- Cadastrar";
            treeNode6.Name = "no_EditarUs";
            treeNode6.Text = "- Editar";
            treeNode7.Name = "no_ListarUs";
            treeNode7.Text = "- Listar";
            treeNode8.Name = "no_EdicaoUsuarios";
            treeNode8.NodeFont = new Font("Microsoft Sans Serif", 12.8F, FontStyle.Bold);
            treeNode8.Text = "+ Gestão de Usuários";
            trv_MenuAdmFunc.Nodes.AddRange(new TreeNode[] { treeNode4, treeNode8 });
            trv_MenuAdmFunc.Size = new Size(272, 173);
            trv_MenuAdmFunc.TabIndex = 2;
            trv_MenuAdmFunc.AfterCollapse += trv_MenuAdmFunc_AfterCollapse;
            trv_MenuAdmFunc.AfterExpand += trv_MenuAdmFunc_AfterExpand;
            trv_MenuAdmFunc.NodeMouseClick += trv_MenuAdmFunc_NodeMouseClick;
            // 
            // btn_PMAdm
            // 
            btn_PMAdm.Location = new Point(2, 0);
            btn_PMAdm.Name = "btn_PMAdm";
            btn_PMAdm.Size = new Size(287, 50);
            btn_PMAdm.TabIndex = 1;
            btn_PMAdm.Text = "Abril Menu de Administrador";
            btn_PMAdm.UseVisualStyleBackColor = true;
            btn_PMAdm.Click += btn_PMAdm_Click;
            // 
            // TelaLoja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1082, 853);
            Controls.Add(panel1);
            MinimumSize = new Size(1100, 900);
            Name = "TelaLoja";
            Text = "TelaLoja";
            Load += TelaLoja_Load;
            Resize += TelaLoja_Resize;
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            pn_PerfilInfoU.ResumeLayout(false);
            flp_PerfilInfoU.ResumeLayout(false);
            pn_CNomeInfoU.ResumeLayout(false);
            pn_CNomeInfoU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_FPerfilinfoU).EndInit();
            pn_OutrosDadosInfoU.ResumeLayout(false);
            pn_OutrosDadosInfoU.PerformLayout();
            pn_T2P.ResumeLayout(false);
            pn_PMCarrinho.ResumeLayout(false);
            pn_PMAdm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DateTimePicker dateTimePicker1;
        private Button btn_T2Perfil;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel pn_T2P;
        private Panel pn_PMCarrinho;
        private Button btn_VerCarrinho;
        private Button btn_PMAdm;
        private Label lbl_InfoNomeU;
        private Panel pn_PerfilInfoU;
        private PictureBox pb_FPerfilinfoU;
        private FlowLayoutPanel flp_PerfilInfoU;
        private Panel pn_CNomeInfoU;
        private Label lbl_UserNameInfo;
        private Panel pn_OutrosDadosInfoU;
        private Label lbl_IdadeInfoU;
        private Label lbl_EmailInfoU;
        private Panel pn_PMAdm;
        private TreeView trv_MenuAdmFunc;
    }
}