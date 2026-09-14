namespace NK_COLLECTION
{
    partial class Frm_login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_login));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtbox_usuario = new Guna.UI2.WinForms.Guna2TextBox();
            txtbox_contrasena = new Guna.UI2.WinForms.Guna2TextBox();
            btn_ingresar = new Guna.UI2.WinForms.Guna2Button();
            label4 = new Label();
            linklbl_contrasena = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(64, 0, 0);
            flowLayoutPanel1.BackgroundImage = (Image)resources.GetObject("flowLayoutPanel1.BackgroundImage");
            flowLayoutPanel1.BackgroundImageLayout = ImageLayout.Zoom;
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(318, 670);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(490, 59);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 63);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Book Antiqua", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 0, 0);
            label1.Location = new Point(425, 137);
            label1.Name = "label1";
            label1.Size = new Size(189, 32);
            label1.TabIndex = 2;
            label1.Text = "Iniciar Sesión";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Book Antiqua", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(372, 199);
            label2.Name = "label2";
            label2.Size = new Size(311, 28);
            label2.TabIndex = 3;
            label2.Text = "Bienvenido a NK Collection";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(359, 227);
            label3.Name = "label3";
            label3.Size = new Size(324, 22);
            label3.TabIndex = 4;
            label3.Text = "Ingresa tus credenciales para continuar";
            // 
            // txtbox_usuario
            // 
            txtbox_usuario.BackColor = Color.Transparent;
            txtbox_usuario.CustomizableEdges = customizableEdges7;
            txtbox_usuario.DefaultText = "Usuario";
            txtbox_usuario.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtbox_usuario.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtbox_usuario.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtbox_usuario.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtbox_usuario.FillColor = Color.FromArgb(248, 241, 242);
            txtbox_usuario.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbox_usuario.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_usuario.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbox_usuario.IconLeft = Properties.Resources.icons8_usuario_32;
            txtbox_usuario.IconLeftSize = new Size(30, 30);
            txtbox_usuario.Location = new Point(350, 287);
            txtbox_usuario.Margin = new Padding(4, 6, 4, 6);
            txtbox_usuario.Name = "txtbox_usuario";
            txtbox_usuario.PlaceholderText = "";
            txtbox_usuario.SelectedText = "";
            txtbox_usuario.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtbox_usuario.Size = new Size(349, 60);
            txtbox_usuario.TabIndex = 5;
            txtbox_usuario.TextOffset = new Point(10, 0);
            // 
            // txtbox_contrasena
            // 
            txtbox_contrasena.BackColor = Color.Transparent;
            txtbox_contrasena.CustomizableEdges = customizableEdges9;
            txtbox_contrasena.DefaultText = "Contraseña";
            txtbox_contrasena.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtbox_contrasena.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtbox_contrasena.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtbox_contrasena.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtbox_contrasena.FillColor = Color.FromArgb(248, 241, 242);
            txtbox_contrasena.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbox_contrasena.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_contrasena.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbox_contrasena.IconLeft = Properties.Resources.icons8_candado_24;
            txtbox_contrasena.IconLeftSize = new Size(30, 30);
            txtbox_contrasena.Location = new Point(350, 369);
            txtbox_contrasena.Margin = new Padding(4, 6, 4, 6);
            txtbox_contrasena.Name = "txtbox_contrasena";
            txtbox_contrasena.PlaceholderText = "";
            txtbox_contrasena.SelectedText = "";
            txtbox_contrasena.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtbox_contrasena.Size = new Size(349, 60);
            txtbox_contrasena.TabIndex = 6;
            txtbox_contrasena.TextOffset = new Point(10, 0);
            // 
            // btn_ingresar
            // 
            btn_ingresar.CustomizableEdges = customizableEdges11;
            btn_ingresar.DisabledState.BorderColor = Color.DarkGray;
            btn_ingresar.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_ingresar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_ingresar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_ingresar.FillColor = Color.FromArgb(64, 0, 0);
            btn_ingresar.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_ingresar.ForeColor = Color.White;
            btn_ingresar.Location = new Point(425, 466);
            btn_ingresar.Name = "btn_ingresar";
            btn_ingresar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btn_ingresar.Size = new Size(200, 44);
            btn_ingresar.TabIndex = 7;
            btn_ingresar.Text = "Ingresar   →";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Book Antiqua", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(372, 625);
            label4.Name = "label4";
            label4.Size = new Size(302, 22);
            label4.TabIndex = 8;
            label4.Text = "-------------- NK Collection --------------";
            // 
            // linklbl_contrasena
            // 
            linklbl_contrasena.AutoSize = true;
            linklbl_contrasena.Font = new Font("Book Antiqua", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linklbl_contrasena.LinkColor = Color.FromArgb(64, 0, 0);
            linklbl_contrasena.Location = new Point(433, 541);
            linklbl_contrasena.Name = "linklbl_contrasena";
            linklbl_contrasena.Size = new Size(192, 20);
            linklbl_contrasena.TabIndex = 9;
            linklbl_contrasena.TabStop = true;
            linklbl_contrasena.Text = "¿Olvidaste tu contraseña?";
            // 
            // Frm_login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 241, 242);
            ClientSize = new Size(733, 670);
            Controls.Add(linklbl_contrasena);
            Controls.Add(label4);
            Controls.Add(btn_ingresar);
            Controls.Add(txtbox_contrasena);
            Controls.Add(txtbox_usuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(flowLayoutPanel1);
            ForeColor = Color.FromArgb(248, 241, 242);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_login";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtbox_usuario;
        private Guna.UI2.WinForms.Guna2TextBox txtbox_contrasena;
        private Guna.UI2.WinForms.Guna2Button btn_ingresar;
        private Label label4;
        private LinkLabel linklbl_contrasena;
    }
}
