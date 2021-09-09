using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RFIDCOM
{
    [ComVisible(true)]
    [Guid("76BBC602-9CBD-40b4-A210-CBB844E7AA70")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IRFIDReader
    {
        [DispId(1)]
        void TagReaded(string value);

        [DispId(2)]
        void Start();

        [DispId(3)]
        void Set(string param);
    }
}
