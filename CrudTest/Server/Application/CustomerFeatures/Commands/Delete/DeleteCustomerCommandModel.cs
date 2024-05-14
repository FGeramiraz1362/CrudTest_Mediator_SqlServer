using MediatR;

namespace Mc2.CrudTest.Presentation.Server.CustomerFeatures.Commands.Delete
{
    public class DeleteCustomerCommandModel : IRequest
    {
        public int Id { get; set; }
    }
}

