using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.UI;

namespace DiademCalculator;

public struct DiademResourceInfo
{
    public readonly uint Id;
    public readonly int Set;
    public readonly int ScripsReward;
    public readonly int PointsReward;
    public readonly int Grade;

    public DiademResourceInfo(uint id, int set, int scripsReward, int pointsReward, int grade)
    {
        Id = id;
        Set = set;
        ScripsReward = scripsReward;
        PointsReward = pointsReward;
        Grade = grade;
    }
}

public static class DiademResources
{
    public static int MinPoints, BtnPoints, FshPoints;
    public static int MinScrips, BtnScrips, FshScrips;
    public static int Grade2Btn, Grade3Btn, Grade4Btn;
    public static int Grade2Min, Grade3Min, Grade4Min;
    public static int Grade2Fsh, Grade3Fsh, Grade4Fsh;
    public static uint Grade2BtnAch, Grade3BtnAch, Grade4BtnAch;
    public static uint Grade2MinAch, Grade3MinAch, Grade4MinAch;
    public static uint Grade2FshAch, Grade3FshAch, Grade4FshAch;
    public static uint Btn500K, Min500K, Fsh500K;
    public static uint CurrentAchievement;

    private static readonly List<DiademResourceInfo> MinerPreset =
    [
        new(29939, 10, 0, 3, 2), //Grade 2 Artisanal Skybuilders' Cloudstone
        new(29940, 10, 0, 3, 2), //Grade 2 Artisanal Skybuilders' Rock Salt
        new(29941, 10, 0, 3, 2), //Grade 2 Artisanal Skybuilders' Spring Water
        new(29942, 10, 0, 3, 2), //Grade 2 Artisanal Skybuilders' Aurum Regis Sand
        new(29943, 10, 0, 3, 2), //Grade 2 Artisanal Skybuilders' Jade
        new(29946, 10, 0, 4, 2), //Grade 2 Skybuilders' Umbral Flarestone
        new(29947, 10, 0, 4, 2), //Grade 2 Skybuilders' Umbral Levinshard

        new(31311, 5, 0, 2, 3), //Grade 3 Artisanal Skybuilders' Cloudstone
        new(31312, 5, 0, 2, 3), //Grade 3 Artisanal Skybuilders' Basilisk Egg
        new(31313, 5, 0, 2, 3), //Grade 3 Artisanal Skybuilders' Alumen
        new(31314, 5, 0, 2, 3), //Grade 3 Artisanal Skybuilders' Clay
        new(31315, 5, 0, 2, 3), //Grade 3 Artisanal Skybuilders' Granite
        new(31318, 5, 0, 2, 3), //Grade 3 Skybuilders' Umbral Magma Shard
        new(31319, 5, 0, 2, 3), //Grade 3 Skybuilders' Umbral Levinite

        new(32007, 5, 1, 0, 5),  //Grade 4 Skybuilders' Iron Ore
        new(32008, 5, 1, 0, 5),  //Grade 4 Skybuilders' Iron Sand
        new(32012, 5, 1, 0, 5),  //Grade 4 Skybuilders' Ore
        new(32013, 5, 1, 0, 5),  //Grade 4 Skybuilders' Rock Salt
        new(32014, 5, 1, 0, 5),  //Grade 4 Skybuilders' Mythrite Sand
        new(32020, 5, 2, 0, 5),  //Grade 4 Skybuilders' Electrum Ore
        new(32021, 5, 2, 0, 5),  //Grade 4 Skybuilders' Alumen
        new(32022, 5, 2, 0, 5),  //Grade 4 Skybuilders' Spring Water
        new(32023, 5, 2, 0, 5),  //Grade 4 Skybuilders' Gold Sand
        new(32024, 5, 2, 0, 5),  //Grade 4 Skybuilders' Ragstone
        new(32030, 5, 3, 13, 5), //Grade 4 Skybuilders' Gold Ore
        new(32031, 5, 3, 13, 5), //Grade 4 Skybuilders' Finest Rock Salt
        new(32032, 5, 3, 13, 5), //Grade 4 Skybuilders' Truespring Water
        new(32033, 5, 3, 13, 5), //Grade 4 Skybuilders' Mineral Sand
        new(32034, 5, 3, 13, 5), //Grade 4 Skybuilders' Bluespirit Ore
        new(32040, 5, 3, 13, 4), //Grade 4 Artisanal Skybuilders' Cloudstone
        new(32041, 5, 3, 13, 4), //Grade 4 Artisanal Skybuilders' Spring Water
        new(32042, 5, 3, 13, 4), //Grade 4 Artisanal Skybuilders' Ice Stalagmite
        new(32043, 5, 3, 13, 4), //Grade 4 Artisanal Skybuilders' Silex
        new(32044, 5, 3, 13, 4), //Grade 4 Artisanal Skybuilders' Prismstone
        new(32047, 5, 5, 15, 4), //Grade 4 Skybuilders' Umbral Flarerock
        new(32048, 5, 5, 15, 4)
    ];

