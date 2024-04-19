using CodeMagic.Source;
using CodeMagic.Source.Controllers;
using CodeMagic.Source.Engine;
using CodeMagic.Source.Models;
using CodeMagic.Source.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CodeMagic;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Player _player;
    private PlayerView _playerView;
    private MovementController _movementController;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
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
        var playerTexture = Content.Load<Texture2D>("Sprites\\player");

        _player = new Player(new Vector2(0, 0), playerTexture, 5);
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
        
        _playerView.Draw();
        
        Globals.spriteBatch.End();

        base.Draw(gameTime);
    }
}