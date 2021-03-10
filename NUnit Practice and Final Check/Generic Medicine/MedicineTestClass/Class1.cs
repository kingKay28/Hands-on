using GenericMedicine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using GenericMedicine;

namespace MedicineTestClass
{
    [TestFixture]
    public class Class1
    {
        Program progObj = null;
        Medicine medicine = null;

        [SetUp]
        public void Setup()
        {
          
             progObj = new Program();
             medicine = progObj.CreateMedicineDetail("medicine_name", "generic_name", "composition", DateTime.Parse("11/12/2035"), 40);
        }

        [Test]
        [TestCase("medicine_name", "generic_name", "composition", "11/12/2022", 40)]
        [TestCase("medicine_name002", "generic_name002", "composition002", "11/12/2023", 80)]
        public void MedicineObjCreateTest(string originalName, string genericName, string composition, DateTime expiryDate, double pricePerStrip)
        {
            Medicine med = progObj.CreateMedicineDetail(originalName, genericName, composition, expiryDate, pricePerStrip);
            Assert.That(med.Name, Is.EqualTo(originalName));
            Assert.That(med.GenericMedicineName, Is.EqualTo(genericName));
            Assert.That(med.Composition, Is.EqualTo(composition));
            Assert.That(med.ExpiryDate, Is.EqualTo(expiryDate));
            Assert.That(med.PricePerStrip, Is.EqualTo(pricePerStrip));
        }

        [Test]
        [TestCase("medicine_name",null, "composition", "11/12/2025",40)]
        //[TestCase("medicine_name", "generic_name01", "composition", "11/12/2025", -40)]
        //[TestCase("medicine_name", "generic_name01", "composition", "11/12/2020", 40)]
        public void MedicineGenericNameExceptionTest(string originalName, string genericName, string composition, DateTime expiryDate, double pricePerStrip)
        {
            Assert.Throws<Exception>(() => progObj.CreateMedicineDetail(originalName, genericName, composition, expiryDate, pricePerStrip));
        }

        [Test]
        //[TestCase("medicine_name", "composition", "11/12/2025", 40)]
        [TestCase("medicine_name", "generic_name01", "composition", "11/12/2024", -40)]
        [TestCase("medicine_name", "generic_name01", "composition", "11/12/2024", 40)]
        //[TestCase("medicine_name", "generic_name01", "composition", "11/12/2020", 40)]
        public void MedicinePriceExceptionTest(string originalName, string genericName, string composition, DateTime expiryDate, double pricePerStrip)
        {

            Assert.Throws<Exception>(() => progObj.CreateMedicineDetail(originalName, genericName, composition, expiryDate, pricePerStrip));

            //try
            //{
            //    Medicine med = progObj.CreateMedicineDetail(originalName, genericName, composition, expiryDate, pricePerStrip);

            //}
            //catch (Exception ex)
            //{
            //    Assert.That(ex.Message, Is.EqualTo("Incorrect value for Medicine price per strip. Please provide valid value"));
            //}
        }

        [Test]
        //[TestCase("medicine_name", "composition", "11/12/2025", 40)]
        //[TestCase("medicine_name", "generic_name01", "composition", "11/12/2025", -40)]
        [TestCase("medicine_name", "generic_name01", "composition", "11/12/2023", 40)]
       
        public void MedicineDateExceptionTest(string originalName, string genericName, string composition, DateTime expiryDate, double pricePerStrip)
        {
            Assert.Throws<Exception>(() => progObj.CreateMedicineDetail(originalName, genericName, composition, expiryDate, pricePerStrip));

        }

        [Test]
        [TestCase(5,"3/8/2022","address01")]
        [TestCase(10,"2/8/2025","address01")]
        public void CartonObjCreateTest(int medicineStripCount, DateTime launchDate, string retailerAddress)
        {
            CartonDetail carton = progObj.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, this.medicine);
            Assert.That(carton.MedicineStripCount, Is.EqualTo(medicineStripCount));
            Assert.That(carton.LaunchDate, Is.EqualTo(launchDate));
            Assert.That(carton.RetailerAddress, Is.EqualTo(retailerAddress));
            Assert.That(carton.Medicine, Is.EqualTo(medicine));
        }

        [Test]
        [TestCase(-21, "3/8/2022", "addrs1")]
        //[TestCase(15, "2/8/2020", "addrs2")]
        public void CartonCountExceptionTest(int medicineStripCount, DateTime launchDate, string retailerAddress)
        {
          
            Assert.Throws<Exception>(() => progObj.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine));
        }

        [Test]
        //[TestCase(21, "3/8/2022", "addrs1")]
        [TestCase(15, "2/8/2020", "addrs2")]
        public void CartonDateExceptionTest(int medicineStripCount, DateTime launchDate, string retailerAddress)
        {
            Assert.Throws<Exception>(() => progObj.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine));
        }

        [Test]
        [TestCase(15, "11/12/2021", "addrs2", null)]
        public void NullCartonDetailsTest(int medicineStripCount, string launchDate, string retailerAddress, Medicine medicine)
        {
            CartonDetail carton = progObj.CreateCartonDetail(medicineStripCount, DateTime.Parse(launchDate), retailerAddress, medicine);
            Assert.That(carton, Is.EqualTo(null));
        }

    }
}
