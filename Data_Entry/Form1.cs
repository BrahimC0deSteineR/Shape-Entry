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

namespace Data_Entry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // connection string :

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2LLV29I\MSSQLSERVER01;Initial Catalog=test1;Integrated Security=True");

        //save data in database :-)

        private void btnsave_Click(object sender, EventArgs e)
        {
            
            if (txtid.Text == "" || txtwidth.Text == "" || txtsides.Text == "" || positionx.Text == "" || txtscale.Text == "" || txtwidth.Text == "")
                {
                    MessageBox.Show("please fill the cell first");
                }
                else
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("insert into Register(id,width,height,sides,scale,positionx,positiony,positionz,rotationx,rotationy,rotationz)values('" + txtid.Text + "','" + txtwidth.Text + "','" + textheight.Text + "','" + txtsides.Text + "','" + txtscale.Text + "','" + positionx.Text + "','"+positiony.Text + "','"+positionz.Text + "','"+rotationx.Text + "','"+rotationy.Text + "','"+rotationz.Text+ "')", conn);

                    sda.SelectCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("data entered succesfully. . . .");
                    panel1.Enabled = false;

                }
            
        }
        // view the data in datagridview :-)

        private void btnview_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            //conn.Open();
            //SqlDataAdapter sda = new SqlDataAdapter("select * from Register",conn);
            //DataTable data = new DataTable();
            //sda.Fill(data);
            //dataGridView1.DataSource = data;
            load_data();
            //conn.Close();

            
        }

        private void load_data()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Register", conn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            conn.Close();
        }
        // double click event for updating and deleting the data from database :-)

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            panel1.Enabled = true;
            txtid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtsides.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtwidth.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtscale.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            positionx.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textheight.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            positiony.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            positionz.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            rotationx.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            rotationy.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            rotationz.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
        //update the data :-)

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (panel1.Enabled == true)
            {

                if (txtid.Text == "" || txtwidth.Text == "" || txtsides.Text == "" || positionx.Text == "" || txtscale.Text == "" || textheight.Text == "" || positiony.Text == "" || positionz.Text == "" || rotationx.Text == "" || rotationy.Text == "" || rotationz.Text == "")
                {
                    MessageBox.Show("please fill the cell first");
                }
                else
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("UPDATE Register SET id ='" + txtid.Text + "',width = '" + txtwidth.Text + "',height = '" + textheight.Text + "', sides = '" + txtsides.Text + "',scale = '" + txtscale.Text + "',positionx = '" + positionx.Text + "',positiony = '"+ positiony.Text + "',positionz = '" + positionz.Text + "',rotationx = '" + rotationx.Text + "',rotationy = '" + rotationy.Text + "',rotationz = '" + rotationz.Text + "' where id ='" + txtid.Text + "'", conn);

                    sda.SelectCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("data updated succesfully. . . .");
                    load_data();
                    panel1.Enabled = false;
                }

            }
            else
            {
                MessageBox.Show("please select what you want to update");
            }
           
            
        }

        //delete btn c0ding :-)

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (panel1.Enabled == true)
            {

                if (txtid.Text == "" || txtwidth.Text == "" || txtsides.Text == "" || positionx.Text == "" || txtscale.Text == "" || textheight.Text == "" || positiony.Text == "" || positionz.Text == "" || rotationx.Text == "" || rotationy.Text == "" || rotationz.Text == "")
                {
                    MessageBox.Show("please select the record");
                }
                else
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("delete from Register where id ='" + txtid.Text + "'", conn);

                    sda.SelectCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("data deleted succesfully. . . .");
                    load_data();
                    panel1.Enabled = false; 
                }
               
            }
            else
            {
                MessageBox.Show("please select the record first");
            }
           
        }

        //to insert the new entry :-*

        private void btnnew_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = false;
            panel1.Enabled = true;
            
           txtid.Text = "";
            txtwidth.Text = "";
            txtsides.Text = "";
            txtscale.Text = "";
            positionx.Text = "";
            textheight.Text = "";
            positiony.Text = "";
            positionz.Text = "";
            rotationx.Text = "";
            rotationy.Text = "";
            rotationz.Text = "";
        }

        //search the data from database by name :-*

        private void srchbtn_Click(object sender, EventArgs e)
        {

            if (txtnamesrch.Text == "")
            {
                MessageBox.Show("cells are empty");
            }
            
            else
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Register where name LIKE '%"+txtnamesrch.Text+"%'", conn);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                conn.Close();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
