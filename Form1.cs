using System;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.htmlEditControl1.CSSText = "BODY {font-family: Arial}";
            this.htmlEditControl1.DocumentHTML = "<table><tr><td></td><td></td><td></td><td></td></tr>" +
                "<tr><td></td><td></td><td></td><td></td></tr>" +
                "<tr><td></td><td></td><td></td><td></td></tr>" +
                "</table><br /><table><tr><td></td><td></td><td></td><td></td></tr>" +
                "<tr><td></td><td></td><td></td><td></td></tr>" +
                "<tr><td></td><td></td><td></td><td></td></tr></table>";

            var oBTN = this.htmlEditControl1.ToolStripItems.Add("Format Tables");
            oBTN.Padding = new Padding(3);
            oBTN.Click += OBTN_Click;
        }

        private void OBTN_Click(object sender, EventArgs e)
        {

            string theTime = DateTime.Now.ToString();

            this.htmlEditControl1.Document.ExecCommand("ms-beginUndoUnit", false, "Table mod " + theTime);

            foreach (HtmlElement table in this.htmlEditControl1.Document.GetElementsByTagName("table"))
            {
                table.Style = "border-width: 1px; border-style: solid; border-collapse: collapse; background-color: rgb(235, 235, 235);";

                foreach (HtmlElement cell in table.GetElementsByTagName("td"))
                {
                    cell.Style = "padding: 5px; border: 1px solid gray; border-image: none; border-collapse: collapse;";
                }
            }

            this.htmlEditControl1.Document.ExecCommand("ms-endUndoUnit", false, "Table mod" + theTime);

            this.htmlEditControl1.SetDirty(true);

        }
    }
}
