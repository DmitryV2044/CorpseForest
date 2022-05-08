using UnityEngine;

public class Open_Close_Inventory : MonoBehaviour
{
    [SerializeField] private Animation OpenAnim;
    private bool isInventoryOpened = false;
    // Start is called before the first frame update
    private void Start()
    {
        OpenAnim = gameObject.GetComponentInParent<Animation>();
    }
    public void Open_Close()
    {
        if (!isInventoryOpened)
        {
            OpenAnim.Play("InventoryOpen");
            isInventoryOpened = true;
        }
        else
        {
            OpenAnim.Play("InventoryClose");
            isInventoryOpened = false;
        }

    }

}
