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
    public partial class MemValue : Form
    {
        public int Memval
        {
            get
            {
                return (Convert.ToInt32(nummb.Text, 10));
            }
            set { nummb.Text = value.ToString(); }
        }
        public MemValue()
        {
            InitializeComponent();
            btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
