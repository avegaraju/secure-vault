using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SecureVault.Web.Models;

namespace SecureVault.Web.Controllers
{
    public class PasswordGeneratorController : Controller
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public IActionResult Index()
        {
            var password = GenerateRandomPassword();
            var passwordViewModel = new PasswordViewModel
            {
                Password = password
            };

            return PartialView("_PasswordGeneratorPartial", passwordViewModel);
        }

        private string GenerateRandomPassword()
        {
            Random rnd = new Random();
            var randomDigitSize = 3;
            var randomLowerCaseCharactersSize = 5;
            var randomUpperCaseCharactersSize = 5;
            var randomSpecialCharacterSize = 5;

            var randomizedDigits = GenerateRandomNumbers(randomDigitSize);
            var randomizedLowerCaseCharacters = GenerateRandomLowerCaseString(randomLowerCaseCharactersSize);
            var randomizedUpperCaseCharacters = GenerateRandomUpperCaseString(randomUpperCaseCharactersSize);
            var randomizedSpecialCharacters = GenerateRandomSpecialCharacterString(randomSpecialCharacterSize);

            var combinedString = randomizedDigits
                .Append(randomizedUpperCaseCharacters)
                .Append(randomizedLowerCaseCharacters)
                .Append(randomizedSpecialCharacters)
                .ToString();

            return RandomizeString(combinedString);
        }

        private string RandomizeString(string combinedString)
        {
            var passwordBuilder = new StringBuilder();
            
            for (int i = 0; i < combinedString.Length; i++)
            {
                var randomizedIndexOfCharacter = RandomNumber(0, combinedString.Length -1);
                passwordBuilder.Append(combinedString[randomizedIndexOfCharacter]);
            }

            return passwordBuilder.ToString();
        }

        private StringBuilder GenerateRandomLowerCaseString(int randomLowerCaseCharactersSize)
        {
            StringBuilder randomizedLowerCaseCharacters = new StringBuilder();

            for (int i = 0; i < randomLowerCaseCharactersSize; i++)
            {
                var ch = Convert.ToChar(RandomNumber(97, 122));
                randomizedLowerCaseCharacters.Append(ch);
            }

            return randomizedLowerCaseCharacters;
        }

        private StringBuilder GenerateRandomSpecialCharacterString(int randomSpecialCharactersSize)
        {
            StringBuilder randomizedLowerCaseCharacters = new StringBuilder();

            for (int i = 0; i < randomSpecialCharactersSize; i++)
            {
                var ch = Convert.ToChar(RandomNumber(33, 46));
                randomizedLowerCaseCharacters.Append(ch);
            }

            return randomizedLowerCaseCharacters;
        }

        private StringBuilder GenerateRandomUpperCaseString(int randomUpperCaseCharactersSize)
        {
            StringBuilder randomizedLowerCaseCharacters = new StringBuilder();

            for (int i = 0; i < randomUpperCaseCharactersSize; i++)
            {
                var ch = Convert.ToChar(RandomNumber(65, 90));
                randomizedLowerCaseCharacters.Append(ch);
            }

            return randomizedLowerCaseCharacters;
        }


        private StringBuilder GenerateRandomNumbers(int randomDigitSize)
        {
            StringBuilder randomizedDigits = new StringBuilder();
            
            for (int i = 0; i <= randomDigitSize - 1; i++)
            {
                var ch = Convert.ToChar(RandomNumber(48, 57));
                randomizedDigits.Append(ch);
            }

            return randomizedDigits;
        }

        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { 
                return random.Next(min, max);
            }
        }
    }
}