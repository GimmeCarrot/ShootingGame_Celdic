using System;
using System.Text;

public class TextTypeWriter
{
    private string sourceText;
    private CharEnumerator charEnum;
    private int writeCharCountPerCall;
    private StringBuilder sb = null;
    private bool initialized = false;
    private bool isWriteOver = false;
    private bool moveNextFail = false;

    public bool Initialized
    {
        get
        {
            return initialized;
        }
    }

    public bool IsWriteOver
    {
        get
        {
            return initialized && isWriteOver;
        }
    }

    public void Init(string _sourceText, int _writeCharCountPerCall)
    {
        sourceText = _sourceText;
        writeCharCountPerCall = _writeCharCountPerCall;
        charEnum = sourceText.GetEnumerator();
        sb = new StringBuilder();
        initialized = true;
        isWriteOver = false;
        moveNextFail = false;
    }

    public string WriteText()
    {
        if (!initialized)
            return null;

        if (moveNextFail)
        {
            isWriteOver = true;
        }
        else
        {
            for (int i = 0; i < writeCharCountPerCall; ++i)
            {
                if (!charEnum.MoveNext())
                {
                    moveNextFail = true;
                    break;
                }

                sb.Append(charEnum.Current);
            }
        }
        return sb.ToString();
    }

    public string FlushAll()
    {
        if (!initialized)
            return null;

        while (charEnum.MoveNext())
            sb.Append(charEnum.Current);

        moveNextFail = true;
        return sb.ToString();
    }
}