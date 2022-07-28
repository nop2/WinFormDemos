namespace MatchingGame
{
    public partial class Form1 : Form
    {
        private Random random = new Random();

        private List<string> icons = new()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        private Label firstClicked = null;
        private Label secondClicked = null;

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        /// <summary>
        /// ��Ԫ�����ͼ��
        /// </summary>
        private void AssignIconsToSquares()
        {
            foreach (var control in tableLayoutPanel1.Controls)
            {
                if (control is not Label iconLabel) continue;
                var randomNumber = random.Next(icons.Count);
                iconLabel.Text = icons[randomNumber];
                // ����ͼ��
                iconLabel.ForeColor = iconLabel.BackColor;
                icons.RemoveAt(randomNumber);
            }
        }

        /// <summary>
        /// ͼ��ĵ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_Click(object sender, EventArgs e)
        {
            // �ڼ�ʱ��δ���У���û�е�������ε�ʱ��
            // ȷ��ֻ�ܵ������
            if(timer1.Enabled) return;

            if (sender is not Label clickedLabel) return;

            // �Ѿ������ɵĲ��ٴ���
            if (clickedLabel.ForeColor == Color.Black)
            {
                return;
            }

            // ��һ��ѡ�񣬲�������ʱ����
            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                clickedLabel.ForeColor = Color.Black;
                return;
            }

            // �ڶ���ѡ��,������֣�ͬʱ������ʱ��
            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            CheckWinner();

            // �������ͼ����ͬ����������ʱ��������ʧ
            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                return;
            }

            timer1.Start();
        }

        /// <summary>
        /// �����Ѿ����������ͼ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void CheckWinner()
        {
            foreach (var control in tableLayoutPanel1.Controls)
            {
                if (control is Label iconLabel)
                {
                    // ��Ȼ�е�Ԫû�е��
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                    {
                        return;
                    }
                }
            }

            MessageBox.Show("��Ӯ�ˣ�", "ף��");
            Close();
        }
    }
}