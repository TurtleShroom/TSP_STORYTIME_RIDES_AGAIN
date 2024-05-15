using HarmonyLib;
using RimWorld;
using Verse;

namespace StoryTime;

[HarmonyPatch(typeof(Mineable))]
[HarmonyPatch("TrySpawnYield")]
public class Mineable_TrySpawnYield_Patch
{
	public static void Postfix(Mineable __instance, Map __0, Pawn __3)
	{
		CompGemDropper compGemDropper = __instance.TryGetComp<CompGemDropper>();
		if (compGemDropper == null)
		{
			return;
		}
		ThingDef thingDef = GemDropperUtility.TryGetItem(compGemDropper.commonGemDropRate, compGemDropper.uncommonGemDropRate, compGemDropper.rareGemDropRate);
		if (thingDef != null)
		{
			Thing thing2 = ThingMaker.MakeThing(thingDef);
			thing2.stackCount = 1;
			GenPlace.TryPlaceThing(thing2, __instance.Position, __0, ThingPlaceMode.Near, ForbidIfNecessary);
			if (__3 != null && __3.Faction == Faction.OfPlayer)
			{
				Messages.Message("ST_FoundGem".Translate(__3.LabelShortCap, thing2.Label), thing2, MessageTypeDefOf.PositiveEvent);
			}
		}
		void ForbidIfNecessary(Thing thing, int count)
		{
			if ((__3 == null || !__3.IsColonist) && thing.def.EverHaulable && !thing.def.designateHaulable)
			{
				thing.SetForbidden(value: true, warnOnFail: false);
			}
		}
	}
}
