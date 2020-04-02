using APIWithForms.Entities;
using APIWithForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWithForms.API.Extensions
{
    public static class UserColorExtensions
    {
        public static UserColorModel ToModel(this UserColor color)
        {
            return new UserColorModel
            {
                Id = color.Id,
                Name = color.Name,
                Alpha = color.Alpha,
                Red = color.Red,
                Green = color.Green,
                Blue = color.Blue,
            };
        }

        public static UserColor ToEntity(this UserColorModel model)
        {
            return new UserColor
            {
                Name = model.Name,
                Alpha = model.Alpha,
                Red = model.Red,
                Green = model.Green,
                Blue = model.Blue,
            };
        }
    }
}
