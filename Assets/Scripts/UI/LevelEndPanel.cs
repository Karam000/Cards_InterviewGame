using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A simple class that represents the level end panel and handles its simple operation
/// </summary>
public class LevelEndPanel : MonoBehaviour
{
    [SerializeField] Text PlayerWinsText;

    public void Open(string playerName)  //of course the next step is an interface for all panels with methods but it isn't needed here
    {
        PlayerWinsText.text = playerName + " wins!";
        this.gameObject.SetActive(true);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
