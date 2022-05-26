using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dashboard : MonoBehaviour
{

    [SerializeField] GameObject _dashboardPanel, _loadingPanel;

    public void PlayOnClick()
    {
        StartCoroutine(Loading());
    }

    public void ExitOnClick()
    {
        Application.Quit();
    }

    IEnumerator Loading()
    {
        _dashboardPanel.SetActive(false);
        _loadingPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
