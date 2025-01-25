using Sandbox;

public sealed class Watermelon : Component
{
	[Property] public NavMeshAgent agent;
	protected override void OnUpdate()
	{
		var targetPosition = new Vector3(0,0,0);
		agent.MoveTo(targetPosition);

		// Stop trying to get to the target position.
		//agent.Stop();
	}
}
