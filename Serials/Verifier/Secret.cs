using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Verifier
{
  class Secret
  {
     private static String _key = "<RSAKeyValue><Modulus>ozb3jjVxAtSQeuwsLOZvgik7zrkF5PHE52rOE5S5B0kPDjzZaXoJQmpDSqPcdNg3WuIGHjS2mzpGr8b0nwGmVSis0XxF8qYWtMEhaDU2fS1SjOFsy6wfS1F4akGQyxTPeqQLXTbPIuqtbXZwYDTIerfQsryZlxtltpCQbSgdXbE=</Modulus><Exponent>AQAB</Exponent><P>2cWiUNh9/GSkgoCCeXaHeK1OpU72TxUmpy/YcNmVU4bd/ao5ihaJIH037bSjX+64wgENArUrSLhRcbUzwbdJXQ==</P><Q>v92a+2vOlb6PL+VrLEOwC4LtCwCc2ni9WVHzvyxuIcC5U31Eyeq/rPH9B2P9m+yaCzfUtDTwnTkpcp591zBcZQ==</Q><DP>R4qvylN1ACeoC99f/bs8wh5dSd1o+Y3/RslnF5vDfM8/uofjo0PIBM5eQ08mpOtt8v4ZYhxWfetfhjV7LVajWQ==</DP><DQ>QYW/gK8vbKoYIiY59HLlMvkyVHiQGHf1SgSXtijJL5OudpmoHUCi1sAJRjXajR4++SfG5wfRSBAWXINNvGhSlQ==</DQ><InverseQ>Y/0c9ZEciT4LtpksE2cJ4HSysoEq82VpZF4BhAz97zUkB3ICS1jbP8YxH9to7rq+3D8YZ7MgJnCk8qJptDdq9Q==</InverseQ><D>TEi5pd72hhMhwEI4V3gQsC5jhLhXt+0EUgFKdj5xyKTuA4KPP0xJnaAa+Xzi4j3YiYLQxzduDdlMBoYf+V2FBtL48CkL7Dqw+iYPnDYKKGjn4DjrZmkoWritu62JRsoacjZgyOEKw6IdXb2ebILH3Xs5H/nfTd/rBqT28db6jZE=</D></RSAKeyValue>";
     public static String Key
     {
         get {return _key;}
     }

     private static String _data = "VxsIV56OeQrFLjmNqkCnXJKkJ4k3R5fy1e0unIJ2SKkKB9ifYK8x9f28iHsMxY86FD5U6Xh7Gm6M1MzT8d/LFIb8gx53C0HyqduNRGUETidiFYjvQLTG3J76EIdITBpDYaTlwEdeQz/xIktx0v4a6oIFvCRCWFr2FqvSgyR1ahE=";
     public static String Data
     {
         get {return _data;}
     }
  }
}
