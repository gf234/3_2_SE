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
    public partial class PathForm : Form
    {
        public PathForm()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            int errCode;
            // 에러 1인경우 시작 지점 에러
            if ((errCode = Map.setPathInfo(Decimal.ToInt32(startRowNumericUpDown.Value), Decimal.ToInt32(startColumnNumericUpDown.Value), spotTextBox.Text)) == 1)
            {
                MessageBox.Show("에러 : 맵 크기에 맞는 시작지점을 입력해 주세요.");
            }
            // 에러 1인경우 주요 지점 에러
            else if (errCode == 2)
            {
                MessageBox.Show("에러 : 올바른 좌표의 주요지점을 입력해 주세요.");
            }
            else
            {
                // 정상 입력인경우 창 종료
                this.Close();
            }
        }

        // 숫자만 입력 받기
        private void SpotTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(Keys.Space)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
    }
}
