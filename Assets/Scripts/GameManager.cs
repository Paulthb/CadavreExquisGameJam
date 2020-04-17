using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> respwanList = new List<Transform>();
    private int idRespawn = 0;

    public GameObject player = null;

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

        Debug.Log("player pos = " + player.transform.position);
        Debug.Log("respawn pos = " + respwanList[idRespawn].position);
    }

    public void CheckPointPassed()
    {
        idRespawn++;
    }
}
