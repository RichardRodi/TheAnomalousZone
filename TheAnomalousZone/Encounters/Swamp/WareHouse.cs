﻿using TheAnomalousZone.Combat;
using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Encounters.Swamp
{
    public class WareHouse : BaseEncounter
    {
        private GameManager _gameManager;

        public WareHouse(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public override void RunEncounter()

        {

            string prompt = ($"\n\tAs you approach the source of the voice when you realize you are surrounded by a group of armed men\n" +
                $"\tThe man who is speaking to you seems to be their leader.\n" +
                $"\tIn a snarled voice he politely asks you to empty your pockets and be on your way.\n\n");

            string[] options = { "1.Raise you rifle at the Bandit Leader!", "2.Run!", "3.Take a Closer Look at the Bandit." };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\n\tWithout hesitating you raise your rifle to the bandit leader.\n" +
                        "\tWith a loud deafening thud you begin to fire at him.");
                    Console.ReadKey(true);
                    Console.Clear();
                    BanditCombat.FightPlayerFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[1]);
                    WareHouseDefeatedBanditLeader();
                    break;

                case 1:
                    Console.WriteLine("\n\tYou attempt to run away from the Bandits.");
                    bool getAway = RunAway.Run(_gameManager.SelectedMainPlayer, _gameManager.Enemies[1]);
                    if (!getAway)
                    {

                        Console.ReadKey(true);
                        Console.Clear();
                        Console.WriteLine("\n\tThe Bandit Leader swiftly disengages his safety and opens fire before you can react,\n" +
                            "\tleaving you with little time to escape");
                        BanditCombat.FightBanditFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[1]);
                        WareHouseDefeatedBanditLeader();
                    }

                    else
                    {
                        Console.WriteLine("\n\tDeciding not to mess with this unsavory looking people,\n" +
                            "\tyou make your way out of this area and proceed along a small dirt path.\n" +
                            "\tYou notice the only way out of this terrible bog is through a nearby looming structure.\n" +
                            "\tAs you get closer to the structure you realize that it is a church.");
                        Console.ReadKey(true);
                        NextEncounter(typeof(AbandonedChurch));
                    }
                    break;
                case 2:
                    Console.WriteLine("\n\tYou take a closer look at the bandit.");
                    _gameManager.Enemies[1].DisplayStats();
                    Console.ReadKey(true);
                    Console.Clear();
                    SlowPrint.Print("\n\tWhile you took your time inspecting the Bandit Leader, \n" +
                        "\the quietly unclicks the safety on his rifle and begins to fire at you.");
                    Console.ReadKey(true);
                    Console.Clear();
                    BanditCombat.FightBanditFirst(_gameManager.SelectedMainPlayer, _gameManager.Enemies[1]);
                    WareHouseDefeatedBanditLeader();
                    break;

            }

        }
        private void WareHouseDefeatedBanditLeader()
        {
            {

                string prompt = ($"\n\tThe Bandit leader now lies face down in a pool of his own blood.\n" +
                    $"\tAnticipating retaliation, you swiftly pivot your firearm muzzles towards the remaining bandits locations,\n" +
                    $"\tbut it seems the demise of their leader has shattered any semblance of courage among them. \n" +
                    $"\tPausing to catch your breath, you survey your surroundings.\n\n");


                string[] options = { "1.Check the Area.", "2.Check the Inside of the Warehouse.", "3.Leave Area.", $"4.Use FirstAid Kit.  Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", $"5.Check Player Stats.\n\n" };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("\n\tYou are standing in front of a large warehouse\n" +
                            "\tthat seems to have been of some agricultural importance.\n" +
                            "\tThere is an eerie crackling that is coming from the inside of the warehouse.");
                        Console.ReadKey(true);
                        WareHouseDefeatedBanditLeader();
                        break;

                    case 1:
                        Console.WriteLine("\n\tAs you step through the threshold of the warehouse's expansive entrance,\n" +
                            "\tan astounding sight greets you:\n" +
                            "\tlarge bales of hay erupting with fiery geysers. Despite appearances,\n" +
                            "\tthe hay isn't consumed by flames but rather generates this curious anomaly.\n\n");
                        Console.ReadKey(true);
                        RunWarehouseAnomaly();
                        break;
                    case 2:
                        Console.WriteLine("\n\tYou decide to not mess with this anomaly\n" +
                            "\tand make your way out of this area and proceed along a small dirt path.\n" +
                            "\tYou notice the only way out of this terrible bog is through a nearby looming structure.\n" +
                            "\tAs you get closer to the structure you realize that it is a church.");
                        Console.ReadKey(true);
                        NextEncounter(typeof(AbandonedChurch));

                        break;
                    case 3:
                        _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                        Console.ReadKey(true);
                        Console.Clear();
                        WareHouseDefeatedBanditLeader();
                        break;

                    case 4:
                        _gameManager.SelectedMainPlayer.DisplayStats();
                        Console.ReadKey(true);
                        Console.Clear();
                        WareHouseDefeatedBanditLeader();
                        break;
                }

                Console.ResetColor();

            }
        }
        private void RunWarehouseAnomaly()
        {
            {

                string prompt = ($"\n\tYou approach the Anomaly, the searing heat from the flames washes over your face,\n" +
                    $"\tintensifying with each step.\n" +
                    $"\tAmidst the fiery tumult, something draws your gaze, a small spherical object weaving through the flames. \n" +
                    $"\tIts presence flickers, appearing and disappearing in a mesmerizing dance. \n" +
                    $"\tIt's as though it calls to you, a silent but compelling invitation.\n" +
                    $"\tSomething in your brain wants to get this object.\n\n");

                string[] options = {"1.Climb the rafters to try and avoid the flames.",
                    "2.Do your best to run through the flames and grab the object.",
                    "3.Leave the Warehouse.", $"4.Use FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", $"5.Check Player Stats.\n\n" };
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("\n\tYou climb the rafters of the roof to try and avoid the flames,\n" +
                            "\tThe brittle rafters give way and you fall into a large open flame scorching your arm.\n");
                        Console.ReadKey(true);
                        _gameManager.SelectedMainPlayer.PlayerDamage(20); ;
                        Console.WriteLine("\n\tYou pick yourself up and gaze at your burnt Arm.\n" +
                            "\tYou definitely felt the extreme heat on your skin as you reached for the object.\n" +
                            "\tGrasping the spherical item a rush of light-headedness,\n" +
                            "\tthis briefly overwhelms you before dissipating and coursing down your body.\n" +
                            "\tIn an instant you feel a newfound lightness and agility surge through you.");
                        Console.ReadKey(true);
                        _gameManager.SelectedMainPlayer.Speed += 3;
                        Console.WriteLine("\nYou are now faster: Speed + 3!\n" +
                            "\tSince there is nothing left of interest in this area you decide to move on from the warehouse.");
                        Console.ReadKey(true);
                        NextEncounter(typeof(AbandonedChurch));


                        break;

                    case 1:
                        if (_gameManager.SelectedMainPlayer.Speed > 10)
                        {
                            Console.WriteLine("\n\tYou sprint as fast as you can through the flames to grab the object.");
                            _gameManager.SelectedMainPlayer.PlayerDamage(5);
                            Console.ReadKey(true);
                            Console.WriteLine("\n\tYou definitely felt the extreme heat on your skin as you reached for the object.\n" +
                                "\tGrasping the spherical item,\n" +
                                "\ta rush of light-headedness briefly overwhelms you before dissipating and coursing down your body.\n" +
                                "\tIn an instant,\n" +
                                "\tyou feel a newfound lightness and agility surge through you.");
                            _gameManager.SelectedMainPlayer.Speed += 3;
                            Console.WriteLine("\n\tYou are now faster Speed + 3!\n" +
                                "\tSince there is nothing left of interest in this area you decide to move on from the warehouse.");
                            Console.ReadKey(true);
                            Console.WriteLine("\n\tYou make your way out of this area and proceed along a small dirt path.\n" +
                            "\tYou notice the only way out of this terrible bog is through a nearby looming structure.\n" +
                            "\tAs you get closer to the structure you realize that it is a church.");
                            NextEncounter(typeof(AbandonedChurch));
                        }
                        else
                        {
                            Console.WriteLine("\n\tYou sprint as fast as you can through the flames to grab the object.\n" +
                                "\tYou are not quite quick enough and get severely burned in the process.");
                            _gameManager.SelectedMainPlayer.PlayerDamage(15);
                            Console.ReadKey(true);
                            Console.Clear();
                            Console.WriteLine("\n\tYou definitely felt the extreme heat on your skin as you reached for the object.\n" +
                                "\tGrasping the spherical item,\n" +
                                "\ta rush of light-headedness briefly overwhelms you before dissipating and coursing down your body.\n" +
                                "\tIn an instant,\n" +
                                "\tyou feel a newfound lightness and agility surge through you.");
                            Console.ReadKey(true);
                            _gameManager.SelectedMainPlayer.Speed += 2;
                            Console.WriteLine("\n\tYou are now faster: Speed + 2!");
                            Console.ReadKey(true);
                            Console.WriteLine("\n\tSince there is nothing left of interest in this area you decide to move on from the warehouse.");
                            Console.ReadKey(true);
                            Console.Clear();
                            Console.WriteLine("\n\tYou make your way out of this area and proceed along a small dirt path.\n" +
                            "\tYou notice the only way out of this terrible bog is through a nearby looming structure.\n" +
                            "\tAs you get closer to the structure you realize that it is a church.");
                            Console.ReadKey(true);
                            NextEncounter(typeof(AbandonedChurch));
                        }

                        Console.WriteLine("\n\tYou make your way out of this area and proceed along a small dirt path.\n" +
                            "\tYou notice the only way out of this terrible bog is through a nearby looming structure.\n" +
                            "\tAs you get closer to the structure you realize that it is a church.");
                        Console.ReadKey(true);
                        NextEncounter(typeof(AbandonedChurch));
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("\n\tYou look at the strange scene in front of you and decide to turn around and leave it alone.");
                        Console.ReadKey(true);
                        WareHouseDefeatedBanditLeader();
                        break;
                    case 3:
                        _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                        Console.ReadKey(true);
                        Console.Clear();
                        RunWarehouseAnomaly();
                        break;

                    case 4:
                        _gameManager.SelectedMainPlayer.DisplayStats();
                        Console.ReadKey(true);
                        Console.Clear();
                        RunWarehouseAnomaly();
                        break;

                }

                Console.ResetColor();
            }

        }
        public override void NextEncounter(Type encounterType)
        {
            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();
        }


    }
}

