using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CodeMagic.Source.Models;

public class Player
{
    public event Action OnPositionChanged;
    
    private Spell[] _spells;
    private Vector2 position;
    private float speedModifier;
    public Texture2D Texture { get; set; }

    public Player(Vector2 initialPosition, Texture2D texture, float speedModifier = 1)
    {
        Position = initialPosition;
        Texture = texture;
        this.speedModifier = speedModifier;
    }

    public Vector2 Position
    {
        get => position;
        set
        {
            position = value;
            OnPositionChanged?.Invoke();
        }
    }

    public void AddSpell(Spell spell)
    {
        
    }

    public Spell[] GetSpells => _spells;

    public void Move(Vector2 delta)
    {
        Position += delta * speedModifier;
    }
}