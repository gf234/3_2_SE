using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SimManager
    {
        SimInterface simInterface = new SimInterface();
        public void rotation(int head, int[] path) {
            for(int i = 0; i < path[0] - head; i++)
            {
                simInterface.rotation();
            }
        }
        public void avoidingHazard() {
            bool ishazard=simInterface.getHazardSensor();
        }
        public void detectingColorBlob() {
            bool[] iscolor=simInterface.getColorBlobSensor();
        }
        public void compensateMotion() { }
        public void keyPointSearch(int head,int[] path) {
            while (true)
            {
                rotation(head,path);
                avoidingHazard();
                detectingColorBlob();
                simInterface.moveForward();
                compensateMotion();
                if (VerifyEnd(path))
                    break;
            }
        }
        public bool VerifyEnd(int[] path) {
            if (path.Length == 0)
                return true;
            else
                return false;
        }
    }
}
