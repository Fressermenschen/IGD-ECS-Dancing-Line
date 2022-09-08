using Leopotam.Ecs;
using UnityEngine;

public class FailTrigger : MonoBehaviour
{
    private EcsEntity _entity;

    public void CreateEntity(EcsWorld world)
    {
        _entity = world.NewEntity();
        _entity.Get<FailTriggerTag>();
    }
}