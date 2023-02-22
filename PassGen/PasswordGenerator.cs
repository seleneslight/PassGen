using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGen
{
    class PasswordGenerator
    {
        public string generatePassword(int passLength, string allowedCharacters)
        {
            StringBuilder pass = new StringBuilder();
            Random rdn = new Random();
            for (int i = 0; i < passLength; i++)
            {
                if(allowedCharacters.Length>0) pass.Append(allowedCharacters[(int)rdn.NextInt64(0, allowedCharacters.Length)]);
            }
            return pass.ToString();
        }
    }
}

