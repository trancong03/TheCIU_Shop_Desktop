﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using DTO;

namespace DAL
{
    public class ColorDAL
    {
        private QuanLyShopDataContext db = new QuanLyShopDataContext();

        public List<Color> GetAllColors()
        {
            return db.Colors.ToList();
        }

        public Color GetColorById(int id)
        {
            return db.Colors.SingleOrDefault(c => c.color_id == id);
        }
        public int GetColorIdByName(string colorName)
        {
            var color = db.Colors.FirstOrDefault(c => c.color_name.Equals(colorName, StringComparison.OrdinalIgnoreCase));
            return color?.color_id ?? 0; 
        }

        public bool InsertColor(Color color)
        {
            try
            {
                db.Colors.InsertOnSubmit(color);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateColor(Color color)
        {
            try
            {
                var existingColor = db.Colors.SingleOrDefault(c => c.color_id == color.color_id);
                if (existingColor != null)
                {
                    existingColor.color_name = color.color_name;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteColor(int id)
        {
            try
            {
                var color = db.Colors.SingleOrDefault(c => c.color_id == id);
                if (color != null)
                {
                    db.Colors.DeleteOnSubmit(color);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
