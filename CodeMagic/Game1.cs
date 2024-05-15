using System;
using CodeMagic.Source;
using CodeMagic.Source.Controllers;
using CodeMagic.Source.Engine;
using CodeMagic.Source.Models;
using CodeMagic.Source.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace CodeMagic;

public class Game1 : Game
{
    public int[,] Map1 =
    {
        { 6, 7, 7, 7, 7, 7, 7, 7, 7, 8 },
        { 14, 15, 15, 15, 15, 15, 15, 15, 15, 16 },
        { 14, 15, 15, 15, 15, 15, 15, 15, 15, 16 },
        { 14, 15, 15, 15, 15, 15, 15, 15, 15, 16 },
        { 14, 15, 15, 15, 15, 15, 15, 15, 15, 16 },
        { 14, 15, 15, 15, 15, 15, 15, 15, 15, 16 },
        { 14, 15, 15, 15, 15, 15, 15, 15, 15, 16 },
        { 14, 15, 15, 15, 15, 15, 15, 15, 15, 16 },
        { 14, 15, 15, 15, 15, 15, 15, 15, 15, 16 },
        { 22, 23, 23, 23, 23, 23, 23, 23, 23, 24 }
    };

    public int[,] Map2 =
    {
        { 6, 7, 7, 7, 7, 7, 7, 7, 7, 8 },
        { 14, 0, 0, 0, 0, 0, 0, 0, 0, 16 },
        { 14, 0, 0, 0, 0, 0, 0, 0, 0, 16 },
        { 14, 0, 0, 0, 0, 0, 0, 0, 0, 16 },
        { 14, 0, 0, 0, 0, 0, 0, 0, 0, 16 },
        { 14, 0, 0, 0, 0, 0, 0, 0, 0, 16 },
        { 14, 0, 0, 0, 0, 0, 0, 0, 0, 16 },
        { 14, 0, 0, 0, 0, 0, 0, 0, 0, 16 },
        { 14, 0, 0, 0, 0, 0, 0, 0, 0, 16 },
        { 22, 23, 23, 23, 23, 23, 23, 23, 23, 24 }
    };

    public const int WindowWidth = 1920;
    public const int WindowHeight = 1000;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Player _player;
    private PlayerView _playerView;
    private MovementController _movementController;

    private Texture2D _tileset;
    private Map _map;
    private MapView _mapView;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = WindowWidth;
        _graphics.PreferredBackBufferHeight = WindowHeight;
        _graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Globals.content = this.Content;
        Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.graphicsDevice = GraphicsDevice;
        
        _tileset = Content.Load<Texture2D>("Maps\\[A]Grass_pipo");
        _map = new Map(_tileset, 32, Map2);
        _mapView = new MapView(_map);
        Console.WriteLine(_map);
        Console.WriteLine(_map is not null);
        var playerTexture = Content.Load<Texture2D>("Sprites\\player");
        _player = new Player(new Vector2(100, 100), playerTexture, _map, 5);
        _playerView = new PlayerView(_player);
        _movementController = new MovementController(_player);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        _movementController.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

        _mapView.Draw();

        _playerView.Draw();
        // _tiledMapRenderer.Draw();

        Globals.spriteBatch.End();

        base.Draw(gameTime);
    }
}