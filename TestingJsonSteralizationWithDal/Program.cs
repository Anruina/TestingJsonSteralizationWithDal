using TestingJsonSteralizationWithDal.Models;

namespace TestingJsonSteralizationWithDal
{
    public class Program
    {
        static void Main(string[] args)
        {
            //initalize data access layer with file path
            var dataAccess = new DAL.DAL("C:\\Users\\Anrui\\source\\repos\\TestingJsonSteralizationWithDal\\TestingJsonSteralizationWithDal\\DAL\\cars.json");

            // Create a new Car object
            var car = new Car
            {

                Name = "i40",
                Brand = "Hyundai",
                Fuel = "Electric",
                Price = 13040
                
            };



            //Save the car object to JSON file
            //dataAccess.SaveCare(car);

            //append the person object to the json file
            dataAccess.AppendCar(car);

            //load the car object from JSON File
            //var loadedCar = dataAccess.LoadCar();
            List<Car> cars = dataAccess.LoadCars();

            // display info

            Console.WriteLine("List of Cars:");
            foreach (var i in cars)
            {
                
                Console.WriteLine($"Name: {i.Name},Brand: {i.Brand}, FuelType:{i.Fuel}, Price: {i.Price} \n");

            }
        }
    }
}
