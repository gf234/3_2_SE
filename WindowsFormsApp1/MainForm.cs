using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        bool isMap = false;
        bool isPath = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            // 맵과 경로가 있는경우에만 창 표시
            if(isMap && isPath)
            {
                StartForm startForm = new StartForm();
                Task.Run(() => startForm.start());
                startForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("에러 : 맵과 경로를 먼저 입력하세요.");
            }
        }

        private void HandlingAMap_Click(object sender, EventArgs e)
        {
            MapForm mapForm = new MapForm();
            mapForm.ShowDialog();
            isMap = true;
            isPath = false;
        }

        private void PlanningAPath_Click(object sender, EventArgs e)
        {
            // 맵이 있는경우에만 창 표시
            if (isMap)
            {
                PathForm pathForm = new PathForm();
                pathForm.ShowDialog();
                isPath = true;
            }
            else
            {
                MessageBox.Show("에러 : 맵을 먼저 입력해 주세요.");
            }
        }
    }
}
