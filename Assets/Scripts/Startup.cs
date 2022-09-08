using Leopotam.Ecs;
using UnityEngine;

public class Startup : MonoBehaviour
{

    [SerializeField] private Player _player;
    [SerializeField] private Coin[] coin;
    [SerializeField] private FailTrigger _failTrigger;
    [SerializeField] private WinTrigger _winTrigger;
    EcsWorld _world;
    EcsSystems _systems;

    private void Start () {
        // create ecs environment.
        _world = new EcsWorld ();
        _systems = new EcsSystems(_world)
            .Add(new InitSystem())
            .Add(new PlayerMovementSystem())
            .Add(new CoinManagementSystem())
            .Add(new FailManagementSystem())
            .Add(new WinManagementSystem())
            .Inject(_player)
            .Inject(coin)
            .Inject(_failTrigger)
            .Inject(_winTrigger);
        _systems.Init ();
    }

    private void Update () {
        // process all dependent systems.
        _systems.Run ();
    }

    void OnDestroy () {
        // destroy systems logical group.
        _systems.Destroy ();
        // destroy world.
        _world.Destroy ();
    }
}
