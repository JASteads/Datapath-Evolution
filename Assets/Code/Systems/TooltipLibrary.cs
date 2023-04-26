public class TooltipLibrary
{
    public static void FetchInfo(string target, out string header, out string body)
    {
        header = body = null;
        
        switch (target)
        {
            case "ALU":
                header = "ALU -- Arithmetic Logic Unit";
                body = "In charge of memory address calculations and arithmetic operations.The ALU takes two input values and produces a result based on the operation specified by the control unit.";
                break;
            default:
                break;
        }
    }
}