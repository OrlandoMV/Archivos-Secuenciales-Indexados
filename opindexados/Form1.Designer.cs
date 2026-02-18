namespace OPArchivosIndexados
{
    partial class Form1
    {
        /// <summary>
        ///  Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtDatos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.TextBox txtModificarDatos;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ListBox lstRegistros;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblDatos;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblModificar;
        private System.Windows.Forms.Label lblRuta;

        /// <summary>
        ///  Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        ///  Método necesario para admitir el Diseñador. No se debe modificar
        ///  el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            txtClave = new TextBox();
            txtDatos = new TextBox();
            txtBuscar = new TextBox();
            txtModificarDatos = new TextBox();
            btnInsertar = new Button();
            btnBuscar = new Button();
            btnMostrar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnLimpiar = new Button();
            lstRegistros = new ListBox();
            lblClave = new Label();
            lblDatos = new Label();
            lblBuscar = new Label();
            lblModificar = new Label();
            lblRuta = new Label();
            SuspendLayout();
            // 
            // txtClave
            // 
            txtClave.Location = new Point(109, 17);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(190, 31);
            txtClave.TabIndex = 1;
            // 
            // txtDatos
            // 
            txtDatos.Location = new Point(92, 55);
            txtDatos.Name = "txtDatos";
            txtDatos.Size = new Size(207, 31);
            txtDatos.TabIndex = 2;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(109, 88);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(190, 31);
            txtBuscar.TabIndex = 3;
            // 
            // txtModificarDatos
            // 
            txtModificarDatos.Location = new Point(117, 127);
            txtModificarDatos.Name = "txtModificarDatos";
            txtModificarDatos.Size = new Size(182, 31);
            txtModificarDatos.TabIndex = 10;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(337, 9);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(111, 31);
            btnInsertar.TabIndex = 4;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(337, 50);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(111, 33);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnMostrar
            // 
            btnMostrar.Location = new Point(20, 170);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(91, 34);
            btnMostrar.TabIndex = 12;
            btnMostrar.Text = "Mostrar";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(337, 89);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(111, 33);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(337, 124);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(111, 31);
            btnModificar.TabIndex = 11;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(371, 254);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 34);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += BtnLimpiar_Click;
            // 
            // lstRegistros
            // 
            lstRegistros.FormattingEnabled = true;
            lstRegistros.ItemHeight = 25;
            lstRegistros.Location = new Point(20, 210);
            lstRegistros.Name = "lstRegistros";
            lstRegistros.Size = new Size(345, 129);
            lstRegistros.TabIndex = 13;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Location = new Point(20, 20);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(91, 25);
            lblClave.TabIndex = 0;
            lblClave.Text = "Clave (ID):";
            // 
            // lblDatos
            // 
            lblDatos.AutoSize = true;
            lblDatos.Location = new Point(20, 58);
            lblDatos.Name = "lblDatos";
            lblDatos.Size = new Size(63, 25);
            lblDatos.TabIndex = 2;
            lblDatos.Text = "Datos:";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(20, 91);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(90, 25);
            lblBuscar.TabIndex = 4;
            lblBuscar.Text = "Buscar ID:";
            // 
            // lblModificar
            // 
            lblModificar.AutoSize = true;
            lblModificar.Location = new Point(20, 130);
            lblModificar.Name = "lblModificar";
            lblModificar.Size = new Size(91, 25);
            lblModificar.TabIndex = 9;
            lblModificar.Text = "Modificar:";
            // 
            // lblRuta
            // 
            lblRuta.AutoSize = true;
            lblRuta.Location = new Point(20, 380);
            lblRuta.Name = "lblRuta";
            lblRuta.Size = new Size(0, 25);
            lblRuta.TabIndex = 14;
            // 
            // Form1
            // 
            ClientSize = new Size(594, 453);
            Controls.Add(lblRuta);
            Controls.Add(lstRegistros);
            Controls.Add(btnMostrar);
            Controls.Add(btnModificar);
            Controls.Add(txtModificarDatos);
            Controls.Add(lblModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(btnInsertar);
            Controls.Add(txtDatos);
            Controls.Add(lblDatos);
            Controls.Add(txtClave);
            Controls.Add(lblClave);
            Controls.Add(btnLimpiar);
            Name = "Form1";
            Text = "Archivos Secuenciales Indexados";
            ResumeLayout(false);
            PerformLayout();
        }
    }
    #endregion
}