using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Timoteo
{

    //This control which elements will be uncover on the screnn. If the player click on the computer element 
    //then the UI computer will appear on the UI Bar.
    public class WinElementsUI : MonoBehaviour
    {
        [SerializeField] GameObject uiElement;
        [SerializeField] Vector3 scaleDirection;
        [SerializeField] float time;
        [SerializeField] SOObjectsCount objectsCount;

        Transform uiElementPos;
        Image uiImage;

        private void Start()
        {
            uiElementPos = uiElement.GetComponent<Transform>();
            uiImage = uiElement.GetComponent<Image>();
        }

        private void OnMouseDown()
        {
            uiImage.color = Color.white;
            LeanTween.scale(uiElementPos.gameObject, scaleDirection, time).setEasePunch();
            objectsCount.objectsCount++;

            if (objectsCount.objectsCount == 7)
            {
                PointsBar.Instance.AddPointsToBar();
                Debug.Log("Won");
            }
            Destroy(this, 4);
        }
    }
}
