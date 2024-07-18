using Microsoft.EntityFrameworkCore;

namespace Test_Task_Blazor.Services
{
	public class MaterialPostServices
	{
		private readonly PurchaseContext _proposalMaterialContext;
		public MaterialPostServices(PurchaseContext proposalMaterialContext) 
		{
			_proposalMaterialContext = proposalMaterialContext;
		}

		public async Task<IEnumerable<ProposalMaterial>> GetProposalMaterialsAsync() =>
			await _proposalMaterialContext.ProposalMaterials
										   .AsNoTracking()
											.ToListAsync();
		public async Task<ProposalMaterialSaveModel?> GetProposalMaterialAsync(int proposalMaterialId) =>
			await _proposalMaterialContext.ProposalMaterials
											.Select(ProposalMaterialSaveModel.Selector)
										   .AsNoTracking()
											.FirstOrDefaultAsync(bp=>bp.Id== proposalMaterialId);
		public async Task SaveAsync(ProposalMaterialSaveModel proposalMaterial)
		{
			var entyty = proposalMaterial.ToProposalMaterialEntyty();
			if (entyty.Id == 0)
			{
				// Добавление нового материала
				

				await _proposalMaterialContext.AddAsync(entyty);
			}
			else
			{
				//Редактирование материала
				entyty = proposalMaterial.Merge(await _proposalMaterialContext.ProposalMaterials.FirstOrDefaultAsync(bp => bp.Id == proposalMaterial.Id));

			}
			//try
			//{
			//	if (await _proposalMaterialContext.SaveChangesAsync() > 0)
			//	{
			//		return MethodResult.Succes();
			//	}
			//	else
			//	{
			//		return MethodResult.Failure("Неизвесная ошибка при сохранении");
			//	}
				
			//}

			//catch (Exception ex)
			//{

			//	return MethodResult.Failure(ex.Message);
			//}
		}
	}
}
