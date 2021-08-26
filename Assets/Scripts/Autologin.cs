using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autologin : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]

    private GameObject image;
    void Start()
    {
        if (PlayerPrefs.HasKey("name")) {
            button.gameObject.SetActive(false);
            image.gameObject.SetActive(false);
        }

    }


}
