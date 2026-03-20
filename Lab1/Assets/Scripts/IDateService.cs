

using System.Collections.Generic;

public interface IDateService
{
    void Save(GameData data, bool overwrite = true);

    GameData Load(string name);
    void Delete(string name);

    IEnumerable<string> ListSaves();
}
