using UnityEngine;
using System.Collections;

public class EndEventTest : EndEvent {

    public override void Invoke()
    {
        Debug.Log("Level Complete!");
    }
}
