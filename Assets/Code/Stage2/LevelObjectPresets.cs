using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectPresets
{
    public static Stage2Object CreateALU(int xPosition, int yPosition, bool expectedIn1, bool expectedIn2, bool expectedOut) {
        Stage2Object aluObj = new Stage2Object("ALU");
        InterfaceTool.FormatRect(aluObj.GetTF(), new Vector2(140, 140), new Vector2(xPosition, yPosition));

        Stage2ObjectNode in1Obj = new Stage2ObjectNode(aluObj, "In 1", expectedIn1, NodeType.INPUT);
        in1Obj.GetImage().color = Color.gray;
        in1Obj.GetTF().anchoredPosition = new Vector2(-10, 30);
        aluObj.AddNode(in1Obj);

        Stage2ObjectNode in2Obj = new Stage2ObjectNode(aluObj, "In 2", expectedIn2, NodeType.INPUT);
        in2Obj.GetImage().color = Color.gray;
        in2Obj.GetTF().anchoredPosition = new Vector2(-10, -30);
        aluObj.AddNode(in2Obj);

        Stage2ObjectNode outObj = new Stage2ObjectNode(aluObj, "Out", expectedOut, NodeType.OUTPUT);
        outObj.GetImage().color = Color.gray;
        outObj.GetTF().anchoredPosition = new Vector2(10, 0);
        aluObj.AddNode(outObj);

        return aluObj;
    }

    public static Stage2Object CreateDataMemory(int xPosition, int yPosition, bool expectedAddress, bool expectedWriteData, bool expectedReadData) {
        Stage2Object dataMemoryObj = new Stage2Object("Data Memory");
        InterfaceTool.FormatRect(dataMemoryObj.GetTF(), new Vector2(300, 300), new Vector2(xPosition, yPosition));

        Stage2ObjectNode addressObj = new Stage2ObjectNode(dataMemoryObj, "Address", expectedWriteData, NodeType.INPUT);
        addressObj.GetImage().color = Color.gray;
        addressObj.GetTF().anchoredPosition = new Vector2(-10, 80);
        dataMemoryObj.AddNode(addressObj);

        Stage2ObjectNode writeDataObj = new Stage2ObjectNode(dataMemoryObj, "Write Data", expectedWriteData, NodeType.INPUT);
        writeDataObj.GetImage().color = Color.gray;
        writeDataObj.GetTF().anchoredPosition = new Vector2(-10, -80);
        dataMemoryObj.AddNode(writeDataObj);

        Stage2ObjectNode readDataObj = new Stage2ObjectNode(dataMemoryObj, "Read Data", expectedReadData, NodeType.OUTPUT);
        readDataObj.GetImage().color = Color.gray;
        readDataObj.GetTF().anchoredPosition = new Vector2(10, 0);
        dataMemoryObj.AddNode(readDataObj);

        return dataMemoryObj;
    }

    public static Stage2Object CreateInstructionMemory(int xPosition, int yPosition, bool expectedReadAddress, bool expectedInstruction) {
        Stage2Object instructionMemoryObj = new Stage2Object("Instruction Memory");
        InterfaceTool.FormatRect(instructionMemoryObj.GetTF(), new Vector2(300, 300), new Vector2(xPosition, yPosition));

        Stage2ObjectNode readAddressObj = new Stage2ObjectNode(instructionMemoryObj, "Read Address", expectedReadAddress, NodeType.INPUT);
        readAddressObj.GetImage().color = Color.gray;
        readAddressObj.GetTF().anchoredPosition = new Vector2(-10, 0);
        instructionMemoryObj.AddNode(readAddressObj);

        Stage2ObjectNode instructionObj = new Stage2ObjectNode(instructionMemoryObj, "Instruction", expectedInstruction, NodeType.OUTPUT);
        instructionObj.GetImage().color = Color.gray;
        instructionObj.GetTF().anchoredPosition = new Vector2(10, 0);
        instructionMemoryObj.AddNode(instructionObj);

        return instructionMemoryObj;
    }

    public static Stage2Object CreateMUX(bool expectedIn1, bool expectedIn2, bool expectedOut) {
        Stage2Object stage2Object = new Stage2Object("mux");
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "expected_in_1", expectedIn1, NodeType.INPUT));
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "expected_in_0", expectedIn2, NodeType.INPUT));
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "expected_out", expectedOut, NodeType.OUTPUT));
        return stage2Object;
    }

    public static Stage2Object CreateRegisterFile(int xPosition, int yPosition, bool expectedReadRegister1, bool expectedReadRegister2, bool expectedWriteRegister, bool expectedWriteData, bool expectedReadData1, bool expectedReadData2) {
        Stage2Object registerFileObj = new Stage2Object("Register File");
        InterfaceTool.FormatRect(registerFileObj.GetTF(), new Vector2(300, 300), new Vector2(xPosition, yPosition));

        Stage2ObjectNode readRegister1Obj = new Stage2ObjectNode(registerFileObj, "Read Register 1", expectedReadRegister1, NodeType.INPUT);
        readRegister1Obj.GetImage().color = Color.gray;
        readRegister1Obj.GetTF().anchoredPosition = new Vector2(-10, 120);
        registerFileObj.AddNode(readRegister1Obj);

        Stage2ObjectNode readRegister2Obj = new Stage2ObjectNode(registerFileObj, "Read Register 2", expectedReadRegister2, NodeType.INPUT);
        readRegister2Obj.GetImage().color = Color.gray;
        readRegister2Obj.GetTF().anchoredPosition = new Vector2(-10, 40);
        registerFileObj.AddNode(readRegister2Obj);

        Stage2ObjectNode writeRegisterObj = new Stage2ObjectNode(registerFileObj, "Write Register", expectedWriteRegister, NodeType.INPUT);
        writeRegisterObj.GetImage().color = Color.gray;
        writeRegisterObj.GetTF().anchoredPosition = new Vector2(-10, -40);
        registerFileObj.AddNode(writeRegisterObj);

        Stage2ObjectNode writeDataObj = new Stage2ObjectNode(registerFileObj, "Write Data", expectedWriteData, NodeType.INPUT);
        writeDataObj.GetImage().color = Color.gray;
        writeDataObj.GetTF().anchoredPosition = new Vector2(-10, -120);
        registerFileObj.AddNode(writeDataObj);

        Stage2ObjectNode readData1Obj = new Stage2ObjectNode(registerFileObj, "Read Data 1", expectedReadData1, NodeType.OUTPUT);
        readData1Obj.GetImage().color = Color.gray;
        readData1Obj.GetTF().anchoredPosition = new Vector2(10, 60);
        registerFileObj.AddNode(readData1Obj);

        Stage2ObjectNode readData2Obj = new Stage2ObjectNode(registerFileObj, "Read Data 2", expectedReadData2, NodeType.OUTPUT);
        readData2Obj.GetImage().color = Color.gray;
        readData2Obj.GetTF().anchoredPosition = new Vector2(10, -60);
        registerFileObj.AddNode(readData2Obj);

        return registerFileObj;
    }
}
