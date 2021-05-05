using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using numpad.input;
using StreamDeckLib;
using StreamDeckLib.Messages;
using YTMDesktop;
using YTMDesktop.settings;

namespace numpad.actions
{
    public abstract class BaseNumPadAction: BaseStreamDeckActionWithSettingsModel<Settings>
    {
        private new static readonly ILogger Logger = Program.LoggerFactory.CreateLogger(nameof(BaseNumPadAction));

        protected string LastContext { get; set; }

        protected Keyboard.ScanCodeShort KeyToSend;

        protected BaseNumPadAction(Keyboard.ScanCodeShort keyToSend)
        {
            KeyToSend = keyToSend;
        }

        protected new void SetModelProperties(StreamDeckEventPayload args)
        {
            base.SetModelProperties(args);
        }
        
        public override Task OnDidReceiveGlobalSettings(StreamDeckEventPayload args)
        {
            SetModelProperties(args);
            LastContext = args.context;
            Logger.LogDebug($"OnDidReceiveGlobalSettings [{SettingsModel}]");
            return Task.CompletedTask;
        }
        
        public override Task OnDidReceiveSettings(StreamDeckEventPayload args)
        {
            SetModelProperties(args);
            LastContext = args.context;
            Logger.LogDebug($"OnDidReceiveSettings [{SettingsModel}]");
            return Task.CompletedTask;
        }

        public override Task OnWillAppear(StreamDeckEventPayload args)
        {
            SetModelProperties(args);
            LastContext = args.context;
            Logger.LogDebug($"OnWillAppear [{SettingsModel}]");
            return Task.CompletedTask;
        }

        public override async Task OnKeyDown(StreamDeckEventPayload args)
        {
            LastContext = args.context;
            await base.OnKeyDown(args);
        }

        public override async Task OnKeyUp(StreamDeckEventPayload args)
        {
            LastContext = args.context;
            var keyboard = new Keyboard();
            keyboard.Send(KeyToSend);
            await base.OnKeyUp(args);
        }

        public override async Task OnWillDisappear(StreamDeckEventPayload args)
        {
            LastContext = args.context;
            await base.OnWillDisappear(args);
        }

        public override async Task OnTitleParametersDidChange(StreamDeckEventPayload args)
        {
            LastContext = args.context;
            await base.OnTitleParametersDidChange(args);
        }

        public override async Task OnDeviceDidConnect(StreamDeckEventPayload args)
        {
            LastContext = args.context;
            await base.OnDeviceDidConnect(args);
        }

        public override async Task OnDeviceDidDisconnect(StreamDeckEventPayload args)
        {
            LastContext = args.context;
            await base.OnDeviceDidDisconnect(args);
        }

        public override async Task OnPropertyInspectorDidDisappear(StreamDeckEventPayload args)
        {
            LastContext = args.context;
            await base.OnPropertyInspectorDidDisappear(args);
        }

        public override async Task OnPropertyInspectorDidAppear(StreamDeckEventPayload args)
        {
            LastContext = args.context;
            await base.OnPropertyInspectorDidAppear(args);
        }
    }
}