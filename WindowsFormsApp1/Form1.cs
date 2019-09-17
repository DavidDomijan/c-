using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<string> mjesta = new List<string>();


            mjesta.Add("1.kat/Dvorana-Concept");
            mjesta.Add("1.kat/Dvorana-Mood");
            mjesta.Add("1.kat/Restoran-Lounge");
            mjesta.Add("1.kat/Restoran-Dining");
            mjesta.Add("2.kat/WC-");
            mjesta.Add("3.kat/Recepcija-Glavni");
            mjesta.Add("3.kat/Recepcija-Uredi");

            string parent;
           

           
             treeView1.BeginUpdate();
             foreach (var mjesto in mjesta)
             {
                parent = mjesto.Substring(0,mjesto.IndexOf("/"));

                 if (mjesto.StartsWith(parent))
                 {
                     if (!treeView1.Nodes.ContainsKey(parent))
                     {
                         TreeNode node1 = new TreeNode(parent);
                         node1.Name = (parent);
                         treeView1.Nodes.Add(node1);
                       
                     }

                     if (treeView1.Nodes.ContainsKey(parent))
                     {

                       
                            
                        int position = mjesto.IndexOf("/");
                        if (position < 0) continue;

                        int position2 = mjesto.IndexOf("-");
                        if (position2 < 0) continue;

                        string str1 = mjesto.Substring(position + 1);
                         int duzina=str1.Length;

                         string str2 = mjesto.Substring(position2);
                         int kraj = duzina -str2.Length;
                        

                        string str3= mjesto.Substring(position + 1,kraj);
                        string str4 = mjesto.Substring(position2 + 1);
                         if (!treeView1.Nodes[parent].Nodes.ContainsKey(str3)) {
                            TreeNode node2 = new TreeNode(str3);
                            node2.Name = (str3);
                            treeView1.Nodes[parent].Nodes.Add(node2);
                           
                                if (!treeView1.Nodes[parent].Nodes[str3].Nodes.ContainsKey(str4) && str4!="" && str4!=null)
                                {
                                    TreeNode node3 = new TreeNode(str4);
                                    node3.Name = (str4);
                                    treeView1.Nodes[parent].Nodes[str3].Nodes.Add(node3);


                                }

                       
                        }

                          else if (treeView1.Nodes[parent].Nodes.ContainsKey(str3)) { 
                            if (!treeView1.Nodes[parent].Nodes[str3].Nodes.ContainsKey(str4))
                            {
                                TreeNode node3 = new TreeNode(str4);
                                node3.Name = (str4);
                                treeView1.Nodes[parent].Nodes[str3].Nodes.Add(node3);

                                
                            }
                           }
                        
                     }





                 }

                


            }
             treeView1.EndUpdate(); 
        }


    }
}
