
using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI scoreText;
   private void Update()
   {
      if (PlayerParameters.IsVictory)
      {
         scoreText.gameObject.SetActive(true);
      }
   }

   private IEnumerator SetScoreCoroutine()
   {
      scoreText.text = "X1";
      yield return new WaitForSeconds(1f);
      scoreText.text = "X2";
      yield return new WaitForSeconds(1f);
      scoreText.text = "X3";
      yield return new WaitForSeconds(1f);
      scoreText.text = "X4";
   }
}
