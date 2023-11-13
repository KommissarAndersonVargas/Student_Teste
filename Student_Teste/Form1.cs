using Student_Teste.Classes;
using System;
using System.Data;
using System.Windows;
using System.Windows.Forms;

namespace Student_Teste
{
    public partial class Form1 : Form
    {
       DataTable table = new DataTable("Table");
        List<Student> students = new List<Student>();
        string peca;
        string descri;
        int id;
        int index;
       

        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Peca", Type.GetType("System.String"));
            table.Columns.Add("Tipo", Type.GetType("System.String"));
            table.Columns.Add("ID", Type.GetType("System.Int32"));
            dataGridView1.DataSource = table; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            peca = textBox1.Text;
            descri = textBox2.Text;
            id = int.Parse(textBox3.Text);

            Student t = new Student(id, peca, descri);
            students.Add(t); 


            table.Rows.Add(t.Peca, t.Tipo, t.Id);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
            textBox2.Focus();
            textBox3.Focus();

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(index);
            students.RemoveAt(index);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // textBox1.Text = students.Count.ToString();
                textBox1.Text = students[0].Peca.ToString(); // testa o objeto 
                textBox2.Text = students[0].Tipo.ToString(); // testa o objeto 
                textBox3.Text = students[0].Id.ToString(); // testa o objeto 
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro: " + er.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            peca = textBox1.Text;
            descri = textBox2.Text;
            id = int.Parse(textBox3.Text);

            DataGridViewRow newdata =  dataGridView1.Rows[index];
            newdata.Cells[0].Value = peca;
            newdata.Cells[1].Value = descri;
            newdata.Cells[2].Value = id;

            students[index].Peca = peca;
            students[index].Id = id;
            students[index].Tipo = descri;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FiltrarGrade();
        }
        private void FiltrarGrade()
        {
            /*
            table.DefaultView.RowFilter = String.Format("[{0}] LIKE '%{1}%'", "Peca",textBox4.Text );
            dataGridView1.DataSource = table;

            //PARA PROCURAR STRINGS

            */
            if (textBox4.Text =="")
            {
                table.DefaultView.RowFilter = null;
            }
           else if (IsNumeric(textBox4.Text)) { 
                table.DefaultView.RowFilter = String.Format("[{0}] = {1}", "ID", textBox4.Text);
                dataGridView1.DataSource = table;
            }

        }

        private bool IsNumeric(string valor)
        {
            return valor.All(char.IsNumber);
        }
    }
}