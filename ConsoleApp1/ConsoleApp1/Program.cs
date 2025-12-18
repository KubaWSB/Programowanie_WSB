using System;
using System.Collections.Generic;
using System.Linq;

namespace CalorieCalculator
{
    public class FoodItem
    {
        public string Name { get; set; }
        public double CaloriesPer100g { get; set; }

        public FoodItem(string name, double caloriesPer100g)
        {
            Name = name;
            CaloriesPer100g = caloriesPer100g;
        }

        public double CalculateCalories(double weightGrams)
        {
            return (CaloriesPer100g * weightGrams) / 100;
        }
    }

    public class Meal
    {
        public string Name { get; set; }
        private List<(FoodItem Item, double Weight)> items;

        public Meal(string name)
        {
            Name = name;
            items = new List<(FoodItem, double)>();
        }

        public void AddFood(FoodItem foodItem, double weightGrams)
        {
            items.Add((foodItem, weightGrams));
            Console.WriteLine($"Dodano {weightGrams}g {foodItem.Name} do posiłku: {Name}");
        }

        public double GetTotalCalories()
        {
            return items.Sum(x => x.Item.CalculateCalories(x.Weight));
        }
    }

    public class DailyIntake
    {
        public DateTime Date { get; set; }
        private List<Meal> meals;

        public DailyIntake(DateTime date)
        {
            Date = date;
            meals = new List<Meal>();
        }

        public void AddMeal(Meal meal)
        {
            meals.Add(meal);
        }

        public double GetDailyTotal()
        {
            return meals.Sum(m => m.GetTotalCalories());
        }

        public void DisplaySummary()
        {
            Console.WriteLine($"\n--- Podsumowanie dnia: {Date.ToShortDateString()} ---");
            foreach (var meal in meals)
            {
                Console.WriteLine($"Posiłek: {meal.Name,-12} | {meal.GetTotalCalories(),8:F2} kcal");
            }
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"RAZEM: {GetDailyTotal(),21:F2} kcal");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FoodItem apple = new FoodItem("Jabłko", 52);
            FoodItem bread = new FoodItem("Chleb żytni", 259);
            FoodItem butter = new FoodItem("Masło", 717);

            Meal breakfast = new Meal("Śniadanie");
            breakfast.AddFood(bread, 60);
            breakfast.AddFood(butter, 10);

            Meal snack = new Meal("Przekąska");
            snack.AddFood(apple, 200);

            DailyIntake daily = new DailyIntake(DateTime.Now);
            daily.AddMeal(breakfast);
            daily.AddMeal(snack);

            daily.DisplaySummary();

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}