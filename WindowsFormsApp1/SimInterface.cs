using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SIM;

namespace WindowsFormsApp1
{
    Sim s = new Sim();
    class SimInterface
    {
        public void getHazardSensor() { }
        public void getColorBlobSensor() { }
        public void getPositionSensor() { }
        public void moveForward() { }
        public void rotation() {
            s.rotation();
        }
    }
}
