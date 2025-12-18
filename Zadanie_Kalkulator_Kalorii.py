class FoodItem:
    def __init__(self, name, calories_per_100g):
        self.name = name
        self.calories_per_100g = calories_per_100g

    def calculate_calories(self, weight_grams):
        return (self.calories_per_100g * weight_grams) / 100


class Meal:
    def __init__(self, name):
        self.name = name
        self.items = []

    def add_food(self, food_item, weight_grams):
        self.items.append((food_item, weight_grams))
        print(f"Dodano {weight_grams}g {food_item.name} do posiłku: {self.name}")

    def get_total_calories(self):
        total = sum(item.calculate_calories(weight) for item, weight in self.items)
        return total


class DailyIntake:
    def __init__(self, date):
        self.date = date
        self.meals = []

    def add_meal(self, meal):
        self.meals.append(meal)

    def get_daily_total(self):
        return sum(meal.get_total_calories() for meal in self.meals)

    def display_summary(self):
        print(f"\n--- Podsumowanie dnia: {self.date} ---")
        for meal in self.meals:
            print(f"Posiłek: {meal.name} | {meal.get_total_calories():.2f} kcal")
        print("-" * 35)
        print(f"RAZEM: {self.get_daily_total():.2f} kcal")



jablko = FoodItem("Jabłko", 52)
chleb = FoodItem("Chleb", 259)
maslo = FoodItem("Masło", 717)

sniadanie = Meal("Śniadanie")
sniadanie.add_food(chleb, 60)
sniadanie.add_food(maslo, 10)


przekaska = Meal("Przekąska")
przekaska.add_food(jablko, 200)

dzisiaj = DailyIntake("18-12-2025")
dzisiaj.add_meal(sniadanie)
dzisiaj.add_meal(przekaska)

dzisiaj.display_summary()