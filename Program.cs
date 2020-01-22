using System;
using System.Collections.Generic;

namespace ValidateEmailTest
{
    class Program
    {
        public static Result IsMailAddressValidResult { get; set; }
        public static Result IsMailByRegexValid1Result { get; set; }
        public static Result IsMailByRegexValid2Result { get; set; }
        public static Result IsMailByRegexValid3Result { get; set; }
        public static Result IsMailByRegexValid4Result { get; set; }


        public static List<Email> GetValidEmails()
        {
            List<Email> emails = new List<Email>
            {
                new Email("email@domain.com", "Valid email"),
                new Email("firstname.lastname@domain.com", "Email contains dot in the address field"),
                new Email("email@subdomain.domain.com", "Email contains dot with subdomain"),
                new Email("firstname+lastname@domain.com", "Plus sign is considered valid character"),
                new Email("email@123.123.123.123", "Domain is valid IP address"),
                new Email("email@[123.123.123.123]", "Square bracket around IP address is considered valid"),
                new Email("\"email\"@domain.com", "Quotes around email is considered valid"),
                new Email("1234567890@domain.com", "Digits in address are valid"),
                new Email("email@domain-one.com", "Dash in domain name is valid"),
                new Email("_______@domain.com", "Underscore in the address field is valid"),
                new Email("email@domain.name", ".name is valid Top Level Domain name"),
                new Email("email@domain.co.jp", "Dot in Top Level Domain name also considered valid (use co.jp as example here)"),
                new Email("firstname-lastname@domain.com", "Dash in address field is valid"),
            };
            return emails;
        }

        public static List<Email> GetInvalidEmails()
        {
            List<Email> emails = new List<Email>
            {
                new Email("plainaddress", "Missing @ sign and domain"),
                new Email("#@%^%#$@#$@#.com", "Garbage"),
                new Email("@domain.com", "Missing username"),
                new Email("email.domain.com", "Missing @"),
                new Email("email@domain@domain.com", "Two @ sign"),
                new Email(".email@domain.com", "Leading dot in address is not allowed"),
                new Email("email.@domain.com", "Trailing dot in address is not allowed"),
                new Email("email..email@domain.com", "Multiple dots"),
                new Email("あいうえお@domain.com", "Unicode char as address"),
                new Email("email@domain", "Missing top level domain (.com/.net/.org/etc)"),
                new Email("email@-domain.com", "Leading dash in front of domain is invalid"),
                new Email("email@domain.web", ".web is not a valid top level domain"),
                new Email("email@111.222.333.44444", "Invalid IP format"),
                new Email("email@domain..com", "Multiple dot in the domain portion is invalid")
            };
            return emails;
        }

        static void Main(string[] args)
        {
            IsMailAddressValidResult = new Result();
            IsMailByRegexValid1Result = new Result();
            IsMailByRegexValid2Result = new Result();
            IsMailByRegexValid3Result = new Result();
            IsMailByRegexValid4Result = new Result();

            // valid emails:
            WriteCyanMessage("VALID EMAIL FORMATS:");
            TestValidEmails();

            Console.WriteLine("-------------------------------------\n");

            // invalid emails:
            WriteCyanMessage("INVALID EMAIL FORMATS:");
            TestInvalidEmails();

            Console.WriteLine("--------------------------------------------------------------------------\n");
            WriteCyanMessage("TOTAL VALIDATION RESULTS (CORRECT VALIDATIONS):\n");
            Console.WriteLine("IsMailAddressValid:  " + (IsMailAddressValidResult.CorrectValidEmailsValidations + IsMailAddressValidResult.CorrectInvalidEmailsValidations) + 
                                " of " + (GetValidEmails().Count + GetInvalidEmails().Count));
            Console.WriteLine("IsMailByRegexValid1: " + (IsMailByRegexValid1Result.CorrectValidEmailsValidations + IsMailByRegexValid1Result.CorrectInvalidEmailsValidations) +
                                " of " + (GetValidEmails().Count + GetInvalidEmails().Count));
            Console.WriteLine("IsMailByRegexValid2: " + (IsMailByRegexValid2Result.CorrectValidEmailsValidations + IsMailByRegexValid2Result.CorrectInvalidEmailsValidations) +
                                " of " + (GetValidEmails().Count + GetInvalidEmails().Count));
            Console.WriteLine("IsMailByRegexValid3: " + (IsMailByRegexValid3Result.CorrectValidEmailsValidations + IsMailByRegexValid3Result.CorrectInvalidEmailsValidations) +
                                " of " + (GetValidEmails().Count + GetInvalidEmails().Count));
            Console.WriteLine("IsMailByRegexValid4: " + (IsMailByRegexValid4Result.CorrectValidEmailsValidations + IsMailByRegexValid4Result.CorrectInvalidEmailsValidations) +
                                " of " + (GetValidEmails().Count + GetInvalidEmails().Count));

            Console.WriteLine("--------------------------------------------------------------------------\n\n");
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }

