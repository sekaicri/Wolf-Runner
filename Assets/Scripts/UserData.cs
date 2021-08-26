using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UserData : MonoBehaviour
{
    public static UserData Instance { get; private set; }
    public User user;
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }



}

