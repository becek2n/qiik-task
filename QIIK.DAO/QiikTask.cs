using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using QIIK.DTO;
using QIIK.Interface;

namespace QIIK.DAO
{
    public class QiikTask : IQiikTask
    {
        private async Task<int[]> Fibonacci(int number)
        {
            int[] fibo = new int[number];
            fibo[0] = 0;
            fibo[1] = 1;
            for (int i = 2; i < number; i++)
            {
                fibo[i] = await Task.Run(() => { return fibo[i - 2] + fibo[i - 1]; }); 
            }
            return fibo;
        }
        public async Task<FibonacciResponseDTO> GetFibonacci(FibonacciRequestDTO request)
        {
            FibonacciResponseDTO response = new FibonacciResponseDTO();
            var fibos = await Fibonacci(request.LengthSeries);
            response.Values = fibos;
            
            return response;
        }

        public async Task<HashingResponseDTO> GetHashing(HashingRequestDTO request)
        {
            HashingResponseDTO response = new HashingResponseDTO();

            using (var md5 = MD5.Create())
            {
                StringBuilder hash = new StringBuilder();
                MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
                byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(request.Value));
                for (int i = 0; i < bytes.Length; i++)
                {
                    hash.Append(bytes[i].ToString("x2"));
                }
                
                response.Value = hash.ToString();
                response.Algorithm = "MD5";
            }

            return response;
        }

        public async Task<ReverseResponseDTO> GetReverse(ReverseRequestDTO request)
        {
            ReverseResponseDTO response = new ReverseResponseDTO();

            char[] charArray = request.Value.ToCharArray();
            Array.Reverse(charArray);
            response.Value = new string(charArray);

            return response;
        }

        public async Task<TriangleResponseDTO> GetTriangle(TriangleRequestDTO request)
        {
            TriangleResponseDTO response = new TriangleResponseDTO();

            //triangle category classification
            //Equilateral triangle: All three sides are equal.
            //Isosceles triangle: All two sides are equal.
            //Scalene triangle: No sides are equal.
            if (request.Side1 == request.Side2 && request.Side2 == request.Side3)
                response.Category = "The Triangle is Equilateral";
            else if (request.Side1 == request.Side2 || request.Side2 == request.Side3 || request.Side3 == request.Side1)
                response.Category = "The Triangle is Isosceles";
            else
                response.Category = "The Triangle is Scalene";

            return response;
        }


        
    }
}
