using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{ 
    [SerializeField] private float moveSpeed = 5f;
    //[SerializeField] private bool movingRight = true;
    [SerializeField] private Vector3 yon;
    [SerializeField] private ZeminSpawner _zeminSpawner;
    //diger scriptlerde de kullanýcagim
    public static bool isDown = false; //kamera takipten kamera takibini durdurucaz
    [SerializeField]public float plusmovespeed;
    /* void Update() ChatGpt 'nin yazdigi
      {
          if (Input.GetMouseButtonDown(0)) // Sol mouse tuþuna týklanýrsa
          {
              ChangeDirection();
          }

          if (movingRight)
              transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
          else
              transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
      }

      void ChangeDirection()
      {
          movingRight = !movingRight;
      }*/

    //benim yazdigim
    private void Start()
    {
        yon = Vector3.forward;
        _zeminSpawner = FindAnyObjectByType<ZeminSpawner>();
    }

    private void Update()
    {
        if (transform.position.y <= 0)
        {
            isDown = true;
            
        }

        if (isDown)
        {
            return;
            //böyle yaparak aþaðýdaki kodlara gitmesini engelliyoruz ve boþ dönmesini saðlýyorz
            //böylelikle aþadðýdaki kodlar çalýþmamýþ oluyor
        }

        //giderek zorluk artmasi
        if (Input.GetMouseButtonDown(0))
        {
            if (yon.x == 0)
            {
                yon = Vector3.left;
            }
            else
            {
                yon = Vector3.forward;
            }
           moveSpeed = moveSpeed + plusmovespeed * Time.deltaTime;
        }
        
    }
    private void FixedUpdate()
    {
        Vector3 hareket = yon * moveSpeed * Time.deltaTime;
        transform.position += hareket;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Zemin")
        {
            collision.gameObject.AddComponent<Rigidbody>();
            _zeminSpawner.GroundSpawner();
            StartCoroutine(zeminDestroy(collision.gameObject));
        }

    }

    IEnumerator zeminDestroy(GameObject silinecekzemin)
    {
        yield return new WaitForSeconds(2);
        Destroy(silinecekzemin);
    }



}