        public static void TestValidEmails()
        {
            foreach (var email in GetValidEmails())
            {
                Console.WriteLine("\n");
                WriteCyanMessage(email.Format + " - " + email.Description);

                // validating with System.Net.Mail.MailAddress
                Console.Write("IsMailAddressValid  returned: ");
                if (ValidationHelper.IsMailAddressValid(email.Format))
                { 
                    WriteGreenMessage("correct");
                    IsMailAddressValidResult.CorrectValidEmailsValidations++;
                }
                else
                {
                    WriteRedMessage("wrong");
                    IsMailAddressValidResult.WrongValidEmailsValidations++;
                }

                // validating with first regex version
                Console.Write("IsMailByRegexValid1 returned: ");
                if (ValidationHelper.IsMailByRegexValid1(email.Format))
                {
                    WriteGreenMessage("correct");
                    IsMailByRegexValid1Result.CorrectValidEmailsValidations++;
                }
                else
                {
                    WriteRedMessage("wrong");
                    IsMailByRegexValid1Result.WrongValidEmailsValidations++;
                }

                // validating with second regex version
                Console.Write("IsMailByRegexValid2 returned: ");
                if (ValidationHelper.IsMailByRegexValid2(email.Format))
                {
                    WriteGreenMessage("correct");
                    IsMailByRegexValid2Result.CorrectValidEmailsValidations++;
                }
                else
                {
                    WriteRedMessage("wrong");
                    IsMailByRegexValid2Result.WrongValidEmailsValidations++;
                }

                // validating with third regex version
                Console.Write("IsMailByRegexValid3 returned: ");
                if (ValidationHelper.IsMailByRegexValid3(email.Format))
                {
                    WriteGreenMessage("correct");
                    IsMailByRegexValid3Result.CorrectValidEmailsValidations++;
                }
                else
                {
                    WriteRedMessage("wrong");
                    IsMailByRegexValid3Result.WrongValidEmailsValidations++;
                }

                // validating with fourth regex version
                Console.Write("IsMailByRegexValid4 returned: ");
                if (ValidationHelper.IsMailByRegexValid4(email.Format))
                {
                    WriteGreenMessage("correct");
                    IsMailByRegexValid4Result.CorrectValidEmailsValidations++;
                }
                else
                {
                    WriteRedMessage("wrong");
                    IsMailByRegexValid4Result.WrongValidEmailsValidations++;
                }
            }

            WriteCyanMessage("\nVALID EMAILS VALIDATION RESULTS:");
            Console.WriteLine("\nIsMailAddressValid - CORRECT: " + IsMailAddressValidResult.CorrectValidEmailsValidations + " of " + GetValidEmails().Count);
            Console.WriteLine("IsMailAddressValid - WRONG: " + IsMailAddressValidResult.WrongValidEmailsValidations + " of " + GetValidEmails().Count);

            Console.WriteLine("\nIsMailByRegexValid1 - CORRECT: " + IsMailByRegexValid1Result.CorrectValidEmailsValidations + " of " + GetValidEmails().Count);
            Console.WriteLine("IsMailByRegexValid1 - WRONG: " + IsMailByRegexValid1Result.WrongValidEmailsValidations + " of " + GetValidEmails().Count);

            Console.WriteLine("\nIsMailByRegexValid2 - CORRECT: " + IsMailByRegexValid2Result.CorrectValidEmailsValidations + " of " + GetValidEmails().Count);
            Console.WriteLine("IsMailByRegexValid2 - WRONG: " + IsMailByRegexValid2Result.WrongValidEmailsValidations + " of " + GetValidEmails().Count);

            Console.WriteLine("\nIsMailByRegexValid3 - CORRECT: " + IsMailByRegexValid3Result.CorrectValidEmailsValidations + " of " + GetValidEmails().Count);
            Console.WriteLine("IsMailByRegexValid3 - WRONG: " + IsMailByRegexValid3Result.WrongValidEmailsValidations + " of " + GetValidEmails().Count);

            Console.WriteLine("\nIsMailByRegexValid4 - CORRECT: " + IsMailByRegexValid4Result.CorrectValidEmailsValidations + " of " + GetValidEmails().Count);
            Console.WriteLine("IsMailByRegexValid4 - WRONG: " + IsMailByRegexValid4Result.WrongValidEmailsValidations + " of " + GetValidEmails().Count);

        }

