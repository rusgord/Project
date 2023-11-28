using Project;
using Project.Enums;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInspector_Normal()
        {
            Owner owner = new Owner("Jack", "Laky", 23, 5000);
            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker(1, "Chris", "Hamsword", 31, Job.Barman));
            workers.Add(new Worker(2, "Lary", "Soume", 19, Job.Waiter));
            workers.Add(new Worker(3, "Sam", "Himel", 22, Job.Cook));
            Restaurant restaurant1 = new Restaurant("HillLime", owner, workers);
            Inspector inspector = new Inspector(restaurant1, 3);
            string expected = $"Restaurant: {restaurant1.Name}, Owner: {owner.FirstName} {owner.LastName}, Workers: {workers.Count}";
            string actual = inspector.PrintToDisplay();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestOwner_Name()
        {
            Owner owner1 = new Owner("", "Laky", 23, 5000);
            Assert.ThrowsException<ArgumentNullException>(() => owner1);
        }
        [TestMethod]
        public void TestOwner_Surname()
        {
            Owner owner2 = new Owner("Jack", "", 23, 5000);
            Assert.ThrowsException<ArgumentNullException>(() => owner2);
        }
        [TestMethod]
        public void TestOwner_Age()
        {
            Owner owner3 = new Owner("Jack", "Laky", 17, 5000);
            Assert.ThrowsException<ArgumentException>(() => owner3);
        }
        [TestMethod]
        public void TestOwner_Income()
        {
            Owner owner4 = new Owner("Jack", "Laky", 17, -5000);
            Assert.ThrowsException<ArgumentException>(() => owner4);
        }
        [TestMethod]
        public void TestWorker_Id()
        {
            Worker worker = new Worker(-1, "Chris", "Hamsword", 31, Job.Barman);
            Assert.ThrowsException<ArgumentException>(() => worker);
        }
        [TestMethod]
        public void TestWorker_Name()
        {
            Worker worker2 = new Worker(1, "", "Hamsword", 31, Job.Barman);
            Assert.ThrowsException<ArgumentNullException>(() => worker2);
        }
        [TestMethod]
        public void TestWorker_Surname()
        {
            Worker worker3 = new Worker(1, "Chris", "", 31, Job.Barman);
            Assert.ThrowsException<ArgumentException>(() => worker3);
        }
        [TestMethod]
        public void TestWorker_Age()
        {
            Worker worker4 = new Worker(1, "Chris", "Hamsword", 17, Job.Barman);
            Assert.ThrowsException<ArgumentNullException>(() => worker4);
        }
        [TestMethod]
        public void TestRestaurant_Name()
        {
            Owner owner5 = new Owner("Jack", "Laky", 23, 5000);
            List<Worker> workers2 = new List<Worker>();
            workers2.Add(new Worker(1, "Chris", "Hamsword", 31, Job.Barman));
            workers2.Add(new Worker(2, "Lary", "Soume", 19, Job.Waiter));
            workers2.Add(new Worker(3, "Sam", "Himel", 22, Job.Cook));
            Restaurant restaurant2 = new Restaurant("", owner5, workers2);
            Assert.ThrowsException<ArgumentNullException>(() => restaurant2);
        }
    }
}