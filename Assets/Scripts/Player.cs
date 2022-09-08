using Leopotam.Ecs;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MovementSpeed _movementSpeed;
    private EcsEntity _entity;
    public void CreateEntity(EcsWorld world)
    {
        _entity = world.NewEntity();
        _entity.Get<PlayerTag>();
        ref var transformRef = ref _entity.Get<TransformRef>();
        transformRef.Transform = transform;

        _entity.Get<MovementSpeed>() = _movementSpeed;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FailTrigger"))
            _entity.Get<FailCollisionEvent>();
        if (other.CompareTag("WinTrigger"))
            _entity.Get<WinCollisionEvent>();
    }
}