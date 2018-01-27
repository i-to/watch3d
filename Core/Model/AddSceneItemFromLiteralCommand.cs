using System;
using Watch3D.Core.Utility;
using Watch3D.Core.ViewModel;

namespace Watch3D.Core.Model
{
    public class AddSceneItemFromLiteralCommand
    {
        public Logger Logger { get; }
        public SceneViewModel Scene { get; }
        public SceneItemDeserializer SceneItemDeserializer { get; }

        public AddSceneItemFromLiteralCommand(Logger logger, SceneViewModel scene, SceneItemDeserializer sceneItemDeserializer)
        {
            Scene = scene;
            SceneItemDeserializer = sceneItemDeserializer;
            Logger = logger;
        }

        public bool TryAddFromLiteral(string command)
        {
            var split = command.Split('#');
            if (split.Length != 2)
                return false;

            try
            {
                var name = split[0].IsEmpty() ? "item" : split[0];
                var item = SceneItemDeserializer.Deserialize(name, split[1]);
                Scene.AddItem(item);
            }
            catch (FormatException e)
            {
                Logger.Error($"Failed to add item from command: '{command}'.\n\t"
                             + $"Exception: '{e}");
            }

            return true;
        }
    }
}