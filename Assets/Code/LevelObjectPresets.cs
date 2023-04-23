using System.Collections;
using System.Collections.Generic;

public class LevelObjectPresets
{
    public static Stage2Object createALU(bool expectedIn1, bool expectedIn2, bool expectedOut) {
        Stage2Object stage2Object = new Stage2Object("alu");
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "expected_in_1", expectedIn1));
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "expected_in_2", expectedIn2));
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "expected_out", expectedOut));
        return stage2Object;
    }

    public static Stage2Object createDataMemory(bool expectedAddress, bool expectedWriteData, bool expectedReadData) {
        Stage2Object stage2Object = new Stage2Object("data_memory");
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "address", expectedAddress));
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "write_data", expectedWriteData));
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "read_data", expectedReadData));
        return stage2Object;
    }

    public static Stage2Object createMUX(bool expectedIn1, bool expectedIn2, bool expectedOut) {
        Stage2Object stage2Object = new Stage2Object("mux");
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "expected_in_1", expectedIn1));
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "expected_in_2", expectedIn2));
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "expected_out", expectedOut));
        return stage2Object;
    }

    public static Stage2Object createRegisterFile(bool expectedReadRegister1, bool expectedReadRegister2, bool expectedWriteRegister, bool expectedWriteData, bool expectedReadData1, bool expectedReadData2) {
        Stage2Object stage2Object = new Stage2Object("register_file");
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "read_register_1", expectedReadRegister1));
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "read_register_2", expectedReadRegister2));
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "write_register", expectedWriteRegister));
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "write_data", expectedWriteData));
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "read_data_1", expectedReadData1));
        stage2Object.GetComponents().Add(new Stage2ObjectComponent(stage2Object, "read_data_2", expectedReadData2));
        return stage2Object;
    }
}
