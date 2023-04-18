using System.Collections;
using System.Collections.Generic;

public class LevelObjectPresets
{
    public static LevelObject createALU(bool expectedIn1, bool expectedIn2, bool expectedOut) {
        LevelObject levelObject = new LevelObject("alu");
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "expected_in_1", expectedIn1));
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "expected_in_2", expectedIn2));
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "expected_out", expectedOut));
        return levelObject;
    }

    public static LevelObject createDataMemory(bool expectedAddress, bool expectedWriteData, bool expectedReadData) {
        LevelObject levelObject = new LevelObject("data_memory");
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "address", expectedAddress));
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "write_data", expectedWriteData));
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "read_data", expectedReadData));
        return levelObject;
    }

    public static LevelObject createMUX(bool expectedIn1, bool expectedIn2, bool expectedOut) {
        LevelObject levelObject = new LevelObject("mux");
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "expected_in_1", expectedIn1));
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "expected_in_2", expectedIn2));
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "expected_out", expectedOut));
        return levelObject;
    }

    public static LevelObject createRegisterFile(bool expectedReadRegister1, bool expectedReadRegister2, bool expectedWriteRegister, bool expectedWriteData, bool expectedReadData1, bool expectedReadData2) {
        LevelObject levelObject = new LevelObject("register_file");
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "read_register_1", expectedReadRegister1));
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "read_register_2", expectedReadRegister2));
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "write_register", expectedWriteRegister));
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "write_data", expectedWriteData));
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "read_data_1", expectedReadData1));
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "read_data_2", expectedReadData2));
        return levelObject;
    }
}
