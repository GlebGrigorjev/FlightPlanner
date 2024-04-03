using FlightPlannerUseCases.Models;
using FluentValidation;

namespace FlightPlannerUseCases.Validations
{
    public class AirportViewModelValidator : AbstractValidator<AirportViewModel>
    {
        public AirportViewModelValidator()
        {
            RuleFor(viewModel => viewModel.Airport).NotEmpty();
        }
    }
}
