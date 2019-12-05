using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }
    
        private void MapPictureBox_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Bitmap spot = new Bitmap(@"..\..\image\flag.png");
            System.Drawing.Bitmap hazard = new Bitmap(@"..\..\image\hazard.png");
            System.Drawing.Bitmap colorblob1 = new Bitmap(@"..\..\image\closed_box.png");
            System.Drawing.Bitmap colorblob2 = new Bitmap(@"..\..\image\coin.png");
            System.Drawing.Bitmap robot0 = new Bitmap(@"..\..\image\sion0.png");
            System.Drawing.Bitmap robot1 = new Bitmap(@"..\..\image\sion1.png");
            System.Drawing.Bitmap robot2 = new Bitmap(@"..\..\image\sion2.png");
            System.Drawing.Bitmap robot3 = new Bitmap(@"..\..\image\sion3.png");
            System.Drawing.Bitmap flag2 = new Bitmap(@"..\..\image\flag2.png");


            int width = (mapPictureBox.Size.Width-10) / MapManager.getMap().GetLength(1);
            int height = (mapPictureBox.Size.Height-10) / MapManager.getMap().GetLength(0);

            // 맵 그리기
            Rectangle Region;
            for(int i = 0; i< MapManager.getMap().GetLength(0); i++)
            {
                for(int j = 0; j< MapManager.getMap().GetLength(1); j++)
                {
                    // 아무것도 없으면 : 0 위험지역 : 1 탐색 지점 : 2  입력 받은 컬러블럽 : 3  지나간 컬러블럽 : 4 지나간 탐색지점 : 5
                    switch (MapManager.getMap()[i,j])
                    {
                        case 0:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            e.Graphics.FillRectangle(new SolidBrush(Color.White), Region);
                            e.Graphics.DrawRectangle(new Pen(Color.DarkGray), Region);
                            break;
                        case 1:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            e.Graphics.DrawImage(hazard, Region);
                            break;
                        case 2:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            e.Graphics.DrawImage(spot, Region);
                            break;
                        case 3:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            e.Graphics.DrawImage(colorblob1, Region);
                            break;
                        case 4:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            e.Graphics.DrawImage(colorblob2, Region);
                            break;
                        case 5:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            e.Graphics.DrawImage(flag2, Region);
                            break;
                    }
                }
            }
            // 로봇 현재 위치
            Region = new Rectangle(new Point(MapManager.getCurrent().Second * width, MapManager.getCurrent().First * height), new Size(width, height));
            e.Graphics.DrawImage(robot0, Region);

            // 화살표 표시
            switch (MapManager.getHead())
            {
                case 0:
                    e.Graphics.DrawImage(robot0, Region);
                    break;
                case 3:
                    e.Graphics.DrawImage(robot3, Region);
                    break;
                case 2:
                    e.Graphics.DrawImage(robot2, Region);
                    break;
                case 1:
                    e.Graphics.DrawImage(robot1, Region);
                    break;
            }
        }
        
        // 비동기 함수
        public async Task start()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000); // 1초쉬고 시작
                SimManager simManager = new SimManager();
                if (!simManager.keyPointSearch(this))
                    MessageBox.Show("경로 없음!");
                MessageBox.Show("탐색 완료!");
            });
        }

        // 이동하거나 맵이 바뀌면 gui에 표시
        public void display()
        {
            mapPictureBox.Invalidate();
        }
    }
}
