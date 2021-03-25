using System;

namespace BuilderSweetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            PackageCreater creater = new PackageCreater();
            Console.WriteLine("Hello World!");
            //IPackageBuilder package = null;

            //package = new ChildPackageBuilder();
            //creater.Manufacture(package);
            //Console.WriteLine("Child Package created.");
            //package.Package.ShowPackage();

            //package = new AdultPackageBuilder();
            //creater.Manufacture(package);
            //Console.WriteLine("Adult Package created.");
            //package.Package.ShowPackage();

            ////////////////////
            IPackageBuilder adultPack = creater.AdultPackageBuilder();
            IPackageBuilder childPack = creater.ChildPackageBuilder();

            Console.WriteLine("New Adult pack created:");
            adultPack.Package.ShowPackage();
            Console.WriteLine("New Child pack created:");
            childPack.Package.ShowPackage();


            Console.ReadLine();
        }
    }

    public class Package
    {
        public int Sweets { get; set; }
        public int Savories { get; set; }

        //public Package()
        //{
        //    Console.WriteLine("This package contains " + Sweets + " sweets and " + Savories + " savories");
        //}
        public void ShowPackage()
        {
            Console.WriteLine("This package contains " + Sweets + " sweets and " + Savories + " savories");
        }
    }

    public interface IPackageBuilder
    {
        Package Package { get; }
        void GenerateSweet();
        void GenerateSavory();
    }

    public class ChildPackageBuilder : IPackageBuilder
    {
        Package package;
        public ChildPackageBuilder()
        {
            package = new Package();
        }
        public void GenerateSavory()
        {
            package.Savories = 1;
        }

        public void GenerateSweet()
        {
            package.Sweets = 2;
        }
        public Package Package
        {
            get { return package; }
        }
    }
    public class AdultPackageBuilder : IPackageBuilder
    {
        Package package ;
        public AdultPackageBuilder()
        {
            package = new Package();
        }
        public void GenerateSavory()
        {
            package.Savories = 2;
        }

        public void GenerateSweet()
        {
            package.Sweets = 2;
        }
        public Package Package
        {
            get { return package; }
        }
    }

    public class PackageCreater
    {
        //public void Manufacture(IPackageBuilder packageBuilder)
        //{
        //    packageBuilder.GenerateSweet();
        //    packageBuilder.GenerateSavory();                          
        //}
        public IPackageBuilder AdultPackageBuilder()
        {
            IPackageBuilder adult = new AdultPackageBuilder();
            adult.GenerateSavory();
            adult.GenerateSweet();
            return adult;
        }
        public IPackageBuilder ChildPackageBuilder()
        {
            IPackageBuilder child = new ChildPackageBuilder();
            child.GenerateSavory();
            child.GenerateSweet();
            return child;
        }
    }
}
