using Terraria.ID;

namespace BaneAndBrew.Common.Families
{
    internal static class VanillaNPCFamilies
    {
        public static void Register()
        {
            RegisterSlimes();
            RegisterUndead();
            RegisterSpirits();
            RegisterDemons();
            RegisterBeasts();
            RegisterHumanoids();
            RegisterInsects();
            RegisterPlants();
            RegisterAquatics();
            RegisterConstructs();
            RegisterEldritch();

            RegisterAlignments();
        }

        /// <summary>
        /// Registers all slime enemies.
        /// </summary>
        private static void RegisterSlimes()
        {
            // Common slimes
            //
            NPCFamilyRegistry.Register(
                NPCID.GreenSlime,
                NPCIdentity.Slime);

            NPCFamilyRegistry.Copy(
                source: NPCID.GreenSlime,
                NPCID.JungleSlime,
                NPCID.YellowSlime,
                NPCID.RedSlime,
                NPCID.PurpleSlime,
                NPCID.BlackSlime,
                NPCID.BabySlime,
                NPCID.Pinky,
                NPCID.BlueSlime,
                NPCID.MotherSlime,
                NPCID.KingSlime,
                NPCID.DungeonSlime,
                NPCID.ToxicSludge,
                NPCID.SpikedJungleSlime,
                NPCID.UmbrellaSlime,
                NPCID.RainbowSlime,
                NPCID.SlimeMasked,
                NPCID.SlimeRibbonWhite,
                NPCID.SlimeRibbonYellow,
                NPCID.SlimeRibbonGreen,
                NPCID.SlimeRibbonRed,
                NPCID.SlimeSpiked,
                NPCID.SandSlime,
                NPCID.GoldenSlime,
                NPCID.ShimmerSlime);

            // Aligned slimes
            //
            NPCFamilyRegistry.Register(
                NPCID.BigCrimslime,
                NPCIdentity.Slime,
                NPCAlignment.Corrupted);

            NPCFamilyRegistry.Copy(
                source: NPCID.BigCrimslime,
                NPCID.LittleCrimslime,
                NPCID.Slimer2,
                NPCID.Slimeling,
                NPCID.CorruptSlime,
                NPCID.Slimer,
                NPCID.Crimslime);

            NPCFamilyRegistry.Register(
                NPCID.IceSlime,
                NPCIdentity.Slime,
                NPCAlignment.Frigid);

            NPCFamilyRegistry.Copy(
                source: NPCID.IceSlime,
                NPCID.SpikedIceSlime);

            NPCFamilyRegistry.Register(
                NPCID.LavaSlime,
                NPCIdentity.Slime,
                NPCAlignment.Infernal);

            NPCFamilyRegistry.Register(
                NPCID.IlluminantSlime,
                NPCIdentity.Slime,
                NPCAlignment.Hallowed);

            NPCFamilyRegistry.Copy(
                source: NPCID.IlluminantSlime,
                NPCID.QueenSlimeBoss,
                NPCID.QueenSlimeMinionBlue,
                NPCID.QueenSlimeMinionPink,
                NPCID.QueenSlimeMinionPurple);
        }

