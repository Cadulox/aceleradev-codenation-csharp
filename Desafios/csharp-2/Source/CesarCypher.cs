using System;
using System.Linq;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        private const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        private const int rotation = 3;
        public string Crypt(string message)
        {

            if (message is null)
            {
                throw new ArgumentNullException();
            }
            else if (message.Length is 0)
            {
                return message;
            }
            else
            {
                string lowercaseMessage = message.ToLower();
                string result = string.Empty;
                foreach (var letter in lowercaseMessage)
                {
                    if (alphabet.Contains(letter))
                    {
                        int charIndex = alphabet.IndexOf(letter);
                        result += alphabet[(charIndex + rotation) % alphabet.Length];
                    }
                    else if (char.IsWhiteSpace(letter) || char.IsNumber(letter))
                    {
                        result += letter;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                return result;
            }

        }

        public string Decrypt(string cryptedMessage)
        {
            if (cryptedMessage is null)
            {
                throw new ArgumentNullException();
            }
            else if (cryptedMessage.Length is 0)
            {
                return cryptedMessage;
            }
            else
            {
                string lowercaseMessage = cryptedMessage.ToLower();
                string result = string.Empty;
                foreach (var letter in lowercaseMessage)
                {
                    if (alphabet.Contains(letter))
                    {
                        int charIndex = alphabet.IndexOf(letter);
                        int aux = (charIndex - rotation) % alphabet.Length;
                        if (aux >= 0)
                        {
                            result += alphabet[aux];
                        }
                        else
                        {
                            result += alphabet[aux + alphabet.Length];
                        }
                    }
                    else if (char.IsWhiteSpace(letter) || char.IsNumber(letter))
                    {
                        result += letter;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                return result;
            }

        }
    }
}
