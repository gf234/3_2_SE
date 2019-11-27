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

    class Sim
    {
        float errRate = 0.1f;
        int head = 0;
        // 현재위치를 심이 받아와야해
        Pair<int, int> cur = new Pair<int, int>(0, 0);
        // 맵 상태를 받아와야해
        int[,] map;
        // 상우하좌
        int[,] move = new int[4, 2] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        // set은 다 출력
        public bool HazardSensor()
        {
            int row = cur.First + move[head, 0];
            int col = cur.Second + move[head, 1];
            // 2를 위험지역이라고 할게
            if (map[row, col] == 2)
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
                // 1을 ColoBlob이라고 할게
                if (map[row, col] == 1)
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
            Random r = new Random();
            // 정상적으로 동작할때
            if (100 * errRate < r.Next(1, 100))
            {
                cur.First += move[head, 0];
                cur.Second += move[head, 1];
            }
            // 오작동 시
            else
            {
                cur.First += 2 * move[head, 0];
                cur.Second += 2 * move[head, 1];
            }
        }
        public int rotation()
        {
            // 머리방향은 상우하좌 0123
            head = (head + 1) % 4;
            return head;
        }
    }