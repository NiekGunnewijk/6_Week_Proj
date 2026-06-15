using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Text;

public class NFC : MonoBehaviour
{

    private string tagID;
    private Text tag_output_text;
    private bool tagFound = false;

    private AndroidJavaObject mActivity;
    private AndroidJavaObject mIntent;
    public static event Action<string> OnNFCRetrieved;


    private void OnApplicationFocus(bool focus)
    {

        if (focus)
        {
            CheckNFC();
        }
    }

    void CheckNFC()
    {
        try{

            mActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"); // Activities open apps
            mIntent = mActivity.Call<AndroidJavaObject>("getIntent");

            if (mIntent.Call<string>("getAction") == "android.nfc.action.TECH_DISCOVERED")
            {
                AndroidJavaObject[] ndefMessages = mIntent.Call<AndroidJavaObject[]>("getParcelableArrayExtra", "android.nfc.extra.NDEF_MESSAGES");

                if (ndefMessages == null || ndefMessages.Length == 0)
                {
                    Debug.Log("No NDEF messages found.");
                    return;
                }

                foreach (var message in ndefMessages)
                {
                    AndroidJavaObject[] records = message.Call<AndroidJavaObject[]>("getRecords");
                    foreach (var record in records)
                    {
                        byte[] payload = record.Call<byte[]>("getPayload");
                        string text = DecodeTextPayload(payload);

                        if (OnNFCRetrieved != null)
                        {
                            OnNFCRetrieved(text); //cut string
                        }
                    }

                }
        }
        }
        catch
        {
            Debug.Log("No activity");
        }
    }




    // Claude
    string DecodeTextPayload(byte[] payload)
    {
        if (payload == null || payload.Length == 0)
            return string.Empty;

        // First byte is the status byte
        // Bits 5-0 = language code length, bit 7 = encoding (0=UTF-8, 1=UTF-16)
        int statusByte = payload[0] & 0xFF;
        bool isUtf16 = (statusByte & 0x80) != 0;
        int langCodeLength = statusByte & 0x3F;

        int textStart = 1 + langCodeLength;
        int textLength = payload.Length - textStart;

        if (isUtf16)
            return Encoding.Unicode.GetString(payload, textStart, textLength);
        else
            return Encoding.UTF8.GetString(payload, textStart, textLength);
    }




}
    /*
    void Start()
    {
        tag_output_text.text = "Scan a NFC tag to make the cube disappear...";
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!tagFound)
            {
                try
                {
                    // Create new NFC Android object
                    mActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"); // Activities open apps
                    mIntent = mActivity.Call<AndroidJavaObject>("getIntent");
                    sAction = mIntent.Call<String>("getAction"); // resulte are returned in the Intent object
                    if (sAction == "android.nfc.action.NDEF_DISCOVERED")
                    {
                        Debug.Log("Tag of type NDEF");
                    }
                    else if (sAction == "android.nfc.action.TECH_DISCOVERED")
                    {
                        Debug.Log("TAG DISCOVERED");
                        // Get ID of tag
                        AndroidJavaObject mNdefMessage = mIntent.Call<AndroidJavaObject>("getParcelableExtra", "android.nfc.extra.TAG");
                        if (mNdefMessage != null)
                        {
                            byte[] payLoad = mNdefMessage.Call<byte[]>("getPayload");
                            string text = System.Convert.ToBase64String(payLoad);
                            tag_output_text.text += "This is your tag text: " + text;
                            Destroy(GetComponent("MeshRenderer")); //Destroy Box when NFC ID is displayed
                            tagID = text;
                        }
                        else
                        {
                            tag_output_text.text = "No ID found !";
                        }
                        tagFound = true;
                        // How to read multiple tags maybe with this line mIntent.Call("removeExtra", "android.nfc.extra.TAG");
                        return;
                    }
                    else if (sAction == "android.nfc.action.TAG_DISCOVERED")
                    {
                        Debug.Log("This type of tag is not supported !");
                    }
                    else
                    {
                        tag_output_text.text = "Scan a NFC tag to make the cube disappear...";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string text = ex.Message;
                    tag_output_text.text = text;
                }
            }
        }
    }

*/