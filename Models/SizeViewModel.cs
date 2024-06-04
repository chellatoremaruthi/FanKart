using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace FanKart.Models
{
    public class SizeViewModel
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }

        public string SizeDescription { get; set; }
    }
}
