using System;
using System.ComponentModel.DataAnnotations;

namespace QIIK.DTO
{
    public class ReverseRequestDTO
    {
        [Required]
        public string Value { get; set; }
    }
    public class ReverseResponseDTO
    {
        public string Value { get; set; }
    }
}
