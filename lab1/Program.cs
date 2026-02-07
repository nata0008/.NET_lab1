using System.Text;

namespace Lab1
{
    // Базовий клас
    class UnsignedNumber
    {
        protected uint value;

        public uint Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public UnsignedNumber() { }

        public UnsignedNumber(uint value)
        {
            this.value = value;
        }

        // Поліморфний метод
        public virtual void Display()
        {
            Console.WriteLine("Ціле беззнакове число: " + value);
        }

        // Перевизначений метод Equals
        public override bool Equals(object obj)
        {
            if (obj is UnsignedNumber other)
                return value == other.value;

            return false;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }


    // Двійкове число
    class BinaryNumber : UnsignedNumber
    {
        public BinaryNumber() { }

        public BinaryNumber(uint value) : base(value) { }

        // Перевизначений поліморфний метод
        public override void Display()
        {
            Console.WriteLine("Двійкове число: " + Convert.ToString(value, 2));
        }

        // Метод для демонстрації раннього зв’язування
        public new void Info()
        {
            Console.WriteLine("Це двійкове представлення числа");
        }
    }

    // Десяткове число
    class DecimalNumber : UnsignedNumber
    {
        public DecimalNumber() { }

        public DecimalNumber(uint value) : base(value) { }

        public override void Display()
        {
            Console.WriteLine("Десяткове число: " + value);
        }

        public new void Info()
        {
            Console.WriteLine("Це десяткове представлення числа");
        }
    }

    // Шістнадцяткове число
    class HexNumber : UnsignedNumber
    {
        public HexNumber() { }

        public HexNumber(uint value) : base(value) { }

        public override void Display()
        {
            Console.WriteLine("Шістнадцяткове число: " + value.ToString("X"));
        }

        public new void Info()
        {
            Console.WriteLine("Це шістнадцяткове представлення числа");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Масив базового класу
            UnsignedNumber[] numbers =
 {
             new UnsignedNumber(15), 
             new BinaryNumber(15),   
             new DecimalNumber(15),  
             new HexNumber(15)       
             
            };


            Console.WriteLine("=== Пізнє зв’язування (override) ===");
            foreach (UnsignedNumber n in numbers)
            {
                // Викликається метод відповідного похідного класу
                n.Display();
            }

            Console.WriteLine();
            Console.WriteLine("=== Раннє зв’язування (new) ===");

            BinaryNumber b = new BinaryNumber(10);
            UnsignedNumber ub = b;

            // Виклик методу похідного класу
            b.Info();


            Console.WriteLine();
            Console.WriteLine("=== Перевірка Equals ===");

            BinaryNumber b1 = new BinaryNumber(5);
            DecimalNumber d1 = new DecimalNumber(5);
            Console.WriteLine($"Порівнюємо {b1.GetType().Name}({b1.Value}) з {d1.GetType().Name}({d1.Value})");
            Console.WriteLine("Результат порівняння: " + b1.Equals(d1));

        }
    }
}
