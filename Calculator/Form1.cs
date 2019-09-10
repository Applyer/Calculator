using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double FirstNumber;  // 最初の数値
        string Operation;   // 演算子
        bool dotCheck = false;  // "."が押されたフラグ
        bool errorMsg = false;  // エラーメッセージが出たフラグ
        bool endCalc = false;   // 演算終了時フラグ

        public Form1()
        {
            InitializeComponent();
        }

        // 表示画面とフラグの初期化
        public void Init()
        {
            textBox1.Text = "0";
            dotCheck = false;
            errorMsg = false;
            endCalc = false;
        }

        // 1をクリックした時
        private void n1_Click(object sender, EventArgs e)
        {
            // 0かエラーメッセージもしくは演算終了時なら1を表示
            if (textBox1.Text == "0" || errorMsg || endCalc)
            {
                textBox1.Text = "1";
            }
            else    // それ以外なら1を右に追加
            {
                textBox1.Text = textBox1.Text + "1";
            }
        }

        // 2をクリックした時
        private void n2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || errorMsg || endCalc)
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text = textBox1.Text + "2";
            }
        }

        // 3をクリックした時
        private void n3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || errorMsg || endCalc)
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text = textBox1.Text + "3";
            }
        }

        // 4をクリックした時
        private void n4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || errorMsg || endCalc)
            {
                textBox1.Text = "4";
            }
            else
            {
                textBox1.Text = textBox1.Text + "4";
            }
        }

        // 5をクリックした時
        private void n5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || errorMsg || endCalc)
            {
                textBox1.Text = "5";
            }
            else
            {
                textBox1.Text = textBox1.Text + "5";
            }
        }

        // 6をクリックした時
        private void n6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || errorMsg || endCalc)
            {
                textBox1.Text = "6";
            }
            else
            {
                textBox1.Text = textBox1.Text + "6";
            }
        }

        // 7をクリックした時
        private void n7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || errorMsg || endCalc)
            {
                textBox1.Text = "7";
            }
            else
            {
                textBox1.Text = textBox1.Text + "7";
            }
        }

        // 8をクリックした時
        private void n8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || errorMsg || endCalc)
            {
                textBox1.Text = "8";
            }
            else
            {
                textBox1.Text = textBox1.Text + "8";
            }
        }

        // 9をクリックした時
        private void n9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || errorMsg || endCalc)
            {
                textBox1.Text = "9";
            }
            else
            {
                textBox1.Text = textBox1.Text + "9";
            }
        }

        // 0をクリックした時
        private void n0_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || errorMsg || endCalc)
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text = textBox1.Text + "0";
            }
        }

        // +をクリックした時
        private void add_Click(object sender, EventArgs e)
        {
            // 最初の数値をダブル型に変換
            FirstNumber = Convert.ToDouble(textBox1.Text);

            // 表示画面とフラグの初期化
            Init();

            // 演算子+を記憶
            Operation = "+";
        }

        // -をクリックした時
        private void sub_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(textBox1.Text);
            Init();
            Operation = "-";
        }

        // *をクリックした時
        private void mul_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(textBox1.Text);
            Init();
            Operation = "*";
        }

        // /をクリックした時
        private void div_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(textBox1.Text);
            Init();
            Operation = "/";
        }

        // Cをクリックした時
        private void c_Click(object sender, EventArgs e)
        {
            // 表示画面とフラグの初期化
            Init();
        }

        // .をクリックした時
        private void dot_Click(object sender, EventArgs e)
        {
            // すでに"."が押されていないか確認
            if (!dotCheck)
            {
                // テキストボックスの右に"."を表示
                textBox1.Text = textBox1.Text + ".";

                // "."が押された
                dotCheck = true;
            }
        }

        // =をクリックした時
        private void equal_Click(object sender, EventArgs e)
        {
            // 次の数値
            double SecondNmber = 0;

            // エラーメッセージが出ていないか確認
            if (!errorMsg)
            {
                // 次の数値をダブル型に変換
                SecondNmber = Convert.ToDouble(textBox1.Text);
            }

            switch (Operation)
            {
                // 演算子が+なら
                case "+":
                    // 合計値を表示
                    textBox1.Text = Convert.ToString(FirstNumber + SecondNmber);

                    // 演算終了時
                    endCalc = true;
                    break;

                // 演算子が-なら
                case "-":
                    textBox1.Text = Convert.ToString(FirstNumber - SecondNmber);
                    endCalc = true;
                    break;

                // 演算子が*なら
                case "*":
                    textBox1.Text = Convert.ToString(FirstNumber * SecondNmber);
                    endCalc = true;
                    break;

                // 演算子が/なら
                case "/":
                    // 次の数値が0の場合
                    if (SecondNmber == 0)
                    {
                        // エラーメッセージの表示
                        textBox1.Text = "ゼロで割る事はできません";

                        // エラーメッセージが出た
                        errorMsg = true;

                        // 演算終了時
                        endCalc = true;
                    }
                    else
                    {
                        textBox1.Text = Convert.ToString(FirstNumber / SecondNmber);
                        endCalc = true;
                    }
                    break;
            }

            // 演算終了時なら最初と次の数値を初期化
            if (endCalc)
            {
                FirstNumber = 0;
                SecondNmber = 0;
            }
        }
    }
}
