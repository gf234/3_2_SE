using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SimManager
    {
        SimInterface simInterface = new SimInterface();
        public void rotation(int head, int[] path) {
            for(int i = 0; i < path[0] - head; i++)
            {
                simInterface.rotation();
            }
        }
        public bool avoidingHazard()
        {
            bool ishazard = simInterface.getHazardSensor();
            if (ishazard)
            {
                // 위험지역이니 맵에게 알리는 코드
                return false;
            }
            else
                return true;
        }
        public void detectingColorBlob()
        {
            bool[] iscolor = simInterface.getColorBlobSensor();
            bool isin = false;
            for (int i = 0; i < iscolor.Length; i++)
            {
                if (iscolor[i] == true)
                    isin = true;
            }
            if (isin)
            {
                //컬러블럽이 나왔으니 맵으로 전달해주는 코드.
            }
        }
        public void compensateMotion(int head, int[] path)
        {
            // 맵에게 알리는 코드
        }
        public void keyPointSearch(int head,int[] path) {
            while (true)
            {
                // 경로 == List<Tile> 형식 --> path[i].X  :  행  ,  path[i].Y   :  열  <-- 이렇게 접근 가능 
                rotation(head, path);
                if (!avoidingHazard()) // 위험지역 나오면 다시 로테이션부터 시작
                    continue;
                detectingColorBlob();
                if (!simInterface.moveForward())
                {
                    compensateMotion(head, path);
                    continue;
                }
                // 스팟에 도착 안했으면 계속 ... 
                // 스팟에 도착 했으면(현재 경로의 끝) -> 스팟 리스트에서 맨앞에 있는거 삭제(도착했으니까) -> 다음 스팟이 없으면 -> 끝  
                //                                                                                        -> 다음 스팟까지의 경로 생성
                if (VerifyEnd(path))
                    break;
            }
        }
        // 남은 스팟이 없을때 끝나는 걸로 바꿔야함 ...
        public bool VerifyEnd(int[] path) {
            if (path.Length == 0)
                return true;
            else
                return false;
        }
    }
}
