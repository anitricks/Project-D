using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Constant
{
    public const string PREFAB_STARFISH_0 = "/Prefabs/Starfish/player-0";
    public const string STARTFISH_PREFABS = "Prefabs/Starfish";

    public const string PERAL_PREFABS = "Prefabs/Pearl";
}

public class GM : MonoBehaviour
{
    public static GM _instance { get; private set; }

    public Starfish _player { get; private set; }
    public PixelPerfextCam _mainCam { get; private set; }

    public GameState currentGameState { get; private set; }


    //  ========== managers ==========
    public ScoreManager _SM { get; private set; }
    public ResourceManager _RM { get; private set; }

    // ==============================

    public enum GameState
    {
        MENU,
        IN_GAME,
        STORE,
        END_GAME,
        DEATH
    }

    void Awake()
    {
        _instance = this;

        _mainCam = Camera.main.GetComponent<PixelPerfextCam>();
        //_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Starfish>();

        _SM = GetComponent<ScoreManager>();
        _RM = GetComponent<ResourceManager>();
    }

    void Start()
    {
        _RM.LoadPlayers();
        _RM.LoadPeral();

        //  init state
        UpdateGameState(GameState.IN_GAME);

    }

    void InitGame(int playerIndex = 0)
    {
        // create player
        GameObject obj = Instantiate(_RM.playerPrefabs[playerIndex], new Vector2(0, _mainCam.camHalfHeight / 3 * 2), Quaternion.identity) as GameObject;
        _player = obj.GetComponent<Starfish>();

    }

    private void UpdateGameState(GameState state)
    {
        switch (state)
        {
            case GameState.MENU:
                break;

            case GameState.IN_GAME:
                InitGame();
                break;

            case GameState.DEATH:
                break;

            case GameState.END_GAME:
                break;

            case GameState.STORE:
                break;
        }
    }
}

public class EnemyGenerator : MonoBehaviour
{
    private float coolDown;
    private float timer = 0;

    private int poolAmt = 4;

    private List<Enemy> enemy1;
    private List<Enemy> enemy2;
    private List<Enemy> enemy3;

    public EnemyGenerator(float rate)
    {
        coolDown = rate;



    }

    public void Update(float dt)
    {
        timer += dt;

        if (timer >= coolDown)
        {
            timer -= coolDown;
            Spawn();
        }
    }

    private void Spawn()
    {

    }




}



