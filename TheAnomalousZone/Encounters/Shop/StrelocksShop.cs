﻿using System.Runtime.CompilerServices;
using TheAnomalousZone.Encounters.Corridor;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters.Shop
{
    public class StrelocksShop : BaseEncounter
    {
        private GameManager _gameManager;

        public StrelocksShop(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public override void NextEncounter(Type encounterType)
        {
            _gameManager.Encounters.Where(x => x.GetType() == encounterType).FirstOrDefault().RunEncounter();
        }
      
        public override void RunEncounter()
        {
            
            {
                string prompt = ($"\tYou make your way down to the rustic village,\n" +
                    $"\twhere a few people keep watch, their demeanor nonviolent yet vigilant.\n" +
                    $"\tThey bear similar gear and weapons, hinting at a shared purpose and allegiance.\n" +
                    $"\tNavigating through the small settlement while following the shop signs,\n" +
                    $"\tyou eventually find yourself standing before an old Cold War bunker,\n" +
                    $"\tits entrance concealed within the earth. A neon sign above reads Strelock's Shop.\n" +
                    $"\tInside, you are greeted by an older man,\n" +
                    $"\this face weathered by the passage of time and marked by the effects of a life lived hard.\n" +
                    $"\tDespite his gruff exterior, he welcomes you with a booming voice,\n" +
                    $"\turging you to enter and explore his wares.\n");

                string[] options = {"1.Buy Plates for your Armor\n Armor + 5 - 5000 Rubles", "2.Buy Custom parts for your Weapon\nWeapon Damage + 8 - 4000 Rubles",
                    "3.Buy Bandit Chest Rig\n Ammunition + 2 - 3000 Rubles", "4.Buy First Aid Kit.\n 1000 Rubles",$"5.Use FirstAid Kit. Player's Health: {_gameManager.SelectedMainPlayer.Health}/{_gameManager.SelectedMainPlayer.MaxHealth}", "6.Check Stats.", "7.Leave Shop."};
                BaseMenu menu = new BaseMenu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:

                        if (_gameManager.SelectedMainPlayer.Rubles >= _gameManager.Items[2].Price)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= _gameManager.Items[2].Price;
                            _gameManager.SelectedMainPlayer.ArmorValue += 5;
                            Console.WriteLine("\n\tArmor increased by 5!");
                            Console.ReadKey(true);
                            RunEncounter();
                        }
                        else
                        {
                            Console.WriteLine("\n\tNot Enough Money");
                            Console.ReadKey(true);
                            RunEncounter();
                        }

                        break;

                    case 1:

                        if (_gameManager.SelectedMainPlayer.Rubles >= _gameManager.Items[3].Price)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= _gameManager.Items[3].Price;
                            _gameManager.SelectedMainPlayer.WeaponValue += 8;
                            Console.WriteLine("\n\tWeapon Damage increased by 8!");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();

                        }
                        else
                        {
                            Console.WriteLine("\n\tNot Enough Money");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();
                        }
                        break;
                    case 2:
                        if (_gameManager.SelectedMainPlayer.Rubles >= _gameManager.Items[4].Price)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= _gameManager.Items[4].Price;
                            _gameManager.SelectedMainPlayer.Ammunition += 2;
                            Console.WriteLine("\n\tAmmunition per magazine increased by 2!");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();
                        }
                        else
                        {
                            Console.WriteLine("\n\tNot Enough Money");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();
                        }

                        break;
                    case 3:


                        if (_gameManager.SelectedMainPlayer.Rubles >= _gameManager.Items[0].Price)
                        {
                            _gameManager.SelectedMainPlayer.Rubles -= _gameManager.Items[0].Price;
                            _gameManager.SelectedMainPlayer.FirstAid += 1;
                            Console.WriteLine("\n\tFirst Aid Added to your Inventory!");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();
                        }
                        else
                        {
                            Console.WriteLine("\n\tNot Enough Money");
                            Console.ReadKey(true);
                            Console.Clear();
                            RunEncounter();
                        }

                        break;
                    case 4:
                        _gameManager.SelectedMainPlayer.Heal(_gameManager.Items[0].MinAmountToHeal, _gameManager.Items[0].MaxAmountToHeal);
                        Console.ReadKey(true);
                        Console.Clear();
                        RunEncounter();
                        break;
                    case 5:
                        _gameManager.SelectedMainPlayer.DisplayStats();
                        Console.ReadKey(true);
                        Console.Clear();
                        RunEncounter();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("\n\tThank you for your service!, Who you assume to be Strelock says,\n" +
                            "\this words carrying a weight of understanding.\n" +
                            "\tI can see it in your eyes. \n" +
                            "\tThe call of the WishGiver. That towering Monolith beckons to you,\n" +
                            "\ttempting you with untold riches, or perhaps infinite knowledge or power.\n" +
                            "\tHe pauses, his gaze piercing yet compassionate.\n" +
                            "\tBe wary, for wishes are seldom what you actually want.\n" +
                            "\tBut who am I to tell a man not to follow his heart?' Good luck out there, friend. Also take this as a souvenir.\n" +
                            "\tAs he says these parting words he tosses you an old pair of binoculars\n" +
                            "\tWith his words echoing in your mind, you step out of Strelock's shop, ready to face the challenges ahead.\n\n\n");
                        Console.ReadKey(true);
                        Console.Clear();
                        NextEncounter(typeof(CorridorCrossRoads));
                        break;

                }

            }
            

        }
        
    }
}