        private static void RegisterUndead()
        {
            // Add NPC marked as zombies
            //
            for (int type = 0; type < NPCID.Sets.Zombies.Length; type++)
            {
                if (NPCID.Sets.Zombies[type])
                {
                    NPCFamilyRegistry.Register(type, NPCIdentity.Undead);
                }
            }

            // Add NPC marked as skeletons
            //
            for (int type = 0; type < NPCID.Sets.Skeletons.Length; type++)
            {
                if (NPCID.Sets.Skeletons[type])
                {
                    NPCFamilyRegistry.Register(type, NPCIdentity.Undead);
                }
            }

            // Add remaining undead
            //
            NPCFamilyRegistry.Register(
                NPCID.Mummy,
                NPCIdentity.Undead);

            NPCFamilyRegistry.Copy(
                source: NPCID.Mummy,
                NPCID.DarkMummy,
                NPCID.BloodMummy,
                NPCID.LightMummy,
                NPCID.UndeadViking,
                NPCID.UndeadMiner,
                NPCID.BoneSerpentHead,
                NPCID.BoneSerpentBody,
                NPCID.BoneSerpentTail,
                NPCID.HeadlessHorseman,
                NPCID.SkeletronHead,
                NPCID.SkeletronHand,

                // Dungeon
                //
                NPCID.CursedSkull,
                NPCID.GiantCursedSkull,
                NPCID.DarkCaster,
                NPCID.RustyArmoredBonesAxe,
                NPCID.RustyArmoredBonesFlail,
                NPCID.RustyArmoredBonesSword,
                NPCID.RustyArmoredBonesSwordNoArmor,
                NPCID.BlueArmoredBones,
                NPCID.BlueArmoredBonesMace,
                NPCID.BlueArmoredBonesNoPants,
                NPCID.BlueArmoredBonesSword,
                NPCID.HellArmoredBones,
                NPCID.HellArmoredBonesSpikeShield,
                NPCID.HellArmoredBonesMace,
                NPCID.HellArmoredBonesSword,
                NPCID.Necromancer,
                NPCID.NecromancerArmored,
                NPCID.RaggedCaster,
                NPCID.RaggedCasterOpenCoat,
                NPCID.DiabolistRed,
                NPCID.DiabolistWhite,
                NPCID.SkeletonSniper,
                NPCID.TacticalSkeleton,
                NPCID.SkeletonCommando,
                NPCID.AngryBonesBig,
                NPCID.AngryBonesBigMuscle,
                NPCID.AngryBonesBigHelmet,

                // Missing from sets
                //
                NPCID.ArmedTorchZombie,
                NPCID.BloodZombie,
                NPCID.MaggotZombie,
                NPCID.ZombieDoctor,
                NPCID.Eyezor,

                // Event
                //
                NPCID.Frankenstein,
                NPCID.ZombieXmas,
                NPCID.ZombieSweater,
                NPCID.ZombieElf,
                NPCID.ZombieElfBeard,
                NPCID.ZombieElfGirl,
                NPCID.DD2SkeletonT1,
                NPCID.DD2SkeletonT3,
                NPCID.PirateGhost);
        }

        private static void RegisterSpirits()
        {
            NPCFamilyRegistry.Register(
                NPCID.Ghost,
                NPCIdentity.Spirit);

            NPCFamilyRegistry.Copy(
                source: NPCID.Ghost,
                NPCID.Wraith,
                NPCID.DungeonSpirit,
                NPCID.ShadowFlameApparition,
                NPCID.Poltergeist,
                NPCID.Reaper,
                NPCID.IceQueen);
        }

        private static void RegisterDemons()
        {
            NPCFamilyRegistry.Register(
                NPCID.Demon,
                NPCIdentity.Demon);

            NPCFamilyRegistry.Copy(
                source: NPCID.Demon,
                NPCID.VoodooDemon,
                NPCID.FireImp,
                NPCID.RedDevil,
                NPCID.WallofFlesh,
                NPCID.WallofFleshEye,
                NPCID.TheHungry,
                NPCID.TheHungryII,
                NPCID.Hellhound);
        }

