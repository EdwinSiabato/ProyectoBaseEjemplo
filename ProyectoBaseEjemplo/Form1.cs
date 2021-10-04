using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBaseEjemplo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            BaseEjemploDosEntitiesConnect contexto = new BaseEjemploDosEntitiesConnect();
            grid.DataSource = contexto.Clientes.ToList();
        }

        private void llenar()
        {
            //Nos carga el registro según el que hayamos elegido. La idea es que cuando seleccione
            //un registro se cargue en su respectiva celda.
            this.txtIdUsuario.Text = grid.SelectedRows[0].Cells[0].Value.ToString();
            this.txtNombre.Text = grid.SelectedRows[0].Cells[1].Value.ToString();
            this.txtApellidos.Text = grid.SelectedRows[0].Cells[2].Value.ToString();
            this.txtIdentificacion.Text = grid.SelectedRows[0].Cells[3].Value.ToString();
            this.txtCorreo.Text = grid.SelectedRows[0].Cells[4].Value.ToString();
            this.txtTelefono.Text = grid.SelectedRows[0].Cells[5].Value.ToString();
            this.txtAsunto.Text = grid.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtIdUsuario.Text);
            string nombre = this.txtNombre.Text;
            string apellidos = this.txtApellidos.Text;
            string identificacion = this.txtIdentificacion.Text;
            string correo = this.txtCorreo.Text;
            string telefono = this.txtTelefono.Text;
            string asunto = this.txtAsunto.Text;

            using (BaseEjemploDosEntitiesConnect contexto = new BaseEjemploDosEntitiesConnect{ })
            {
                Clientes c = new Clientes
                {
                    IdUsuario = id,
                    Nombre = nombre,
                    Apellidos = apellidos,
                    Identificacion = identificacion,
                    Correo = correo,
                    Telefono = telefono,
                    Asunto = asunto

                };
                contexto.Clientes.Add(c);
                contexto.SaveChanges();
                cargar();
            }

        }

        private void grid_Click(object sender, EventArgs e)
        {
            llenar();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            using(BaseEjemploDosEntitiesConnect contexto = new BaseEjemploDosEntitiesConnect { })
            {
                //Seleccionamos un registro a modificar. 
                int id = Convert.ToInt16(this.txtIdUsuario.Text);
                string nombre = this.txtNombre.Text;
                string apellidos = this.txtApellidos.Text;
                string identificacion = this.txtIdentificacion.Text;
                string correo = this.txtCorreo.Text;
                string telefono = this.txtTelefono.Text;
                string asunto = this.txtAsunto.Text;

                Clientes c = contexto.Clientes.FirstOrDefault(x => x.IdUsuario == id);

                c.IdUsuario = id;
                c.Nombre = nombre;
                c.Apellidos = apellidos;
                c.Identificacion = identificacion;
                c.Correo = correo;
                c.Telefono = telefono;
                c.Asunto = asunto;              

                contexto.SaveChanges();
                cargar();

            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            using (BaseEjemploDosEntitiesConnect contexto = new BaseEjemploDosEntitiesConnect { })
            {
             
                int id = Convert.ToInt16(this.txtIdUsuario.Text);
               
                Clientes c = contexto.Clientes.FirstOrDefault(x => x.IdUsuario == id);

                contexto.Clientes.Remove(c);
                contexto.SaveChanges();
                cargar();


            }
        }
}
}