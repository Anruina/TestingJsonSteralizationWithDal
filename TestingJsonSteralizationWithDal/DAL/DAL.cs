using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using TestingJsonSteralizationWithDal.Models;

namespace TestingJsonSteralizationWithDal.DAL
{
    public class DAL
    {
        private string _filePath; // Path to the JSON File

        public DAL(string filePath)
        {
        
            _filePath = filePath;
        
        }

        public void SaveCare(Car car)
        {
            // Serialize the car object to JSON and save it to a file
            string jsonString = JsonSerializer.Serialize(car);
            File.WriteAllText(_filePath, jsonString);

        }

        public void AppendCar(Car car)
        {
            List<Car> cars;

            if (File.Exists(_filePath))
            {
                //read existing json
                string jsonString = File.ReadAllText(_filePath);

                //deserialize the json
                cars = JsonSerializer.Deserialize<List<Car>>(jsonString);
            
            }
            else
            {
                //if file doesnt exist create new
                cars = new List<Car>();

            }

            //add new person to the list
            cars.Add(car);

            //Serialize the updated list back to JSON
            string updatedJsonString = JsonSerializer.Serialize(cars);

            //write the updated list back to JSON
            File.WriteAllText(_filePath, updatedJsonString);
        }

        public List<Car> LoadCars() 
        {

            if (File.Exists(_filePath))
            {
                //read json data
                string? jsonString = File.ReadAllText(_filePath);

                //desterialize data
                List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonString);
                return cars;
            }
            else 
            {

                return new List<Car>();
            }

        
        }
    }
}
