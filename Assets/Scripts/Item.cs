using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item")]
public class Item : ScriptableObject {

    [Tooltip("Name used in inventory list")]
    public string name;

    [Tooltip("Sprite used in inventory list")]
    public Sprite icon;

    [Tooltip("3D Game Object used in scene")]
    public GameObject model;

    [Tooltip("Max number of objects player can carry")]
    public int maxCount;
}
