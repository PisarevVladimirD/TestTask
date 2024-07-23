using System.ComponentModel.DataAnnotations;

namespace Test_Task_Blazor.Data.Entities
{
    public enum ProposalStatus : byte
    {
        Created = 0,
        Deleted = 1,
        Aproved= 2,
    }
    public class Proposal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProposalNumber { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public string FullNumber
        {
            get
            {
                return $"{CreationDate:yy}/{ProposalNumber:0000}";
            }
        }
        [Required]
        public ProposalStatus Status { get; set; }
        public string TextStatus
        {
            get
            {
                switch (Status)
                {
                    case ProposalStatus.Created:
                        return "Создана";
                    case ProposalStatus.Deleted:
                        return "Удалена";
                    case ProposalStatus.Aproved:
                        return "Утверждена";
                    default:
                        return "Создана";
                }
            }
        }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Author { get; set; }

       // public string FIO => Surname + " " + Name[0] + ". " + Patronymic[0] + ".";
    }
}
