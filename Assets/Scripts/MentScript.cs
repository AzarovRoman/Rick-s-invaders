using UnityEngine;

public class MentScript : MonoBehaviour
{
    private void OnDestroy()
    {
        Ments.ments.Remove(gameObject);
    }
}
