using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    static class MapManager
    {
        public static void setMapInfo(int a,int b,string hazardPos) {
            switch(Map.setMapInfo(a, b, hazardPos))
            {
                case 0:
                    // 정상
                    break;
                case 1:
                    // 위험지역 오류
                    break;
            }

        }
        public static void setPathInfo(int a,int b,string spotPos) {
            switch (Map.setPathInfo(a, b, spotPos))
            {
                case 0:
                    // 정상
                    break;
                case 1:
                    // 시작점 오류
                    break;
                case 2:
                    // 주요지점 오류
                    break;
            }
        }
        public static void addColorBlob(bool[] bColorBlob) {
            Map.addColorBlob(bColorBlob);
        }
        public static void addHazard(bool newHazard) {
            Map.addHazard(newHazard);
        }
        public static void CreatePath() {
            if (Map.createPath()==1)
            {
                // 경로 없음
                // 디스플레이 해주고 종료
            }
        }

    }
}
