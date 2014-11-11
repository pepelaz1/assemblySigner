using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace KeyLib
{
    public class RegKey
    {
        private String _key;
        public String Key
        {
            get { return _key;}
            set { _key = value; }
        }

        private String _hash;
        public String Hash
        {
            get { return _hash; }
            set { _hash = value; }
        }

        private String GenerateRandomKey()
        {
            String key = "";
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    key += Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rnd.NextDouble() + 65)));
                }
                if (i != 3)
                    key += "-";
            }
            return key;
        }

        public void Generate()
        {
            _key = GenerateRandomKey();
            _hash = Hasher.GetHash(_key, Hasher.HashType.MD5);
        }

        public static bool Verify(String key, String hash)
        {
            return hash == Hasher.GetHash(key, Hasher.HashType.MD5);
        }
    }
}
