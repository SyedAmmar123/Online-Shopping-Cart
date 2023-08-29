using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCart.Models
{
    public class ShareModel
    {
        //lskfjlsdlf-23kl45jl2=kj32lkj42l-sldjflk=343
        public ShareModel()
        {
            Id = Path.GetRandomFileName().Replace(".", ""); //kljslkffjsldj.sdk
            DbEntryTime = DateTime.UtcNow;
        }

        [ScaffoldColumn(false)]
        public string Id { get; set; }
        
        [ScaffoldColumn(false)]
        public DateTime DbEntryTime { get; set; }
    }
}