        public static void TestInvalidEmails()
        {
            foreach (var email in GetInvalidEmails())
            {
                Console.WriteLine("\n");
                WriteCyanMessage(email.Format + " - " + email.Description);

                // validating with System.Net.Mail.MailAddress
                Console.Write("IsMailAddressValid  returned: ");
                if (!ValidationHelper.IsMailAddressValid(email.Format))
                {
                    WriteGreenMessage("correct");
                    IsMailAddressValidResult.CorrectInvalidEmailsValidations++;
                }
                else
                {
                    WriteRedMessage("wrong");
                    IsMailAddressValidResult.WrongInvalidEmailsValidations++;
                }

                // validating with first regex version
                Console.Write("IsMailByRegexValid1 returned: ");
                if (!ValidationHelper.IsMailByRegexValid1(email.Format))
                {
                    WriteGreenMessage("correct");
                    IsMailByRegexValid1Result.CorrectInvalidEmailsValidations++;
                }
                else
                {
                    WriteRedMessage("wrong");
                    IsMailByRegexValid1Result.WrongInvalidEmailsValidations++;
                }

                // validating with second regex version
                Console.Write("IsMailByRegexValid2 returned: ");
                if (!ValidationHelper.IsMailByRegexValid2(email.Format))
                {
                    WriteGreenMessage("correct");
                    IsMailByRegexValid2Result.CorrectInvalidEmailsValidations++;
                }
                else
                {
                    WriteRedMessage("wrong");
                    IsMailByRegexValid2Result.WrongInvalidEmailsValidations++;
                }

                // validating with third regex version
                Console.Write("IsMailByRegexValid3 returned: ");
                if (!ValidationHelper.IsMailByRegexValid3(email.Format))
                {
                    WriteGreenMessage("correct");
                    IsMailByRegexValid3Result.CorrectInvalidEmailsValidations++;
                }
                else
                {
                    WriteRedMessage("wrong");
                    IsMailByRegexValid3Result.WrongInvalidEmailsValidations++;
                }

                // validating with fourth regex version
                Console.Write("IsMailByRegexValid4 returned: ");
                if (!ValidationHelper.IsMailByRegexValid4(email.Format))
                {
                    WriteGreenMessage("correct");
                    IsMailByRegexValid4Result.CorrectInvalidEmailsValidations++;
                }
                else
                {
                    WriteRedMessage("wrong");
                    IsMailByRegexValid4Result.WrongInvalidEmailsValidations++;
                }
            }

            WriteCyanMessage("\nINVALID EMAILS VALIDATION RESULTS:");
            Console.WriteLine("\nIsMailAddressValid - CORRECT: " + IsMailAddressValidResult.CorrectInvalidEmailsValidations + " of " + GetInvalidEmails().Count);
            Console.WriteLine("IsMailAddressValid - WRONG: " + IsMailAddressValidResult.WrongInvalidEmailsValidations + " of " + GetInvalidEmails().Count);

            Console.WriteLine("\nIsMailByRegexValid1 - CORRECT: " + IsMailByRegexValid1Result.CorrectInvalidEmailsValidations + " of " + GetInvalidEmails().Count);
            Console.WriteLine("IsMailByRegexValid1 - WRONG: " + IsMailByRegexValid1Result.WrongInvalidEmailsValidations + " of " + GetInvalidEmails().Count);

            Console.WriteLine("\nIsMailByRegexValid2 - CORRECT: " + IsMailByRegexValid2Result.CorrectInvalidEmailsValidations + " of " + GetInvalidEmails().Count);
            Console.WriteLine("IsMailByRegexValid2 - WRONG: " + IsMailByRegexValid2Result.WrongInvalidEmailsValidations + " of " + GetInvalidEmails().Count);

            Console.WriteLine("\nIsMailByRegexValid3 - CORRECT: " + IsMailByRegexValid3Result.CorrectInvalidEmailsValidations + " of " + GetInvalidEmails().Count);
            Console.WriteLine("IsMailByRegexValid3 - WRONG: " + IsMailByRegexValid3Result.WrongInvalidEmailsValidations + " of " + GetInvalidEmails().Count);

            Console.WriteLine("\nIsMailByRegexValid4 - CORRECT: " + IsMailByRegexValid4Result.CorrectInvalidEmailsValidations + " of " + GetInvalidEmails().Count);
            Console.WriteLine("IsMailByRegexValid4 - WRONG: " + IsMailByRegexValid4Result.WrongInvalidEmailsValidations + " of " + GetInvalidEmails().Count);
        }

        public static void WriteGreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteCyanMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteRedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
