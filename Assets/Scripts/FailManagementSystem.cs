using Leopotam.Ecs;
using UnityEngine;

public class FailManagementSystem : IEcsRunSystem
{
    private EcsFilter<PlayerTag, FailCollisionEvent, MovementSpeed> _filter;
    public void Run()
    {
        foreach (var i in _filter)
        {
            _filter.GetEntity(i).Del<MovementSpeed>();
            Debug.Log("You lost");
        }
    }
}