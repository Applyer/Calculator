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
        double SecondNmber;  // 次の数値
        double OperatedNum;  // 最後の数値
        string NowNumber;   // 入力中の数値
        string Operation;   // 演算子
        bool dotCheck = false;  // "."が押されたフラグ
        bool errorMsg = false;  // エラーメッセージが出たフラグ
        bool endPut = false;   // 入力終了時フラグ
        bool equalContinu = false; // 連続でイコールが押された
        bool transNow = false;  // 透明化フラグ
        bool firstNChek = false; // 最初の数値に値があるか？
        bool secondNChek = false; // 次の数値に値があるか？
        bool operatedNChek = false; // 最後の数値に値があるか？

        public Form1()
        {
            InitializeComponent();
        }

        // フラグの初期化
        public void InitFlag()
        {
            dotCheck = false;
            errorMsg = false;
            endPut = false;
            equalContinu = false;
        }

        // 入力された数値の処理
        public void EnteringNum()
        {
            // 0かエラーメッセージもしくは入力終了時なら入力中の数値を表示
            if (textBox1.Text == "0" || errorMsg || endPut)
            {
                textBox1.Text = NowNumber;
                endPut = false;
            }
            else    // それ以外なら入力中の数値を右に追加
            {
                textBox1.Text = textBox1.Text + NowNumber;
            }
        }

        // 演算子が押された時の裏処理
        public void OperatorClick()
        {
            // 最初の数値に値があるなら
            if (firstNChek)
            {
                OperatMain();
            }
            // 最初の数値が空なら
            if (!firstNChek && !errorMsg)
            {
                // 最初の数値をダブル型に変換
                FirstNumber = Convert.ToDouble(textBox1.Text);
                firstNChek = true;
                errorMsg = false;
            }

            // 一部フラグの初期化
            dotCheck = false;
            equalContinu = false;

            // 入力終了
            endPut = true;
        }

        // 次の数値を入力するか？
        public void NextNum()
        {
            // 連続でイコールが押されているか？エラーは出ているか？
            if (equalContinu && !errorMsg)
            {
                // 表示されいる数値をダブル型に変換し最初の数値に代入
                FirstNumber = Convert.ToDouble(textBox1.Text);
            }
            else if (!errorMsg && !secondNChek) // エラーが出ているか？
            {
                // 表示されいる数値をダブル型に変換し次の数値に代入
                SecondNmber = Convert.ToDouble(textBox1.Text);
                secondNChek = true;
            }
        }

        // エラーが出た
        public void ErrorMessage()
        {
            // エラー時のフラグや処理
        }

        // 演算のメイン
        public void OperatMain()
        {
            NextNum();

            switch (Operation)
            {
                // 演算子が+なら
                case "+":
                    // 合計値を表示
                    OperatedNum = FirstNumber + SecondNmber;
                    textBox1.Text = Convert.ToString(OperatedNum);
                    break;

                // 演算子が-なら
                case "-":
                    OperatedNum = FirstNumber - SecondNmber;
                    textBox1.Text = Convert.ToString(OperatedNum);
                    break;

                // 演算子が*なら
                case "*":
                    OperatedNum = FirstNumber * SecondNmber;
                    textBox1.Text = Convert.ToString(OperatedNum);
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
                    }
                    else
                    {
                        OperatedNum = FirstNumber / SecondNmber;
                        textBox1.Text = Convert.ToString(OperatedNum);
                    }
                    break;

                // 演算子が^なら
                case "^":
                    OperatedNum = System.Math.Pow(FirstNumber, SecondNmber);
                    textBox1.Text = Convert.ToString(OperatedNum);
                    // textBox1.Text = Convert.ToString(System.Math.Pow(FirstNumber, SecondNmber));
                    break;

                // 演算子が%なら
                case "%":
                    // 次の数値が0の場合
                    if (SecondNmber == 0)
                    {
                        // エラーメッセージの表示
                        textBox1.Text = "ゼロで余りは出ません";

                        // エラーメッセージが出た
                        errorMsg = true;
                    }
                    else
                    {
                        OperatedNum = FirstNumber % SecondNmber;
                        textBox1.Text = Convert.ToString(OperatedNum);
                    }
                    break;
            }

            // 入力終了時
            endPut = true;
            equalContinu = true;
            firstNChek = secondNChek = operatedNChek = false;
        }

        // 1をクリックした時
        private void n1_Click(object sender, EventArgs e)
        {
            // 入力中の数値に1を
            NowNumber = "1";

            // 入力処理
            EnteringNum();
        }

        // 2をクリックした時
        private void n2_Click(object sender, EventArgs e)
        {
            // 入力中の数値に2を
            NowNumber = "2";

            // 入力処理
            EnteringNum();
        }

        // 3をクリックした時
        private void n3_Click(object sender, EventArgs e)
        {
            // 入力中の数値に3を
            NowNumber = "3";

            // 入力処理
            EnteringNum();
        }

        // 4をクリックした時
        private void n4_Click(object sender, EventArgs e)
        {
            // 入力中の数値に4を
            NowNumber = "4";

            // 入力処理
            EnteringNum();
        }

        // 5をクリックした時
        private void n5_Click(object sender, EventArgs e)
        {
            // 入力中の数値に5を
            NowNumber = "5";

            // 入力処理
            EnteringNum();
        }

        // 6をクリックした時
        private void n6_Click(object sender, EventArgs e)
        {
            // 入力中の数値に6を
            NowNumber = "6";

            // 入力処理
            EnteringNum();
        }

        // 7をクリックした時
        private void n7_Click(object sender, EventArgs e)
        {
            // 入力中の数値に7を
            NowNumber = "7";

            // 入力処理
            EnteringNum();
        }

        // 8をクリックした時
        private void n8_Click(object sender, EventArgs e)
        {
            // 入力中の数値に8を
            NowNumber = "8";

            // 入力処理
            EnteringNum();
        }

        // 9をクリックした時
        private void n9_Click(object sender, EventArgs e)
        {
            // 入力中の数値に9を
            NowNumber = "9";

            // 入力処理
            EnteringNum();
        }

        // 0をクリックした時
        private void n0_Click(object sender, EventArgs e)
        {
            // 入力中の数値に0を
            NowNumber = "0";

            // 入力処理
            EnteringNum();
        }

        // +をクリックした時
        private void add_Click(object sender, EventArgs e)
        {
            // 演算子が押された
            OperatorClick();

            // 演算子+を記憶
            Operation = "+";
        }

        // -をクリックした時
        private void sub_Click(object sender, EventArgs e)
        {
            // 演算子が押された
            OperatorClick();

            // 演算子-を記憶
            Operation = "-";
        }

        // *をクリックした時
        private void mul_Click(object sender, EventArgs e)
        {
            // 演算子が押された
            OperatorClick();

            // 演算子*を記憶
            Operation = "*";
        }

        // /をクリックした時
        private void div_Click(object sender, EventArgs e)
        {
            // 演算子が押された
            OperatorClick();

            // 演算子/を記憶
            Operation = "/";
        }

        // ^をクリックした時
        private void pow_Click(object sender, EventArgs e)
        {
            // 演算子が押された
            OperatorClick();

            // 演算子^を記憶
            Operation = "^";
        }

        // %をクリックした時
        private void res_Click(object sender, EventArgs e)
        {
            // 演算子が押された
            OperatorClick();

            // 演算子%を記憶
            Operation = "%";
        }

        // Cをクリックした時
        private void c_Click(object sender, EventArgs e)
        {
            // 表示画面とフラグの初期化
            textBox1.Text = "0";
            InitFlag();
            FirstNumber = SecondNmber = OperatedNum = 0;
            firstNChek = secondNChek = operatedNChek = false;
        }

        // .をクリックした時
        private void dot_Click(object sender, EventArgs e)
        {
            // すでに"."が押されていないか？数値は既に入っているか？確認
            if ((!dotCheck && firstNChek) || textBox1.Text == "0")
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
            OperatMain();
        }

        // !をクリックした時
        private void trans_Click(object sender, EventArgs e)
        {
            // 透明でない場合透明にする
            if (!transNow)
            {
                this.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
                this.AllowTransparency = true;
                transNow = true;
            }
            else
            {
                this.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
                this.AllowTransparency = false;
                transNow = false;
            }
        }
    }
}
