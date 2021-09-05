using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class fly : MonoBehaviour
{
    public InputActionReference move;
    public float speedMove;

    public Transform XRroot, camXR;



    Vector3 dirZ, dirX;

    Vector2 axisMove;

    float tlerp;


    private void OnEnable()
    {
        //move.action.Enable();





    }

    private void Update()
    {
        axisMove = move.action.ReadValue<Vector2>();

        MoveTeleport();
    }



    void MoveTeleport() 
    {
        if (tlerp<1.0f)
        {

        }


        if (axisMove.magnitude>0)
        {
            dirZ = camXR.TransformDirection(Vector3.forward);
            dirX = camXR.TransformDirection(Vector3.right);


            Vector3 fmovedirnormal = dirZ * axisMove.y + dirX * axisMove.x;
            fmovedirnormal = fmovedirnormal.normalized;

            XRroot.transform.position = XRroot.transform.position + fmovedirnormal * speedMove;



        }
    
    
    
    }


}
