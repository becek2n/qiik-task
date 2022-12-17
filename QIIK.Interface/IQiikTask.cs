using System;
using System.Threading.Tasks;
using QIIK.DTO;

namespace QIIK.Interface
{
    public interface IQiikTask
    {
        Task<TriangleResponseDTO> GetTriangle(TriangleRequestDTO request);
        Task<FibonacciResponseDTO> GetFibonacci(FibonacciRequestDTO request);
        Task<ReverseResponseDTO> GetReverse(ReverseRequestDTO request);
        Task<HashingResponseDTO> GetHashing(HashingRequestDTO request);

    }
}
