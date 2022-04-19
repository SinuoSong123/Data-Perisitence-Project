using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainUIManager : MonoBehaviour
{

    public static MainUIManager Instance;
    public InputField NameField;
    public TextMeshProUGUI title;



    public int bestScore;
    public string nowName;
    public string bestname;

    // Start is called before the first frame update
    void Start()
    {

        Instance = this;
        if (DatenManager.Instance != null)
        {
            bestScore = DatenManager.Instance.bestscore;
            bestname = DatenManager.Instance.Name;

        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(NameField.text);
        title.text="Best Score:" + bestname+":"+bestScore;
  
    }

  
    public void StartNew()
    {
        nowName = NameField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.exit();
#endif
    }


     
}
