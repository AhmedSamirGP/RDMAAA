using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    bool Jetpack = false;
    [Header("Refrences")]
    [SerializeField]
    EventSO SwitchEvent;
    [SerializeField]
    GameObject JetbackBar;
    [SerializeField]
    GameObject TimeSlowBar;
    [SerializeField]
    GameObject LosePanel;
    private void Start()
    {
        Jetpack = !Jetpack;
        Switch();
    }
    public void Switch()
    {
        Jetpack = !Jetpack;
        JetbackBar.SetActive(Jetpack);
        TimeSlowBar.SetActive(!Jetpack);
    }
    public void OpenLosePanel()
    {
        LosePanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
