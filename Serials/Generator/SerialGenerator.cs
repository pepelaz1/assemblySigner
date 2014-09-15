using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Security.Cryptography;

namespace Generator
{
    class SerialGenerator : IDisposable
    {
        private String _public;// = "<BitStrength>1024</BitStrength><RSAKeyValue><Modulus>vJxv6Rc/bI+x9xvG2qh5N3J6+4zyDxOpp4IDTxuAJy0BWheoMh/in38wdWPB1psHEXTvdntXO5MWV9YvNqMTeysCYRHgK216yDCjnO9pICPbbpVXsWMtNOF07ruzv1Chep23RItjTpK4UHgHNhLsN0MbfsnMRPYmZR8HBeshoW8=</Modulus><Exponent>AQAB</Exponent><P>+O3gA6LMC8YEKRqTQxr7bYb9+2Gq/K3lYdSRhmh2REUaSBaCnYlZTIvJLkLPbuZ91mvUEA1QOkJ7VVyQrUfUrw==</P><Q>wffzOwvfY1oMfwzb7nt/Q0EJnLsU0dCX8P9uK8YRhdq7tu+oaYXLNamkB33P2+alMC/SfAU2uqhBe7syqM+vQQ==</Q><DP>t9pZHdZbhkaWRBWQtntzQA34AHa+Zym4xWzOnssArqOrKZsWlWwgPFzyFezacDpkrr2tPr3Wh3Eazo0zfggTmQ==</DP><DQ>FWtRA7My7uCxwpHj83jVu9KBwjnyeZzkOmuqedD8fGCEHBZo7YYlw35BK8ab3negxCpzvthAi+oqmQQ5+uQ8QQ==</DQ><InverseQ>NhCk11pvaKYlqEKU25lzRcRUdtcaj1eT0Mms29XP6BOiDDMFNEAsDIG3ClPEt9mmD2Oo28uy19CZN9+7NppDOQ==</InverseQ><D>r7WVVDMCNSLRCoJoCMA23P7br4ko3/7TaGfoqUPXaae1wLaVTM0DlM8q19GtfT5DoXGsvFY/eBKZGA9DQMU/mTxmfYGodbMB1EVkWkCjAttn0eRLi0+WTQ6kwsu9vXKjSDdGiZ0Lw3xKU2kk1cdtnK6X813dsjL33t1r7j1mhQE=</D></RSAKeyValue>";
        private String _private;// = "<BitStrength>1024</BitStrength><RSAKeyValue><Modulus>vJxv6Rc/bI+x9xvG2qh5N3J6+4zyDxOpp4IDTxuAJy0BWheoMh/in38wdWPB1psHEXTvdntXO5MWV9YvNqMTeysCYRHgK216yDCjnO9pICPbbpVXsWMtNOF07ruzv1Chep23RItjTpK4UHgHNhLsN0MbfsnMRPYmZR8HBeshoW8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private String _encrypted_string;

        private int _rsa_key_size = 1024;
        private int _seed = 1000;
        private int _startMember = 100000000;
        private Random _rnd;
        private int _serCount = 5000;
        private ArrayList _serials = new ArrayList();
        private TextWriter _tw;

        public int SerialsCount
        {
            get { return _serCount; }
        }

        public int Seed
        {
            get { return _seed; }
        }

        public int StartMember
        {
            get { return _startMember; }
        }

        public SerialGenerator(int seed, int startMember)
        {
            _seed = seed;
            _startMember = startMember;
            _rnd = new Random(_seed);
        }

        public SerialGenerator()
        {
        }       

        private byte GenSerialSymbol()
        {
            int val = 0;
            while ((val < 48) || (val > 57 && val < 65) || (val > 90))
                val = _rnd.Next(48, 90);

            return (byte)val;
        }

        public void Generate(bool write_to_file = true)
        {
            _serials.Clear();

            // Move to start member of random sequence
            for (int i = 0; i < _startMember; i++)
                _rnd.Next();

            int cnt = 0;
           // int tot = 0;
            for (; ; )
            {
                String serial = "";
                for (int j = 0; j < 16; j++)
                {
                    if ((j % 4) == 0 && j != 0)
                        serial += "-";
                    serial += Encoding.ASCII.GetString(new byte[] { GenSerialSymbol() });
                }
                if (_serials.Contains(serial) == false)
                {
                    _serials.Add(serial);
                    cnt++;
                }
             //   tot++;
                if (cnt >= _serCount)
                    break;
            }

            if (write_to_file)
            {
                using (_tw = new StreamWriter("serials.txt"))
                {

                    foreach (String s in _serials)
                        _tw.WriteLine(s);
                    _tw.Close();
                }

                GenerateKeys();
                EncryptString(Seed.ToString() + " " + StartMember.ToString());
                WriteSecret();
            }
        }

        public String GetByNumber(int num)
        {
            Generate(false);
            return _serials[num].ToString();
        }

        public void Dispose()
        {
            
        }

        private void GenerateKeys()
        {
            RSACryptoServiceProvider rsa_prov = new RSACryptoServiceProvider(_rsa_key_size);
            _public = rsa_prov.ToXmlString(false);
            _private = rsa_prov.ToXmlString(true);
        }

        private void EncryptString(String inputString)
        {
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(_rsa_key_size);
            rsaCryptoServiceProvider.FromXmlString(_public);
            int keySize = _rsa_key_size / 8;
            byte[] bytes = Encoding.UTF32.GetBytes(inputString);
            // The hash function in use by the .NET RSACryptoServiceProvider here is SHA1
            // int maxLength = ( keySize ) - 2 - ( 2 * SHA1.Create().ComputeHash( rawBytes ).Length );
            int maxLength = keySize - 42;
            int dataLength = bytes.Length;
            int iterations = dataLength / maxLength;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= iterations; i++)
            {
                byte[] tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
                Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length);
                byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes, true);
                // Be aware the RSACryptoServiceProvider reverses the order of encrypted bytes after encryption and before decryption.
                // If you do not require compatibility with Microsoft Cryptographic API (CAPI) and/or other vendors.
                // Comment out the next line and the corresponding one in the DecryptString function.
                Array.Reverse(encryptedBytes);
                // Why convert to base 64?
                // Because it is the largest power-of-two base printable using only ASCII characters
                stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
            }
            _encrypted_string =  stringBuilder.ToString();
        }

        private void WriteSecret()
        {
            using (_tw = new StreamWriter("..\\Verifier\\Secret.cs"))
            {
                _tw.WriteLine("using System;");
                _tw.WriteLine("using System.Collections.Generic;");
                _tw.WriteLine("using System.Linq;");
                _tw.WriteLine("using System.Text;");
                _tw.WriteLine("");
                _tw.WriteLine("namespace Verifier");
                _tw.WriteLine("{");
                _tw.WriteLine("  class Secret");
                _tw.WriteLine("  {");
                _tw.WriteLine("     private static String _key = \"" + _private + "\";");
                _tw.WriteLine("     public static String Key");
                _tw.WriteLine("     {");
                _tw.WriteLine("         get {return _key;}");
                _tw.WriteLine("     }");
                _tw.WriteLine("");
                _tw.WriteLine("     private static String _data = \"" + _encrypted_string + "\";");
                _tw.WriteLine("     public static String Data");
                _tw.WriteLine("     {");
                _tw.WriteLine("         get {return _data;}");
                _tw.WriteLine("     }");
                _tw.WriteLine("  }");
                _tw.WriteLine("}");

                _tw.Close();
            }
        }
    }    
}
