using Sandbox;

public sealed class Flashkight : Component
{

	protected override void OnFixedUpdate()
	{
		var camera = Scene.GetAllComponents<CameraComponent>().Where(x => x.IsMainCamera).FirstOrDefault();
		if (camera is null) return;
		var camPos = camera.Transform.Position;
		var camRot = camera.Transform.Rotation;
		Transform.Position = camPos;
		Transform.Rotation = camRot;
	}
}
