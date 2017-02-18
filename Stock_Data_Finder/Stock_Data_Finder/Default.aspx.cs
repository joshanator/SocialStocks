using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Data_Finder
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitUserInput(object sender, EventArgs e)
        {
            string Symbol = symbol.Text;
            DateTime startDate = sDate.SelectedDate;
            DateTime endDate = eDate.SelectedDate;

        }
    }
}