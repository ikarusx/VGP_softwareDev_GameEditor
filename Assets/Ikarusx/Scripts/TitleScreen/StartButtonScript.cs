﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartButtonScript : MonoBehaviour
    , IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        //SceneManager.LoadScene(SceneManager.GetSceneAt(1).name);
        SceneManager.LoadScene("Second1");
    }
}
