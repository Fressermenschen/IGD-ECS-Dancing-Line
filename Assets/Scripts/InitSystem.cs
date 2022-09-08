using Leopotam.Ecs;
using UnityEngine;

public class InitSystem : IEcsInitSystem
{
    private Player _player;
    private Coin[] coin;
    private EcsWorld _world;
    private FailTrigger _failTrigger;
    private WinTrigger _winTrigger;

    public void Init()
    {
        _player.CreateEntity(_world);
        _failTrigger.CreateEntity(_world);
        _winTrigger.CreateEntity(_world);
        foreach(var i in coin)
            i.CreateEntity(_world);
        Debug.Log("System Initialized");
    }
}