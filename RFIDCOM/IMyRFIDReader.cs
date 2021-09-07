using System.Runtime.InteropServices;

namespace RFIDCOM
{
    [ComVisible(true)]
    [Guid("6F0E241A-8575-44BF-B237-2B1913ABD102")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]

    internal interface IMyRFIDReader
    {
        [DispId(1)]
        //Установка значений
        string Set(string IP, int port, int timeOut);

        [DispId(2)]
        //4. описываем методы которые можно будет вызывать из вне
        void Start();


        [DispId(3)]
        //4. описываем методы которые можно будет вызывать из вне
        void Stop();

        [DispId(4)]
        //4. описываем методы которые можно будет вызывать из вне
        void TagReaded();

        [DispId(5)]
        //4. описываем методы которые можно будет вызывать из вне
        void SendEvent();
    }
    
}