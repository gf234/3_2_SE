using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace WindowsFormsApp1
{
    static class Map
    {
        /////////////////////////////////////////////////멤버 변수

        // 아무것도 없으면 : 0 위험지역 : 1 탐색 지점 : 2  입력 받은 컬러블럽 : 3  지나간 컬러블럽 : 4
        public static int[,] map;
        // 경로는 노드의 스택 형식 ...
        public static List<Tile> path = new List<Tile>();
        // 헤드방향은 기본으로 위쪽( 0 )
        public static int head = 0;
        // current : 현재 위치 ...
        public static Pair<int, int> current;
        // 주요 지점 ...
        public static List<Pair<int, int>> spot = new List<Pair<int, int>>();


        //////////////////////////////////////////////////멤버 함수

        // 맵 크기 입력 받아서 2차원 배열 생성하는 함수.
        public static int setMapInfo(int a, int b, string hazardPos, string colorBlobPos)
        {
            map = new int[a, b];

            // 위험지역 띄어쓰기로 구분해서 저장
            string[] hazardList = hazardPos.Split(' ');
            // 짝수개가 아니면 에러
            if (hazardList.GetLength(0) % 2 == 1) return 1;
            foreach (var s in hazardList)
            {
                if (s == "")
                {
                    return 2;
                }
            }

            // 좌표로 받기 위해 2개 씩 이동
            for (int i = 0; i<hazardList.Length; i += 2)
            {
                // 좌표 저장할 임시 변수
                Pair<int, int> temp = new Pair<int, int>(Int32.Parse(hazardList[i]), Int32.Parse(hazardList[i + 1]));

                // 맵의 범위를 넘어선 경우 에러로 종료
                if (!isInMap(temp))
                    // 에러코드 1 : 위험지역 위치 오류
                    return 1;

                map[temp.First, temp.Second] = 1;
            }

            // 위험지역 띄어쓰기로 구분해서 저장
            string[] colorBlobList = colorBlobPos.Split(' ');
            // 짝수개가 아니면 에러
            if (colorBlobList.GetLength(0) % 2 == 1) return 1;
            foreach (var s in colorBlobList)
            {
                if (s == "")
                {
                    return 2;
                }
            }

            // 좌표로 받기 위해 2개 씩 이동
            for (int i = 0; i < colorBlobList.Length; i += 2)
            {
                // 좌표 저장할 임시 변수
                Pair<int, int> temp = new Pair<int, int>(Int32.Parse(colorBlobList[i]), Int32.Parse(colorBlobList[i + 1]));

                // 맵의 범위를 넘어선 경우 에러로 종료
                if (!isInMap(temp))
                    // 에러코드 1 : 위험지역 위치 오류
                    return 1;

                map[temp.First, temp.Second] = 3;
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
            // 현재 위치 세팅
            current = new Pair<int, int>(a, b);

            // 주요지점 띄어쓰기로 구분해서 저장
            string[] spotList = spotPos.Split(' ');

            // 짝수개가 아니면 에러
            if (spotList.GetLength(0) % 2 == 1) return 2;
            foreach (var s in spotList){
                if(s == "")
                {
                    return 2;
                }
            }

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
                // 맵과 주요지점 리스트에 주요지점 추가
                map[temp.First, temp.Second] = 2;
                spot.Add(temp);
            }
            // 경로 생성
            createPath();
            // 정상 종료
            return 0;
        }

        // 컬러블럽 추가 
        public static void addColorBlob(bool isColor)
        {
            if (isColor)
            {
                map[current.First, current.Second] = 4;
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
                        // 맵의 크기를 넘어서거나, 해당 지역이 0이 아닌경우 추가 안함
                        if ((!isInMap(new Pair<int, int>(current.First + 1, current.Second))) || (map[current.First - 1, current.Second] != 0)) break;
                        map[current.First - 1, current.Second] = 1;
                        break;
                    case 1:
                        if ((!isInMap(new Pair<int, int>(current.First, current.Second + 1))) || (map[current.First, current.Second + 1] != 0)) break;
                        map[current.First, current.Second + 1] = 1;
                        break;
                    case 2:
                        if ((!isInMap(new Pair<int, int>(current.First - 1, current.Second))) || (map[current.First + 1, current.Second] != 0)) break;
                        map[current.First + 1, current.Second] = 1;
                        break;
                    case 3:
                        if ((!isInMap(new Pair<int, int>(current.First, current.Second - 1))) || (map[current.First, current.Second - 1] != 0)) break;
                        map[current.First, current.Second - 1] = 1;
                        break;
                }
            }
        }

        // 맨앞에 있는 주요지점 경로 생성, 생성 안될경우 return 1
        public static int createPath()
        {
            List<Tile> Path;

            Path = Astar.createPath(current, spot[0], map);

            if (Path == null) return 1; // 경로 없음
            // 정상 종료
            path = Path;
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
