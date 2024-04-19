using System;
using CodeMagic.Source.Engine;
using CodeMagic.Source.Models;
using Microsoft.Xna.Framework;

namespace CodeMagic.Source.Views;

public class PlayerView
{
    private Player player;

    public PlayerView(Player player)
    {
        this.player = player;
        // player.OnPositionChanged += HandlePositionChange;
    }

    public void Draw()
    {
        Globals.spriteBatch.Draw(player.Texture, player.Position, Color.White);
    }

    private static void HandlePositionChange()
    {
        Console.WriteLine("Moved");
    }
}