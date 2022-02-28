using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField nameInputField;

    public void StartNew()
    {
        MainManagerMenu.Instance.PlayerName = nameInputField.text;
        SceneManager.LoadScene(1);
    }


}
