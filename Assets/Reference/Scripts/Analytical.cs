using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reference
{
    public class Analytical : MonoBehaviour
    {
        [SerializeField] protected Vector3 initPos = new Vector3(0f, 0f, 0f);       // 初期位置
        [SerializeField] protected Vector3 initVel = new Vector3(10f, 10f, 0f);     // 初期速度
        [SerializeField] protected Vector3 gravity = new Vector3(0f, -9.8f, 0f);    // 重力加速度

        private Vector3 position;   // 現在位置

        // 最初に一度呼ばれるメソッド．
        void Start()
        {
            // メンバ変数の初期化．
            position = initPos;

            // アタッチしているオブジェクトの位置を初期化．
            this.transform.position = position;
        }

        // FixedUpdate は物理演算を行う際によく用いられる．
		// とりあえず固定の周期で動いてくれるメソッドと思えばいい．
        // 詳細はこちら：https://docs.unity3d.com/ja/2021.1/ScriptReference/MonoBehaviour.FixedUpdate.html
        void FixedUpdate()
        {
            float time = Time.time;     // シミュレーション開始からの経過時間を取得
            position = UpdatePos(time);

            // アタッチしているオブジェクトの位置を更新．
            this.transform.position = position;
        }

        // 現在の時刻から，現在位置を求める
        private Vector3 UpdatePos(float t /* = 現在時刻*/)
        {
            Vector3 pos = Vector3.zero;
            pos = 0.5f * gravity * t * t + initVel * t + initPos;
            return pos;
        }
        
    }
}
