namespace WindowsFormsApp1.FluentValidations
{
    using FluentValidation;
    using WindowsFormsApp1.Entities.Auth;

    public class RegisterEntityValidator : AbstractValidator<RegisterEntity>
    {
        public RegisterEntityValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş ola bilməz.")
                .EmailAddress().WithMessage("Email formatı düzgün deyil.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("İstifadəçi adı boş ola bilməz.")
                .MinimumLength(3).WithMessage("Minimum 3 simvol olmalıdır.");

            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("Şifrə boş ola bilməz.")
                .MinimumLength(6).WithMessage("Minimum 6 simvol olmalıdır.");
        }
    }

}
