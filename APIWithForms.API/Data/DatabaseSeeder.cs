using APIWithForms.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWithForms.API.Data
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        public DatabaseSeeder(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            _context.Database.EnsureCreated();
            if (!_context.UserColors.Any())
            {
                List<UserColor> colors = new List<UserColor>();
                colors.Add(FromHex("Red", "#FF2222"));
                colors.Add(FromHex("Green", "#22FF22"));
                colors.Add(FromHex("Blue", "#2222FF"));


                colors.Add(FromHex("Isabelline", "#f2efea"));
                colors.Add(FromHex("Coral", "#fc7753"));
                colors.Add(FromHex("Medium Turquoise", "#66d7d1"));
                colors.Add(FromHex("Arsenic", "#403d58"));
                colors.Add(FromHex("Straw", "#dbd56e"));


                await _context.UserColors.AddRangeAsync(colors);
                await _context.SaveChangesAsync();
            }
        }

        private UserColor FromHex(string name, string hex)
        {
            hex = hex.TrimStart('#');

            if (hex.Length == 6) hex = "FF" + hex;

            System.Drawing.Color c = System.Drawing.Color.FromArgb(Int32.Parse(hex, System.Globalization.NumberStyles.HexNumber));

            UserColor newColor = new UserColor
            {
                Name = name,
                Alpha = c.A,
                Red = c.R,
                Green = c.G,
                Blue = c.B
            };

            return newColor;
        }
    }
}
