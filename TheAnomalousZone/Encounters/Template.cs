﻿using TheAnomalousZone.MainCharacter;
using TheAnomalousZone.NewFolder;

namespace TheAnomalousZone.Encounters
{
    internal class Template
    {
        public static void RunEncounter(MainPlayer player)

        {

            string prompt = ($"");

            string[] options = { "Play Game", "Credits", "Exit" };
            BaseMenu menu = new BaseMenu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:

                    break;

                case 1:

                    break;
                case 2:

                    break;

            }

            Console.ResetColor();
        }
    }
}