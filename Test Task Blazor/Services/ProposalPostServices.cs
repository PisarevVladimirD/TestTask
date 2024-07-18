using Microsoft.EntityFrameworkCore;

namespace Test_Task_Blazor.Services
{
	public class ProposalPostServices
	{
		private readonly PurchaseContext _proposalContext;
		public ProposalPostServices(PurchaseContext proposalContext)
		{
			_proposalContext = proposalContext;
		}
		public async Task<IEnumerable<Proposal>> GetProposalAsync() =>
			await _proposalContext.Proposals
									.AsNoTracking()
									.ToListAsync();
	}
}
