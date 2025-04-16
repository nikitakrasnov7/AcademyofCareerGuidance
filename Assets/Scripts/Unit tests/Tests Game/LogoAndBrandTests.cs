using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LogoAndBrandTests
{

    [UnityTest]
    public IEnumerator LogoAndBrandTestWithEnumeratorPasses()
    {
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<ControllerLB>();
        gameObject.GetComponent<ControllerLB>().CheckResoult();
        yield return null;
    }

}
