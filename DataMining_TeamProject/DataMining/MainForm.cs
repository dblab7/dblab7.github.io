using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMining
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            /* Weather Attributes */
            cmbAttr1.Items.Add("Male");
            cmbAttr1.Items.Add("Female");
            cmbAttr1.SelectedItem = "Male";

            cmbAttr2.Items.Add("Morning");
            cmbAttr2.Items.Add("Evening");
            cmbAttr2.Items.Add("Afternoon");
            cmbAttr2.SelectedItem = "Morning";

            cmbAttr3.Items.Add("Home");
            cmbAttr3.Items.Add("Classroom");
            cmbAttr3.Items.Add("library");
            cmbAttr3.Items.Add("Moving");
            cmbAttr3.Items.Add("Restaurant");
            cmbAttr3.Items.Add("Etc");
            cmbAttr3.SelectedItem = "Home";

            cmbAttr4.Items.Add("No");
            cmbAttr4.Items.Add("Yes");
            cmbAttr4.SelectedItem = "No";

            cmbAttr5.Items.Add("Yes");
            cmbAttr5.Items.Add("No");
            cmbAttr5.SelectedItem = "Yes";

            cmbAttr6.Items.Add("Less than 15%");
            cmbAttr6.Items.Add("Between 15% and 70%");
            cmbAttr6.Items.Add("More than 70%");
            cmbAttr6.SelectedItem = "Less than 15%";

            cmbAttr7.Items.Add("Less than 30%");
            cmbAttr7.Items.Add("Between 30 % and 70%");
            cmbAttr7.Items.Add("More than 70%");
            cmbAttr7.SelectedItem = "Less than 30%";

            radOneRule.Checked = true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            txtAppClass.Text = string.Empty;
            txtAccuracy.Text = string.Empty;

            string attr1 = cmbAttr1.Text;
            string attr2 = cmbAttr2.Text;
            string attr3 = cmbAttr3.Text;
            string attr4 = cmbAttr4.Text;
            string attr5 = cmbAttr5.Text;
            string attr6 = cmbAttr6.Text;
            string attr7 = cmbAttr7.Text;

            SmartPhoneApp smartPhoneApp = new SmartPhoneApp(attr1, attr2, attr3, attr4, attr5, attr6, attr7);

            if (radOneRule.Checked) // One Rule
            {
                smartPhoneApp.OneRule();
            }
            else if (radNaiveBayesian.Checked) // Naive Bayesian
            {
                smartPhoneApp.NaiveBayesian();
            }
            else if (radDecisionTree.Checked) // Decision Tree
            {
                smartPhoneApp.DecisionTree();
            }
            else if (radCoveringAlgorithm.Checked) // Covering Algorithm
            {
                smartPhoneApp.CoveringAlgorithm();
            }

            txtAppClass.Text = smartPhoneApp.AppClass;
            txtAccuracy.Text = smartPhoneApp.Accuracy;
            txtResult.Text = smartPhoneApp.Result;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
