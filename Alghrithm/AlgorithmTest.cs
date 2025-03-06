using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alghrithm
{
    class AlgorithmTest
    {
        private Random random = new Random();



        public AlgorithmTest()
        {
            int selected = 0;

            // Console.Clear();
            Console.WriteLine("++++++++++++++++++++++++++ Algorithm Test ++++++++++++++++++++++++++");
            Console.WriteLine("문제를 선택하세요. 뒤로 가려면 '0'을 입력하세요.");
            Console.WriteLine("[1] 라운드 로빈(R.R) 알고리즘");
            Console.WriteLine("[2] 중복 탐지");
            Console.WriteLine("[3] 순환 탐지 알고리즘");
            Console.WriteLine("[4] 벽돌 던지기 실험");
            Console.WriteLine("[5] 제곱수 판별");
            Console.WriteLine("[6] 괄호 여닫이 체크");

            bool validInput = true;
            while (validInput)
            {
                try
                {
                    Console.Write("입력 : ");
                    selected = Convert.ToInt32(Console.ReadLine());
                    if (selected == 0)
                    {
                        Console.Clear();
                        return;
                    }

                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    RunAlgoTest(selected);

                }
                catch (FormatException)
                {
                    Console.WriteLine("올바른 숫자를 입력하세요.");
                }
            }
        }


        private void RunAlgoTest(int selected)
        {
            Console.WriteLine("");

            int min = 0;
            int max = 0;

            switch (selected)
            {
                case 1:
                    #region ============================== 1. R.R Scheduling ==============================

                    Console.WriteLine("[Round Robin Scheduling]");
                    int processCnt = 10;
                    int quantum = 3;
                    List<Tuple<int, int>> quest1 = GenerateRandomProcesses(processCnt);

                    ProcessByRoundRobin(quantum, quest1);

                    #endregion ======================================================================

                    break;
                case 2:
                    #region ============================== 2. 중복 탐지 ==============================

                    Console.WriteLine("[중복 탐지 알고리즘]");
                    int size = 100;
                    min = 1;
                    max = 10;

                    int[] quest2 = GenerateRandomArray(size, min, max);

                    int answer2 = SearchDuplicate(quest2);

                    #endregion =====================================================================

                    break;
                case 3:
                    #region ============================== 3. 순환 탐지 알고리즘(Graph) ==============================

                    Console.WriteLine("[순환 탐지 알고리즘]");
                    int nodeCnt = 4;
                    Dictionary<int, List<int>> quest3 = GenerateRandomGraph(nodeCnt, false);

                    bool answer3 = CheckWithDFS(quest3);

                    #endregion ===============================================================================

                    break;
                case 4:
                    #region ============================== 4. 벽돌 던지기 테스트(탐색 알고리즘) ============================

                    Console.WriteLine("[깨지는 벽돌 실험]");
                    min = 1;
                    max = 100;
                    int maxTry = 2; // 최대 시도 횟수(벽돌 깨지면 하나씩 감소)
                    int quest4 = GenerateBreakingPoint(min, max);

                    int answer4 = FindBreakingPoint(min, max, quest4, maxTry);

                    #endregion ===================================================================

                    break;
                case 5:
                    #region ============================== 5.제곱수 판별 ==============================

                    Console.WriteLine("[제곱수 판별]");
                    int quest5 = GenerateRandomNumber();

                    bool answer5 = CheckSqrOfTwo(quest5);

                    #endregion ==========================================================================

                    break;

                case 6:
                    #region ====================== 괄호 여닫이(?) 체크 ======================

                    Console.WriteLine("[괄호 여닫이(?) 체크]");
                    string quest6 = GenerateRandomBrackets(10);

                    bool answer6 = CheckParentheses(quest6);
                    #endregion ========================================================

                    break;
                default:
                    break;
            }

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }



        #region ================================================== 문제 생성 ==================================================

        // 1️⃣ 랜덤 프로세스 생성 (PID, 실행 시간)
        List<Tuple<int, int>> GenerateRandomProcesses(int count)
        {
            List<Tuple<int, int>> processes = new List<Tuple<int, int>>();
            for (int i = 1; i <= count; i++)
            {
                processes.Add(new Tuple<int, int>(i, random.Next(1, 10))); // 실행 시간 1~10 랜덤
            }

            return processes;
        }

        // 2️⃣ 랜덤 숫자 배열 생성 (중복 많은 데이터 포함)
        int[] GenerateRandomArray(int size, int min, int max)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = random.Next(min, max + 1);
            }

            return arr;
        }

        // 3️⃣ 랜덤 그래프 생성 (5개 노드, 랜덤 엣지)
        Dictionary<int, List<int>> GenerateRandomGraph(int nodeCount)
        {
            var graph = new Dictionary<int, List<int>>();
            for (int i = 1; i <= nodeCount; i++)
            {
                graph[i] = new List<int>();
                int edges = random.Next(1, 3); // 각 노드당 1~2개의 랜덤 엣지 생성
                for (int j = 0; j < edges; j++)
                {
                    int to = random.Next(1, nodeCount + 1);
                    if (to != i && !graph[i].Contains(to))
                    {
                        graph[i].Add(to);
                    }
                }
            }

            return graph;
        }


        // 3-1. 순환 그래프 생성(테스트용), bCycle은 Method Overloading을 위해 추가한 파라미터(안씀) 
        // 노드 하나당 하나의 간선만 가지는 그래프 생성
        Dictionary<int, List<int>> GenerateRandomGraph(int nodeCount, bool bCycle)
        {
            var graph = new Dictionary<int, List<int>>();

            // 그래프 초기화 (각 노드에 대해 빈 리스트 할당)
            for (int i = 1; i <= nodeCount; i++)
            {
                graph[i] = new List<int>();
            }

            // 각 노드는 하나의 간선만 가지도록 설정
            for (int i = 1; i <= nodeCount; i++)
            {
                int to;
                do
                {
                    to = random.Next(1, nodeCount + 1); // 랜덤하게 연결할 노드 선택
                } while (to == i || graph.Values.Any(list => list.Contains(to))); // 중복 간선 방지

                graph[i].Add(to);
            }

            // 순환 그래프를 생성해야 하면 마지막 노드를 첫 번째 노드와 연결하여 사이클 생성
            if (bCycle)
            {
                graph[nodeCount].Clear(); // 마지막 노드의 기존 간선 제거
                graph[nodeCount].Add(1); // 마지막 노드를 첫 번째 노드와 연결
            }

            return graph;
        }




        // 4️⃣ 벽돌 깨지는 층 (랜덤 깨지는 층 생성)
        int GenerateBreakingPoint(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        // 5️⃣ 2의 제곱수 판별 (랜덤 숫자 생성)
        int GenerateRandomNumber()
        {
            return random.Next(1, 10000); // 1~10000 사이의 랜덤 숫자
        }

        // 6️⃣ 랜덤 괄호 문자열 생성
        string GenerateRandomBrackets(int length)
        {
            char[] brackets = { '(', ')', '{', '}', '[', ']' };
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = brackets[random.Next(0, brackets.Length)];
            }

            return new string(result);
        }

        #endregion ============================================================================================================


        // Tuple의 첫번째 요소는 PID(순서), 두번째 요소는 총 소요 시간
        private void ProcessByRoundRobin(int quantum, List<Tuple<int, int>> processes)
        {
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>(processes);
            int time = 0;
            int total = 0;

            while (queue.Count > 0) // A : Loop 실행
            {
                var process = queue.Dequeue(); // O(1) (큐 연산)
                int pid = process.Item1;
                int burst = process.Item2;
                // Console.WriteLine($"PID {pid} 실행 중...");

                if (burst > quantum)
                {
                    time += quantum;
                    burst -= quantum;
                    queue.Enqueue(new Tuple<int, int>(pid, burst)); // B : 큐 삽입 연산(O(1))
                }
                else
                {
                    time += burst;
                    total += time;
                    // Console.WriteLine($"PID {pid} 종료. 소요 시간 : {time}");
                }
            }

            Console.WriteLine($"전체 소요 시간 : {total}");
        }


        private int SearchDuplicate(int[] arr)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            foreach (var num in arr) // O(n)
            {
                if (count.ContainsKey(num))
                {
                    count[num]++;
                }
                else
                {
                    count[num] = 1;
                }
            }

            // 가장 많이 중복된 숫자 찾기
            return count.OrderByDescending(x => x.Value).First().Key;
        }



        // DFS(깊이 우선 탐색)로 순환 탐지
        private bool CheckWithDFS(Dictionary<int, List<int>> quest3) // O(V+E)
        {
            HashSet<int> visited = new HashSet<int>(); // 방문 노드 저장
            HashSet<int> recStack = new HashSet<int>(); // 현재 탐색중인 경로 저장(재귀 스택 역할)
            foreach (var node in quest3.Keys) // 그래프를 순회하며 순환 탐지
            {
                if (IsCyclicUtil(node, visited, recStack, quest3))
                {
                    return true; // 순환 발견되면 true 반환
                }
            }

            return false;
        }

        // 현재 노드의 방문 여부와 재귀 스택(recStack) 여부를 확인하여 순환 여부를 판단
        private bool IsCyclicUtil(int node, HashSet<int> visited, HashSet<int> recStack,
            Dictionary<int, List<int>> graph)
        {
            // 현재 노드가 이미 재귀 스택에 있으면 순환
            if (recStack.Contains(node))
            {
                return true;
            }

            // 현재 노드가 이미 방문한 노드면 순환 아님
            if (visited.Contains(node))
            {
                return false;
            }

            visited.Add(node); // 방문 처리
            recStack.Add(node); // 재귀 스택에 추가

            // 현재 노드의 이웃 노드를 순회하며 순환 여부 확인
            foreach (var neighbor in graph[node])
            {
                if (IsCyclicUtil(neighbor, visited, recStack, graph))
                {
                    return true;
                }
            }

            // 현재 노드의 이웃 노드를 모두 순회했는데 순환을 찾지 못한 경우
            recStack.Remove(node);
            return false;
        }


        /// <summary>
        /// BFS(위상 정렬)로 순환 탐지
        /// </summary>
        /// <param name="quest3"></param>
        /// <returns></returns>
        private bool CheckWithBFS(Dictionary<int, List<int>> graph) // O(V+E)
        {
            Dictionary<int, int> inDegree = new Dictionary<int, int>(); // 각 노드의 진입 차수
            Queue<int> queue = new Queue<int>(); // BFS 탐색을 위한 큐

            // 진입 차수 초기화
            foreach (var node in graph.Keys)
            {
                inDegree[node] = 0;
            }

            // 진입 차수 계산(각 노드가 몇 개의 노드로부터 진입하는지 계산)
            foreach (var node in graph.Keys)
            {
                foreach (var neighbor in graph[node])
                {
                    inDegree[neighbor]++;
                }
            }

            // 진입 차수가 0인 노드를 큐에 추가(시작 노드)
            foreach (var node in inDegree.Keys)
            {
                if (inDegree[node] == 0)
                {
                    queue.Enqueue(node);
                }
            }

            int visitedCount = 0; // 방문한 노드 수

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                visitedCount++;
                foreach (var neighbor in graph[node])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return visitedCount != graph.Count;
        }


        /// <summary>
        /// Jump Search 알고리즘을 이용하여 벽돌 깨지는 층 찾기
        /// Jump Search: O(sqrt(N))
        /// 점프 탐색 알고리즘이란? 블록 크기만큼 점프하며 탐색하는 알고리즘
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="target"></param>
        /// <param name="maxTry"></param>
        /// <returns></returns>
        private int FindBreakingPoint(int min, int max, int target, int maxTry)
        {
            int interval = (int)Math.Sqrt(max); // 점프 간격 (10층 단위)
            int previousFloor = min;
            int currentFloor = interval;
            int attempts = 0;
            int bricksLeft = maxTry; // 남은 벽돌 개수

            // 첫 번째 벽돌: sqrt(N) 간격으로 점프하며 깨지는 층 찾기
            while (currentFloor <= max && bricksLeft > 1)
            {
                attempts++;
                if (IsBreaking(currentFloor, target))
                {
                    bricksLeft--; // 벽돌 깨짐
                    break;
                }

                previousFloor = currentFloor;
                currentFloor += interval;
            }

            // 두 번째 벽돌: 깨지기 직전 층부터 선형 탐색
            currentFloor = previousFloor;
            while (currentFloor <= max)
            {
                attempts++;
                if (IsBreaking(currentFloor, target))
                    return attempts;

                currentFloor++;
            }

            return attempts;
        }

        /// <summary>
        /// 특정 층에서 벽돌이 깨지는지 확인하는 더미 함수
        /// </summary>
        private bool IsBreaking(int floor, int target)
        {
            return floor >= target;
        }


        /// <summary>
        /// 주어진 숫자가 2의 제곱수인지 판별하는 함수
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private bool CheckSqrOfTwo(int num) // O(1)
        {
            // 2의 제곱수는 이진수로 표현했을 때 1이 하나만 존재함
            return num > 0 && (num & (num - 1)) == 0;
        }


        /// <summary>
        /// 주어진 문자열이 괄호 여닫이가 올바른지 판별하는 함수
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool CheckParentheses(string str) // O(n)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char ch in str)
            {
                // 여는 괄호면 스택에 추가
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                }
                // 닫는 괄호면 스택에서 Pop하여 짝이 맞는지 확인
                else if (ch == ')' && (stack.Count == 0 || stack.Pop() != '('))
                {
                    return false;
                }
                else if (ch == '}' && (stack.Count == 0 || stack.Pop() != '{'))
                {
                    return false;
                }
                else if (ch == ']' && (stack.Count == 0 || stack.Pop() != '['))
                {
                    return false;
                }
            }

            // 스택이 비어있으면 모든 괄호가 올바르게 닫힘
            return stack.Count == 0;
        }


    }
}
