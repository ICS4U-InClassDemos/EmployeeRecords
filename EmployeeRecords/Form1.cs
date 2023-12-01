using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace EmployeeRecords
{
    public partial class mainForm : Form
    {
        List<Employee> employeeDB = new List<Employee>();

        public mainForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        { 
            string id, firstName, lastName, date, salary;

            id = idInput.Text;
            firstName = fnInput.Text;
            lastName = lnInput.Text;
            date = dateInput.Text;
            salary = salaryInput.Text;

            Employee newEmployee = new Employee(id, firstName, lastName, date, salary);
            employeeDB.Add(newEmployee);

            ClearLabels();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
           
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = "";

            foreach (Employee emp in employeeDB)
            {
                outputLabel.Text += $"{emp.id} {emp.firstName} {emp.lastName}\n";
            }
        }

        private void ClearLabels()
        {
            idInput.Text = "";
            fnInput.Text = "";
            lnInput.Text = "";
            dateInput.Text = "";
            salaryInput.Text = "";
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveDB();
        }

        public void loadDB()
        {
            
        }

        public void saveDB()
        {
            XmlWriter writer = XmlWriter.Create("Resources/employeeData.xml", null);

            writer.WriteStartElement("Employees");

            foreach (Employee e in employeeDB)
            {
                writer.WriteStartElement("Employee");

                writer.WriteElementString("id", e.id);
                writer.WriteElementString("firstName", e.firstName);
                writer.WriteElementString("lastName", e.lastName);
                writer.WriteElementString("date", e.date);
                writer.WriteElementString("salary", e.salary);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            
            writer.Close();

        }
    }
}
