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
    public partial class ColorInput : Form
    {
        public ColorInput()
        {
            InitializeComponent();
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public int red
        {
            get
            {
                return (Convert.ToInt32(first.Text, 10));
            }
            set { first.Text = value.ToString(); }
        }
        public int green
        {
            get
            {
                return (Convert.ToInt32(second.Text, 10));
            }
            set { second.Text = value.ToString(); }
        }

        public int blue
        {
            get
            {
                return (Convert.ToInt32(third.Text, 10));
            }
            set { third.Text = value.ToString(); }
        }

    }
}
