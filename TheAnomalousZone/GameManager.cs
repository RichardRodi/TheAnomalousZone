﻿using System.Data;
using TheAnomalousZone.Encounters;
using TheAnomalousZone.Encounters.Corridor;
using TheAnomalousZone.Encounters.PowerPlant;
using TheAnomalousZone.Encounters.Shop;
using TheAnomalousZone.Encounters.Swamp;
using TheAnomalousZone.Enemies;
using TheAnomalousZone.Items;
using TheAnomalousZone.MainCharacter;

namespace TheAnomalousZone
{
    public class GameManager
    {
        public MainPlayer SelectedMainPlayer { get; set; }

        public List<MainPlayer> AllMainCharacters { get; set; } = new List<MainPlayer>();

        public List<BaseEnemy> Enemies { get; set; } = new List<BaseEnemy>();

        public List<BaseEncounter> Encounters { get; set; } = new List<BaseEncounter>();

        public List<ItemBase> Items { get; set; } = new List<ItemBase>();

        public GameManager(bool seedData = false)
        {
            if (seedData)
            {
                GenerateMainCharacter();
                GenerateAllEnemies();
                GenerateAllEncounters();
                GenerateAllFirstAid();
            }
        }
        public void GenerateMainCharacter()
        {


            AllMainCharacters.Add(new MainPlayer(name: "Sergei", health: 50, radiation: 0, damage: 2, armorValue: 7,
                firstAid: 1, weaponValue: 10, ammunitionPerMagazine: 4, speed: 8, "You were a soldier in the Ukranian Army", rubles: 500, maxHealth: 50));

            AllMainCharacters.Add(new MainPlayer(name: "Artyom", health: 35, radiation: 0, damage: 1, armorValue: 5,
                firstAid: 3, weaponValue: 18, ammunitionPerMagazine: 1, speed: 12, "You were a sniper in the Ukranian Army", rubles: 1000, maxHealth: 35));

            AllMainCharacters.Add(new MainPlayer(name: "Dimitri", health: 40, radiation: 0, damage: 1, armorValue: 6,
                firstAid: 4, weaponValue: 9, ammunitionPerMagazine: 9, speed: 10, "You were a scientist in the Ukranian Army", rubles: 800, maxHealth: 40));
        }


        public void GenerateAllEnemies()
        {

            Enemies.Add(new Bandits("Bandit Soldier", health: 32, damage: 2, armorValue: 4,
                firstAid: 1, weaponValue: 6, ammunition: 8, speed: 10, numberOfShotsFired: 3));

            Enemies.Add(new Bandits("Bandit Leader", health: 28, damage: 1, armorValue: 5,
                firstAid: 2, weaponValue: 9, ammunition: 5, speed: 12, numberOfShotsFired: 1));

            Enemies.Add(new Bandits("Bandit Scout", health: 28, damage: 1, armorValue: 3,
                firstAid: 1, weaponValue: 9, ammunition: 2, speed: 14, numberOfShotsFired: 2));

            Enemies.Add(new MutatedAnimals("Mutated Boar", health: 20, damage: 8, armorValue: 4, radiationDamage: 1,
                  speed: 10, "This is a mutated boar"));

            Enemies.Add(new MutatedAnimals("Chimera", health: 60, damage: 12, armorValue: 5, radiationDamage: 1,
            speed: 9, "This is a mutated chimera"));

            Enemies.Add(new MutatedAnimals("Snork", health: 30, damage: 7, armorValue: 5, radiationDamage: 1,
                 speed: 15, "This is a mutated Snork"));

            Enemies.Add(new MutatedAnimals("Snork", health: 30, damage: 7, armorValue: 5, radiationDamage: 1,
                speed: 15, "This is a mutated Snork"));

            Enemies.Add(new MutatedAnimals("Snork", health: 30, damage: 7, armorValue: 5, radiationDamage: 1,
                speed: 15, "This is a mutated Snork"));

            Enemies.Add(new Bandits("Monolith Soldier", health: 35, damage: 2, armorValue: 5,
                firstAid: 1, weaponValue: 7, ammunition: 8, speed: 10, numberOfShotsFired: 3));

            Enemies.Add(new Bandits("Monolith Soldier", health: 35, damage: 2, armorValue: 5,
               firstAid: 1, weaponValue: 7, ammunition: 8, speed: 10, numberOfShotsFired: 3));

            Enemies.Add(new Bandits("Monolith Soldier", health: 35, damage: 2, armorValue: 5,
                firstAid: 1, weaponValue: 7, ammunition: 8, speed: 10, numberOfShotsFired: 3));

            Enemies.Add(new Bandits("Monolith Leader", health: 50, damage: 2, armorValue: 9,
                firstAid: 1, weaponValue: 10, ammunition: 8, speed: 10, numberOfShotsFired: 3));

        }

