using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2ObjectPresests
{
    public static Stage2Object CreateALU(int xPosition, int yPosition, bool expectedIn1, bool expectedIn2, bool expectedOut) {
        Stage2Object aluObj = new Stage2Object("ALU");
        InterfaceTool.FormatRect(aluObj.GetTF(), new Vector2(140, 140), new Vector2(xPosition, yPosition));
        aluObj.GetImage().sprite = SysManager.sprites[0];

        SysManager.tooltip.AssignTooltip(aluObj.GetImage().transform);

        Stage2ObjectNode in1Obj = new Stage2ObjectNode(aluObj, "In 1", expectedIn1, NodeType.INPUT);
        in1Obj.GetImage().sprite = SysManager.sprites[6];
        in1Obj.GetTF().anchoredPosition = new Vector2(-10, 30);
        aluObj.AddNode(in1Obj);

        Stage2ObjectNode in2Obj = new Stage2ObjectNode(aluObj, "In 2", expectedIn2, NodeType.INPUT);
        in2Obj.GetImage().sprite = SysManager.sprites[6];
        in2Obj.GetTF().anchoredPosition = new Vector2(-10, -30);
        aluObj.AddNode(in2Obj);

        Stage2ObjectNode outObj = new Stage2ObjectNode(aluObj, "Out", expectedOut, NodeType.OUTPUT);
        outObj.GetImage().sprite = SysManager.sprites[6];
        outObj.GetTF().anchoredPosition = new Vector2(10, 0);
        aluObj.AddNode(outObj);

        return aluObj;
    }

    public static Stage2Object CreateDataMemory(int xPosition, int yPosition, bool expectedAddress, bool expectedWriteData, bool expectedReadData) {
        Stage2Object dataMemoryObj = new Stage2Object("Data Memory");
        InterfaceTool.FormatRect(dataMemoryObj.GetTF(), new Vector2(300, 300), new Vector2(xPosition, yPosition));
        dataMemoryObj.GetImage().sprite = SysManager.sprites[3];
        Text text = InterfaceTool.CreateHeader("Data Memory", dataMemoryObj.GetTF(), new Vector2(0, 40), new Vector2(0, -170), 24);
        text.alignment = TextAnchor.MiddleCenter;

        SysManager.tooltip.AssignTooltip(dataMemoryObj.GetImage().transform);

        Stage2ObjectNode addressObj = new Stage2ObjectNode(dataMemoryObj, "Address", expectedWriteData, NodeType.INPUT);
        addressObj.GetImage().sprite = SysManager.sprites[6];
        addressObj.GetTF().anchoredPosition = new Vector2(-10, 80);
        dataMemoryObj.AddNode(addressObj);

        Stage2ObjectNode writeDataObj = new Stage2ObjectNode(dataMemoryObj, "Write Data", expectedWriteData, NodeType.INPUT);
        writeDataObj.GetImage().sprite = SysManager.sprites[6];
        writeDataObj.GetTF().anchoredPosition = new Vector2(-10, -80);
        dataMemoryObj.AddNode(writeDataObj);

        Stage2ObjectNode readDataObj = new Stage2ObjectNode(dataMemoryObj, "Read Data", expectedReadData, NodeType.OUTPUT);
        readDataObj.GetImage().sprite = SysManager.sprites[6];
        readDataObj.GetTF().anchoredPosition = new Vector2(10, 0);
        dataMemoryObj.AddNode(readDataObj);

        return dataMemoryObj;
    }

    public static Stage2Object CreateInstructionMemory(int xPosition, int yPosition, bool expectedReadAddress, bool expectedOut1, bool expectedOut2, bool expectedOut3, bool expectedOut4) {
        Stage2Object instructionMemoryObj = new Stage2Object("Instruction Memory");
        InterfaceTool.FormatRect(instructionMemoryObj.GetTF(), new Vector2(300, 300), new Vector2(xPosition, yPosition));
        instructionMemoryObj.GetImage().sprite = SysManager.sprites[3];
        Text text = InterfaceTool.CreateHeader("Instruction\nMemory", instructionMemoryObj.GetTF(), new Vector2(0, 60), new Vector2(0, -180), 24);
        text.alignment = TextAnchor.MiddleCenter;

        SysManager.tooltip.AssignTooltip(instructionMemoryObj.GetImage().transform);

        Stage2ObjectNode readAddressObj = new Stage2ObjectNode(instructionMemoryObj, "Read Address", expectedReadAddress, NodeType.INPUT);
        readAddressObj.GetImage().sprite = SysManager.sprites[6];
        readAddressObj.GetTF().anchoredPosition = new Vector2(-10, 0);
        instructionMemoryObj.AddNode(readAddressObj);

        Stage2ObjectNode out1Obj = new Stage2ObjectNode(instructionMemoryObj, "Out 1", expectedOut1, NodeType.OUTPUT);
        out1Obj.GetImage().sprite = SysManager.sprites[6];
        out1Obj.GetTF().anchoredPosition = new Vector2(10, 120);
        instructionMemoryObj.AddNode(out1Obj);

        Stage2ObjectNode out2Obj = new Stage2ObjectNode(instructionMemoryObj, "Out 2", expectedOut2, NodeType.OUTPUT);
        out2Obj.GetImage().sprite = SysManager.sprites[6];
        out2Obj.GetTF().anchoredPosition = new Vector2(10, 40);
        instructionMemoryObj.AddNode(out2Obj);

        Stage2ObjectNode out3Obj = new Stage2ObjectNode(instructionMemoryObj, "Out 3", expectedOut3, NodeType.OUTPUT);
        out3Obj.GetImage().sprite = SysManager.sprites[6];
        out3Obj.GetTF().anchoredPosition = new Vector2(10, -40);
        instructionMemoryObj.AddNode(out3Obj);

        Stage2ObjectNode out4Obj = new Stage2ObjectNode(instructionMemoryObj, "Out 4", expectedOut4, NodeType.OUTPUT);
        out4Obj.GetImage().sprite = SysManager.sprites[6];
        out4Obj.GetTF().anchoredPosition = new Vector2(10, -120);
        instructionMemoryObj.AddNode(out4Obj);

        return instructionMemoryObj;
    }

    public static Stage2Object CreateMUX(bool expectedIn1, bool expectedIn2, bool expectedOut) {
        Stage2Object stage2Object = new Stage2Object("mux");
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "expected_in_1", expectedIn1, NodeType.INPUT));
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "expected_in_0", expectedIn2, NodeType.INPUT));
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "expected_out", expectedOut, NodeType.OUTPUT));
        return stage2Object;
    }

    public static Stage2Object CreatePC(int xPosition, int yPosition, bool expectedOut) {
        Stage2Object pcObj = new Stage2Object("PC");
        InterfaceTool.FormatRect(pcObj.GetTF(), new Vector2(40, 160), new Vector2(xPosition, yPosition));
        pcObj.GetImage().sprite = SysManager.sprites[2];

        SysManager.tooltip.AssignTooltip(pcObj.GetImage().transform);

        Stage2ObjectNode outObj = new Stage2ObjectNode(pcObj, "Out", expectedOut, NodeType.OUTPUT);
        outObj.GetImage().sprite = SysManager.sprites[6];
        outObj.GetTF().anchoredPosition = new Vector2(10, 0);
        pcObj.AddNode(outObj);

        return pcObj;
    }

    public static Stage2Object CreateRegisterFile(int xPosition, int yPosition, bool expectedReadRegister1, bool expectedReadRegister2, bool expectedWriteRegister, bool expectedWriteData, bool expectedReadData1, bool expectedReadData2) {
        Stage2Object registerFileObj = new Stage2Object("Register File");
        InterfaceTool.FormatRect(registerFileObj.GetTF(), new Vector2(300, 300), new Vector2(xPosition, yPosition));
        registerFileObj.GetImage().sprite = SysManager.sprites[3];
        Text text = InterfaceTool.CreateHeader("Register File", registerFileObj.GetTF(), new Vector2(0, 40), new Vector2(0, -170), 24);
        text.alignment = TextAnchor.MiddleCenter;

        SysManager.tooltip.AssignTooltip(registerFileObj.GetImage().transform);

        Stage2ObjectNode readRegister1Obj = new Stage2ObjectNode(registerFileObj, "Read Register 1", expectedReadRegister1, NodeType.INPUT);
        readRegister1Obj.GetImage().sprite = SysManager.sprites[6];
        readRegister1Obj.GetTF().anchoredPosition = new Vector2(-10, 120);
        registerFileObj.AddNode(readRegister1Obj);

        Stage2ObjectNode readRegister2Obj = new Stage2ObjectNode(registerFileObj, "Read Register 2", expectedReadRegister2, NodeType.INPUT);
        readRegister2Obj.GetImage().sprite = SysManager.sprites[6];
        readRegister2Obj.GetTF().anchoredPosition = new Vector2(-10, 40);
        registerFileObj.AddNode(readRegister2Obj);

        Stage2ObjectNode writeRegisterObj = new Stage2ObjectNode(registerFileObj, "Write Register", expectedWriteRegister, NodeType.INPUT);
        writeRegisterObj.GetImage().sprite = SysManager.sprites[6];
        writeRegisterObj.GetTF().anchoredPosition = new Vector2(-10, -40);
        registerFileObj.AddNode(writeRegisterObj);

        Stage2ObjectNode writeDataObj = new Stage2ObjectNode(registerFileObj, "Write Data", expectedWriteData, NodeType.INPUT);
        writeDataObj.GetImage().sprite = SysManager.sprites[6];
        writeDataObj.GetTF().anchoredPosition = new Vector2(-10, -120);
        registerFileObj.AddNode(writeDataObj);

        Stage2ObjectNode readData1Obj = new Stage2ObjectNode(registerFileObj, "Read Data 1", expectedReadData1, NodeType.OUTPUT);
        readData1Obj.GetImage().sprite = SysManager.sprites[6];
        readData1Obj.GetTF().anchoredPosition = new Vector2(10, 60);
        registerFileObj.AddNode(readData1Obj);

        Stage2ObjectNode readData2Obj = new Stage2ObjectNode(registerFileObj, "Read Data 2", expectedReadData2, NodeType.OUTPUT);
        readData2Obj.GetImage().sprite = SysManager.sprites[6];
        readData2Obj.GetTF().anchoredPosition = new Vector2(10, -60);
        registerFileObj.AddNode(readData2Obj);

        return registerFileObj;
    }

    public static Stage2Object CreateSignExtend(int xPosition, int yPosition, bool expectedIn, bool expectedOut) {
        Stage2Object signExtendObj = new Stage2Object("Sign Extend");
        InterfaceTool.FormatRect(signExtendObj.GetTF(), new Vector2(80, 160), new Vector2(xPosition, yPosition));
        signExtendObj.GetImage().sprite = SysManager.sprites[8];

        SysManager.tooltip.AssignTooltip(signExtendObj.GetImage().transform);

        Stage2ObjectNode inObj = new Stage2ObjectNode(signExtendObj, "In", expectedOut, NodeType.INPUT);
        inObj.GetImage().sprite = SysManager.sprites[6];
        inObj.GetTF().anchoredPosition = new Vector2(-10, 0);
        signExtendObj.AddNode(inObj);

        Stage2ObjectNode outObj = new Stage2ObjectNode(signExtendObj, "Out", expectedOut, NodeType.OUTPUT);
        outObj.GetImage().sprite = SysManager.sprites[6];
        outObj.GetTF().anchoredPosition = new Vector2(10, 0);
        signExtendObj.AddNode(outObj);

        return signExtendObj;
    }
}
