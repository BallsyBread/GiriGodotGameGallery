using Godot;
using System;

public partial class Gravity : Node2D
{
    [Export]
    public float Acceleration;
    [Export]
    public float JumpHeight;
    private Vector2 Velocity;
    public override void _PhysicsProcess(double delta)
    {
        if(Input.IsActionJustPressed("ui_accept")) OnCoinBodyEntered(null);
        Velocity += Vector2.Up * (float) delta * Acceleration;
        foreach(Node node in GetChildren()) {
            if (node is Node2D node2d) {
                node2d.Position += Velocity;
                if (node2d.Position.Y > 600 ) node2d.QueueFree();
            }
        }
    }
    public void OnCoinBodyEntered(Node body) {
        Velocity = Vector2.Down * JumpHeight;
    }
}
