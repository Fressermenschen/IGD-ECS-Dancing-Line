using Leopotam.Ecs;
using UnityEngine;

public class PlayerMovementSystem : IEcsRunSystem
{
    private Vector3 Direction1 = Vector3.forward;
    private Vector3 Direction2 = Vector3.left;
    private EcsFilter<PlayerTag, TransformRef, MovementSpeed> _filter;
    private int _directionIndex = 0;

    private Vector3 GetDirection()
    {
        if (_directionIndex == 0)
            return Direction1;
        return Direction2;
    }
    
    public void Run()
    {
        foreach (var i in _filter)
        {
            var transform = _filter.Get2(i).Transform;
            if (Input.GetMouseButtonDown(0))
            {
                if (_directionIndex == 0)
                    _directionIndex = 1;
                else
                    _directionIndex = 0;
            }

            var speed = _filter.Get3(i).Speed;
            transform.position += GetDirection() * Time.deltaTime * speed;
        }
    }
}