        private static void RegisterBeasts()
        {
            // Bats
            //
            NPCFamilyRegistry.Register(
                NPCID.CaveBat,
                NPCIdentity.Beast);

            NPCFamilyRegistry.Copy(
                source: NPCID.CaveBat,
                NPCID.JungleBat,
                NPCID.GiantBat,
                NPCID.IceBat,
                NPCID.Lavabat,
                NPCID.IlluminantBat,
                NPCID.VampireBat,
                NPCID.GiantFlyingFox,
                NPCID.Hellbat,
                NPCID.SporeBat,

            // Misc
            //
                NPCID.CorruptBunny,
                NPCID.CrimsonBunny,
                NPCID.Crawdad,
                NPCID.Crawdad2,
                NPCID.GiantShelly,
                NPCID.GiantShelly2,
                NPCID.Salamander,
                NPCID.Salamander2,
                NPCID.Salamander3,
                NPCID.Salamander4,
                NPCID.Salamander5,
                NPCID.Salamander6,
                NPCID.Salamander7,
                NPCID.Salamander8,
                NPCID.Salamander9,
                NPCID.Derpling,
                NPCID.Scutlix,

            // Wolves & canines
            //
                NPCID.Wolf,
                NPCID.Werewolf,

            // Flyers
            //
                NPCID.Vulture,
                NPCID.Harpy,
                NPCID.WyvernHead,
                NPCID.WyvernLegs,
                NPCID.WyvernBody,
                NPCID.WyvernBody2,
                NPCID.WyvernBody3,
                NPCID.WyvernTail,
                NPCID.Raven,
                NPCID.Parrot,
                NPCID.FlyingSnake,

            // Snow / desert beasts
            //
                NPCID.SnowFlinx,
                NPCID.GiantTortoise,
                NPCID.IceTortoise,
                NPCID.Yeti,
                NPCID.Krampus,

            // Hallowed & corrupt beasts
            //
                NPCID.CorruptPenguin,
                NPCID.CrimsonPenguin,
                NPCID.Unicorn,
                NPCID.Gastropod,
                NPCID.Herpling,
                NPCID.Crimera,
                NPCID.IchorSticker,
                NPCID.PigronHallow,
                NPCID.PigronCorruption,
                NPCID.PigronCrimson,

            // Bosses & Old One's Army
            //
                NPCID.Deerclops,
                NPCID.DD2Betsy,
                NPCID.DD2WitherBeastT2,
                NPCID.DD2WitherBeastT3,
                NPCID.DD2WyvernT1,
                NPCID.DD2WyvernT2,
                NPCID.DD2WyvernT3,
                NPCID.DD2DrakinT2,
                NPCID.DD2DrakinT3);
        }

        private static void RegisterHumanoids()
        {
            // Goblins
            //
            NPCFamilyRegistry.Register(
                NPCID.GoblinPeon,
                NPCIdentity.Humanoid);

            NPCFamilyRegistry.Copy(
                source: NPCID.GoblinPeon,
                NPCID.GoblinThief,
                NPCID.GoblinWarrior,
                NPCID.GoblinSorcerer,
                NPCID.GoblinScout,
                NPCID.GoblinArcher,
                NPCID.GoblinSummoner,
                NPCID.BoundGoblin,
                NPCID.GoblinTinkerer,
                NPCID.ChaosElemental,
                NPCID.LostGirl,
                NPCID.Nymph,
                NPCID.Medusa,
                NPCID.Vampire,

            // Pirates
            //
                NPCID.PirateDeckhand,
                NPCID.PirateCorsair,
                NPCID.PirateCrossbower,
                NPCID.PirateDeadeye,
                NPCID.PirateCaptain,

            // Cultists
            //
                NPCID.CultistArcherBlue,
                NPCID.CultistArcherWhite,
                NPCID.CultistDevote,
                NPCID.CultistBoss,

            // Frost Legion
            //
                NPCID.SnowmanGangsta,
                NPCID.MisterStabby,
                NPCID.SnowBalla,
                NPCID.ElfArcher,

            // Martian gunners
            //
                NPCID.GrayGrunt,
                NPCID.MartianOfficer,
                NPCID.RayGunner,
                NPCID.ScutlixRider,

            // Old One's Army
            //
                NPCID.DD2GoblinT1,
                NPCID.DD2GoblinT2,
                NPCID.DD2GoblinT3,
                NPCID.DD2GoblinBomberT1,
                NPCID.DD2GoblinBomberT2,
                NPCID.DD2GoblinBomberT3,
                NPCID.DD2DarkMageT1,
                NPCID.DD2DarkMageT3,
                NPCID.DD2OgreT2,
                NPCID.DD2OgreT3,

                // Misc
                //

                NPCID.Paladin,
                NPCID.Tim,
                NPCID.RuneWizard);
        }

