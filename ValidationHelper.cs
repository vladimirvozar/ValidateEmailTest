using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ValidateEmailTest
{
    public static class ValidationHelper
    {
        /// <summary>
        /// Validation with System.Net.Mail.MailAddress class
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public static bool IsMailAddressValid(string emailAddress)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(emailAddress);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validating with regex - version 1
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public static bool IsMailByRegexValid1(string emailAddress)
        {
            // Email address: RFC 2822 Format
            // Matches a normal email address. Does not check the top - level domain.
            // Requires the "case insensitive" option to be ON.
            string theEmailPattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@" + 
                                     @"(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            Regex _regex = new Regex(theEmailPattern);
            return _regex.IsMatch(emailAddress);
        }

        /// <summary>
        /// Validating with regex - version 2
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public static bool IsMailByRegexValid2(string emailAddress)
        {
            string theEmailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@" + 
                                     @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";
            Regex _regex = new Regex(theEmailPattern);
            return _regex.IsMatch(emailAddress);
        }

        /// <summary>
        /// Validating with regex - version 3
        /// General Email Regex (RFC 5322 Official Standard)
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public static bool IsMailByRegexValid3(string emailAddress)
        {
            string theEmailPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                    + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                        [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                    + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                        [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                    + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

            Regex _regex = new Regex(theEmailPattern);
            return _regex.IsMatch(emailAddress);
        }

        /// <summary>
        /// Validating with regex - version 4
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public static bool IsMailByRegexValid4(string emailAddress)
        {
            string theEmailPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                     @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

            Regex _regex = new Regex(theEmailPattern);
            return _regex.IsMatch(emailAddress);
        }
    }
}
