using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace malshetwi_Project3_SDA.LMS.Models
{
    public class Item 
    {
        [Key]
        public int ItemID { get; set; }

        [Required(ErrorMessage ="insert pic name")]
        public string ItemPicURL { get; set; }

        [Required(ErrorMessage = "insert Item Name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "insert Item Bio")]
        public string ItemBio { get; set; }

        [Required(ErrorMessage = "insert Item Price")]
        public int Price { get; set; }

        //Relations
        public List<Order> Order { get; set; }
    }
}
