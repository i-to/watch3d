using System;
using System.ComponentModel.Design;

namespace Watch3D.Package
{
    public class CommandsRegistrar
    {
        readonly IMenuCommandService MenuCommandService;

        public CommandsRegistrar(IMenuCommandService service)
        {
            MenuCommandService = service;
        }

        public void RegisterCommand(Guid commandSet, int commandId, Action handler)
        {
            var menuCommand = CreateCommand(commandSet, commandId, handler);
            AddToHost(menuCommand);
        }

        MenuCommand CreateCommand(Guid commandSet, int commandId, Action handler)
        {
            var id = new CommandID(commandSet, commandId);
            return new MenuCommand((_, __) => handler(), id);
        }

        void AddToHost(MenuCommand menuCommand) => MenuCommandService.AddCommand(menuCommand);
    }
}
