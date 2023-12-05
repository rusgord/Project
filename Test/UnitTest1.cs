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
            string expected = $"Jack Laky";
            string actual = restaurant1.ToString();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestOwner_Name()
        {
            Owner owner1 = new Owner("", "Laky", 23, 5000);
            Assert.ThrowsException<ArgumentException>(() => owner1.IsEmpty(owner1.FirstName));
        }
        [TestMethod]
        public void TestOwner_Surname()
        {
            Owner owner2 = new Owner("Jack", "", 23, 5000);
            Assert.ThrowsException<ArgumentException>(() => owner2.IsEmpty(owner2.LastName));
        }
        [TestMethod]
        public void TestOwner_Age()
        {
            Owner owner3 = new Owner("Jack", "Laky", 17, 5000);
            Assert.ThrowsException<ArgumentException>(() => owner3.NormalAge(owner3.Age));
        }
        [TestMethod]
        public void TestOwner_Income()
        {
            Owner owner4 = new Owner("Jack", "Laky", 17, -5000);
            Assert.ThrowsException<ArgumentException>(() => owner4.Enough(owner4.Income));
        }
        [TestMethod]
        public void TestWorker_Id()
        {
            Worker worker = new Worker(-1, "Chris", "Hamsword", 31, Job.Barman);
            Assert.ThrowsException<ArgumentException>(() => worker.Enough(worker.Id));
        }
        [TestMethod]
        public void TestWorker_Name()
        {
            Worker worker2 = new Worker(1, "", "Hamsword", 31, Job.Barman);
            Assert.ThrowsException<ArgumentException>(() => worker2.IsEmpty(worker2.FirstName));
        }
        [TestMethod]
        public void TestWorker_Surname()
        {
            Worker worker3 = new Worker(1, "Chris", "", 31, Job.Barman);
            Assert.ThrowsException<ArgumentException>(() => worker3.IsEmpty(worker3.LastName));
        }
        [TestMethod]
        public void TestWorker_Age()
        {
            Worker worker4 = new Worker(1, "Chris", "Hamsword", 17, Job.Barman);
            Assert.ThrowsException<ArgumentException>(() => worker4.NormalAge(worker4.Age));
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
            Assert.ThrowsException<ArgumentException>(() => restaurant2.IsEmpty(restaurant2.Name));
        }
    }
}