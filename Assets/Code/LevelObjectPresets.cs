using System.Collections;
using System.Collections.Generic;

public class LevelObjectPresets
{
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

    public static LevelObject createDataMemory(bool expectedAddress, bool expectedWriteData, bool expectedReadData) {
        LevelObject levelObject = new LevelObject("data_memory");
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "address", expectedAddress));
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "write_data", expectedWriteData));
        levelObject.GetComponents().Add(new LevelObjectComponent(levelObject, "read_data", expectedReadData));
        return levelObject;
    }
}
