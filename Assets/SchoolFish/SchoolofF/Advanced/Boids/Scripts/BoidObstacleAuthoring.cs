

using System;
using Samples.Boids;
using Unity.Entities;
using UnityEngine;

[AddComponentMenu("DOTS Samples/Boids/BoidObstacle")]
[ConverterVersion("joe", 1)]
public class BoidObstacleAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new BoidObstacle());
    }
}


