﻿using System.Media;
using TheAnomalousZone.Encounters.Swamp;
using TheAnomalousZone.NewFolder;
using TheAnomalousZone.Printer;

namespace TheAnomalousZone.Encounters
{
    public class IntroCharacterCreation 
    {
        private GameManager _gameManager;
        
        public IntroCharacterCreation(GameManager gameManager)
        {
            _gameManager = gameManager;
             RunGenerateMainCharacter();
        }
        public void RunGenerateMainCharacter()
        {

         string prompt = $"{StoryScript.IntroCharacterCreationPrompt}";

            string[] options = { "1.You were a Soldier.", "2.You were a Sniper.", "3.You were a Scientist.\n" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:

                    Console.WriteLine("\n\tYou remember you were a Sergeant in the Army.\n" +
                        "\tGripping your heavy but well maintained Kalashnikov Rifle you head into the unknown.");
                    Console.ReadKey(true);
                    var selectedSoldier = _gameManager.AllMainCharacters.Where(x => x.Name == "Sergei").FirstOrDefault();
                    if(selectedSoldier is not null)
                        _gameManager.SelectedMainPlayer = selectedSoldier;
                    break;
                case 1:
                    Console.WriteLine("\n\tYou remember you were a Mercenary that fought in foreign lands.\n" +
                        "\tGripping your well worn but functional Bolt Action Rifle you head into the unknown.");
                    Console.ReadKey(true);
                    var selectedSniper = _gameManager.AllMainCharacters.Where(x => x.Name == "Artyom").FirstOrDefault();
                    if (selectedSniper is not null)
                        _gameManager.SelectedMainPlayer = selectedSniper;
                   
                    break;
                case 2:
                    Console.WriteLine("\n\tYou remember were a Scientist working for the Government trying to understand the Zone.\n" +
                        "\tGripping your Old Soviet Surplus Handgun you head into the unknown.");
                    Console.ReadKey(true);
                    var selectedScientist = _gameManager.AllMainCharacters.Where(x => x.Name == "Dimitri").FirstOrDefault();
                    if (selectedScientist is not null)
                        _gameManager.SelectedMainPlayer = selectedScientist;
                    break;

            }

            Console.ResetColor();
        }

       

       
    }
}
