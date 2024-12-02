using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Ultis
{
    public static class PrintHelper
    {
        public static void Print(DataGridView dataGridView)
        {
            try
            {
                if (dataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += (s, e) =>
                {
                    int x = 10;
                    int y = 10;
                    int cellHeight = 25;

                    // Tiêu đề
                    e.Graphics.DrawString("Danh sách", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, x, y);
                    y += 40;

                    // Tiêu đề cột
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        e.Graphics.DrawString(dataGridView.Columns[i].HeaderText, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, x, y);
                        x += 100; // Điều chỉnh độ rộng cột
                    }
                    x = 10;
                    y += cellHeight;

                    // Dữ liệu
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            e.Graphics.DrawString(dataGridView.Rows[i].Cells[j].Value?.ToString(), new Font("Arial", 10), Brushes.Black, x, y);
                            x += 100; // Điều chỉnh độ rộng cột
                        }
                        x = 10;
                        y += cellHeight;
                    }
                };

                // Hiển thị hộp thoại Print Preview
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
                {
                    Document = printDocument,
                    Width = 800,
                    Height = 600
                };

                if (printPreviewDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
