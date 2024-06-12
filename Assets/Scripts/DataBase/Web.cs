using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;


public class Web : MonoBehaviour
{
    void Start()
    {       
        //StartCoroutine(GetDate());
        //StartCoroutine(GetUsers());
        //StartCoroutine(Login("testuser", "12345678"));
        //StartCoroutine(RegisterUser("testuser3", "testuser3"));
        
    }
    /*
    public void ShowUserItems()
    {
        StartCoroutine(GetItemsIDs(Main.Instance.UserInfo.UserID));
    }
    */
    


    IEnumerator GetDate()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/TugaBackEnd/GetDate.php"))
        { 
           
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }

    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/TugaBackEnd/GetUsers.php"))
        {

            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }

    public IEnumerator Login(string username, string userpassword)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", userpassword);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/TugaBackEnd/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Main.Instance.UserInfo.SetCredentials(username, userpassword);
                Main.Instance.UserInfo.SetID(www.downloadHandler.text);

                if (www.downloadHandler.text.Contains("Wrong password.") || www.downloadHandler.text.Contains("Username does not exists"))
                {
                    Debug.Log("Try Again");
                }
                else
                {
                    Main.Instance.UserProfile.SetActive(true);
                    Main.Instance.Login.gameObject.SetActive(false);
                }

            }
        }

    }

    public IEnumerator RegisterUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/TugaBackEnd/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }

    }

    public IEnumerator GetItemsIDs(string UserID, System.Action<string> callback) //
    {

        WWWForm form = new WWWForm();
        form.AddField("userID", UserID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/TugaBackEnd/GetItemsIDs.php", form))
        {

            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                string jsonArray = www.downloadHandler.text;

                callback(jsonArray);

            }
        }
    }
    
    public IEnumerator GetItem(string itemID, System.Action<string> callback)
    {

        WWWForm form = new WWWForm();
        form.AddField("itemID", itemID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/TugaBackEnd/GetItem.php", form))
        {

            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                string jsonArray = www.downloadHandler.text;

                callback(jsonArray);

            }
        }
     }

}