using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Query;

namespace SDT_WindowsFormsApp_TASK1
{
    public partial class Form1 : Form
    {
        Graph kb;
        Graph yb;

        public Form1()
        {

            InitializeComponent();
            kb = new Graph();
            Notation3Parser n3p = new Notation3Parser();
            n3p.Load(kb, @"kbFile.n3");
            string query1 = @"
                prefix rdf:<http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix process: <URN:process:>
                prefix input: <URN:input>
                prefix output: <URN:output>
                SELECT ?pr ?label
                WHERE
                    { ?pr    rdfs:subClassOf   process:AMPBB;
                             rdf:label	?label .}";

            SparqlResultSet srRez = (SparqlResultSet)kb.ExecuteQuery(query1);
            treeView1.Nodes.Add("TREE_VIEW_OF_AMPBB");
            treeView1.Nodes.Add(srRez[0]["label"].ToString());
            TreeNode myNode = treeView1.Nodes[0];
            

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            Load neural Component
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string summa = treeView1.SelectedNode.Text;
            int length = summa.Length;
            int adl = length - 4;
            char[] queryst = new char[adl]; ;
            summa.CopyTo(4, queryst, 0, adl);
            string qs = new string(queryst);
            textBox1.Clear();
            string query2 = @"
                prefix rdf:<http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix process: <urn:process:>
                SELECT ?sub ?label ?Connections ?also ?var ?res ?comment
                WHERE
                    { ?sub  rdfs:subClassOf ?var;
                            rdfs:comment ?comment;
                            rdf:label """ + treeView1.SelectedNode.Text + @""";
                            rdfs:Properties   ?Connections;
                            rdfs:seeAlso  ?also.       
                    OPTIONAL{?sub  rdf:Resource    ?res;
                                   rdfs:Properties   ?Connections.}
                    }ORDER BY ASC(?sub)";

            SparqlResultSet DesRez = (SparqlResultSet)kb.ExecuteQuery(query2);
            textBox1.AppendText(DesRez[0]["comment"].ToString());
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText(DesRez[0]["Connections"].ToString());
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText(DesRez[1]["Connections"].ToString());
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText(DesRez[0]["also"].ToString());
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText(DesRez[0]["res"].ToString());
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!treeView1.SelectedNode.IsExpanded)
            {
                string query2 = @"
                prefix rdf:<http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                SELECT ?sub ?label
                WHERE
                    { ?sub    rdfs:subClassOf """+treeView1.SelectedNode.Text+ @""";
                              rdf:label ?label.
                    }ORDER BY ASC(?sub)";

                SparqlResultSet selectedRez = (SparqlResultSet)kb.ExecuteQuery(query2);
                foreach(SparqlResult sr in selectedRez)
                {
                    treeView1.SelectedNode.Nodes.Add(sr["label"].ToString());
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python37_64\python.exe";
            var script = @"D:\Workspace\VS\ResearchMethods\TestingInterface.py";
            psi.Arguments = $"\"{script}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            var errors = "";
            
            using (Process process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
            }
            Console.WriteLine("Errors");
            Console.WriteLine(errors);
            Console.WriteLine();
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            yb = new Graph();
            Notation3Parser n3p = new Notation3Parser();
            n3p.Load(yb, @"retrain.n3");
            string query1 = @"
                prefix rdf:<http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix process: <URN:process:>
                SELECT ?pr ?epochs ?project
                WHERE
                    { ?pr    rdfs:subClassOf   ?project;
                             rdf:epochs	?epochs.}";
            
            SparqlResultSet srRez1 = (SparqlResultSet)yb.ExecuteQuery(query1);
            var epochs = (srRez1[0]["epochs"].ToString());

            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python37_64\python.exe";
            var script = @"D:\Workspace\VS\ResearchMethods\Main_System.py";
            
            psi.Arguments = $"\"{script}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            var errors = "";

            using (Process process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
            }
            Console.WriteLine("Errors");
            Console.WriteLine(errors);
            Console.WriteLine();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
    }
}
