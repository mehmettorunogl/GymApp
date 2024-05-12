using System.ComponentModel.DataAnnotations;

namespace GymApp.Web.Models {
    public class Category : BaseEntity {
        public Category() 
        {
            this.Courses = new HashSet<Course>();
            //default collection olusturuyor içerisinde aldığı değeri tekrar almaması eşsiz bir liste olmasını sağlıyor
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Başlığı Giriniz"),
         StringLength(64, ErrorMessage = "Bu alan en fazla 64 karakter içermelidir"),
         MinLength(3, ErrorMessage = "Bu Alan en az 3 karakter içermelidir")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen Açıklamayı giriniz"),
         StringLength(64, ErrorMessage = "Bu alan en fazla 64 karakter içermelidir"),
         MinLength(3, ErrorMessage = "Bu Alan en az 3 karakter içermelidir")]
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
