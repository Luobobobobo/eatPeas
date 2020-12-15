using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerChasingState : playerBaseState
{
    //characterBase characterBase;
    //public soliderTest solidertest;
    public override void _AIbaseState(soliderTest solider)
    {
        solidertest = solider;
        choseScript();
        //Debug.Log("敌方士兵正在追击，请躲避！");
        //solider.gameObject.transform.LookAt(new Vector3(solider.playerObj.transform.position.x, solider.gameObject.transform.position.y, solider.playerObj.transform.position.z));
        //solider.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * characterBase.solidSpeed, Space.Self);
        solider.nav.SetDestination(solider.playerObj.transform.position);
        if (distanceLimited() > 10)
        {
            //solider.gameObject.transform.position = Vector3.Lerp(solidertest.gameObject.transform.position, characterBase.originPos, Time.time);
            //iTween.MoveTo(solider.gameObject, characterBase.originPos, 5f);
            solider.nav.SetDestination(characterBase.originPos);
        }
    }
}
