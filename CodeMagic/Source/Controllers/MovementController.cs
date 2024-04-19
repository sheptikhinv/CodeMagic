using CodeMagic.Source.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CodeMagic.Source.Controllers;

public class MovementController
{
    private Player player;

    public MovementController(Player player)
    {
        this.player = player;
    }
    
    public void Update()
    {
        var delta = new Vector2(0, 0);
        if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            delta.X--;
        if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            delta.X++;
        if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
            delta.Y--;
        if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            delta.Y++;

        player.Move(delta);
    }
}