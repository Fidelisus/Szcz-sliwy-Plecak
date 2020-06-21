using System.ComponentModel.DataAnnotations;

namespace SzczesliwyPlecak.Models
{
    public class ProductForm : Product
    {
        [Range(1, int.MaxValue, ErrorMessage = "Podaj wartość większą od 0")]
        public int Quantity { get; set; }
    }
}
