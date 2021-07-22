using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMenuManager : MonoBehaviour
{
    public InputField playerName;

    public void StartTheAction()
    {
        if (string.IsNullOrEmpty(playerName.text) == false)
        {
            // Set name
            GameData.Instance.currentPlayerName = playerName.text;

            // start game
            SceneManager.LoadScene(1);
        }
    }
}
