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
            if (!IsPostBack)
            {
                txt_cedula.Text = string.Empty;
                txt_apellido.Text = string.Empty;
                txt_nombre.Text = string.Empty;
                consultar();
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

                consultar();
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

        public  void consultar()
        {
            try
            {
                DataSet result = new DataSet();
                SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Estudiante;User ID=sa;Password=desa*P2022");
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("STP_CLIENTES", conn);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@tipo", 1);

                da.Fill(result);

                gv_clientes.DataSource = result.Tables[0];
                gv_clientes.DataBind();

                conn.Close();
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString());
            }
        }

        protected void gv_clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                GridViewRow row = gv_clientes.SelectedRow;

                string cedula = row.Cells[0].Text;
                DataSet result = new DataSet();

                SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Estudiante;User ID=sa;Password=desa*P2022");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("STP_CLIENTES", conn);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@tipo", 5);
                da.SelectCommand.Parameters.AddWithValue("@cedula", cedula);

                da.Fill(result);

                if (result.Tables[0].Rows.Count > 0)
                {
                    txt_cedula.Text = result.Tables[0].Rows[0]["cedula"].ToString();
                    txt_nombre.Text = result.Tables[0].Rows[0]["nombre"].ToString();
                    txt_apellido.Text = result.Tables[0].Rows[0]["apellido"].ToString();
                    cl_fecha_nacimiento.SelectedDate = System.Convert.ToDateTime(result.Tables[0].Rows[0]["fecha_nacimiento"].ToString());
                }


            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString());
            }

        }
    }
}