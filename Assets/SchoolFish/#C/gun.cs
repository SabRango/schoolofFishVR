using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Physics;

public class gun : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mprefab;

    public InputActionReference fire;

    public AudioClip clipgun;

    AudioSource scacudio;

    public float speed=0.6f;

    private BlobAssetStore blobAssetStore;



    bool firednow = false;
    void Start()
    {
        fire.asset.Enable();


        scacudio=GetComponent<AudioSource>();
        scacudio.clip = clipgun;

        fire.action.started += ctx => firednow=true;

        fire.action.canceled += ctx => firednow =false;

    }

    float timerFire = 0;
    void Update()
    {


        

        if (firednow)
        {
            if (timerFire==0)
            {
                FireGun();
            }
            timerFire += 1;



        }
        else
        {
            timerFire = 0;

        }



    }

    public void FireGun()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var world = World.DefaultGameObjectInjectionWorld;
        blobAssetStore = new BlobAssetStore();       

        var settings = GameObjectConversionSettings.FromWorld(world, blobAssetStore);
        var _entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(mprefab, settings);
        var instance = entityManager.Instantiate(_entityPrefab);



        Vector3 dir = transform.TransformDirection(Vector3.forward);

        print("i instanciateddd");
        Quaternion jjj = Quaternion.LookRotation(dir, Vector3.up);
        quaternion qtemp = new quaternion();
        qtemp.value.x = jjj.x;
        qtemp.value.y = jjj.y;
        qtemp.value.z = jjj.z;
        qtemp.value.w = jjj.w;

        //var instance = entityManager.Instantiate(prefab);



        float3 posf = new float3(transform.position.x, transform.position.y, transform.position.z);
        entityManager.SetComponentData(instance, new Translation { Value = posf } );

        entityManager.SetComponentData(instance, new Rotation{ Value = qtemp});

        entityManager.SetComponentData(instance, new PhysicsVelocity()
        {
            Linear = dir * speed,
            Angular = float3.zero
        });


        //var shape = entityManager.GetComponentData<Unity.Physics.Collider>(instance);

        /*entityManager.SetComponentData(instance, new Unity.Physics.Collider()
        {
            Type= ColliderType.Box
        });*/


        //GameObject tempINst = Instantiate(mprefab, transform.position, jjj);

        //tempINst.GetComponent<Rigidbody>().velocity=dir*speed;


        
        scacudio.Play();


    }

    private void OnDestroy()
    {
        // Dispose of the BlobAssetStore, else we're get a message:
        // A Native Collection has not been disposed, resulting in a memory leak.
        if (blobAssetStore != null) { blobAssetStore.Dispose(); }
    }

}
