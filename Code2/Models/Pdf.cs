using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Code2.Models;

namespace Code2.Models
{
    public class Pdf
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string PdfTitle { get; set; } // Title of the PDF

        // Foreign Key for User
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } // Navigation property to the uploader

        // Additional Attributes
        public string ThumbnailPath { get; set; } // Path to the PDF's thumbnail image
        public float Rating { get; set; } // Rating of the PDF
        public int Views { get; set; } // Number of views
        public DateTime UploadedAt { get; set; } // Upload timestamp



    }
}
