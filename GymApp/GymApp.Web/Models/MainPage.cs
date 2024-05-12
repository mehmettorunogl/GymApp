using System.ComponentModel.DataAnnotations;

namespace GymApp.Web.Models {
    public class MainPage : BaseEntity {
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string? ImageUrl { get; set; }
        [Required, StringLength(128)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required, StringLength(128)]
        public string AboutTitle { get; set; }

        [Required]
        public string AboutDescription { get; set;}

        [StringLength(128)]
        public string? AboutImageUrl1 { get; set; }

        [StringLength(128)]
        public string? AboutImageUrl2{ get; set; }

        [StringLength(128)]
        public string? AboutImageUrl3 { get; set; }

        [StringLength(128)]
        public string AboutRedirectUrl { get; set; }

        public string SliderImageUrl1 { get; set; }

        public string SliderImageUrl2 { get; set; }

        public string SliderImageUrl3 { get; set; }

        public string SliderRedirectUrl1 { get; set; }

        public string SliderRedirectUrl2 { get; set; }

        public string SliderRedirectUrl3 { get; set; }

        public string SliderTittle1 { get; set; }

        public string SliderTittle2 { get; set; }

        public string SliderTittle3 { get; set; }

        public string SliderSubTittle1 { get; set; }

        public string SliderSubTittle2 { get; set; }

        public string SliderSubTittle3 { get; set; }


    }
}