    private static readonly List<DiademResourceInfo> BotanistPreset =
    [
        new(29934, 10, 0, 3, 2), //Grade 2 Artisanal Skybuilders' Log
        new(29935, 10, 0, 3, 2), //Grade 2 Artisanal Skybuilders' Hardened Sap
        new(29936, 10, 0, 3, 2), //Grade 2 Artisanal Skybuilders' Wheat
        new(29937, 10, 0, 3, 2), //Grade 2 Artisanal Skybuilders' Cotton Boll
        new(29938, 10, 0, 3, 2), //Grade 2 Artisanal Skybuilders' Dawn Lizard
        new(29944, 10, 0, 4, 2), //Grade 2 Skybuilders' Umbral Galewood Log
        new(29945, 10, 0, 4, 2), //Grade 2 Skybuilders' Umbral Earthcap

        new(31306, 5, 0, 2, 3), //Grade 3 Artisanal Skybuilders' Log
        new(31307, 5, 0, 2, 3), //Grade 3 Artisanal Skybuilders' Amber
        new(31308, 5, 0, 2, 3), //Grade 3 Artisanal Skybuilders' Cotton Boll
        new(31309, 5, 0, 2, 3), //Grade 3 Artisanal Skybuilders' Rice
        new(31310, 5, 0, 2, 3), //Grade 3 Artisanal Skybuilders' Vine
        new(31316, 5, 0, 2, 3), //Grade 3 Skybuilders' Umbral Galewood Sap
        new(31317, 5, 0, 2, 3), //Grade 3 Skybuilders' Umbral Tortoise

        new(32005, 5, 1, 0, 5),  //Grade 4 Skybuilders' Switch
        new(32006, 5, 1, 0, 5),  //Grade 4 Skybuilders' Hemp
        new(32009, 5, 1, 0, 5),  //Grade 4 Skybuilders' Mahogany Log
        new(32010, 5, 1, 0, 5),  //Grade 4 Skybuilders' Sesame
        new(32011, 5, 1, 0, 5),  //Grade 4 Skybuilders' Cotton Boll
        new(32015, 5, 2, 0, 5),  //Grade 4 Skybuilders' Spruce Log
        new(32016, 5, 2, 0, 5),  //Grade 4 Skybuilders' Mistletoe
        new(32017, 5, 2, 0, 5),  //Grade 4 Skybuilders' Toad
        new(32018, 5, 2, 0, 5),  //Grade 4 Skybuilders' Vine
        new(32019, 5, 2, 0, 5),  //Grade 4 Skybuilders' Tea Leaves
        new(32025, 5, 3, 13, 5), //Grade 4 Skybuilders' White Cedar Log
        new(32026, 5, 3, 13, 5), //Grade 4 Skybuilders' Primordial Resin
        new(32027, 5, 3, 13, 5), //Grade 4 Skybuilders' Wheat
        new(32028, 5, 3, 13, 5), //Grade 4 Skybuilders' Gossamer Cotton Boll
        new(32029, 5, 3, 13, 5), //Grade 4 Skybuilders' Tortoise
        new(32035, 5, 3, 13, 4), //Grade 4 Artisanal Skybuilders' Log
        new(32036, 5, 3, 13, 4), //Grade 4 Artisanal Skybuilders' Raspberry
        new(32037, 5, 3, 13, 4), //Grade 4 Artisanal Skybuilders' Caiman
        new(32038, 5, 3, 13, 4), //Grade 4 Artisanal Skybuilders' Cocoon
        new(32039, 5, 3, 13, 4), //Grade 4 Artisanal Skybuilders' Barbgrass
        new(32045, 5, 5, 15, 4), //Grade 4 Skybuilders' Umbral Galewood Branch
        new(32046, 5, 5, 15, 4)
    ];


