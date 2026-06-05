using TMPro;
using UnityEngine;

public class ChestZone : MonoBehaviour
{
    public int currentTreasures;
    public int requiredTreasures = 5;
    public bool counted = false;
    public TMP_Text progressText;

    private void Start()
    {
        progressText.text = $"Bloques: 0/{requiredTreasures}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Treasure"))
            return;

        Treasure treasure = other.GetComponent<Treasure>();

        if (treasure == null || treasure.counted)
            return;

        treasure.counted = true;

        currentTreasures++;

        progressText.text = $"Bloques: {currentTreasures}/{requiredTreasures}";

        if (currentTreasures >= requiredTreasures)
        {
            progressText.text = "¡Felicitaciones! Completaste el desafío";
        }
    }
}