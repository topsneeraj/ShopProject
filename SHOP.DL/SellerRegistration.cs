using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SHOP.DL
{
    public class SellerRegistration
    {
        /// <summary>
        /// primary key column
        /// </summary>
        [Key]
        public int seller_id { get; set; }

        /// <summary>
        ///  seller Name 
        /// </summary>
        [Required]
        [Column("seller_name",TypeName = "Varchar")]
        public string seller_name { get; set; }

        /// <summary>
        ///  seller email Id
        /// </summary>
        [Required]
        [Column("seller_email_id",TypeName ="Varchar")]
        public string seller_email_id { get; set; }

        /// <summary>
        ///  seller Mobile Number
        /// </summary>
        [Required]
        [Column("seller_Mobile_no",TypeName ="Varchar")]
        public string seller_Mobile_no { get; set; }

        /// <summary>
        /// seller Password
        /// </summary>
        [Required]
        [Column("seller_password",TypeName ="varchar")]
        
        public string seller_password { get; set; }
        /// <summary>
        ///  seller address
        /// </summary>
        [Required]
        [Column("seller_address",TypeName ="Varchar")]
        
        public string seller_address { get; set; }
        /// <summary>
        /// seller status
        /// </summary>
        [Required]
        [Column("seller_status",TypeName ="Varchar")]
        public string seller_status { get; set; }

        /// <summary>
        /// seller auto generated Registration date
        /// </summary>
        
        
        public DateTime seller_reg_date { get; set; }
        /// <summary>
        ///  seller Update date 
        /// </summary>
        [Required]
        [Column("seller_update_date",TypeName ="Date")]
        public DateTime seller_update_date { get; set; }

       

    }
}
