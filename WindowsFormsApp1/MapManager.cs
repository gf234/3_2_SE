using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    static class MapManager
    {
        public static int setMapInfo(int a,int b,string hazardPos,string colorBlobPos) {
            return Map.setMapInfo(a, b, hazardPos, colorBlobPos);
        }
        public static int setPathInfo(int a,int b,string spotPos) {
            return Map.setPathInfo(a, b, spotPos);
        }
        public static void addColorBlob(bool isColor) {
            Map.addColorBlob(isColor);
        }
        public static void addHazard(bool newHazard) {
            Map.addHazard(newHazard);
        }
        public static int CreatePath() {
            return Map.createPath();
        }
        public static int[,] getMap()
        {
            return Map.map;
        }
        public static List<Tile> getPath()
        {
            return Map.path;
        }
        public static int getHead()
        {
            return Map.head;
        }
        public static void setHead(int head)
        {
            Map.head=head;
        }
        public static Pair<int,int> getCurrent()
        {
            return Map.current;
        }
        public static void setCurrent(Pair<int,int> map)
        {
            Map.current=map;
        }
        public static List<Pair<int,int>> getSpot()
        {
            return Map.spot;
        }
        public static bool isInMap(Pair<int,int> pos)
        {
            return Map.isInMap(pos);
        }
    }
}
