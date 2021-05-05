using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using numpad.input;
using StreamDeckLib;
using StreamDeckLib.Messages;
using YTMDesktop;

namespace numpad.actions
{
    [ActionUuid(Uuid = "com.maxoumask.numpad.action.0")]
    public class ActionNum0 : BaseNumPadAction
    {
        private new static readonly ILogger Logger = Program.LoggerFactory.CreateLogger(nameof(ActionNum0));

        public override async Task OnWillAppear(StreamDeckEventPayload args)
        {
            await base.OnWillAppear(args);
            await Manager.SetTitleAsync(args.context, "0");
        }

        public ActionNum0() : base(Keyboard.ScanCodeShort.KEY_0)
        {
        }
    }
}