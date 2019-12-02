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
                            e.Graphics.FillRectangle(new SolidBrush(Color.Red), Region);
                            e.Graphics.DrawRectangle(new Pen(Color.DarkGray), Region);
                            break;
                        case 2:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), Region);
                            e.Graphics.DrawRectangle(new Pen(Color.DarkGray), Region);
                            break;
                        case 3:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), Region);
                            e.Graphics.DrawRectangle(new Pen(Color.DarkGray), Region);
                            break;
                        case 4:
                            Region = new Rectangle(new Point(j * width, i * height), new Size(width, height));
                            e.Graphics.FillRectangle(new SolidBrush(Color.Green), Region);
                            e.Graphics.DrawRectangle(new Pen(Color.DarkGray), Region);
                            break;
                    }
                }
            }
            // 로봇 현재 위치
            Region = new Rectangle(new Point(Map.current.Second * width, Map.current.First * height), new Size(width, height));
            e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), Region);
            e.Graphics.DrawRectangle(new Pen(Color.DarkGray), Region);
            
            // 화살표 표시
            Pen pen = new Pen(Color.Blue, 5);
            pen.StartCap = LineCap.ArrowAnchor;
            switch (Map.head)
            {
                case 0:
                    e.Graphics.DrawLine(pen, Region.X + Region.Width * 1 / 2, Region.Y + Region.Height * 1 / 4, Region.X + Region.Width * 1 / 2, Region.Y + Region.Height * 3 / 4);
                    break;
                case 3:
                    e.Graphics.DrawLine(pen, Region.X + Region.Width * 1 / 4, Region.Y + Region.Height * 1 / 2, Region.X + Region.Width * 3 / 4, Region.Y + Region.Height * 1 / 2);
                    break;
                case 2:
                    e.Graphics.DrawLine(pen, Region.X + Region.Width * 1 / 2, Region.Y + Region.Height * 3 / 4, Region.X + Region.Width * 1 / 2, Region.Y + Region.Height * 1 / 4);
                    break;
                case 1:
                    e.Graphics.DrawLine(pen, Region.X + Region.Width * 3 / 4, Region.Y + Region.Height * 1 / 2, Region.X + Region.Width * 1 / 4, Region.Y + Region.Height * 1 / 2);
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
                Thread.Sleep(2000); // 2초쉬고 시작
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
