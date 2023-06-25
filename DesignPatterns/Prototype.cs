using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Prototype
    {
        public Prototype()
        {
            Console.WriteLine("It specifies the kind of objects to create using a prototypical instance, and create new objects " +
                "by copying this prototype");

            ColorManager manager = new ColorManager();

            //Standard Colors
            manager["Red"] = new Color(255, 0, 0);
            manager["Blue"] = new Color(0, 0, 255);
            manager["Green"] = new Color(0, 255, 0);

            // User adds personalized colors
            manager["Angry"] = new Color(255, 54, 0);
            manager["Peace"] = new Color(128, 211, 128);
            manager["Flame"] = new Color(211, 34, 20);

            //Clone colors
            Color? color1 = manager["Red"].Clone() as Color;
            Color? color2 = manager["Peace"].Clone() as Color;
            Color? color3 = manager["Flame"].Clone() as Color;

        }
    }

    //Prototype
    public abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    //Concrete Prototype
    public class Color : ColorPrototype
    {
        int red;
        int green;
        int blue;

        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public override ColorPrototype Clone()
        {
            Console.WriteLine($"Cloning color RGB:{red}, {green}, {blue}");
            return MemberwiseClone() as ColorPrototype;
        }
    }

    //Prototype Manager

    public class ColorManager
    {
        private Dictionary<string, ColorPrototype> colors = new Dictionary<string, ColorPrototype>();
        public ColorPrototype this[string key]
        {
            get { return colors[key]; }
            set { colors.Add(key, value); }
        }
    }
}
