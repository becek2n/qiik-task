using System;
using System.ComponentModel.DataAnnotations;

namespace QIIK.DTO
{
    public class HashingRequestDTO
    {
        [Required]
        public string Value { get; set; }
    }
    public class HashingResponseDTO
    {
        public string Algorithm { get ; set; }
        public string Value { get; set; }
    }
}
