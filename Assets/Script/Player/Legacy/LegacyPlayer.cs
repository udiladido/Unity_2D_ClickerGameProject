using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegacyPlayer : MonoBehaviour
{

    private Animator playerAnim;


    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    
    void Update()
    {
        MouseOnClick();

    }

    private void MouseOnClick()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null && hit.collider.tag == "Enemy")
            {
                EnemyLegacy enemy = hit.collider.GetComponent<EnemyLegacy>();

                if (enemy != null)
                {
                    enemy.EnemyOnClick();

                    playerAnim.SetTrigger("Attack"); 
                }

            }
            
        }


    }

}
