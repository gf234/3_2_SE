using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    // 순서쌍 클래스
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };

    public class Sim
    {
        public Sim()
        {
        }
        float errRate = 0.05f;
        int head = 0;
        // 현재위치를 심이 받아와야해
        Pair<int, int> cur = MapManager.getCurrent();
        // 바로 맵 상태를 받아와
        int[,] map = MapManager.getMap();
        // 상우하좌
        int[,] move = new int[4, 2] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
        Random r = new Random();
        // set map 삭제
        public bool HazardSensor()
        {
            int row = cur.First + move[head, 0];
            int col = cur.Second + move[head, 1];
            // 3% 확률로 에러
            if (errRate*100 >= r.Next(1, 100))
                return true;
            else
                return false;
        }
        public bool ColorBlobSensor()
        {
            if (MapManager.getMap()[cur.First, cur.Second] == 3)
                return true;

            return false;
        }
        public Pair<int, int> PositionSensor()
        {
            return cur;
        }
        // 두개는 
        public bool moveForward()
        {
            // 오작동 시 앞에 벽이면 오작동 안되게
            if (100 * errRate > r.Next(1, 100) && MapManager.isInMap(new Pair<int, int>(cur.First + 2 * move[head, 0],cur.Second + 2 * move[head, 1]))
                && MapManager.getMap()[cur.First + 2 * move[head, 0], cur.Second + 2 * move[head, 1]]!=2)
            {
                cur.First += 2 * move[head, 0];
                cur.Second += 2 * move[head, 1];
                return false;
            }
            // 정상적으로 동작할때
            else
            {
                cur.First += move[head, 0];
                cur.Second += move[head, 1];
                return true;
            }

        }
        public int rotation()
        {
            // 머리방향은 상우하좌 0123
            head = (head + 1) % 4;
            return head;
        }
    }
}