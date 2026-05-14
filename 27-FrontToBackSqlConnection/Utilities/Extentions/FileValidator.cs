using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;

namespace _27_FrontToBackSqlConnection.Utilities.Extentions
{
    public static class FileValidator
    {
        //!slider.Photo.ContentType.Contains("image/")
        public static bool CheckFileType(this IFormFile file, string type)
        {
            if (file.ContentType.Contains(type))
            {
                return true;
            }
            return false;
        }

        public static bool CheckFileSize(this IFormFile file, FileSize fileSize, decimal value)
        {
            switch (fileSize)
            {
                case FileSize.KB:
                    return file.Length <= value * 1024;
                case FileSize.MB:
                    return file.Length <= value * 1024 * 1024;
                case FileSize.GB:
                    return file.Length <= value * 1024 * 1024 * 1024;
            }
            return false;
        }

        public static async Task<string> CreateFile(this IFormFile file, params string[] roots)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            string filePath = string.Empty;

            foreach (var root in roots)
            {
                filePath = Path.Combine(filePath, root);
            }

            filePath = Path.Combine(filePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public static void DeleteFile(this string fileName , params string[] roots)
        {
            string path = string.Empty;

            foreach (var root in roots)
            {
                path = Path.Combine(path, root);
            }

            path = Path.Combine(path, fileName);

            File.Delete(path);
        }
    }
}
