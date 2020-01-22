namespace ValidateEmailTest
{
    public class Email
    {
        public string Format { get; set; }
        public string Description { get; set; }

        public Email(string format, string description)
        {
            Format = format;
            Description = description;
        }
    }
}
