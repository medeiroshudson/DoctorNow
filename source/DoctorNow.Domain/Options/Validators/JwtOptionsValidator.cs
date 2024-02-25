using Microsoft.Extensions.Options;

namespace DoctorNow.Domain.Options.Validators;

[OptionsValidator]
public partial class JwtOptionsValidator : IValidateOptions<JwtOptions>
{
    // source generation will do the code via [OptionsValidator] attribute
}