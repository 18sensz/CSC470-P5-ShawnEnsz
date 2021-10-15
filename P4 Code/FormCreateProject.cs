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
    public partial class FormCreateProject : Form
    {
        public FakeProjectRepository fakeProjectRepo;
        public FormCreateProject(FakeProjectRepository fakeProjectRepository)
        {
            InitializeComponent();
            fakeProjectRepo = fakeProjectRepository;
        }

        private void FormCreateProject_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Project temp = new Project();
            int id;
            string result;
            
            temp.Name = textBox1.Text;
            result = fakeProjectRepo.Add(temp, out id);

            if(id < 0)
            {
                //Failed to add 
                //Popup error?
                MessageBox.Show(result, "Attention");
            }
            else
            {
                //Added
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
