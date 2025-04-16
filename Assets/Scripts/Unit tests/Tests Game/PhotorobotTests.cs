using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PhotorobotTests
{


    [UnityTest]
    public IEnumerator PhotorobotTestWithEnumeratorPasses()
    {
        try
        {

            GameObject gameObject = new GameObject();
            gameObject.AddComponent<CreateRandomPhoto>();
            gameObject.GetComponent<CreateRandomPhoto>().CheckingPhoto();
        }
        catch (NullReferenceException)
        {
            Debug.Log("aaa");
        }

        yield return null;
    }



}
