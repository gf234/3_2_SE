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
    public partial class MapForm : Form
    {
        public MapForm()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {

            if (Map.setMapInfo(Decimal.ToInt32(rowNumericUpDown.Value), Decimal.ToInt32(columnNumericUpDown.Value), hazardPositionBox.Text, colorBlobPositionBox.Text) == 1)
            {
                // 위험지역이 맵 범위를 넘어선 경우 에러창 띄우고
                MessageBox.Show("에러 : 올바른 좌표의 위험지역을 입력해 주세요.");
            }
            else
            {
                // 정상 입력인경우 창 종료
                this.Close();
            }
        }

        // 숫자만 입력 받기
        private void HazardPositionBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(Keys.Space)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void ColorBlobPositionBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(Keys.Space)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
    }
}
