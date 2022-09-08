using Leopotam.Ecs;
using UnityEngine;

public class CoinManagementSystem : IEcsRunSystem
{
    private EcsFilter<CoinTag, CoinCollisionEvent, TransformRef> _filter;
    public void Run()
    {
        foreach (var i in _filter)
        {
            Object.Destroy(_filter.Get3(i).Transform.gameObject);
            _filter.GetEntity(i).Destroy();
            Debug.Log("Coin Collected");
        }
    }
}