using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TEST_Cilent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WCF_Synthese_Remote.ServiceWCF_SyntheseClient client = new WCF_Synthese_Remote.ServiceWCF_SyntheseClient();
            WCF_Synthese_Remote.ObservationDTO observation = new WCF_Synthese_Remote.ObservationDTO() { IDOiseau=1, DateObservation = ": 2014-04-06 12:00:00 "};

            client.AddObservation(observation);

        }
    }
}
