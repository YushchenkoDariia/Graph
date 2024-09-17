using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private int? x = null; 
        private int? y = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                x = int.Parse(txtX.Text);
                y = int.Parse(txtY.Text);

                string quarter = DetermineQuarter(x.Value, y.Value);

                MessageBox.Show($"The point is in the {quarter} quarter", "Result");

                panelGraph.Invalidate();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values ​​for X and Y.", "Input error");
            }
        }


        private void panelGraph_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("The panelGraph_Paint method is called");

            if (x.HasValue && y.HasValue)
            {
                DrawPointOnGraph(e.Graphics, x.Value, y.Value);
            }
        }

        private void DrawPointOnGraph(Graphics g, int x, int y)
        {
            int centerX = panelGraph.Width / 2;
            int centerY = panelGraph.Height / 2;

            int scale = 10; 

            
            g.DrawLine(Pens.Black, centerX, 0, centerX, panelGraph.Height); 
            g.DrawLine(Pens.Black, 0, centerY, panelGraph.Width, centerY); 

            
            Color pointColor = Color.Black;
            if (x > 0 && y > 0)
                pointColor = Color.Red;
            else if (x < 0 && y > 0)
                pointColor = Color.Green;
            else if (x < 0 && y < 0)
                pointColor = Color.Blue;
            else if (x > 0 && y < 0)
                pointColor = Color.Yellow;

            int drawX = centerX + x * scale;
            int drawY = centerY - y * scale;

            if (drawX >= 0 && drawX <= panelGraph.Width && drawY >= 0 && drawY <= panelGraph.Height)
            {
                
                g.FillEllipse(new SolidBrush(pointColor), drawX - 5, drawY - 5, 10, 10);
            }
        }



        private string DetermineQuarter(int x, int y)
        {
            if (x > 0 && y > 0)
                return "першій";
            if (x < 0 && y > 0)
                return "другій";
            if (x < 0 && y < 0)
                return "третій";
            if (x > 0 && y < 0)
                return "четвертій";
            return "на осі";
        }

    }
}
