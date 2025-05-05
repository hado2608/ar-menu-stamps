using UnityEngine;
using System.Collections.Generic;
using Niantic.ARDK.AR.HitTest;
using Niantic.ARDK.Extensions;
using Niantic.ARDK.Utilities.Input;

public class MultiItemPlacer : MonoBehaviour
{
    public List<GameObject> foodPrefabs = new List<GameObject>();
    private int currentIndex = 0;

    void Update()
    {
        if (ARInput.touchCount == 0 || ARInput.GetTouch(0).phase != TouchPhase.Began)
            return;

        var touch = ARInput.GetTouch(0);
        var session = ARSessionManager.Instance.Session;
        if (session == null) return;

        var camera = ARSessionManager.Instance.Camera;
        var hits = session.CurrentFrame.HitTest(camera, touch.position, ARHitTestResultType.Plane);

        if (hits.Count > 0 && currentIndex < foodPrefabs.Count)
        {
            var pos = hits[0].WorldTransform.ToPosition();
            var rot = hits[0].WorldTransform.ToRotation();

            Instantiate(foodPrefabs[currentIndex], pos, rot);
            currentIndex++;
        }
    }

    public void SetFoodList(List<GameObject> selectedItems)
    {
        foodPrefabs = selectedItems;
        currentIndex = 0;
    }
}