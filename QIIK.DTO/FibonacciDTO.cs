using System;

namespace QIIK.DTO
{
    public class FibonacciRequestDTO
    {
        public int LengthSeries { get; set; }
    }
    public class FibonacciResponseDTO
    {
        public int[] Values { get; set; }
    }
}
