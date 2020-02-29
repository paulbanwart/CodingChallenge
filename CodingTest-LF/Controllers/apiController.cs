using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingTest_LF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingTest_LF.Controllers
{
    [Route("api/encode")]
    [ApiController]
    public class apiController : ControllerBase
    {
        char[] alphabet = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        // POST: api/encode
        [HttpPost]
        public string Post([FromBody] Cipher cipher)
        {
           char[] encodedArray = new char[cipher.Message.Length];
           string message = cipher.Message.ToUpper();

            //go letter by letter through the alphabet, updating the encodedArray when there's a match
            for (int i = 0; i < alphabet.Length; i++)
            {
                int count = 0;
                foreach (char c in message)
                {
                 //ignore spaces, preserve its place in array
                    if (c == ' ')
                    {
                        encodedArray[count] = ' ';
                        count++;
                        continue;
                    }
                  //ignore any case where the alphabet character does not equal, don't do anything, continue       
                    if (alphabet[i] != c)
                    {
                        count++;
                        continue;
                    }

                    //calculate the shifted letter using the index of the alphabet array
                   int shift = Array.IndexOf(alphabet, c) + cipher.Shift;
                    if (shift <= 0)
                        shift = shift + 26;

                    if (shift >= 26)
                        shift = shift - 26;

                    //update encodedArray with encoded character
                    encodedArray[count] = alphabet[shift];
                    count++;
                }
            }
            //save encoded message to file (append new line with encoded message)
            return new string(encodedArray);
        }
    }
}