        private static void RegisterInsects()
        {
            // Hornets
            //
            NPCFamilyRegistry.Register(
                NPCID.Hornet,
                NPCIdentity.Insect);

            NPCFamilyRegistry.Copy(
                source: NPCID.Hornet,
                NPCID.BigHornetStingy,
                NPCID.LittleHornetStingy,
                NPCID.BigHornetSpikey,
                NPCID.LittleHornetSpikey,
                NPCID.BigHornetLeafy,
                NPCID.LittleHornetLeafy,
                NPCID.BigHornetHoney,
                NPCID.LittleHornetHoney,
                NPCID.BigHornetFatty,
                NPCID.LittleHornetFatty,
                NPCID.GiantMossHornet,
                NPCID.BigMossHornet,
                NPCID.LittleMossHornet,
                NPCID.TinyMossHornet,
                NPCID.BigStinger,
                NPCID.LittleStinger,
                NPCID.MossHornet,
                NPCID.HornetFatty,
                NPCID.HornetHoney,
                NPCID.HornetLeafy,
                NPCID.HornetSpikey,
                NPCID.HornetStingy,
            // Spiders
            //
                NPCID.BlackRecluse,
                NPCID.WallCreeper,
                NPCID.WallCreeperWall,
                NPCID.JungleCreeper,
                NPCID.JungleCreeperWall,
                NPCID.BlackRecluseWall,
                NPCID.BloodCrawler,
                NPCID.BloodCrawlerWall,

            // Misc
            //
                NPCID.AnomuraFungus,
                NPCID.MushiLadybug,
                NPCID.VortexHornet,
                NPCID.VortexHornetQueen,
                NPCID.VortexLarva,
                NPCID.Antlion,
                NPCID.WalkingAntlion,
                NPCID.FlyingAntlion,
                NPCID.LarvaeAntlion,
                NPCID.GiantWalkingAntlion,
                NPCID.GiantFlyingAntlion,
                NPCID.Moth,
                NPCID.DD2LightningBugT3);

            // Worms & bees
            //
            NPCFamilyRegistry.Register(
                NPCID.EaterofWorldsHead,
                NPCIdentity.Insect);

            NPCFamilyRegistry.Copy(
                source: NPCID.EaterofWorldsHead,
                NPCID.EaterofWorldsBody,
                NPCID.EaterofWorldsTail,
                NPCID.GiantWormHead,
                NPCID.GiantWormBody,
                NPCID.GiantWormTail,
                NPCID.DevourerHead,
                NPCID.DevourerBody,
                NPCID.DevourerTail,
                NPCID.EaterofSouls,
                NPCID.Corruptor,
                NPCID.DiggerHead,
                NPCID.DiggerBody,
                NPCID.DiggerTail,
                NPCID.SeekerHead,
                NPCID.SeekerBody,
                NPCID.SeekerTail,
                NPCID.Mothron,
                NPCID.MothronSpawn,
                NPCID.QueenBee,
                NPCID.Bee,
                NPCID.BeeSmall);
        }

        private static void RegisterPlants()
        {
            NPCFamilyRegistry.Register(
                NPCID.ManEater,
                NPCIdentity.Plant);

            NPCFamilyRegistry.Copy(
                source: NPCID.ManEater,
                NPCID.Snatcher,
                NPCID.AngryTrapper,
                NPCID.Plantera,
                NPCID.PlanterasHook,
                NPCID.PlanterasTentacle,
                NPCID.Everscream,
                NPCID.Splinterling,
                NPCID.MourningWood,
                NPCID.Pumpking,
                NPCID.Dandelion);
        }

        private static void RegisterAquatics()
        {
            NPCFamilyRegistry.Register(
                NPCID.Shark,
                NPCIdentity.Aquatic);

            NPCFamilyRegistry.Copy(
                source: NPCID.Shark,
                NPCID.Piranha,
                NPCID.BlueJellyfish,
                NPCID.PinkJellyfish,
                NPCID.GreenJellyfish,
                NPCID.BloodJelly,
                NPCID.BloodFeeder,
                NPCID.FlyingFish,
                NPCID.Crab,
                NPCID.Squid,
                NPCID.AnglerFish,
                NPCID.DukeFishron,
                NPCID.Sharkron,
                NPCID.Sharkron2,
                NPCID.Arapaima,
                NPCID.LeechHead,
                NPCID.LeechBody,
                NPCID.LeechTail,
                NPCID.CorruptGoldfish,
                NPCID.FungoFish,

                // Blood moon
                //
                NPCID.CrimsonGoldfish,
                NPCID.ZombieMerman,
                NPCID.BloodNautilus,
                NPCID.BloodSquid,
                NPCID.BloodEelHead,
                NPCID.BloodEelBody,
                NPCID.BloodEelTail,
                NPCID.GoblinShark);
        }

