using System.ComponentModel.DataAnnotations;

namespace GymApp.Web.Models {
    public class Contact : BaseEntity {
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string? ImageUrl { get; set; }

		[Required(ErrorMessage = "Lütfen Başlığı Giriniz"),
		 StringLength(64, ErrorMessage = "Bu alan en fazla 64 karakter içermelidir"),
		 MinLength(3, ErrorMessage = "Bu Alan en az 3 karakter içermelidir")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Lütfen Açıklama Alanını Doldurun"),
		 StringLength(100, ErrorMessage = "Bu alan en fazla 100 karakter içermelidir"),
		 MinLength(3, ErrorMessage = "Bu Alan en az 3 karakter içermelidir")]
		public string Description { get; set; }

        [StringLength(128)]
        public string InstagramRedirectUrl { get; set; }

        [StringLength(128)]
        public string LinkedinRedirectUrl { get; set; }

        [StringLength(128)]
        public string XRedirectUrl { get; set; }

        [StringLength(128)]
        public string ContactTitle { get; set; }

        [StringLength(128)]
        public string ContactDescription { get; set; }

        [StringLength(128)]
        public string ContactImageUrl { get; set; }

        [StringLength(13)]
        public string ContactPhone { get; set; }

        [StringLength(64)]
        public string ContactEmail { get; set; }

        [Required]
        public string ContactMap { get; set; }

        [StringLength(128)]
        public string ContactFacebookRedirectUrl { get; set; }

        [StringLength(128)]
        public string ContactXRedirectUrl { get; set; }

        [StringLength(128)]
        public string ContactInstagramRedirectUrl { get; set; }

        [StringLength(128)]
        public string ContactLinkedinRedirectUrl { get; set; }

    }
}
