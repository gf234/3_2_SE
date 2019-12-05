using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace WindowsFormsApp1
{
    // A* 알고리즘 계산을 위한 한 칸을 나타내는 클래스
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int F { get { return G + H; } }
        public int G { get; private set; } // Start ~ Current
        public int H { get; private set; } // Current ~ End
        public Tile Parent { get; private set; }
        public void Execute(Tile parent, Tile endTile)
        {
            Parent = parent;
            G = CalcGValue(parent, this);
            int diffX = Math.Abs(endTile.X - X);
            int diffY = Math.Abs(endTile.Y - Y);
            H = (diffX + diffY) * 10;
        }
        public static int CalcGValue(Tile parent, Tile current)
        {
            int diffX = Math.Abs(parent.X - current.X);
            int diffY = Math.Abs(parent.Y - current.Y);
            int value = 10;
            if (diffX == 1 && diffY == 1)
            {
                value = 14;
            }
            return parent.G + value;
        }
    }

    // 최단 경로를 찾는 A* 알고리즘
    class Astar
    {       
        public static List<Tile> createPath(Pair<int, int> start, Pair<int, int> end, int[,] area)
        {
            // 위험지역
            int obstacle = 1;
            List<List<Tile>> tiles = new List<List<Tile>>();
            List<Tile> openList = new List<Tile>();
            List<Tile> closeList = new List<Tile>();
            List<Tile> path = new List<Tile>();
            Tile startTile = null;
            Tile targetTile = null;
            // 값 초기화
            for (int i = 0; i < area.GetLength(0); i++)
            {
                List<Tile> t = new List<Tile>();
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    Tile temp = new Tile();
                    temp.X = i;
                    temp.Y = j;
                    t.Add(temp);
                    // 주요 지점
                    if ((i == end.First) && (j == end.Second))
                    {
                        targetTile = temp;
                    }
                }
                tiles.Add(t);
            }
            // 시작점
            startTile = tiles[start.First][start.Second];
            openList.Add(startTile);
            if (targetTile == null)
            {
                // 타겟을 못찾는 경우
                return null;
            }
            Tile currentTile = null;
            do
            {
                if (openList.Count == 0)
                {
                    break;
                }
                currentTile = openList.OrderBy(o => o.F).First();
                openList.Remove(currentTile);
                closeList.Add(currentTile);
                if (currentTile == targetTile)
                {
                    break;
                }
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        // 상, 하, 좌, 우 탐색
                        bool near = (Math.Abs(currentTile.X - tiles[i][j].X) <= 1)
                                 && (Math.Abs(currentTile.Y - tiles[i][j].Y) <= 1)
                                 && (currentTile.Y == tiles[i][j].Y || currentTile.X == tiles[i][j].X);
                        if (area[i, j] == obstacle
                         || closeList.Contains(tiles[i][j])
                         || (!near))
                        {
                            continue;
                        }
                        if (!openList.Contains(tiles[i][j]))
                        {
                            openList.Add(tiles[i][j]);
                            tiles[i][j].Execute(currentTile, targetTile);
                        }
                        else
                        {
                            if (Tile.CalcGValue(currentTile, tiles[i][j]) < tiles[i][j].G)
                            {
                                tiles[i][j].Execute(currentTile, targetTile);
                            }
                        }
                    }
                }
            } while (currentTile != null);
            if (currentTile != targetTile)
            {
                // 길을 찾지 못한는 경우
                return null;
            }
            do
            {
                path.Add(currentTile);
                currentTile = currentTile.Parent;
            }
            while (currentTile != null);
            path.Reverse();
            // 시작점은 제외
            path.RemoveAt(0);
            return path;
        }

    }
}
