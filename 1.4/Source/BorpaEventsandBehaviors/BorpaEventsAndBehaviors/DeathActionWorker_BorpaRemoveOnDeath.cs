using Verse;

namespace BorpaEventsAndBehaviors;

public class DeathActionWorker_BorpaRemoveOnDeath : DeathActionWorker
{
	public override void PawnDied(Corpse c)
	{
		c.Destroy();
	}
}
