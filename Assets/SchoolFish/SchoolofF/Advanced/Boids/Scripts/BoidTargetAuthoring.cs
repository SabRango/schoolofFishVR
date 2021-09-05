

using System;
using Samples.Boids;
using Unity.Entities;
using UnityEngine;

[AddComponentMenu("DOTS Samples/Boids/BoidTarget")]
[ConverterVersion("joe", 1)]
public class BoidTargetAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new BoidTarget());
    }
}


