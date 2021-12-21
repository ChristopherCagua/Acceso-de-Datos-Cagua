using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesodeDatos
{
    public partial class frmAccesodeDatos : Form
    {
        public frmAccesodeDatos()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //1. crear la conexion
            SqlConnection conexion = new SqlConnection(@"server=MAQUINA-DE-GUER\SQLEXPRESS;
                    database=TI2021; Integrated Security=true");


            //2.Definir una operacion
            string sql = "insert into personas(cedula,apellidos,nombres,fechaNacimiento, peso) ";
            sql += "values(@cedula,@apellidos,@nombres,@fechaNacimiento,@peso)";

            //3. ejecutar la operacion
            SqlCommand comando = new SqlCommand(sql, conexion);


            //3.1 configuracion de parametros @cedula,@apellidos,@nombres,@fechaNacimiento,@peso
            try
            {
                DateTime fecha = datafecha.Value;
                comando.Parameters.Add(new SqlParameter("@cedula", this.txtCedula.Text));
                comando.Parameters.Add(new SqlParameter("@apellidos", this.txtApellido.Text));
                comando.Parameters.Add(new SqlParameter("@nombres", this.txtNombre.Text));
                comando.Parameters.Add(new SqlParameter("@fechaNacimiento", fecha.ToString()));
                comando.Parameters.Add(new SqlParameter("@peso", this.txtPeso.Text));


                //3.2 abrir la conexion
                conexion.Open();
                //3.3 insertar el registro en la base de datos
                int res = comando.ExecuteNonQuery();

                //4. cerrar la conexion
                conexion.Close();
                MessageBox.Show("Filas insertadas:" + res.ToString());


            }
            catch (SqlException e1)
            {
                MessageBox.Show(e1.Message.ToString(), "Error :c", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message.ToString());
            }

        }
    }
}
