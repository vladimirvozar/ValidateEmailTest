namespace ValidateEmailTest
{
    public class Result
    {
        public int CorrectValidEmailsValidations { get; set; }
        public int WrongValidEmailsValidations { get; set; }
        public int CorrectInvalidEmailsValidations { get; set; }
        public int WrongInvalidEmailsValidations { get; set; }

        public Result()
        {
            CorrectValidEmailsValidations = 0;
            WrongValidEmailsValidations = 0;
            CorrectInvalidEmailsValidations = 0;
            WrongInvalidEmailsValidations = 0;
        }
    }
}
