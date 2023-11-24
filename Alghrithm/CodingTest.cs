using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alghrithm
{
    public class CodingTest
    {

        public CodingTest()
        {
            int selected = 0;

            // Console.Clear();
            Console.WriteLine("++++++++++++++++++++++++++ Coding Test ++++++++++++++++++++++++++");
            Console.WriteLine("문제를 선택하세요. 뒤로 가려면 '0'을 입력하세요.");
            Console.WriteLine("[1] OTP 알고리즘 구현하기");
            Console.WriteLine("[2] 전력 사용량 구하기");
            Console.WriteLine("[3] 내비게이션 안내 메시지 출력하기");
            Console.WriteLine("[4] 카데인 알고리즘");
            Console.WriteLine("[5] 완호 등수 구하기");
            Console.WriteLine("[6] 대충 만든 자판");
            Console.WriteLine("[7] 명예의 전당");
            Console.WriteLine("[8] 과제 진행하기");
            Console.WriteLine("[9] 할인 행사");
            Console.WriteLine("[10] 혼자 놀기의 달인");
            Console.WriteLine("[11] 뒤에 있는 큰 수 찾기");
            Console.WriteLine("[12] 의상");
            Console.WriteLine("[13] 큐");

            bool validInput = true;
            while (validInput)
            {
                try
                {
                    Console.Write("입력 : ");
                    selected = Convert.ToInt32(Console.ReadLine());
                    if(selected == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    RunCodingTest(selected);
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("올바른 숫자를 입력하세요.");
                }
            }
        }

        public void RunCodingTest(int selected)
        {
            Console.WriteLine("");
            switch (selected)
            {
                case 1:
                    #region ============================== OTP 알고리즘 ==============================
                    Console.WriteLine("[NSUSLAB 코딩테스트]");
                    int[] times = new int[] { 0, 29, 30, 119, 120 };
                    int k = 30, a = 25, b = 13;
                    string initPassword = "0001";
                    string[] answer1 = solution(k, a, b, initPassword, times);

                    //int[] times = new int[] { 2, 3, 4 };
                    //string[] answer1 = solution(1, 1, 1000, "7123", times);

                    Console.WriteLine("변경 주기 : " + k + ", 규칙(a, b) : " + a + ", " + b + ", 초기 비밀번호 : " + initPassword);
                    Console.Write("타겟 시간 : ");
                    for (int i = 0; i < times.Length; i++)
                    {
                        Console.Write(times[i] + "초 ");
                    }
                    Console.WriteLine("");

                    Console.Write("변경 비밀번호 : ");
                    for (int i = 0; i < answer1.Length; i++)
                    {
                        Console.Write(answer1[i] + " ");
                    }
                    Console.WriteLine("");
                    #endregion ======================================================================
                    break;
                case 2:
                    #region ============================== 전력 사용량 ==============================
                    Console.WriteLine("[NSUSLAB 코딩테스트]");
                    int[,] fees = new int[,]{
                        {200, 910, 93},
                        {400, 1600, 188},
                        {655, 7300, 281},
                        {0, 15372, 435}
                    };
                    int usage = 320;
                    Console.WriteLine("<< 전력요금표 >>");
                    Console.WriteLine("사용량\t\t기본요금\tkwH당 추가요금");
                    Console.WriteLine("----------------------------------------------");
                    for (int i = 0; i < fees.GetLength(0); i++)
                    {
                        Console.WriteLine(fees[i, 0] + "\t\t" + fees[i, 1] + "\t\t" + fees[i, 2]);
                    }
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("전력 사용량 : " + usage);
                    
                    int answer2 = solution2(fees, usage);
                    Console.WriteLine("사용 금액 : " + answer2);
                    #endregion =====================================================================
                    break;
                case 3:
                    #region ============================== 내비게이션 안내 메시지 ==============================
                    Console.WriteLine("[NSUSLAB 코딩테스트]");
                    string path = "EEESEEEEENNNN";

                    Console.Write("이동경로 : ");
                    for (int i = 0; i < path.Length; i++)
                    {
                        Console.Write(path[i] + " ");
                    }
                    Console.WriteLine("");

                    string[] answer3 = solution3(path);
                    Console.WriteLine("내비게이션 메시지");
                    for (int i = 0; i < answer3.Length; i++)
                    {
                        Console.WriteLine(answer3[i]);
                    }
                    #endregion ===============================================================================
                    break;
                case 4:
                    #region ============================== 펄스 수열 ==============================
                    int[] sequence = { 2, 3, -6, 1, 3, -1, 2, 4 };
                    long answer4 = solution4(sequence);
                    Console.WriteLine("펄스 수열 : " + answer4);
                    #endregion ===================================================================
                    break;
                case 5:
                    #region ============================== 완호 등수 구하기 ==============================
                    Console.WriteLine("[프로그래밍 코딩테스트(난이도 3)]");
                    int[,] scores = {
                        // 기본 테스트 케이스
                         //{ 2, 2 },
                         //{ 1, 4 },
                         //{ 3, 2 },
                         //{ 3, 2 },
                         //{ 2, 1 }
                        // 테스트 케이스2
                        //{ 7, 1 },
                        //{ 6, 6 },
                        //{ 5, 4 },
                        //{ 5, 4 },
                        //{ 6, 6 },
                        // 테스트 케이스3
                        { 4, 1 },
                        { 2, 4 },
                        { 3, 5 }
                    };
                    int answer5 = solution5(scores);
                    Console.WriteLine("<< 점수표(완호는 첫 번째 index) >>");
                    Console.WriteLine("업무평가\t동료평가");
                    Console.WriteLine("---------------------------");
                    for (int i = 0; i < scores.GetLength(0); i++)
                    {
                        Console.WriteLine(scores[i, 0] + "\t\t" + scores[i, 1]);
                    }
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("완호 등수 : " + answer5);
                    #endregion ==========================================================================
                    break;

                case 6:
                    #region ====================== 대충 만든 자판 ======================
                    Console.WriteLine("[프로그래밍 코딩테스트(난이도 1)]");
                    // string[] keymap = { "ABACD", "BCEFD" };
                    // string[] targets = { "ABCD", "AABB" };

                    // string[] keymap = { "AA" };
                    // string[] targets = { "B" };

                    // string[] keymap = { "AGZ", "BSSS" };
                    // string[] targets = { "ASA", "BGZ" };

                    string[] keymap = { "CAB", "AAC", "EFGH", "BHI" };
                    string[] targets = { "ABACZI" };
                    Console.Write("자판 배열 : ");
                    for(int i = 0; i < keymap.Length; i++)
                    {
                        Console.Write(keymap[i] + " ");
                    }
                    Console.WriteLine("");

                    Console.Write("입력할 문자열 : ");
                    for (int i = 0; i < targets.Length; i++)
                    {
                        Console.Write(targets[i] + " ");
                    }
                    Console.WriteLine("");

                    Console.Write("결과 : ");
                    int[] answer6 = solution6(keymap, targets);
                    for (int i = 0; i < answer6.Length; i++)
                    {
                        Console.Write(answer6[i] + " ");
                    }
                    Console.WriteLine("");
                    #endregion ========================================================
                    break;
                case 7:
                    #region ================================ 명예의 전당 ================================
                    Console.WriteLine("[프로그래밍 코딩테스트(난이도 1)]");

                    int k1 = 3;
                    int[] score = { 10, 100, 20, 150, 1, 100, 200 };

                    // int k1 = 4;
                    // int[] score = { 0, 300, 40, 300, 20, 70, 150, 50, 500, 1000 };

                    Console.WriteLine("명예의 전당 목록 개수 : " + k1);
                    Console.Write("점수 리스트 : ");
                    for(int i = 0; i < score.Length; i++)
                    {
                        Console.Write(score[i] + " ");
                    }
                    Console.WriteLine("");

                    int[] result = solution7(k1, score);
                    Console.Write("결과 : ");
                    for (int i = 0; i < result.Length; i++)
                    {
                        Console.Write(result[i] + " ");
                    }
                    Console.WriteLine("");
                    #endregion =========================================================================
                    break;
                case 8:
                    #region ================================ 과제 진행하기 ================================
                    Console.WriteLine("[프로그래밍 코딩테스트(난이도 2)]");

                    string[,] plans = {
                        //{ "korean", "11:40", "30" },
                        //{ "english", "12:10", "20" },
                        //{ "math", "12:30", "40" },

                        //{ "science", "12:40", "50" },
                        //{ "music", "12:20", "40" },
                        //{ "history", "14:00", "30" },
                        //{ "computer", "12:30", "100" },

                        {"a", "09:00", "10" },
                        {"b", "09:10", "10" },
                        {"c", "09:15", "10" },
                        {"d", "09:30", "10" },
                        { "e", "09:35", "10" },

                    };
                    Console.WriteLine("과목명\t\t시작시간\t할당시간");
                    Console.WriteLine("----------------------------------------------");
                    for (int i = 0; i < plans.GetLength(0); i++)
                    {
                        Console.WriteLine(plans[i, 0] + "\t\t" + plans[i, 1] + "\t\t" + plans[i, 2]);
                    }
                    Console.WriteLine("----------------------------------------------");

                    string[] answer8 = solution8(plans);
                    Console.Write("과제 완료 순서 : ");
                    for(int i = 0; i < answer8.Length; i++)
                    {
                        Console.Write(answer8[i] + " ");
                    }
                    Console.WriteLine("");
                    #endregion ===========================================================================
                    break;
                case 9:
                    #region ================================ 할인 행사 ================================
                    Console.WriteLine("[프로그래밍 코딩테스트(난이도 2)]");
                    string[] want = {
                        // "banana", "apple", "rice", "pork", "pot",
                        "apple", };

                    int[] number = {
                        // 3, 2, 2, 2, 1, 
                        10, 
                    };

                    string[] discount = { 
                        //"chicken", "apple", "apple", "banana", "rice", "apple", "pork", "banana", "pork", "rice", "pot", "banana", "apple", "banana",
                        "banana", "banana", "banana", "banana", "banana", "banana", "banana", "banana", "banana", "banana"
                    };

                    Console.WriteLine("원하는 물건 : ");
                    for (int i = 0; i < want.Length; i++)
                    {
                        Console.WriteLine(want[i] + "\t" + number[i]);
                    }

                    Console.Write("판매 항목 : ");
                    for (int i = 0; i < discount.Length; i++)
                    {
                        Console.Write(discount[i] + " ");
                    }
                    Console.WriteLine("");

                    int answer9 = solution9(want, number, discount);
                    Console.WriteLine("회원가입 가능한 날짜 : " + answer9);
                    #endregion =======================================================================
                    break;

                case 10:
                    #region ================================ 혼자 놀기 ================================
                    Console.WriteLine("[프로그래밍 코딩테스트(난이도 2)]");
                    int[] cards = {
                        //8, 6, 3, 7, 2, 5, 1, 4,             // 기대값 : 12
                        4, 1, 3, 2, 5,                   // 기대값 : 3
                        // 10, 5, 6, 7, 8, 9, 1, 2, 3, 4,   // 기대값 : 36
                    };
                    int answer10 = solution10(cards);
                    Console.WriteLine("최고 점수 : " + answer10);
                    #endregion =======================================================================
                    break;

                case 11:
                    #region ================================ 뒤에 있는 큰 수 찾기 ================================
                    Console.WriteLine("[프로그래밍 코딩테스트(난이도 2)]");

                    int[] numbers = { 
                        // 2, 3, 3, 5,                 // 기대값 : { 3, 5, 5, 1}
                        9, 1, 5, 3, 6, 2         // 기대값 : { -1, 5, 6, 6, -1, -1 }
                    };
                    int[] answer = solution11(numbers);
                    #endregion =======================================================================
                    break;
                case 12:
                    #region ================================ 의상 ================================
                    Console.WriteLine("[프로그래밍 코딩테스트(난이도 2)]");
                    string[, ] clothes = { 
                        { "yellow_hat", "headgear" }, 
                        { "blue_sunglasses", "eyewear" }, 
                        { "green_turban", "headgear" } 
                    };
                    int answer12 = solution12(clothes);
                    #endregion =====================================================================================
                    break;
                case 13:
                    #region ================================ 큐 ================================
                    Console.WriteLine("[래브라도 코딩테스트]");
                    string[] str1 = { "3", "e", "10", "e", "20", "e", "30" };                   // 기대값 : 10, 20, 30
                    string[] str2 = { "4", "d", "e", "10", "e", "20", "e", "30" };              // 기대값 : underflow, 10, 20, 30
                    string[] str3 = { "3", "d", "e", "10", "e", "20", "e", "30", "e", "40" };   // 기대값 : u, 10, 20, 30, o
                    string[] str4 = { "3", "e", "10", "e", "20", "d", "10", "e", "30" };        // 기대값 : 20, 30
                    string[] answer13 = solution13(str3);
                    for (int i = 0; i < answer13.Length; i++)
                    {
                        if (answer13[i] == "overflow" || answer13[i] == "underflow")
                        {
                            Console.WriteLine(answer13[i]);
                        }
                        else
                        {
                            Console.Write(answer13[i] + " ");
                        }
                    }
                    #endregion =================================================================
                    break;
                default:
                    break;
            }
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }


        /// <summary>
        /// OTP
        /// </summary>
        /// <param name="k">비밀번호 변경 주기(초)</param>
        /// <param name="a">비밀번호 변경 규칙 1</param>
        /// <param name="b">비밀번호 변경 규칙 2</param>
        /// <param name="init_password">최초 비밀번호</param>
        /// <param name="times"></param>
        /// <returns></returns>
        public string[] solution(int k, int a, int b, string init_password, int[] times)
        {
            string[] answer = new string[times.Length];

            // 초기 비밀번호 설정
            int currentPassword = int.Parse(init_password);

            // 주어진 시간에 따라 비밀번호 생성
            for (int i = 0; i < times.Length; i++)
            {
                // 현재 시간
                int currentTime = times[i];

                // 현재 시간까지 몇 번의 주기가 지났는지 계산
                int cycles = currentTime / k;

                // 주기에 따른 비밀번호 갱신
                int tempPassword = currentPassword;
                for (int j = 0; j < cycles; j++)
                {
                    tempPassword = (a * tempPassword + b) % 10000;
                }

                answer[i] = tempPassword.ToString("D4");
            }

            return answer;
        }


        /// <summary>
        /// 전기 요금표 사용량
        /// </summary>
        /// <param name="fees">요금표</param>
        /// <param name="usage">사용량</param>
        /// <returns></returns>
        public int solution2(int[,] fees, int usage)
        {
            int answer = 0;
            int index = 0;
            int basicFee = 0;          // 기본요금

            // 기본요금 조회
            for (int i = 0; i < fees.GetLength(0); i++)
            {
                if (usage <= fees[i, 0])
                {
                    index = i;
                    basicFee = fees[i, 1];
                    break;
                }
                else if (i == (fees.GetLength(0) - 1))
                {
                    index = i;
                    basicFee = fees[i, 1];
                    break;
                }
            }

            int additionalFee = 0;
            int remain = usage;
            // int prevMax = 0;
            for (int i = 0; i <= index; i++)
            {
                int temp = 0;       // 누전 사용량..?
                if (i == 0)
                    temp = fees[i, 0] - 0;
                else if (i == index)
                    temp = fees[i - 1, 0];
                else
                    temp = fees[i, 0] - fees[i - 1, 0];

                // remain과 비교해서 remain이 더 크면 전기 요금표의 max값으로 계산, 그렇지 않으면 remain으로 계산.
                additionalFee = additionalFee + (remain > temp ? (temp * fees[i, 2]) : (remain * fees[i, 2]));
                remain = remain - temp;

                if (remain <= 0)
                    break;
            }

            answer = basicFee + additionalFee;

            return answer;
        }



        /// <summary>
        /// 좌표탐색 알고리즘
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string[] solution3(string path)
        {
            List<string> answer = new List<string>();

            for (int i = 0; i < path.Length; i++)
            {
                char direction = path[i];

                for (int j = i; j <= i + 5; j++)
                {
                    // 현재 위치한 경로로부터 5칸 이내에 방향 변경이 있는지 체크
                    if (j < path.Length)
                    {
                        if (path[i] != path[j])
                        {
                            string directionMsg = "";

                            char nextDirection = path[j];
                            // left / right 판단
                            if ((direction == 'E' && nextDirection == 'S') ||
                                (direction == 'S' && nextDirection == 'W') ||
                                (direction == 'W' && nextDirection == 'N') ||
                                (direction == 'N' && nextDirection == 'E'))
                            {
                                directionMsg = "right";
                            }
                            else
                            {
                                directionMsg = "left";
                            }
                            int distance = j - i == 4 ? 5 : (j - i);

                            answer.Add($"Time {i}: Go straight {distance}00m and turn {directionMsg}");
                            i = j - 1;
                            break;
                        }
                    }
                }


            }

            return answer.ToArray();
        }


        /// <summary>
        /// 펄스수열
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public long solution4(int[] sequence)
        {
            long answer = 0;

            //long maxSum = 0; // 최대 연속 부분 수열의 합
            //// 배열 내에서 가장 큰 값을 찾아 시작점으로 설정
            //for (int start = 0; start < sequence.Length; start++)
            //{
            //    long currentSum = 0;
            //    long tempMax = 0;
            //    int sign = 1; // 부호 (1 또는 -1)

            //    // 시작점부터 부분 수열 계산
            //    for (int i = start; i < sequence.Length; i++)
            //    {
            //        // 현재 원소와 부호를 곱하여 연속 부분 수열의 합에 더함
            //        currentSum += sequence[i] * sign;
            //        sign *= -1; // 부호 변경

            //        // 최대값 갱신
            //        tempMax = Math.Max(tempMax, currentSum);
            //        maxSum = Math.Max(maxSum, tempMax);
            //    }
            //}

            //answer = maxSum;
            return answer;
        }



        /// <summary>
        /// 완호 등수 구하기
        /// </summary>
        /// <param name="scores"></param>
        /// <returns></returns>
        public int solution5(int[,] scores)
        {
            int wanho_a = scores[0, 0];
            int wanho_b = scores[0, 1];
            int wanho_sum = wanho_a + wanho_b;
            // 완호보다 점수가 높은 사람을 담을 List
            var highers = new List<int>();

            for (int i = 1; i < scores.GetLength(0); i++)
            {
                // 다른 사람 점수
                int a = scores[i, 0];
                int b = scores[i, 1];

                // 근무태도 & 동료 평가가 둘 다 낮은 경우 있으면 -1 리턴
                if (wanho_a < a && wanho_b < b)
                    return -1;

                // 합산 점수가 완호가 더 낮을 때
                if (wanho_sum < a + b)
                {
                    int found = 0;
                    int inserted = 0;

                    while (found < highers.Count)
                    {
                        int h = highers[found];
                        int h_a = scores[h, 0];
                        int h_b = scores[h, 1];

                        // 완호보다 점수가 높은 현재 비교인(?)과 완호보다 점수가 더 높은 사람이 들어 있는 List를 비교
                        if (a < h_a && b < h_b)
                            break;
                        if (h_a >= a || h_b >= b)
                            highers[inserted++] = h;
                        found++;
                    }
                    if (found == highers.Count)
                    {
                        // 완호보다 점수가 높은 사람 추가
                        highers.RemoveRange(inserted, highers.Count - inserted);
                        highers.Add(i);
                    }
                }
            }
            return highers.Count + 1;
        }


        /// <summary>
        /// 대충 만든 자판
        /// </summary>
        /// <param name="keymap">자판 키 배열</param>
        /// <param name="targets">입력 문자열</param>
        /// <returns></returns>
        public int[] solution6(string[] keymap, string[] targets)
        {
            /* keymap 돌면서 각 알파벳 중 가장 먼저오는 순서를 Dictionary 형태로 저장.
             * 예를 들어 "ABACD", "BCEFD" 라는 keymap이 있을 때
             * "B" 요소는 index[0]과[1]에 모두 존재하지만 index[1]의 B가 더 먼저 오기 때문에 더 빠른 index인 0을 저장
             * 저장되는 형태는 다음과 같다.
             * keymap: "ABACD", "BCEFD" 일 때, "B"를 저장한다고 하자.
             * B의 위치 : keymap[0][1], keymap[1][0] => 두 번 째 B의 위치가 더 빠르므로 B | 0 의 형태로 저장
             */
            int[] answer = new int[targets.Length];
            
            Dictionary<char, int> keyCollection = new Dictionary<char, int>();

            // 1. Dictionary에 자판 배열 추가(가장 빠른 배열로)
            for(int i = 0; i < keymap.Length; i++)
            {
                string keyNote = keymap[i];
                for(int j = 0; j < keyNote.Length; j++)
                {
                    if (keyCollection.ContainsKey(keyNote[j]))
                    {
                        // 이미 있는 자판인지 비교하여 있으면 더 빠른 자판으로 교체해준다.
                        keyCollection[keyNote[j]] = keyCollection[keyNote[j]] < j ? keyCollection[keyNote[j]] : j;
                    }
                    else
                    {
                        // 없으면 자판 추가
                        keyCollection.Add(keyNote[j], j);
                    }
                }
            }


            for(int i = 0; i < targets.Length; i++)
            {
                string target = targets[i];
                for(int j = 0; j < target.Length; j++)
                {
                    if (keyCollection.ContainsKey(target[j]))
                    {
                        // 자판 횟수 추가
                        int cnt = keyCollection[target[j]] + 1;
                        answer[i] = answer[i] + cnt;
                    }
                    else
                    {
                        // 아무것도 없으면 -1 반환
                        answer[i] = -1;
                        break;
                    }
                }
            }

            return answer;
        }


        /// <summary>
        /// 명예의 전당
        /// </summary>
        /// <param name="k">명예의 전당 리스트 개수</param>
        /// <param name="score">점수</param>
        /// <returns></returns>
        public int[] solution7(int k, int[] score)
        {
            int[] answer = new int[score.Length];

            List<int> answer_list = new List<int>();
            for(int i = 0; i < score.Length; i++)
            {
                if (answer_list.Count < k)
                {
                    // k 이하의 경우는 무조건 가장 작은 값 Add
                    answer_list.Add(score[i]);
                    answer[i] = answer_list.Min();
                }
                else
                {
                    answer_list.Add(score[i]);
                    answer_list = answer_list.OrderByDescending(x => x).ToList();
                    answer[i] = answer_list[k - 1];
                }
            }

            return answer;
        }



        /// <summary>
        /// 과제 진행하기
        /// </summary>
        /// <param name="plans">과제 목록(과제명 | 과제 시작 시간 | 과제 할당 시간)</param>
        /// <returns></returns>
        public string[] solution8(string[, ] plans)
        {
            List<string> answer = new List<string>();
            Dictionary<string, int[]> dic = new Dictionary<string, int[]>();
            Queue<string> queue = new Queue<string>();                              // 멈춰둔 과제와 새로운 과제가 있을 때 새로운 과제부터 처리하려고...??
            Stack<string> stack = new Stack<string>();                              // 멈춰둔 과제 : 여러개일 때 가장 최근에 멈춘 과제부터 처리를 위해..??

            for (int i = 0; i < plans.GetLength(0); i++)
            {
                int[] temp = Array.ConvertAll(plans[i, 1].Split(":"), int.Parse);
                dic.Add(plans[i, 0], new int[] { (temp[0] * 60 + temp[1]), int.Parse(plans[i, 2]) });       // 시, 분을 분 형태로 저장 및 할당 시간을 Dictionary 형태로 저장
            }
            dic = dic.OrderBy(x => x.Value[0]).ToDictionary(x => x.Key, x => x.Value);                      // 시작 시간 순서대로 정렬

            
            foreach (string s in dic.Keys)
            {
                queue.Enqueue(s);
            }

            while (queue.Count > 1)
            {
                string now = queue.Dequeue();                   // 현재 과제 먼저 진행
                string next = queue.Peek();                     // 다음 과제
                int time = dic[next][0] - dic[now][0];          // 현재 과제 할당 시간

                //이번 시간 안에 과제를 끝낼수 있으면
                if (time >= dic[now][1])
                {
                    //끝낸 과제 추가, 남은 시간 계산
                    answer.Add(now);
                    time -= dic[now][1];

                    // 남은 시간을 대기중인 과제에사용
                    while (stack.Count > 0 && time > 0) //시간이 남았고, 대기중인 과제가 있다면
                    {
                        string temp = stack.Pop();

                        if (time >= dic[temp][1])// 시간안에 끝낼수 있는지
                        {
                            answer.Add(temp);
                            time -= dic[temp][1];
                        }
                        else
                        {
                            dic[temp][1] -= time;
                            time = 0;
                            stack.Push(temp);
                        }
                    }
                }
                else
                {
                    // 과제 못끝내면 할당시간 재계산 후 stack에 push
                    dic[now][1] -= time;
                    stack.Push(now);
                }
            }

            // 마지막 과제 완료 처리
            answer.Add(queue.Dequeue());
            // 미뤄둔 과제부터 완료처리
            while (stack.Count > 0)
            {
                answer.Add(stack.Pop());
            }

            return answer.ToArray();
        }



        /// <summary>
        /// 할인 행사
        /// </summary>
        /// <param name="want">정현이가 원하는 제품들</param>
        /// <param name="number">정현이가 원하는 제품들의 수량</param>
        /// <param name="discount">마트에서 할인하는 제품 문자열배열</param>
        /// <returns></returns>
        public int solution9(string[] want, int[] number, string[] discount)
        {
            int answer = 0;

            int total = 0;
            Dictionary<string, int> dic = new Dictionary<string, int>();

            for(int i = 0; i < want.Length; i++)
            {
                dic.Add(want[i], number[i]);
                total += number[i];
            }

            // 할인 품목만큼 다 돌면서
            for(int i = 0; i < discount.Length; i++)
            {
                // 유효성 체크
                if(i + total > discount.Length)
                {
                    break;
                }
                for (int k = 0; k < want.Length; k++)
                {
                    // dictionary 다시 초기화
                    dic[want[k]] = number[k];
                }

                // 현재 날짜부터 정현이 물건 개수만큼 루프
                for (int j = i; j < total + i; j++)
                {
                    string product = discount[j];
                    if (dic.ContainsKey(product) && dic[product] > 0)
                    {
                        dic[product] -= 1;
                    }

                    // 기준일 j로부터 마지막 날일 때 모든 품목을 삿는지 체크
                    if(j == (total + i - 1))
                    {
                        if (dic.Values.All(value => value == 0))
                        {
                            answer++;
                        }
                        break;
                    }
                }
            }


            return answer;
        }


        /// <summary>
        /// 혼자 놀기의 달인
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public int solution10(int[] cards)
        {
            int answer = 1;
            List<List<int>> openedList = new List<List<int>>();

            int j = 0;
            int maxCnt = 0;
            int temp = 0;
            while (temp < cards.Length - 1)
            {
                temp = 0;
                // 1. cards에서 루프 돌면서 임의의 숫자 하나를 고름
                for (int r = 0; r < openedList.Count; r++)
                {
                    temp += openedList[r].Count;
                }

                // 2. 카드가 이미 열려있는 카드면 다음 인덱스로, 아니면 열린 카드로 변경
                if (openedList.Count == 0)
                {
                    // 아무것도 열려있는 카드가 없으면 첫 카드를 열린 카드로 등록
                    List<int> arr = new List<int>();
                    arr.Add(j);
                    openedList.Add(arr);
                    j = cards[j] - 1;
                }
                else
                {
                    bool flag = false;
                    
                    for(int k = 0; k < openedList.Count; k++)
                    {
                        if (flag)
                            break;
                        // if (!openedList.Any(list => list.Count > j && list.ElementAtOrDefault(j) != null))
                        if (!openedList[maxCnt].Contains(j))
                        {
                            // 열려있지 않은 카드면 다음 카드를 열고, 열린 카드로 처리함.
                            openedList[maxCnt].Add(j);
                            j = cards[j] - 1;
                            flag = false;
                        }
                        else
                        {
                            // 이미 열려있는 카드면 새로운 카드 뭉치 추가, 열려있지 않은 카드 중 임의의  카드로설정
                            List<int> arr_new = new List<int>();
                            openedList.Add(arr_new);
                            maxCnt++;
                            j = j + 1;
                            flag = true;
                        }
                    }
                }
            }

            for(int i = 0; i < openedList.Count; i++)
            {
                if (openedList[i].Count == 0)
                    openedList.RemoveAt(i);
            }

            if (openedList.Count == 1)
                answer = 0;
            else
            {
                for (int i = 0; i < openedList.Count; i++)
                {
                    answer = answer * openedList[i].Count;
                }
            }
            


            // 2. 임의의 숫자를 골라서 그룹이 되는 것들을 묶음. 이미 열려있는 카드가 나올 때까지 처리함.

            // 3. 그룹으로 묶인 카드들은 뭉치에서 제외함.

            // 4. 모든 카드가 제외될 때 까지 처리.

            // 5. 루프를 돌면서 이미 그룹 내에 속해있는 애들이면 똑같은 애들로 묶음.
            return answer;
        }



        /// <summary>
        /// 뒤에 있는 큰 수 찾기
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int[] solution11(int[] numbers)
        {
            int[] answer = new int[numbers.Length];

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    bool bChange = false;
            //    for (int j = i + 1; j < numbers.Length; j++)
            //    {
            //        if (numbers[i] < numbers[j] && !bChange)
            //        {
            //            answer[i] = numbers[j];
            //            bChange = true;
            //            break;
            //        }
            //        else
            //        {
            //            answer[i] = -1;
            //        }
            //    }
            //    if (i == numbers.Length - 1)
            //        answer[i] = -1;
            //}

            Stack numStack = new Stack();
            List<int> reverseList = new List<int>();

            numStack.Push(numbers[numbers.Length - 1]);                 // Stack에 마지막 요소 추가
            reverseList.Add(-1);                                        // List에 마지막 값(무조건 -1) 추가

            for (int i = numbers.Length - 2; i >= 0; i--)
            {
                int tmp = -1;

                while(numStack.Count != 0)
                {
                    if (Convert.ToInt32(numStack.Peek()) > numbers[i])
                    {
                        // stack의 마지막 요소와 비교해서 stack에 있는 값이 더 크면 해당 값을 List에 추가해준다.
                        tmp = Convert.ToInt32(numStack.Peek());
                        break;
                    }
                    else
                        // 그게 아니면 그 다음 요소와 비교해서 넣어줌
                        numStack.Pop();
                }
                reverseList.Add(tmp);
                numStack.Push(numbers[i]);
            }

            reverseList.Reverse();
            answer = reverseList.ToArray();

            return answer;
        }



        public int solution12(string[,] clothes)
        {
            int answer = 0;

            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<int> list = new List<int>();
            for (int i = 0; i < clothes.GetLength(0); i++)
            {
                dict.Add(clothes[i, 0], clothes[i, 1]);
            }

            var keys = dict.Keys.ToList();
            for(int i = 0; i < keys.Count; i++)
            {
                var key = keys[i];
            }

            // 1. 가지수 구하기

            // 2. count1 = 가지수별로 하나 씩만 착용할 경우(ex. headgear(2) + eyewear(1) = 3)
            // 3. count2 = 가지수를 조합할 경우(ex. yello_hat/blue_sunglasses(1) + green_turban/blue_sunglasses(1) = 2)
            //      3-1. 가지수가 하나만 있으면 이미 count1에서 처리했으므로 처리하지 않는다.
            //      3-2. 가지수가 여러개일 경우
            //          3-2-1. ex) aa // bb // cc ---> aabb aacc bbcc
            // 4. count + count2 = 5
            return answer;
        }


        public string[] solution13(string[] str)
        {
            int maxSize = Convert.ToInt32(str[0]);  // 큐의 최대 size
            string[] queue = new string[maxSize];
            int front = 0;  // 큐의 가장 앞 요소
            int rear = -1;  // 큐의 가장 뒤 요소
            int count = 0;  // 현재 큐의 요소의 개수

            List<string> result = new List<string>(); // 결과를 저장할 리스트

            int index = 0;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == "e")
                {
                    if (count == maxSize)
                    {
                        // 큐의 최대 길이 초과시
                        result.Add("overflow");
                    }
                    else
                    {
                        rear = (rear + 1) % maxSize;
                        queue[rear] = str[i + 1];
                        result.Add(str[i + 1]);
                        i++;        // 다음 요소로 넘기기 위해서 i++ 처리
                        count++;
                    }
                }
                else if (str[i] == "d")
                {
                    if (count == 0)
                    {
                        result.Add("underflow");
                    }
                    else
                    {
                        // result.Add(queue[front]);
                        result.RemoveAt(front);
                        // front = (front + 1) % maxSize;
                        count--;
                    }
                }
            }


            return queue;
        }


    }
}
