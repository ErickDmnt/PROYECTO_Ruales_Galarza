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



namespace PROYECTO_Ruales_Galarza
{
    public partial class Form2 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5925MEN;Initial Catalog=delivery;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();

        }

        void populate()
        {
            try
            {
                con.Open();
                string Myquery = "select * from RepartidorTB";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();

            }
            catch
            {

            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 Menu = new Form1();
            Menu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into RepartidorTB values" +
                    "('" + nombreRPT.Text + "','" + contactoRPT.Text + "','" + vehiculoRPT.Text + "','" + placaRPT.Text + "','" + estadoRPT.Text + "')", con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("registrado con exito");
                con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            populate();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (RepId.Text == "")
            {
                MessageBox.Show("Selecione Un Nombre");
            }
            else
            {
                con.Open();
                string myquery = "delete from RepartidorTB where RepId='" + RepId.Text + "';";
                SqlCommand cmd = new SqlCommand(myquery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Eliminado con Exito");
                con.Close();
                populate();

            }
            /*
            if (DataGridView1.SelectedRows.Count > 0)
            {
                RepId = dataGridView1.CurrentRow.Cells["RepId"].Value.ToString();
                objetoCN.EliminarPRod(RepId);
                MessageBox.Show("Eliminado correctamente");
                MostrarProdctos();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }*/
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RepId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                nombreRPT.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                contactoRPT.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                vehiculoRPT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                placaRPT.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                estadoRPT.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch
            {}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE into RepartidorTB values" +
                "('" + RepId.Text + "','" + nombreRPT.Text + "','" + contactoRPT.Text + "','" + vehiculoRPT.Text + "','" + placaRPT.Text + "','" + estadoRPT.Text + "')", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("aCTUALIZADO con Exito");
            con.Close();
            populate();
        }
    }
}
