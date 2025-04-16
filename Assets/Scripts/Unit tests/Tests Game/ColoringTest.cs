using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ColoringTest
{
    //[Test]
    //public void ColoringTestSimplePasses()
    //{
        
    //}

    [UnityTest]
    public IEnumerator ColoringTestWithEnumeratorPasses()
    {
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<ColorSprite>();
        gameObject.GetComponent<ColorSprite>().CheckingForColorMatching() ;
        yield return null;
    }


}
