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
    public partial class FormRemoveProject : Form
    {
        public FakeProjectRepository fakeProjectRepo;
        public Project selectedProject;
        public FormRemoveProject(FakeProjectRepository fakeProjectRepository, Project _selectedProject)
        {
            InitializeComponent();
            fakeProjectRepo = fakeProjectRepository;
            selectedProject = _selectedProject;
        }

        private void FormRemoveProject_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            this.textBox1.Text = selectedProject.Name;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            string result = "";
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                result = fakeProjectRepo.Remove(selectedProject.Id);
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
            
            if (result == "")
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
