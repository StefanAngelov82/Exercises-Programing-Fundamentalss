﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Album
    {
       
        public Album()
        {
            Songs = new List<Song>();            
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime ReleaseDate { get; set; }
        

        public decimal Price
        {
            get 
            {
                if (Songs.Any()) 
                    return Songs.Sum(s => s.Price);

                else
                    return 0;               
            }           
        }

        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }
        public virtual Producer? Producer { get; set; } 

        public virtual ICollection<Song> Songs { get; set; }
    }
}
