#if TOOLS
using Godot;
using System;

[Tool]
public partial class MultiAudioStreamPlayerPlugin : EditorPlugin
{
	public override void _EnterTree()
	{
        var script = GD.Load<Script>("res://addons/multi_audio_stream_player/players/MultiAudioStreamPlayer.cs");
        var texture = GD.Load<Texture2D>("res://icon.svg");
        AddCustomType("MultiAudioStreamPlayer", "Node", script, texture);
    }

	public override void _ExitTree()
	{
		RemoveCustomType("MultiAudioStreamPlayer");
	}
}
#endif
