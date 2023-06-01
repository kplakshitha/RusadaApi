using System.ComponentModel.DataAnnotations;

namespace Data.Attributes
{
    public class PastDateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            var d = Convert.ToDateTime(value);
            return d < DateTime.Now; //Dates less than today are valid (true)
        }
    }
}
