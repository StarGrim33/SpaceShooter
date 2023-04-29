using UnityEngine;

public class Scenes
{
    public string GameScene => _gameScene;

    public string IntroScene => _introScene;

    public string MainMenuScene => _mainMenuScene;

    private readonly string _gameScene = "SampleScene";
    private readonly string _introScene = "Intro";
    private readonly string _mainMenuScene = "MainMenu";
}
