using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button TekrarButton;
    void Start()
    {
        TekrarButton.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.isDown == true)
        {
            TekrarButton.gameObject.SetActive(true);
        }
    }

    public void BtnTekrar()
    {
        SceneManager.LoadScene(0);
        TekrarButton.gameObject.SetActive(false);
        Debug.Log("buton gizle");

    }
}