    private static readonly List<DiademResourceInfo> FisherPreset =
    [
        new(30008, 1, 0, 15, 2),  //Grade 2 Artisanal Skybuilders' Pterodactyl
        new(30009, 1, 0, 15, 2),  //Grade 2 Artisanal Skybuilders' Skyfish
        new(30006, 1, 0, 158, 2), //Grade 2 Artisanal Skybuilders' Rhomaleosaurus
        new(30007, 1, 0, 158, 2), //Grade 2 Artisanal Skybuilders' Gobbie Mask
        new(30010, 1, 0, 15, 2),  //Grade 2 Artisanal Skybuilders' Cometfish
        new(30011, 1, 0, 15, 2),  //Grade 2 Artisanal Skybuilders' Anomalocaris
        new(30012, 1, 0, 15, 2),  //Grade 2 Artisanal Skybuilders' Rhamphorhynchus
        new(30013, 1, 0, 15, 2),  //Grade 2 Artisanal Skybuilders' Dragon's Soul

        new(31596, 1, 0, 12, 3),  //Grade 3 Artisanal Skybuilders' Oscar
        new(31597, 1, 0, 22, 3),  //Grade 3 Artisanal Skybuilders' Blind Manta
        new(31598, 1, 0, 83, 3),  //Grade 3 Artisanal Skybuilders' Mosasaur
        new(31599, 1, 0, 93, 3),  //Grade 3 Artisanal Skybuilders' Storm Chaser
        new(31600, 1, 0, 57, 3),  //Grade 3 Artisanal Skybuilders' Archaeopteryx
        new(31601, 1, 0, 90, 3),  //Grade 3 Artisanal Skybuilders' Wyvern
        new(31602, 1, 0, 77, 3),  //Grade 3 Artisanal Skybuilders' Cloudshark
        new(31603, 1, 0, 113, 3), //Grade 3 Artisanal Skybuilders' Helicoprion

        new(32882, 1, 2, 0, 5),     //Grade 4 Skybuilders' Zagas Khaal
        new(32883, 1, 2, 0, 5),     //Grade 4 Skybuilders' Goldsmith Crab
        new(32884, 1, 4, 0, 5),     //Grade 4 Skybuilders' Common Bitterling
        new(32885, 1, 4, 0, 5),     //Grade 4 Skybuilders' Skyloach
        new(32886, 1, 4, 0, 5),     //Grade 4 Skybuilders' Glacier Core
        new(32887, 1, 4, 0, 5),     //Grade 4 Skybuilders' Kissing Fish
        new(32888, 1, 8, 0, 5),     //Grade 4 Skybuilders' Cavalry Catfish
        new(32889, 1, 8, 0, 5),     //Grade 4 Skybuilders' Manasail
        new(32890, 1, 4, 0, 5),     //Grade 4 Skybuilders' Starflower
        new(32891, 1, 4, 0, 5),     //Grade 4 Skybuilders' Cyan Crab
        new(32892, 1, 10, 0, 5),    //Grade 4 Skybuilders' Fickle Krait
        new(32893, 1, 10, 0, 5),    //Grade 4 Skybuilders' Proto-hropken
        new(32894, 1, 3, 2, 5),     //Grade 4 Skybuilders' Ghost Faerie
        new(32895, 1, 5, 5, 5),     //Grade 4 Skybuilders' Ashfish
        new(32896, 1, 10, 8, 5),    //Grade 4 Skybuilders' Whitehorse
        new(32897, 1, 6, 4, 5),     //Grade 4 Skybuilders' Ocean Cloud
        new(32898, 1, 12, 10, 5),   //Grade 4 Skybuilders' Black Fanfish
        new(32899, 1, 12, 10, 5),   //Grade 4 Skybuilders' Sunfish
        new(32900, 1, 17, 106, 4),  //Grade 4 Artisanal Skybuilders' Sweatfish
        new(32901, 1, 17, 250, 4),  //Grade 4 Artisanal Skybuilders' Sculptor
        new(32902, 1, 124, 911, 4), //Grade 4 Artisanal Skybuilders' Little Thalaos
        new(32903, 1, 64, 996, 4),  //Grade 4 Artisanal Skybuilders' Lightning Chaser
        new(32904, 1, 77, 512, 4),  //Grade 4 Artisanal Skybuilders' Marrella
        new(32905, 1, 45, 542, 4),  //Grade 4 Artisanal Skybuilders' Crimson Namitaro
        new(32906, 1, 153, 982, 4), //Grade 4 Artisanal Skybuilders' Griffin
        new(32907, 1, 126, 1078, 4)
    ];

