using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass2_1
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        public Employee RetriveEmployeeInformation()
        {
            Employee empl = new Employee();
            empl.idEmployee = Convert.ToInt32(textBoxEmplID.Text);
            empl.name = textBoxEmplName.Text;
            empl.title = textBoxEmplTitle.Text;
            return empl;
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeDBManager edbm = new EmployeeDBManager();
                dataGridViewEmployees.DataSource = edbm.RetrieveEmployees();
                //EmptyControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            EmployeeDBManager edbm = new EmployeeDBManager();
            DateTime start = textBoxStartDate.Value;
            DateTime end = textBoxEndDate.Value;
            Console.Write(""+start + end+"\n");
            int id = Convert.ToInt32(textBoxEmplID.Text);
            IList<EmployeeActivity> emplActivityList = edbm.RetrieveEmployeeActivity(id, start, end);
            if (emplActivityList.Count > 0)
            {
                string message = edbm.generateReport(emplActivityList);
                MessageBox.Show(message);
            }
            else
                MessageBox.Show("No activity for this user");
        }
        private void dataGridViewEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count > 0)
            {
                Employee empl = dataGridViewEmployees.SelectedRows[0].DataBoundItem as Employee;
                if (empl != null)
                {

                    textBoxEmplID.Text = empl.idEmployee.ToString();
                    textBoxEmplName.Text = empl.name;
                    textBoxEmplTitle.Text = empl.title;

                }
            }
        }

        private void c_Click(object sender, EventArgs e)
        {
            Employee empl = RetriveEmployeeInformation();
            EmployeeDBManager edbm = new EmployeeDBManager();
            edbm.AddEmployee(empl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee empl = RetriveEmployeeInformation();
            EmployeeDBManager edbm = new EmployeeDBManager();
            edbm.UpdateEmployee(empl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employee empl = RetriveEmployeeInformation();
            EmployeeDBManager edbm = new EmployeeDBManager();
            edbm.DeleteEmployee(empl);
        }
    }
}
