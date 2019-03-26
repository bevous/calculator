using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    using System.Data.Common;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    using calculator.Properties;

    public partial class CalculatorForm : Form
    {
        /// <summary>
        /// The my calculator.
        /// </summary>
        private Calculator MyCalculator = new Calculator();

        #region Operators
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorForm"/> class.
        /// </summary>
        public CalculatorForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The operand pressed.
        /// </summary>
        /// <param name="symbol">
        /// The symbol.
        /// </param>
        private void OperandPressed(char symbol)
        {
            if (this.ResultTextBox.Text != string.Empty)
            {
                if (this.MyCalculator.OperandOne.CompareTo(0.0) != 0)
                {
                    double.TryParse(this.ResultTextBox.Text, out var OperandTwo);
                    this.MyCalculator.OperandTwo = OperandTwo;
                    this.MyCalculator.Process();
                    this.OperationTextBox.Text += OperandTwo;
                    this.ResultTextBox.Text = this.MyCalculator.CurrentValue.ToString();
                } // else, there is no second operand DoNothing();

                double.TryParse(this.ResultTextBox.Text, out var LeftSide);
                this.MyCalculator.OperandOne = LeftSide;
                if (this.OperationTextBox.Text == string.Empty)
                {
                    this.OperationTextBox.Text += LeftSide.ToString();
                }
                this.OperationTextBox.Text += symbol.ToString();
                switch (symbol)
                {
                    case '+':
                        {
                            this.MyCalculator.Op = Calculator.Operators.Add;
                            break;
                        }
                    case '-':
                        {
                            this.MyCalculator.Op = Calculator.Operators.Subtract;
                            break;
                        }
                    case '*':
                        {
                            this.MyCalculator.Op = Calculator.Operators.Multiply;
                            break;
                        }
                    case '/':
                        {
                            this.MyCalculator.Op = Calculator.Operators.Divide;
                            break;
                        }
                }
                this.ResultTextBox.Text = string.Empty;
            }
            else if (this.OperationTextBox.Text != string.Empty)
            {
                switch (symbol)
                {
                    case '+':
                        {
                            this.MyCalculator.Op = Calculator.Operators.Add;
                            break;
                        }
                    case '-':
                        {
                            this.MyCalculator.Op = Calculator.Operators.Subtract;
                            break;
                        }
                    case '*':
                        {
                            this.MyCalculator.Op = Calculator.Operators.Multiply;
                            break;
                        }
                    case '/':
                        {
                            this.MyCalculator.Op = Calculator.Operators.Divide;
                            break;
                        }
                }

                this.OperationTextBox.Text += symbol.ToString();
            }
        }

        /// <summary>
        /// The addition button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void AdditionButton_Click(object sender, EventArgs e)
        {
            this.OperandPressed('+');
        }

        /// <summary>
        /// The subtraction button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SubtractionButton_Click(object sender, EventArgs e)
        {
            this.OperandPressed('-');
        }

        /// <summary>
        /// The multiplication button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MultiplicationButton_Click(object sender, EventArgs e)
        {
            this.OperandPressed('*');
        }

        /// <summary>
        /// The division button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DivisionButton_Click(object sender, EventArgs e)
        {
            this.OperandPressed('/');
        }

        /// <summary>
        /// The square root button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SquareRootButton_Click(object sender, EventArgs e)
        {
            this.MyCalculator.Op = Calculator.Operators.None;
            if (this.ResultTextBox.Text != string.Empty)
            {
                double.TryParse(this.ResultTextBox.Text, out var number);
                if (number.CompareTo(0.0) < 0)
                {
                    this.ResultTextBox.Text = Resources.SquareRootError;
                    return;
                } // else DoNothing();
                this.MyCalculator.Sqrt(number);
                this.OperationTextBox.Text += string.Format(Resources.SquareRoot, number);
            }
            else
            {
                if (this.MyCalculator.CurrentValue.CompareTo(0.0) < 0)
                {
                    this.ResultTextBox.Text = Resources.SquareRootError;
                    return;
                } // else DoNothing();
                this.MyCalculator.Sqrt(this.MyCalculator.CurrentValue);
                this.OperationTextBox.Text = string.Format(Resources.SquareRoot, this.OperationTextBox.Text);
            }

            this.MyCalculator.Op = Calculator.Operators.None;
            this.ResultTextBox.Clear();
        }

        /// <summary>
        /// The under one button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void UnderOneButton_Click(object sender, EventArgs e)
        {
            if (this.ResultTextBox.Text != string.Empty)
            {
                double.TryParse(this.ResultTextBox.Text, out var number);
                if (number.CompareTo(0.0) < 0)
                {
                    this.ResultTextBox.Text = Resources.SquareRootError;
                    return;
                } // else DoNothing();
                this.MyCalculator.Reciprocal(number);
                this.OperationTextBox.Text += string.Format(Resources.CalculatorForm_UnderOneButton_Click__1__0_G__, number);
            }
            else
            {
                
                if (this.MyCalculator.CurrentValue.CompareTo(0.0) < 0)
                {
                    this.ResultTextBox.Text = Resources.SquareRootError;
                    return;
                } // else DoNothing();
                this.MyCalculator.Reciprocal(this.MyCalculator.CurrentValue);
                this.OperationTextBox.Text = string.Format(Resources.CalculatorForm_UnderOneButton_Click__1__0_G__, this.OperationTextBox.Text);
            }

            this.ResultTextBox.Clear();
        }


        private double lastNumderUsed;
        private Calculator.Operators lastOperator;

        /// <summary>
        /// The equals button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (this.ResultTextBox.Text != string.Empty)
            {
                if (this.OperationTextBox.Text != string.Empty)
                {
                    double.TryParse(this.ResultTextBox.Text, out var OperandTwo);
                    this.MyCalculator.OperandTwo = OperandTwo;
                    this.lastNumderUsed = OperandTwo;
                    this.lastOperator = this.MyCalculator.Op;
                }
                else
                {
                    this.MyCalculator.OperandOne = this.MyCalculator.CurrentValue;
                    this.MyCalculator.OperandTwo = this.lastNumderUsed;
                    this.MyCalculator.Op = this.lastOperator;
                }
            }
            else
            {
                if (this.OperationTextBox.Text != string.Empty)
                {
                    if (this.IsOperator(this.OperationTextBox.Text[this.OperationTextBox.TextLength - 1]))
                    {
                        return;
                    }       
                }
            }
            
            this.MyCalculator.Process();
            this.OperationTextBox.Clear();
            this.ResultTextBox.Text = this.MyCalculator.CurrentValue.ToString();
            this.MyCalculator.OperandTwo = 0.0;
            this.MyCalculator.Op = Calculator.Operators.None;
        }

        /// <summary>
        /// The clear button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.MyCalculator.Clear();
            this.ResultTextBox.Clear();
            this.OperationTextBox.Clear();
        }

        /// <summary>
        /// The back button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (this.ResultTextBox.Text != string.Empty)
            {
                this.ResultTextBox.Text = this.ResultTextBox.Text.Remove(this.ResultTextBox.Text.Length - 1);
            }
            else if (this.OperationTextBox.Text != string.Empty)
            {
                if (this.IsOperator(this.OperationTextBox.Text[this.OperationTextBox.Text.Length - 1]))
                {
                    this.MyCalculator.Op = Calculator.Operators.None;
                }

                this.OperationTextBox.Text =
                    this.OperationTextBox.Text.Remove(this.OperationTextBox.Text.Length - 1);
            }
        }

        /// <summary>
        /// The is operator.
        /// </summary>
        /// <param name="character">
        /// The character.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsOperator(char character)
        {
            switch (character)
            {
                case '+':
                    {
                        return true;
                    }
                case '-':
                    {
                        return true;
                    }
                case '*':
                    {
                        return true;
                    }
                case '/':
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        #endregion
        #region numbers

        /// <summary>
        /// The number zero button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NumberZeroButton_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += Settings.Default.Zero;
        }

        /// <summary>
        /// The number one button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NumberOneButton_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += Settings.Default.One;
        }

        /// <summary>
        /// The number two button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NumberTwoButton_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += Settings.Default.Two;
        }

        /// <summary>
        /// The number three button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NumberThreeButton_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += Settings.Default.Three;
        }

        /// <summary>
        /// The number four button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NumberFourButton_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += Settings.Default.Four;
        }

        /// <summary>
        /// The number five button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NumberFiveButton_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += Settings.Default.Five;
        }

        /// <summary>
        /// The number six button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NumberSixButton_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += Settings.Default.Six;
        }

        /// <summary>
        /// The number seven button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NumberSevenButton_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += Settings.Default.Seven;
        }

        /// <summary>
        /// The number eight button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NumberEightButton_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += Settings.Default.Eight;
        }

        /// <summary>
        /// The number nine button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NumberNineButton_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += Settings.Default.Nine;
        }

        private void EqualsButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.EqualsButton.PerformClick();
        }
        #endregion

        /// <summary>
        /// The positive negative button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PositiveNegativeButton_Click(object sender, EventArgs e)
        {
            if (this.ResultTextBox.Text != string.Empty)
            {
                double.TryParse(this.ResultTextBox.Text, out var number);
                this.MyCalculator.ChangeSign(number);
                this.OperationTextBox.Text += $@"({this.MyCalculator.CurrentValue:G})";
            }
            else
            {
                this.MyCalculator.ChangeSign(this.MyCalculator.CurrentValue);
                this.OperationTextBox.Text += this.MyCalculator.CurrentValue;
            }

            this.ResultTextBox.Clear();
        }
    }
}
