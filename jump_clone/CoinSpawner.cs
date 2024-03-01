using Godot;
using System;

public partial class CoinSpawner : Node2D
{
    [Export]
    private PackedScene CoinNode;
    [Export]
    private float Spacing;
    private Gravity GravityNode;
    private Area2D MostRecentCoin;
    public override void _Ready()
    {
        GravityNode = GetNode<Gravity>("../Gravity");
        SpawnCoinAt(new Vector2(0, Spacing));
    }
    public override void _PhysicsProcess(double delta)
    {
        if (!ShouldSpawnCoin()) return;
        SpawnCoinAt(
            new Vector2(
                (float)GD.RandRange(-(GetViewportRect().Size.X / 2), GetViewportRect().Size.X / 2),
                MostRecentCoin.Position.Y - Spacing
            )
        );
    }
    private bool ShouldSpawnCoin()
    {
        bool isMostRecentCoinAboveTwiceTheScreenSize = MostRecentCoin.Position.Y < GetViewportRect().Size.Y * 2;
        return isMostRecentCoinAboveTwiceTheScreenSize;
    }
    private void SpawnCoinAt(Vector2 position)
    {
        MostRecentCoin = CoinNode.Instantiate<Area2D>();
        MostRecentCoin.Position = position;
        MostRecentCoin.BodyEntered+=GravityNode.OnCoinBodyEntered;
        GravityNode.AddChild(MostRecentCoin);
    }

}