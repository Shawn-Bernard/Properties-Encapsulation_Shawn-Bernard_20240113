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
            PowerUp buff = new PowerUp("defying gravity", 0.0f);

            //Hero Test
            hero.Health = 100;  // Should work
            hero.Health = -50;  // Should be prevented
            Console.WriteLine($"[Name: {hero.Name}]  [Health: {hero.Health}]  [Am I alive: {hero.IsAlive}]");

            //Backpack test
            backpack.Gold = 2;
            //backpack.Capacity = 15;
            backpack.ItemCount = 20;
            Console.WriteLine($"[Gold count: {backpack.Gold}]");
            Console.WriteLine($"[Capcity: {backpack.Capacity}]");
            Console.WriteLine($"[Gold count: {backpack.Gold}]  [Capcity: {backpack.Capacity}]  [Item count: {backpack.ItemCount}]  [Is backpack full: {backpack.IsFull}]");

            //Buff test
            Console.WriteLine($"[Buff name: {buff.Name}]  [Duration: {buff.Duration}]  [Is buff active {buff.IsActive}]");
            Console.ReadLine();

            // Add more tests for other properties...
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
                if (value < 0) value = 0;
                if (value > 100) value = 100;
                health = value;
                // TODO: Validate between 0-100
            }
        }

        // 3. Computed property
        public bool IsAlive
        {
            get
            {
                if (health >= 0)
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
            this.capacity = capacity;
        }
        public int Gold
        {
            get { return gold; }
            set
            {
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
                if (value > 20) value = 20;
                capacity = value;
            }
            // TODO: Implement properties as specified
        }
        public int ItemCount
        {
            get { return itemCount; }
            set
            {
                if (value < 0) value = 0;
                if (value > capacity) value = capacity;
                itemCount = value;
            }
        }

        public bool IsFull
        {
            get
            {
                if (itemCount >= capacity)
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
            this.duration = duration;
        }
        public float Duration
        {
            //short hand for get { return duration; }
            get => duration;
            set
            {
                if (value <= 0) value = 0;
                duration = value;
                //if (value >= 0) isActive = true; 
            }
        }
        public bool IsActive
        {
            get {
                if (duration < 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
