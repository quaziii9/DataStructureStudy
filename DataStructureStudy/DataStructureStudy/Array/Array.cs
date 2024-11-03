using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureStudy
{
    /* 1. 배열의 기본 특징
        - 고정된 크기를 가짐
        - 연속된 메모리 공간에 저장
        - 0부터 시작하는 인덱스
        - 같은 타입의 데이터만 저장 가능
        
       2. 배열의 종류
        - 1차원 배열 : 가장 기본적인 형태
        - 다차원 배열 : 행과 열을 가진 형태(2차원, 3차원 등)
        - 가변 배열 : 각 행의 길이가다른 배열 
       
       3. 성능 특징
        - 읽기/쓰기 : O(1)
        - 삽입/삭제 : O(n)
        - 검색 : O(n)
        - 메모리 : 연속된 공간 필요
       
       4. 실무에서 배열 사용시 주의 사항
        - 크기가 고정되어 있어 동적으로 크기 조절 불가
        - 삽입 / 삭제가 빈번한 경우 List<T> 사용 권장
        - 큰 배열 할당 시 메모리 부족 주의
        - 다차원 배열보다 가변 배열이 더 효율적일 수 있음

       5. 일반적인 사용 사례
        - 고정된 크기의 데이터 저장
        - 행렬 연산
        - 이미지 처리 (픽셀 배열)
        - 버퍼 관리
        - 캐싱
    */

    // 1. 기본적인 배열 선언과 초기화
    public class ArrayBasics
    {
        public void BasicArrayExamples()
        {
            // 1-1. 배열 선언 방법들
            int[] numbers = new int[5];     // 크기가 5인 정수 배열 선언
            int[] intialized = { 1, 2, 3, 4, 5 }; // 초기값과 함께 선언
            int[] sized = new int[5] { 1, 2, 3, 4, 5 }; // 크기 지정과 함께 초기화

            // 1-2. 배열 요소 접근
            numbers[0] = 10;    // 첫 번째 요소에 값 할당 
            int firstNumber = numbers[0]; // 배열 요소 읽기

            // 1-3. 배열 길이 확인
            int length = numbers.Length;    // 배열 길이 얻기
        }

        // 2. 다차원 배열
        public void MultidimensionalArrays()
        {
            // 2-1. 2차원 배열 선언
            int[,] matrix = new int[3, 3];  // 3x3 2차원 배열

            // 2-2. 2차원 배열 초기화
            int[,] initialized2D = new int[,]
            {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
            };

            // 2-3. 차원 수 및 각 차원의 길이 확인
            int dimensions = matrix.Rank;      // 차원 수 확인
            int rows = matrix.GetLength(0);    // 행 수
            int columns = matrix.GetLength(1); // 열 수

            // 2-4. 2차원 배열 순회
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = i * j;  // 각 요소에 값 할당
                }
            }
        }

        // 3. 가변 배열 (Jagged Array)
        public void JaggedArrays()
        {
            // 3-1. 가변 배열 선언
            int[][] jaggedArray = new int[3][];

            // 3-2. 각 행마다 다른 크기의 배열 할당
            jaggedArray[0] = new int[4];
            jaggedArray[1] = new int[2];
            jaggedArray[2] = new int[3];

            // 3-3. 가변 배열 초기화
            jaggedArray[0] = new int[] { 1, 2, 3, 4 };
            jaggedArray[1] = new int[] { 5, 6 };
            jaggedArray[2] = new int[] { 7, 8, 9 };

            // 3-4. 가변 배열 순회
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        // 4. 배열 메서드 활용
        public void ArrayMethods()
        {
            int[] numbers = { 5, 2, 8, 1, 9 };

            // 4-1. 정렬
            Array.Sort(numbers);  // 오름차순 정렬

            // 4-2. 역순
            Array.Reverse(numbers);  // 배열 순서 뒤집기

            // 4-3. 검색
            int index = Array.IndexOf(numbers, 8);  // 값 8의 인덱스 찾기

            // 4-4. 복사
            int[] copied = new int[numbers.Length];
            Array.Copy(numbers, copied, numbers.Length);

            // 4-5. 모든 요소에 조건 적용
            Array.ForEach(numbers, n => Console.WriteLine(n));

            // 4-6. 배열 초기화
            Array.Clear(numbers, 0, numbers.Length);
        }

        // 5. 배열 활용 예제
        public class ArrayUtilities
        {
            // 5-1. 배열의 합계 계산
            public static int Sum(int[] array)
            {
                int sum = 0;
                foreach (int num in array)
                {
                    sum += num;
                }
                return sum;
            }

            // 5-2. 배열에서 최대값 찾기
            public static int FindMax(int[] array)
            {
                if (array == null || array.Length == 0)
                    throw new ArgumentException("Array is empty");

                int max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max)
                        max = array[i];
                }
                return max;
            }

            // 5-3. 배열 요소 회전
            public static void Rotate(int[] array, int k)
            {
                if (array == null || array.Length == 0) return;

                k = k % array.Length;  // k가 배열 길이보다 큰 경우 처리

                // 전체 배열 뒤집기
                Reverse(array, 0, array.Length - 1);
                // 처음부터 k-1까지 뒤집기
                Reverse(array, 0, k - 1);
                // k부터 끝까지 뒤집기
                Reverse(array, k, array.Length - 1);
            }

            private static void Reverse(int[] array, int start, int end)
            {
                while (start < end)
                {
                    int temp = array[start];
                    array[start] = array[end];
                    array[end] = temp;
                    start++;
                    end--;
                }
            }
        }
    }
}
