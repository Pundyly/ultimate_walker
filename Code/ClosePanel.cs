using Sandbox;

public sealed class ClosePanel : Component
{
	bool TabOn = true;
	[Property] public GameObject Tab;
	protected override void OnUpdate()
	{
		bool OnCloseTab = Input.Released("Slot0");
		if (OnCloseTab)
		{
			Log.Info("log");
			if (TabOn)
			{
				Log.Info("lox1");
				TabOn = false;
				Tab.Enabled = false;
			}
			else
			{
				Log.Info("lox2");
				TabOn = true;
				Tab.Enabled = true;
			}
		}
		else
        {
			return;
        }
	}
}
