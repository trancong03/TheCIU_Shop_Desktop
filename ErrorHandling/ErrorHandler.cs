using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling
{
    public static class ErrorHandler
    {
        // Phương thức xử lý và phân loại các loại ngoại lệ khác nhau
        public static void HandleException(Exception ex)
        {
            if (ex is ValidationException)
            {
                HandleValidationException((ValidationException)ex);
            }
            else if (ex is DatabaseException)
            {
                HandleDatabaseException((DatabaseException)ex);
            }
            else if (ex is FileException)
            {
                HandleFileException((FileException)ex);
            }
            else
            {
                HandleGeneralException(ex);
            }
        }

        // Phương thức xử lý ngoại lệ Validation
        private static void HandleValidationException(ValidationException ex)
        {
            LogError(ex); // Ghi log (nếu cần)
            ShowErrorMessage($"Lỗi xác thực: {ex.Message}");
        }

        // Phương thức xử lý ngoại lệ Database
        private static void HandleDatabaseException(DatabaseException ex)
        {
            LogError(ex); // Ghi log (nếu cần)
            ShowErrorMessage($"Lỗi cơ sở dữ liệu: {ex.Message}");
        }

        // Phương thức xử lý ngoại lệ File
        private static void HandleFileException(FileException ex)
        {
            LogError(ex); // Ghi log (nếu cần)
            ShowErrorMessage($"Lỗi tệp tin: {ex.Message}");
        }

        // Phương thức xử lý các ngoại lệ chung
        private static void HandleGeneralException(Exception ex)
        {
            LogError(ex); // Ghi log (nếu cần)
            ShowErrorMessage($"Lỗi hệ thống: {ex.Message}");
        }

        // Phương thức ghi log lỗi (ghi vào file hoặc cơ sở dữ liệu)
        private static void LogError(Exception ex)
        {
            // Ví dụ: Ghi vào file text đơn giản (có thể mở rộng để ghi vào cơ sở dữ liệu)
            try
            {
                string message = $"{DateTime.Now}: {ex.Message}\n{ex.StackTrace}\n";
                System.IO.File.AppendAllText("error_log.txt", message);
            }
            catch (Exception logEx)
            {
                Console.WriteLine($"Ghi log lỗi thất bại: {logEx.Message}");
            }
        }

        // Phương thức hiển thị thông báo lỗi thân thiện với người dùng
        private static void ShowErrorMessage(string message)
        {
            // Trong Console App
            Console.WriteLine(message);

            // Nếu bạn dùng Windows Forms hoặc WPF, có thể sử dụng MessageBox
            // System.Windows.Forms.MessageBox.Show(message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}

