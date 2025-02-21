//using BookManagement.Application.Books.Commands.Create;
//using BookManagement.Application.Common;
//using MediatR;

//namespace BookManagement.Application.Books.Commands.CreateBulk
//{
//    public class CreateBookBulkCommandHandler : IRequestHandler<CreateBookCommand, Guid>
//    {
//        private readonly IAppicationDbContext _context;

//        public CreateBookBulkCommandHandler(IAppicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
