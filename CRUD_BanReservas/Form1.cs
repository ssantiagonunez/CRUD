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

namespace CRUD_BanReservas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'samuel_PruebaDataSet.Persona' table. You can move, or remove it, as needed.
            this.personaTableAdapter.Fill(this.samuel_PruebaDataSet.Persona);

        }

        private void ejecutarnq(string cmdr)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-S9G6OAU\\SQLEXPRESS;Initial Catalog=Samuel_Prueba;Integrated Security=True";

            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(cmdr, con);
                cmd.ExecuteNonQuery();
                label3.Text = "Se realizó correctamente";
            }
            catch (Exception ex)
            {
                label3.Text = "ocurrió un error." + ex;
            }

            this.personaTableAdapter.Fill(this.samuel_PruebaDataSet.Persona);
            dataGridView1.Refresh();

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string cmdr = "insert into Persona (nombre, fechadenacimiento) values ('" + textBox1.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "')";
                ejecutarnq(cmdr);
            }
            else
            {
                label3.Text = "No se pudo insertar. Por favor, llene todos los campos.";
            }
            textBox1.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 )
            {
                string cmdr = "Delete from Persona where ID = " + dataGridView1.CurrentCell.Value.ToString();
                ejecutarnq(cmdr);
            }
            else
                label3.Text = "No se pudo eliminar. Seleccione un número de ID y luego presione eliminar";

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Para eliminar, seleccione el número de ID en la tabla de abajo y luego presione eliminar", button2);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Para eliminar, seleccione el número de ID en la tabla de abajo y luego presione eliminar", pictureBox1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para eliminar, seleccione el número de ID en la tabla de abajo y luego presione eliminar", "Ayuda");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
