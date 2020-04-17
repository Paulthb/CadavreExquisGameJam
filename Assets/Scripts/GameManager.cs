using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Transform> respwanList = new List<Transform>();
    private int idRespawn = 0;

    public GameObject player = null;
    public GameObject respawnText = null;
    public GameObject FinishText = null;

    #region Singleton Pattern
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }
    #endregion

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void RespawnPlayer()
    {
        Debug.Log("respawn");

        PlayerMovement.Instance.Teleport(respwanList[idRespawn].position);

        StartCoroutine(RespawnText());

        Debug.Log("player pos = " + player.transform.position);
        Debug.Log("respawn pos = " + respwanList[idRespawn].position);
    }

    public void CheckPointPassed()
    {
        idRespawn++;
    }

    public IEnumerator RespawnText()
    {
        respawnText.SetActive(true);
        yield return new WaitForSeconds(1);
        respawnText.SetActive(false);
    }

    public void Finish()
    {
        FinishText.SetActive(true);
        idRespawn = 0;
        StartCoroutine(FinishRespawn());
    }

    public IEnumerator FinishRespawn()
    {
        yield return new WaitForSeconds(3f);
        FinishText.SetActive(false);
        RespawnPlayer();
    }
}
