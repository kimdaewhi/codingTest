using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alghrithm
{
    class SearchAlgorithm
    {
        private static Stopwatch stopwatch = new Stopwatch();

        public SearchAlgorithm() 
        {
            
        }


        /// <summary>
        /// [선형 탐색 알고리즘]
        /// 처음부터 끝까지 데이터셋을 순회하며 데이터 찾기
        /// </summary>
        /// <returns></returns>
        public int LinearSearch(List<int> numbers, int target, ref string time)
        {
            stopwatch.Reset();
            int rtnVal = -1;

            stopwatch.Start();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == target)
                    rtnVal = target;
            }
            stopwatch.Stop();
            time = stopwatch.Elapsed.ToString();
            stopwatch.Reset();

            return rtnVal;
        }

        /// <summary>
        /// [이진탐색 알고리즘]
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int BinarySearch(List<int> numbers, int target, ref string time)
        {
            stopwatch.Reset();

            int rtnVal = -1;
            int left = 0;
            int right = numbers.Count - 1;

            stopwatch.Start();

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (numbers[mid] == target)
                {
                    rtnVal = numbers[mid];
                    stopwatch.Stop();
                    time = stopwatch.Elapsed.ToString();
                    return rtnVal;
                }
                if (numbers[mid] < target)
                {
                    left = mid + 1;
                }
                // target이 중앙값보다 왼쪽에 있는 경우
                if (numbers[mid] > target)
                {
                    right = mid - 1;
                }
            }
            rtnVal = -1;
            stopwatch.Stop();
            time = stopwatch.Elapsed.ToString();

            return rtnVal;
        }

        /// <summary>
        /// [이진탐색 알고리즘]
        /// 1. 검색하려는 DataSet을 중간지점을 기준으로 Data를 반으로 나눔
        /// 2. target data가 중간지점의 왼/오른쪽에 있는지 탐색
        /// 3. 없다면 다시 왼/오른쪽의 Data를 반으로 나눔 >>> target data 찾을 때까지 반복
        /// ※ 데이터의 정렬이 중요하기 때문에 정렬 알고리즘과 묶어서 사용함.
        /// </summary>
        /// <returns></returns>
        public int BinarySearchPackage(List<int> numbers, int target, ref string time)
        {
            stopwatch.Reset();
            int rtnVal = -1;

            stopwatch.Start();
            int index = numbers.BinarySearch(target);           // 리스트의 BinarySearch를 이용하면 target 요소의 index를 반환, target이 dataset 안에 없다면 (max index + 1) * -1 반환
            if (!(index < 0))
                rtnVal = numbers[index];
            else
                rtnVal = -1;
            time = stopwatch.Elapsed.ToString();
            stopwatch.Stop();

            return rtnVal;
        }


        /// <summary>
        /// [해시 탐색 알고리즘]
        /// </summary>
        /// <returns></returns>
        public string HashSearch()
        {
            string value = string.Empty;
            Dictionary<string, string> hashTable = new Dictionary<string, string>();

            // 데이터 추가
            hashTable.Add("key1", "value1");
            hashTable.Add("key2", "value2");
            hashTable.Add("key3", "value3");

            // 데이터 검색
            string keyToSearch = "key2";
            if (hashTable.ContainsKey(keyToSearch))
            {
                value = hashTable[keyToSearch];
            }

            return value;
        }

    }
}
