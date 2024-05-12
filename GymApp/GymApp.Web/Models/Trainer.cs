using System.ComponentModel.DataAnnotations;

namespace GymApp.Web.Models {
    public class Trainer : BaseEntity {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Adı Soyadı Alanını Doldurun"), 
         StringLength(64, ErrorMessage ="Bu alan en fazla 64 karakter içermelidir"),
         MinLength(3, ErrorMessage ="Bu Alan en az 3 karakter içermelidir")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "E Posta Alanını Doldurun"),
        StringLength(100, ErrorMessage = "Bu alan en fazla 100 karakter içermelidir"),
        MinLength(3, ErrorMessage = "Bu Alan en az 3 karakter içermelidir")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon Alanını Doldurun"),
        StringLength(13, ErrorMessage = "Bu alan en fazla 13 karakter içermelidir"),
        MinLength(10, ErrorMessage = "Bu Alan en az 10 karakter içermelidir")]
        public string Phone { get; set; }

        
    }
}
