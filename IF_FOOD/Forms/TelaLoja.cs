using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFFood.Forms
{
    public partial class TelaLoja : Form
    {
        public TelaLoja()
        {
            InitializeComponent();

            trv_MenuAdmFunc.Font = new Font(trv_MenuAdmFunc.Font.FontFamily, 12f, FontStyle.Bold);

            foreach (TreeNode pai in trv_MenuAdmFunc.Nodes)
            {
                pai.NodeFont = null; // Garante que o pai herde a fonte do TreeView sem cortar

                foreach (TreeNode filho in pai.Nodes)
                {
                    filho.NodeFont = new Font(trv_MenuAdmFunc.Font.FontFamily, 10f, FontStyle.Regular);
                }
            }


        }

        bool Logado = true;
        private Panel _pnCadastrarU;
        private Form2 _telaOriginal;

        private void TelaLoja_Load(object sender, EventArgs e)
        {
            pn_T2P.Height = btn_T2Perfil.ClientSize.Height;
            pn_PMCarrinho.Height = btn_VerCarrinho.ClientSize.Height;
            pn_PMAdm.Height = btn_PMAdm.ClientSize.Height;
            _pnCadastrarU.Hide();

            
            //string URL = "Colocar aqui a URL da imagem";

            //mudar para os dados de login

            lbl_UserNameInfo.Text += "DualHeart";
            lbl_InfoNomeU.Text += "Gabriel Verissimo";
            lbl_EmailInfoU.Text += "gabrielverissimo673@gmail.com";
            lbl_IdadeInfoU.Text += "17";
            pb_FPerfilinfoU.SizeMode = PictureBoxSizeMode.Zoom;
            //pb_FPerfilinfoU.LoadAsync(URL); mudar a foto do perfil para a escolhida pelo usuario no login

            //ajustar pra verificar o tipo de usuario e mostrar o menu de administrador caso seja um adm
            /*remover/ajustar*/
            string tipoUsuario = "adm";
            if (tipoUsuario != "adm")
            {
                pn_PMAdm.Hide();
            }

            _telaOriginal?.VerificarLogado(Logado);


            TelaLoja_Resize(this, EventArgs.Empty);

        }


        public TelaLoja(Panel Cadastrar, Form2 form2) : this()
        {
            _telaOriginal = form2;

            if (Cadastrar != null)
            {
                _pnCadastrarU = Cadastrar;
                _pnCadastrarU.Parent?.Controls.Remove(_pnCadastrarU);

                this.Controls.Add(_pnCadastrarU);
                _pnCadastrarU.Location = new Point(20, 20);
                _pnCadastrarU.Enabled = true;
                _pnCadastrarU.Visible = true;
                _pnCadastrarU.BringToFront();
            }
        }

        //bool do botao perfil
        bool BPerfil = false;

        private async void btn_T2Perfil_Click(object sender, EventArgs e)
        {
            BPerfil = !BPerfil;
            if (BPerfil == false)
            {
                do
                {
                    pn_T2P.Height -= 10;
                    await Task.Delay(1);

                } while (pn_T2P.Height > btn_T2Perfil.ClientSize.Height);


            }
            else
            {
                do
                {
                    pn_T2P.Height += 10;
                    await Task.Delay(1);

                } while (pn_T2P.Height < 256);



            }
        }

        //bool do botao carrinho
        bool BCarrinho = false;

        private async void btn_VerCarrinho_Click(object sender, EventArgs e)
        {
            BCarrinho = !BCarrinho;
            if (BCarrinho == false)
            {
                do
                {
                    pn_PMCarrinho.Height -= 10;
                    await Task.Delay(1);

                } while (pn_PMCarrinho.Height > btn_VerCarrinho.ClientSize.Height);
            }
            else
            {
                do
                {
                    pn_PMCarrinho.Height += 10;
                    await Task.Delay(1);

                } while (pn_PMCarrinho.Height < 256);
            }
        }

        //bool do botao menu de administrador
        bool BMenuAdm = false;
        private async void btn_PMAdm_Click(object sender, EventArgs e)
        {
            BMenuAdm = !BMenuAdm;
            if (BMenuAdm == false)
            {
                

                do
                {
                    pn_PMAdm.Height -= 10;
                    await Task.Delay(1);

                } while (pn_PMAdm.Height > btn_PMAdm.ClientSize.Height);
                


                //AjustarMenuAdm();
            }
            else
            {
                trv_MenuAdmFunc.CollapseAll();
                AjustarAlturaTreeView();
                do
                {
                    pn_PMAdm.Height += 10;
                    await Task.Delay(1);

                } while (pn_PMAdm.Height < (trv_MenuAdmFunc.ClientSize.Height + btn_PMAdm.ClientSize.Height + 30));

                
                //AjustarMenuAdm();
            }
        }






        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pb_FPerfilinfoU_Click(object sender, EventArgs e)
        {

        }

        private void pn_PerfilInfoU_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TelaLoja_Resize(object sender, EventArgs e)
        {
            lbl_InfoNomeU.MaximumSize = new Size((pn_PerfilInfoU.Width - pb_FPerfilinfoU.ClientSize.Width - 10), 0);
            lbl_EmailInfoU.MaximumSize = new Size((pn_OutrosDadosInfoU.Width - 10), 0);
            lbl_UserNameInfo.MaximumSize = new Size((pn_PerfilInfoU.Width - pb_FPerfilinfoU.ClientSize.Width - 10), 0);


            pn_CNomeInfoU.Height = lbl_InfoNomeU.Height + lbl_UserNameInfo.Height;
            pn_OutrosDadosInfoU.Height = lbl_EmailInfoU.Height + lbl_IdadeInfoU.Height + 20;


            pn_PerfilInfoU.Height = pn_CNomeInfoU.Height + pn_OutrosDadosInfoU.Height + 30;
            //flp_PerfilInfoU.Height = pn_CNomeInfoU.Height + pn_OutrosDadosInfoU.Height + 10;


            _telaOriginal?.AlinharPainel(_pnCadastrarU, this);


        }

        private void flp_PerfilInfoU_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trv_MenuAdmFunc_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "no_CadastrarProd":
                    MessageBox.Show("Cadastro de Produtos");

                    break;

                case "no_EditarProd":
                    MessageBox.Show("Editar Produtos");

                    break;

                case "no_ListarProd":
                    MessageBox.Show("Listar Produtos");

                    break;

                case "no_CadastrarUs":
                    MessageBox.Show("Cadastro de Funcionários");
                    _pnCadastrarU.Show();
                    break;

                case "no_EditarUs":
                    MessageBox.Show("Editar Funcionários");
                    break;

                case "no_ListarUs":
                    MessageBox.Show("Listar Funcionários");
                    break;



                default:
                    break;
            }
        }

        private void AjustarAlturaTreeView()
        {
            if (trv_MenuAdmFunc.Nodes.Count == 0)
                return;

            int totalLinhasVisiveis = 0;

            foreach (TreeNode pai in trv_MenuAdmFunc.Nodes)
            {
                totalLinhasVisiveis++; // O nó pai sempre conta
                if (pai.IsExpanded)
                {
                    totalLinhasVisiveis += pai.GetNodeCount(false);
                }
            }

            int alturaLinha = trv_MenuAdmFunc.ItemHeight > 0
                ? trv_MenuAdmFunc.ItemHeight
                : trv_MenuAdmFunc.Font.Height + 6;

            int novaAltura = (totalLinhasVisiveis * alturaLinha) + 8;

            if (trv_MenuAdmFunc.Height != novaAltura)
            {
                trv_MenuAdmFunc.Height = novaAltura;
            }
        }



        //muda a altura do painel de acordo com a altura do treeview, mas não deixa ultrapassar a altura do form
        private void AjustarMenuAdm()
        {
            pn_PMAdm.Height = trv_MenuAdmFunc.ClientSize.Height + btn_PMAdm.ClientSize.Height + 30;
        }

        private void trv_MenuAdmFunc_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            AjustarAlturaTreeView();
            AjustarMenuAdm();
        }

        private void trv_MenuAdmFunc_AfterExpand(object sender, TreeViewEventArgs e)
        {
            AjustarAlturaTreeView();
            AjustarMenuAdm();
        }
    }
}
