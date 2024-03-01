using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    public float HorizontalSpeed;
    private CollisionShape2D collisionShape;

    public override void _Ready()
    {
        collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
    }
    public override void _PhysicsProcess(double delta)
    {
        float horizontalInput = Input.GetVector("ui_left", "ui_right", "ui_down", "ui_up").X;
        collisionShape.Position+=new Vector2(horizontalInput, 0)*HorizontalSpeed;
    }
}
