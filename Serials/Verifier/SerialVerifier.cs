using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using System.IO;

namespace Verifier
{
    class SerialVerifier : IDisposable
    {
        private int _rsa_key_size = 1024;
        private int _serCount = 5000;
        private String _serial;
        private ArrayList _serials = new ArrayList();
        private int _seed;
        private int _startMember;
        private Random _rnd;

        private String _license_file = "license.key";
        private String _password = @"myKey123";

        public SerialVerifier()
        {
            
        }

        public String Serial
        {
            get { return _serial; }
        }

        public bool Verify(String serial)
        {
            // try read from license.key
            ReadFromFile(serial);
            
            DecryptString();
            GenerateAll();
            bool b =  _serials.Contains(_serial);
            if (b == true)
                SaveToFile();
            return b;
        }

        private byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private void ReadFromFile(String serial)
        {
            if (File.Exists(_license_file))
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(_password);
  
                FileStream fsCrypt = new FileStream(_license_file, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                int n = 0;
                byte [] bts = new byte[1024];
                while ((bts[n] = (byte)cs.ReadByte()) != 255)
                     n++;
                _serial = UE.GetString(bts,0,n);
                    
                cs.Close();
                fsCrypt.Close();
            }
            else
                _serial = serial;
        }
              

        private void SaveToFile()
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(_password);

            string cryptFile = _license_file;
            FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateEncryptor(key, key),
                CryptoStreamMode.Write);

            cs.Write(GetBytes(_serial), 0, _serial.Length * sizeof(char));

            cs.Close();
            fsCrypt.Close();
        }

        public void Dispose()
        {
           
        }

        private void DecryptString()
        {
            String inputString = Secret.Data;
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(_rsa_key_size);
            rsaCryptoServiceProvider.FromXmlString(Secret.Key);
            int base64BlockSize = ((_rsa_key_size / 8) % 3 != 0) ? (((_rsa_key_size / 8) / 3) * 4) + 4 : ((_rsa_key_size / 8) / 3) * 4;
            int iterations = inputString.Length / base64BlockSize;
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < iterations; i++)
            {
                byte[] encryptedBytes = Convert.FromBase64String(inputString.Substring(base64BlockSize * i, base64BlockSize));
                // Be aware the RSACryptoServiceProvider reverses the order of encrypted bytes after encryption and before decryption.
                // If you do not require compatibility with Microsoft Cryptographic API (CAPI) and/or other vendors.
                // Comment out the next line and the corresponding one in the EncryptString function.
                Array.Reverse(encryptedBytes);
                arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(encryptedBytes, true));
            }
            String decrypted_string =  Encoding.UTF32.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
            _seed = Int32.Parse(decrypted_string.Split(" ".ToCharArray())[0]);
            _startMember = Int32.Parse(decrypted_string.Split(" ".ToCharArray())[1]);
            
        }

        private byte GenSerialSymbol()
        {
            int val = 0;
            while ((val < 48) || (val > 57 && val < 65) || (val > 90))
                val = _rnd.Next(48, 90);

            return (byte)val;
        }

        private void GenerateAll()
        {

            _rnd = new Random(_seed);
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
        }
    }
}
