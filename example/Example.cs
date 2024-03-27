using Godot;
using System;

public partial class Example : Node
{
    [Export] private MultiAudioStreamPlayer multiAudioStreamPlayer;

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        if (@event.IsActionPressed("sound_1"))
        {
            multiAudioStreamPlayer.Play();
        }
    }
}
