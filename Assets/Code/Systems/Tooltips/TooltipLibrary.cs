public class TooltipLibrary
{
    public static void FetchInfo(string target, out string header, out string body)
    {
        header = body = null;
        
        switch (target)
        {
            case "Control Unit":
                header = "Control Unit";
                body = "The control unit is responsible for directing the flow of data and instructions. It sends control signals to other components to execute instructions.";
                break;
            case "REG_DST":
                header = "REG_DST";
                body = "This control signal selects the destination register for the data that is to be written to memory. It should not be turned off because if it is turned off, the data will not be written to the correct register.";
                break;
            case "REG_WRITE":
                header = "REG_WRITE";
                body = "This control signal enables the write operation to a register. It should not be turned on because the data is being written to memory and not to a register.";
                break;
            case "PC_SRC":
                header = "PC_SRC";
                body = "This control signal selects the source of the program counter value. It should not be turned on because the program counter value is not being used in this datapath.";
                break;
            case "ALU_SRC":
                header = "ALU_SRC";
                body = "This control signal selects the source of the data that is to be written to memory. It should not be turned off because if it is turned off, the data will not be written to the correct memory location.";
                break;
            case "MEM_READ":
                header = "MEM_READ";
                body = "This control signal enables the memory read operation. It should not be turned on because the data is being written to memory and not being read from memory.";
                break;
            case "MEM_WRITE":
                header = "MEM_WRITE";
                body = "This control signal enables the memory write operation. It should not be turned off because if it is turned off, the data will not be written to memory.";
                break;
            case "MEM_TO_REG":
                header = "MEM_TO_REG";
                body = "This control signal selects the source of data to be written to a register. It should not be turned on because the data is being written to memory and not being selected data to send to the register file to write.";
                break;
            case "PC":
                header = "Program Counter (PC)";
                body = "Refers to the program counter, which is a register that stores the memory address of the next instruction to be executed by the CPU.";
                break;
            case "Instruction\nMemory":
            case "Instruction Memory":
                header = "Instruction Memory";
                body = "A type of memory that stores the program instructions to be executed by the CPU. The CPU fetches instructions from this memory as it executes a program.";
                break;
            case "Register\nFile":
            case "Register File":
                header = "Register File";
                body = "A register is a storage unit within a CPU that can hold data temporarily. The register file is used to store operands for the ALU and to hold intermediate results during the execution of instructions.";
                break;
            case "Sign Extend":
                header = "Sign Extend";
                body = "The operation increasing the number of bits of a binary number while preserving the number's sign and value.";
                break;
            case "ALU":
                header = "Arithmetic Logic Unit (ALU)";
                body = "In charge of memory address calculations and arithmetic operations. The ALU takes two input values and produces a result based on the operation specified by the control unit.";
                break;
            case "Data\nMemory":
            case "Data Memory":
                header = "Data Memory";
                body = "A type of memory that stores data values used by a program. The CPU can read from and write to this memory as it executes instructions.";
                break;
            case "IF/ID":
                header = "Fetch/Decode";
                body = "During this stage, the CPU fetches the next instruction from memory and decodes it to determine what operation it performs.";
                break;
            case "ID/EX":
                header = "Instruction Decode/Execute";
                body = "During this stage, the CPU decodes the instruction and prepares to execute it.";
                break;
            case "EX/MEM":
                header = "Execute/Memory Access";
                body = "During this stage, the CPU executes the instruction and accesses memory as needed.";
                break;
            case "MEM/WB":
                header = "Memory Access/Write Back";
                body = "During this stage, the CPU accesses memory to retrieve or store data, and writes the result of the instruction back to a register.";
                break;
            default:
                break;
        }
    }
}