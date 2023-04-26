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
            case "Control Unit":
                header = "Control Unit";
                body = "The control unit is responsible for directing the flow of data and instructions.  It sends control signals to other components to execute instructions.";
                break;
            case "PC":
                header = "(PC) Program Counter";
                body = "";
                break;
            case "Register File":
                header = "Register File";
                body = "A register is a storage unit within a CPU that can hold data temporarily.The register file is used to store operands for the ALU and to hold intermediate results during the execution of instructions.";
                break;
            case "Mux":
                header = "Mux (Multiplexer)";
                body = "Digital switch that selects one input from multiple inputs and outputs it can perform complex operations by selecting the appropriate input signal for each operation based on a control signal.";
                break;
            case "Fetch":
                header = "Instruction Fetch";
                body = "The first stage of the pipeline fetches the next instruction from memory and prepares it for execution.";
                break;
            case "Decode":
                header = "Instruction Decode";
                body = "The second stage decodes the instruction and determines what operation needs to be performed.";
                break;
            case "Execute":
                header = "Execute";
                body = "The processor performs the necessary operation on the data, such as addition or multiplication.";
                break;
            case "Memory Access":
                header = "Memory Access";
                body = "If the instruction requires accessing memory, this stage retrieves or stores data in memory.";
                break;
            case " Write-Back":
                header = "Write-Back";
                body = "The results of the operation are written back to the appropriate registers.";
                break;
            case "DEG_DST":
                header = "DEG_DST";
                body = "This control signal selects the destination register for the data that is to be written to memory. It should not be turned off because if it is turned off, the data will not be written to the correct register.";
                break;
            case "ALU_SRC":
                header = "ALU_SRC";
                body = "This control signal selects the source of the data that is to be written to memory. It should not be turned off because if it is turned off, the data will not be written to the correct memory location.";
                break;
            case "MEM_WRITE":
                header = "MEM_WRITE";
                body = "This control signal enables the memory write operation. It should not be turned off because if it is turned off, the data will not be written to memory.";
                break;
            case "REG_WRITE":
                header = "REG_WRITE";
                body = "This control signal enables the write operation to a register. It should not be turned on because the data is being written to memory and not to a register.";
                break;
            case "PC_SRC":
                header = "PC_SRC";
                body = "This control signal selects the source of the program counter value. It should not be turned on because the program counter value is not being used in this datapath.";
                break;
            case "MEM_READ":
                header = "MEM_READ";
                body = "This control signal enables the memory read operation. It should not be turned on because the data is being written to memory and not being read from memory.";
                break;
            case "MEM_TO_REG":
                header = "MEM_TO_REG";
                body = "This control signal selects the source of data to be written to a register. It should not be turned on because the data is being written to memory and not being selected data to send to the register file to write.";
                break;
            default:
                break;
        }
    }
}