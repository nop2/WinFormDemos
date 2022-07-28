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
        /// 向单元格分配图标
        /// </summary>
        private void AssignIconsToSquares()
        {
            foreach (var control in tableLayoutPanel1.Controls)
            {
                if (control is not Label iconLabel) continue;
                var randomNumber = random.Next(icons.Count);
                iconLabel.Text = icons[randomNumber];
                // 隐藏图标
                iconLabel.ForeColor = iconLabel.BackColor;
                icons.RemoveAt(randomNumber);
            }
        }

        /// <summary>
        /// 图标的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_Click(object sender, EventArgs e)
        {
            // 在计时器未运行，即没有点击完两次的时候
            // 确保只能点击两个
            if(timer1.Enabled) return;

            if (sender is not Label clickedLabel) return;

            // 已经点击完成的不再处理
            if (clickedLabel.ForeColor == Color.Black)
            {
                return;
            }

            // 第一次选择，不启动计时器器
            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                clickedLabel.ForeColor = Color.Black;
                return;
            }

            // 第二次选择,让其出现，同时启动计时器
            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            CheckWinner();

            // 如果两个图标相同，则不启动计时器让其消失
            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                return;
            }

            timer1.Start();
        }

        /// <summary>
        /// 隐藏已经点击的两个图标
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
                    // 仍然有单元没有点击
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                    {
                        return;
                    }
                }
            }

            MessageBox.Show("你赢了！", "祝贺");
            Close();
        }
    }
}