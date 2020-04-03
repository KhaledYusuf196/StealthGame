using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameManger : MonoBehaviour
{

    [SerializeField] GameObject Win;
    [SerializeField] GameObject Lose;
    [SerializeField] Transform Player;
    Vector3 startPosition;
    
    
    private static GameManger instance;

    public static GameManger Instance => instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        startPosition = Player.position;
    }
   
    void Update()
    {
        //if (winning)
        //{
        //    Win.active = true;
        //}
        //else if (Losing)
        //    Lose.active = true;

    }

    public void Lost()
    {
        Lose.SetActive(true);
        Invoke("restScene", 2);

    }
    public void Won()
    {
        Win.SetActive(true)  ;
        Invoke("restScene", 2);
    }

    public void restScene()
    {
        Player.position = startPosition;
        Win.SetActive(false);
        Lose.SetActive(false);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("WinningCube"))
    //    {
    //        GameManger.Instance.Won();
    //    }
    //}
}
