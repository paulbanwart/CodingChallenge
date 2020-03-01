using System;
using System.Collections.Generic;
using System.IO;
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
        //Due to this class being an APIController and this method being an HttpPost there are alot of goodies baked in like responding with a 500 when there is a server error
        [HttpPost]
        public EncodedMessageModel Post([FromBody] Cipher cipher)
        {
            char[] encodedArray = new char[cipher.Message.Length];
            //uppercase all characters so we only need to test against 26 total characters
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

                    //calculate the shifted letter using the index of the alphabet array to get offset
                    int shift = Array.IndexOf(alphabet, c) + cipher.Shift;
                    if (shift <= 0)
                        shift = shift + 26;

                    if (shift >= 26)
                        shift = shift - 26;

                    //update encodedArray with encoded character
                    encodedArray[count] = alphabet[shift];
                    //next letter of the alphabet
                    count++;
                }
            }
            EncodedMessageModel encodedMessage = new EncodedMessageModel() { EncodedMessage = new string(encodedArray) };
            //save encoded message to file (i.e. append new line with encoded message)
           bool Saved = SaveToFile(new EncodedMessageModel() { EncodedMessage = new string(encodedArray)});
            if (!Saved)
            {
                //if unable to save file, respond with empty string
                return new EncodedMessageModel() { EncodedMessage = "" };
            }
            return encodedMessage;
        }

        private bool SaveToFile(EncodedMessageModel encodedMessage)
        {

            return true;

        }
    }
}
