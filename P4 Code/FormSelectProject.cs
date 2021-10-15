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
    public partial class FormSelectProject : Form
    {
        public FakeProjectRepository fakeRepo;
        public Project selectedProject;
        public FormSelectProject(FakeProjectRepository fakeProjectRepository)
        {
            InitializeComponent();
            fakeRepo = fakeProjectRepository;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormSelectProject_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            foreach(Project project in fakeRepo.GetAll())
            {
                listBox1.Items.Add(project.Id.ToString() + "-" + project.Name);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            var selectedProjectName = listBox1.GetItemText(listBox1.SelectedItem);
            selectedProjectName = selectedProjectName.Split('-')[1];
            var index = fakeRepo.GetAll().FindIndex(p => p.Name == selectedProjectName);
            selectedProject = fakeRepo.GetAll()[index];
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
