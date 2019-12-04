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
            System.Drawing.Bitmap spot = new Bitmap(@"C:\Users\hyunho\source\soft_engine\git4\3_2_SE\WindowsFormsApp1\image\ward.jpg");
            System.Drawing.Bitmap hazard = new Bitmap(@"C:\Users\hyunho\source\soft_engine\git4\3_2_SE\WindowsFormsApp1\image\baron2.png");
            System.Drawing.Bitmap colorblob1 = new Bitmap(@"C:\Users\hyunho\source\soft_engine\git4\3_2_SE\WindowsFormsApp1\image\question.jpg");
            System.Drawing.Bitmap colorblob2 = new Bitmap(@"C:\Users\hyunho\source\soft_engine\git4\3_2_SE\WindowsFormsApp1\image\teemo.png");
            System.Drawing.Bitmap robot0 = new Bitmap(@"C:\Users\hyunho\source\soft_engine\git4\3_2_SE\WindowsFormsApp1\image\sion0.png");
            System.Drawing.Bitmap robot1 = new Bitmap(@"C:\Users\hyunho\source\soft_engine\git4\3_2_SE\WindowsFormsApp1\image\sion1.png");
            System.Drawing.Bitmap robot2 = new Bitmap(@"C:\Users\hyunho\source\soft_engine\git4\3_2_SE\WindowsFormsApp1\image\sion2.png");
            System.Drawing.Bitmap robot3 = new Bitmap(@"C:\Users\hyunho\source\soft_engine\git4\3_2_SE\WindowsFormsApp1\image\sion3.png");

            //mapPictureBox.Image = bitmap;

            int width = (mapPictureBox.Size.Width-10) / Map.map.GetLength(1);
            int height = (mapPictureBox.Size.Height-10) / Map.map.GetLength(0);

            // 맵 그리기
            Rectangle Region;
            for(int i = 0; i<Map.map.GetLength(0); i++)
            {
                for(int j = 0; j<Map.map.GetLength(1); j++)
                {
                    // 아무것도 없으면 : 0 위험지역 : 1 탐색 지점 : 2  입력 받은 컬러블럽 : 3  지나간 컬러블럽 : 4
                    switch (Map.map[i,j])
                    {
                        case 0:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            e.Graphics.FillRectangle(new SolidBrush(Color.White), Region);
                            e.Graphics.DrawRectangle(new Pen(Color.DarkGray), Region);
                            break;
                        case 1:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            //e.Graphics.FillRectangle(new SolidBrush(Color.Red), Region);
                            //e.Graphics.DrawRectangle(new Pen(Color.DarkGray), Region);
                            e.Graphics.DrawImage(hazard, Region);
                            break;
                        case 2:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            //e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), Region);
                            //e.Graphics.DrawRectangle(new Pen(Color.DarkGray), Region);
                            e.Graphics.DrawImage(spot, Region);
                            break;
                        case 3:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            //e.Graphics.FillRectangle(new SolidBrush(Color.Gray), Region);
                            //e.Graphics.DrawRectangle(new Pen(Color.DarkGray), Region);
                            e.Graphics.DrawImage(colorblob1, Region);
                            break;
                        case 4:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            //e.Graphics.FillRectangle(new SolidBrush(Color.Green), Region);
                            //e.Graphics.DrawRectangle(new Pen(Color.DarkGray), Region);
                            e.Graphics.DrawImage(colorblob2, Region);
                            break;
                    }
                }
            }
            // 로봇 현재 위치
            Region = new Rectangle(new Point(Map.current.Second * width, Map.current.First * height), new Size(width, height));
            //e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), Region);
            //e.Graphics.DrawRectangle(new Pen(Color.DarkGray), Region);
            e.Graphics.DrawImage(robot0, Region);

            // 화살표 표시
            Pen pen = new Pen(Color.Blue, 5);
            pen.StartCap = LineCap.ArrowAnchor;
            switch (Map.head)
            {
                case 0:
                    //e.Graphics.DrawLine(pen, Region.X + Region.Width * 1 / 2, Region.Y + Region.Height * 1 / 4, Region.X + Region.Width * 1 / 2, Region.Y + Region.Height * 3 / 4);
                    e.Graphics.DrawImage(robot0, Region);
                    break;
                case 3:
                    //e.Graphics.DrawLine(pen, Region.X + Region.Width * 1 / 4, Region.Y + Region.Height * 1 / 2, Region.X + Region.Width * 3 / 4, Region.Y + Region.Height * 1 / 2);
                    e.Graphics.DrawImage(robot3, Region);
                    break;
                case 2:
                    //e.Graphics.DrawLine(pen, Region.X + Region.Width * 1 / 2, Region.Y + Region.Height * 3 / 4, Region.X + Region.Width * 1 / 2, Region.Y + Region.Height * 1 / 4);
                    e.Graphics.DrawImage(robot2, Region);
                    break;
                case 1:
                    //e.Graphics.DrawLine(pen, Region.X + Region.Width * 3 / 4, Region.Y + Region.Height * 1 / 2, Region.X + Region.Width * 1 / 4, Region.Y + Region.Height * 1 / 2);
                    e.Graphics.DrawImage(robot1, Region);
                    break;
            }
        }
        //public void start()
        //{
        //    SimManager simManager = new SimManager();
        //    simManager.keyPointSearch(this);
        //}
        public async Task start()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000); // 1초쉬고 시작
                SimManager simManager = new SimManager();
                simManager.keyPointSearch(this);
                MessageBox.Show("탐색 완료!");
            });
        }
        // 로테이션 반응
        // 하자드 반응
        // 컬러블럽 반응
        // 무브 반응
        // 엔드 반응
        public void display()
        {
            mapPictureBox.Invalidate();
        }
    }
}
