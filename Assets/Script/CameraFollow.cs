using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform balltarget;
    [SerializeField] private float lerpTime;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - balltarget.position;
   }
    void LateUpdate()
    {
        if(PlayerController.isDown == false) 
        { 
            transform.position = balltarget.position + offset;
        }
        // Vector3 newpos = Vector3.Lerp(transform.position, offset, lerpTime * Time.deltaTime);
        //transform.position = newpos;
    }
}
