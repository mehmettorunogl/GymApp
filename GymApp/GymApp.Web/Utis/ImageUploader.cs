namespace GymApp.Web.Utis
{
	public static class ImageUploader
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="IWebHostEnvironment">bulundugu sunucu zerinde dosya ve resimlerle işlem yapabilemmizi sağlıyor</param>
		/// <param name="img"></param>
		/// <returns></returns>

		/// <summary>
		/// 
		/// </summary>
		/// <param name="IFormFile">bulundugu dosyayı almamızı sağlıyor</param>
		/// <param name="img"></param>
		/// <returns></returns>
		/// 


		public static async Task<string> UploadImageAsync(IWebHostEnvironment hostEnvironment, IFormFile img)
		{
			string wwwRootPath = hostEnvironment.WebRootPath;
			string fileName = FileNameControl(Path
				.GetFileNameWithoutExtension(img.FileName));
			string extension = Path.GetExtension(img.FileName);
			fileName = fileName + DateTime.Now.ToString("yyyyMMddhhmmss") + extension;

			string path = Path.Combine(wwwRootPath + "/ImageUpload/", fileName);

			using (var fileStream = new FileStream(path, FileMode.Create))
			{
				await img.CopyToAsync(fileStream);
			}
			//fileStream bilgisayardan bilgisayara senkron ediyor
			return "/ImageUpload/" + fileName;
		}

		public static async Task<bool> DeleteImageAsync(IWebHostEnvironment hostEnvironment, string? path)
		{
			try
			{
				if (!string.IsNullOrEmpty(path))
				{
					string wwwRootPath = hostEnvironment.WebRootPath;
					string filePath = Path.Combine(wwwRootPath + path);
					FileInfo fileInfo = new FileInfo(filePath);
					if (fileInfo.Exists)
					{
						fileInfo.Delete();
						return true;
					}
				}

				return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		private static string FileNameControl(string filename)
		{
			filename.Replace("ş", "s");
			filename.Replace("ç", "c");
			filename.Replace("ü", "u");
			filename.Replace("ğ", "g");
			filename.Replace("ı", "i");
			filename.Replace("ö", "o");
			filename.Replace("Ş", "S");
			filename.Replace("Ç", "C");
			filename.Replace("Ü", "U");
			filename.Replace("Ğ", "G");
			filename.Replace("İ", "I");
			filename.Replace("Ö", "O");
			filename.Replace("-", "");
			filename.Replace("_", "");
			filename.Replace("?", "");
			filename.Replace("!", "");
			filename.Replace("#", "");
			filename.Replace("*", "");
			filename.Replace("/", "");
			filename.Replace("&", "");
			filename.Replace("%", "");
			filename.Replace("$", "");
			filename.Replace("^", "");
			filename.Replace("{", "");
			filename.Replace("}", "");
			filename.Replace("[", "");
			filename.Replace("]", "");
			filename.Replace(")", "");
			filename.Replace("(", "");
			filename.Replace(":", "");

			return filename;
		}
	}
}
