using System.ComponentModel.DataAnnotations;

namespace AnimalsDbConnection.Validators;

public class StringValidator : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        string stringValue = value as string;
        if (stringValue.ToLower() == "string")
        {
            return false;
        }

        return true;
    }
}