    private static void UpdateAchievements(uint achievementId, uint progress)
    {
        switch (achievementId)
        {
            case 2536:
                Grade2BtnAch = progress;
                break;
            case 2657:
                Grade3BtnAch = progress;
                break;
            case 2816:
                Grade4BtnAch = progress;
                break;
            case 2535:
                Grade2MinAch = progress;
                break;
            case 2656:
                Grade3MinAch = progress;
                break;
            case 2815:
                Grade4MinAch = progress;
                break;
            case 2537:
                Grade2FshAch = progress;
                break;
            case 2658:
                Grade3FshAch = progress;
                break;
            case 2817:
                Grade4FshAch = progress;
                break;
            case 2515:
                Min500K = progress;
                break;
            case 2518:
                Btn500K = progress;
                break;
            case 2521:
                Fsh500K = progress;
                break;
        }
    }

    public static unsafe void CalculatePoints(int presetToUse)
    {
        var uiState = UIState.Instance();

        // Get Achievement Data and update if new achievement was opened
        var clickedAchievement = uiState->Achievement.ProgressAchievementId;
        if (CurrentAchievement != clickedAchievement)
        {
            UpdateAchievements(clickedAchievement, uiState->Achievement.ProgressCurrent);
            CurrentAchievement = clickedAchievement;
        }

        var manager = InventoryManager.Instance();
        if (manager == null)
            return;

        var preset = presetToUse switch
        {
            0 => MinerPreset,
            1 => BotanistPreset,
            2 => FisherPreset,
            _ => []
        };

        var (points, scrips) = (0, 0);
        int[] grades = [0, 0, 0, 0] ;
        foreach (var item in preset)
        {
            var count = manager->GetInventoryItemCount(item.Id, false, false, false);
            points += (count / item.Set) * item.PointsReward;
            scrips += (count / item.Set) * item.ScripsReward;
            grades[item.Grade - 2] = grades[item.Grade - 2] + count - (count % item.Set);
        }

        _ = presetToUse switch
        {
            0 => (MinPoints, MinScrips, Grade2Min, Grade3Min, Grade4Min) = (points, scrips, grades[0], grades[1], grades[2]),
            1 => (BtnPoints, BtnScrips, Grade2Btn, Grade3Btn, Grade4Btn) = (points, scrips, grades[0], grades[1], grades[2]),
            2 => (FshPoints, FshScrips, Grade2Fsh, Grade3Fsh, Grade4Fsh) = (points, scrips, grades[0], grades[1], grades[2]),
            _ => throw new NotImplementedException()
        };
    }
}
