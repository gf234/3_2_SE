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
        Sim sim = new Sim();
        public bool getHazardSensor() {
            return sim.HazardSensor();
        }
        public bool[] getColorBlobSensor() {
            return sim.ColorBlobSensor();
        }
        public Pair<int,int> getPositionSensor() {
            return sim.PositionSensor();
        }
        public bool moveForward() {
            return sim.moveForward();
        }
        public void rotation() {
            sim.rotation();
        }
        public void setMap(int[,] map)
        {
            sim.setMap(map);
        }
    }
}
