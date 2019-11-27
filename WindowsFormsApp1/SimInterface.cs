using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SIM;

namespace WindowsFormsApp1
{
    class SimInterface
    {
        Sim s = new Sim();
        public bool getHazardSensor() {
            return s.HazardSensor();
        }
        public bool[] getColorBlobSensor() {
            return s.ColorBlobSensor();
        }
        public Pair<int,int> getPositionSensor() {
            return s.PositionSensor();
        }
        public void moveForward() {
            s.moveForward();
        }
        public void rotation() {
            s.rotation();
        }
        public void setMap(int[,] map)
        {
            s.setMap(map);
        }
    }
}
