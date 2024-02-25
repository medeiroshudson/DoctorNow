using Microsoft.Extensions.Options;

namespace DoctorNow.Domain.Options.Validators;

[OptionsValidator]
public partial class DatabaseOptionsValidator : IValidateOptions<DatabaseOptions>
{
    // source generation will do the code via [OptionsValidator] attribute
}