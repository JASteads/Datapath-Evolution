using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectPresets
{
    public static Stage2Object createALU(bool expectedIn1, bool expectedIn2, bool expectedOut) {
        Stage2Object aluObj = new Stage2Object("ALU");
        InterfaceTool.FormatRectNPos(aluObj.GetTF(), new Vector2(140, 140));

        Stage2ObjectNode in1Obj = new Stage2ObjectNode(aluObj, "In 1", expectedIn1, NodeType.INPUT);
        in1Obj.GetImage().color = Color.gray;
        InterfaceTool.FormatRect(in1Obj.GetTF(), new Vector2(40, 40), new Vector2(-10, 30));
        aluObj.AddNode(in1Obj);

        Stage2ObjectNode in2Obj = new Stage2ObjectNode(aluObj, "In 2", expectedIn2, NodeType.INPUT);
        in2Obj.GetImage().color = Color.gray;
        InterfaceTool.FormatRect(in2Obj.GetTF(), new Vector2(40, 40), new Vector2(-10, -30));
        aluObj.AddNode(in2Obj);

        Stage2ObjectNode outObj = new Stage2ObjectNode(aluObj, "Out", expectedIn2, NodeType.OUTPUT);
        outObj.GetImage().color = Color.gray;
        InterfaceTool.FormatRect(outObj.GetTF(), new Vector2(40, 40), new Vector2(10, 0));
        aluObj.AddNode(outObj);
        
        return aluObj;
    }

    public static Stage2Object createDataMemory(bool expectedAddress, bool expectedWriteData, bool expectedReadData) {
        Stage2Object stage2Object = new Stage2Object("data_memory");
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "address", expectedAddress, NodeType.INPUT));
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "write_data", expectedWriteData, NodeType.INPUT));
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "read_data", expectedReadData, NodeType.OUTPUT));
        return stage2Object;
    }

    public static Stage2Object createMUX(bool expectedIn1, bool expectedIn2, bool expectedOut) {
        Stage2Object stage2Object = new Stage2Object("mux");
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "expected_in_1", expectedIn1, NodeType.INPUT));
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "expected_in_0", expectedIn2, NodeType.INPUT));
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "expected_out", expectedOut, NodeType.OUTPUT));
        return stage2Object;
    }

    public static Stage2Object createRegisterFile(bool expectedReadRegister1, bool expectedReadRegister2, bool expectedWriteRegister, bool expectedWriteData, bool expectedReadData1, bool expectedReadData2) {
        Stage2Object stage2Object = new Stage2Object("register_file");
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "read_register_1", expectedReadRegister1, NodeType.INPUT));
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "read_register_2", expectedReadRegister2, NodeType.INPUT));
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "write_register", expectedWriteRegister, NodeType.INPUT));
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "write_data", expectedWriteData, NodeType.INPUT));
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "read_data_1", expectedReadData1, NodeType.OUTPUT));
        stage2Object.GetNodes().Add(new Stage2ObjectNode(stage2Object, "read_data_2", expectedReadData2, NodeType.OUTPUT));
        return stage2Object;
    }
}
