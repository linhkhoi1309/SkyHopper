using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelMenuUIEventHandler : MonoBehaviour
{
    UIDocument uIDocument;

    List<Button> levelButtons = new List<Button>();
    private void Awake() {
        uIDocument = GetComponent<UIDocument>();
    }

    private void Start() {
        
    }
}
