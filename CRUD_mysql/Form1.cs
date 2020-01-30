using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_mysql.myclass;
using MySql.Data.MySqlClient;

namespace CRUD_mysql
{
    public partial class Form1 : Form
    {
        CRUD crud = new CRUD();

        public Form1()
        {
            InitializeComponent();
        }
        public void ClearSave()
        {
            nametxt.Text = "";
            mobiletxt.Text = "";
            addresstxt.Text = "";
        }
        public void ClearUpdate()
        {
            IDTXT.Text = "ID";
            u_nametxt.Text = "";
            u_mobiletxt.Text = "";
            u_addresstxt.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //CREATE
            CREATE();
            READ();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //UPDATE
            UPDATE();
            READ();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DELETE
            DELETE();
            READ();
        }

        //READ
        public void READ()
        {
            dataGridView1.DataSource = null;
            crud.Read_data();
            dataGridView1.DataSource = crud.dt;
        }

        public void CREATE()
        {
            crud.name = nametxt.Text;
            crud.number = mobiletxt.Text;
            crud.address = addresstxt.Text;
            crud.Create_data();
        }

        public void UPDATE()
        {
            crud.name = u_nametxt.Text;
            crud.number = u_mobiletxt.Text;
            crud.address = u_addresstxt.Text;
            crud.id = IDTXT.Text;
            crud.Update_data();
        }

        public void DELETE()
        {
            crud.id = IDTXT.Text;
            crud.Delete_data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //GET DATA
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    IDTXT.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    u_nametxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    u_addresstxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    u_mobiletxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Don't Click the Header!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            READ();
            ClearSave();
            ClearUpdate();
        }
    }
}
