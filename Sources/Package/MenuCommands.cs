using System;
using System.ComponentModel.Design;

namespace Watch3D.Package
{
    interface IMenuCommands
    {
        void RegisterCommand(Guid commandSet, int commandId, Action handler);
    }

    class MenuCommands : IMenuCommands
    {
        readonly IMenuCommandService HostMenuCommandService;

        public MenuCommands(IMenuCommandService service)
        {
            HostMenuCommandService = service;
        }

        MenuCommand CreateMenuCommand(Guid commandSet, int commandId, Action handler) =>
            new MenuCommand(
                (_, __) => handler(),
                new CommandID(commandSet, commandId));

        void AddMenuCommand(MenuCommand menuCommand) =>
            HostMenuCommandService.AddCommand(menuCommand);

        public void RegisterCommand(Guid commandSet, int commandId, Action handler) =>
            AddMenuCommand(
                CreateMenuCommand(commandSet, commandId, handler));
    }
}
