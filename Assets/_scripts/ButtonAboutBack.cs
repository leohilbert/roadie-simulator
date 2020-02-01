using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAboutBack : MonoBehaviour
{
    public Transform startPosition;
    public Transform positionTeam;
    public GameObject mainMenu;

    private void OnMouseDown()
    {
        StartCoroutine(MoveToPosition(mainMenu, startPosition.position, 1f));
    }

    public IEnumerator MoveToPosition(GameObject _mainMenu, Vector3 position, float timeToMove)
    {
        var currentPos = mainMenu.transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            mainMenu.transform.position = Vector3.Lerp(currentPos, -position, t);
            yield return null;
        }
    }
}
