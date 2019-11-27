using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    static class Map
    {
        // 멤버 변수

        // 아무것도 없으면 : 0 위험지역 : 1 탐색 지점 : 2 컬러블럽 : 3
        static int[,] map;
        static int[] path;
        static int head;
        static Pair<int, int> start;
        static Pair<int, int> current;

        // 맵 크기 입력 (gui 숫자 받는거 있음) 받아서 2차원 배열 생성하는 함수.
        public static int setMapInfo(int a, int b, string hazardPos)
        {
            // 기본적으로 0으로 초기화 되는지?? 안될경우 0으로 초기화 필요...
            map = new int[a, b];

            // 위험지역 띄어쓰기로 구분해서 저장
            string[] hazardList = hazardPos.Split(' ');

            // 좌표로 받기 위해 2개 씩 이동
            for(int i = 0; i<hazardList.Length; i += 2)
            {
                // 좌표 저장할 임시 변수
                Pair<int, int> temp = new Pair<int, int>(Int32.Parse(hazardList[i]), Int32.Parse(hazardList[i + 1]));

                // 맵의 범위를 넘어선 경우 에러로 종료
                if (!isInMap(temp))
                    // 에러코드 1 : 위험지역 위치 오류
                    return 1;

                map[temp.First, temp.Second] = 1;
            }
            // 정상 종료
            return 0;
        }

        // 시작점과 주요지점 입력받아서 경로 초기화
        public static int setPathInfo(int a, int b, string spotPos)
        {
            // 시작점이 맵을 벗어나면 에러로 종료
            if(!isInMap(new Pair<int, int>(a,b)))
            {
                // 에러코드 1 : 시작점 위치 오류
                return 1;
            }
            // 시작점과 현재 위치 세팅
            start = new Pair<int, int>(a, b);
            current = new Pair<int, int>(a, b);

            // 주요지점 띄어쓰기로 구분해서 저장
            string[] spotList = spotPos.Split(' ');

            // 좌표로 받기 위해 2개 씩 이동하면서 저장
            for (int i = 0; i < spotList.Length; i += 2)
            {
                // 좌표 저장할 임시 변수
                Pair<int, int> temp = new Pair<int, int>(Int32.Parse(spotList[i]), Int32.Parse(spotList[i + 1]));

                // 맵의 범위를 넘어선 경우 에러로 종료
                if (!isInMap(temp))
                {
                    // 에러코드 2 : 주요지점 위치 오류
                    return 2;
                }
                map[temp.First, temp.Second] = 2;
            }
            // 정상 종료
            return 0;
        }

        // 컬러블럽 추가  +++++++++++ 위험지역이랑 겹치는 경우 처리 필요 +++++++++
        public static void addColorBlob(bool[] bColorBlob)
        {
            // 상하좌우 bool값 입력 받아서 현재 기준으로 컬러블럽 추가
            for(int i = 0; i<4; i++)
            {
                if (bColorBlob[i])
                {
                    switch (i)
                    {
                        case 0:
                            if (!isInMap(new Pair<int, int>(current.First + 1, current.Second))) break;
                            map[current.First + 1, current.Second] = 3;
                            break;
                        case 1:
                            if (!isInMap(new Pair<int, int>(current.First, current.Second+1))) break;
                            map[current.First, current.Second+1] = 3;
                            break;
                        case 2:
                            if (!isInMap(new Pair<int, int>(current.First - 1, current.Second))) break;
                            map[current.First - 1, current.Second] = 3;
                            break;
                        case 3:
                            if (!isInMap(new Pair<int, int>(current.First, current.Second - 1))) break;
                            map[current.First, current.Second-1] = 3;
                            break;
                    }
                }
            }
        }

        // 위험지역 추가
        public static void addHazard(bool newHazard)
        {
            if (newHazard)
            {
                // 헤드 방향에 따라 앞에 있는 지역 위험지역으로 추가
                switch (head)
                {
                    case 0:
                        if (!isInMap(new Pair<int, int>(current.First + 1, current.Second))) break;
                        map[current.First + 1, current.Second] = 1;
                        break;
                    case 1:
                        if (!isInMap(new Pair<int, int>(current.First, current.Second + 1))) break;
                        map[current.First, current.Second + 1] = 1;
                        break;
                    case 2:
                        if (!isInMap(new Pair<int, int>(current.First - 1, current.Second))) break;
                        map[current.First - 1, current.Second] = 1;
                        break;
                    case 3:
                        if (!isInMap(new Pair<int, int>(current.First, current.Second - 1))) break;
                        map[current.First, current.Second - 1] = 1;
                        break;
                }
            }
        }

        // 경로 생성, 생성 안될경우 return 1
        public static int createPath()
        {
            // 길찾기 알고리즘 입력

            return 0;
        }

        // 맵 안에 있는지 확인
        public static bool isInMap(Pair<int, int> pos)
        {
            if (pos.First < 0 || pos.Second < 0 || pos.First >= map.GetLength(0) || pos.Second >= map.GetLength(1))
            {
                // 맵을 벗어나면 false
                return false;
            }
            // 맵 안에 있으면 true
            return true;
        }
    }
}
