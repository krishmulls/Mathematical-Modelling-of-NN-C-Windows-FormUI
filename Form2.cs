using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace SDT_WindowsFormsApp_TASK1
{
    
    public partial class Form2 : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        private const float v = 1;

        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int resultint = 5;
            if (textBox6.Text == "you can decrease your speed\r\n\r\n")
            {
                resultint = 0;
            }
            if (textBox6.Text == "Maintain your speed and environment\r\n\r\n")
            {
                resultint = 1;
            }
            if (textBox6.Text == "you can increase your speed\r\n\r\n")
            {
                resultint = 2;
            }
            if (textBox6.Text == "you can see environment and apply brakes\r\n\r\n")
            {
                resultint = 3;
            }
            con = new SqlConnection(@"Data Source=DESKTOP-QK788MA;Initial Catalog=ProjectTest;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("INSERT INTO NNMM_CSV (WheelEncode,Camera,Lidar,Proximity,GSMGPS,ResultInt,Result,Time) VALUES(@WheelEncode,@Camera,@Lidar,@Proximity,@GSMGPS,@ResultInt,@Result,@Time)", con);
            cmd.Parameters.Add("@WheelEncode", textBox1.Text);
            cmd.Parameters.Add("@Camera", textBox2.Text);
            cmd.Parameters.Add("@Lidar", textBox3.Text);
            cmd.Parameters.Add("@Proximity", textBox4.Text);
            cmd.Parameters.Add("@GSMGPS", textBox5.Text);
            cmd.Parameters.Add("@ResultInt", resultint);
            cmd.Parameters.Add("@Result", textBox6.Text);
            cmd.Parameters.Add("@Time", DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss tt"));
            cmd.ExecuteNonQuery();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // input Variables
            float WS = float.Parse(textBox1.Text);
            float CS = float.Parse(textBox2.Text);
            float LS = float.Parse(textBox3.Text);
            float PS = float.Parse(textBox4.Text);
            float GS = float.Parse(textBox5.Text);

            var psi = new ProcessStartInfo();
            psi.FileName = @"python3";
            var script = @"D:\Workspace\VS\ResearchMethods\NNMM.py";
            psi.Arguments = string.Format("{0} {1} {2} {3} {4} {5}", script, WS, CS, LS, PS, GS);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            var errors = "";

            using (Process process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                    Console.WriteLine("NNMM Result");
                    Console.WriteLine("Result", result);
                    textBox6.Clear();
                    textBox6.AppendText(result);
                    textBox6.AppendText(Environment.NewLine);
                }
            }
            Console.WriteLine("NO Errors");
            Console.WriteLine(errors);
            Console.WriteLine();

            

        }

        private float Activationfunc(float j, float x)
        {
            float i = (j >= x) ? 1 : 0;
            return i;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
