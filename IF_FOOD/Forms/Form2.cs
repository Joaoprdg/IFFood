using IFFood.Classes;
using IFFood.Classes.BD;
using IFFood.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace IFFood
{
    public partial class Form2 : Form
    {
        Usuario U;
        UsuarioBD UBD = new UsuarioBD();
        Verificadores V = new Verificadores();
        // Guarda o tamanho/posição e a fonte originais de cada controle para não acumular erro ao redimensionar
        //parte do responsivo do login
        Dictionary<Control, Rectangle> originaisEntrar = new Dictionary<Control, Rectangle>();
        Dictionary<Control, float> fontesOriginaisEntrar = new Dictionary<Control, float>();

        // Guarda o tamanho/posição e a fonte originais de cada controle para não acumular erro ao redimensionar
        //parte do responsivo do cadastro
        Dictionary<Control, Rectangle> originaisCadastrar = new Dictionary<Control, Rectangle>();
        Dictionary<Control, float> fontesOriginaisCadastrar = new Dictionary<Control, float>();

        //parte do menu lateral com dados e a logo
        Dictionary<Control, Rectangle> originaisLateral = new Dictionary<Control, Rectangle>();
        Dictionary<Control, float> fontesOriginaisLateral = new Dictionary<Control, float>();

        bool Logado = false;

        public Form2()
        {
            InitializeComponent();
        }

        // faz os botoes de cadastrar e entrar ficarem arredondados

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Width = 900;
            this.Height = 900;
            cmb_TipoUsuario.SelectedIndex = 0;

            pn_ImagensPerfil.Height = 0;

            if (Logado == false)
            {
                cmb_TipoUsuario.Hide();
                lbl_TipoUsuario.Hide();
            }
            else
            {
                cmb_TipoUsuario.Show();
                lbl_TipoUsuario.Show();
            }





            foreach (Control c in pn_Entrar.Controls)
            {
                originaisEntrar[c] = new Rectangle(c.Left, c.Top, c.Width, c.Height);
                fontesOriginaisEntrar[c] = c.Font.Size;
            }

            foreach (Control c in pn_Cadastrar.Controls)
            {
                if (c != pn_ImagensPerfil) // pn_ImagensPerfil tem Dock = Top e altura animada por código
                {
                    originaisCadastrar[c] = new Rectangle(c.Left, c.Top, c.Width, c.Height);
                    fontesOriginaisCadastrar[c] = c.Font.Size;
                }
            }


            // psrte do menu lateral
            foreach (Control c in pn_LateralTelaPrincipal.Controls)
            {
                originaisLateral[c] = new Rectangle(c.Left, c.Top, c.Width, c.Height);
                fontesOriginaisLateral[c] = c.Font.Size;
            }

            foreach (Control c in pn_InfoBasicas.Controls)
            {
                originaisLateral[c] = new Rectangle(c.Left, c.Top, c.Width, c.Height);
                fontesOriginaisLateral[c] = c.Font.Size;
            }



            VerificarLogado(Logado);
            //faz já começar formatado
            Form2_Resize(this, EventArgs.Empty);

            //this.MinimumSize = new Size(750, 750);


        }




        private void btn_CancelarCadastro_Click(object sender, EventArgs e)
        {
            CancelarCadastro();
        }

        private async void btn_EditarImagem_Click(object sender, EventArgs e)
        {
            //pn_ImagensPerfil.Show();
            do
            {
                pn_ImagensPerfil.Height += 10;
                await Task.Delay(1);
            } while (pn_ImagensPerfil.Height < 181);
        }

        private void pn_ImagensPerfil_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btn_SubirMenuEscolheImagem_Click(object sender, EventArgs e)
        {
            do
            {
                pn_ImagensPerfil.Height -= 10;
                await Task.Delay(1);
            } while (pn_ImagensPerfil.Height > 0);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pn_Cadastrar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            pn_Cadastrar.Show();
            pn_Cadastrar.BringToFront();

            //desabilita todos os controles das outras coisas
            foreach (Control c in this.Controls)
            {
                if (c != pn_Cadastrar)
                    c.Enabled = false;
            }

        }

        private void btn_Entrar_Click(object sender, EventArgs e)
        {
            pn_Entrar.Show();
            pn_Entrar.BringToFront();

            //desabilita todos os controles das outras coisas
            foreach (Control c in this.Controls)
            {
                if (c != pn_Entrar)
                    c.Enabled = false;
            }
        }

        private void btn_CancelarLogin_Click(object sender, EventArgs e)
        {
            CancelarLogin();
        }

        private void llbl_TerConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CancelarCadastro();

            pn_Entrar.Show();
            pn_Entrar.BringToFront();

            //desabilita todos os controles das outras coisas
            foreach (Control c in this.Controls)
            {
                if (c != pn_Entrar)
                    c.Enabled = false;
            }
        }

        private void llbl_NãoTerConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CancelarLogin();



            pn_Cadastrar.Show();
            pn_Cadastrar.BringToFront();

            //desabilita todos os controles das outras coisas
            foreach (Control c in this.Controls)
            {
                if (c != pn_Cadastrar)
                {
                    c.Enabled = false;

                }
            }
        }

        private void btn_ConfirmarCadastro_Click(object sender, EventArgs e)
        {
            if (tb_ConfirmaSenha.Text == tb_SenhaUsuario.Text)
            {
                try
                {
                    if (!V.CamposEstaoPreenchidos(tb_CodigoUsuario, tb_SenhaUsuario, tb_NomeUsuario, tb_IdadeUsuario, tb_EmailUsuario))
                    {
                        MessageBox.Show("Preencha todos os campos obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        if (tb_CodigoUsuario.Text.Length < 5 || tb_CodigoUsuario.Text.Length > 20)
                        {
                            MessageBox.Show("O Tamanho do usuário precisa estar entre 5 e 20!", "Aviso");
                        }
                        else
                        {
                            if (tb_SenhaUsuario.Text.Length < 5 || tb_SenhaUsuario.Text.Length > 12)
                            {
                                MessageBox.Show("O Tamanho da senha precisa estar entre 5 e 12!", "Aviso");
                            }
                            else
                            {
                                U = new Usuario(tb_CodigoUsuario.Text, tb_SenhaUsuario.Text, tb_NomeUsuario.Text, tb_IdadeUsuario.Text, tb_EmailUsuario.Text, cmb_TipoUsuario.SelectedIndex, cmb_GeneroUsuario.SelectedItem.ToString());
                                UsuarioBD UBD = new UsuarioBD();
                                UBD.Inserir(U);
                                MessageBox.Show("Usuario Cadastrado com sucesso!");

                            }
                        }
                    }


                }
                catch (OracleException ex)
                {
                    MessageBox.Show($"Erro no banco Oracle ({ex.Number}): {ex.Message}", "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error); // vai carrega icone de alerta amarelo e o botao pra continuar
                }

            }
            else
            {
                MessageBox.Show("As senhas não coincidem!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }





        private void btn_ExcluirFotoPerfil_Click(object sender, EventArgs e)
        {
            pb_FotoPerfil.Image = IFFood.Properties.Resources._8207765;
            rb_Foto1.Checked = false;
            rb_Foto2.Checked = false;
            rb_Foto3.Checked = false;
            rb_Foto4.Checked = false;
            rb_Foto5.Checked = false;
            rb_Foto6.Checked = false;

        }

        private void rb_Foto1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Foto1.Checked)
            {
                pb_FotoPerfil.Image = pb_Foto01.Image;

            }
        }

        private void rb_Foto2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Foto2.Checked)
            {
                pb_FotoPerfil.Image = pb_Foto02.Image;

            }
        }

        private void rb_Foto3_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Foto3.Checked)
            {
                pb_FotoPerfil.Image = pb_Foto03.Image;

            }
        }

        private void rb_Foto4_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Foto4.Checked)
            {
                pb_FotoPerfil.Image = pb_Foto04.Image;

            }
        }

        private void rb_Foto5_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Foto5.Checked)
            {
                pb_FotoPerfil.Image = pb_Foto05.Image;

            }
        }

        private void rb_Foto6_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Foto6.Checked)
            {
                pb_FotoPerfil.Image = pb_Foto06.Image;

            }
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            //Garante que os paineis fiquem centralizados na tela
            AlinharPainel(pn_Cadastrar, this);
            AlinharPainel(pn_Entrar, this);

            pn_Entrar.Width = Math.Max(360, (int)(this.ClientSize.Width * (385.0 / 900.0)));
            pn_Entrar.Height = Math.Max(385, (int)(this.ClientSize.Height * (388.0 / 900.0)));



            // RESPONSIVO ENTRAR //

            //ver se as coisas do titulo estao salvas e ajudsta a posição pra ficar relativa
            if (originaisEntrar.ContainsKey(lbl_TituloLogin))
            {
                lbl_TituloLogin.Left = Math.Max(originaisEntrar[lbl_TituloLogin].X, (int)(originaisEntrar[lbl_TituloLogin].X * (pn_Entrar.Width / 385.0)));
                lbl_TituloLogin.Top = Math.Max(originaisEntrar[lbl_TituloLogin].Y, (int)(originaisEntrar[lbl_TituloLogin].Y * (pn_Entrar.Height / 388.0)));
                lbl_TituloLogin.Font = new Font(lbl_TituloLogin.Font.FontFamily, Math.Max(fontesOriginaisEntrar[lbl_TituloLogin], (float)(fontesOriginaisEntrar[lbl_TituloLogin] * (1.0 + (Math.Min(pn_Entrar.Width / 385.0, pn_Entrar.Height / 388.0) - 1.0) * 0.4))), lbl_TituloLogin.Font.Style);
            }

            //ve se o campo de usuario ta salvo e ajusta
            if (originaisEntrar.ContainsKey(tb_CodigoLogin))
            {
                tb_CodigoLogin.SetBounds(
                    Math.Max(originaisEntrar[tb_CodigoLogin].X, (int)(originaisEntrar[tb_CodigoLogin].X * (pn_Entrar.Width / 385.0))),
                    Math.Max(originaisEntrar[tb_CodigoLogin].Y, (int)(originaisEntrar[tb_CodigoLogin].Y * (pn_Entrar.Height / 388.0))),
                    Math.Min(pn_Entrar.Width - (2 * Math.Max(originaisEntrar[tb_CodigoLogin].X, (int)(originaisEntrar[tb_CodigoLogin].X * (pn_Entrar.Width / 385.0)))), Math.Max(originaisEntrar[tb_CodigoLogin].Width, (int)(originaisEntrar[tb_CodigoLogin].Width * (1.0 + ((pn_Entrar.Width / 385.0) - 1.0) * 0.65)))),
                    originaisEntrar[tb_CodigoLogin].Height
                );
                tb_CodigoLogin.Font = new Font(tb_CodigoLogin.Font.FontFamily, Math.Max(fontesOriginaisEntrar[tb_CodigoLogin], (float)(fontesOriginaisEntrar[tb_CodigoLogin] * (1.0 + (Math.Min(pn_Entrar.Width / 385.0, pn_Entrar.Height / 388.0) - 1.0) * 0.15))), tb_CodigoLogin.Font.Style);
            }

            //campo da senha ta salvo e ajusta pra ficar bonitin
            if (originaisEntrar.ContainsKey(tb_SenhaLogin))
            {
                tb_SenhaLogin.SetBounds(
                    Math.Max(originaisEntrar[tb_SenhaLogin].X, (int)(originaisEntrar[tb_SenhaLogin].X * (pn_Entrar.Width / 385.0))),
                    Math.Max(originaisEntrar[tb_SenhaLogin].Y, (int)(originaisEntrar[tb_SenhaLogin].Y * (pn_Entrar.Height / 388.0))),
                    Math.Min(pn_Entrar.Width - (2 * Math.Max(originaisEntrar[tb_SenhaLogin].X, (int)(originaisEntrar[tb_SenhaLogin].X * (pn_Entrar.Width / 385.0)))), Math.Max(originaisEntrar[tb_SenhaLogin].Width, (int)(originaisEntrar[tb_SenhaLogin].Width * (1.0 + ((pn_Entrar.Width / 385.0) - 1.0) * 0.65)))),
                    originaisEntrar[tb_SenhaLogin].Height
                );
                tb_SenhaLogin.Font = new Font(tb_SenhaLogin.Font.FontFamily, Math.Max(fontesOriginaisEntrar[tb_SenhaLogin], (float)(fontesOriginaisEntrar[tb_SenhaLogin] * (1.0 + (Math.Min(pn_Entrar.Width / 385.0, pn_Entrar.Height / 388.0) - 1.0) * 0.15))), tb_SenhaLogin.Font.Style);
            }

            //ve se ta salvo eajusta os botões de entrar e cancelar
            if (originaisEntrar.ContainsKey(btn_CancelarLogin) && originaisEntrar.ContainsKey(btn_ConfirmarLogin))
            {
                // 1. Primeiro define tamanho e fonte dos dois botões
                btn_CancelarLogin.Width = Math.Max(originaisEntrar[btn_CancelarLogin].Width, (int)(originaisEntrar[btn_CancelarLogin].Width * (pn_Entrar.Width / 385.0)));
                btn_CancelarLogin.Height = Math.Max(originaisEntrar[btn_CancelarLogin].Height, (int)(originaisEntrar[btn_CancelarLogin].Height * (pn_Entrar.Height / 388.0)));
                btn_CancelarLogin.Font = new Font(btn_CancelarLogin.Font.FontFamily, Math.Max(fontesOriginaisEntrar[btn_CancelarLogin], (float)(fontesOriginaisEntrar[btn_CancelarLogin] * (1.0 + (Math.Min(pn_Entrar.Width / 385.0, pn_Entrar.Height / 388.0) - 1.0) * 0.35))), btn_CancelarLogin.Font.Style);

                btn_ConfirmarLogin.Width = Math.Max(originaisEntrar[btn_ConfirmarLogin].Width, (int)(originaisEntrar[btn_ConfirmarLogin].Width * (pn_Entrar.Width / 385.0)));
                btn_ConfirmarLogin.Height = Math.Max(originaisEntrar[btn_ConfirmarLogin].Height, (int)(originaisEntrar[btn_ConfirmarLogin].Height * (pn_Entrar.Height / 388.0)));
                btn_ConfirmarLogin.Font = new Font(btn_ConfirmarLogin.Font.FontFamily, Math.Max(fontesOriginaisEntrar[btn_ConfirmarLogin], (float)(fontesOriginaisEntrar[btn_ConfirmarLogin] * (1.0 + (Math.Min(pn_Entrar.Width / 385.0, pn_Entrar.Height / 388.0) - 1.0) * 0.35))), btn_ConfirmarLogin.Font.Style);

                // 2. Depois posiciona usando o Width já atualizado do btn_ConfirmarLogin
                btn_CancelarLogin.Left = Math.Max(originaisEntrar[btn_CancelarLogin].X, (int)(originaisEntrar[btn_CancelarLogin].X * (pn_Entrar.Width / 385.0)));
                btn_CancelarLogin.Top = Math.Max(originaisEntrar[btn_CancelarLogin].Y, (int)(originaisEntrar[btn_CancelarLogin].Y * (pn_Entrar.Height / 388.0)));

                btn_ConfirmarLogin.Left = Math.Max(
                    btn_CancelarLogin.Right + 10,
                    pn_Entrar.Width - btn_CancelarLogin.Left - btn_ConfirmarLogin.Width - 10
                );
                btn_ConfirmarLogin.Top = btn_CancelarLogin.Top;

                //corrigi um bug qnd tentava colocar em tela cheia qnd era mt pequeno
            }

            //
            if (originaisEntrar.ContainsKey(llbl_NãoTerConta))
            {
                llbl_NãoTerConta.Left = Math.Max(originaisEntrar[llbl_NãoTerConta].X, pn_Entrar.Width - originaisEntrar[llbl_NãoTerConta].Width - Math.Max(originaisEntrar[btn_CancelarLogin].X, (int)(originaisEntrar[btn_CancelarLogin].X * (pn_Entrar.Width / 385.0))));
                llbl_NãoTerConta.Top = Math.Max(originaisEntrar[llbl_NãoTerConta].Y, (int)(originaisEntrar[llbl_NãoTerConta].Y * (pn_Entrar.Height / 388.0)));
                llbl_NãoTerConta.Font = new Font(llbl_NãoTerConta.Font.FontFamily, Math.Max(fontesOriginaisEntrar[llbl_NãoTerConta], (float)(fontesOriginaisEntrar[llbl_NãoTerConta] * (1.0 + (Math.Min(pn_Entrar.Width / 385.0, pn_Entrar.Height / 388.0) - 1.0) * 0.3))), llbl_NãoTerConta.Font.Style);
            }

            //
            if (originaisEntrar.ContainsKey(lbl_NPC))
            {
                lbl_NPC.Left = Math.Max(originaisEntrar[lbl_NPC].X, pn_Entrar.Width - lbl_NPC.Width - Math.Max(originaisEntrar[btn_CancelarLogin].X, (int)(originaisEntrar[btn_CancelarLogin].X * (pn_Entrar.Width / 385.0))) - 15); lbl_NPC.Top = Math.Max(originaisEntrar[lbl_NPC].Y, (int)(originaisEntrar[lbl_NPC].Y * (pn_Entrar.Height / 388.0)));
                lbl_NPC.Font = new Font(lbl_NPC.Font.FontFamily, Math.Max(fontesOriginaisEntrar[lbl_NPC], (float)(fontesOriginaisEntrar[lbl_NPC] * (1.0 + (Math.Min(pn_Entrar.Width / 385.0, pn_Entrar.Height / 388.0) - 1.0) * 0.3))), lbl_NPC.Font.Style);
            }

            pn_Cadastrar.Width = Math.Max(645, (int)(this.ClientSize.Width * (643.0 / 900.0)));
            pn_Cadastrar.Height = Math.Max(600, (int)(this.ClientSize.Height * (595.0 / 900.0)));


            // RESPONSIVO CADASTRAR //
            pn_Cadastrar.Width = Math.Min(800, Math.Max(643, (int)(this.ClientSize.Width * (643.0 / 900.0))));
            pn_Cadastrar.Height = Math.Min(800, Math.Max(595, (int)(this.ClientSize.Height * (595.0 / 900.0))));

            // RESPONSIVO CADASTRAR //
            foreach (var item in originaisCadastrar)
            {
                Control c = item.Key;
                Rectangle r = item.Value;

                if (c == btn_EditarImagem || c == btn_ExcluirFotoPerfil || c == pb_MostraSenha || c == lbl_JPC || c == llbl_TerConta)
                    continue;

                int novoX = Math.Max(r.X, (int)(r.X * (pn_Cadastrar.Width / 643.0)));
                int novoY = Math.Max(r.Y, (int)(r.Y * (pn_Cadastrar.Height / 595.0)));
                int novoW = Math.Max(r.Width, (int)(r.Width * (pn_Cadastrar.Width / 643.0)));
                int novoH = Math.Max(r.Height, (int)(r.Height * (pn_Cadastrar.Height / 595.0)));

                if (c == pb_FotoPerfil)
                {
                    novoW = Math.Max(r.Width, (int)(r.Width * Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0)));
                    novoH = Math.Max(r.Height, (int)(r.Height * Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0)));
                }

                c.SetBounds(novoX, novoY, novoW, novoH);

                if (fontesOriginaisCadastrar.ContainsKey(c))
                {
                    c.Font = new Font(
                        c.Font.FontFamily,
                        Math.Max(
                            fontesOriginaisCadastrar[c],
                            (float)(fontesOriginaisCadastrar[c] * (1.0 + (Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0) - 1.0) * (c == label1 ? 0.4 : 0.35)))
                        ),
                        c.Font.Style
                    );
                }
            }

            // Botões de editar e excluir foto colados na lateral/cantos da pb_FotoPerfil
            if (originaisCadastrar.ContainsKey(btn_EditarImagem) && originaisCadastrar.ContainsKey(btn_ExcluirFotoPerfil))
            {
                btn_EditarImagem.SetBounds(
                    pb_FotoPerfil.Right - (Math.Max(35, (int)(35 * Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0))) / 2),
                    pb_FotoPerfil.Top,
                    Math.Max(35, (int)(35 * Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0))),
                    Math.Max(35, (int)(35 * Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0)))
                );

                btn_ExcluirFotoPerfil.SetBounds(
                    pb_FotoPerfil.Right - (Math.Max(35, (int)(35 * Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0))) / 2),
                    pb_FotoPerfil.Bottom - Math.Max(35, (int)(35 * Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0))),
                    Math.Max(35, (int)(35 * Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0))),
                    Math.Max(35, (int)(35 * Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0)))
                );
            }

            // Ícone de olho alinhado à direita do tb_SenhaUsuario
            if (originaisCadastrar.ContainsKey(pb_MostraSenha))
            {
                pb_MostraSenha.SetBounds(
                    tb_SenhaUsuario.Right + 4,
                    tb_SenhaUsuario.Top + (tb_SenhaUsuario.Height - Math.Max(Visivel ? 30 : 20, (int)((Visivel ? 30 : 20) * Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0)))) / 2,
                    Math.Max(27, (int)(27 * Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0))),
                    Math.Max(Visivel ? 30 : 20, (int)((Visivel ? 30 : 20) * Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0)))
                );
            }

            // Alinha pela direita igual no pn_Entrar
            if (originaisCadastrar.ContainsKey(llbl_TerConta))
            {
                llbl_TerConta.Font = new Font(
                    llbl_TerConta.Font.FontFamily,
                    Math.Max(fontesOriginaisCadastrar[llbl_TerConta], (float)(fontesOriginaisCadastrar[llbl_TerConta] * (1.0 + (Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0) - 1.0) * 0.3))),
                    llbl_TerConta.Font.Style
                );
                llbl_TerConta.Top = Math.Max(originaisCadastrar[llbl_TerConta].Y, (int)(originaisCadastrar[llbl_TerConta].Y * (pn_Cadastrar.Height / 595.0)));
                llbl_TerConta.Left = Math.Max(10, pn_Cadastrar.Width - llbl_TerConta.Width - Math.Max(24, (int)(24 * (pn_Cadastrar.Width / 643.0))));
            }

            if (originaisCadastrar.ContainsKey(lbl_JPC))
            {
                lbl_JPC.Font = new Font(
                    lbl_JPC.Font.FontFamily,
                    Math.Max(fontesOriginaisCadastrar[lbl_JPC], (float)(fontesOriginaisCadastrar[lbl_JPC] * (1.0 + (Math.Min(pn_Cadastrar.Width / 643.0, pn_Cadastrar.Height / 595.0) - 1.0) * 0.3))),
                    lbl_JPC.Font.Style
                );
                lbl_JPC.Top = Math.Max(originaisCadastrar[lbl_JPC].Y, (int)(originaisCadastrar[lbl_JPC].Y * (pn_Cadastrar.Height / 595.0)));
                lbl_JPC.Left = Math.Max(10, pn_Cadastrar.Width - lbl_JPC.Width - Math.Max(24, (int)(24 * (pn_Cadastrar.Width / 643.0))) - 15);
            }

            // RESPONSIVO IMAGENS E RADIOBUTTONS DE PERFIL (6 COLUNAS IGUAIS) //
            if (pn_ImagensPerfil.Width > 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    ((i == 0) ? pb_Foto01 : (i == 1) ? pb_Foto02 : (i == 2) ? pb_Foto03 : (i == 3) ? pb_Foto04 : (i == 4) ? pb_Foto05 : pb_Foto06).SetBounds(
                        ((i * (pn_ImagensPerfil.Width / 6)) + ((pn_ImagensPerfil.Width / 6) / 2)) - (Math.Max(85, Math.Min((pn_ImagensPerfil.Width / 6) - 16, (int)(85 * (1.0 + (Math.Min(pn_ImagensPerfil.Width / 643.0, pn_ImagensPerfil.Height / 595.0) - 1.0) * 0.15)))) / 2),
                        Math.Max(8, (pn_ImagensPerfil.Height - 37 - Math.Max(85, Math.Min((pn_ImagensPerfil.Width / 6) - 16, (int)(85 * (1.0 + (Math.Min(pn_ImagensPerfil.Width / 643.0, pn_ImagensPerfil.Height / 595.0) - 1.0) * 0.15)))) - 24) / 2),
                        Math.Max(85, Math.Min((pn_ImagensPerfil.Width / 6) - 16, (int)(85 * (1.0 + (Math.Min(pn_ImagensPerfil.Width / 643.0, pn_ImagensPerfil.Height / 595.0) - 1.0) * 0.15)))),
                        Math.Max(85, Math.Min((pn_ImagensPerfil.Width / 6) - 16, (int)(85 * (1.0 + (Math.Min(pn_ImagensPerfil.Width / 643.0, pn_ImagensPerfil.Height / 595.0) - 1.0) * 0.15))))
                    );

                    ((i == 0) ? rb_Foto1 : (i == 1) ? rb_Foto2 : (i == 2) ? rb_Foto3 : (i == 3) ? rb_Foto4 : (i == 4) ? rb_Foto5 : rb_Foto6).Location = new Point(
                        ((i * (pn_ImagensPerfil.Width / 6)) + ((pn_ImagensPerfil.Width / 6) / 2)) - (((i == 0) ? rb_Foto1 : (i == 1) ? rb_Foto2 : (i == 2) ? rb_Foto3 : (i == 3) ? rb_Foto4 : (i == 4) ? rb_Foto5 : rb_Foto6).Width / 2),
                        ((i == 0) ? pb_Foto01 : (i == 1) ? pb_Foto02 : (i == 2) ? pb_Foto03 : (i == 3) ? pb_Foto04 : (i == 4) ? pb_Foto05 : pb_Foto06).Bottom + 6
                    );
                }
            }

            if (originaisEntrar.ContainsKey(cb_MostrarSenha))
            {
                cb_MostrarSenha.Font = new Font(
                    cb_MostrarSenha.Font.FontFamily,
                    Math.Max(fontesOriginaisEntrar[cb_MostrarSenha], (float)(fontesOriginaisEntrar[cb_MostrarSenha] * (1.0 + (Math.Min(pn_Entrar.Width / 385.0, pn_Entrar.Height / 388.0) - 1.0) * 0.25))),
                    cb_MostrarSenha.Font.Style
                );
                cb_MostrarSenha.Location = new Point(
                    Math.Max(originaisEntrar[cb_MostrarSenha].X, (int)(originaisEntrar[cb_MostrarSenha].X * (pn_Entrar.Width / 385.0))),
                    Math.Min(
                        btn_CancelarLogin.Top - cb_MostrarSenha.Height - 6,
                        Math.Max(
                            tb_SenhaLogin.Bottom + 6,
                            (int)(originaisEntrar[cb_MostrarSenha].Y * (pn_Entrar.Height / 388.0))
                        )
                    )
                );
            }



            // 2. Centraliza DEPOIS de mudar Width e Height, sem deixar sair da tela
            // serve pra nn bugar e deixar pra tras da tela
            pn_Entrar.Left = Math.Max(0, (this.ClientSize.Width - pn_Entrar.Width) / 2);
            pn_Entrar.Top = Math.Max(0, (this.ClientSize.Height - pn_Entrar.Height) / 2);



            pn_Cadastrar.Left = Math.Max(0, (this.ClientSize.Width - pn_Cadastrar.Width) / 2);
            pn_Cadastrar.Top = Math.Max(0, (this.ClientSize.Height - pn_Cadastrar.Height) / 2);



            pn_LateralTelaPrincipal.Width = (int)(ClientSize.Width * 0.52);
            pb_LogoIFFood.Left = Math.Max(0, (pn_LateralTelaPrincipal.ClientSize.Width - pb_LogoIFFood.Width) / 2);// imagem no meio

            pn_DireitaBotaoPrincipal.Width = (int)(ClientSize.Width * 0.47);

            // Centraliza os botões na tela
            btn_Entrar.Left = Math.Max(0, (pn_DireitaBotaoPrincipal.ClientSize.Width - btn_Entrar.Width) / 2);
            btn_Cadastrar.Left = Math.Max(0, (pn_DireitaBotaoPrincipal.ClientSize.Width - btn_Cadastrar.Width) / 2);
            btn_Sair.Left = Math.Max(0, (pn_DireitaBotaoPrincipal.ClientSize.Width - btn_Sair.Width) / 2);
            btn_VerPagina.Left = Math.Max(0, (pn_DireitaBotaoPrincipal.ClientSize.Width - btn_VerPagina.Width) / 2);

            //redimensiona os botoes
            btn_Entrar.Width = Math.Min(pn_DireitaBotaoPrincipal.ClientSize.Width - 24, Math.Max(315, (int)(315 * (1.0 + ((pn_DireitaBotaoPrincipal.ClientSize.Width / 423.0) - 1.0) * 0.35))));
            btn_Entrar.Height = Math.Min(130, Math.Max(93, (int)(93 * (1.0 + ((pn_DireitaBotaoPrincipal.ClientSize.Height / 860.0) - 1.0) * 0.25))));
            btn_Entrar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Entrar.Width, btn_Entrar.Height, 60, 60));

            btn_Cadastrar.Width = Math.Min(pn_DireitaBotaoPrincipal.ClientSize.Width - 24, Math.Max(315, (int)(315 * (1.0 + ((pn_DireitaBotaoPrincipal.ClientSize.Width / 423.0) - 1.0) * 0.35))));
            btn_Cadastrar.Height = Math.Min(130, Math.Max(93, (int)(93 * (1.0 + ((pn_DireitaBotaoPrincipal.ClientSize.Height / 860.0) - 1.0) * 0.25))));
            btn_Cadastrar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Cadastrar.Width, btn_Cadastrar.Height, 60, 60));

            btn_VerPagina.Width = Math.Min(pn_DireitaBotaoPrincipal.ClientSize.Width - 24, Math.Max(315, (int)(315 * (1.0 + ((pn_DireitaBotaoPrincipal.ClientSize.Width / 423.0) - 1.0) * 0.35))));
            btn_VerPagina.Height = Math.Min(130, Math.Max(93, (int)(93 * (1.0 + ((pn_DireitaBotaoPrincipal.ClientSize.Height / 860.0) - 1.0) * 0.25))));
            btn_VerPagina.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_VerPagina.Width, btn_VerPagina.Height, 60, 60));

            btn_Sair.Width = Math.Min(pn_DireitaBotaoPrincipal.ClientSize.Width - 24, Math.Max(315, (int)(315 * (1.0 + ((pn_DireitaBotaoPrincipal.ClientSize.Width / 423.0) - 1.0) * 0.35))));
            btn_Sair.Height = Math.Min(130, Math.Max(93, (int)(93 * (1.0 + ((pn_DireitaBotaoPrincipal.ClientSize.Height / 860.0) - 1.0) * 0.25))));
            btn_Sair.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Sair.Width, btn_Sair.Height, 60, 60));

            //1 Calcula a largura do botao, com um minimo e maximo
            //2 Calcula a altura do botao, com um minimo e maximo
            //3 Recria a região arredondada (60x60) usando os novos tamanhos para os cantos não ficarem cortados após redimensionar

            // Espaçamento vertical igual entre os 4 botões (5 intervalos iguais: topo, entre eles e base)
            btn_Entrar.Top = Math.Max(12, (pn_DireitaBotaoPrincipal.ClientSize.Height - (btn_Entrar.Height + btn_Cadastrar.Height + btn_VerPagina.Height + btn_Sair.Height)) / 5);
            btn_Cadastrar.Top = btn_Entrar.Bottom + Math.Max(12, (pn_DireitaBotaoPrincipal.ClientSize.Height - (btn_Entrar.Height + btn_Cadastrar.Height + btn_VerPagina.Height + btn_Sair.Height)) / 5);
            btn_VerPagina.Top = btn_Cadastrar.Bottom + Math.Max(12, (pn_DireitaBotaoPrincipal.ClientSize.Height - (btn_Entrar.Height + btn_Cadastrar.Height + btn_VerPagina.Height + btn_Sair.Height)) / 5);
            btn_Sair.Top = btn_VerPagina.Bottom + Math.Max(12, (pn_DireitaBotaoPrincipal.ClientSize.Height - (btn_Entrar.Height + btn_Cadastrar.Height + btn_VerPagina.Height + btn_Sair.Height)) / 5);


            //centralizando textos informativos
            lbl_NomeEscola.Left = Math.Max(0, (pn_LateralTelaPrincipal.ClientSize.Width - lbl_NomeEscola.Width) / 2);
            pn_InfoBasicas.Left = Math.Max(0, (pn_LateralTelaPrincipal.ClientSize.Width - pn_InfoBasicas.Width) / 2);

            //Responsivo do menu lateral
            if (originaisLateral.ContainsKey(pb_LogoIFFood))
            {
                pb_LogoIFFood.SetBounds(
                    Math.Max(0, (pn_LateralTelaPrincipal.ClientSize.Width - Math.Min(pn_LateralTelaPrincipal.ClientSize.Width - 24, Math.Max(140, (int)(originaisLateral[pb_LogoIFFood].Width * (1.0 + (Math.Min(pn_LateralTelaPrincipal.ClientSize.Width / 468.0, pn_LateralTelaPrincipal.ClientSize.Height / 860.0) - 1.0) * 0.45))))) / 2),
                    Math.Max(12, (int)(originaisLateral[pb_LogoIFFood].Y * (pn_LateralTelaPrincipal.ClientSize.Height / 860.0))),
                    Math.Min(pn_LateralTelaPrincipal.ClientSize.Width - 24, Math.Max(140, (int)(originaisLateral[pb_LogoIFFood].Width * (1.0 + (Math.Min(pn_LateralTelaPrincipal.ClientSize.Width / 468.0, pn_LateralTelaPrincipal.ClientSize.Height / 860.0) - 1.0) * 0.45)))),
                    Math.Max(140, (int)(originaisLateral[pb_LogoIFFood].Height * (1.0 + (Math.Min(pn_LateralTelaPrincipal.ClientSize.Width / 468.0, pn_LateralTelaPrincipal.ClientSize.Height / 860.0) - 1.0) * 0.45)))
                );
            }

            if (originaisLateral.ContainsKey(pn_InfoBasicas))
            {
                pn_InfoBasicas.SetBounds(
                    Math.Max(8, (pn_LateralTelaPrincipal.ClientSize.Width - Math.Min(pn_LateralTelaPrincipal.ClientSize.Width - 24, Math.Max(260, (int)(originaisLateral[pn_InfoBasicas].Width * (1.0 + ((pn_LateralTelaPrincipal.ClientSize.Width / 468.0) - 1.0) * 0.55))))) / 2),
                    pb_LogoIFFood.Bottom + Math.Max(12, (pn_LateralTelaPrincipal.ClientSize.Height - pb_LogoIFFood.Height - Math.Max(220, (int)(originaisLateral[pn_InfoBasicas].Height * (1.0 + ((pn_LateralTelaPrincipal.ClientSize.Height / 860.0) - 1.0) * 0.35))) - lbl_NomeEscola.Height) / 3),
                    Math.Min(pn_LateralTelaPrincipal.ClientSize.Width - 24, Math.Max(260, (int)(originaisLateral[pn_InfoBasicas].Width * (1.0 + ((pn_LateralTelaPrincipal.ClientSize.Width / 468.0) - 1.0) * 0.55)))),
                    Math.Max(220, (int)(originaisLateral[pn_InfoBasicas].Height * (1.0 + ((pn_LateralTelaPrincipal.ClientSize.Height / 860.0) - 1.0) * 0.35)))
                );

                foreach (Control c in pn_InfoBasicas.Controls)
                {
                    if (originaisLateral.ContainsKey(c) && fontesOriginaisLateral.ContainsKey(c))
                    {
                        c.Font = new Font(
                            c.Font.FontFamily,
                            Math.Max(
                                fontesOriginaisLateral[c],
                                (float)(fontesOriginaisLateral[c] * (1.0 + (Math.Min(
                                    pn_InfoBasicas.Width / (double)Math.Max(1, originaisLateral[pn_InfoBasicas].Width),
                                    pn_InfoBasicas.Height / (double)Math.Max(1, originaisLateral[pn_InfoBasicas].Height)
                                ) - 1.0) * 0.14))
                            ),
                            c.Font.Style
                        );

                        c.SetBounds(
                            Math.Max(4, (int)(originaisLateral[c].X * (pn_InfoBasicas.Width / (double)Math.Max(1, originaisLateral[pn_InfoBasicas].Width)))),
                            Math.Max(4, (int)(originaisLateral[c].Y * (pn_InfoBasicas.Height / (double)Math.Max(1, originaisLateral[pn_InfoBasicas].Height)))),
                            Math.Max(40, Math.Min(pn_InfoBasicas.ClientSize.Width - Math.Max(4, (int)(originaisLateral[c].X * (pn_InfoBasicas.Width / (double)Math.Max(1, originaisLateral[pn_InfoBasicas].Width)))) - 4, (int)(originaisLateral[c].Width * (pn_InfoBasicas.Width / (double)Math.Max(1, originaisLateral[pn_InfoBasicas].Width))))),
                            Math.Max(20, Math.Min(pn_InfoBasicas.ClientSize.Height - Math.Max(4, (int)(originaisLateral[c].Y * (pn_InfoBasicas.Height / (double)Math.Max(1, originaisLateral[pn_InfoBasicas].Height)))) - 4, (int)(originaisLateral[c].Height * (pn_InfoBasicas.Height / (double)Math.Max(1, originaisLateral[pn_InfoBasicas].Height)))))
                        );
                    }
                }
            }
            if (originaisLateral.ContainsKey(lbl_NomeEscola) && fontesOriginaisLateral.ContainsKey(lbl_NomeEscola))
            {
                lbl_NomeEscola.Font = new Font(
                    lbl_NomeEscola.Font.FontFamily,
                    Math.Max(
                        fontesOriginaisLateral[lbl_NomeEscola],
                        (float)(fontesOriginaisLateral[lbl_NomeEscola] * (1.0 + (Math.Min(
                            pn_LateralTelaPrincipal.ClientSize.Width / 468.0,
                            pn_LateralTelaPrincipal.ClientSize.Height / 860.0
                        ) - 1.0) * 0.15))
                    ),
                    lbl_NomeEscola.Font.Style
                );

                lbl_NomeEscola.Left = Math.Max(0, (pn_LateralTelaPrincipal.ClientSize.Width - lbl_NomeEscola.Width) / 2);
                lbl_NomeEscola.Top = pn_InfoBasicas.Bottom + 14;
            }




        }

        private void pn_Cadastrar_Resize(object sender, EventArgs e)
        {

            if (pn_Cadastrar.Width > 800)
            {
                pn_Cadastrar.Width = 800;
            }
            if (pn_Cadastrar.Height > 800)
            {
                pn_Cadastrar.Height = 800;
            }
        }




        private void pn_Entrar_Resize(object sender, EventArgs e)
        {

            if (pn_Entrar.Width > 500)
            {
                pn_Entrar.Width = 500;
            }
            if (pn_Entrar.Height > 800)
            {
                pn_Entrar.Height = 800;
            }

        }

        private void pn_Entrar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CancelarCadastro()
        {
            pn_Cadastrar.Hide();
            pn_ImagensPerfil.Height = 0;

            //limpa os campos de cadastro
            tb_CodigoUsuario.Text = "";
            tb_ConfirmaSenha.Text = "";
            tb_EmailUsuario.Text = "";
            tb_IdadeUsuario.Text = "";
            tb_NomeUsuario.Text = "";
            tb_SenhaUsuario.Text = "";
            cmb_GeneroUsuario.SelectedIndex = -1;
            cmb_TipoUsuario.SelectedIndex = 0;
            pb_FotoPerfil.Image = IFFood.Properties.Resources._8207765;


            //habilita todos os controles das outras coisas
            foreach (Control c in this.Controls)
            {
                if (c != pn_Cadastrar)
                    c.Enabled = true;
            }
        }

        private void CancelarLogin()
        {
            pn_Entrar.Hide();
            //habilita todos os controles das outras coisas
            foreach (Control c in this.Controls)
            {
                if (c != pn_Entrar)
                    c.Enabled = true;
            }
            tb_CodigoLogin.Text = "";
            tb_SenhaLogin.Text = "";

        }

        private void tb_IdadeUsuario_TextChanged(object? sender, EventArgs e)
        {
            string limpo = new string(Array.FindAll(tb_IdadeUsuario.Text.ToCharArray(), char.IsDigit));
            if (tb_IdadeUsuario.Text == limpo) return;

            tb_IdadeUsuario.TextChanged -= tb_IdadeUsuario_TextChanged;
            tb_IdadeUsuario.Text = limpo;
            tb_IdadeUsuario.SelectionStart = limpo.Length;
            tb_IdadeUsuario.TextChanged += tb_IdadeUsuario_TextChanged;
        }

        // Bloqueia teclas que não sejam dígitos numéricos (0-9) ou teclas de controle (ex.: Backspace) durante a digitação
        private void tb_IdadeUsuario_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Impede o caractere de ser inserido no TextBox
            }
        }

        //Verifica se o botão para ocultar senha esta marcado ou nao
        private bool Visivel = true;
        private void pb_MostraSenha_Click(object sender, EventArgs e)
        {
            Visivel = !Visivel;

            if (Visivel == true)
            {

                pb_MostraSenha.Image = IFFood.Properties.Resources.OcultarSenhaLogin;
                tb_SenhaUsuario.PasswordChar = '●';
                pb_MostraSenha.Height = 30;
            }
            else
            {

                pb_MostraSenha.Image = IFFood.Properties.Resources.MostrarSenhaLogin;
                tb_SenhaUsuario.PasswordChar = '\0';
                pb_MostraSenha.Height = 20;
            }


            //pb_MostraSenha.Image = Visivel ? IF_FOOD.Properties.Resources.MostrarSenhaLogin : IF_FOOD.Properties.Resources.OcultarSenhaLogin;
        }

        private void cb_MostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_MostrarSenha.Checked)
            {
                tb_SenhaLogin.PasswordChar = '\0'; // Mostra a senha
            }
            else
            {
                tb_SenhaLogin.PasswordChar = '●'; // Oculta a senha
            }
        }

        private void tb_SenhaUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pb_LogoIFFood_Click(object sender, EventArgs e)
        {

        }



        private void pn_DireitaBotaoPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_VerPagina_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://github.com/Joaoprdg/IFFood/tree/master/IF_FOOD", //mudar para a pagina do projeto
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o link: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ConfirmarLogin_Click(object sender, EventArgs e)
        {
            if (UBD.VerificaLogin(tb_CodigoLogin.Text, tb_SenhaLogin.Text))
            {
                MessageBox.Show("Logado com sucesso!");
                this.Hide();
                U = UBD.PegaDados(U, tb_CodigoLogin.Text);
                TelaLoja segundaTela = new TelaLoja(this.pn_Cadastrar, this, U);
                segundaTela.Show();
            }
            else
            {
                MessageBox.Show("Usuario ou senha incorretos!");
            }
        }

        //cuidado
        public void ReceberPainelDeVolta(Panel painel)
        {
            if (painel != null && !this.Controls.Contains(painel))
            {
                painel.Parent?.Controls.Remove(painel);
                this.Controls.Add(painel);
                painel.Hide();
            }
        }


        private void lbl_NomeEscola_Click(object sender, EventArgs e)
        {

        }

        private void lbl_POrg_Click(object sender, EventArgs e)
        {

        }


        public void VerificarLogado(bool Logado)
        {
            if (Logado == false)
            {
                cmb_TipoUsuario.Hide();
                lbl_TipoUsuario.Hide();
                lbl_JPC.Show();
                llbl_TerConta.Show();
            }
            else
            {
                cmb_TipoUsuario.Show();
                lbl_TipoUsuario.Show();
                lbl_JPC.Hide();
                llbl_TerConta.Hide();
            }
        }

        public void AlinharPainel(Panel painel, Form tela)
        {
            if (painel != null && tela != null)
            {
                painel.Left = Math.Max(0, (tela.ClientSize.Width - painel.Width) / 2);
                painel.Top = Math.Max(0, (tela.ClientSize.Height - painel.Height) / 2);
            }
        }

        private void cmb_TipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
