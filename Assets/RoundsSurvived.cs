using UnityEngine;
using TMPro;
using System.Collections;

public class RoundsSurvived : MonoBehaviour
{
    public TextMeshProUGUI rounds;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        rounds.text = "0";
        int round = 0;

        yield return new WaitForSeconds(.7f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            rounds.text = round.ToString();

            yield return new WaitForSeconds(0.05f);
        }
    }
}
