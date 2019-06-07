﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Legenden_der_Alten_Zeit_Lib.Ressources
{
    public class Ressource
    {
        RessourceData baseData;
        public string Name => baseData.Name;
        public string DescriptionPath
        {
            get => baseData.RTF_Description_Path;
            set => baseData.RTF_Description_Path = value;
        }
        public Dictionary<string, int[]> DepositRanges
        {
            get => baseData.DepositRanges;
            set => baseData.DepositRanges = value;
        }

        private void InitializeData()
        {
            DepositRanges = new Dictionary<string, int[]>
            {
                [DepositSizes.VerySmall] = new int[2],
                [DepositSizes.Small] = new int[2],
                [DepositSizes.Medium] = new int[2],
                [DepositSizes.Large] = new int[2],
                [DepositSizes.VeryLarge] = new int[2]
            };
        }
    }

    [Serializable]
    public struct RessourceData
    {
        public string Name { get; set; }
        public string RTF_Description_Path { get; set; }
        public Dictionary<string, int[]> DepositRanges { get; set; }

        public List<string> NeededTileAttributes { get; set; }
        public List<string> ForbiddenTileAttributes { get; set; }
    }
}
