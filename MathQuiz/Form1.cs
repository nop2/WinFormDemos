namespace MathQuiz
{
    public partial class Form1 : Form
    {
        // �����������
        private readonly Random randomizer = new Random();

        // ��������
        private int addend1;
        private int addend2;

        private int minuend;
        private int subtrahend;

        private int multiplicand;
        private int multiplier;

        private int dividend;
        private int divisor;

        // ʣ��ش�ʱ��
        private int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51); // 0-50
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            var temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 ��";
            timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private bool CheckAnswer() => addend1 + addend2 == sum.Value
                                      && minuend - subtrahend == difference.Value
                                      && multiplicand * multiplier == product.Value
                                      && (int)(dividend / divisor) == quotient.Value;


        /// <summary>
        /// ÿ��1s����һ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckAnswer())
            {
                timer1.Stop();
                MessageBox.Show("����ˣ�");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                --timeLeft;
                timeLabel.Text = $"{timeLeft} ��";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "ʱ�䵽��";
                MessageBox.Show("����ʧ�ܣ�");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        // ���»س����������
        private void answer_Enter(object sender, EventArgs e)
        {
            // This parameter refers to the object whose event is firing, which is known as the sender. In this case, the sender object is the NumericUpDown control.
            if (sender is not NumericUpDown answerBox) return;

            var lengthOfAnswer = answerBox.Value.ToString().Length;
            answerBox.Select(0,lengthOfAnswer);
        }
    }
}