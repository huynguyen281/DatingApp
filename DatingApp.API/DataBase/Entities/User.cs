using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Database.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(32)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]        
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(128)]  
        public string KnowAs { get; set; }

        [StringLength(6)] 
        public string Gender { get; set; }

        [StringLength(256)]  
        public string Introduction { get; set; }
        
        [StringLength(128)]  
        public string City { get; set; }

        [StringLength(512)]  
        public string Avatar { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}