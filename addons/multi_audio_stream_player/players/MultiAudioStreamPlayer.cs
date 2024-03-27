using Godot;
using System;
using System.Linq;

public partial class MultiAudioStreamPlayer : Node
{
    [ExportGroup("Instancing Settings")]
    [Export(PropertyHint.Range, "1,128,1,or_greater")] private int _numberOfInstances = 2;
    [Export] private bool _prioritizeNewPlays = true;
    private AudioStreamPlayer[] _players;

    public void Play(float fromPosition = 0.0f)
    {
        float longestPosition = -1.0f;
        int longestPositionIndex = -1;
        for (int i = 0; i < _numberOfInstances; i++)
        {
            if (!_players[i].Playing)
            {
                _players[i].Play(fromPosition);
                return;
            }
            
            if (_prioritizeNewPlays && _players[i].GetPlaybackPosition() > longestPosition)
            {
                longestPositionIndex = i;
                longestPosition = _players[i].GetPlaybackPosition();
            }
        }

        if (_prioritizeNewPlays)
        {
            _players[longestPositionIndex].Play(fromPosition);
        }
    }

    public override void _EnterTree()
    {
        base._EnterTree();

        _players = new AudioStreamPlayer[_numberOfInstances];
        for (int i = 0; i < _numberOfInstances; i++)
        {
            _players[i] = new AudioStreamPlayer();
            AddChild(_players[i]);
        }
    }

    public override void _ExitTree()
    {
        base._ExitTree();

        foreach (AudioStreamPlayer player in _players)
        {
            player.QueueFree();
        }

        _players = null;
    }
}

// TODO
// - Config warning and errors for loopable 
// - Auto set values based on properties