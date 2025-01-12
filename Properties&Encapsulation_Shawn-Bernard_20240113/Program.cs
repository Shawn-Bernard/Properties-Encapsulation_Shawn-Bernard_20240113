using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties_Encapsulation_Shawn_Bernard_20240113
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instances of each class
            GameCharacter hero = new GameCharacter("Elphaba");//Setting my name
            Inventory backpack = new Inventory(25); //Setting my capcity
            PowerUp buff = new PowerUp("defying gravity", 10.0f);//Setting my buff name & duration 

            //Hero Test
            hero.Health = 100;  // Should work
            hero.Health = -50;  // Should be prevented
            Console.WriteLine($"[Name: {hero.Name}]  [Health: {hero.Health}]  [Am I alive: {hero.IsAlive}]");

            //Backpack test
            backpack.Gold = 5;
            backpack.Capacity = 30;
            backpack.ItemCount = 25;
            Console.WriteLine($"[Gold count: {backpack.Gold}]  [Capcity: {backpack.Capacity}]  [Item count: {backpack.ItemCount}]  [Is backpack full: {backpack.IsFull}]");

            //Buff test
            buff.Duration = -20;
            Console.WriteLine($"[Buff name: {buff.Name}]  [Duration: {buff.Duration}]  [Is buff active {buff.IsActive}]");
            Console.ReadLine();

        }
    }
    public class GameCharacter
    {
        // 1. Auto-implemented property
        public string Name { get; private set; }

        // 2. Full property with validation
        private int health;

        public GameCharacter(string name)
        {
            Name = name;
        }

        public int Health
        {
            get { return health; }
            set
            {
                //So the value doesn't go under 0
                if (value < 0) value = 0;
                //So my value doesn't go over 100
                if (value > 100) value = 100;
                health = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                //if my health is greater than 0 returns true
                if (health > 0)
                {
                    return true;
                }
                return false;
                // TODO: Return true if health > 0
            }
        }
    }

    public class Inventory
    {
        private int gold;

        private int capacity;

        private int itemCount;

        public Inventory(int capacity)
        {
            Capacity = capacity;
        }
        public int Gold
        {
            get { return gold; }
            set
            {
                //So the value doesn't go under 0
                if (value < 0) value = 0;
                gold = value;
            }
        }
        public int Capacity
        {
            get { return capacity; }
            set
            {
                if (value < 0) value = 0;
                capacity = value;
            }
            // TODO: Implement properties as specified
        }
        public int ItemCount
        {
            get { return itemCount; }
            set
            {
                //So the value doesn't go under 0
                if (value < 0) value = 0;
                //If my value is greater than the capcity, make my value into the capcity
                if (value > capacity) value = capacity;
                itemCount = value;
            }
        }

        public bool IsFull
        {
            get
            {
                //If my item count is equal to my capcity return true
                if (itemCount == capacity)
                {
                    return true;
                }
                return false;
            }
        }
    }
    public class PowerUp
    {
        public string Name { get; private set; }

        private float duration;

        public PowerUp(string name, float duration)
        {
            Name = name;
            Duration = duration;
        }
        public float Duration
        {
            //short hand for get { return duration; }
            get => duration; 
            set
            {
                //So my value doesn't go under 0
                if (value < 0) value = 0;
                duration = value;
            }
        }
        public bool IsActive
        {
            get {
                //If my duration is greater then 0, returns true
                if (duration > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
