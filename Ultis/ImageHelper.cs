using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Ultis
{
    public static class ImageHelper
    {
        public static void LoadImageFromLocalOrURL(PictureBox pictureBox, string imagePathOrUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(imagePathOrUrl))
                {
                    throw new ArgumentException("Đường dẫn hoặc URL không hợp lệ hoặc trống.");
                }

                if (File.Exists(imagePathOrUrl))
                {
                    // Nếu đường dẫn là file cục bộ
                    ValidateAndLoadImageFromLocal(pictureBox, imagePathOrUrl);
                }
                else
                {
                    // Nếu là URL
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] imageData = webClient.DownloadData(imagePathOrUrl);

                        if (imageData == null || imageData.Length == 0)
                        {
                            throw new InvalidDataException("Không thể tải ảnh từ URL hoặc dữ liệu rỗng.");
                        }

                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            ValidateAndLoadImageFromStream(pictureBox, ms);
                        }
                    }
                }
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetDefaultImage(pictureBox);
            }
            catch (WebException webEx)
            {
                MessageBox.Show($"Không thể kết nối tới URL: {webEx.Message}", "Lỗi mạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetDefaultImage(pictureBox);
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Ảnh bị lỗi hoặc không hợp lệ. Vui lòng kiểm tra file.", "Lỗi bộ nhớ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetDefaultImage(pictureBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetDefaultImage(pictureBox);
            }
        }

        private static void ValidateAndLoadImageFromLocal(PictureBox pictureBox, string localPath)
        {
            try
            {
                using (var img = Image.FromFile(localPath))
                {
                    LoadResizedImage(pictureBox, img);
                }
            }
            catch (OutOfMemoryException)
            {
                throw new OutOfMemoryException("File không phải ảnh hợp lệ hoặc bị lỗi.");
            }
        }

        private static void ValidateAndLoadImageFromStream(PictureBox pictureBox, MemoryStream ms)
        {
            try
            {
                using (var img = Image.FromStream(ms))
                {
                    LoadResizedImage(pictureBox, img);
                }
            }
            catch (OutOfMemoryException)
            {
                throw new OutOfMemoryException("Dữ liệu từ stream không phải ảnh hợp lệ.");
            }
        }

        private static void LoadResizedImage(PictureBox pictureBox, Image img)
        {
            // Giới hạn kích thước ảnh để giảm tình trạng OutOfMemoryException
            const int maxWidth = 1024; // Kích thước tối đa chiều rộng
            const int maxHeight = 1024; // Kích thước tối đa chiều cao

            // Kiểm tra nếu ảnh lớn hơn kích thước tối đa thì resize
            if (img.Width > maxWidth || img.Height > maxHeight)
            {
                using (var resizedImage = ResizeImage(img, maxWidth, maxHeight))
                {
                    pictureBox.Image?.Dispose();
                    pictureBox.Image = new Bitmap(resizedImage);
                }
            }
            else
            {
                pictureBox.Image?.Dispose();
                pictureBox.Image = new Bitmap(img); // Gán ảnh trực tiếp nếu kích thước nhỏ
            }

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private static Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            int newWidth = image.Width;
            int newHeight = image.Height;

            // Tính toán kích thước mới
            if (image.Width > maxWidth || image.Height > maxHeight)
            {
                float ratioX = (float)maxWidth / image.Width;
                float ratioY = (float)maxHeight / image.Height;
                float ratio = Math.Min(ratioX, ratioY);

                newWidth = (int)(image.Width * ratio);
                newHeight = (int)(image.Height * ratio);
            }

            // Tạo ảnh mới với kích thước đã resize
            var resizedImage = new Bitmap(newWidth, newHeight);
            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        private static void SetDefaultImage(PictureBox pictureBox)
        {
            pictureBox.Image?.Dispose();
            pictureBox.Image = Properties.Resources.DefaultImage; // Hiển thị ảnh mặc định
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
