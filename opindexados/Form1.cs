using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OPArchivosIndexados
{
    public partial class Form1 : Form
    {
        // Carpeta segura en Documentos
        private static readonly string CarpetaDatos = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ArchivosIndexadosApp");
        private static readonly string ArchivoDatos = Path.Combine(CarpetaDatos, "datos_secuenciales_usuario.txt");
        private static readonly string ArchivoIndice = Path.Combine(CarpetaDatos, "indice_secuenciales_usuario.txt");

        private record Indice(int Clave, long Posicion);
        
        public Form1()
        {
            // IMPORTANTE: InitializeComponent() debe ir PRIMERO
            InitializeComponent();
            
            // Suspender el layout para evitar parpadeos durante la configuración
            SuspendLayout();
            
            // Configuración del formulario
            Text = "Gestor de Archivos Indexados";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 800;
            Height = 600;

            // Crear el directorio si no existe
            Directory.CreateDirectory(CarpetaDatos);
            
            // Reanudar el layout y forzar actualización
            ResumeLayout(false);
            PerformLayout();
            
            // Suscribir al evento Load
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblRuta.Text = $"Ruta de datos:\n{ArchivoDatos}\n{ArchivoIndice}";
            
            // Cargar datos existentes al iniciar
            MostrarEnLista();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtClave.Text = "";
            txtDatos.Text = "";
            txtBuscar.Text = "";
            txtModificarDatos.Text = "";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtClave.Text, out int clave) && !string.IsNullOrWhiteSpace(txtDatos.Text))
            {
                Insertar(clave, txtDatos.Text);
                MessageBox.Show("Registro insertado.");
                MostrarEnLista();
            }
            else
            {
                MessageBox.Show("Clave o datos inválidos.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBuscar.Text, out int clave))
            {
                var resultado = Buscar(clave);
                if (resultado != null)
                    MessageBox.Show($"Registro encontrado: {resultado}");
                else
                    MessageBox.Show("Registro no encontrado.");
            }
            else
            {
                MessageBox.Show("Clave inválida.");
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarEnLista();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBuscar.Text, out int clave))
            {
                Eliminar(clave);
                MessageBox.Show("Registro eliminado (si existía).");
                MostrarEnLista();
            }
            else
            {
                MessageBox.Show("Clave inválida.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBuscar.Text, out int clave) && !string.IsNullOrWhiteSpace(txtModificarDatos.Text))
            {
                Modificar(clave, txtModificarDatos.Text);
                MessageBox.Show("Registro modificado (si existía).");
                MostrarEnLista();
            }
            else
            {
                MessageBox.Show("Clave o datos inválidos.");
            }
        }

        private void MostrarEnLista()
        {
            // Suspender actualizaciones visuales durante la carga
            lstRegistros.BeginUpdate();
            lstRegistros.Items.Clear();
            var registros = MostrarSecuencial();
            foreach (var reg in registros)
                lstRegistros.Items.Add(reg);
            lstRegistros.EndUpdate(); // Actualizar todo de una vez
        }

        // --- Operaciones de archivos indexados ---

        private void Insertar(int clave, string datos)
        {
            using var fs = new FileStream(ArchivoDatos, FileMode.Append, FileAccess.Write);
            long posicion = fs.Position;
            using var sw = new StreamWriter(fs);
            sw.WriteLine($"{clave}|{datos}");

            var indices = LeerIndices();
            indices.Add(new Indice(clave, posicion));
            indices = indices.OrderBy(i => i.Clave).ToList();
            GuardarIndices(indices);
        }

        private string Buscar(int clave)
        {
            var indices = LeerIndices();
            var indice = indices.FirstOrDefault(i => i.Clave == clave);
            if (indice == null) return null;

            using var fs = new FileStream(ArchivoDatos, FileMode.Open, FileAccess.Read);
            fs.Seek(indice.Posicion, SeekOrigin.Begin);
            using var sr = new StreamReader(fs);
            return sr.ReadLine();
        }

        private List<string> MostrarSecuencial()
        {
            if (!File.Exists(ArchivoDatos)) return new List<string>();
            return File.ReadAllLines(ArchivoDatos).ToList();
        }

        private void Eliminar(int clave)
        {
            var indices = LeerIndices();
            var indice = indices.FirstOrDefault(i => i.Clave == clave);
            if (indice == null) return;

            var registros = File.ReadAllLines(ArchivoDatos).ToList();
            registros = registros.Where(r => !r.StartsWith($"{clave}|")).ToList();

            File.WriteAllLines(ArchivoDatos, registros);

            indices = new List<Indice>();
            long pos = 0;
            foreach (var reg in registros)
            {
                var partes = reg.Split('|');
                indices.Add(new Indice(int.Parse(partes[0]), pos));
                pos += reg.Length + Environment.NewLine.Length;
            }
            GuardarIndices(indices);
        }

        private void Modificar(int clave, string nuevosDatos)
        {
            var indices = LeerIndices();
            var indice = indices.FirstOrDefault(i => i.Clave == clave);
            if (indice == null) return;

            var registros = File.ReadAllLines(ArchivoDatos).ToList();
            for (int i = 0; i < registros.Count; i++)
            {
                if (registros[i].StartsWith($"{clave}|"))
                {
                    registros[i] = $"{clave}|{nuevosDatos}";
                    break;
                }
            }

            File.WriteAllLines(ArchivoDatos, registros);

            indices = new List<Indice>();
            long pos = 0;
            foreach (var reg in registros)
            {
                var partes = reg.Split('|');
                indices.Add(new Indice(int.Parse(partes[0]), pos));
                pos += reg.Length + Environment.NewLine.Length;
            }
            GuardarIndices(indices);
        }

        private List<Indice> LeerIndices()
        {
            var indices = new List<Indice>();
            if (!File.Exists(ArchivoIndice)) return indices;
            foreach (var linea in File.ReadAllLines(ArchivoIndice))
            {
                var partes = linea.Split('|');
                indices.Add(new Indice(int.Parse(partes[0]), long.Parse(partes[1])));
            }
            return indices;
        }

        private void GuardarIndices(List<Indice> indices)
        {
            var lineas = indices.Select(i => $"{i.Clave}|{i.Posicion}");
            File.WriteAllLines(ArchivoIndice, lineas);
        }
    }
}
