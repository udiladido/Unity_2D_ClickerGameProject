using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class LegacyPlayer : MonoBehaviour
{

    private Animator playerAnim;

    public Transform pos;
    public Vector2 boxSize;

    public bool AutoClick = false;
    private float AutoClicktime = 0.5f;

    private Coroutine coroutine;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }


    void Update()
    {

        if(!AutoClick)
        MouseOnClick();             

    }

    public void StartAutoClick()
    {

        
        AutoClick = !AutoClick;

        if (AutoClick)
            coroutine = StartCoroutine(AutoClickCoroutine());
        else
            StopAutoClick();
    }

    public void StopAutoClick()
    {

       StopCoroutine(coroutine);

    }

    private void MouseOnClick()
    {

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ClickAttack();

        }

    }
    private void ClickAttack()
    {

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Enemy")
            {

                EnemyLegacy enemy = collider.GetComponent<EnemyLegacy>();
                if (enemy != null)
                {
                    enemy.EnemyOnClick();

                    playerAnim.SetTrigger("Attack");
                }
            }

        }

    }

    private IEnumerator AutoClickCoroutine()
    {

        while (true)
        {
            ClickAttack();
            yield return new WaitForSeconds(AutoClicktime);
        }

    }
    private void OnDisable()
    {
      
        StopCoroutine(AutoClickCoroutine());
    }

}