        private static void RegisterConstructs()
        {
            NPCFamilyRegistry.Register(
                NPCID.Golem,
                NPCIdentity.Construct);

            NPCFamilyRegistry.Copy(
                source: NPCID.Golem,

                NPCID.GraniteGolem,
                NPCID.GraniteFlyer,
                NPCID.RockGolem,
                NPCID.EnchantedSword,
                NPCID.PossessedArmor,
                NPCID.SpikeBall,
                NPCID.BlazingWheel,
                NPCID.CursedHammer,
                NPCID.CrimsonAxe,
                NPCID.IceGolem,
                NPCID.IceElemental,
                NPCID.PirateShip,
                NPCID.PirateShipCannon,

                // Mimics
                //
                NPCID.Mimic,
                NPCID.IceMimic,
                NPCID.PresentMimic,
                NPCID.BigMimicCorruption,
                NPCID.BigMimicCrimson,
                NPCID.BigMimicHallow,
                NPCID.BigMimicJungle,

                // Boss
                //
                NPCID.GolemHead,
                NPCID.GolemFistLeft,
                NPCID.GolemFistRight,
                NPCID.GolemHeadFree,
                NPCID.TheDestroyer,
                NPCID.TheDestroyerBody,
                NPCID.TheDestroyerTail,
                NPCID.Probe,
                NPCID.Retinazer,
                NPCID.Spazmatism,
                NPCID.SkeletronPrime,
                NPCID.PrimeCannon,
                NPCID.PrimeSaw,
                NPCID.PrimeVice,
                NPCID.PrimeLaser,
                NPCID.PumpkingBlade,

                // Frost Legion
                //
                NPCID.ElfCopter,
                NPCID.Nutcracker,
                NPCID.NutcrackerSpinning,
                NPCID.Flocko,
                NPCID.SantaNK1,

                // Martian
                //
                NPCID.MartianSaucer,
                NPCID.MartianSaucerCannon,
                NPCID.MartianSaucerCore,
                NPCID.MartianSaucerTurret,
                NPCID.MartianDrone,
                NPCID.MartianTurret,
                NPCID.MartianProbe);
        }

        private static void RegisterEldritch()
        {
            // Eyes
            //
            NPCFamilyRegistry.Register(
                NPCID.DemonEye,
                NPCIdentity.Eldritch);

            NPCFamilyRegistry.Copy(
                source: NPCID.DemonEye,
                NPCID.DemonEye2,
                NPCID.DemonEyeOwl,
                NPCID.DemonEyeSpaceship,
                NPCID.PurpleEye,
                NPCID.PurpleEye2,
                NPCID.GreenEye,
                NPCID.GreenEye2,
                NPCID.SleepyEye,
                NPCID.SleepyEye2,
                NPCID.CataractEye,
                NPCID.CataractEye2,
                NPCID.DialatedEye,
                NPCID.DialatedEye2,
                NPCID.WanderingEye,
                NPCID.EyeofCthulhu,
                NPCID.ServantofCthulhu,
                NPCID.MeteorHead,
                NPCID.Crimera,
                NPCID.BigCrimera,
                NPCID.LittleCrimera,
                NPCID.EyeballFlyingFish,

            // Brain of Cthulhu
            //
                NPCID.BrainofCthulhu,
                NPCID.Creeper,

            // Nebula Pillar
            //
                NPCID.NebulaBrain,
                NPCID.NebulaHeadcrab,
                NPCID.NebulaSoldier,

            // Stardust Pillar
            //
                NPCID.StardustCellBig,
                NPCID.StardustCellSmall,
                NPCID.StardustJellyfishBig,
                NPCID.StardustJellyfishSmall,
                NPCID.StardustSoldier,
                NPCID.StardustSpiderBig,
                NPCID.StardustSpiderSmall,
                NPCID.StardustWormHead,
                NPCID.StardustWormBody,
                NPCID.StardustWormTail,

            // Moon Lord
            //
                NPCID.MoonLordCore,
                NPCID.MoonLordHand,
                NPCID.MoonLordHead,
                NPCID.MoonLordFreeEye,
                NPCID.MoonLordLeechBlob);
        }

