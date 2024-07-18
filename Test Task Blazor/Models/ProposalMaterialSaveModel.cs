using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Test_Task_Blazor.Models
{
	public class ProposalMaterialSaveModel
	{
		public int Id { get; set; }

		[Required]
		public string MaterialName { get; set; }

		[Required, MaxLength(10)]
		public string MaterialCode { get; set; }

		public int Quantity { get; set; } // ограничить 1

		[Required]
		public string? Comment { get; set; }

		public ProposalMaterial ToProposalMaterialEntyty() =>
			new()
			{
				Id = Id,
				MaterialName = MaterialName,
				MaterialCode = MaterialCode,
				Quantity = Quantity,
				Comment = Comment
			};

		public ProposalMaterial Merge(ProposalMaterial entyty)
		{
			entyty.Id = Id;
			entyty.MaterialName = MaterialName;
			entyty.MaterialCode = MaterialCode;
			entyty.Quantity = Quantity;
			entyty.Comment = Comment;
			return entyty;
		}
		public static Expression<Func<ProposalMaterial, ProposalMaterialSaveModel>> Selector =>
			bp => new ProposalMaterialSaveModel
			{
				Id = bp.Id,
				MaterialName = bp.MaterialName,
				MaterialCode = bp.MaterialCode,
				Quantity = bp.Quantity,
				Comment = bp.Comment
			};
	}
}

