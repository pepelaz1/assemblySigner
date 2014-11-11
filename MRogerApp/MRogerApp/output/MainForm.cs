using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace MRogerApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private XmlDocument DecompressXmlFile(string compressed_xml_file)
        {
            XmlDocument xml = null;
            try
            {
                xml = new XmlDocument();
                using (FileStream fs = File.OpenRead(compressed_xml_file))
                {
                    using (GZipStream gz = new GZipStream(fs, CompressionMode.Decompress))
                    {

                        const int size = 4096;
                        byte[] buffer = new byte[size];
                        using (MemoryStream ms = new MemoryStream())
                        {
                            int count = 0;
                            do
                            {
                                count = gz.Read(buffer, 0, size);
                                if (count > 0)
                                {
                                    ms.Write(buffer, 0, count);
                                }
                            }
                            while (count > 0);
                            ms.Position = 0;
                            using (StreamReader sr = new StreamReader(ms))
                                xml.LoadXml(sr.ReadToEnd());
                        }                        
                    }
                }
            }
            finally
            {

            }
            return xml;
        }

        
        private void btnCallFn1_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = DecompressXmlFile("note.xml.gz");
            if (xdoc != null)
                tbXml.Text = xdoc.OuterXml;
        }


        private void LoadAssembly(string compressed_assembly_resource)
        {
            try
            {
                using (Stream s = Assembly.GetEntryAssembly().GetManifestResourceStream(compressed_assembly_resource))
                {
                    using (GZipStream gz = new GZipStream(s, CompressionMode.Decompress))
                    {
                        const int size = 4096;
                        byte[] buffer = new byte[size];
                        using (MemoryStream ms = new MemoryStream())
                        {
                            int count = 0;
                            do
                            {
                                count = gz.Read(buffer, 0, size);
                                if (count > 0)
                                {
                                    ms.Write(buffer, 0, count);
                                }
                            }
                            while (count > 0);
                            ms.Position = 0;
                            Assembly.Load(ms.GetBuffer());
                        }
                    }
                }

            }
            finally
            {
                
            }
        }

        private string DecompressAssemblyInTempDir(string resource_name)
        {
            String result = "";
            try
            {
                using (Stream s = Assembly.GetEntryAssembly().GetManifestResourceStream(resource_name))
                {
                    using (GZipStream gz = new GZipStream(s, CompressionMode.Decompress))
                    {
                        const int size = 4096;
                        byte[] buffer = new byte[size];
                        result = Path.GetTempPath();
                        String[] parts = resource_name.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        String filename = result + parts[parts.Length-3] + "." + parts[parts.Length-2];
                        using (FileStream ms = File.Create(filename))
                        {
                            int count = 0;
                            do
                            {
                                count = gz.Read(buffer, 0, size);
                                if (count > 0)
                                {
                                    ms.Write(buffer, 0, count);
                                }
                            }
                            while (count > 0);
                            ms.Close();
                        }
                    }
                }

            }
            finally
            {
                
            }
            return result;
        }

        private void btnCallFn2_Click(object sender, EventArgs e)
        {
           LoadAssembly("MRogerApp.Resources.TestAssembly.dll.gz");
           ShowLoadedAssemblies();  
        }

        private void ShowLoadedAssemblies()
        {
            lbAssemblies.Items.Clear();
            AppDomain MyDomain = AppDomain.CurrentDomain;
            Assembly[] AssembliesLoaded = MyDomain.GetAssemblies();
            foreach (Assembly a in AssembliesLoaded)
                lbAssemblies.Items.Add(a.FullName);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowLoadedAssemblies();  
        }

        private void btnCallFn3_Click(object sender, EventArgs e)
        {
            tbDir.Text = DecompressAssemblyInTempDir("MRogerApp.Resources.TestAssembly.dll.gz");
        }
    }
}
