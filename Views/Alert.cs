using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CardViewer.Views
{
    public partial class Alert : Form
    {
        public Alert(string message)
        {
            InitializeComponent();

            labelAlertMessage.Text = message;
        }
    }
}
