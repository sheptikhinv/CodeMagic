using System.Collections.Generic;
using CodeMagic.Source.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CodeMagic.Source.Models;

public class Map
{
    private readonly Texture2D _tileset;

    public List<Texture2D> _tiles = new() { null };
    public readonly int[,] map;
    public readonly int tileSize;
    public readonly int sizeCoeff = 3;

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

    public bool WillCollide(Vector2 futurePosition, int objectHeight, int objectWidth)
    {
        {
            var startX = (int)(futurePosition.X / tileSize / sizeCoeff);
            var startY = (int)(futurePosition.Y / tileSize / sizeCoeff);
            var endX = (int)((futurePosition.X + objectWidth) / tileSize / sizeCoeff);
            var endY = (int)((futurePosition.Y + objectHeight) / tileSize / sizeCoeff);

            // Проверяем, что позиция находится в пределах карты
            if (startX < 0 || endX >= map.GetLength(0) || startY < 0 || endY >= map.GetLength(1))
            {
                return true;
            }

            // Проверяем, не пересекается ли объект с твердыми тайлами
            for (var x = startX; x <= endX; x++)
            {
                for (var y = startY; y <= endY; y++)
                {
                    if (map[x, y] != 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}