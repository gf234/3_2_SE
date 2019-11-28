using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /*
     * 키포인트 서치를 실행시키면 맵매니저에게 헤드랑 패스를 지정받아.
     * 0번 패스에 맞게 헤드를 돌리고
     * 심에게 하자드를 받아와서 하자드라면 맵에게 알리고 다시 로테이션부터 실행해.
     * 심에게 컬러블럽을 받아와서 컬러블럽이라면 맵에게 알리고 그냥 진행해.
     * 이제 심에게 무브 명령을 내려
     * 심에게 현재 위치를 받아와서 위치가 다르다면 맵에게 알리고 다시 로테이션부터 실행해.
     * 정상적으로 움직였다면 패스를 1칸줄여(방금 움직인거야)
     * 패스가 0이라면 도착이니 스타트로 알려.
     */
    class SimManager
    {
        SimInterface simInterface = new SimInterface();
        public void rotation(int head, int[] path) {
            for(int i = 0; i < path[0] - head; i++)
            {
                simInterface.rotation();
            }
        }
        public bool avoidingHazard() {
            bool ishazard=simInterface.getHazardSensor();
            if (ishazard)
            {
                // 위험지역이니 맵에게 알리는 코드
                return false;
            }
            else
                return true;
        }
        public void detectingColorBlob() {
            bool[] iscolor=simInterface.getColorBlobSensor();
            bool isin = false;
            for(int i = 0; i < iscolor.Length; i++)
            {
                if (iscolor[i] == true)
                    isin = true;
            }
            if (isin)
            {
                //컬러블럽이 나왔으니 맵으로 전달해주는 코드.
            }
        }
        public void compensateMotion(int head,int[] path) {
            // 맵에게 알리는 코드
        }
        public void keyPointSearch(int head,int[] path) {
            while (true)
            {
                rotation(head,path);
                if (!avoidingHazard()) // 위험지역 나오면 다시 로테이션부터 시작
                    continue;
                detectingColorBlob();
                if (!simInterface.moveForward())
                {
                    compensateMotion(head, path);
                    continue;
                }
                if (VerifyEnd(path))
                    break;
            }
        }
        public bool VerifyEnd(int[] path) {
            if (path.Length == 0)
                return true;
            else
                return false;
        }
    }
}
