public class Slot
{
    public readonly static int MAX_POS = 4;
    public readonly static int NO_MOVE = -1;
    public readonly int expectedPos;
    int curPos;

    public Slot(int _expectedPos)
    {
        curPos = 0;
        expectedPos = _expectedPos;
    }

    public int GetPosition()
    {
        return curPos;
    }

    public bool CheckPosition()
    {
        return curPos == expectedPos;
    }

    public int Translate(bool isForward)
    {
        if ((curPos == 0 && !isForward)
            || (curPos == MAX_POS && isForward))
        {
            return NO_MOVE;
        }

        curPos += isForward ? 1 : -1;

        return curPos;
    }
}