using Newtonsoft.Json;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RegisterConsumer : MonoBehaviour
{
    [SerializeField]
    private string email, name, lastname, device,age, postalcode, phone;
    [SerializeField]
    private LoginResponse response;
    [SerializeField]
    private InputField email1, name1, lastname1, postalcode1, phone1;
    [SerializeField]
    private UnityEvent succeededRegister;
    [SerializeField]
    private GameObject  mainMenu;
    [SerializeField]
    private GameObject register;
    [SerializeField]
    private Text alert;
    [SerializeField]
    private Toggle check;
    [SerializeField]
    private UnityEvent useEmail;



    public void Age(String age1)
    {

        age = age1;
    }
    public void RegisterPetition()
    {
       
            name = name1.text; 
            lastname = lastname1.text;
            email = email1.text;
#if UNITY_IOS
        device = "IOS";
#elif UNITY_ANDROID
        device = "Android";
#endif
            postalcode = postalcode1.text;
            phone = phone1.text;


       

            if (check.isOn)
            {
                StartCoroutine(AsyncPetition());
            }
            else
            {
                alert.text = "Accept the terms!";

            }
        
       
    }

    private IEnumerator AsyncPetition()

    {
       
        RegisterServiceData serviceData = new RegisterServiceData(name, lastname,phone,age, postalcode,email, device);
        yield return serviceData.SendAsync(Response);
    }


    private void EmailInUse(){
        useEmail.Invoke();
        mainMenu.gameObject.SetActive(true);
        register.gameObject.SetActive(false);

    }
    private void Response(string response, string code)
    {
        //InAppNotification.Instance.HideNotication();
        if (code.Contains("200")) {
            this.response = JsonConvert.DeserializeObject<LoginResponse>(response);
            succeededRegister.Invoke();
            mainMenu.gameObject.SetActive(true);
            register.gameObject.SetActive(false);
            alert.text = "";
            PlayerPrefs.SetString("name", name);


        }
        else if (code.Contains("201")) {
            alert.text = "The mail is already in use";
            PlayerPrefs.SetString("name", name);
            Invoke("EmailInUse", 2f);
        }

        else
        {
            mainMenu.gameObject.SetActive(false);
            register.gameObject.SetActive(true);
            alert.text = "Check all fields";

        }
    }
}
