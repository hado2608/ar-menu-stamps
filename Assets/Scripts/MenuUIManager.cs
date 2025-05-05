using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    public MultiItemPlacer placer;

    public GameObject steakPrefab;
    public GameObject omelettePrefab;
    public GameObject padThaiPrefab;

    private List<GameObject> selectedItems = new List<GameObject>();

    public void SelectSteak() => AddItem(steakPrefab);
    public void SelectOmelette() => AddItem(omelettePrefab);
    public void SelectPadThai() => AddItem(padThaiPrefab);

    public void ConfirmOrder()
    {
        placer.SetFoodList(selectedItems);
        gameObject.SetActive(false);
    }

    private void AddItem(GameObject item)
    {
        if (!selectedItems.Contains(item))
            selectedItems.Add(item);
    }
}