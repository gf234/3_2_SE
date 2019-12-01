using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class SimManager
    {
        // 초기 머리방향 위쪽
        int head = 0;
        int sleepTime = 1000; // 1초 슬립
        SimInterface simInterface = new SimInterface();
        public void rotation()
        {
            if (Map.path.Count == 0) {
                Console.WriteLine("path 0 err");
                Application.ExitThread();
                Environment.Exit(0);
            }
            int x = Map.current.First - Map.path[0].X;
            int y = Map.path[0].Y - Map.current.Second;
            int forward = 0; // 진행할 방향
            if (x == 1 && y == 0)
            {
                forward = 0;
            }
            else if (x == 0 && y == 1)
            {
                forward = 1;
            }
            else if (x == -1 && y == 0)
            {
                forward = 2;
            }
            else if (x == 0 && y == -1)
            {
                forward = 3;
            }
            // 진행할 방향으로 헤드 돌리기
            while (head != forward)
            {
                head = (head + 1) % 4;
                simInterface.rotation();
                // StartForm에 회전 디스플레이 띄우기
                Thread.Sleep(sleepTime);
            }
        }
        public bool avoidingHazard()
        {
            bool ishazard = simInterface.getHazardSensor();
            if (ishazard)
            {
                // 위험지역이니 맵에게 알리는 코드
                Map.addHazard(ishazard);
                // StartForm에 위험지역 디스플레이 띄우기
                Thread.Sleep(sleepTime);
                Map.createPath();
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
                // 컬러블럽을 맵에게 알리는 코드
                Map.addColorBlob(iscolor);
                // StartForm에 컬러블럽 디스플레이 띄우기
                Thread.Sleep(sleepTime);
            }
        }
        public void compensateMotion()
        {
            // 맵에게 알리는 코드
            Map.createPath();
        }
        public void keyPointSearch()
        {
            Thread.Sleep(sleepTime);
            while (true)
            {
                // 경로 == List<Tile> 형식 --> path[i].X  :  행  ,  path[i].Y   :  열  <-- 이렇게 접근 가능 
                rotation();
                if (!avoidingHazard()) // 위험지역 나오면 다시 로테이션부터 시작
                    continue;
                detectingColorBlob();
                // 오작동 했다면
                if (!simInterface.moveForward())
                {
                    compensateMotion();
                    continue;
                }
                // 스팟에 도착 안했으면 계속 ... 
                // 스팟에 도착 했으면(현재 경로의 끝) -> 스팟 리스트에서 맨앞에 있는거 삭제(도착했으니까) -> 다음 스팟이 없으면 -> 끝
                // 스팟이면 스팟 하나 삭제
                set_cur();
                set_head();
                if (Map.current.First == Map.spot[0].First && Map.current.Second == Map.spot[0].Second)
                    Map.spot.RemoveAt(0);
                Map.path.RemoveAt(0); // 제대로 움직였으니 첫번째 패스 삭제
                if (VerifyEnd()){
                    Console.WriteLine("Successed!!!");
                    Application.ExitThread();
                    Environment.Exit(0);
                }
                if (Map.path.Count == 0)
                    Map.createPath();
            }
        }
        // 남은 스팟이 없을때 끝나는 걸로 바꿔야함 ...
        public bool VerifyEnd()
        {
            if (Map.spot.Count() == 0)
                // StartForm에 엔드알림
                return true;
            else
                return false;
        }
        // 맵에서 받을 헤드
        public void set_head()
        {
            Map.head=head;
        }
        // 맵에서 받을 현재위치
        public void set_cur()
        {
            Map.current=simInterface.getPositionSensor();
        }
    }
}
