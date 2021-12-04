using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnownErrorAndIssue: MonoBehaviour
{
    [TextArea]
    public string error = "";

    [TextArea]
    public string issue = "Because of the implimented Text-To-Speech, in xcode to do the following: " +
        "1. In xcode, go to 'Unity Framework'." +
        "2. Go to 'Build Phases'." +
        "3. Go to 'Link Binaries with Libraries'." +
        "4. Add 'Speech.framework'." +
        "https://github.com/j1mmyto9/Speech-And-Text-Unity-iOS-Android/issues/59";
}