        private static void RegisterAlignments()
        {
            NPCFamilyRegistry.SetAlignments(
                NPCAlignment.Corrupted,

            // Corruption
            //
                NPCID.EaterofSouls,
                NPCID.Corruptor,
                NPCID.DevourerHead,
                NPCID.DevourerBody,
                NPCID.DevourerTail,
                NPCID.CorruptGoldfish,
                NPCID.EaterofWorldsHead,
                NPCID.EaterofWorldsBody,
                NPCID.EaterofWorldsTail,
                NPCID.DarkMummy,
                NPCID.CursedHammer,
                NPCID.Clinger,
                NPCID.BigMimicCorruption,
                NPCID.DesertGhoulCorruption,
                NPCID.PigronCorruption,

            // Crimson
            //
                NPCID.BloodCrawler,
                NPCID.BloodCrawlerWall,
                NPCID.CrimsonGoldfish,
                NPCID.FaceMonster,
                NPCID.Crimera,
                NPCID.BigCrimera,
                NPCID.LittleCrimera,
                NPCID.BrainofCthulhu,
                NPCID.Creeper,
                NPCID.Herpling,
                NPCID.BloodJelly,
                NPCID.BloodFeeder,
                NPCID.BloodMummy,
                NPCID.CrimsonAxe,
                NPCID.IchorSticker,
                NPCID.FloatyGross,
                NPCID.BigMimicCrimson,
                NPCID.DesertGhoulCrimson,
                NPCID.PigronCrimson);

            NPCFamilyRegistry.SetAlignments(
                NPCAlignment.Infernal,
                NPCID.Hellbat,
                NPCID.Lavabat,
                NPCID.FireImp,
                NPCID.MeteorHead,
                NPCID.DD2Betsy,
                NPCID.HellArmoredBones,
                NPCID.HellArmoredBonesSpikeShield,
                NPCID.HellArmoredBonesMace,
                NPCID.HellArmoredBonesSword);

            NPCFamilyRegistry.SetAlignments(
                NPCAlignment.Frigid,

            // Ice & Frost Legion
            //
                NPCID.IceBat,
                NPCID.IceTortoise,
                NPCID.IceGolem,
                NPCID.IceElemental,
                NPCID.IcyMerman,
                NPCID.Everscream,
                NPCID.SnowmanGangsta,
                NPCID.MisterStabby,
                NPCID.SnowBalla,
                NPCID.Yeti,
                NPCID.IceQueen,
                NPCID.Flocko);

            NPCFamilyRegistry.SetAlignments(
                NPCAlignment.Storm,

            // Vortex Pillar & Martian Saucer
            //
                NPCID.VortexHornet,
                NPCID.VortexHornetQueen,
                NPCID.VortexLarva,
                NPCID.WyvernHead,
                NPCID.WyvernLegs,
                NPCID.WyvernBody,
                NPCID.WyvernBody2,
                NPCID.WyvernBody3,
                NPCID.WyvernTail,
                NPCID.MartianSaucerCannon,
                NPCID.MartianSaucerCore,
                NPCID.MartianSaucerTurret
                );

            NPCFamilyRegistry.SetAlignments(
                NPCAlignment.Hallowed,

            // Hallow
            //
                NPCID.Pixie,
                NPCID.Unicorn,
                NPCID.Gastropod,
                NPCID.LightMummy,
                NPCID.IlluminantBat,
                NPCID.ChaosElemental,
                NPCID.EnchantedSword,
                NPCID.BigMimicHallow,
                NPCID.DesertGhoulHallow,
                NPCID.PigronHallow,
                NPCID.SandsharkHallow,
                NPCID.HallowBoss);
        }
    }
}