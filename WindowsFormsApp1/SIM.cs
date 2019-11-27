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
        Pair<int, int> cur = new Pair<int, int>(0, 0);
        // 맵 상태를 받아와야해
        int[,] map;
        // 상우하좌
        int[,] move = new int[4, 2] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        Random r = new Random();
        // set은 다 출력
        public void setMap(int[,] new_map)
        {
            map = (int[,])new_map.Clone();
            /*
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    map[i, j] = m[i, j];
                    */
        }
        public bool HazardSensor()
        {
            int row = cur.First + move[head, 0];
            int col = cur.Second + move[head, 1];
            // 3% 확률로 에러
            if (3<r.Next(1, 100))
                return true;
            else
                return false;
        }
        public bool[] ColorBlobSensor()
        {
            bool[] isColor = new bool[4] { false, false, false, false };
            for (int i = 0; i < 4; i++)
            {
                int row = cur.First + move[i, 0];
                int col = cur.Second + move[i, 1];
                // 컬러블럽 확률 2%
                if (3 > r.Next(1, 100))
                    isColor[i] = true;
            }
            return isColor;
        }
        public Pair<int, int> PositionSensor()
        {
            return cur;
        }
        // 두개는 
        public void moveForward()
        {
            // 오작동 시 앞에 벽이면 오작동 안되게
            if ((move[head, 0] != -1) && (move[head, 1] != -1) && (100 * errRate > r.Next(1, 100)))
            {
                cur.First += 2 * move[head, 0];
                cur.Second += 2 * move[head, 1];
            }
            // 정상적으로 동작할때
            else
            {
                cur.First += move[head, 0];
                cur.Second += move[head, 1];
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