        public void GenerateAllEncounters()
        {

            var swampIntro = new SwampIntro(this);
            Encounters.Add(swampIntro);

            var dilapidatedBuilding = new DilapidatedBuilding(this);
            Encounters.Add(dilapidatedBuilding);

            var wareHouse = new WareHouse(this);
            Encounters.Add(wareHouse);

            var strelocksShop = new StrelocksShop(this);
            Encounters.Add(strelocksShop);

            var abandonedChurch = new AbandonedChurch(this);
            Encounters.Add(abandonedChurch);

            var corridorIntro = new CorridorIntro(this);
            Encounters.Add(corridorIntro);

            var corridorCrossRoads = new CorridorCrossRoads(this);
            Encounters.Add(corridorCrossRoads);

            var factoryEntrance = new FactoryEntrance(this);
            Encounters.Add(factoryEntrance);

            var mainRoad = new MainRoad(this);
            Encounters.Add(mainRoad);

            var mainRoadContinued = new MainRoadContinued(this);
            Encounters.Add(mainRoadContinued);

            var finalCorridorSection = new FinalCorridorSection(this);
            Encounters.Add(finalCorridorSection);

            var powerPlantHallway = new PowerPlantHallway(this);
            Encounters.Add(powerPlantHallway);

            var powerPlantMaze = new PowerPlantMaze(this);
            Encounters.Add(powerPlantMaze);

            var monolithEnd = new MonolithEnd(this);
            Encounters.Add(monolithEnd);

            var factoryMainArea = new FactoryMainArea(this);
            Encounters.Add(factoryMainArea);
        }

        public void GenerateAllFirstAid()
        {
            Items.Add(new ItemBase(iD: 0, "Basic FirstAid Kit", price: 1000, minAmountToHeal: 10, maxAmountToHeal: 15));
            Items.Add(new ItemBase(iD: 1, "Military FirstAid Kit", price: 2000, minAmountToHeal: 15, maxAmountToHeal: 20));
            Items.Add(new ItemBase(iD: 2, "Armor Mod", price: 5000, minAmountToHeal: 0, maxAmountToHeal: 0));
            Items.Add(new ItemBase(iD: 2, "Weapon Mod", price: 4000, minAmountToHeal: 0, maxAmountToHeal: 0));
            Items.Add(new ItemBase(iD: 2, "Ammunition Mod", price: 3000, minAmountToHeal: 0, maxAmountToHeal: 20));
        }
        public void RunGame()
        {
            TitlePage mainMenu = new TitlePage();


            var generateMainCharacter = mainMenu.RunTitlePage();
            if (generateMainCharacter)
            {
                IntroCharacterCreation createMainCharacter = new IntroCharacterCreation(this);
            }

            var firstEncounter = Encounters.Where(x => x.GetType() == typeof(SwampIntro)).FirstOrDefault();
            if (firstEncounter != null)
                firstEncounter.RunEncounter();
            else
                RunGame();
        }

    }
}
