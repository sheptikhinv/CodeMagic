using System.Collections.Generic;
using CodeMagic.Source.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CodeMagic.Source.Models;

public class Map
{
    public readonly int tileSize;
    private readonly Texture2D _tileset;
    private List<Texture2D> _tiles = new() { null };

    public readonly int[,] map;

    public Map(Texture2D tileset, int tileSize, int[,] map)
    {
        _tileset = tileset;
        this.tileSize = tileSize;
        this.map = map;

        var columns = tileset.Width / tileSize;
        var rows = tileset.Height / this.tileSize;

        for (var y = 0; y < rows; y++)
        {
            for (var x = 0; x < columns; x++)
            {
                var sourceRect = new Rectangle(x * this.tileSize, y * tileSize, tileSize, tileSize);
                var sourceData = new Color[tileSize * tileSize];
                tileset.GetData(0, sourceRect, sourceData, 0, sourceData.Length);
                var tileSprite = new Texture2D(Globals.graphicsDevice, tileSize, tileSize);
                tileSprite.SetData(sourceData);
                _tiles.Add(tileSprite);
            }
        }
    }

    public void Draw()
    {
        for (var x = 0; x < map.GetLength(1); x++)
        {
            for (var y = 0; y < map.GetLength(0); y++)
            {
                if (map[y, x] == 0) continue;
                Globals.spriteBatch.Draw(_tiles[map[y, x]], new Vector2(x * tileSize, y * tileSize), Color.White);
            }
        }
    }
}