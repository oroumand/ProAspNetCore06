using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    public class Wallet
    {
        private readonly List<Money> moneys = new List<Money>();


        public Money this[int index]
        {
            get
            {
                return moneys[index];
            }
            set
            {
                if (moneys.Count > index)
                    moneys[index] = value;
                else
                {
                    moneys.Add(value);
                }
            }
        }

    }
    public class Money : IEquatable<Money>
    {
        private readonly int _value;
        public Money(int value)
        {
            _value = value;
        }

        public int Value { get { return _value; } }

        public bool Equals(Money? other)
        {
            return this == other;
        }

        public override bool Equals(object? obj)
        {
            return this == obj as Money;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        //public Money Add(Money inputMoney)
        //    => new Money(_value + inputMoney.Value);

        public static Money operator +(Money right, Money left) =>
            new Money(right.Value + left.Value);

        public static Money operator -(Money right, Money left) =>
            new Money(right.Value - left.Value);

        public static bool operator ==(Money right, Money left) =>
            right.Value == left.Value;

        public static bool operator !=(Money right, Money left) =>
            !(left == right);

        public static implicit operator int(Money value) => value.Value;

        public static implicit operator Money(int value) => new Money(value);

        public static explicit operator byte(Money value) => (byte)value.Value;
    }
}
