using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class SizeBLL
    {
        private SizeDAL sizeDAL = new SizeDAL();

        public List<Size> GetAllSizes()
        {
            return sizeDAL.GetAllSizes();
        }

        public Size GetSizeById(int id)
        {
            return sizeDAL.GetSizeById(id);
        }

        public bool AddSize(Size size)
        {
            ValidateField(!string.IsNullOrWhiteSpace(size.size_name), "Tên kích cỡ không được để trống.");
            return sizeDAL.InsertSize(size);
        }

        public bool EditSize(Size size)
        {
            ValidateField(!string.IsNullOrWhiteSpace(size.size_name), "Tên kích cỡ không được để trống.");
            return sizeDAL.UpdateSize(size);
        }

        public bool RemoveSize(int id)
        {
            return sizeDAL.DeleteSize(id);
        }

        private void ValidateField(bool isValid, string errorMessage)
        {
            if (!isValid)
                throw new Exception(errorMessage);
        }
    }
}
