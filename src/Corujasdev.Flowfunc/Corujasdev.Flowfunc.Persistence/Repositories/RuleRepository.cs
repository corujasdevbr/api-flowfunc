using Corujasdev.Flowfunc.Application.Repositories;
using Corujasdev.Flowfunc.Domain.Entities;
using Corujasdev.Flowfunc.Persistence.Context;

namespace Corujasdev.Flowfunc.Persistence.Repositories;

public class RuleRepository : BaseRepository<Rule>, IRuleRepository
{
    public RuleRepository(DataContext context) : base(context)
    {
    }
}