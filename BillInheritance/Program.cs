using System;

namespace BillInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var myBill = new Bill(15.80, 0.06);
            Pay(myBill);

            var myTippedBill = new TippableBill(8.50, 0.06, 2);

            Pay(myTippedBill);
        }
        static void Pay(Bill bill) 
        {
            var total = bill.CalcTotal();
            Console.WriteLine($"${total}");
        }
    }


    public class Bill 
    {
        public Bill()
        {
        }
        public Bill(double subtotal, double taxRate)
        {
            Subtotal = subtotal;
            TaxRate = taxRate;
        }
        public double Subtotal { get; set; }
        public double TaxRate { get; set; }

        public virtual double CalcTotal() => (Subtotal * (1 + TaxRate));
    }

    public class TippableBill : Bill 
    {

        public TippableBill()
        {
            Console.WriteLine("Who ya gonna call? Default constructor!");
        }
        public TippableBill(double subtotal, double taxRate, double tip)
        {
            Subtotal = subtotal;
            TaxRate = taxRate;
            Tip = tip;
        }
        public double Tip { get; set; }

        public override double CalcTotal() => (Subtotal * (1 + TaxRate)) + Tip;
    }
}
