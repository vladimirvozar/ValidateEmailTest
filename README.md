### Overview ###

There is no perfect way for validating emails.
This small C# console app, demonstrates validation results for five different ways of email validation.

One way is with System.Net.Mail.MailAddress class, and other four are with different Regex patterns.
These validation methods are used to validate both valid and invalid email formats as input.

Following is the methods code, and final validation results.
For more details, download/clone the app and run it on your machine.
You can test some more emails as inputs, or add some different validation methods if you will.

```
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
```

```
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
```

```
	public static bool IsMailByRegexValid2(string emailAddress)
	{
		string theEmailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@" + 
								 @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";
		Regex _regex = new Regex(theEmailPattern);
		return _regex.IsMatch(emailAddress);
	}
```

```
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
```

```
	public static bool IsMailByRegexValid4(string emailAddress)
	{
		string theEmailPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
								 @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

		Regex _regex = new Regex(theEmailPattern);
		return _regex.IsMatch(emailAddress);
	}
```

### Validation results (CORRECT VALIDATIONS): ###

    IsMailAddressValid:  19 of 27
    IsMailByRegexValid1: 20 of 27
    IsMailByRegexValid2: 22 of 27
    IsMailByRegexValid3: 21 of 27
    IsMailByRegexValid4: 24 of 27
