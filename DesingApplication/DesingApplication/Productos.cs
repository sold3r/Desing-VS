using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DesingApplication
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = GetProductos();
        }

        private DataTable GetProductos()
        {
            DataTable dtproductos = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["bdAnimeMerchan"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Productos", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtproductos.Load(reader);
                }
                
            }

                return dtproductos;
        }
    }
}
