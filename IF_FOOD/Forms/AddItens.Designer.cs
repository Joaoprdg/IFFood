namespace IFFood
{
    partial class WAddItens
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WAddItens));
            lb_Lista = new ListBox();
            btn_Fechar = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lb_Lista
            // 
            lb_Lista.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_Lista.FormattingEnabled = true;
            lb_Lista.ItemHeight = 36;
            lb_Lista.Location = new Point(7, 13);
            lb_Lista.Margin = new Padding(3, 4, 3, 4);
            lb_Lista.Name = "lb_Lista";
            lb_Lista.Size = new Size(599, 364);
            lb_Lista.TabIndex = 0;
            lb_Lista.SelectedIndexChanged += lb_Lista_SelectedIndexChanged;
            lb_Lista.DoubleClick += lb_Lista_DoubleClick;
            // 
            // btn_Fechar
            // 
            btn_Fechar.Font = new Font("Arial Narrow", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Fechar.Location = new Point(242, 407);
            btn_Fechar.Margin = new Padding(3, 4, 3, 4);
            btn_Fechar.Name = "btn_Fechar";
            btn_Fechar.Size = new Size(158, 64);
            btn_Fechar.TabIndex = 9;
            btn_Fechar.Text = "Fechar";
            btn_Fechar.UseVisualStyleBackColor = true;
            btn_Fechar.Click += btn_Fechar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(457, 399);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(115, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // WAddItens
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(621, 491);
            Controls.Add(pictureBox1);
            Controls.Add(btn_Fechar);
            Controls.Add(lb_Lista);
            Margin = new Padding(3, 4, 3, 4);
            Name = "WAddItens";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lista de Produtos";
            Load += Add_Itens_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lb_Lista;
        private Button btn_Fechar;
        private PictureBox pictureBox1;
    }
}