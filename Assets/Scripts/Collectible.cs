using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    public void Collect()
    {
        FindObjectOfType<ScoreManager>().AddScore(1);
        
        Destroy(gameObject);
    }
}
