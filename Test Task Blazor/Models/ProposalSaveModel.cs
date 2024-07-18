using System.ComponentModel.DataAnnotations;

namespace Test_Task_Blazor.Models
{
	public class ProposalSaveModel
	{
		public class Proposal
		{
			public int Id { get; set; }

			[Required]
			public ProposalStatus Status { get; set; }


			[Required]
			public string Department { get; set; }

			[Required]
			public string Author { get; set; }

			public Proposal ToProposal() =>
				new()
				{
					Id = Id,
					Status = Status,
					Department = Department,
					Author = Author
				};
		}
	}
}

