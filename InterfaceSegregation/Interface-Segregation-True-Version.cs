using System;

namespace InterfaceSegregation
{
    public static class Program
    {
        public static void Main()
        {
            var localBox = new LocalBox(2, 3, 1);
            var internationalBox = new InternationalBox(2, 3, 1);
            
            Console.WriteLine(localBox.CalculateDeci());
            Console.WriteLine(internationalBox.CalculateInternationalBarcodeNumber());
        }
    }

    public interface ICalculateDeci
    {
        double CalculateDeci();
    }
    
    public interface ICalculateBarcodeNumber
    {
        double CalculateInternationalBarcodeNumber();
    }

    public class LocalBox : ICalculateDeci
    {
        private readonly long _height;
        private readonly long _length;
        private readonly long _width;

        public LocalBox(long height, long length, long width)
        {
            _height = height;
            _length = length;
            _width = width;
        }
        
        public double CalculateDeci()
        {
            return _height * _length * _width;
        }
    }
    
    public class InternationalBox : ICalculateBarcodeNumber
    {
        private readonly long _height;
        private readonly long _length;
        private readonly long _width;
        private const double Coefficient = 0.6;

        public InternationalBox(long height, long length, long width)
        {
            _height = height;
            _length = length;
            _width = width;
        }
        
        public double CalculateInternationalBarcodeNumber()
        {
            return _height * _length * _width * Coefficient;
        }
    }
}