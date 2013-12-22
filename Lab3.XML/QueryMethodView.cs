using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3.XML
{
    public partial class QueryMethodView : Form
    {
        private int _queryMethod = 0;

        public QueryMethodView()
        {
            InitializeComponent();
        }

        public int GetQueryMethod()
        {
            return _queryMethod;
        }

        private void linqMethodButton_Click(object sender, EventArgs e)
        {
            _queryMethod = 1;
            Close();
        }

        private void xPathMethodButton_Click(object sender, EventArgs e)
        {
            _queryMethod = 2;
            Close();
        }

        private void simpleMethodButton_Click(object sender, EventArgs e)
        {
            _queryMethod = 3;
            Close();
        }  
    }
}
