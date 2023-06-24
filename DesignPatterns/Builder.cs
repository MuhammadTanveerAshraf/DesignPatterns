namespace DesignPatterns
{
    internal class Builder
    {
        public Builder()
        {
            Console.WriteLine("It separates the construction of a complex object from its representation so that the same" +
                " construction process can be used for multple representations");

            var shop = new Shop();

            VehicleBuilder builder = new MotorcycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.DisplayData();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.DisplayData();
        }
    }

    //Director
    class Shop
    {
        public void Construct(VehicleBuilder builder)
        {
            builder.BuildFrame();
            builder.BuildMaker();
            builder.BuildEngine();
            builder.BuildModel();
        }
    }


    //Builder
    abstract class VehicleBuilder
    {
        protected Vehicle vehicle;
        public Vehicle Vehicle
        {
            get { return vehicle; }
        }

        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildMaker();
        public abstract void BuildModel();
    }


    //Concrete Builder
    class MotorcycleBuilder : VehicleBuilder
    {
        public MotorcycleBuilder()
        {
            vehicle = new Vehicle("Suzuki Motor Cycle");
        }
        public override void BuildEngine()
        {
            vehicle["Engine"] = "150 cc";
        }

        public override void BuildFrame()
        {
            vehicle["Frame"] = "Scooter Frame";
        }

        public override void BuildMaker()
        {
            vehicle["Maker"] = "Suzuki Motors";
        }

        public override void BuildModel()
        {
            vehicle["Model"] = "2017";
        }
    }

    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehicle = new Vehicle("Mehran Car");
        }
        public override void BuildEngine()
        {
            vehicle["Engine"] = "950 cc";
        }

        public override void BuildFrame()
        {
            vehicle["Frame"] = "Mehran Car Frame";
        }

        public override void BuildMaker()
        {
            vehicle["Maker"] = "Suzuki Motors";
        }

        public override void BuildModel()
        {
            vehicle["Model"] = "2010";
        }
    }


    //Product
    class Vehicle
    {
        private string _vehicleType;
        private Dictionary<string, string> _parts = new Dictionary<string, string>();
        
        //constructor
        public Vehicle(string vehicleType)
        {
            _vehicleType = vehicleType;
        }

        //Indexer
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void DisplayData()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
            Console.WriteLine(" Frame : {0}", _parts["Frame"]);
            Console.WriteLine(" Engine : {0}", _parts["Engine"]);
            Console.WriteLine(" Maker: {0}", _parts["Maker"]);
            Console.WriteLine(" Model : {0}", _parts["Model"]);
        }
    }
}
