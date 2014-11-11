using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Reflection;
using Mono.Security;
using Mono.Security.X509;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace AssemblySinger
{
    public class Signer
    {
        static bool Compare(byte[] value1, byte[] value2)
        {
            if ((value1 == null) || (value2 == null))
                return false;
            bool result = (value1.Length == value2.Length);
            if (result)
            {
                for (int i = 0; i < value1.Length; i++)
                {
                    if (value1[i] != value2[i])
                        return false;
                }
            }
            return result;
        }

        public static bool ReSign(string assemblyName, string keyfile, string password)
        {
            return ReSign(assemblyName, GetKeyFromFile(keyfile, password));
        }

        static bool ReSign(string assemblyName, RSA key)
        {
            // this doesn't load the assembly (well it unloads it ;)
            AssemblyName an = null;
            try
            {
                an = AssemblyName.GetAssemblyName(assemblyName);
            }
            catch
            {
            }
            if (an == null)
            {
              //  MessageBox.Show(String.Format("Unable to load assembly: {0}", assemblyName));
                return false;
            }

            StrongName sign = new StrongName(key);
            byte[] token = an.GetPublicKeyToken();

            // first, try to compare using a mapped public key (e.g. ECMA)
            bool same = Compare(sign.PublicKey, StrongNameManager.GetMappedPublicKey(token));
            if (!same)
            {
                // second, try to compare using the assembly public key
                same = Compare(sign.PublicKey, an.GetPublicKey());
                if (!same)
                {
                    // third (and last) chance, try to compare public key token
                    same = Compare(sign.PublicKeyToken, token);
                }
            }

            if (same)
            {
                bool signed = sign.Sign(assemblyName);
              //  MessageBox.Show(String.Format(signed ? "Assembly {0} signed." : "Couldn't sign the assembly {0}.", assemblyName));
                return signed;
            }

           // MessageBox.Show(String.Format("Couldn't sign the assembly {0} with this key pair.", assemblyName));
            return false;
        }

        static byte[] ReadFromFile(string fileName)
        {
            byte[] data = null;
            FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
            }
            finally
            {
                fs.Close();
            }
            return data;
        }

        static RSA GetKeyFromFile(string filename, string password = "")
        {
            byte[] data = ReadFromFile(filename);
            try
            {
                // for SNK files (including the ECMA pseudo-key)
                return new StrongName(data).RSA;
            }
            catch
            {
                if (data[0] != 0x30)
                    throw;
                // this could be a PFX file
                //Console.Write("Enter password for private key (will be visible when typed): ");
                PKCS12 pfx = new PKCS12(data, password);
                // works only if a single key is present
                if (pfx.Keys.Count != 1)
                    throw;
                RSA rsa = (pfx.Keys[0] as RSA);
                if (rsa == null)
                    throw;
                return rsa;
            }
        }

    }
}
