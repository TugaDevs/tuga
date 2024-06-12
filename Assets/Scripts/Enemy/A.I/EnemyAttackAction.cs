using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ds
{
    [CreateAssetMenu(menuName = "A.I/Enemy Action/Attack Action")]
    public class EnemyAttackAction : EnemyAction
    {
        public int attackScore = 3;
        public float recoveryTime = 2;

        public float maximumAttackAngle = 35;
        public float minimumAttackAngle = -35;

        public float minimumDistanceNeedToAttack = 0;
        public float maximumDistanceNeedToAttack = 3;
    }

}
