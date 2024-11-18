using DAL;
using DTO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ColorBLL
    {
        private ColorDAL colorDAL = new ColorDAL();

        public List<Color> GetAllColors()
        {
            return colorDAL.GetAllColors();
        }

        public Color GetColorById(int id)
        {
            return colorDAL.GetColorById(id);
        }

        public bool AddColor(Color color)
        {
            ValidateField(!string.IsNullOrWhiteSpace(color.color_name), "Tên màu không được để trống.");
            return colorDAL.InsertColor(color);
        }

        public bool EditColor(Color color)
        {
            ValidateField(!string.IsNullOrWhiteSpace(color.color_name), "Tên màu không được để trống.");
            return colorDAL.UpdateColor(color);
        }

        public bool RemoveColor(int id)
        {
            return colorDAL.DeleteColor(id);
        }

        private void ValidateField(bool isValid, string errorMessage)
        {
            if (!isValid)
                throw new Exception(errorMessage);
        }
    }
}
