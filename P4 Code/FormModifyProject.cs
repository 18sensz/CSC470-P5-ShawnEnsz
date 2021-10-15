using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3_Code
{
    public partial class FormModifyProject : Form
    {
        public FakeProjectRepository fakeProjectRepo;
        public Project selectedProject;
        public FormModifyProject(FakeProjectRepository fakeProjectRepository, Project _selectedProject)
        {
            InitializeComponent();
            fakeProjectRepo = fakeProjectRepository;
            selectedProject = _selectedProject;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            //selectedProject.Name = textBox1.Text;
            Project temp = new Project();
            temp.Name = textBox1.Text;
            var result = fakeProjectRepo.Modify(temp.Id, temp);
            if(result == "")
            {
                //No errors
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //Errors
                MessageBox.Show(result, "Attention");
            }
        }

        private void FormModifyProject_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
