using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CodeMagic.Source.Engine;

public class Entity
{
    public Texture2D Sprite;
    public Vector2 pos, dims;

    public Entity(string spritePath, Vector2 pos, Vector2 dims)
    {
        Sprite = Globals.content.Load<Texture2D>(spritePath);
        this.pos = pos;
        this.dims = dims;
    }

    public virtual void Update()
    {
    }

    public virtual void Draw()
    {
        Console.WriteLine("Drawing");
        Console.WriteLine(Sprite.ToString());
        if (Sprite != null)
        {
            Console.WriteLine("AYEEEH");
            Globals.spriteBatch.Draw(Sprite, new Rectangle((int)pos.X, (int)pos.Y, (int)pos.X, (int)pos.Y), Color.White);
            Console.WriteLine("DRAWN YEAH");
        }
    }
}