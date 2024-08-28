namespace GameZone.Attribute
{
    public class MaxFileAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {

            var file = value as IFormFile;

            if (file != null)
            {
                

                if (file.Length> _maxFileSize)
                {
                    return new ValidationResult(ErrorMessage=$" Maximum allowed Size is {_maxFileSize} bytes  ");
                }


            }
            return ValidationResult.Success;
        }
    }
}

