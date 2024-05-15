using CodeMagic.Source.Engine;
using CodeMagic.Source.Models;
using Microsoft.Xna.Framework;

namespace CodeMagic.Source.Views;

public class MapView
{
    private Map _map;

    public MapView(Map map)
    {
        _map = map;
    }
    
    public void Draw()
    {
        for (var x = 0; x < _map.map.GetLength(1); x++)
        {
            for (var y = 0; y < _map.map.GetLength(0); y++)
            {
                if (_map.map[y, x] == 0) continue;
                var destinationRectangle = new Rectangle(x * _map.tileSize * _map.sizeCoeff, y * _map.tileSize * _map.sizeCoeff,
                    _map.tileSize * _map.sizeCoeff, _map.tileSize * _map.sizeCoeff);
                Globals.spriteBatch.Draw(_map._tiles[_map.map[y, x]], destinationRectangle, Color.White);
            }
        }
    }
}