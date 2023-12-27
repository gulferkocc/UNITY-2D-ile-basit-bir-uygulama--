
using UnityEngine;

public class Enemies : MonoBehaviour
{

private int dusmancan=3;

public GameObject particleEffectPrefab;

   void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.tag == "Saw"){
        dusmancan--;
         if(dusmancan==0){
        Destroy(gameObject);}//enemy
        Destroy(other.gameObject);//saw
        // prefab => particle effect

       GameObject patlamaEfekti= Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
         // Patlama efektini 2 saniye sonra yok et
                Destroy(patlamaEfekti, 1f);

       
    }
   }
}
