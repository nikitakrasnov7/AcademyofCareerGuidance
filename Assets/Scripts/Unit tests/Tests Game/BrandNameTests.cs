using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

public class BrandNameTests
{


    [UnityTest]
    public IEnumerator CheckRegistreTestWithEnumeratorPasses()
    {

        GameObject gameObject = new GameObject();
        GameObject test = new GameObject();
        test.AddComponent<TMP_InputField>();
        gameObject.AddComponent<ControllerBN>();
        gameObject.GetComponent<ControllerBN>().CheckRegistre(test.GetComponent<TMP_InputField>());
        yield return null;

    }



}
