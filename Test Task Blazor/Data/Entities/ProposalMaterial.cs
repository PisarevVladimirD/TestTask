using System.ComponentModel.DataAnnotations;

namespace Test_Task_Blazor.Data.Entities
{
    public enum MaterialStatus : byte
    {
        Created = 0,
        Deleted = 1,
    }

    public class ProposalMaterial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public MaterialStatus Status { get; set; }

        public string TextStatus => Status.ToString();
        [Required]
        public string MaterialName { get; set; }

        [Required, MaxLength (10)]
        public string MaterialCode { get; set; }

        public int Quantity { get; set; } // ограничить 1

        [Required]
        public string? Comment { get; set; }

        [Required]
        public int ProposalId { get; set; }
    }
}
