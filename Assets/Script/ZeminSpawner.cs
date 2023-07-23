using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Zemin;
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            GroundSpawner();
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void GroundSpawner()
    {
        Vector3 randomyon;
        if (Random.RandomRange(0,2) == 0) // 0 ile 10 arasýnda bir sayý seç demek
        {
            randomyon = Vector3.left;
        }
        else
        {
            randomyon = Vector3.forward;
        }

        Zemin = Instantiate(Zemin,Zemin.transform.position + randomyon ,Quaternion.identity);
    }
}
