using challengeN5.Data.interfaces;
using MediatR;
using System.Transactions;

namespace challengeN5.Data.relational.common
{
    public sealed class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (IsNotCommand())
            {
                return await next();
            }

            using(var transactionScope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                var response = await next();

                await _unitOfWork.CompleteAsync();

                transactionScope.Complete();

                return response;
            }
        }

        private static bool IsNotCommand()
        {
            return !typeof(TRequest).Name.EndsWith("Command");
        }
    }
}
