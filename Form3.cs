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
    public partial class Form3 : Form
    {
        Graph kb;
       

        public Form3()
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
                prefix sprint: <urn:sprint:>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT  DISTINCT ?sprint 
                WHERE
                    { 
                        ?pr	rdfs:subClassOf ?var1;
                            rdfs:comment ?var2;
                            rdf:label ?var3;
                            rdfs:Properties ?var4;
                            rdf:Resource ?var5;
                            owl:oneOf (?sprint);
                            rdfs:seeAlso ?var6.}";

            SparqlResultSet srRez = (SparqlResultSet)kb.ExecuteQuery(query1);
            treeView1.Nodes.Add("Number of Sprint in Project");
            foreach (SparqlResult sr in srRez)
            {
                treeView1.Nodes.Add(sr["sprint"].ToString());
            }
            TreeNode myNode = treeView1.Nodes[0];
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            string query1 = @"
                prefix rdf:<http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix process: <URN:process:>
                prefix input: <URN:input>
                prefix output: <URN:output>
                prefix sprint: <urn:sprint:>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT DISTINCT ?var3 
                WHERE
                    { 
                        ?pr	rdfs:subClassOf ?var1;
                            rdfs:comment ?var2;
                            rdf:label ?var3;
                            rdfs:Properties ?var4;
                            rdf:Resource ?var5;
                            owl:oneOf  (""" + treeView1.SelectedNode.Text + @""");
                            rdfs:seeAlso ?var6.}";

            SparqlResultSet srRez1 = (SparqlResultSet)kb.ExecuteQuery(query1);
            textBox2.AppendText("Process which we will work on corresponding sprint:");
            textBox2.AppendText(Environment.NewLine);
            textBox2.AppendText(Environment.NewLine);
            textBox2.AppendText(Environment.NewLine);
            foreach (SparqlResult sr in srRez1)
            {
                
                textBox2.AppendText(sr["var3"].ToString());
                textBox2.AppendText(Environment.NewLine);
            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
