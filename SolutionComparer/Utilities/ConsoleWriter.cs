using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSolutionComparer.Utilities
{
    public class ConsoleWriter : System.IO.TextWriter
    {
        System.Windows.Forms.ListView lst;
        public ConsoleWriter(System.Windows.Forms.ListView lst)
        {
            this.lst = lst;
        }
        public override Encoding Encoding => System.Text.Encoding.UTF8;
        public override void WriteLine(string value)
        {
            if (lst.IsHandleCreated)
            {
                lst.BeginInvoke((Action)(() =>
                {
                    lst.Items.Add(value.ToString());
                }
                ));
            }
        }
    }
}
