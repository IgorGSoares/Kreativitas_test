using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    #region VARIABLES
    [SerializeField] float firerate;

    #endregion

    #region RETURN VALUES
    public float GetFireRate() => firerate;

    #endregion
}
