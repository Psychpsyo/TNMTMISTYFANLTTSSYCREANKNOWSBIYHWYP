using FrooxEngine.CommonAvatar;
using HarmonyLib;
using NeosModLoader;

namespace TouchSecurity
{
    public class TouchSecurity : NeosMod
    {
        public override string Name => "The Neos Mod That Makes It So That Your Fingers Are No Longer Trusted Touch Sources So You Can Rest Easy At Night Knowing No One Will Shove Buttons Into Your Hand Without Your Permission";
        public override string Author => "Psychpsyo";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/Psychpsyo/TNMTMISTYFANLTTSSYCREANKNOWSBIYHWYP";

        public override void OnEngineInit() {
            Harmony harmony = new Harmony("Psychpsyo.TNMTMISTYFANLTTSSYCREANKNOWSBIYHWYP");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(AvatarHandDataAssigner), "OnCommonUpdate")]
        class AvatarHandDataAssignerUpdate
        {
            static void Postfix(AvatarHandDataAssigner __instance) {
                if (__instance.TouchSource.Target != null) {
                    __instance.TouchSource.Target.SafeTouchSource = false;
                }
            }
        }

        [HarmonyPatch(typeof(AvatarHandDataAssigner), "OnEquip")]
        class AvatarHandDataAssignerEquip
        {
            static void Postfix(AvatarHandDataAssigner __instance) {
                if (__instance.TouchSource.Target != null) {
                    __instance.TouchSource.Target.SafeTouchSource = false;
                }
            }
        }
    }
}