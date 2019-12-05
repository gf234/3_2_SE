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
            if (MapManager.getPath().Count == 0) {
                Console.WriteLine("path 0 err");
                Application.ExitThread();
                Environment.Exit(0);
            }
            int x = MapManager.getCurrent().First - MapManager.getPath()[0].X;
            int y = MapManager.getPath()[0].Y - MapManager.getCurrent().Second;
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
                MapManager.addHazard(ishazard);
                // StartForm에 위험지역 디스플레이 띄우기
                startForm.display();
                Thread.Sleep(sleepTime);
                return false;
            }
            else
                return true;
        }
        public void detectingColorBlob()
        {
            bool iscolor = simInterface.getColorBlobSensor();
            MapManager.addColorBlob(iscolor);
        }
        public bool compensateMotion()
        {
            // 맵에게 알리는 코드
            if (MapManager.CreatePath() == 0)
                return true;
            else
                return false;
        }
        public bool keyPointSearch(StartForm startForm)
        {
            while (true)
            {
                Thread.Sleep(sleepTime);
                // 경로 == List<Tile> 형식 --> path[i].X  :  행  ,  path[i].Y   :  열  <-- 이렇게 접근 가능 
                rotation(startForm);
                if (!avoidingHazard(startForm)) // 위험지역 나오면 다시 로테이션부터 시작
                {
                    if (MapManager.CreatePath() == 1)
                        return false;
                    continue;
                }
                detectingColorBlob();
                // 오작동 했다면
                bool moveCorrect = simInterface.moveForward();
                set_cur();
                startForm.display();
                MapManager.getPath().RemoveAt(0); // 제대로 움직였으니 첫번째 패스 삭제
                if (!moveCorrect)
                {
                    if (!compensateMotion()) // 경로 재설정
                        return false;
                }

                // 스팟에 도착했는지 검사
                if (MapManager.getCurrent().First == MapManager.getSpot()[0].First && MapManager.getCurrent().Second == MapManager.getSpot()[0].Second)
                {
                    // 스팟 지나가면 깃발 바꾸기
                    MapManager.getMap()[MapManager.getSpot()[0].First, MapManager.getSpot()[0].Second] = 5;
                    MapManager.getSpot().RemoveAt(0);
                    // 끝났으면
                    if (VerifyEnd())
                    {
                        Console.WriteLine("Successed!!!");
                        break;
                    }
                    else
                    {
                        MapManager.CreatePath();
                    }
                }
                
            }
            return true;
        }

        // 모두 끝났는지 확인
        public bool VerifyEnd()
        {
            if (MapManager.getSpot().Count() == 0)
                return true;
            else
                return false;
        }
        // 맵에서 받을 헤드
        public void set_head()
        {
            MapManager.setHead(head);
        }
        // 맵에서 받을 현재위치
        public void set_cur()
        {
            MapManager.setCurrent(simInterface.getPositionSensor());
        }
    }
}
