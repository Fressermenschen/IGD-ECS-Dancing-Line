using Leopotam.Ecs;
using UnityEngine;

public class WinManagementSystem : IEcsRunSystem
{
    private EcsFilter<PlayerTag, WinCollisionEvent, MovementSpeed> _filter;
    public void Run()
    {
        foreach (var i in _filter)
        {
            _filter.GetEntity(i).Del<MovementSpeed>();
            Debug.Log("You Win!");
        }
    }
}