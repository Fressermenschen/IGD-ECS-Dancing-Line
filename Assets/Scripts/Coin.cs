using Leopotam.Ecs;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private EcsEntity _entity;

    public void CreateEntity(EcsWorld world)
    {
        _entity = world.NewEntity();
        _entity.Get<CoinTag>();
        ref var transformRef = ref _entity.Get<TransformRef>();
        transformRef.Transform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _entity.Get<CoinCollisionEvent>();
    }
}