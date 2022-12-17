using System;

namespace QIIK.DTO
{
    public class TriangleRequestDTO
    {
        public int Side1 { get; set; }
        public int Side2 { get; set; }
        public int Side3 { get; set; }
    }
    public class TriangleResponseDTO
    {
        public string Category { get; set; }
    }
}
