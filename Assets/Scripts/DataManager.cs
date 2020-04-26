using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int language; // 0: Default English, 1 -> VietNamese
    private void Start()
    {
        if(Instance == null){
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("Home");
    }
}
