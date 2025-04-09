using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEstudiante
{
    public partial class wf_estudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (true)
            {
                txt_cedula.Text = string.Empty;
                txt_apellido.Text = string.Empty;
                txt_nombre.Text = string.Empty;
               
            }
        }

        protected void btn_grabar_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Estudiante;User ID=sa;Password=desa*P2022");
          
                conn.Open();
                SqlCommand cmd = new SqlCommand("STP_CLIENTES", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@tipo",2);
                cmd.Parameters.AddWithValue("@cedula", txt_cedula.Text.ToString());
                cmd.Parameters.AddWithValue("@nombre", txt_nombre.Text.ToString());
                cmd.Parameters.AddWithValue("@apellido", txt_apellido.Text.ToString());
                cmd.Parameters.AddWithValue("@sexo", chk_femenino.Checked);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", cl_fecha_nacimiento.SelectedDate.ToShortDateString());
                cmd.Parameters.AddWithValue("@estado", true);

                int rowsAffected = cmd.ExecuteNonQuery();


                conn.Close();


            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString());
            }
        }

        protected void chk_masculino_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_masculino.Checked)
            {
                chk_femenino.Checked = false;
            }
        }

        protected void chk_femenino_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_femenino.Checked)
            {
                chk_masculino.Checked = false;
            }
        }
    }
}