using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
public class QteTrigger : MonoBehaviour
{
    [SerializeField] private GameObject qtePanel;
    [SerializeField] private GameObject losePanel;

    void Update()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        if (SwipeController.swipeRight)
        {
            qtePanel.SetActive(false);
            Time.timeScale = 1;
        }
        if (SwipeController.swipeLeft)
        {
            qtePanel.SetActive(false);
            losePanel.SetActive(true);
        }
        if (SwipeController.swipeUp)
        {
            qtePanel.SetActive(false);
            losePanel.SetActive(true);
        }

        yield return new WaitForSecondsRealtime(2);
        qtePanel.SetActive(false);
        losePanel.SetActive(true);
    }
}