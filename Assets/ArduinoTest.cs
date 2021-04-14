using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class ArduinoTest : MonoBehaviour
{
    public bool hasSendMessage = false;

    public SerialPort stream;
    public string dataString = null;
    public float TimerSet;
    private float Timer;
    private void Awake()
    {
        //initialize stream open
        stream = new SerialPort("COM4", 9600);
        stream.ReadTimeout = 50;
        stream.Open();
    }

    private void Update()
    {
        //send message to arduino
        if (!hasSendMessage)
        {
            WriteToArduino("PING");
            hasSendMessage = true;
            ReadFromArduino();
        }
        if(Timer<=0)
        {
            hasSendMessage = false;
            Timer = TimerSet;
        }
        Timer -= Time.deltaTime;

    }

    public void WriteToArduino(string message)
    {
        stream.WriteLine(message);
        stream.BaseStream.Flush();
    }

    public void ReadFromArduino()
    {
        //stream.ReadTimeout = timeout;

        /* StartCoroutine
         (
             AsynchronousReadFromArduino
             (
                 (string s) => Debug.Log(s),     // Callback
                 () => Debug.LogError("Error!"), // Error callback
                 10000f                          // Timeout (milliseconds)
             )
         );
 */
        /*return dataString;*/

        try
        {
            dataString = stream.ReadLine();
        }
        catch (TimeoutException e)
        {
            dataString= null;
        }
    }

    public IEnumerator AsynchronousReadFromArduino(Action<string> callback, Action fail = null, float timeout = float.PositiveInfinity)
    {
        DateTime initialTime = DateTime.Now;
        DateTime nowTime;
        TimeSpan diff = default(TimeSpan);

        /*dataString = null;*/

        do
        {
            try
            {
                dataString = stream.ReadLine();
            }
            catch (TimeoutException)
            {
                dataString = null;
            }

            if (dataString != null)
            {
                callback(dataString);
                Debug.Log(dataString);
                yield break; // Terminates the Coroutine
            }
            else
            {
                Debug.Log("Wait for data");
                yield break;// Wait for next frame
            }


            nowTime = DateTime.Now;
            diff = nowTime - initialTime;

        } while (diff.Milliseconds < timeout);

        if (fail != null)
            fail();
        yield return null;
    }
}
