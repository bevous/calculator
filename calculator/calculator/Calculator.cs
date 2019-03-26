namespace calculator
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;

    class Calculator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Calculator"/> class. 
        /// </summary>
        /// <param name="value">
        /// The current result of the calculations
        /// </param>
        /// <param name="firstOperand">
        /// The first operand
        /// </param>
        /// <param name="secondOperand">
        /// The second operand
        /// </param>
        /// <param name="givenOperator">
        /// The Given Operator.
        /// </param>
        public Calculator(
            double value = 0.0,
            double firstOperand = 0.0,
            double secondOperand = 0.0,
            Operators givenOperator = Operators.None)
        {
            this.Op = givenOperator;
            this.CurrentValue = value;
            this.OperandOne = firstOperand;
            this.OperandTwo = secondOperand;
        }

        /// <summary>
        /// The process.
        /// </summary>
        public void Process()
        {   
            switch (this.Op)
            {
                case Operators.Add:
                    {
                        this.Addition();
                        break;
                    }
                case Operators.Subtract:
                    {
                        this.Subtract();
                        break;
                    }
                case Operators.Multiply:
                    {
                        this.Multiply();
                        break;
                    }
                case Operators.Divide:
                    {
                        this.Divide();
                        break;
                    }
                case Operators.None:
                    {
                        if (this.CurrentValue.Equals(0))
                        {
                            if (this.OperandTwo.CompareTo(0) != 0)
                            {
                                this.CurrentValue = this.OperandTwo;
                                this.OperandOne = this.CurrentValue;
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// The operators.
        /// </summary>
        public enum Operators
        {
            /// <summary>
            /// The add.
            /// </summary>
            Add = '+',

            /// <summary>
            /// The subtract.
            /// </summary>
            Subtract = '-',

            /// <summary>
            /// The multiply.
            /// </summary>
            Multiply = '*',

            /// <summary>
            /// The divide.
            /// </summary>
            Divide = '/',

            /// <summary>
            /// The none.
            /// </summary>
            None = 'n'
        }

        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        public double CurrentValue { get; set; }

        /// <summary>
        /// Gets or sets the operand one.
        /// </summary>
        public double OperandOne { get; set; }

        /// <summary>
        /// Gets or sets the operand two.
        /// </summary>
        public double OperandTwo { get; set; }

        /// <summary>
        /// Gets or sets the op.
        /// </summary>
        public Operators Op { get; set; }

        /// <summary>
        /// adds two numbers together
        /// </summary>
        private void Addition()
        {
            this.CurrentValue = this.OperandOne + this.OperandTwo;
            this.OperandTwo = 0.0;
        }

        /// <summary>
        /// subtracts two numbers
        /// </summary>
        private void Subtract()
        {
            this.CurrentValue = this.OperandOne - this.OperandTwo;
        }

        /// <summary>
        /// multiplies two numbers together
        /// </summary>
        private void Multiply()
        {
            this.CurrentValue = this.OperandOne * this.OperandTwo;
        }

        /// <summary>
        /// divides two numbers
        /// </summary>
        private void Divide()
        {
            this.CurrentValue = this.OperandOne / this.OperandTwo;
        }

        /// <summary>
        /// square roots the number
        /// </summary>
        public void Sqrt(double ToSquareRoot)
        {
            if (this.CurrentValue.CompareTo(ToSquareRoot) == 0)
            {
                this.CurrentValue = Math.Sqrt(this.CurrentValue);
            }
            else
            {
                this.OperandTwo = Math.Sqrt(ToSquareRoot);
                this.Process();
            }
        }

        /// <summary>
        /// changes the sign
        /// </summary>
        public void ChangeSign(double number)
        {
            if (this.CurrentValue.CompareTo(number) == 0)
            {
                this.CurrentValue = this.CurrentValue * -1;
            }
            else
            {
                this.OperandTwo = number * -1;
                this.Process();
            }
            
        }

        /// <summary>
        /// calculates the reciprocal
        /// </summary>
        public void Reciprocal(double number)
        {
            if (this.CurrentValue.CompareTo(number) == 0)
            {
                this.CurrentValue = 1 / this.CurrentValue;
            }
            else
            {
                this.OperandTwo = 1 / number;
                this.Process();
            }
        }

        /// <summary>
        /// The is divide by zero.
        /// </summary>
        /// <param name="divisor">
        /// The divisor.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsDivideByZero(double divisor)
        {
            return divisor.CompareTo(0) == 0;
        }

        /// <summary>
        /// Resets the properties.
        /// </summary>
        public void Clear()
        {
            this.Op = 0.0;
            this.CurrentValue = 0.0;
            this.OperandOne = 0.0;
            this.OperandTwo = 0.0;
        }
    }
}
