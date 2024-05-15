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
    public const int WindowWidth = 1920;
    public const int WindowHeight = 1000;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Player _player;
    private PlayerView _playerView;
    private MovementController _movementController;

    // TiledMap _tiledMap;
    // TiledMapRenderer _tiledMapRenderer;

    private Texture2D _tileset;
    private Map _map;

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
        var playerTexture = Content.Load<Texture2D>("Sprites\\player");

        _player = new Player(new Vector2(0, 0), playerTexture, 5);
        _playerView = new PlayerView(_player);
        _movementController = new MovementController(_player);

        // _tiledMap = Content.Load<TiledMap>("Maps\\field");
        // _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
        _tileset = Content.Load<Texture2D>("Maps\\[A]Grass_pipo");
        var map = new int[,]
        {
            { 1, 2, 1 },
            { 1, 2, 1 },
            { 1, 2, 1 },
            { 1, 2, 1 }
        };
        _map = new Map(_tileset, 32, map);


        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        _movementController.Update();
        // _tiledMapRenderer.Update(gameTime);


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

        _map.Draw();

        _playerView.Draw();
        // _tiledMapRenderer.Draw();

        Globals.spriteBatch.End();

        base.Draw(gameTime);
    }
}