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
        int sleepTime = 500; // 1초 슬립
        SimInterface simInterface = new SimInterface();
        public void rotation(StartForm startForm)
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
                set_head();
                // StartForm에 회전 디스플레이 띄우기
                startForm.display();
                Thread.Sleep(sleepTime);
            }
        }
        public bool avoidingHazard(StartForm startForm)
        {
            bool ishazard = simInterface.getHazardSensor();
            if (ishazard)
            {
                // 위험지역이니 맵에게 알리는 코드
                Map.addHazard(ishazard);
                // StartForm에 위험지역 디스플레이 띄우기
                startForm.display();
                Thread.Sleep(sleepTime);
                Map.createPath();
                return false;
            }
            else
                return true;
        }
        public void detectingColorBlob()
        {
            bool iscolor = simInterface.getColorBlobSensor();
            Map.addColorBlob(iscolor);
        }
        public void compensateMotion()
        {
            // 맵에게 알리는 코드
            Map.createPath();
        }
        public void keyPointSearch(StartForm startForm)
        {
            while (true)
            {
                Thread.Sleep(sleepTime);
                // 경로 == List<Tile> 형식 --> path[i].X  :  행  ,  path[i].Y   :  열  <-- 이렇게 접근 가능 
                rotation(startForm);
                if (!avoidingHazard(startForm)) // 위험지역 나오면 다시 로테이션부터 시작
                    continue;
                detectingColorBlob();
                // 오작동 했다면
                bool moveCorrect = simInterface.moveForward();
                set_cur();
                startForm.display();
                Map.path.RemoveAt(0); // 제대로 움직였으니 첫번째 패스 삭제
                if (!moveCorrect)
                {
                    compensateMotion(); // 경로 재설정
                    
                }
                // 스팟에 도착 안했으면 계속 ... 
                // 스팟에 도착 했으면(현재 경로의 끝) -> 스팟 리스트에서 맨앞에 있는거 삭제(도착했으니까) -> 다음 스팟이 없으면 -> 끝

                if (Map.current.First == Map.spot[0].First && Map.current.Second == Map.spot[0].Second)
                {
                    Map.spot.RemoveAt(0);
                    // 끝났으면
                    if (VerifyEnd())
                    {
                        Console.WriteLine("Successed!!!");
                        break;
                    }
                    else
                    {
                        Map.createPath();
                    }
                }
                
            }
            
        }

        // 모두 끝났는지 확인
        public bool VerifyEnd()
        {
            if (Map.spot.Count() == 0)
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
