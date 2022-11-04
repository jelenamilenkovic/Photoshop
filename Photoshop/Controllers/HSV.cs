using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photoshop
{
    public partial class HSV : Form
    {
        public decimal hue
        {
            get
            {
                return (decimal)newH.Value;
            }
            set { newH.Value= value; }
        }
        public decimal sat
        {
            get
            {
                return (decimal)newS.Value;
            }
            set { newS.Value = value; }
        }

        public HSV()
        {
            InitializeComponent();
            btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
